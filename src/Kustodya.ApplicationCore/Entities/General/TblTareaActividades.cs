using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblTareaActividades
    {
        public long IIdtareaActividad { get; set; }
        public long IIdtarea { get; set; }
        public string TDescripcion { get; set; }
        public DateTime? DtFechaInicio { get; set; }
        public DateTime? DtFechaFin { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblTareas IIdtareaNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
    }
}
