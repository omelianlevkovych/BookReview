using BookReview.Models;
using BusinessLogic.Logic.Interfaces;
using BusinessLogic.Models;
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
        private readonly IBooksLogic booksLogic;

        public BooksController(
            IBooksLogic booksLogic)
        {
            this.booksLogic = booksLogic;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookModel>>> GetBooks()
        {
            return Ok(await booksLogic.GetAll());
        }

        /*
        [HttpGet("{id}")]
        public ActionResult<BookDto> GetBook(int id)
        {
             // return _books.SingleOrDefault(x => x.Id == id);
        }
        */

        [HttpPost]
        public IActionResult AddBook(BookDto book)
        {
           //  _books.Add(book);
            return Ok();
        }

        /*
        [HttpDelete]
        public IActionResult DeleteBook(int id)
        {
            var bookToRemove = _books.SingleOrDefault(x => x.Id == id);
            if (bookToRemove is null)
            {
                return NotFound();
            }
           //  _books.Remove(bookToRemove);
            return Ok();
        }
        */
    }
}
