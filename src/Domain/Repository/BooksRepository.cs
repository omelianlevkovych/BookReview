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

        public async Task Remove(int id)
        {
            var book = await context.Books.FindAsync(id);
            context.Books.Remove(book);
            await context.SaveChangesAsync();
        }
    }
}
