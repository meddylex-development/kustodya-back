using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblAtinformacionSuceso
    {
        public long IIdinformacionSuceso { get; set; }
        public long IIdaccidenteTrabajo { get; set; }
        public int IIdsubtablaTipoDano { get; set; }
        public string TValorTipoDano { get; set; }
        public string TDescripcion { get; set; }
        public int ICosto { get; set; }
        public string TEntidadNotificada { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblAccidentesTrabajo IIdaccidenteTrabajoNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
    }
}
