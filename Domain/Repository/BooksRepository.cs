using Domain.Entities;
using Domain.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class BooksRepository : IBooksRepository
    {
        public Task<BookEntity> Create(BookEntity book)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BookEntity>> GetAll()
        {
            var result = new List<BookEntity>
            {
                new BookEntity
                {
                    Id = 1,
                    Name = "Call of Cthulhu",
                },
            };

            return Task.FromResult<IEnumerable<BookEntity>>(result);
        }

        public Task<BookEntity> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BookEntity> Update(BookEntity book)
        {
            throw new NotImplementedException();
        }
    }
}
