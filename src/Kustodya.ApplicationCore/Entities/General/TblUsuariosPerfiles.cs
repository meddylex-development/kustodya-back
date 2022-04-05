using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblUsuariosPerfiles
    {
        public int IIdusuario { get; set; }
        public int IIdperfil { get; set; }
        public bool BActivo { get; set; }

        public virtual TblPerfiles IIdperfilNavigation { get; set; }
        public virtual TblUsuarios IIdusuarioNavigation { get; set; }
    }
}
