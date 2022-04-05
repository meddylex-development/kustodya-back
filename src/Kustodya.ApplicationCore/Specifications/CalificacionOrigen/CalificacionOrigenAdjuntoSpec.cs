using Kustodya.ApplicationCore.Entities.CalificacionOrigen;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Specifications.CalificacionOrigen
{
    public class CalificacionOrigenAdjuntoSpec : BaseSpec<Adjunto>
    {
        public CalificacionOrigenAdjuntoSpec(string guid)
                : base(u => u.Contenido == guid)
        
        {
        
        }
    }
}
