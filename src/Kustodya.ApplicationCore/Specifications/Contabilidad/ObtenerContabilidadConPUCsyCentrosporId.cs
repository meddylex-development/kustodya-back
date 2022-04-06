using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Specifications.Contabilidades
{
    public class ObtenerContabilidadConPUCsyCentrosporId : BaseSpec<Entities.Contabilidades.Contabilidad>
    {
        public ObtenerContabilidadConPUCsyCentrosporId(Guid Id)
            : base(c => c.Id == Id)
        {
            AddInclude(c => c.Pucs);
            AddInclude(c => c.Centros);
        }
    }
}
