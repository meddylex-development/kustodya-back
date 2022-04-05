using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblEventosCalendario
    {
        public TblEventosCalendario()
        {
            TblEventosCalendarioParticipantes = new HashSet<TblEventosCalendarioParticipantes>();
        }

        public int IIdeventoCalendario { get; set; }
        public int? IIdentidad { get; set; }
        public int? IIdsubTablaTipoCalendario { get; set; }
        public string TIdvalorTipoCalendario { get; set; }
        public int? IIdusuarioAsignado { get; set; }
        public string TAsunto { get; set; }
        public string TDescripcion { get; set; }
        public string TLugar { get; set; }
        public DateTime? DtFechaInicio { get; set; }
        public DateTime? DtFechaFin { get; set; }
        public DateTime? DtFechaCreacion { get; set; }
        public int? IIdusuarioCreacion { get; set; }
        public DateTime? DtFechaModificacion { get; set; }
        public int? IIdusuarioModificacion { get; set; }
        public bool? BActivo { get; set; }

        public virtual ICollection<TblEventosCalendarioParticipantes> TblEventosCalendarioParticipantes { get; set; }
    }
}
