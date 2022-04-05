using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblTareas
    {
        public TblTareas()
        {
            TblInspecciones = new HashSet<TblInspecciones>();
            TblInspeccionesPrograma = new HashSet<TblInspeccionesPrograma>();
            TblPlanAccionTareas = new HashSet<TblPlanAccionTareas>();
            TblPlanCapacitacion = new HashSet<TblPlanCapacitacion>();
            TblTareaActividades = new HashSet<TblTareaActividades>();
        }

        public long IIdtarea { get; set; }
        public long IIdempresa { get; set; }
        public long IIdtipoTarea { get; set; }
        public int IIdusuarioTarea { get; set; }
        public string TDescripcion { get; set; }
        public long IIdestadoTarea { get; set; }
        public DateTime DtFechaInicio { get; set; }
        public DateTime? DtFechaFin { get; set; }
        public DateTime DtFechaVencimiento { get; set; }
        public int IIdusuarioInsecion { get; set; }
        public DateTime DtFechaInsercion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblEmpresas IIdempresaNavigation { get; set; }
        public virtual TblMultivalores IIdestadoTareaNavigation { get; set; }
        public virtual TblMultivalores IIdtipoTareaNavigation { get; set; }
        public virtual TblUsuarios IIdusuarioInsecionNavigation { get; set; }
        public virtual TblUsuarios IIdusuarioTareaNavigation { get; set; }
        public virtual ICollection<TblInspecciones> TblInspecciones { get; set; }
        public virtual ICollection<TblInspeccionesPrograma> TblInspeccionesPrograma { get; set; }
        public virtual ICollection<TblPlanAccionTareas> TblPlanAccionTareas { get; set; }
        public virtual ICollection<TblPlanCapacitacion> TblPlanCapacitacion { get; set; }
        public virtual ICollection<TblTareaActividades> TblTareaActividades { get; set; }
    }
}
