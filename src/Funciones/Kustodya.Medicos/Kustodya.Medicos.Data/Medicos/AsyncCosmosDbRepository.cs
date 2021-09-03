using Kustodya.ApplicationCore.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.Medicos.Data
{
    public class AsyncCosmosDbRepository<T, TContext> : ICosmosDbAsyncRepository<T, TContext> 
        where T : BaseEntity 
        where TContext : DbContext
    {
        private readonly TContext _dbContext;

        public AsyncCosmosDbRepository(TContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<ICollection<T>> AddAsync(ICollection<T> entities)
        {
            await _dbContext.Set<T>().AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();

            return entities;
        }

        public async Task<int> CountAsync(ICosmosDbSpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        public async Task DeleteAsync(IReadOnlyList<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> GetOneAsync(ICosmosDbSpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
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

        public async Task<IReadOnlyList<T>> ListAsync(ICosmosDbSpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync().ConfigureAwait(false);
        }

        public async Task UpdateAsync(T entity)
        {
            //_dbContext.Add(entity.Peticion);
            _dbContext.Entry(entity).Members.ToList().ForEach(m => m.EntityEntry.State = EntityState.Added);
            _dbContext.Entry(entity).State = EntityState.Modified;
            //entity.Detalles?.ForEach(detalle =>
            //        _dbContext.Entry(detalle).State = EntityState.Added);

            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(ICollection<T> entities)
        {
            foreach (var entity in entities)
            {
                _dbContext.Entry(entity).Members.ToList()
                    .ForEach(m => m.EntityEntry.State = EntityState.Added);
                _dbContext.Entry(entity).State = EntityState.Modified;
            }

            await _dbContext.SaveChangesAsync();
        }

        private IQueryable<T> ApplySpecification(ICosmosDbSpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
        }
    }
}
