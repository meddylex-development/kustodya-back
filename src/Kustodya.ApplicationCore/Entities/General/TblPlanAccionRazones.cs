using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblPlanAccionRazones
    {
        public TblPlanAccionRazones()
        {
            TblPlanAccionActividades = new HashSet<TblPlanAccionActividades>();
        }

        public long IIdplanAccionRazon { get; set; }
        public long IIdplanAccion { get; set; }
        public string TDescripcion { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblPlanAccion IIdplanAccionNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
        public virtual ICollection<TblPlanAccionActividades> TblPlanAccionActividades { get; set; }
    }
}
