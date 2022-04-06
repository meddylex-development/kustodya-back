using System;
using Kustodya.ApplicationCore.Constants;
using Kustodya.Medicos.Data;
using Kustodya.Medicos.Data.Medicos;
using Roojo.CalificacionOrigen;

namespace Kustodya.Medicos.Specifications
{
    public class CorreosRecientesSpec : BaseSpec<Correo>
    {
        public CorreosRecientesSpec(int dias)
                : base(e => e.Fecha >= DateTime.Now.AddDays(-dias))
        {
            
        }
    }
}
