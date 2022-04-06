using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblPlanAccionTareas
    {
        public long IIdplanAccionTarea { get; set; }
        public long IIdplanAccionActividad { get; set; }
        public long IIdtarea { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblPlanAccionActividades IIdplanAccionActividadNavigation { get; set; }
        public virtual TblTareas IIdtareaNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
    }
}
