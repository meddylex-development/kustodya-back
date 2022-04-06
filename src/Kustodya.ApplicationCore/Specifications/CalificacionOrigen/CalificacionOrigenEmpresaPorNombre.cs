using Kustodya.ApplicationCore.Entities.CalificacionOrigen;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Specifications.CalificacionOrigen
{
    class CalificacionOrigenEmpresaPorNombre : BaseSpec<Empresa>
    {
        public CalificacionOrigenEmpresaPorNombre(string nombreEmpresa)
                : base(u => u.Nombre == nombreEmpresa)

        {
        }
    }
}
