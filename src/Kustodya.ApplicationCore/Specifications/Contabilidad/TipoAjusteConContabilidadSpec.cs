using Kustodya.ApplicationCore.Entities.Contabilidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Specifications.Contabilidades
{
    public class TipoAjusteConContabilidadSpec : BaseSpec<TipoAjuste>
    {
        public TipoAjusteConContabilidadSpec(Guid contabilidadId, string busqueda = null)
            : base(c =>
                c.ContabilidadId == contabilidadId &&
                (string.IsNullOrWhiteSpace(busqueda) || c.Descripcion.ToLower().Contains(busqueda.ToLower())) &&
                c.Eliminado == false
                )
        {
        }

        public TipoAjusteConContabilidadSpec(Guid contabilidadId, string busqueda, int pagina = 1)
            : this(contabilidadId, busqueda)
        {
            var skip = Math.Max(pagina - 1, 0) * 10;
            var take = 10;

            ApplyPaging(skip, take);
            AddInclude(c => c.Contabilidad);
        }
    }
}
