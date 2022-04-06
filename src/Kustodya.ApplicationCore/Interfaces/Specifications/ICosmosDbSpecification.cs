using System;
using System.Linq.Expressions;
using Kustodya.ApplicationCore.Interfaces;

namespace Kustodya.ApplicationCore.Specifications
{
    public interface ICosmosDbSpecification<T> : ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        Expression<Func<T, object>> GroupBy { get; }
        bool IsPagingEnabled { get; }
        Expression<Func<T, object>> OrderBy { get; }
        Expression<Func<T, object>> OrderByDescending { get; }
        int Skip { get; }
        int Take { get; }
    }
}