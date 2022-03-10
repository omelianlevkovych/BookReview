using Domain.Data;
using Domain.Entities;
using Domain.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Repository
{
    public class BooksRepository : EfRepositoryBase<BookEntity>, IBooksRepository
    {
        public BooksRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<BookEntity> GetBooksByName(string name)
        {
            return context.Books
                .Where(x => string.Equals(x.Name, name, System.StringComparison.InvariantCultureIgnoreCase))
            .ToList();
        }
    }
}
