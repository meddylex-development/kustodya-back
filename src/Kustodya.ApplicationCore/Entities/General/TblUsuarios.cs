using Kustodya.ApplicationCore.Entities.Administracion;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Specifications;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblUsuarios
    {
        private readonly ILoggerService<TblUsuarios> _logger;
        private readonly IAsyncRepository<TblUsuarios> _usuariosRepository;
        public TblUsuarios()
        {
            TblAccidentesTrabajo = new HashSet<TblAccidentesTrabajo>();
            TblActaMensual = new HashSet<TblActaMensual>();
            TblActaMensualCompromisoActividades = new HashSet<TblActaMensualCompromisoActividades>();
            TblActaMensualCompromisosIUsuarioAsignadoNavigation = new HashSet<TblActaMensualCompromisos>();
            TblActaMensualCompromisosIUsuarioConfirmacionNavigation = new HashSet<TblActaMensualCompromisos>();
            TblActaMensualCompromisosIUsuarioCreacionNavigation = new HashSet<TblActaMensualCompromisos>();
            TblActaMensualParticipantes = new HashSet<TblActaMensualParticipantes>();
            TblActas = new HashSet<TblActas>();
            TblAfp = new HashSet<TblAfp>();
            TblArls = new HashSet<TblArls>();
            TblAsignacion = new HashSet<TblAsignacion>();
            TblAtanalisisCausas = new HashSet<TblAtanalisisCausas>();
            TblAtequiposProteccion = new HashSet<TblAtequiposProteccion>();
            TblAtinformacionSuceso = new HashSet<TblAtinformacionSuceso>();
            TblAtmedidasAccionesCorrectivas = new HashSet<TblAtmedidasAccionesCorrectivas>();
            TblAtmedidasSeguridad = new HashSet<TblAtmedidasSeguridad>();
            TblAtpartesAfectadas = new HashSet<TblAtpartesAfectadas>();
            TblAtpersonas = new HashSet<TblAtpersonas>();
            TblAusentismoHorasHombreTrabajadas = new HashSet<TblAusentismoHorasHombreTrabajadas>();
            TblAusentismoIndicadoresInfraestructura = new HashSet<TblAusentismoIndicadoresInfraestructura>();
            TblAusentismoIndicadoresProceso = new HashSet<TblAusentismoIndicadoresProceso>();
            TblAusentismoIndiceAccidentalidad = new HashSet<TblAusentismoIndiceAccidentalidad>();
            TblAusentismoIndiceEnfermedadProfesional = new HashSet<TblAusentismoIndiceEnfermedadProfesional>();
            TblAusentismoPrevalenciaIncidencia = new HashSet<TblAusentismoPrevalenciaIncidencia>();
            TblAyudas = new HashSet<TblAyudas>();
            TblCajasCompensacion = new HashSet<TblCajasCompensacion>();
            TblCargoPerfil = new HashSet<TblCargoPerfil>();
            TblCargoPerfilCompetenciasCorporativas = new HashSet<TblCargoPerfilCompetenciasCorporativas>();
            TblCargoPerfilCompetenciasFuncionales = new HashSet<TblCargoPerfilCompetenciasFuncionales>();
            TblCargoPerfilFuncionesAmbientales = new HashSet<TblCargoPerfilFuncionesAmbientales>();
            TblCargoPerfilFuncionesSst = new HashSet<TblCargoPerfilFuncionesSst>();
            TblCargoPerfilIdiomas = new HashSet<TblCargoPerfilIdiomas>();
            TblCargoPerfilNivelAcademico = new HashSet<TblCargoPerfilNivelAcademico>();
            TblCargoPerfilNivelAutoridad = new HashSet<TblCargoPerfilNivelAutoridad>();
            TblCargoPerfilObjetivos = new HashSet<TblCargoPerfilObjetivos>();
            TblCargoPerfilResponsabilidadSst = new HashSet<TblCargoPerfilResponsabilidadSst>();
            TblCargoPerfilResponsabilidades = new HashSet<TblCargoPerfilResponsabilidades>();
            TblCargosIIdusuarioCreadorNavigation = new HashSet<TblCargos>();
            TblCargosIIdusuarioModificacionNavigation = new HashSet<TblCargos>();
            TblClasificacionRiesgos = new HashSet<TblClasificacionRiesgos>();
            TblCorredores = new HashSet<TblCorredores>();
            TblDashBoard = new HashSet<TblDashBoard>();
            TblDiagnosticoInicial = new HashSet<TblDiagnosticoInicial>();
            TblElementosIIdusuarioInsercionNavigation = new HashSet<TblElementos>();
            TblElementosIIdusuarioModificacionNavigation = new HashSet<TblElementos>();
            TblEmisores = new HashSet<TblEmisores>();
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
            TblEmpresaGestora = new HashSet<TblEmpresaGestora>();
            TblEmpresaJurisprudencias = new HashSet<TblEmpresaJurisprudencias>();
            TblEmpresaParametros = new HashSet<TblEmpresaParametros>();
            TblEmpresaPoliticaControlCambiosIIdusuarioCreacionNavigation = new HashSet<TblEmpresaPoliticaControlCambios>();
            TblEmpresaPoliticaControlCambiosIIdusuarioModificacionNavigation = new HashSet<TblEmpresaPoliticaControlCambios>();
            TblEmpresaPoliticaControlCambiosIIdusuarioNavigation = new HashSet<TblEmpresaPoliticaControlCambios>();
            TblEmpresaProcesos = new HashSet<TblEmpresaProcesos>();
            TblEmpresaRiesgoValoracion = new HashSet<TblEmpresaRiesgoValoracion>();
            TblEmpresasArls = new HashSet<TblEmpresasArls>();
            TblEmpresasCorredores = new HashSet<TblEmpresasCorredores>();
            TblEmpresasVigencia = new HashSet<TblEmpresasVigencia>();
            TblEntradasSalidas = new HashSet<TblEntradasSalidas>();
            TblEps = new HashSet<TblEps>();
            TblEstandarTipoPoliticas = new HashSet<TblEstandarTipoPoliticas>();
            TblExtintoresTipo = new HashSet<TblExtintoresTipo>();
            TblFormatos = new HashSet<TblFormatos>();
            TblFormulariosIIdusuarioCreacionNavigation = new HashSet<TblFormularios>();
            TblFormulariosIIdusuarioModificacionNavigation = new HashSet<TblFormularios>();
            TblIdiomas = new HashSet<TblIdiomas>();
            TblIndicadoresDetalle = new HashSet<TblIndicadoresDetalle>();
            TblIndicadoresMatriz = new HashSet<TblIndicadoresMatriz>();
            TblInspeccionExtintoresDetalle = new HashSet<TblInspeccionExtintoresDetalle>();
            TblInspeccionExtintoresDetalleMtto = new HashSet<TblInspeccionExtintoresDetalleMtto>();
            TblInspecciones = new HashSet<TblInspecciones>();
            TblInspeccionesPrograma = new HashSet<TblInspeccionesPrograma>();
            TblInstalacionElectricaAlumbrado = new HashSet<TblInstalacionElectricaAlumbrado>();
            TblInstalacionElectricaCircuitos = new HashSet<TblInstalacionElectricaCircuitos>();
            TblInstalacionElectricaInterruptores = new HashSet<TblInstalacionElectricaInterruptores>();
            TblInstalacionElectricaTomas = new HashSet<TblInstalacionElectricaTomas>();
            TblIps = new HashSet<TblIps>();
            TblJurisprudencias = new HashSet<TblJurisprudencias>();
            TblMapaProcesoPosiciones = new HashSet<TblMapaProcesoPosiciones>();
            TblMultivalores = new HashSet<TblMultivalores>();
            TblNumerales = new HashSet<TblNumerales>();
            TblNumeralesProceso = new HashSet<TblNumeralesProceso>();
            TblPartesCuerpo = new HashSet<TblPartesCuerpo>();
            TblPerfilSocioDemoAfp = new HashSet<TblPerfilSocioDemoAfp>();
            TblPerfilSocioDemoCargo = new HashSet<TblPerfilSocioDemoCargo>();
            TblPerfilSocioDemoEdad = new HashSet<TblPerfilSocioDemoEdad>();
            TblPerfilSocioDemoEps = new HashSet<TblPerfilSocioDemoEps>();
            TblPerfilSocioDemoEstadoCivil = new HashSet<TblPerfilSocioDemoEstadoCivil>();
            TblPerfilSocioDemoFormacionEduc = new HashSet<TblPerfilSocioDemoFormacionEduc>();
            TblPerfilSocioDemoSucursal = new HashSet<TblPerfilSocioDemoSucursal>();
            TblPerfilSocioDemoTipoVincul = new HashSet<TblPerfilSocioDemoTipoVincul>();
            TblPerfilSocioDemografico = new HashSet<TblPerfilSocioDemografico>();
            TblPhva = new HashSet<TblPhva>();
            TblPlanAccionActividadesIIdresponsableNavigation = new HashSet<TblPlanAccionActividades>();
            TblPlanAccionActividadesIUsuarioCreacionNavigation = new HashSet<TblPlanAccionActividades>();
            TblPlanAccionIIdresponsableNavigation = new HashSet<TblPlanAccion>();
            TblPlanAccionIUsuarioCreacionNavigation = new HashSet<TblPlanAccion>();
            TblPlanAccionRazones = new HashSet<TblPlanAccionRazones>();
            TblPlanAccionTareas = new HashSet<TblPlanAccionTareas>();
            TblPlanCapacitacion = new HashSet<TblPlanCapacitacion>();
            TblPlanCapacitacionAsistentes = new HashSet<TblPlanCapacitacionAsistentes>();
            TblPlanCapacitacionSesiones = new HashSet<TblPlanCapacitacionSesiones>();
            TblPosiblesRiesgos = new HashSet<TblPosiblesRiesgos>();
            TblProcedimientos = new HashSet<TblProcedimientos>();
            TblProcesos = new HashSet<TblProcesos>();
            TblRecobroEstados = new HashSet<TblRecobroEstados>();
            TblRecobroEstadosDocumentos = new HashSet<TblRecobroEstadosDocumentos>();
            TblRecobroEstadosDocumentosIdiomas = new HashSet<TblRecobroEstadosDocumentosIdiomas>();
            TblRecobroEstadosIdiomas = new HashSet<TblRecobroEstadosIdiomas>();
            TblRecobrosDocumentosIIdusuarioCreacionNavigation = new HashSet<TblRecobrosDocumentos>();
            TblRecobrosDocumentosIIdusuarioModificacionNavigation = new HashSet<TblRecobrosDocumentos>();
            TblRecobrosDocumentosUsuariosIIdusuarioCreacionNavigation = new HashSet<TblRecobrosDocumentosUsuarios>();
            TblRecobrosDocumentosUsuariosIIdusuarioModificacionNavigation = new HashSet<TblRecobrosDocumentosUsuarios>();
            TblRecobrosIIdusuarioCreacionNavigation = new HashSet<TblRecobros>();
            TblRecobrosIIdusuarioModificacionNavigation = new HashSet<TblRecobros>();
            TblRecobrosUsuariosElementosIIdusuarioCreacionNavigation = new HashSet<TblRecobrosUsuariosElementos>();
            TblRecobrosUsuariosElementosIIdusuarioModificacionNavigation = new HashSet<TblRecobrosUsuariosElementos>();
            TblRecobrosUsuariosServiciosProcedimientosIIdusuarioCreacionNavigation = new HashSet<TblRecobrosUsuariosServiciosProcedimientos>();
            TblRecobrosUsuariosServiciosProcedimientosIIdusuarioModificacionNavigation = new HashSet<TblRecobrosUsuariosServiciosProcedimientos>();
            TblRecursos = new HashSet<TblRecursos>();
            TblRhsi = new HashSet<TblRhsi>();
            TblRiesgoAnalisis = new HashSet<TblRiesgoAnalisis>();
            TblRiesgoCausas = new HashSet<TblRiesgoCausas>();
            TblRiesgoControlValoraciones = new HashSet<TblRiesgoControlValoraciones>();
            TblRiesgoControles = new HashSet<TblRiesgoControles>();
            TblRiesgoEfectos = new HashSet<TblRiesgoEfectos>();
            TblRiesgoIdentificacion = new HashSet<TblRiesgoIdentificacion>();
            TblRiesgoResidual = new HashSet<TblRiesgoResidual>();
            TblServiciosProcedimientosIIdusuarioInsercionNavigation = new HashSet<TblServiciosProcedimientos>();
            TblServiciosProcedimientosIIdusuarioModificacionNavigation = new HashSet<TblServiciosProcedimientos>();
            TblSoa = new HashSet<TblSoa>();
            TblSoportes = new HashSet<TblSoportes>();
            TblSoportes1 = new HashSet<TblSoportes1>();
            TblSucursalesEmpresas = new HashSet<TblSucursalesEmpresas>();
            TblTareaActividades = new HashSet<TblTareaActividades>();
            TblTareasIIdusuarioInsecionNavigation = new HashSet<TblTareas>();
            TblTareasIIdusuarioTareaNavigation = new HashSet<TblTareas>();
            TblTipoProceso = new HashSet<TblTipoProceso>();
            TblUsuariosEmpresas = new HashSet<TblUsuariosEmpresas>();
            TblUsuariosPerfiles = new HashSet<TblUsuariosPerfiles>();
            TblVendedor = new HashSet<TblVendedor>();
        }

        public int IIdusuario { get; set; }
        public string TIdnumDoc { get; set; }
        public string TUsuario { get; set; }
        public string TPrimerNombre { get; set; }
        public string TSegundoNombre { get; set; }
        public string TPrimerApellido { get; set; }
        public string TSegundoApellido { get; set; }
        public string TClave { get; set; }
        public long IIdtipoDoc { get; set; }
        public int? IIdsubtablaTipoDoc { get; set; }
        public string TIdvalorTipoDoc { get; set; }
        public long? IIdgenero { get; set; }
        public string TTelefono { get; set; }
        public string TCelular { get; set; }
        public string TEmail { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public bool BActivo { get; set; }
        public int IIdusuarioCreador { get; set; }
        public DateTime DtFechaCambioPassword { get; set; }
        public bool BCambioPassword { get; set; }
        public long? IPerfilDocumentos { get; set; }
        
        // Campos para registro desde Kustodya
        public DateTime FechaNacimiento { get; set; }
        public string RegistroMedico { get; set; }
        public bool EsMedico { get; set; }
        public bool OtrosTratamientos { get; set; }
        public string Firma { get; set; }
        public bool EsSuperAdmin { get; set; }
        
        // Campos registro usuario
        public ICollection<UsuarioDireccion> Direcciones { get; set; }
        public ICollection<UsuarioTelefono> Telefonos { get; set; }
        public ICollection<UsuarioCorreo> Correos { get; set; }
        public ICollection<UsuarioRedSocial> RedesSociales { get; set; }
        public ICollection<UsuarioEPS> EPSs{ get; set; }
        public ICollection<UsuarioCliente> Clientes { get; set; }
        public ICollection<UsuarioEntidad> Entidades { get; set; }

        public virtual TblMultivalores IIdtipoDocNavigation { get; set; }
        public virtual ICollection<TblAccidentesTrabajo> TblAccidentesTrabajo { get; set; }
        public virtual ICollection<TblActaMensual> TblActaMensual { get; set; }
        public virtual ICollection<TblActaMensualCompromisoActividades> TblActaMensualCompromisoActividades { get; set; }
        public virtual ICollection<TblActaMensualCompromisos> TblActaMensualCompromisosIUsuarioAsignadoNavigation { get; set; }
        public virtual ICollection<TblActaMensualCompromisos> TblActaMensualCompromisosIUsuarioConfirmacionNavigation { get; set; }
        public virtual ICollection<TblActaMensualCompromisos> TblActaMensualCompromisosIUsuarioCreacionNavigation { get; set; }
        public virtual ICollection<TblActaMensualParticipantes> TblActaMensualParticipantes { get; set; }
        public virtual ICollection<TblActas> TblActas { get; set; }
        public virtual ICollection<TblAfp> TblAfp { get; set; }
        public virtual ICollection<TblArls> TblArls { get; set; }
        public virtual ICollection<TblAsignacion> TblAsignacion { get; set; }
        public virtual ICollection<TblAtanalisisCausas> TblAtanalisisCausas { get; set; }
        public virtual ICollection<TblAtequiposProteccion> TblAtequiposProteccion { get; set; }
        public virtual ICollection<TblAtinformacionSuceso> TblAtinformacionSuceso { get; set; }
        public virtual ICollection<TblAtmedidasAccionesCorrectivas> TblAtmedidasAccionesCorrectivas { get; set; }
        public virtual ICollection<TblAtmedidasSeguridad> TblAtmedidasSeguridad { get; set; }
        public virtual ICollection<TblAtpartesAfectadas> TblAtpartesAfectadas { get; set; }
        public virtual ICollection<TblAtpersonas> TblAtpersonas { get; set; }
        public virtual ICollection<TblAusentismoHorasHombreTrabajadas> TblAusentismoHorasHombreTrabajadas { get; set; }
        public virtual ICollection<TblAusentismoIndicadoresInfraestructura> TblAusentismoIndicadoresInfraestructura { get; set; }
        public virtual ICollection<TblAusentismoIndicadoresProceso> TblAusentismoIndicadoresProceso { get; set; }
        public virtual ICollection<TblAusentismoIndiceAccidentalidad> TblAusentismoIndiceAccidentalidad { get; set; }
        public virtual ICollection<TblAusentismoIndiceEnfermedadProfesional> TblAusentismoIndiceEnfermedadProfesional { get; set; }
        public virtual ICollection<TblAusentismoPrevalenciaIncidencia> TblAusentismoPrevalenciaIncidencia { get; set; }
        public virtual ICollection<TblAyudas> TblAyudas { get; set; }
        public virtual ICollection<TblCajasCompensacion> TblCajasCompensacion { get; set; }
        public virtual ICollection<TblCargoPerfil> TblCargoPerfil { get; set; }
        public virtual ICollection<TblCargoPerfilCompetenciasCorporativas> TblCargoPerfilCompetenciasCorporativas { get; set; }
        public virtual ICollection<TblCargoPerfilCompetenciasFuncionales> TblCargoPerfilCompetenciasFuncionales { get; set; }
        public virtual ICollection<TblCargoPerfilFuncionesAmbientales> TblCargoPerfilFuncionesAmbientales { get; set; }
        public virtual ICollection<TblCargoPerfilFuncionesSst> TblCargoPerfilFuncionesSst { get; set; }
        public virtual ICollection<TblCargoPerfilIdiomas> TblCargoPerfilIdiomas { get; set; }
        public virtual ICollection<TblCargoPerfilNivelAcademico> TblCargoPerfilNivelAcademico { get; set; }
        public virtual ICollection<TblCargoPerfilNivelAutoridad> TblCargoPerfilNivelAutoridad { get; set; }
        public virtual ICollection<TblCargoPerfilObjetivos> TblCargoPerfilObjetivos { get; set; }
        public virtual ICollection<TblCargoPerfilResponsabilidadSst> TblCargoPerfilResponsabilidadSst { get; set; }
        public virtual ICollection<TblCargoPerfilResponsabilidades> TblCargoPerfilResponsabilidades { get; set; }
        public virtual ICollection<TblCargos> TblCargosIIdusuarioCreadorNavigation { get; set; }
        public virtual ICollection<TblCargos> TblCargosIIdusuarioModificacionNavigation { get; set; }
        public virtual ICollection<TblClasificacionRiesgos> TblClasificacionRiesgos { get; set; }
        public virtual ICollection<TblCorredores> TblCorredores { get; set; }
        public virtual ICollection<TblDashBoard> TblDashBoard { get; set; }
        public virtual ICollection<TblDiagnosticoInicial> TblDiagnosticoInicial { get; set; }
        public virtual ICollection<TblElementos> TblElementosIIdusuarioInsercionNavigation { get; set; }
        public virtual ICollection<TblElementos> TblElementosIIdusuarioModificacionNavigation { get; set; }
        public virtual ICollection<TblEmisores> TblEmisores { get; set; }
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
        public virtual ICollection<TblEmpresaGestora> TblEmpresaGestora { get; set; }
        public virtual ICollection<TblEmpresaJurisprudencias> TblEmpresaJurisprudencias { get; set; }
        public virtual ICollection<TblEmpresaParametros> TblEmpresaParametros { get; set; }
        public virtual ICollection<TblEmpresaPoliticaControlCambios> TblEmpresaPoliticaControlCambiosIIdusuarioCreacionNavigation { get; set; }
        public virtual ICollection<TblEmpresaPoliticaControlCambios> TblEmpresaPoliticaControlCambiosIIdusuarioModificacionNavigation { get; set; }
        public virtual ICollection<TblEmpresaPoliticaControlCambios> TblEmpresaPoliticaControlCambiosIIdusuarioNavigation { get; set; }
        public virtual ICollection<TblEmpresaProcesos> TblEmpresaProcesos { get; set; }
        public virtual ICollection<TblEmpresaRiesgoValoracion> TblEmpresaRiesgoValoracion { get; set; }
        public virtual ICollection<TblEmpresasArls> TblEmpresasArls { get; set; }
        public virtual ICollection<TblEmpresasCorredores> TblEmpresasCorredores { get; set; }
        public virtual ICollection<TblEmpresasVigencia> TblEmpresasVigencia { get; set; }
        public virtual ICollection<TblEntradasSalidas> TblEntradasSalidas { get; set; }
        public virtual ICollection<TblEps> TblEps { get; set; }
        public virtual ICollection<TblEstandarTipoPoliticas> TblEstandarTipoPoliticas { get; set; }
        public virtual ICollection<TblExtintoresTipo> TblExtintoresTipo { get; set; }
        public virtual ICollection<TblFormatos> TblFormatos { get; set; }
        public virtual ICollection<TblFormularios> TblFormulariosIIdusuarioCreacionNavigation { get; set; }
        public virtual ICollection<TblFormularios> TblFormulariosIIdusuarioModificacionNavigation { get; set; }
        public virtual ICollection<TblIdiomas> TblIdiomas { get; set; }
        public virtual ICollection<TblIndicadoresDetalle> TblIndicadoresDetalle { get; set; }
        public virtual ICollection<TblIndicadoresMatriz> TblIndicadoresMatriz { get; set; }
        public virtual ICollection<TblInspeccionExtintoresDetalle> TblInspeccionExtintoresDetalle { get; set; }
        public virtual ICollection<TblInspeccionExtintoresDetalleMtto> TblInspeccionExtintoresDetalleMtto { get; set; }
        public virtual ICollection<TblInspecciones> TblInspecciones { get; set; }
        public virtual ICollection<TblInspeccionesPrograma> TblInspeccionesPrograma { get; set; }
        public virtual ICollection<TblInstalacionElectricaAlumbrado> TblInstalacionElectricaAlumbrado { get; set; }
        public virtual ICollection<TblInstalacionElectricaCircuitos> TblInstalacionElectricaCircuitos { get; set; }
        public virtual ICollection<TblInstalacionElectricaInterruptores> TblInstalacionElectricaInterruptores { get; set; }
        public virtual ICollection<TblInstalacionElectricaTomas> TblInstalacionElectricaTomas { get; set; }
        public virtual ICollection<TblIps> TblIps { get; set; }
        public virtual ICollection<TblJurisprudencias> TblJurisprudencias { get; set; }
        public virtual ICollection<TblMapaProcesoPosiciones> TblMapaProcesoPosiciones { get; set; }
        public virtual ICollection<TblMultivalores> TblMultivalores { get; set; }
        public virtual ICollection<TblNumerales> TblNumerales { get; set; }
        public virtual ICollection<TblNumeralesProceso> TblNumeralesProceso { get; set; }
        public virtual ICollection<TblPartesCuerpo> TblPartesCuerpo { get; set; }
        public virtual ICollection<TblPerfilSocioDemoAfp> TblPerfilSocioDemoAfp { get; set; }
        public virtual ICollection<TblPerfilSocioDemoCargo> TblPerfilSocioDemoCargo { get; set; }
        public virtual ICollection<TblPerfilSocioDemoEdad> TblPerfilSocioDemoEdad { get; set; }
        public virtual ICollection<TblPerfilSocioDemoEps> TblPerfilSocioDemoEps { get; set; }
        public virtual ICollection<TblPerfilSocioDemoEstadoCivil> TblPerfilSocioDemoEstadoCivil { get; set; }
        public virtual ICollection<TblPerfilSocioDemoFormacionEduc> TblPerfilSocioDemoFormacionEduc { get; set; }
        public virtual ICollection<TblPerfilSocioDemoSucursal> TblPerfilSocioDemoSucursal { get; set; }
        public virtual ICollection<TblPerfilSocioDemoTipoVincul> TblPerfilSocioDemoTipoVincul { get; set; }
        public virtual ICollection<TblPerfilSocioDemografico> TblPerfilSocioDemografico { get; set; }
        public virtual ICollection<TblPhva> TblPhva { get; set; }
        public virtual ICollection<TblPlanAccionActividades> TblPlanAccionActividadesIIdresponsableNavigation { get; set; }
        public virtual ICollection<TblPlanAccionActividades> TblPlanAccionActividadesIUsuarioCreacionNavigation { get; set; }
        public virtual ICollection<TblPlanAccion> TblPlanAccionIIdresponsableNavigation { get; set; }
        public virtual ICollection<TblPlanAccion> TblPlanAccionIUsuarioCreacionNavigation { get; set; }
        public virtual ICollection<TblPlanAccionRazones> TblPlanAccionRazones { get; set; }
        public virtual ICollection<TblPlanAccionTareas> TblPlanAccionTareas { get; set; }
        public virtual ICollection<TblPlanCapacitacion> TblPlanCapacitacion { get; set; }
        public virtual ICollection<TblPlanCapacitacionAsistentes> TblPlanCapacitacionAsistentes { get; set; }
        public virtual ICollection<TblPlanCapacitacionSesiones> TblPlanCapacitacionSesiones { get; set; }
        public virtual ICollection<TblPosiblesRiesgos> TblPosiblesRiesgos { get; set; }
        public virtual ICollection<TblProcedimientos> TblProcedimientos { get; set; }
        public virtual ICollection<TblProcesos> TblProcesos { get; set; }
        public virtual ICollection<TblRecobroEstados> TblRecobroEstados { get; set; }
        public virtual ICollection<TblRecobroEstadosDocumentos> TblRecobroEstadosDocumentos { get; set; }
        public virtual ICollection<TblRecobroEstadosDocumentosIdiomas> TblRecobroEstadosDocumentosIdiomas { get; set; }
        public virtual ICollection<TblRecobroEstadosIdiomas> TblRecobroEstadosIdiomas { get; set; }
        public virtual ICollection<TblRecobrosDocumentos> TblRecobrosDocumentosIIdusuarioCreacionNavigation { get; set; }
        public virtual ICollection<TblRecobrosDocumentos> TblRecobrosDocumentosIIdusuarioModificacionNavigation { get; set; }
        public virtual ICollection<TblRecobrosDocumentosUsuarios> TblRecobrosDocumentosUsuariosIIdusuarioCreacionNavigation { get; set; }
        public virtual ICollection<TblRecobrosDocumentosUsuarios> TblRecobrosDocumentosUsuariosIIdusuarioModificacionNavigation { get; set; }
        public virtual ICollection<TblRecobros> TblRecobrosIIdusuarioCreacionNavigation { get; set; }
        public virtual ICollection<TblRecobros> TblRecobrosIIdusuarioModificacionNavigation { get; set; }
        public virtual ICollection<TblRecobrosUsuariosElementos> TblRecobrosUsuariosElementosIIdusuarioCreacionNavigation { get; set; }
        public virtual ICollection<TblRecobrosUsuariosElementos> TblRecobrosUsuariosElementosIIdusuarioModificacionNavigation { get; set; }
        public virtual ICollection<TblRecobrosUsuariosServiciosProcedimientos> TblRecobrosUsuariosServiciosProcedimientosIIdusuarioCreacionNavigation { get; set; }
        public virtual ICollection<TblRecobrosUsuariosServiciosProcedimientos> TblRecobrosUsuariosServiciosProcedimientosIIdusuarioModificacionNavigation { get; set; }
        public virtual ICollection<TblRecursos> TblRecursos { get; set; }
        public virtual ICollection<TblRhsi> TblRhsi { get; set; }
        public virtual ICollection<TblRiesgoAnalisis> TblRiesgoAnalisis { get; set; }
        public virtual ICollection<TblRiesgoCausas> TblRiesgoCausas { get; set; }
        public virtual ICollection<TblRiesgoControlValoraciones> TblRiesgoControlValoraciones { get; set; }
        public virtual ICollection<TblRiesgoControles> TblRiesgoControles { get; set; }
        public virtual ICollection<TblRiesgoEfectos> TblRiesgoEfectos { get; set; }
        public virtual ICollection<TblRiesgoIdentificacion> TblRiesgoIdentificacion { get; set; }
        public virtual ICollection<TblRiesgoResidual> TblRiesgoResidual { get; set; }
        public virtual ICollection<TblServiciosProcedimientos> TblServiciosProcedimientosIIdusuarioInsercionNavigation { get; set; }
        public virtual ICollection<TblServiciosProcedimientos> TblServiciosProcedimientosIIdusuarioModificacionNavigation { get; set; }
        public virtual ICollection<TblSoa> TblSoa { get; set; }
        public virtual ICollection<TblSoportes> TblSoportes { get; set; }
        public virtual ICollection<TblSoportes1> TblSoportes1 { get; set; }
        public virtual ICollection<TblSucursalesEmpresas> TblSucursalesEmpresas { get; set; }
        public virtual ICollection<TblTareaActividades> TblTareaActividades { get; set; }
        public virtual ICollection<TblTareas> TblTareasIIdusuarioInsecionNavigation { get; set; }
        public virtual ICollection<TblTareas> TblTareasIIdusuarioTareaNavigation { get; set; }
        public virtual ICollection<TblTipoProceso> TblTipoProceso { get; set; }
        public virtual ICollection<TblUsuariosEmpresas> TblUsuariosEmpresas { get; set; }
        public virtual ICollection<TblUsuariosPerfiles> TblUsuariosPerfiles { get; set; }
        public virtual ICollection<TblVendedor> TblVendedor { get; set; }
        public void RecuperacionContrasena()
        {
            BCambioPassword = true;
        }

        public string ObtenerNombre() {
            return TPrimerNombre +
                (TSegundoNombre == null ? " " : (TSegundoNombre.Length == 0 ? " " : " " + TSegundoNombre + " ")) +
                TPrimerApellido +
                (TSegundoApellido == null ? " " : (TSegundoApellido.Length == 0 ? " " : " " + TSegundoApellido));
        }
    }
}
