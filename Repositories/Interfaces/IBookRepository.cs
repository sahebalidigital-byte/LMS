using LMS.Models;

namespace LMS.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllBooks();

        Task<Book> GetBookById(int id);
        Task<int> AddBook(Book book);
        Task UpdateBook(int id, Book book);
        Task DeleteBook(int id);
    }
}
