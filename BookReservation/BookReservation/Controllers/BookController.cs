using BusinessLogic.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Shered.DTOs;

namespace BookReservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("GetAllBooks")]
        public async Task<ActionResult<IEnumerable<BookDTO>>> GetAllBooks()
        {
            var books = await _bookService.GetAllBooksAsync();
            if (books == null || !books.Any())
            {
                return NotFound("No books found.");
            }
            return Ok(books);
        }

        [HttpGet("GetBookById/{id}")]
        public async Task<ActionResult<BookDTO>> GetBookById(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound($"Book with ID {id} not found.");
            }
            return Ok(book);
        }

        [HttpPost("SearchBooks")]
        public async Task<ActionResult<IEnumerable<BookDTO>>> SearchBooks([FromQuery] string name, [FromQuery] int? year, [FromQuery] BookType type)
        {
            var books = await _bookService.SearchBooksAsync(name, year ?? default(int), type);
            if (books == null || !books.Any())
            {
                return NotFound("No books found matching the search criteria.");
            }
            return Ok(books);
        }
    }
}
