using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAppBook.Data
{
    public class BookStoreContext:DbContext
    {
        public BookStoreContext(DbContextOptions <BookStoreContext> options):base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DINESH\\DINESHSERVER; database=BookStoreDb; Integrated Security=true;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
