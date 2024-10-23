using Database.Models;
using Shared;
using Shered.DTOs;

namespace Database.Repository.Interface
{
    public interface IBookRepository
    {
        Task<IEnumerable<BookDTO>> GetAllBooksAsync();
        Task<BookDTO> GetBookByIdAsync(int id);
        Task<IEnumerable<BookDTO>> SearchBooksAsync(string name, int year, BookType type);
        Task AddBookAsync(Book book);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(int id);
    }
}
