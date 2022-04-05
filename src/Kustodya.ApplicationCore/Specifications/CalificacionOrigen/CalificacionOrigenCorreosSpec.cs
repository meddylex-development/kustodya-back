using Kustodya.ApplicationCore.Entities.CalificacionOrigen;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Kustodya.ApplicationCore.Specifications.CalificacionOrigen
{
    public class CalificacionOrigenCorreosSpec : BaseSpec<Correo>
    {
        public CalificacionOrigenCorreosSpec(Expression<Func<Correo, bool>> criteria, int? skip, int? take) : base(criteria)
        {
            if (skip.HasValue && take.HasValue)
                ApplyPaging(skip.Value, take.Value);
        }
        public CalificacionOrigenCorreosSpec(Correo.EstadoCorreo estadoCorreo, string busqueda, DateTime fechaDesde, DateTime fechaHasta, int? skip, int? take)
                : this(u => u.Estado == estadoCorreo &&
                u.Fecha >= fechaDesde && u.Fecha <= fechaHasta && 
                ((busqueda != "" ? u.De.ToLower().Contains(busqueda) : true) ||
                (busqueda != "" ? u.Asunto.ToLower().Contains(busqueda) : true)), skip, take)
        {
            base.AddInclude(u => u.Adjuntos);
            ApplyOrderByDescending(c => c.Fecha);
        }
    }
}
