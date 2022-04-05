using Kustodya.ApplicationCore.Entities.MallaValidadora;
using Kustodya.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.Incapacidades.Data
{
    public class SqlRepository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        private readonly DiagnosticoContext _dbContext;

        public SqlRepository(DiagnosticoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<int> CountAsync(ISqlSpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> GetOneAsync(ISqlSpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public virtual async Task<T> GetByIdAsync(string id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISqlSpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync().ConfigureAwait(false);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        private IQueryable<T> ApplySpecification(ISqlSpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
        }

        public async Task<ICollection<T>> AddRangeAsync(ICollection<T> entities)
        {
            _dbContext.AddRange(entities);
            await _dbContext.SaveChangesAsync();

            return entities;
        }

        Task IAsyncRepository<T>.DeleteRangeAsync(IReadOnlyList<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }

}
