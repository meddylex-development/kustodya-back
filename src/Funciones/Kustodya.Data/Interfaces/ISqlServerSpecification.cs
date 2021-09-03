using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Kustodya.Data.Interfaces
{
    public interface ISqlSpecification<T> : ISpecification<T>
    {
        List<Expression<Func<T, object>>> Includes { get; }
        List<string> IncludeStrings { get; }
    }
}