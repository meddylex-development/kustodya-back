using System;
using System.Linq.Expressions;

namespace Kustodya.ApplicationCore.Interfaces
{
    public interface ISpecification<T>
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