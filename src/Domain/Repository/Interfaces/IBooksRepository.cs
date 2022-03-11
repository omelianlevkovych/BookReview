using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repository.Interfaces
{
    public interface IBooksRepository : IRepositoryBase<BookEntity>
    {
        Task Delete(int id);

        Task<IEnumerable<BookEntity>> GetBooksByName(string name);

        Task<IEnumerable<BookEntity>> GetSoftDeleted();
    }
}
