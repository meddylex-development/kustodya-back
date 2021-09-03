using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.Administracion
{
    public class UsuarioEntidadPerfil
    {
        public int Id { get; set; }
        public int UsuarioEntidadId { get; set; }
        public int PerfilId { get; set; }
        public UsuarioEntidad UsuarioEntidad { get; set; }
        public TblPerfiles Perfil { get; set; }

    }
}
