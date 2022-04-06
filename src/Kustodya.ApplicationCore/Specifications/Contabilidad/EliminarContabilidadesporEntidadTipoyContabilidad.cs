using Kustodya.ApplicationCore.Entities.Contabilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kustodya.ApplicationCore.Specifications.Contabilidades
{
    public class EliminarContabilidadesporEntidadTipoyContabilidad : BaseSpec<Puc>
    {
        public EliminarContabilidadesporEntidadTipoyContabilidad(int entidadId, string[] tipoyContabilidad)
            /*: base(c => tipoyContabilidad.Contains(c.TipoContabilidad.ToString() + c.ContabilidadId.ToString()) && 
            c.Contabilidad.EntidadId == entidadId)*/
            : base(c => c.Contabilidad.EntidadId == 2)
        {
            AddInclude(c => c.Contabilidad);
        }
    }
}
