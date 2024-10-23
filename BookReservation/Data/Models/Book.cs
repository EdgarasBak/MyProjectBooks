using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string PictureUrl { get; set; }
        public List<BookType> Types { get; set; } = new List<BookType>();
    }
}
