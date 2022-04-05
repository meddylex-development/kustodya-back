using System;
using System.Linq.Expressions;
using Kustodya.Data.Interfaces;

namespace Kustodya.Data.Interfaces
{
    public interface ICosmosDbSpecification<T> : ISpecification<T>
    {
    }
}