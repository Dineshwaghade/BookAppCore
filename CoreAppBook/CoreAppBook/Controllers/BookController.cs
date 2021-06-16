using CoreAppBook.Models;
using CoreAppBook.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAppBook.Controllers
{
    public class BookController : Controller
    {
        BookRepository _bookRepository = null;

        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public ViewResult GetAllBooks()
        {
            var data= _bookRepository.GetAllBooks();
            return View(data);
        }
        //[Route("Book/getbook/{id}")]
        public ViewResult GetBook(int id)
        {
            var data = _bookRepository.GetBookById(id);
            return View(data);
        }

        public ViewResult AddBook(bool isSuccess=false,int BookId=0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = BookId;
            return View();
        }
        [HttpPost]
        public IActionResult AddBook( BookModel model)
        {
            int id=_bookRepository.AddNewBook(model);
            if(id>0)
            {
                return RedirectToAction(nameof(AddBook),new { isSuccess = true, BookId=id });
            }
            return View();
        }
    }
}
