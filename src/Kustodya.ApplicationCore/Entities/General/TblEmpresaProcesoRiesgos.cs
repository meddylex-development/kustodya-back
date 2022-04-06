using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblEmpresaProcesoRiesgos
    {
        public long IIdempresaProcesoRiesgo { get; set; }
        public long IIdempresaProceso { get; set; }
        public long IIdclasificacionRiesgo { get; set; }
        public int IUsuarioCreacion { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblClasificacionRiesgos IIdclasificacionRiesgoNavigation { get; set; }
        public virtual TblEmpresaProcesos IIdempresaProcesoNavigation { get; set; }
    }
}
