using CoreAppBook.Models;
using CoreAppBook.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAppBook.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        private readonly LanguageRepository _languageRepository = null;


        public BookController(BookRepository bookRepository,LanguageRepository languageRepository)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
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
        //[Route("Book/getbook/{id}")]
        public async Task<ViewResult> GetBook(int id)
        {
            var data = await _bookRepository.GetBookById(id);
            return View(data);
        }

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
        [HttpPost]
        public async Task<IActionResult> AddBook( BookModel model)
        {
            if(ModelState.IsValid)
            {
                int id = await _bookRepository.AddNewBook(model);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddBook), new { isSuccess = true, BookId = id });
                }
            }
            ViewBag.Language = new SelectList(await _languageRepository.GetLanguages(), "Id", "Name");

            return View();
        }
    }
}
