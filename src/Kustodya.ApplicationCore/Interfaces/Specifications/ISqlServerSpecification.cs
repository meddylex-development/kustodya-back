using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Kustodya.ApplicationCore.Interfaces
{
    public interface ISqlSpecification<T> : ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        Expression<Func<T, object>> GroupBy { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        List<string> IncludeStrings { get; }
        bool IsPagingEnabled { get; }
        Expression<Func<T, object>> OrderBy { get; }
        Expression<Func<T, object>> OrderByDescending { get; }
        int Skip { get; }
        int Take { get; }
    }
}