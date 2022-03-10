using Domain.Data;
using Domain.Entities;
using Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class EfRepositoryBase<T>: IRepositoryBase<T> where T: EntityBase
    {
        protected readonly ApplicationDbContext context;
        public EfRepositoryBase(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<T> GetById(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().FirstOrDefaultAsync(predicate); 
        }

        public async Task Add(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public Task Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            return context.SaveChangesAsync();
        }

        public Task Remove(T entity)
        {
            context.Set<T>().Remove(entity);
            return context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate)
        {
            return await context.Set<T>().Where(predicate).ToListAsync();
        }

        public Task<int> CountAll() => context.Set<T>().CountAsync();

        public Task<int> Count(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().CountAsync(predicate);
        }
    }
}
