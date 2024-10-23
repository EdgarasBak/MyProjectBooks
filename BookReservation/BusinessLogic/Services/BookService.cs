using BusinessLogic.Services.Interface;
using Database.Repository.Interface;
using Shared;
using Shered.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<IEnumerable<BookDTO>> GetAllBooksAsync()
        {
            return await _bookRepository.GetAllBooksAsync();
        }
        public async Task<BookDTO> GetBookByIdAsync(int id)
        {
            return await _bookRepository.GetBookByIdAsync(id);
        }
        public async Task<IEnumerable<BookDTO>> SearchBooksAsync(string name, int year, BookType type)
        {
            return await _bookRepository.SearchBooksAsync(name, year, type);
        }
    }
}
