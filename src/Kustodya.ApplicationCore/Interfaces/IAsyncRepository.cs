using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.Interfaces
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);

        Task<int> CountAsync(ISqlSpecification<T> spec);

        Task DeleteAsync(T entity);

        Task<T> GetOneAsync(ISqlSpecification<T> spec);

        Task<T> GetByIdAsync(int id);

        Task<T> GetByIdAsync(string id);

        Task<IReadOnlyList<T>> ListAllAsync();

        Task<IReadOnlyList<T>> ListAsync(ISqlSpecification<T> spec);

        Task UpdateAsync(T entity);
        Task<ICollection<T>> AddRangeAsync(ICollection<T> entities);
        Task DeleteRangeAsync(IReadOnlyList<T> entities);
        Task<T> GetByIdAsync(Guid id);
    }

}