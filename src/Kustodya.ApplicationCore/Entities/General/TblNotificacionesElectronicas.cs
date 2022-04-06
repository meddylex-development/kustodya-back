using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblNotificacionesElectronicas
    {
        public short IId { get; set; }
        public string TIdentificador { get; set; }
        public string TDescripcion { get; set; }
        public short INumeroDias { get; set; }
        public byte? IIdtemplateNotificacion { get; set; }

        public virtual TblTemplateNotificaciones IIdtemplateNotificacionNavigation { get; set; }
    }
}
