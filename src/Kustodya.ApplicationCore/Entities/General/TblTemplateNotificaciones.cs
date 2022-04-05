using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblTemplateNotificaciones
    {
        public TblTemplateNotificaciones()
        {
            TblNotificacionesElectronicas = new HashSet<TblNotificacionesElectronicas>();
        }

        public byte IId { get; set; }
        public string TNombre { get; set; }
        public string TDescripcion { get; set; }
        public string TTemplate { get; set; }
        public DateTime? DtFechaCreacion { get; set; }

        public virtual ICollection<TblNotificacionesElectronicas> TblNotificacionesElectronicas { get; set; }
    }
}
