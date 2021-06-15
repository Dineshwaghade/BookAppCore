using CoreAppBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAppBook.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return datasource().ToList();
        }

        public BookModel GetBookById(int id)
        {
            return datasource().Where(x => x.Id == id).FirstOrDefault();
        }
        private List<BookModel> datasource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id=1,Title="Java", Author="xyz",Description="This is description for Java book",ToTalPages=100,Category="Programming",Language="English"},
                new BookModel(){Id=2,Title="PHP", Author="xyz",Description="This is description for PHP book",ToTalPages=110,Category="Programming",Language="English"},
                new BookModel(){Id=3,Title="C#", Author="xyz",Description="This is description for C# book",ToTalPages=120,Category="Programming",Language="English"}

            };
        }
    }
}
