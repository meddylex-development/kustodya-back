using Kustodya.ApplicationCore.Entities.Administracion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Specifications.Administracion
{
    public class EntidadDetalleSpec : BaseSpec<Entidad>
    {
        public EntidadDetalleSpec(int entidadid)
                : base(u => (u.Id == entidadid))
        {
            base.AddInclude(u => u.Telefonos);
            base.AddInclude(u => u.Direcciones);
            base.AddInclude(u => u.RedesSociales);
            base.AddInclude(u => u.Correos);
            base.AddInclude(u => u.Clientes);
            base.AddInclude(u => u.Usuarios);
            base.AddInclude(u => u.Otros);
        }
    }
}
