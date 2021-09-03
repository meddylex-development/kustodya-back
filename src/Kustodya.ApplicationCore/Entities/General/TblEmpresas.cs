using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblEmpresas
    {
        public TblEmpresas()
        {
            TblAccidentesTrabajo = new HashSet<TblAccidentesTrabajo>();
            TblActaMensual = new HashSet<TblActaMensual>();
            TblActaMensualCompromisos = new HashSet<TblActaMensualCompromisos>();
            TblActas = new HashSet<TblActas>();
            TblAsignacion = new HashSet<TblAsignacion>();
            TblAusentismoHorasHombreTrabajadas = new HashSet<TblAusentismoHorasHombreTrabajadas>();
            TblAusentismoIndicadoresInfraestructura = new HashSet<TblAusentismoIndicadoresInfraestructura>();
            TblAusentismoIndicadoresProceso = new HashSet<TblAusentismoIndicadoresProceso>();
            TblAusentismoIndiceAccidentalidad = new HashSet<TblAusentismoIndiceAccidentalidad>();
            TblAusentismoIndiceEnfermedadProfesional = new HashSet<TblAusentismoIndiceEnfermedadProfesional>();
            TblAusentismoPrevalenciaIncidencia = new HashSet<TblAusentismoPrevalenciaIncidencia>();
            TblCargoPerfil = new HashSet<TblCargoPerfil>();
            TblCargos = new HashSet<TblCargos>();
            TblDiagnosticoCondicionTrabajo = new HashSet<TblDiagnosticoCondicionTrabajo>();
            TblDiagnosticoInicial = new HashSet<TblDiagnosticoInicial>();
            TblEmpleados = new HashSet<TblEmpleados>();
            TblEmpresaArea = new HashSet<TblEmpresaArea>();
            TblEmpresaControlEficacia = new HashSet<TblEmpresaControlEficacia>();
            TblEmpresaControlFrecuencia = new HashSet<TblEmpresaControlFrecuencia>();
            TblEmpresaControlHerramientas = new HashSet<TblEmpresaControlHerramientas>();
            TblEmpresaControlProcedimientos = new HashSet<TblEmpresaControlProcedimientos>();
            TblEmpresaControlResponsable = new HashSet<TblEmpresaControlResponsable>();
            TblEmpresaEstandarDocGenSis = new HashSet<TblEmpresaEstandarDocGenSis>();
            TblEmpresaEstandares = new HashSet<TblEmpresaEstandares>();
            TblEmpresaEstructuraProcesos = new HashSet<TblEmpresaEstructuraProcesos>();
            TblEmpresaJurisprudencias = new HashSet<TblEmpresaJurisprudencias>();
            TblEmpresaParametros = new HashSet<TblEmpresaParametros>();
            TblEmpresaPolitica = new HashSet<TblEmpresaPolitica>();
            TblEmpresaProcesos = new HashSet<TblEmpresaProcesos>();
            TblEmpresaRiesgoValoracion = new HashSet<TblEmpresaRiesgoValoracion>();
            TblEmpresasArls = new HashSet<TblEmpresasArls>();
            TblEmpresasCajasCompensacion = new HashSet<TblEmpresasCajasCompensacion>();
            TblEmpresasCorredores = new HashSet<TblEmpresasCorredores>();
            TblEmpresasVigencia = new HashSet<TblEmpresasVigencia>();
            TblEntradasSalidas = new HashSet<TblEntradasSalidas>();
            TblEstandarTipoPoliticas = new HashSet<TblEstandarTipoPoliticas>();
            TblIndicadoresMatriz = new HashSet<TblIndicadoresMatriz>();
            TblInspecciones = new HashSet<TblInspecciones>();
            TblInspeccionesPrograma = new HashSet<TblInspeccionesPrograma>();
            TblMapaProcesoPosiciones = new HashSet<TblMapaProcesoPosiciones>();
            TblNumeralesProceso = new HashSet<TblNumeralesProceso>();
            TblPacientes = new HashSet<TblPacientes>();
            TblPerfilSocioDemografico = new HashSet<TblPerfilSocioDemografico>();
            TblPhva = new HashSet<TblPhva>();
            TblPlanAccion = new HashSet<TblPlanAccion>();
            TblPlanCapacitacion = new HashSet<TblPlanCapacitacion>();
            TblProcedimientos = new HashSet<TblProcedimientos>();
            TblProcesos = new HashSet<TblProcesos>();
            TblRecobroEstados = new HashSet<TblRecobroEstados>();
            TblRecobros = new HashSet<TblRecobros>();
            TblRecursos = new HashSet<TblRecursos>();
            TblRhsi = new HashSet<TblRhsi>();
            TblRhsiactividadEconomica = new HashSet<TblRhsiactividadEconomica>();
            TblRhsiriesgos = new HashSet<TblRhsiriesgos>();
            TblRiesgoIdentificacion = new HashSet<TblRiesgoIdentificacion>();
            TblSoa = new HashSet<TblSoa>();
            TblSoportes = new HashSet<TblSoportes>();
            TblSucursalesEmpresas = new HashSet<TblSucursalesEmpresas>();
            TblTareas = new HashSet<TblTareas>();
            TblTipoProceso = new HashSet<TblTipoProceso>();
            TblUsuariosEmpresas = new HashSet<TblUsuariosEmpresas>();
        }

        public long IIdempresa { get; set; }
        public long IIdtipoIdentificacion { get; set; }
        public string TNumeroIdentificacion { get; set; }
        public int TDigitoVerificacion { get; set; }
        public string TRazonSocial { get; set; }
        public string TNombreComercial { get; set; }
        public long IIdubicacion { get; set; }
        public string TDireccion { get; set; }
        public string TTelefonoPrincipal { get; set; }
        public string TTelefonoSecundario { get; set; }
        public string TFax { get; set; }
        public short? IIdactividadEconomica1 { get; set; }
        public short? IIdactividadEconomica2 { get; set; }
        public short? IIdactividadEconomica3 { get; set; }
        public long? IIdarl { get; set; }
        public DateTime? DtFechaInicialArl { get; set; }
        public long? IIdcajaCompensacion { get; set; }
        public DateTime? DtFechaInicialCaja { get; set; }
        public int? IIdcorredor { get; set; }
        public DateTime? DtFechaInicialCorredor { get; set; }
        public int IIdusuarioCreacion { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int? IIdusuarioModificacion { get; set; }
        public DateTime? DtFechaModificacion { get; set; }
        public bool BActivo { get; set; }
        public long IIdempresaGestora { get; set; }
        public long IIdvendedor { get; set; }

        public virtual TblMultivalores IIdtipoIdentificacionNavigation { get; set; }
        public virtual ICollection<TblAccidentesTrabajo> TblAccidentesTrabajo { get; set; }
        public virtual ICollection<TblActaMensual> TblActaMensual { get; set; }
        public virtual ICollection<TblActaMensualCompromisos> TblActaMensualCompromisos { get; set; }
        public virtual ICollection<TblActas> TblActas { get; set; }
        public virtual ICollection<TblAsignacion> TblAsignacion { get; set; }
        public virtual ICollection<TblAusentismoHorasHombreTrabajadas> TblAusentismoHorasHombreTrabajadas { get; set; }
        public virtual ICollection<TblAusentismoIndicadoresInfraestructura> TblAusentismoIndicadoresInfraestructura { get; set; }
        public virtual ICollection<TblAusentismoIndicadoresProceso> TblAusentismoIndicadoresProceso { get; set; }
        public virtual ICollection<TblAusentismoIndiceAccidentalidad> TblAusentismoIndiceAccidentalidad { get; set; }
        public virtual ICollection<TblAusentismoIndiceEnfermedadProfesional> TblAusentismoIndiceEnfermedadProfesional { get; set; }
        public virtual ICollection<TblAusentismoPrevalenciaIncidencia> TblAusentismoPrevalenciaIncidencia { get; set; }
        public virtual ICollection<TblCargoPerfil> TblCargoPerfil { get; set; }
        public virtual ICollection<TblCargos> TblCargos { get; set; }
        public virtual ICollection<TblDiagnosticoCondicionTrabajo> TblDiagnosticoCondicionTrabajo { get; set; }
        public virtual ICollection<TblDiagnosticoInicial> TblDiagnosticoInicial { get; set; }
        public virtual ICollection<TblEmpleados> TblEmpleados { get; set; }
        public virtual ICollection<TblEmpresaArea> TblEmpresaArea { get; set; }
        public virtual ICollection<TblEmpresaControlEficacia> TblEmpresaControlEficacia { get; set; }
        public virtual ICollection<TblEmpresaControlFrecuencia> TblEmpresaControlFrecuencia { get; set; }
        public virtual ICollection<TblEmpresaControlHerramientas> TblEmpresaControlHerramientas { get; set; }
        public virtual ICollection<TblEmpresaControlProcedimientos> TblEmpresaControlProcedimientos { get; set; }
        public virtual ICollection<TblEmpresaControlResponsable> TblEmpresaControlResponsable { get; set; }
        public virtual ICollection<TblEmpresaEstandarDocGenSis> TblEmpresaEstandarDocGenSis { get; set; }
        public virtual ICollection<TblEmpresaEstandares> TblEmpresaEstandares { get; set; }
        public virtual ICollection<TblEmpresaEstructuraProcesos> TblEmpresaEstructuraProcesos { get; set; }
        public virtual ICollection<TblEmpresaJurisprudencias> TblEmpresaJurisprudencias { get; set; }
        public virtual ICollection<TblEmpresaParametros> TblEmpresaParametros { get; set; }
        public virtual ICollection<TblEmpresaPolitica> TblEmpresaPolitica { get; set; }
        public virtual ICollection<TblEmpresaProcesos> TblEmpresaProcesos { get; set; }
        public virtual ICollection<TblEmpresaRiesgoValoracion> TblEmpresaRiesgoValoracion { get; set; }
        public virtual ICollection<TblEmpresasArls> TblEmpresasArls { get; set; }
        public virtual ICollection<TblEmpresasCajasCompensacion> TblEmpresasCajasCompensacion { get; set; }
        public virtual ICollection<TblEmpresasCorredores> TblEmpresasCorredores { get; set; }
        public virtual ICollection<TblEmpresasVigencia> TblEmpresasVigencia { get; set; }
        public virtual ICollection<TblEntradasSalidas> TblEntradasSalidas { get; set; }
        public virtual ICollection<TblEstandarTipoPoliticas> TblEstandarTipoPoliticas { get; set; }
        public virtual ICollection<TblIndicadoresMatriz> TblIndicadoresMatriz { get; set; }
        public virtual ICollection<TblInspecciones> TblInspecciones { get; set; }
        public virtual ICollection<TblInspeccionesPrograma> TblInspeccionesPrograma { get; set; }
        public virtual ICollection<TblMapaProcesoPosiciones> TblMapaProcesoPosiciones { get; set; }
        public virtual ICollection<TblNumeralesProceso> TblNumeralesProceso { get; set; }
        public virtual ICollection<TblPacientes> TblPacientes { get; set; }
        public virtual ICollection<TblPerfilSocioDemografico> TblPerfilSocioDemografico { get; set; }
        public virtual ICollection<TblPhva> TblPhva { get; set; }
        public virtual ICollection<TblPlanAccion> TblPlanAccion { get; set; }
        public virtual ICollection<TblPlanCapacitacion> TblPlanCapacitacion { get; set; }
        public virtual ICollection<TblProcedimientos> TblProcedimientos { get; set; }
        public virtual ICollection<TblProcesos> TblProcesos { get; set; }
        public virtual ICollection<TblRecobroEstados> TblRecobroEstados { get; set; }
        public virtual ICollection<TblRecobros> TblRecobros { get; set; }
        public virtual ICollection<TblRecursos> TblRecursos { get; set; }
        public virtual ICollection<TblRhsi> TblRhsi { get; set; }
        public virtual ICollection<TblRhsiactividadEconomica> TblRhsiactividadEconomica { get; set; }
        public virtual ICollection<TblRhsiriesgos> TblRhsiriesgos { get; set; }
        public virtual ICollection<TblRiesgoIdentificacion> TblRiesgoIdentificacion { get; set; }
        public virtual ICollection<TblSoa> TblSoa { get; set; }
        public virtual ICollection<TblSoportes> TblSoportes { get; set; }
        public virtual ICollection<TblSucursalesEmpresas> TblSucursalesEmpresas { get; set; }
        public virtual ICollection<TblTareas> TblTareas { get; set; }
        public virtual ICollection<TblTipoProceso> TblTipoProceso { get; set; }
        public virtual ICollection<TblUsuariosEmpresas> TblUsuariosEmpresas { get; set; }
    }
}
