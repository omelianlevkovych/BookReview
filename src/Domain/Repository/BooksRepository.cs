using Domain.Data;
using Domain.Entities;
using Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class BooksRepository : EfRepositoryBase<BookEntity>, IBooksRepository
    {
        public BooksRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<BookEntity>> GetBooksByName(string name)
        {
            return await context.Books
                .Where(x => string.Equals(x.Name, name, System.StringComparison.InvariantCultureIgnoreCase))
            .ToListAsync();
        }

        public async Task Delete(int id)
        {
            var book = await context.Books.FindAsync(id);
            
            if (book is null)
            {
                throw new Exception("Unable to find the book.");
            }

            book.SoftDeleted = true;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<BookEntity>> GetSoftDeleted()
        {
            return await context.Books.IgnoreQueryFilters()
                    .Where(x => x.SoftDeleted)
                    .ToListAsync();
        }

    }
}
