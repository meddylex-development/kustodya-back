using Kustodya.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Specifications.Usuarios
{
    public class UsuarioPorCorreoSpec : BaseSpec<TblUsuarios>
    {
        public UsuarioPorCorreoSpec(string correo)
                : base(u => (u.TEmail == correo))
        {
        }
    }
}
