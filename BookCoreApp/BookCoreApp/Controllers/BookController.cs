using BookCoreApp.Models;
using BookCoreApp.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCoreApp.Controllers
{
    public class BookController : Controller
    {
        private BookRepository _bookRepository = null;
        public BookController()
        {
            _bookRepository = new BookRepository();
        }
        public IActionResult Index()
        {
            return View();
        }
        public List<BookModel> GetAllBooks()
        {
            return _bookRepository.GetAllBooks();
        }
        public IActionResult GetBookById(int id)
        {
            return View(_bookRepository.GetBookById(id));
        }
    }
}
