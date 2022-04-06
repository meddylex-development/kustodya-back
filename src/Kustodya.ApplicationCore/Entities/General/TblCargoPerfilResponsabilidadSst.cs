using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblCargoPerfilResponsabilidadSst
    {
        public long IIdcargoPerfilResponSst { get; set; }
        public long IIdcargoPerfil { get; set; }
        public long IResponsabilidad { get; set; }
        public long IPeriodicidad { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblCargoPerfil IIdcargoPerfilNavigation { get; set; }
        public virtual TblMultivalores IPeriodicidadNavigation { get; set; }
        public virtual TblMultivalores IResponsabilidadNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
    }
}
