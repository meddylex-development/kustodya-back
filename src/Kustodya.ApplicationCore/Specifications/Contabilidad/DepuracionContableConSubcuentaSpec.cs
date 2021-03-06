using Kustodya.ApplicationCore.Entities.Contabilidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Kustodya.ApplicationCore.Specifications.Contabilidades
{
    public class DepuracionContableConSubcuentaSpec : BaseSpec<DepuracionContable>
    {
        public DepuracionContableConSubcuentaSpec(Expression<Func<DepuracionContable, bool>> criteria, int? skip, int? take) : base(criteria)
        {
            if (skip.HasValue && take.HasValue)
                ApplyPaging(skip.Value, take.Value);
        }
        public DepuracionContableConSubcuentaSpec(int  busqueda, DateTime fechaDesde, DateTime fechaHasta, int? skip, int? take)
                : this(d => d.Eliminado == false && d.Subcuenta == busqueda && d.FechaCreacion >= fechaDesde && d.FechaCreacion <= fechaHasta.AddDays(1), skip, take)
        {
            
        }
    }
}
