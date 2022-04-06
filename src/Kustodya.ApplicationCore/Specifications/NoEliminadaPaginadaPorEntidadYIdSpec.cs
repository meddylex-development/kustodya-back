using System;
using System.Linq.Expressions;
using Kustodya.ApplicationCore.Entities.Contabilidades;

namespace Kustodya.ApplicationCore.Specifications
{
    public class NoEliminadaPaginadaPorEntidadYIdSpec<TEntity> : BaseSpec<TEntity>
        where TEntity : IBaseEntity
    {
        // Especificacion con criteria, por id y no eliminado
        public NoEliminadaPaginadaPorEntidadYIdSpec(
            int entidadId, 
            int? pagina = null,
            Expression<Func<TEntity, bool>> criteria = null 
            )
            : base(
                criteria ?? ((Expression<Func<TEntity, bool>>)(e => true))
                    .AndInclude(e => e.Eliminado == false && e.EntidadId == entidadId))
        {
            if(pagina != null) 
                ApplyPaging(pagina.Value);
        }
        
        public NoEliminadaPaginadaPorEntidadYIdSpec(
            Guid id, 
            int entidadId, 
            int? pagina = null,
            Expression<Func<TEntity, bool>> criteria = null 
            )
            : this(entidadId, pagina, e => e.Id == id)
        {
        }

        protected void ApplyPaging(int pagina)
        {
            int skip = Math.Max(pagina - 1, 0) * 10;
            int take = 10;

            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }
    }

    public static class ExpressionExtensions
    {
        public static Expression<Func<T, bool>> AndInclude<T>(
            this Expression<Func<T, bool>> left,
            Expression<Func<T, bool>> right)
        {
            var param = Expression.Parameter(typeof(T), "x");
            var body = Expression.AndAlso(
                    Expression.Invoke(left, param),
                    Expression.Invoke(right, param)
                );
            var lambda = Expression.Lambda<Func<T, bool>>(body, param);
            return lambda;
        }
    }
}