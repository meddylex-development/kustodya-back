using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class UsuarioEPS
    {
        public int Id { get; set; }
        public long TblEpsId { get; set; }
        public int TblUsuariosId { get; set; }
        public bool Activo { get; set; }
        public TblEps Eps { get; set; }
        public TblUsuarios Usuario { get; set; }
        public long TblIpsId { get; set; }
    }
}
