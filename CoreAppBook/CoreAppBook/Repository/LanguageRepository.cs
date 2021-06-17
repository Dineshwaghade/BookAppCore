using CoreAppBook.Data;
using CoreAppBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CoreAppBook.Repository
{
    public class LanguageRepository
    {
        private readonly BookStoreContext _context = null;
        public LanguageRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<List<LanguageModel>> GetLanguages()
        {
            var data = await _context.Languages
                .Select(x => new LanguageModel()
                {
                    Id=x.Id,
                    Name=x.Name,
                    Description=x.Description
                })
                .ToListAsync();
            return data;
        }
    }
}
