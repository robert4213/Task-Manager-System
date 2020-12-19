using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManager.Core.RepositoryInterface;
using TaskManager.Infrastructure.Data;

namespace TaskManager.Infrastructure.Repository
{
    public class EfRepository<T>:IAsyncRepository<T> where T:class
    {
        protected readonly TaskManagerDbContext _dbContext;

        public EfRepository(TaskManagerDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbContext.Set<T>().Where(filter).ToListAsync();
        }

        public async Task<IEnumerable<T>> ListAllWithIncludesAsync(Expression<Func<T, bool>> @where, params Expression<Func<T, object>>[] includes)
        {
            var query = _dbContext.Set<T>().AsQueryable();

            if (includes != null)
                foreach (Expression<Func<T, object>> navigationProperty in includes)
                    query = query.Include(navigationProperty);

            return await query.Where(where).ToListAsync();
        }
        
        public async Task<bool> GetExistsAsync(Expression<Func<T, bool>> filter = null)
        {
            return !(filter is null) ? await _dbContext.Set<T>().Where(filter).AnyAsync()
            : await _dbContext.Set<T>().AnyAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> AddAsync(IEnumerable<T> entity)
        {
            await _dbContext.Set<T>().AddRangeAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> UpdateAsync(IEnumerable<T> entity)
        {
            foreach (var e in entity)
            {
                _dbContext.Entry(e).State = EntityState.Modified;
            }
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(IEnumerable<T> entity)
        {
            _dbContext.Set<T>().RemoveRange(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}