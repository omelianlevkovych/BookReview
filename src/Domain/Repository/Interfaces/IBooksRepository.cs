using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repository.Interfaces
{
    public interface IBooksRepository : IRepositoryBase<BookEntity>
    {
        public Task Remove(int id);

        public IEnumerable<BookEntity> GetBooksByName(string name);
    }
}
