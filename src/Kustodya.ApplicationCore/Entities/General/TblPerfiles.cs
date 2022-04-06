using Kustodya.ApplicationCore.Entities.Administracion;
using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblPerfiles
    {
        public TblPerfiles()
        {
            TblDashBoard = new HashSet<TblDashBoard>();
            TblMenuPerfiles = new HashSet<TblMenuPerfiles>();
            TblUsuariosPerfiles = new HashSet<TblUsuariosPerfiles>();
        }

        public int IIdperfil { get; set; }
        public string TDescripcion { get; set; }
        public bool BActivo { get; set; }

        public virtual ICollection<TblDashBoard> TblDashBoard { get; set; }
        public virtual ICollection<TblMenuPerfiles> TblMenuPerfiles { get; set; }
        public virtual ICollection<TblUsuariosPerfiles> TblUsuariosPerfiles { get; set; }
        public ICollection<UsuarioEntidadPerfil> usuarioEntidadPerfiles { get; set; }
    }
}
