using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblCie10DiagnosticoIncapacidad
    {
        public long IIdcie10DiagnosticoIncapacidad { get; set; }
        public long IIddiagnosticoIncapacidad { get; set; }
        public int IIdcie10 { get; set; }

        public virtual TblCie10 IIdcie10Navigation { get; set; }
        public virtual TblDiagnosticosIncapacidades IIddiagnosticoIncapacidadNavigation { get; set; }
    }
}
