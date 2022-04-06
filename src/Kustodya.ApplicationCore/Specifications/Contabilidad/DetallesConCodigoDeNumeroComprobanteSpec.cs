using Kustodya.ApplicationCore.Entities.Contabilidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Kustodya.ApplicationCore.Specifications.Contabilidades
{
    public class DetallesConCodigoDeNumeroComprobanteSpec : BaseSpec<Movimiento>
    {
        public DetallesConCodigoDeNumeroComprobanteSpec(Expression<Func<Movimiento, bool>> criteria, int? skip, int? take) : base(criteria)
        {
            if (skip.HasValue && take.HasValue)
                ApplyPaging(skip.Value, take.Value);
        }
        public DetallesConCodigoDeNumeroComprobanteSpec(int busqueda, DateTime fechaDesde, DateTime fechaHasta, int? skip, int? take)
                : this(d => d.Eliminado == false && (d.CodigoContable == busqueda || d.NumComprobanteCierre == busqueda) && 
                d.DepuracionContable.FechaCreacion >= fechaDesde && d.DepuracionContable.FechaCreacion <= fechaHasta.AddDays(1), skip, take)
        {
            AddInclude(c => c.DepuracionContable);
        }
    }
}
