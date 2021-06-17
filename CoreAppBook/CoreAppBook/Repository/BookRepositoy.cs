using CoreAppBook.Data;
using CoreAppBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace CoreAppBook.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;
        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            var data = await _context.Books
                .Select(x=> new BookModel() { 
                Id=x.Id,
                Title=x.Title,
                Author=x.Author,
                Description=x.Description,
                ToTalPages=x.ToTalPages,
                CreatedOn=x.CreatedOn,
                UpdatedOn=x.UpdatedOn,
                LanguageId=x.LanguageId
                })
                .ToListAsync();
            
            return data;
        }

        public async Task<BookModel> GetBookById(int id)
        {
            var data = await _context.Books
                .Select(x => new BookModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Author = x.Author,
                    Description = x.Description,
                    ToTalPages = x.ToTalPages,
                    CreatedOn = x.CreatedOn,
                    UpdatedOn = x.UpdatedOn,
                    LanguageId = x.LanguageId
                })
                .Where(x => x.Id == id).FirstOrDefaultAsync();
            return data;
        }
        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Book()
            {
                Title = model.Title,
                Author = model.Author,
                Description = model.Description,
                ToTalPages = model.ToTalPages.HasValue?model.ToTalPages.Value:0,
                LanguageId = model.LanguageId,
                Category = model.Category,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn=DateTime.UtcNow
               
            };
            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();
            return newBook.Id;
        }

    }
}
