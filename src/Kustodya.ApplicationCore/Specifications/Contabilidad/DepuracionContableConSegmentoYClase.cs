using Kustodya.ApplicationCore.Entities.Contabilidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Kustodya.ApplicationCore.Specifications.Contabilidades
{
    public class DepuracionContableConSegmentoYClase : BaseSpec<DepuracionContable>
    {
        public DepuracionContableConSegmentoYClase(Expression<Func<DepuracionContable, bool>> criteria, int? skip, int? take) : base(criteria)
        {
            if (skip.HasValue && take.HasValue)
                ApplyPaging(skip.Value, take.Value);
        }
        public DepuracionContableConSegmentoYClase(Guid? segmento, string claseDoc, DateTime fechaDesde, DateTime fechaHasta, int? skip, int? take)
                : this(d => d.Eliminado == false && (segmento == null ? true : d.SegmentoId == segmento || d.ClaseDocumento.ToString() == claseDoc) &&
                d.FechaCreacion >= fechaDesde && d.FechaCreacion <= fechaHasta.AddDays(1), skip, take)
        {
            
        }
    }
}
