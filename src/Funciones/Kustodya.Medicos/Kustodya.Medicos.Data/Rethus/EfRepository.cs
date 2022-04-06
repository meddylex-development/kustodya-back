using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using Kustodya.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Roojo.Rethus
{
    public class EfRepository<T> : IAsyncRepository<T> where T : Kustodya.ApplicationCore.Entities.BaseEntity
    {
        protected readonly RethusContext _dbContext;

        public EfRepository(RethusContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISqlSpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<int> CountAsync(ISqlSpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> FirstAsync(ISqlSpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstAsync();
        }

        public async Task<T> FirstOrDefaultAsync(ISqlSpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        private IQueryable<T> ApplySpecification(ISqlSpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
        }

        public async Task<T> GetOneAsync(ISqlSpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public Task<ICollection<T>> AddRangeAsync(ICollection<T> entities)
        {
            throw new System.NotImplementedException();
        }

        Task DeleteRangeAsync(IReadOnlyList<T> entities)
        {
            throw new System.NotImplementedException();
        }

        Task IAsyncRepository<T>.DeleteRangeAsync(IReadOnlyList<T> entities)
        {
            throw new System.NotImplementedException();
        }
    }
}