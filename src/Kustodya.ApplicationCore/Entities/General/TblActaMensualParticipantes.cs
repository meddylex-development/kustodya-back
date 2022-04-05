using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblActaMensualParticipantes
    {
        public long IIdactaMensualParti { get; set; }
        public long IIdactaMensual { get; set; }
        public long IIdempleado { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblActaMensual IIdactaMensualNavigation { get; set; }
        public virtual TblEmpleados IIdempleadoNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
    }
}
