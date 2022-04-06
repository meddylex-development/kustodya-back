using Kustodya.ApplicationCore.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Interfaces
{
    public interface IIncludeQuery
    {
        Dictionary<IIncludeQuery, string> PathMap { get; }
        IncludeVisitor Visitor { get; }
        HashSet<string> Paths { get; }
    }

    public interface IIncludeQuery<TEntity, out TPreviousProperty> : IIncludeQuery
    {
    }
}
