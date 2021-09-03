using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblNotificacionesUsuarios
    {
        public short IId { get; set; }
        public short IIdusuarioNotificacion { get; set; }
        public byte IIdTipoNotificacion { get; set; }
        public short IIdNotificacionElectronica { get; set; }
        public DateTime? DtFechaCreacion { get; set; }
    }
}
