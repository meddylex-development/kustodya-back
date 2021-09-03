using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblPlanCapacitacionSesiones
    {
        public long IIdplanCapacitacionSesion { get; set; }
        public long IIdplanCapacitacion { get; set; }
        public string TNombre { get; set; }
        public DateTime DtFechaInicial { get; set; }
        public DateTime DtFechaFinal { get; set; }
        public TimeSpan IHoraInicial { get; set; }
        public TimeSpan IHoraFinal { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
    }
}
