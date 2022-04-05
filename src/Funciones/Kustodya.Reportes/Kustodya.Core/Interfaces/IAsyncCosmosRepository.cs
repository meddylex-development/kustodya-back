using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace Kustodya.Core.Interfaces
{
    public interface IAsyncCosmosRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);

        Task<int> CountAsync(ISpecification<T> spec);

        Task DeleteAsync(T entity);

        Task<T> GetOneAsync(ISpecification<T> spec);

        Task<T> GetByIdAsync(int id);

        Task<T> GetByIdAsync(string id);

        Task<IReadOnlyList<T>> ListAllAsync();

        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);

        Task UpdateAsync(T entity);
        Task<ICollection<T>> AddRangeAsync(ICollection<T> entities);
        Task DeleteRangeAsync(IReadOnlyList<T> entities);
        Task<T> GetByIdAsync(Guid id);
    }

}