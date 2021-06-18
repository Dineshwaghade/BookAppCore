using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAppBook.Data
{
    public class BookGallery
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public Book Book { get; set; }
    }
}
