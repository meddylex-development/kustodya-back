using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblUsuariosEmpresas
    {
        public long IIdempresa { get; set; }
        public int IIdusuario { get; set; }
        public bool BActivo { get; set; }

        public virtual TblEmpresas IIdempresaNavigation { get; set; }
        public virtual TblUsuarios IIdusuarioNavigation { get; set; }
    }
}
