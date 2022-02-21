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

        public async Task<IEnumerable<BookModel>> GetAll()
        {
            // TODO: this should be improved
            return (await booksRepository.GetAll()).ToModel();
        }
    }
}
