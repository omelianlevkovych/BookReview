using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repository.Interfaces
{
    public interface IBooksRepository
    {
        Task<BookEntity> GetById(int id);
        Task<IEnumerable<BookEntity>> GetAll();
        Task<BookEntity> Create(BookEntity book);
        Task Delete(int id);
        Task<BookEntity> Update(BookEntity book);
    }
}
