using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblAtequiposProteccion
    {
        public long IIdatequipoProteccion { get; set; }
        public long IIdacidenteTrabajo { get; set; }
        public long IIdequipoProteccion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblAccidentesTrabajo IIdacidenteTrabajoNavigation { get; set; }
        public virtual TblMultivalores IIdequipoProteccionNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
    }
}
