using Kustodya.ApplicationCore.Entities.Contabilidades;
using System;

namespace Kustodya.ApplicationCore.Specifications.Contabilidades
{
    public class TipoAjusteConDescripcionSpec : BaseSpec<TipoAjuste>
    {
        public TipoAjusteConDescripcionSpec(string descripcion, Guid contabilidadId, int? skip = 0, int? take = 10)
          : base(c => c.Descripcion == descripcion && c.ContabilidadId == contabilidadId)
        {
        }
    }
}