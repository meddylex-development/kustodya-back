using Kustodya.ApplicationCore.Entities.CalificacionOrigen;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Specifications.CalificacionOrigen
{
    class CalificacionCorreoDetalleporIdSpec : BaseSpec<Correo>
    {
        public CalificacionCorreoDetalleporIdSpec(int id)
                : base(u => u.Id == id)

        {
            base.AddInclude(u => u.Adjuntos);
        }
    }
}
