using Kustodya.ApplicationCore.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Interfaces;

namespace Kustodya.Medicos.Data
{
    public interface ICosmosDbAsyncRepository<TEntidad, TContexto>
        where TEntidad : BaseEntity
        where TContexto : DbContext
    {
        Task<TEntidad> AddAsync(TEntidad entity);

        Task<ICollection<TEntidad>> AddAsync(ICollection<TEntidad> entity);

        Task<int> CountAsync(ICosmosDbSpecification<TEntidad> spec);

        Task DeleteAsync(TEntidad entity);

        Task<TEntidad> GetOneAsync(ICosmosDbSpecification<TEntidad> spec);

        Task<TEntidad> GetByIdAsync(int id);

        Task<TEntidad> GetByIdAsync(Guid id);

        Task<TEntidad> GetByIdAsync(string id);

        Task<IReadOnlyList<TEntidad>> ListAllAsync();

        Task<IReadOnlyList<TEntidad>> ListAsync(ICosmosDbSpecification<TEntidad> spec);

        Task UpdateAsync(TEntidad entity);

        Task UpdateAsync(ICollection<TEntidad> entity);

        Task DeleteAsync(IReadOnlyList<TEntidad> entities);
    }
}