using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblCargoPerfilNivelAutoridad
    {
        public long IIdcargoPerfilNivelAutoridad { get; set; }
        public long IIdcargoPerfil { get; set; }
        public long INivelAutoridad { get; set; }
        public long IRendicionCuentas { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblCargoPerfil IIdcargoPerfilNavigation { get; set; }
        public virtual TblMultivalores INivelAutoridadNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
    }
}
