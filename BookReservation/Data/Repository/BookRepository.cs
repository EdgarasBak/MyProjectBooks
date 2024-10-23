using Database.Models;
using Database.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Shared;
using Shered.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _context;

        public BookRepository(LibraryDbContext context)
        {
            _context = context;

            if (!_context.Books.Any())
            {
                _context.Books.AddRange(
                    new Book
                    {
                        Id = 1,
                        Name = "Harry Potter 1",
                        Year = 1997,
                        PictureUrl = "https://thumb.knygos-static.lt/jmS_3e7-5u1VAbrPv1K-BAByte0=/fit-in/0x800/images/books/14251284/1694523327_Capture.JPG",
                        Types = new List<BookType> { BookType.Book, BookType.Audiobook } 
                    },
                    new Book
                    {
                        Id = 2,
                        Name = "Harry Potter 2",
                        Year = 1998,
                        PictureUrl = "https://www.patogupirkti.lt/media/catalog/product/cache/1/small_image/210x313/9df78eab33525d08d6e5fb8d27136e95/h/a/haris-poteris-ir-paslapciu-kambarys-2-dalis_1.jpg",
                        Types = new List<BookType> { BookType.Book, BookType.Audiobook }
                    },
                    new Book
                    {
                        Id = 3,
                        Name = "Harry Potter 3",
                        Year = 2000,
                        PictureUrl = "https://thumb.knygos-static.lt/ZX320v2JEZCX-R_gNkIA9AE3Zq0=/fit-in/800x800/filters:cwatermark(static/wm.png,500,75,30)/images/books/2152/1462873164_ugnies.jpg",
                        Types = new List<BookType> { BookType.Book, BookType.Audiobook }
                    },
                    new Book
                    {
                        Id = 4,
                        Name = "Harry Potter 4",
                        Year = 1998,
                        PictureUrl = "https://thumb.knygos-static.lt/ZX320v2JEZCX-R_gNkIA9AE3Zq0=/fit-in/800x800/filters:cwatermark(static/wm.png,500,75,30)/images/books/2152/1462873164_ugnies.jpg",
                        Types = new List<BookType> { BookType.Book, BookType.Audiobook }
                    },
                    new Book
                    {
                        Id = 5,
                        Name = "Harry Potter 5",
                        Year = 2003,
                        PictureUrl = "https://upload.wikimedia.org/wikipedia/lt/c/cb/Fenikso_brolija.jpg",
                        Types = new List<BookType> { BookType.Book, BookType.Audiobook }
                    },
                    new Book
                    {
                        Id = 6,
                        Name = "Harry Potter 6",
                        Year = 2005,
                        PictureUrl = "https://thumb.knygos-static.lt/bcenq35-5le98t4HWRAdiPqsXg8=/fit-in/0x800/images/books/14251286/1694520762_Capture.JPG",
                        Types = new List<BookType> { BookType.Book, BookType.Audiobook }
                    },
                    new Book
                    {
                        Id = 7,
                        Name = "Harry Potter 7",
                        Year = 2007,
                        PictureUrl = "https://thumb.knygos-static.lt/G-Kwq8MzibuP8BzqNKhCcdVSAik=/fit-in/0x800/images/books/14251285/1694520111_Capture.JPG",
                        Types = new List<BookType> { BookType.Book, BookType.Audiobook }
                    }
                );
                _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<BookDTO>> GetAllBooksAsync()
        {
            return await _context.Books.Select(b => new BookDTO
            {
                Id = b.Id,
                Name = b.Name,
                Year = b.Year,
                PictureUrl = b.PictureUrl,
                Types = b.Types
            }).ToListAsync();
        }

        public async Task<BookDTO> GetBookByIdAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return null;

            return new BookDTO
            {
                Id = book.Id,
                Name = book.Name,
                Year = book.Year,
                PictureUrl = book.PictureUrl,
                Types = book.Types
            };
        }
        public async Task<IEnumerable<BookDTO>> SearchBooksAsync(string name, int year, BookType type)
        {
            IQueryable<Book> query = _context.Books;

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(b => b.Name.Contains(name));

            if (year > 0) 
                query = query.Where(b => b.Year == year);

                query = query.Where(b => b.Types.Contains(type));

            return await query.Select(b => new BookDTO
            {
                Id = b.Id,
                Name = b.Name,
                Year = b.Year,
                PictureUrl = b.PictureUrl,
                Types = b.Types
            }).ToListAsync();
        }
        public async Task AddBookAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateBookAsync(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }
    }
}
