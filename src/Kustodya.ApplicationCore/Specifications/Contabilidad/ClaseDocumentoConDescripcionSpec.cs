using Kustodya.ApplicationCore.Entities.Contabilidades;
using System;
using Kustodya.ApplicationCore.Helpers;

namespace Kustodya.ApplicationCore.Specifications.Contabilidades
{
    public class ClaseDocumentoConDescripcionSpec : BaseSpec<ClaseDocumento>
    {
        public ClaseDocumentoConDescripcionSpec(string descripcion, Guid contabilidadId, int? skip = 0, int? take = 10)
            : base(c => c.Descripcion == descripcion && c.ContabilidadId == contabilidadId)
        {
            AddIncludes(i => i.Include(c => c.Contabilidad)
                .ThenInclude(c => c.DepuracionesContables));
        }
    }
}