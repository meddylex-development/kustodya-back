using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblRiesgoResidualAcciones
    {
        public long IIdriesgoResidualAccion { get; set; }
        public long IIdriesgoResidual { get; set; }
        public string TAccion { get; set; }
        public long IIdresponsable { get; set; }
        public string TIndicadores { get; set; }
        public DateTime DtFechaInsercion { get; set; }
        public int IUsuarioInsercion { get; set; }
        public bool? BActivo { get; set; }

        public virtual TblRiesgoResidual IIdriesgoResidualNavigation { get; set; }
    }
}
