using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblEventosCalendarioParticipantes
    {
        public int IIdeventoCalendarioParticipante { get; set; }
        public int? IIdeventoCalendario { get; set; }
        public string TCorreoElectronico { get; set; }
        public DateTime? DtFechaCreacion { get; set; }
        public int? IIdusuarioCreacion { get; set; }
        public DateTime? DtFechaModificacion { get; set; }
        public int? IIdusuarioModificacion { get; set; }
        public bool? BActivo { get; set; }

        public virtual TblEventosCalendario IIdeventoCalendarioNavigation { get; set; }
    }
}
