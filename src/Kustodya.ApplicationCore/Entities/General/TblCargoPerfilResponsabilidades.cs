using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblCargoPerfilResponsabilidades
    {
        public long IIdcargoPerfilResponsabilidades { get; set; }
        public long IIdcargoPerfil { get; set; }
        public long IResponsabilidad { get; set; }
        public bool BResponsabilidad { get; set; }
        public string TAclaracion { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblCargoPerfil IIdcargoPerfilNavigation { get; set; }
        public virtual TblMultivalores IResponsabilidadNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
    }
}
