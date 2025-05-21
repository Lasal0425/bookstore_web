using BookApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookApi.Services
{
    public class BookService : IBookService
    {
        private readonly List<Book> _books;
        private int _nextId = 1;

        public BookService()
        {
            _books = new List<Book>
            {
                new Book
                {
                    Id = _nextId++,
                    Title = "Clean Code",
                    Author = "Robert C. Martin",
                    ISBN = "978-0132350884",
                    PublicationDate = new DateTime(2008, 8, 1)
                },
                new Book
                {
                    Id = _nextId++,
                    Title = "Design Patterns",
                    Author = "Erich Gamma",
                    ISBN = "978-0201633610",
                    PublicationDate = new DateTime(1994, 11, 10)
                }
            };
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _books;
        }

        public Book? GetBookById(int id)
        {
            return _books.FirstOrDefault(b => b.Id == id);
        }

        public Book AddBook(Book book)
        {
            book.Id = _nextId++;
            _books.Add(book);
            return book;
        }

        public Book? UpdateBook(Book book)
        {
            var existingBook = _books.FirstOrDefault(b => b.Id == book.Id);
            if (existingBook == null)
                return null;

            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.ISBN = book.ISBN;
            existingBook.PublicationDate = book.PublicationDate;

            return existingBook;
        }

        public bool DeleteBook(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                return false;

            return _books.Remove(book);
        }
    }
}
