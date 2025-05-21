using Microsoft.AspNetCore.Mvc;
using BookApi.Models;
using BookApi.Services;
using System;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/Books
        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok(_bookService.GetAllBooks());
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // POST: api/Books
        [HttpPost]
        public IActionResult CreateBook([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            var createdBook = _bookService.AddBook(book);
            return CreatedAtAction(nameof(GetBook), new { id = createdBook.Id }, createdBook);
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book book)
        {
            if (book == null || id != book.Id)
            {
                return BadRequest();
            }

            var updatedBook = _bookService.UpdateBook(book);
            if (updatedBook == null)
            {
                return NotFound();
            }

            return Ok(updatedBook);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var result = _bookService.DeleteBook(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}