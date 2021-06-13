using BookCoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCoreApp.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return Datasourse().ToList();
        }
        public BookModel GetBookById(int id)
        {
            return Datasourse().Where(x => x.Id == id).FirstOrDefault();
        }
        public List<BookModel> SearchBook(string title,string author)
        {
            return Datasourse().Where(x => x.Title == title && x.Author == author).ToList();
        }

        private List<BookModel> Datasourse()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id=1,Title="C#",Author="xyz"},
                new BookModel(){Id=2,Title="Java",Author="xyz"},
                new BookModel(){Id=3,Title="Asp.net",Author="xyz"},
                new BookModel(){Id=4,Title="Net Core",Author="xyz"}
            };
        }
    }
}
