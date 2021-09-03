using Kustodya.ApplicationCore.Entities.Contabilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Kustodya.ApplicationCore.Helpers;

namespace Kustodya.ApplicationCore.Specifications.Contabilidades
{
    public class DepuracionContableConIdSpec : BaseSpec<DepuracionContable>
    {
        public DepuracionContableConIdSpec(Guid Id, int entidadId)
                : base(d => d.Eliminado == false && (d.Id == Id) && d.Contabilidad.EntidadId == entidadId)
        {
            base.AddInclude(u => u.Movimientos);
            base.AddInclude(u => u.ClaseDocumento);
            base.AddInclude(u => u.Segmento);
            base.AddIncludes(i => i.Include(c => c.DepuracionesFolios)
            .ThenInclude(c => c.Select(c=>c.Folio)));
            base.AddIncludes(i => i.Include(c => c.Contabilidad)
            .ThenInclude(c => c.PucCreditoPorDefecto));
        }
    }
}
