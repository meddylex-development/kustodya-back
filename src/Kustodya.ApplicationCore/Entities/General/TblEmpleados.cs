using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblEmpleados
    {
        public TblEmpleados()
        {
            TblAccidentesTrabajo = new HashSet<TblAccidentesTrabajo>();
            TblActaMensualParticipantes = new HashSet<TblActaMensualParticipantes>();
            TblConceptoRehabilitacion = new HashSet<TblConceptoRehabilitacion>();
            TblEmpleadosDetalles = new HashSet<TblEmpleadosDetalles>();
            TblIndicadoresMatrizIIdempleadoAproboNavigation = new HashSet<TblIndicadoresMatriz>();
            TblIndicadoresMatrizIIdempleadoElaboroNavigation = new HashSet<TblIndicadoresMatriz>();
            TblIndicadoresMatrizIIdempleadoRevisoNavigation = new HashSet<TblIndicadoresMatriz>();
            TblPlanCapacitacion = new HashSet<TblPlanCapacitacion>();
            TblPlanCapacitacionAsistentes = new HashSet<TblPlanCapacitacionAsistentes>();
            TblProcesos = new HashSet<TblProcesos>();
        }

        public long IIdempleado { get; set; }
        public long IIdempresa { get; set; }
        public long IIdsucursal { get; set; }
        public long IIdcargo { get; set; }
        public string TPrimerApellido { get; set; }
        public string TSegundoApellido { get; set; }
        public string TPrimerNombre { get; set; }
        public string TSegundoNombre { get; set; }
        public long IIdlugarNacimiento { get; set; }
        public long IIdlugarDomicilio { get; set; }
        public string TDireccionDomicilio { get; set; }
        public DateTime DtFechaNacimiento { get; set; }
        public long IIdgenero { get; set; }
        public long IIdtipoDocumento { get; set; }
        public string TNumeroDocumento { get; set; }
        public long IIdlugarExpedicion { get; set; }
        public long IIdnacionalidad { get; set; }
        public long IIdestadoCivil { get; set; }
        public long IIdformacionEducativa { get; set; }
        public DateTime DtFechaIngreso { get; set; }
        public long IIdeps { get; set; }
        public DateTime DtFechaAfiliacionEps { get; set; }
        public long IIdafp { get; set; }
        public DateTime DtFechaAfiliacionAfp { get; set; }
        public long? IIdarl { get; set; }
        public DateTime? DtFechaAfiliacionArl { get; set; }
        public bool BInduccion { get; set; }
        public DateTime? DtFechaInduccion { get; set; }
        public bool BExamenMedico { get; set; }
        public DateTime? DtFechaExamenMedico { get; set; }
        public int IIdmonedaSalario { get; set; }
        public int IValorSalario { get; set; }
        public long IiDtipoVinculacion { get; set; }
        public bool BRepresentanteLegal { get; set; }
        public int IIdusuarioCreacion { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int? IIdusuarioModificacion { get; set; }
        public DateTime? DtFechaModificacion { get; set; }
        public bool BActivo { get; set; }
        public string TEmail { get; set; }
        public long EmployeeDetailsId { get; set; }

        public virtual TblArls IIdarlNavigation { get; set; }
        public virtual TblCargos IIdcargoNavigation { get; set; }
        public virtual TblEmpresas IIdempresaNavigation { get; set; }
        public virtual TblEps IIdepsNavigation { get; set; }
        public virtual TblMultivalores IIdestadoCivilNavigation { get; set; }
        public virtual TblMultivalores IIdformacionEducativaNavigation { get; set; }
        public virtual TblMultivalores IIdgeneroNavigation { get; set; }
        public virtual TblDivipola IIdlugarDomicilioNavigation { get; set; }
        public virtual TblDivipola IIdlugarExpedicionNavigation { get; set; }
        public virtual TblDivipola IIdlugarNacimientoNavigation { get; set; }
        public virtual TblSucursalesEmpresas IIdsucursalNavigation { get; set; }
        public virtual TblMultivalores IIdtipoDocumentoNavigation { get; set; }
        public virtual TblUsuarios IIdusuarioCreacionNavigation { get; set; }
        public virtual TblMultivalores IiDtipoVinculacionNavigation { get; set; }
        public virtual ICollection<TblAccidentesTrabajo> TblAccidentesTrabajo { get; set; }
        public virtual ICollection<TblActaMensualParticipantes> TblActaMensualParticipantes { get; set; }
        public virtual ICollection<TblConceptoRehabilitacion> TblConceptoRehabilitacion { get; set; }
        public virtual ICollection<TblEmpleadosDetalles> TblEmpleadosDetalles { get; set; }
        public virtual ICollection<TblIndicadoresMatriz> TblIndicadoresMatrizIIdempleadoAproboNavigation { get; set; }
        public virtual ICollection<TblIndicadoresMatriz> TblIndicadoresMatrizIIdempleadoElaboroNavigation { get; set; }
        public virtual ICollection<TblIndicadoresMatriz> TblIndicadoresMatrizIIdempleadoRevisoNavigation { get; set; }
        public virtual ICollection<TblPlanCapacitacion> TblPlanCapacitacion { get; set; }
        public virtual ICollection<TblPlanCapacitacionAsistentes> TblPlanCapacitacionAsistentes { get; set; }
        public virtual ICollection<TblProcesos> TblProcesos { get; set; }
    }
}
