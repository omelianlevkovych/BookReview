using BusinessLogic.Extensions;
using BusinessLogic.Logic.Interfaces;
using BusinessLogic.Models;
using Domain.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            return booksRepository.Remove(id);
        }

        public async Task<BookModel> Get(int id)
        {
            return (await booksRepository.GetById(id)).ToModel();
        }

        public async Task<IEnumerable<BookModel>> GetAll()
        {
            // TODO: this should be improved
            return (await booksRepository.GetAll()).ToModel();
        }
    }
}
