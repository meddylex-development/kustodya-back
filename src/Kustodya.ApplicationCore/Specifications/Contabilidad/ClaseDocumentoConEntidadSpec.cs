using System;
using Kustodya.ApplicationCore.Entities.Contabilidades;

namespace Kustodya.ApplicationCore.Specifications.Contabilidades
{
    public class ClaseDocumentoConEntidadSpec : BaseSpec<ClaseDocumento>
    {
        public ClaseDocumentoConEntidadSpec(int entidadId, string busqueda = null)
            : base(c => 
                c.Contabilidad.EntidadId == entidadId && 
                (string.IsNullOrWhiteSpace(busqueda) || c.Descripcion.ToLower().Contains(busqueda.ToLower())) && 
                c.Eliminado == false
                )
        {
            AddInclude(c => c.Contabilidad);
        }

        public ClaseDocumentoConEntidadSpec(int entidadId, string busqueda, int pagina = 1)
            : this(entidadId, busqueda)
        {
            var skip = Math.Max(pagina - 1, 0) * 10;
            var take = 10;

            ApplyPaging(skip, take);
            AddInclude(c => c.Contabilidad);
        }
    }
}
