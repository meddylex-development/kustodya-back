using Kustodya.ApplicationCore.Helpers;
using Kustodya.ApplicationCore.Helpers.Query;
using Kustodya.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Kustodya.ApplicationCore.Specifications
{
    public abstract class BaseSpec<T> : ISqlSpecification<T>
    {
        protected BaseSpec(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria { get; }
        public Expression<Func<T, object>> GroupBy { get; private set; }
        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();
        public List<string> IncludeStrings { get; } = new List<string>();
        public bool IsPagingEnabled { get; protected set; } = false;
        public Expression<Func<T, object>> OrderBy { get; private set; }
        public Expression<Func<T, object>> OrderByDescending { get; private set; }
        public int Skip { get; protected set; }
        public int Take { get; protected set; }

        protected virtual void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected virtual void AddIncludes<TProperty>(Func<IncludeAggregator<T>, IIncludeQuery<T, TProperty>> includeGenerator)
        {
            var includeQuery = includeGenerator(new IncludeAggregator<T>());
            IncludeStrings.AddRange(includeQuery.Paths);
        }

        protected virtual void AddInclude(string includeString)
        {
            IncludeStrings.Add(includeString);
        }

        //Not used anywhere at the moment, but someone requested an example of setting this up.
        protected virtual void ApplyGroupBy(Expression<Func<T, object>> groupByExpression)
        {
            GroupBy = groupByExpression;
        }

        protected virtual void ApplyOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        protected virtual void ApplyOrderByDescending(Expression<Func<T, object>> orderByDescendingExpression)
        {
            OrderByDescending = orderByDescendingExpression;
        }

        protected virtual void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }
    }
}