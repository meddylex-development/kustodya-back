using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblPlanCapacitacion
    {
        public long IIdplanCapacitacion { get; set; }
        public long IIdempresa { get; set; }
        public string TTematica { get; set; }
        public string TObjetivos { get; set; }
        public long IIdresponsable { get; set; }
        public DateTime DtFechaInicial { get; set; }
        public DateTime DtFechaFinal { get; set; }
        public long IIdtipoCapacitacion { get; set; }
        public int IIdsubtablaTipoCapacitador { get; set; }
        public string TIdvalorTipoCapacitador { get; set; }
        public long IIdcapacitador { get; set; }
        public string TRecursos { get; set; }
        public DateTime DtFechaEvaluacion { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }
        public long IIdtarea { get; set; }

        public virtual TblEmpresas IIdempresaNavigation { get; set; }
        public virtual TblEmpleados IIdresponsableNavigation { get; set; }
        public virtual TblTareas IIdtareaNavigation { get; set; }
        public virtual TblMultivalores IIdtipoCapacitacionNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
    }
}
