using LMS.Data;
using LMS.Models;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;
using System.Net;
using LMS.Repositories.Interfaces;

namespace LMS.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly AppdbContext _context;

        public BookRepository(AppdbContext context)
        {
            _context = context;
        }
        public async Task<int> AddBook(Book book)
        {
            if (book.Name != null)
            {
                _context.Books.Add(book);
                await _context.SaveChangesAsync();
                return book.Id;
            }
            return 0;
        }

        public async Task DeleteBook(int id)
        {
            var book = new Book() { Id = id };
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }

        public Task<List<Book>> GetAllBooks()
        {
            return _context.Books.ToListAsync();
        }

        public async Task<Book> GetBookById(int id)
        {
            var book = await _context.Books.FindAsync(id);
            return book;
        }

        public async Task UpdateBook(int id, Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }
    }
}
