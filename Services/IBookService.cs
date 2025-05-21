using BookApi.Models;
using System.Collections.Generic;

namespace BookApi.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
        Book AddBook(Book book);
        Book UpdateBook(Book book);
        bool DeleteBook(int id);
    }
}