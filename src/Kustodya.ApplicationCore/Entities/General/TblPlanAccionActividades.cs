using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblPlanAccionActividades
    {
        public TblPlanAccionActividades()
        {
            TblPlanAccionTareas = new HashSet<TblPlanAccionTareas>();
        }

        public long IIdplanAccionActividad { get; set; }
        public long IIdplanAccionRazon { get; set; }
        public string TDescripcion { get; set; }
        public int IIdresponsable { get; set; }
        public DateTime DtFechaCompromiso { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblPlanAccionRazones IIdplanAccionRazonNavigation { get; set; }
        public virtual TblUsuarios IIdresponsableNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
        public virtual ICollection<TblPlanAccionTareas> TblPlanAccionTareas { get; set; }
    }
}
