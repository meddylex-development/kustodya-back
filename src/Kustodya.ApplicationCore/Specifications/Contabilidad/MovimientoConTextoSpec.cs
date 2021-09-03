using Kustodya.ApplicationCore.Entities.Contabilidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Kustodya.ApplicationCore.Specifications.Contabilidades
{
    public class MovimientoConTextoSpec : BaseSpec<Movimiento>
    {
        public MovimientoConTextoSpec(Expression<Func<Movimiento, bool>> criteria, int? skip, int? take) : base(criteria)
        {
            if (skip.HasValue && take.HasValue)
                ApplyPaging(skip.Value, take.Value);
        }
        public MovimientoConTextoSpec(string busqueda, DateTime fechaDesde, DateTime fechaHasta, int? skip, int? take)
                : this(m => m.Eliminado == false && (m.DescripcionMovimiento.Contains(busqueda) 
                // || m.CentroBeneficio.Codigo == busqueda
                ) &&
                m.DepuracionContable.FechaCreacion >= fechaDesde && m.DepuracionContable.FechaCreacion <= fechaHasta.AddDays(1), skip, take)
        {
            AddInclude(c => c.DepuracionContable);
        }
    }
}
