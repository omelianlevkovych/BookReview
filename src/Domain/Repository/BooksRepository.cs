using Domain.Data;
using Domain.Entities;
using Domain.Repository.Interfaces;
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

        public IEnumerable<BookEntity> GetBooksByName(string name)
        {
            return context.Books
                .Where(x => string.Equals(x.Name, name, System.StringComparison.InvariantCultureIgnoreCase))
            .ToList();
        }

        public Task Remove(int id)
        {
            var book = new BookEntity() { Id = id };
            context.Books.Attach(book);
            context.Books.Remove(book);
            return context.SaveChangesAsync();
        }
    }
}
