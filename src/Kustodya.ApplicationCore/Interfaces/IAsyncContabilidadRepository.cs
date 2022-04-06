using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.Interfaces
{
    public interface IAsyncContabilidadRepository<T> : IAsyncRepository<T> where T : class
    {
        Task ReplaceAsync(IReadOnlyList<T> entities, ISqlSpecification<T> specification);
    }
}