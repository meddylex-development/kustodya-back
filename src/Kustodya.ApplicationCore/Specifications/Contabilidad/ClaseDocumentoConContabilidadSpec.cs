using System;
using Kustodya.ApplicationCore.Entities.Contabilidades;

namespace Kustodya.ApplicationCore.Specifications.Contabilidades
{
    // ClaseDocumentoConEntidadSpec
    public class ClaseDocumentoConContabilidadSpec : BaseSpec<ClaseDocumento>
    {
        public ClaseDocumentoConContabilidadSpec(Guid contabilidadId, string busqueda = null)
            : base(c => 
                c.ContabilidadId == contabilidadId && 
                (string.IsNullOrWhiteSpace(busqueda) || c.Descripcion.ToLower().Contains(busqueda.ToLower())) && 
                c.Eliminado == false
                )
        {
        }

        public ClaseDocumentoConContabilidadSpec(Guid contabilidadId, string busqueda, int pagina = 1)
            : this(contabilidadId, busqueda)
        {
            var skip = Math.Max(pagina - 1, 0) * 10;
            var take = 10;

            ApplyPaging(skip, take);
            AddInclude(c => c.Contabilidad);
        }
    }
}
