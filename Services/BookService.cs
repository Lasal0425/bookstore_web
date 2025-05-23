using BookApi.Models;

namespace BookApi.Services
{
    public class BookService : IBookService
    {
        private readonly List<Book> _books = new();
        private int _nextId = 1;

        public Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            // Cast List<Book> to IEnumerable<Book>
            return Task.FromResult<IEnumerable<Book>>(_books);
        }

        public Task<Book?> GetBookByIdAsync(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            return Task.FromResult(book);
        }

        public Task<Book> AddBookAsync(Book book)
        {
            book.Id = _nextId++;
            _books.Add(book);
            return Task.FromResult(book);
        }

        public Task<Book?> UpdateBookAsync(Book book)
        {
            var existingBook = _books.FirstOrDefault(b => b.Id == book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.Isbn = book.Isbn;
                existingBook.PublishedDate = book.PublishedDate;
                existingBook.Genre = book.Genre;
            }
            return Task.FromResult(existingBook);
        }

        public Task<bool> DeleteBookAsync(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                _books.Remove(book);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}