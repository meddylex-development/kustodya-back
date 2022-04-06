using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblEmpresaProcesos
    {
        public TblEmpresaProcesos()
        {
            TblAsignacion = new HashSet<TblAsignacion>();
            TblEmpresaProcesoRiesgos = new HashSet<TblEmpresaProcesoRiesgos>();
            TblEntradasSalidas = new HashSet<TblEntradasSalidas>();
            TblIndicadoresMatriz = new HashSet<TblIndicadoresMatriz>();
            TblMapaProcesoPosiciones = new HashSet<TblMapaProcesoPosiciones>();
            TblNumeralesProceso = new HashSet<TblNumeralesProceso>();
            TblPhva = new HashSet<TblPhva>();
            TblPlanAccion = new HashSet<TblPlanAccion>();
            TblProcedimientos = new HashSet<TblProcedimientos>();
            TblRecursos = new HashSet<TblRecursos>();
            TblRiesgoIdentificacion = new HashSet<TblRiesgoIdentificacion>();
        }

        public long IIdempresaProceso { get; set; }
        public long IIdempresa { get; set; }
        public long IIdnivelProceso { get; set; }
        public long? IIdpadre { get; set; }
        public string TNombre { get; set; }
        public string TCodigo { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblEmpresas IIdempresaNavigation { get; set; }
        public virtual TblMultivalores IIdnivelProcesoNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
        public virtual ICollection<TblAsignacion> TblAsignacion { get; set; }
        public virtual ICollection<TblEmpresaProcesoRiesgos> TblEmpresaProcesoRiesgos { get; set; }
        public virtual ICollection<TblEntradasSalidas> TblEntradasSalidas { get; set; }
        public virtual ICollection<TblIndicadoresMatriz> TblIndicadoresMatriz { get; set; }
        public virtual ICollection<TblMapaProcesoPosiciones> TblMapaProcesoPosiciones { get; set; }
        public virtual ICollection<TblNumeralesProceso> TblNumeralesProceso { get; set; }
        public virtual ICollection<TblPhva> TblPhva { get; set; }
        public virtual ICollection<TblPlanAccion> TblPlanAccion { get; set; }
        public virtual ICollection<TblProcedimientos> TblProcedimientos { get; set; }
        public virtual ICollection<TblRecursos> TblRecursos { get; set; }
        public virtual ICollection<TblRiesgoIdentificacion> TblRiesgoIdentificacion { get; set; }
    }
}
