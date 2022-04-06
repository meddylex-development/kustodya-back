using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.Administracion
{
    public class UsuarioEntidad
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int EntidadId { get; set; }
        public TblUsuarios Usuario { get; set; }
        public Entidad Entidad { get; set; }
        public List<UsuarioEntidadPerfil> usuarioEntidadPerfiles { get; set; }
    }
}
