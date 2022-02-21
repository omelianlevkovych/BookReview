using BookReview.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly HashSet<BookDto> _books = new()
        {
            new BookDto { Id = 1, Name = "Call of Cthulhu" },
            new BookDto { Id = 2, Name = "Raven" },
        };

        [HttpGet]
        public ActionResult<IEnumerable<BookDto>> GetBooks()
        {
            return _books;
        }

        [HttpGet("{id}")]
        public ActionResult<BookDto> GetBook(int id)
        {
            return _books.SingleOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public IActionResult AddBook(BookDto book)
        {
            _books.Add(book);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteBook(int id)
        {
            var bookToRemove = _books.SingleOrDefault(x => x.Id == id);
            if (bookToRemove is null)
            {
                return NotFound();
            }
            _books.Remove(bookToRemove);
            return Ok();
        }
    }
}
