using Shared;
using Shered.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Interface
{
    public interface IBookService
    {
        Task<IEnumerable<BookDTO>> GetAllBooksAsync();
        Task<BookDTO> GetBookByIdAsync(int id);
        Task<IEnumerable<BookDTO>> SearchBooksAsync(string name, int year, BookType type);
    }
}
