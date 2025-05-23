using BookApi.Models;

namespace BookApi.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book?> GetBookByIdAsync(int id);
        Task<Book> AddBookAsync(Book book);
        Task<Book?> UpdateBookAsync(Book book);
        Task<bool> DeleteBookAsync(int id);
    }
}