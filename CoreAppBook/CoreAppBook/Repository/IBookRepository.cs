using CoreAppBook.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreAppBook.Repository
{
    public interface IBookRepository
    {
        Task<int> AddNewBook(BookModel model);
        Task<List<BookModel>> GetAllBooks();
        Task<BookModel> GetBookById(int id);
        Task<List<BookModel>> GetTopBooks(int count);

    }
}