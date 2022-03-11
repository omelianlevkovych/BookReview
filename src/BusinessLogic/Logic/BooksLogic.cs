using BusinessLogic.Extensions;
using BusinessLogic.Logic.Interfaces;
using BusinessLogic.Models;
using Domain.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public class BooksLogic : IBooksLogic
    {
        private readonly IBooksRepository booksRepository;

        public BooksLogic(
            IBooksRepository booksRepository)
        {
            this.booksRepository = booksRepository;
        }

        public Task Add(BookModel book)
        {
            return booksRepository.Add(book.ToEntity());
        }

        public Task Delete(int id)
        {
            return booksRepository.Delete(id);
        }

        public async Task<BookModel> Get(int id)
        {
            var book = await booksRepository.GetById(id);
            if (book is null)
            {
                throw new Exception("Unable to get the book");
            }

            return book.ToModel();
        }

        public async Task<IEnumerable<BookModel>> GetAll()
        {
            var books = await booksRepository.GetAll();
            return books.ToModel();
        }

        public async Task<IEnumerable<BookModel>> GetSoftDeleted()
        {
            var books = await booksRepository.GetSoftDeleted();
            return books.ToModel();
        }
    }
}
