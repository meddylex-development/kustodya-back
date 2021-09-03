using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblActaMensualCompromisoActividades
    {
        public long IIdactaMensualCompromisoActividad { get; set; }
        public long IIdactaMensualCompromiso { get; set; }
        public string TDescripcion { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblActaMensualCompromisos IIdactaMensualCompromisoNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
    }
}
