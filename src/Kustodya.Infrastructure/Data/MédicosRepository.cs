using Kustodya.ApplicationCore.Entities.Medicos;
using Kustodya.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kustodya.Infrastructure.Data
{
    public class MedicosRepository : IAsyncRepository<Medico>
    {
        private readonly MedicosContext _dbContext;

        public MedicosRepository(MedicosContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Medico> AddAsync(Medico entity)
        {
            _dbContext.Medicos.Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<int> CountAsync(ISqlSpecification<Medico> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        public async Task DeleteAsync(Medico entity)
        {
            _dbContext.Medicos.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Medico> GetOneAsync(ISqlSpecification<Medico> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public virtual async Task<Medico> GetByIdAsync(string id)
        {
            return await _dbContext.Set<Medico>().FindAsync(id);
        }

        public virtual async Task<Medico> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Medico>().FindAsync(id);
        }

        public async Task<IReadOnlyList<Medico>> ListAllAsync()
        {
            return await _dbContext.Set<Medico>().ToListAsync();
        }

        public async Task<IReadOnlyList<Medico>> ListAsync(ISqlSpecification<Medico> spec)
        {
            return await ApplySpecification(spec).ToListAsync().ConfigureAwait(false);
        }

        public async Task UpdateAsync(Medico entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        private IQueryable<Medico> ApplySpecification(ISqlSpecification<Medico> spec)
        {
            return SpecificationEvaluator<Medico>.GetQuery(_dbContext.Set<Medico>().AsQueryable(), spec);
        }

        public Task<ICollection<Medico>> AddRangeAsync(ICollection<Medico> entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRangeAsync(IReadOnlyList<Medico> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Medico> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
