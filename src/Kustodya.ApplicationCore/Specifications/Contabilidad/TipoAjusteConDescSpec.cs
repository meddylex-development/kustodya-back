using Kustodya.ApplicationCore.Entities.Contabilidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Specifications.Contabilidades
{
    class TipoAjusteConDescSpec : BaseSpec<TipoAjuste>
    {
        public TipoAjusteConDescSpec(string descripcion, int entidadId, int? skip = 0, int? take = 10)
            : base(p => p.Eliminado == false && p.Descripcion == descripcion && p.Contabilidad.EntidadId == entidadId)
        {
            AddInclude(p => p.Contabilidad);
        }
    }
}