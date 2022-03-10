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
        public Task<IEnumerable<BookModel>> GetBooks()
        {
            return booksLogic.GetAll();
        }

        
        [HttpGet("{id}")]
        public Task<BookModel> GetBook(int id)
        {
             return booksLogic.Get(id);
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
    }
}
