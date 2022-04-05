using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblAtmedidasSeguridad
    {
        public long IIdatmedidaSeguridad { get; set; }
        public long IIdaccidenteTrabajo { get; set; }
        public int IIdsubtablaTipoControl { get; set; }
        public string TValorTipoControl { get; set; }
        public string TMedidaSeguridad { get; set; }
        public int IUsuarioCreacion { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblAccidentesTrabajo IIdaccidenteTrabajoNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
    }
}
