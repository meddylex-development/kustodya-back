using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblDashBoard
    {
        public int IIdperfil { get; set; }
        public long IIdtipoTarea { get; set; }
        public int IIdusuarioCreacion { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblPerfiles IIdperfilNavigation { get; set; }
        public virtual TblMultivalores IIdtipoTareaNavigation { get; set; }
        public virtual TblUsuarios IIdusuarioCreacionNavigation { get; set; }
    }
}
