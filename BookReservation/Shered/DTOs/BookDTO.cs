using Shared;

namespace Shered.DTOs
{
    public class BookDTO
    {
        public int Id {  get; set; }
        public string Name {  get; set; }
        public int Year { get; set; }
        public string PictureUrl { get; set; }
        public List<BookType> Types { get; set; }
    }
}
