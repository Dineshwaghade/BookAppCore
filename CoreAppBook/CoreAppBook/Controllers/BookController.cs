using CoreAppBook.Models;
using CoreAppBook.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAppBook.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository = null;
        private readonly ILanguageRepository _languageRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public BookController(IBookRepository bookRepository,ILanguageRepository languageRepository, IWebHostEnvironment webHostEnvironment)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<ViewResult> GetAllBooks()
        {
            var data= await _bookRepository.GetAllBooks();
            return View(data);
        }
        public async Task<ViewResult> GetBook(int id)
        {
            var data = await _bookRepository.GetBookById(id);
            return View(data);
        }

        [Authorize(Roles ="Admin")]
        public async Task<ViewResult> AddBook(bool isSuccess=false,int BookId=0)
        {

            //ViewBag.Language = new SelectList(new List<string>() { "hindi", "eng" });

            //ViewData["Language"] = new SelectListItem(new List<LanguageModel>(){
            //        new LanguageModel(){ Id=1,Name="English" },
            //        new LanguageModel(){ Id=2,Name="hindi" }
            //    }, "id", "Name");
            ViewBag.Language = new SelectList(await _languageRepository.GetLanguages(), "Id", "Name");
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = BookId;
            return View();
        }
        [HttpGet]
        [Route("/Account/AccessDenied")]
        public ViewResult AccessDenied()
        {
            return View("Accessdenied");
        }
        [HttpPost]
        public async Task<IActionResult> AddBook( BookModel model)
        {
            if(ModelState.IsValid)
            {
                if (model.CoverPhoto != null)
                {
                    string folder = "Book/cover/";
                    model.CoverImageUrl = await UploadImage(folder, model.CoverPhoto);
                }
                if (model.GalleryFiles != null)
                {
                    string folder = "Book/Gallery/";
                    model.Gallery= new List<GalleryModel>();
                    foreach(var file in model.GalleryFiles)
                    {
                        var gallery = new GalleryModel()
                        {
                            Name = file.FileName,
                            Url = await UploadImage(folder, file)
                        };
                        model.Gallery.Add(gallery);
                    }
                }
                if (model.BookPdf != null)
                {
                    string folder = "Book/pdf/";
                    model.PdfUrl = await UploadImage(folder, model.BookPdf);
                }

                int id = await _bookRepository.AddNewBook(model);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddBook), new { isSuccess = true, BookId = id });
                }
            }
            ViewBag.Language = new SelectList(await _languageRepository.GetLanguages(), "Id", "Name");

            return View();
        }

        private async Task<string> UploadImage(string folder,IFormFile file)
        {
            folder += Guid.NewGuid().ToString() +"_"+ file.FileName;
            string ServerFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
            await file.CopyToAsync(new FileStream(ServerFolder, FileMode.Create));
            return "/" + folder;
        }
    }
}
