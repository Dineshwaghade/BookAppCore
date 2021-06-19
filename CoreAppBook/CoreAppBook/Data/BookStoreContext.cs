using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAppBook.Data
{
    public class BookStoreContext:IdentityDbContext
    {
        public BookStoreContext(DbContextOptions <BookStoreContext> options):base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<BookGallery> BookGallery{ get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=DINESH\\DINESHSERVER; database=BookStoreDb; Integrated Security=true;");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
