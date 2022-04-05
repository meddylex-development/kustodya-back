using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblCargoPerfilObjetivos
    {
        public long IIdcargoPerfilObj { get; set; }
        public long IIdcargoPerfil { get; set; }
        public string TObjetivoCargo { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblCargoPerfil IIdcargoPerfilNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
    }
}
