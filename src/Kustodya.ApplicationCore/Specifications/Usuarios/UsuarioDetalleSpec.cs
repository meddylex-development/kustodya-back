using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Entities.Administracion;
using Kustodya.ApplicationCore.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Specifications.Usuarios
{
    public class UsuarioDetalleSpec : BaseSpec<TblUsuarios>
    {
        public UsuarioDetalleSpec(int id)
                : base(u => (u.IIdusuario == id))
        {
            base.AddInclude(u => u.Telefonos); 
            base.AddInclude(u => u.Correos); 
            base.AddInclude(u => u.RedesSociales);
            base.AddInclude(u => u.Direcciones);
            base.AddInclude(u => u.EPSs);
            base.AddInclude(u => u.Clientes);
            base.AddIncludes(i => i.Include(c => c.Entidades)
                .ThenInclude(c => c.usuarioEntidadPerfiles));
        }
        public UsuarioDetalleSpec(string correo)
                : base(u => (u.TEmail == correo))
        {
            base.AddInclude(u => u.Telefonos);
            base.AddInclude(u => u.Correos);
            base.AddInclude(u => u.RedesSociales);
            base.AddInclude(u => u.Direcciones);
            base.AddInclude(u => u.EPSs);
            base.AddInclude(u => u.Clientes);
            base.AddInclude(u => u.Entidades);
        }
    }
}
