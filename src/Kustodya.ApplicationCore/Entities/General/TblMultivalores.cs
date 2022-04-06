using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblMultivalores
    {
        public TblMultivalores()
        {
            TblAccidentesTrabajoIIdactividadEconomicaNavigation = new HashSet<TblAccidentesTrabajo>();
            TblAccidentesTrabajoIIdtipoEventoNavigation = new HashSet<TblAccidentesTrabajo>();
            TblAccidentesTrabajoIIdtipoIdentificacionNavigation = new HashSet<TblAccidentesTrabajo>();
            TblAccidentesTrabajoIIdtipoVinculaciontrabNavigation = new HashSet<TblAccidentesTrabajo>();
            TblAccidentesTrabajoIIdtipoVinculadorNavigation = new HashSet<TblAccidentesTrabajo>();
            TblAccidentesTrabajoIJornadaNavigation = new HashSet<TblAccidentesTrabajo>();
            TblActaMensualCompromisos = new HashSet<TblActaMensualCompromisos>();
            TblActaMensualIIdclaseActaNavigation = new HashSet<TblActaMensual>();
            TblActaMensualITipoReunionNavigation = new HashSet<TblActaMensual>();
            TblActasIIdclaseActaNavigation = new HashSet<TblActas>();
            TblActasIIdtipoActaNavigation = new HashSet<TblActas>();
            TblAfp = new HashSet<TblAfp>();
            TblArls = new HashSet<TblArls>();
            TblAtequiposProteccion = new HashSet<TblAtequiposProteccion>();
            TblCajasCompensacion = new HashSet<TblCajasCompensacion>();
            TblCargoPerfilCompetenciasCorporativasICompetenciaCorporativaNavigation = new HashSet<TblCargoPerfilCompetenciasCorporativas>();
            TblCargoPerfilCompetenciasCorporativasINivelRequeridoNavigation = new HashSet<TblCargoPerfilCompetenciasCorporativas>();
            TblCargoPerfilCompetenciasFuncionalesICompetenciaFuncionalNavigation = new HashSet<TblCargoPerfilCompetenciasFuncionales>();
            TblCargoPerfilCompetenciasFuncionalesINivelRequeridoNavigation = new HashSet<TblCargoPerfilCompetenciasFuncionales>();
            TblCargoPerfilFuncionesAmbientalesIFuncionAmbientalNavigation = new HashSet<TblCargoPerfilFuncionesAmbientales>();
            TblCargoPerfilFuncionesAmbientalesIPeriodicidadNavigation = new HashSet<TblCargoPerfilFuncionesAmbientales>();
            TblCargoPerfilFuncionesSst = new HashSet<TblCargoPerfilFuncionesSst>();
            TblCargoPerfilIdiomasIIdiomaNavigation = new HashSet<TblCargoPerfilIdiomas>();
            TblCargoPerfilIdiomasINivelConversacionNavigation = new HashSet<TblCargoPerfilIdiomas>();
            TblCargoPerfilIdiomasINivelEscrituraNavigation = new HashSet<TblCargoPerfilIdiomas>();
            TblCargoPerfilIdiomasINivelLecturaNavigation = new HashSet<TblCargoPerfilIdiomas>();
            TblCargoPerfilNivelAcademico = new HashSet<TblCargoPerfilNivelAcademico>();
            TblCargoPerfilNivelAutoridad = new HashSet<TblCargoPerfilNivelAutoridad>();
            TblCargoPerfilResponsabilidadSstIPeriodicidadNavigation = new HashSet<TblCargoPerfilResponsabilidadSst>();
            TblCargoPerfilResponsabilidadSstIResponsabilidadNavigation = new HashSet<TblCargoPerfilResponsabilidadSst>();
            TblCargoPerfilResponsabilidades = new HashSet<TblCargoPerfilResponsabilidades>();
            TblCie10 = new HashSet<TblCie10>();
            TblCorredores = new HashSet<TblCorredores>();
            TblDashBoard = new HashSet<TblDashBoard>();
            TblDiagnosticoCondicionTrabajoIActividadesNavigation = new HashSet<TblDiagnosticoCondicionTrabajo>();
            TblDiagnosticoCondicionTrabajoITareasNavigation = new HashSet<TblDiagnosticoCondicionTrabajo>();
            TblDiagnosticoInicial = new HashSet<TblDiagnosticoInicial>();
            TblDiagnosticosIncapacidadesIIdorigenCalificadoIncapacidadNavigation = new HashSet<TblDiagnosticosIncapacidades>();
            TblDiagnosticosIncapacidadesIIdpresuntoOrigenIncapacidadNavigation = new HashSet<TblDiagnosticosIncapacidades>();
            TblDiagnosticosIncapacidadesIIdtipoAtencionNavigation = new HashSet<TblDiagnosticosIncapacidades>();
            TblEmisores = new HashSet<TblEmisores>();
            TblEmpleadosIIdestadoCivilNavigation = new HashSet<TblEmpleados>();
            TblEmpleadosIIdformacionEducativaNavigation = new HashSet<TblEmpleados>();
            TblEmpleadosIIdgeneroNavigation = new HashSet<TblEmpleados>();
            TblEmpleadosIIdtipoDocumentoNavigation = new HashSet<TblEmpleados>();
            TblEmpleadosIiDtipoVinculacionNavigation = new HashSet<TblEmpleados>();
            TblEmpresaEstandarDocGenSisIIdcoberturaNavigation = new HashSet<TblEmpresaEstandarDocGenSis>();
            TblEmpresaEstandarDocGenSisIIdestadoNavigation = new HashSet<TblEmpresaEstandarDocGenSis>();
            TblEmpresaEstandarDocGenSisIIdtipoDocumentoNavigation = new HashSet<TblEmpresaEstandarDocGenSis>();
            TblEmpresaEstandares = new HashSet<TblEmpresaEstandares>();
            TblEmpresaEstructuraProcesos = new HashSet<TblEmpresaEstructuraProcesos>();
            TblEmpresaGestora = new HashSet<TblEmpresaGestora>();
            TblEmpresaPolitica = new HashSet<TblEmpresaPolitica>();
            TblEmpresaProcesos = new HashSet<TblEmpresaProcesos>();
            TblEmpresas = new HashSet<TblEmpresas>();
            TblEmpresasVigencia = new HashSet<TblEmpresasVigencia>();
            TblEps = new HashSet<TblEps>();
            TblEstandarTipoPoliticas = new HashSet<TblEstandarTipoPoliticas>();
            TblFormatos = new HashSet<TblFormatos>();
            TblIpsIIdtipoIdentificacionNavigation = new HashSet<TblIps>();
            TblIpsITipoIpsNavigation = new HashSet<TblIps>();
            TblJurisprudencias = new HashSet<TblJurisprudencias>();
            TblMedicamentos = new HashSet<TblMedicamentos>();
            TblMedicamentosTemp = new HashSet<TblMedicamentosTemp>();
            TblPacientesIIdgeneroNavigation = new HashSet<TblPacientes>();
            TblPacientesIIdtipoDocNavigation = new HashSet<TblPacientes>();
            TblPerfilSocioDemoEdad = new HashSet<TblPerfilSocioDemoEdad>();
            TblPerfilSocioDemoEstadoCivil = new HashSet<TblPerfilSocioDemoEstadoCivil>();
            TblPerfilSocioDemoFormacionEduc = new HashSet<TblPerfilSocioDemoFormacionEduc>();
            TblPerfilSocioDemoTipoVincul = new HashSet<TblPerfilSocioDemoTipoVincul>();
            TblPlanCapacitacion = new HashSet<TblPlanCapacitacion>();
            TblRecobrosDocumentos = new HashSet<TblRecobrosDocumentos>();
            TblRecobrosDocumentosUsuarios = new HashSet<TblRecobrosDocumentosUsuarios>();
            TblSoportesIIdclaseSoporteNavigation = new HashSet<TblSoportes>();
            TblSoportesIIdtipoDocumentoNavigation = new HashSet<TblSoportes>();
            TblSucursalRiesgo = new HashSet<TblSucursalRiesgo>();
            TblSucursalesEmpresas = new HashSet<TblSucursalesEmpresas>();
            TblTareasIIdestadoTareaNavigation = new HashSet<TblTareas>();
            TblTareasIIdtipoTareaNavigation = new HashSet<TblTareas>();
            TblUsuarios = new HashSet<TblUsuarios>();
            TblVendedor = new HashSet<TblVendedor>();
        }

        public long IIdmultivalor { get; set; }
        public int IIdsubtabla { get; set; }
        public string TSubtabla { get; set; }
        public int IOrden { get; set; }
        public string TValor { get; set; }
        public string TDescripcion { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IIdusuarioCreador { get; set; }
        public bool BActivo { get; set; }

        public virtual TblUsuarios IIdusuarioCreadorNavigation { get; set; }
        public virtual ICollection<TblAccidentesTrabajo> TblAccidentesTrabajoIIdactividadEconomicaNavigation { get; set; }
        public virtual ICollection<TblAccidentesTrabajo> TblAccidentesTrabajoIIdtipoEventoNavigation { get; set; }
        public virtual ICollection<TblAccidentesTrabajo> TblAccidentesTrabajoIIdtipoIdentificacionNavigation { get; set; }
        public virtual ICollection<TblAccidentesTrabajo> TblAccidentesTrabajoIIdtipoVinculaciontrabNavigation { get; set; }
        public virtual ICollection<TblAccidentesTrabajo> TblAccidentesTrabajoIIdtipoVinculadorNavigation { get; set; }
        public virtual ICollection<TblAccidentesTrabajo> TblAccidentesTrabajoIJornadaNavigation { get; set; }
        public virtual ICollection<TblActaMensualCompromisos> TblActaMensualCompromisos { get; set; }
        public virtual ICollection<TblActaMensual> TblActaMensualIIdclaseActaNavigation { get; set; }
        public virtual ICollection<TblActaMensual> TblActaMensualITipoReunionNavigation { get; set; }
        public virtual ICollection<TblActas> TblActasIIdclaseActaNavigation { get; set; }
        public virtual ICollection<TblActas> TblActasIIdtipoActaNavigation { get; set; }
        public virtual ICollection<TblAfp> TblAfp { get; set; }
        public virtual ICollection<TblArls> TblArls { get; set; }
        public virtual ICollection<TblAtequiposProteccion> TblAtequiposProteccion { get; set; }
        public virtual ICollection<TblCajasCompensacion> TblCajasCompensacion { get; set; }
        public virtual ICollection<TblCargoPerfilCompetenciasCorporativas> TblCargoPerfilCompetenciasCorporativasICompetenciaCorporativaNavigation { get; set; }
        public virtual ICollection<TblCargoPerfilCompetenciasCorporativas> TblCargoPerfilCompetenciasCorporativasINivelRequeridoNavigation { get; set; }
        public virtual ICollection<TblCargoPerfilCompetenciasFuncionales> TblCargoPerfilCompetenciasFuncionalesICompetenciaFuncionalNavigation { get; set; }
        public virtual ICollection<TblCargoPerfilCompetenciasFuncionales> TblCargoPerfilCompetenciasFuncionalesINivelRequeridoNavigation { get; set; }
        public virtual ICollection<TblCargoPerfilFuncionesAmbientales> TblCargoPerfilFuncionesAmbientalesIFuncionAmbientalNavigation { get; set; }
        public virtual ICollection<TblCargoPerfilFuncionesAmbientales> TblCargoPerfilFuncionesAmbientalesIPeriodicidadNavigation { get; set; }
        public virtual ICollection<TblCargoPerfilFuncionesSst> TblCargoPerfilFuncionesSst { get; set; }
        public virtual ICollection<TblCargoPerfilIdiomas> TblCargoPerfilIdiomasIIdiomaNavigation { get; set; }
        public virtual ICollection<TblCargoPerfilIdiomas> TblCargoPerfilIdiomasINivelConversacionNavigation { get; set; }
        public virtual ICollection<TblCargoPerfilIdiomas> TblCargoPerfilIdiomasINivelEscrituraNavigation { get; set; }
        public virtual ICollection<TblCargoPerfilIdiomas> TblCargoPerfilIdiomasINivelLecturaNavigation { get; set; }
        public virtual ICollection<TblCargoPerfilNivelAcademico> TblCargoPerfilNivelAcademico { get; set; }
        public virtual ICollection<TblCargoPerfilNivelAutoridad> TblCargoPerfilNivelAutoridad { get; set; }
        public virtual ICollection<TblCargoPerfilResponsabilidadSst> TblCargoPerfilResponsabilidadSstIPeriodicidadNavigation { get; set; }
        public virtual ICollection<TblCargoPerfilResponsabilidadSst> TblCargoPerfilResponsabilidadSstIResponsabilidadNavigation { get; set; }
        public virtual ICollection<TblCargoPerfilResponsabilidades> TblCargoPerfilResponsabilidades { get; set; }
        public virtual ICollection<TblCie10> TblCie10 { get; set; }
        public virtual ICollection<TblCorredores> TblCorredores { get; set; }
        public virtual ICollection<TblDashBoard> TblDashBoard { get; set; }
        public virtual ICollection<TblDiagnosticoCondicionTrabajo> TblDiagnosticoCondicionTrabajoIActividadesNavigation { get; set; }
        public virtual ICollection<TblDiagnosticoCondicionTrabajo> TblDiagnosticoCondicionTrabajoITareasNavigation { get; set; }
        public virtual ICollection<TblDiagnosticoInicial> TblDiagnosticoInicial { get; set; }
        public virtual ICollection<TblDiagnosticosIncapacidades> TblDiagnosticosIncapacidadesIIdorigenCalificadoIncapacidadNavigation { get; set; }
        public virtual ICollection<TblDiagnosticosIncapacidades> TblDiagnosticosIncapacidadesIIdpresuntoOrigenIncapacidadNavigation { get; set; }
        public virtual ICollection<TblDiagnosticosIncapacidades> TblDiagnosticosIncapacidadesIIdtipoAtencionNavigation { get; set; }
        public virtual ICollection<TblEmisores> TblEmisores { get; set; }
        public virtual ICollection<TblEmpleados> TblEmpleadosIIdestadoCivilNavigation { get; set; }
        public virtual ICollection<TblEmpleados> TblEmpleadosIIdformacionEducativaNavigation { get; set; }
        public virtual ICollection<TblEmpleados> TblEmpleadosIIdgeneroNavigation { get; set; }
        public virtual ICollection<TblEmpleados> TblEmpleadosIIdtipoDocumentoNavigation { get; set; }
        public virtual ICollection<TblEmpleados> TblEmpleadosIiDtipoVinculacionNavigation { get; set; }
        public virtual ICollection<TblEmpresaEstandarDocGenSis> TblEmpresaEstandarDocGenSisIIdcoberturaNavigation { get; set; }
        public virtual ICollection<TblEmpresaEstandarDocGenSis> TblEmpresaEstandarDocGenSisIIdestadoNavigation { get; set; }
        public virtual ICollection<TblEmpresaEstandarDocGenSis> TblEmpresaEstandarDocGenSisIIdtipoDocumentoNavigation { get; set; }
        public virtual ICollection<TblEmpresaEstandares> TblEmpresaEstandares { get; set; }
        public virtual ICollection<TblEmpresaEstructuraProcesos> TblEmpresaEstructuraProcesos { get; set; }
        public virtual ICollection<TblEmpresaGestora> TblEmpresaGestora { get; set; }
        public virtual ICollection<TblEmpresaPolitica> TblEmpresaPolitica { get; set; }
        public virtual ICollection<TblEmpresaProcesos> TblEmpresaProcesos { get; set; }
        public virtual ICollection<TblEmpresas> TblEmpresas { get; set; }
        public virtual ICollection<TblEmpresasVigencia> TblEmpresasVigencia { get; set; }
        public virtual ICollection<TblEps> TblEps { get; set; }
        public virtual ICollection<TblEstandarTipoPoliticas> TblEstandarTipoPoliticas { get; set; }
        public virtual ICollection<TblFormatos> TblFormatos { get; set; }
        public virtual ICollection<TblIps> TblIpsIIdtipoIdentificacionNavigation { get; set; }
        public virtual ICollection<TblIps> TblIpsITipoIpsNavigation { get; set; }
        public virtual ICollection<TblJurisprudencias> TblJurisprudencias { get; set; }
        public virtual ICollection<TblMedicamentos> TblMedicamentos { get; set; }
        public virtual ICollection<TblMedicamentosTemp> TblMedicamentosTemp { get; set; }
        public virtual ICollection<TblPacientes> TblPacientesIIdgeneroNavigation { get; set; }
        public virtual ICollection<TblPacientes> TblPacientesIIdtipoDocNavigation { get; set; }
        public virtual ICollection<TblPerfilSocioDemoEdad> TblPerfilSocioDemoEdad { get; set; }
        public virtual ICollection<TblPerfilSocioDemoEstadoCivil> TblPerfilSocioDemoEstadoCivil { get; set; }
        public virtual ICollection<TblPerfilSocioDemoFormacionEduc> TblPerfilSocioDemoFormacionEduc { get; set; }
        public virtual ICollection<TblPerfilSocioDemoTipoVincul> TblPerfilSocioDemoTipoVincul { get; set; }
        public virtual ICollection<TblPlanCapacitacion> TblPlanCapacitacion { get; set; }
        public virtual ICollection<TblRecobrosDocumentos> TblRecobrosDocumentos { get; set; }
        public virtual ICollection<TblRecobrosDocumentosUsuarios> TblRecobrosDocumentosUsuarios { get; set; }
        public virtual ICollection<TblSoportes> TblSoportesIIdclaseSoporteNavigation { get; set; }
        public virtual ICollection<TblSoportes> TblSoportesIIdtipoDocumentoNavigation { get; set; }
        public virtual ICollection<TblSucursalRiesgo> TblSucursalRiesgo { get; set; }
        public virtual ICollection<TblSucursalesEmpresas> TblSucursalesEmpresas { get; set; }
        public virtual ICollection<TblTareas> TblTareasIIdestadoTareaNavigation { get; set; }
        public virtual ICollection<TblTareas> TblTareasIIdtipoTareaNavigation { get; set; }
        public virtual ICollection<TblUsuarios> TblUsuarios { get; set; }
        public virtual ICollection<TblVendedor> TblVendedor { get; set; }
    }
}
