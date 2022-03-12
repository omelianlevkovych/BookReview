using BusinessLogic.Logic.Interfaces;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public Task<IEnumerable<BookModel>> GetBooks()
        {
            return booksLogic.GetAll();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<BookModel>> GetBook(int id)
        {
            var book = await booksLogic.Get(id);
            if (book is null)
            {
                return NotFound();
            }
             return book;
        }
        

        [HttpPost]
        public async Task<ActionResult> AddBook(BookModel book)
        {
            await booksLogic.Add(book);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var bookToRemove = await booksLogic.Get(id);
            if (bookToRemove is null)
            {
                return NotFound();
            }
           
            await booksLogic.Delete(bookToRemove.Id);
            return Ok();
        }

        [HttpGet("trashed")]
        public Task<IEnumerable<BookModel>> GetSoftDeleted()
        {
            return booksLogic.GetSoftDeleted();
        }
    }
}
