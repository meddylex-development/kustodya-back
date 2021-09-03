using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblMenuPerfiles
    {
        public int IIdperfil { get; set; }
        public int IIdmenu { get; set; }
        public bool BActivo { get; set; }

        public virtual TblMenu IIdmenuNavigation { get; set; }
        public virtual TblPerfiles IIdperfilNavigation { get; set; }
    }
}
