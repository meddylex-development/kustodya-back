using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Entities.Administracion;
using Kustodya.ApplicationCore.Entities.Concepto;
using Kustodya.ApplicationCore.Entities.CalificacionOrigen;
//using Kustodya.ApplicationCore.Entities.Contabilidades;
using Microsoft.EntityFrameworkCore;
using Kustodya.ApplicationCore.Entities.Rethus;

namespace Kustodya.Infrastructure
{
    public partial class dbProtektoV1Context : DbContext
    {
        public dbProtektoV1Context()
        {
        }

        public dbProtektoV1Context(DbContextOptions<dbProtektoV1Context> options)
            : base(options)
        {
        }

        // public virtual DbSet<DepuracionContable> Encabezado { get; set; }
        // public virtual DbSet<Movimiento> Detalle { get; set; }
        public virtual DbSet<TblAccidentesTrabajo> TblAccidentesTrabajo { get; set; }
        public virtual DbSet<TblActaMensual> TblActaMensual { get; set; }
        public virtual DbSet<TblActaMensualCompromisoActividades> TblActaMensualCompromisoActividades { get; set; }
        public virtual DbSet<TblActaMensualCompromisos> TblActaMensualCompromisos { get; set; }
        public virtual DbSet<TblActaMensualParticipantes> TblActaMensualParticipantes { get; set; }
        public virtual DbSet<TblActas> TblActas { get; set; }
        public virtual DbSet<TblActividadEconomica> TblActividadEconomica { get; set; }
        public virtual DbSet<TblAfp> TblAfp { get; set; }
        //public virtual DbSet<PlazoLargo> PlazoLargos { get; set; }
        //public virtual DbSet<Pronosticos> Pronosticos { get; set; }
        //public virtual DbSet<Remisiones> Remisiones { get; set; }
        //public virtual DbSet<Etiologias> Etiologias { get; set; }
        //public virtual DbSet<FinalidadTratamientos> FinalidadTratamientos { get; set; }
        public virtual DbSet<ApplicationCore.Entities.Diagnostico> Diagnosticos { get; set; }
        public virtual DbSet<ConceptoRehabilitacion> ConceptoRehabilitacion { get; set; }
        //public virtual DbSet<Conceptos> Conceptos { get; set; }
        //public virtual DbSet<ConceptosMedicos> ConceptosMedicos { get; set; }
        //public virtual DbSet<DescripcionSecuelas> DescripcionSecuelas { get; set; }
        //public virtual DbSet<NotaRemisiones> NotaRemisiones { get; set; }
        //public virtual DbSet<TerapeuticaPosibles> TerapeuticaPosibles { get; set; }
        //public virtual DbSet<TipoSecuelas> TipoSecuelas { get; set; }
        public virtual DbSet<TblArls> TblArls { get; set; }
        public virtual DbSet<TblAsignacion> TblAsignacion { get; set; }
        public virtual DbSet<TblAtanalisisCausas> TblAtanalisisCausas { get; set; }
        public virtual DbSet<TblAtequiposProteccion> TblAtequiposProteccion { get; set; }
        public virtual DbSet<TblAtinformacionSuceso> TblAtinformacionSuceso { get; set; }
        public virtual DbSet<TblAtmedidasAccionesCorrectivas> TblAtmedidasAccionesCorrectivas { get; set; }
        public virtual DbSet<TblAtmedidasSeguridad> TblAtmedidasSeguridad { get; set; }
        public virtual DbSet<TblAtpartesAfectadas> TblAtpartesAfectadas { get; set; }
        public virtual DbSet<TblAtpersonas> TblAtpersonas { get; set; }
        public virtual DbSet<TblAuditoria> TblAuditoria { get; set; }
        public virtual DbSet<TblAusentismoHorasHombreTrabajadas> TblAusentismoHorasHombreTrabajadas { get; set; }
        public virtual DbSet<TblAusentismoIndicadoresInfraestructura> TblAusentismoIndicadoresInfraestructura { get; set; }
        public virtual DbSet<TblAusentismoIndicadoresProceso> TblAusentismoIndicadoresProceso { get; set; }
        public virtual DbSet<TblAusentismoIndiceAccidentalidad> TblAusentismoIndiceAccidentalidad { get; set; }
        public virtual DbSet<TblAusentismoIndiceEnfermedadProfesional> TblAusentismoIndiceEnfermedadProfesional { get; set; }
        public virtual DbSet<TblAusentismoPrevalenciaIncidencia> TblAusentismoPrevalenciaIncidencia { get; set; }
        public virtual DbSet<TblAyudas> TblAyudas { get; set; }
        public virtual DbSet<TblBlobs> TblBlobs { get; set; }
        public virtual DbSet<TblCajasCompensacion> TblCajasCompensacion { get; set; }
        public virtual DbSet<TblCargoPerfil> TblCargoPerfil { get; set; }
        public virtual DbSet<TblCargoPerfilCompetenciasCorporativas> TblCargoPerfilCompetenciasCorporativas { get; set; }
        public virtual DbSet<TblCargoPerfilCompetenciasFuncionales> TblCargoPerfilCompetenciasFuncionales { get; set; }
        public virtual DbSet<TblCargoPerfilFuncionesAmbientales> TblCargoPerfilFuncionesAmbientales { get; set; }
        public virtual DbSet<TblCargoPerfilFuncionesSst> TblCargoPerfilFuncionesSst { get; set; }
        public virtual DbSet<TblCargoPerfilIdiomas> TblCargoPerfilIdiomas { get; set; }
        public virtual DbSet<TblCargoPerfilNivelAcademico> TblCargoPerfilNivelAcademico { get; set; }
        public virtual DbSet<TblCargoPerfilNivelAutoridad> TblCargoPerfilNivelAutoridad { get; set; }
        public virtual DbSet<TblCargoPerfilObjetivos> TblCargoPerfilObjetivos { get; set; }
        public virtual DbSet<TblCargoPerfilResponsabilidadSst> TblCargoPerfilResponsabilidadSst { get; set; }
        public virtual DbSet<TblCargoPerfilResponsabilidades> TblCargoPerfilResponsabilidades { get; set; }
        public virtual DbSet<TblCargos> TblCargos { get; set; }
        public virtual DbSet<TblCie> TblCie { get; set; }
        public virtual DbSet<TblCie10> TblCie10 { get; set; }
        public virtual DbSet<TblCie10DiagnosticoIncapacidad> TblCie10DiagnosticoIncapacidad { get; set; }
        public virtual DbSet<TblCiedetalle> TblCiedetalle { get; set; }
        public virtual DbSet<TblCiiu> TblCiiu { get; set; }
        public virtual DbSet<TblCiuo08> TblCiuo08 { get; set; }
        public virtual DbSet<TblClasificacionRiesgos> TblClasificacionRiesgos { get; set; }
        public virtual DbSet<TblCodigosCorrelacion> TblCodigosCorrelacion { get; set; }
        public virtual DbSet<TblConceptoRehabilitacion> TblConceptoRehabilitacion { get; set; }
        public virtual DbSet<TblCorredores> TblCorredores { get; set; }
        public virtual DbSet<TblDashBoard> TblDashBoard { get; set; }
        public virtual DbSet<TblDiagnosticoCondicionTrabajo> TblDiagnosticoCondicionTrabajo { get; set; }
        public virtual DbSet<TblDiagnosticoInicial> TblDiagnosticoInicial { get; set; }
        public virtual DbSet<TblDiagnosticos> TblDiagnosticos { get; set; }
        public virtual DbSet<TblDiagnosticosCapitulos> TblDiagnosticosCapitulos { get; set; }
        public virtual DbSet<TblDiagnosticosIncapacidades> TblDiagnosticosIncapacidades { get; set; }
        public virtual DbSet<TblDiagnosticosNomenclaturas> TblDiagnosticosNomenclaturas { get; set; }
        public virtual DbSet<TblDivipola> TblDivipola { get; set; }
        public virtual DbSet<TblElementos> TblElementos { get; set; }
        public virtual DbSet<TblEmisores> TblEmisores { get; set; }
        public virtual DbSet<TblEmpleados> TblEmpleados { get; set; }
        public virtual DbSet<TblEmpleadosDetalles> TblEmpleadosDetalles { get; set; }
        public virtual DbSet<TblEmpresaArea> TblEmpresaArea { get; set; }
        public virtual DbSet<TblEmpresaControlEficacia> TblEmpresaControlEficacia { get; set; }
        public virtual DbSet<TblEmpresaControlFrecuencia> TblEmpresaControlFrecuencia { get; set; }
        public virtual DbSet<TblEmpresaControlHerramientas> TblEmpresaControlHerramientas { get; set; }
        public virtual DbSet<TblEmpresaControlProcedimientos> TblEmpresaControlProcedimientos { get; set; }
        public virtual DbSet<TblEmpresaControlResponsable> TblEmpresaControlResponsable { get; set; }
        public virtual DbSet<TblEmpresaEstandarDocGenSis> TblEmpresaEstandarDocGenSis { get; set; }
        public virtual DbSet<TblEmpresaEstandares> TblEmpresaEstandares { get; set; }
        public virtual DbSet<TblEmpresaEstructuraProcesos> TblEmpresaEstructuraProcesos { get; set; }
        public virtual DbSet<TblEmpresaGestora> TblEmpresaGestora { get; set; }
        public virtual DbSet<TblEmpresaJurisprudencias> TblEmpresaJurisprudencias { get; set; }
        public virtual DbSet<TblEmpresaParametros> TblEmpresaParametros { get; set; }
        public virtual DbSet<TblEmpresaPolitica> TblEmpresaPolitica { get; set; }
        public virtual DbSet<TblEmpresaPoliticaControlCambios> TblEmpresaPoliticaControlCambios { get; set; }
        public virtual DbSet<TblEmpresaProcesoRiesgos> TblEmpresaProcesoRiesgos { get; set; }
        public virtual DbSet<TblEmpresaProcesos> TblEmpresaProcesos { get; set; }
        public virtual DbSet<TblEmpresaRiesgoValoracion> TblEmpresaRiesgoValoracion { get; set; }
        public virtual DbSet<TblEmpresas> TblEmpresas { get; set; }
        public virtual DbSet<TblEmpresasArls> TblEmpresasArls { get; set; }
        public virtual DbSet<TblEmpresasCajasCompensacion> TblEmpresasCajasCompensacion { get; set; }
        public virtual DbSet<TblEmpresasCorredores> TblEmpresasCorredores { get; set; }
        public virtual DbSet<TblEmpresasPacientes> TblEmpresasPacientes { get; set; }
        public virtual DbSet<TblEmpresasTerceros> TblEmpresasTerceros { get; set; }
        public virtual DbSet<TblEmpresasVigencia> TblEmpresasVigencia { get; set; }
        public virtual DbSet<TblEntradasSalidas> TblEntradasSalidas { get; set; }
        public virtual DbSet<TblEps> TblEps { get; set; }
        public virtual DbSet<TblEstadoAfiliacion> TblEstadoAfiliacion { get; set; }
        public virtual DbSet<TblEstandarNumerales> TblEstandarNumerales { get; set; }
        public virtual DbSet<TblEstandarTipoPoliticas> TblEstandarTipoPoliticas { get; set; }
        public virtual DbSet<TblEventosCalendario> TblEventosCalendario { get; set; }
        public virtual DbSet<TblEventosCalendarioParticipantes> TblEventosCalendarioParticipantes { get; set; }
        public virtual DbSet<TblExtintoresTipo> TblExtintoresTipo { get; set; }
        public virtual DbSet<TblFormatos> TblFormatos { get; set; }
        public virtual DbSet<TblFormularios> TblFormularios { get; set; }
        public virtual DbSet<TblFormulariosRespuestas> TblFormulariosRespuestas { get; set; }
        public virtual DbSet<TblFormulariosRespuestasEncabezados> TblFormulariosRespuestasEncabezados { get; set; }
        public virtual DbSet<TblIdiomas> TblIdiomas { get; set; }
        public virtual DbSet<TblIndicadoresDetalle> TblIndicadoresDetalle { get; set; }
        public virtual DbSet<TblIndicadoresDetalleHistorico> TblIndicadoresDetalleHistorico { get; set; }
        public virtual DbSet<TblIndicadoresMatriz> TblIndicadoresMatriz { get; set; }
        public virtual DbSet<TblIndicadoresMatrizHistorico> TblIndicadoresMatrizHistorico { get; set; }
        public virtual DbSet<TblIndicadoresSeguimiento> TblIndicadoresSeguimiento { get; set; }
        public virtual DbSet<TblInspeccionExtintoresDetalle> TblInspeccionExtintoresDetalle { get; set; }
        public virtual DbSet<TblInspeccionExtintoresDetalleMtto> TblInspeccionExtintoresDetalleMtto { get; set; }
        public virtual DbSet<TblInspecciones> TblInspecciones { get; set; }
        public virtual DbSet<TblInspeccionesPrograma> TblInspeccionesPrograma { get; set; }
        public virtual DbSet<TblInstalacionElectricaAlumbrado> TblInstalacionElectricaAlumbrado { get; set; }
        public virtual DbSet<TblInstalacionElectricaCircuitos> TblInstalacionElectricaCircuitos { get; set; }
        public virtual DbSet<TblInstalacionElectricaInterruptores> TblInstalacionElectricaInterruptores { get; set; }
        public virtual DbSet<TblInstalacionElectricaTomas> TblInstalacionElectricaTomas { get; set; }
        public virtual DbSet<TblInventarioEmpresas> TblInventarioEmpresas { get; set; }
        public virtual DbSet<TblIps> TblIps { get; set; }
        public virtual DbSet<TblIpssEps> TblIpssEps { get; set; }
        public virtual DbSet<TblJurisprudencias> TblJurisprudencias { get; set; }
        public virtual DbSet<TblListaDetalle> TblListaDetalle { get; set; }
        public virtual DbSet<TblMapaProcesoPosiciones> TblMapaProcesoPosiciones { get; set; }
        public virtual DbSet<TblMedicamentos> TblMedicamentos { get; set; }
        public virtual DbSet<TblMedicamentosTemp> TblMedicamentosTemp { get; set; }
        public virtual DbSet<TblMenu> TblMenu { get; set; }
        public virtual DbSet<TblMenuPerfiles> TblMenuPerfiles { get; set; }
        public virtual DbSet<TblMultivalores> TblMultivalores { get; set; }
        public virtual DbSet<TblNotificacionesElectronicas> TblNotificacionesElectronicas { get; set; }
        public virtual DbSet<TblNotificacionesUsuarios> TblNotificacionesUsuarios { get; set; }
        public virtual DbSet<TblNumerales> TblNumerales { get; set; }
        public virtual DbSet<TblNumeralesProceso> TblNumeralesProceso { get; set; }
        public virtual DbSet<TblPacientes> TblPacientes { get; set; }
        public virtual DbSet<TblParametrosEmpresas> TblParametrosEmpresas { get; set; }
        public virtual DbSet<TblPartesCuerpo> TblPartesCuerpo { get; set; }
        public virtual DbSet<TblPeoresConsecuencias> TblPeoresConsecuencias { get; set; }
        public virtual DbSet<TblPerfilSocioDemoAfp> TblPerfilSocioDemoAfp { get; set; }
        public virtual DbSet<TblPerfilSocioDemoCargo> TblPerfilSocioDemoCargo { get; set; }
        public virtual DbSet<TblPerfilSocioDemoEdad> TblPerfilSocioDemoEdad { get; set; }
        public virtual DbSet<TblPerfilSocioDemoEps> TblPerfilSocioDemoEps { get; set; }
        public virtual DbSet<TblPerfilSocioDemoEstadoCivil> TblPerfilSocioDemoEstadoCivil { get; set; }
        public virtual DbSet<TblPerfilSocioDemoFormacionEduc> TblPerfilSocioDemoFormacionEduc { get; set; }
        public virtual DbSet<TblPerfilSocioDemoSucursal> TblPerfilSocioDemoSucursal { get; set; }
        public virtual DbSet<TblPerfilSocioDemoTipoVincul> TblPerfilSocioDemoTipoVincul { get; set; }
        public virtual DbSet<TblPerfilSocioDemografico> TblPerfilSocioDemografico { get; set; }
        public virtual DbSet<TblPerfiles> TblPerfiles { get; set; }
        public virtual DbSet<TblPhva> TblPhva { get; set; }
        public virtual DbSet<TblPlanAccion> TblPlanAccion { get; set; }
        public virtual DbSet<TblPlanAccionActividades> TblPlanAccionActividades { get; set; }
        public virtual DbSet<TblPlanAccionRazones> TblPlanAccionRazones { get; set; }
        public virtual DbSet<TblPlanAccionTareas> TblPlanAccionTareas { get; set; }
        public virtual DbSet<TblPlanCapacitacion> TblPlanCapacitacion { get; set; }
        public virtual DbSet<TblPlanCapacitacionAsistentes> TblPlanCapacitacionAsistentes { get; set; }
        public virtual DbSet<TblPlanCapacitacionSesiones> TblPlanCapacitacionSesiones { get; set; }
        public virtual DbSet<TblPosiblesRiesgos> TblPosiblesRiesgos { get; set; }
        public virtual DbSet<TblProcedimientos> TblProcedimientos { get; set; }
        public virtual DbSet<TblProcesos> TblProcesos { get; set; }
        public virtual DbSet<TblRecobroEstados> TblRecobroEstados { get; set; }
        public virtual DbSet<TblRecobroEstadosDocumentos> TblRecobroEstadosDocumentos { get; set; }
        public virtual DbSet<TblRecobroEstadosDocumentosIdiomas> TblRecobroEstadosDocumentosIdiomas { get; set; }
        public virtual DbSet<TblRecobroEstadosIdiomas> TblRecobroEstadosIdiomas { get; set; }
        public virtual DbSet<TblRecobros> TblRecobros { get; set; }
        public virtual DbSet<TblRecobrosDocumentos> TblRecobrosDocumentos { get; set; }
        public virtual DbSet<TblRecobrosDocumentosSoportes> TblRecobrosDocumentosSoportes { get; set; }
        public virtual DbSet<TblRecobrosDocumentosUsuarios> TblRecobrosDocumentosUsuarios { get; set; }
        public virtual DbSet<TblRecobrosDocumentosUsuariosDiagnosticos> TblRecobrosDocumentosUsuariosDiagnosticos { get; set; }
        public virtual DbSet<TblRecobrosDocumentosUsuariosDiagnosticosSoportes> TblRecobrosDocumentosUsuariosDiagnosticosSoportes { get; set; }
        public virtual DbSet<TblRecobrosDocumentosUsuariosSoportes> TblRecobrosDocumentosUsuariosSoportes { get; set; }
        public virtual DbSet<TblRecobrosSoportes> TblRecobrosSoportes { get; set; }
        public virtual DbSet<TblRecobrosUsuariosElementos> TblRecobrosUsuariosElementos { get; set; }
        public virtual DbSet<TblRecobrosUsuariosElementosSoportes> TblRecobrosUsuariosElementosSoportes { get; set; }
        public virtual DbSet<TblRecobrosUsuariosMedicamentos> TblRecobrosUsuariosMedicamentos { get; set; }
        public virtual DbSet<TblRecobrosUsuariosMedicamentosSoportes> TblRecobrosUsuariosMedicamentosSoportes { get; set; }
        public virtual DbSet<TblRecobrosUsuariosServiciosProcedimientos> TblRecobrosUsuariosServiciosProcedimientos { get; set; }
        public virtual DbSet<TblRecobrosUsuariosServiciosProcedimientosSoportes> TblRecobrosUsuariosServiciosProcedimientosSoportes { get; set; }
        public virtual DbSet<TblRecursos> TblRecursos { get; set; }
        public virtual DbSet<TblRegimenAfiliacion> TblRegimenAfiliacion { get; set; }
        public virtual DbSet<TblRhsi> TblRhsi { get; set; }
        public virtual DbSet<TblRhsiactividadEconomica> TblRhsiactividadEconomica { get; set; }
        public virtual DbSet<TblRhsiriesgos> TblRhsiriesgos { get; set; }
        public virtual DbSet<TblRiesgoAnalisis> TblRiesgoAnalisis { get; set; }
        public virtual DbSet<TblRiesgoCausas> TblRiesgoCausas { get; set; }
        public virtual DbSet<TblRiesgoControlValoraciones> TblRiesgoControlValoraciones { get; set; }
        public virtual DbSet<TblRiesgoControles> TblRiesgoControles { get; set; }
        public virtual DbSet<TblRiesgoEfectos> TblRiesgoEfectos { get; set; }
        public virtual DbSet<TblRiesgoIdentificacion> TblRiesgoIdentificacion { get; set; }
        public virtual DbSet<TblRiesgoResidual> TblRiesgoResidual { get; set; }
        public virtual DbSet<TblRiesgoResidualAcciones> TblRiesgoResidualAcciones { get; set; }
        public virtual DbSet<TblServiciosProcedimientos> TblServiciosProcedimientos { get; set; }
        public virtual DbSet<TblSoa> TblSoa { get; set; }
        public virtual DbSet<TblSoportes> TblSoportes { get; set; }
        public virtual DbSet<TblSoportes1> TblSoportes1 { get; set; }
        public virtual DbSet<TblSucursalRiesgo> TblSucursalRiesgo { get; set; }
        public virtual DbSet<TblSucursalesEmpresas> TblSucursalesEmpresas { get; set; }
        public virtual DbSet<TblTareaActividades> TblTareaActividades { get; set; }
        public virtual DbSet<TblTareas> TblTareas { get; set; }
        public virtual DbSet<TblTemplateNotificaciones> TblTemplateNotificaciones { get; set; }
        public virtual DbSet<TblTipoAfiliacion> TblTipoAfiliacion { get; set; }
        public virtual DbSet<TblTipoCie> TblTipoCie { get; set; }
        public virtual DbSet<TblTipoEmpresa> TblTipoEmpresa { get; set; }
        public virtual DbSet<TblTipoProceso> TblTipoProceso { get; set; }
        public virtual DbSet<TblTipoSociedadEmpresa> TblTipoSociedadEmpresa { get; set; }
        public virtual DbSet<TblTiposArchivo> TblTiposArchivo { get; set; }
        public virtual DbSet<TblTiposNotificaciones> TblTiposNotificaciones { get; set; }
        public virtual DbSet<TblTranscripciones> TblTranscripciones { get; set; }
        public virtual DbSet<TblUsuarios> TblUsuarios { get; set; }
        public virtual DbSet<TblUsuariosEmpresas> TblUsuariosEmpresas { get; set; }
        public virtual DbSet<TblUsuariosNotificaciones> TblUsuariosNotificaciones { get; set; }
        public virtual DbSet<TblUsuariosPerfiles> TblUsuariosPerfiles { get; set; }
        public virtual DbSet<TblVendedor> TblVendedor { get; set; }
        public virtual DbSet<UsuarioEPS> UsuarioEPSs { get; set; }
        public virtual DbSet<Entidad> Entidades { get; set; }
        public virtual DbSet<Auditoria> Auditoria { get; set; }
        public virtual DbSet<PacientesPorEmitir> PacientesPorEmitir { get; set; }
        public virtual DbSet<PronosticoConcepto> PronosticosConcepto { get; set; }
        public virtual DbSet<Correo> Correos { get; set; }
        public virtual DbSet<TextoReconocidoCarta> TextoReconocidoCartas { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<tblRethusIdentificationTypes> RethusIdentificationTypes { get; set; }
        public virtual DbSet<tblRethusData_Main> RethusData_Main { get; set; }
        public virtual DbSet<tblRethusData_Academic> RethusData_Academic { get; set; }
        public virtual DbSet<tblRethusData_Sanctions> RethusData_Sanctions { get; set; }
        public virtual DbSet<tblRethusData_SSO> RethusData_SSO { get; set; }

        // Unable to generate entity type for table 'Incapacidades.tblCIE10España'. Please see the warning messages.
        // Unable to generate entity type for table 'negocio.tblCargos_BKP'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.tblEmpresas_tmp'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Data Source=tcp:serverbrazil2.database.windows.net;Initial Catalog=dbProtektoV1;User ID=braziladminabernal;Password=RoojoS3rv3r1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<TblUsuarios>()
                .HasIndex(u => u.TEmail)
                .IsUnique();

            modelBuilder.Entity<UsuarioEntidad>()
                .HasIndex(u => new { u.EntidadId, u.UsuarioId })
                .IsUnique();

            modelBuilder.Entity<UsuarioEntidadPerfil>()
                .HasIndex(u => u.UsuarioEntidadId)
                .IsUnique();

            modelBuilder.Entity<Cliente>()
                .HasIndex(u => new { u.EntidadId, u.TipoId, u.NumeroId })
                .IsUnique();

            modelBuilder.Entity<Entidad>()
                .HasIndex(u => new { u.TipoId, u.NumeroId, u.NombreCompania })
                .IsUnique();

            /*modelBuilder.Entity<Entidad>()
                .HasOne(u => u.EntidadRelacion)
                .WithOne(u => u.EntidadRelacion)
                .HasForeignKey<Entidad>(u => u.EntidadRelacionId);*/

            /*modelBuilder.Entity<Subcuenta>()
                .HasIndex(u => u.Codigo)
                .IsUnique();*/
            //modelBuilder.Entity<Incapacidad>(entity =>
            //{
            //    entity.ToTable("Incapacidad", "Incapacidades");
            //});

            //modelBuilder.Entity<TipoSecuelas>(entity =>
            //{
            //    entity.ToTable("TipoSecuelas", "Conceptos");
            //});

            //modelBuilder.Entity<TerapeuticaPosibles>(entity =>
            //{
            //    entity.ToTable("TerapeuticaPosibles", "Conceptos");
            //});

            //modelBuilder.Entity<Remisiones>(entity =>
            //{
            //    entity.ToTable("Remisiones", "Conceptos");
            //});

            //modelBuilder.Entity<Pronosticos>(entity =>
            //{
            //    entity.ToTable("Pronosticos", "Conceptos");
            //});

            //modelBuilder.Entity<PlazoLargo>(entity =>
            //{
            //    entity.ToTable("PlazoLargo", "Conceptos");
            //});

            //modelBuilder.Entity<PlazoCorto>(entity =>
            //{
            //    entity.ToTable("PlazoCorto", "Conceptos");
            //});

            //modelBuilder.Entity<NotaRemisiones>(entity =>
            //{
            //    entity.ToTable("NotaRemisiones", "Conceptos");
            //});

            //modelBuilder.Entity<FinalidadTratamientos>(entity =>
            //{
            //    entity.ToTable("FinalidadTratamientos", "Conceptos");
            //});

            //modelBuilder.Entity<Etiologias>(entity =>
            //{
            //    entity.ToTable("Etiologias", "Conceptos");
            //});


            //modelBuilder.Entity<DescripcionSecuelas>(entity =>
            //{
            //    entity.ToTable("DescripcionSecuelas", "Conceptos");
            //});


            //modelBuilder.Entity<ConceptosMedicos>(entity =>
            //{
            //    entity.ToTable("ConceptosMedicos", "Conceptos");
            //});


            //modelBuilder.Entity<Conceptos>(entity =>
            //{
            //    entity.ToTable("Conceptos", "Conceptos");
            //});

            modelBuilder.Entity<UsuarioEPS>(entity =>
            {
                entity.ToTable("UsuarioEPS", "seguridad");
            });

            modelBuilder.Entity<PronosticoConcepto>(entity =>
            {
                entity.ToTable("PronosticosConcepto", "Conceptos");
            });

            modelBuilder.Entity<PacientesPorEmitir>(entity =>
            {
                entity.ToTable("PacientesPorEmitir", "Conceptos");
                entity.HasKey(e => e.Id);
                entity.HasOne(d => d.Paciente)
                    .WithMany(p => p.PacientesPorEmtitir)
                    .HasForeignKey(d => d.PacienteId)
                    .HasConstraintName("FK__Pacientes__idPac__5788D180");
            });

            modelBuilder.Entity<Auditoria>(entity =>
            {
                entity.ToTable("Auditoria", "seguridad");
            });

            modelBuilder.Entity<ConceptoRehabilitacion>(entity =>
            {
                entity.ToTable("ConceptoRehabilitacion", "Conceptos");
            });

            modelBuilder.Entity<Kustodya.ApplicationCore.Entities.Concepto.Diagnostico>(entity =>
            {
                entity.ToTable("Diagnosticos", "Conceptos");
            });
            modelBuilder.Entity<Kustodya.ApplicationCore.Entities.Concepto.Secuela>(entity =>
            {
                entity.ToTable("Secuelas", "Conceptos");
            });
            //modelBuilder.Entity<Afiliado>(entity =>
            //{
            //    entity.ToTable("Afiliado", "Incapacidades");
            //});

            modelBuilder.Entity<tblRethusTasks>(entity =>
            {
                entity.HasKey(e => e.iIDTask);
                entity.ToTable("tblRethusTasks", "Rethus");
                entity.Property(e => e.iIDTask).HasColumnName("iIDTask");
            });

            modelBuilder.Entity<tblRethusQuerys>(entity =>
            {
                entity.HasKey(e => e.iIDRethusQuerys);
                entity.ToTable("tblRethusQuerys", "Rethus");
                entity.Property(e => e.iIDRethusQuerys).HasColumnName("iIDRethusQuerys");
            });

            modelBuilder.Entity<tblRethusIdentificationTypes>(entity =>
            {
                entity.HasKey(e => e.iIDIdentificationType);
                entity.ToTable("tblRethusIdentificationTypes", "Rethus");
                entity.Property(e => e.iIDIdentificationType).HasColumnName("iIDIdentificationType");
            });

            modelBuilder.Entity<tblRethusData_Main>(entity =>
            {
                entity.HasKey(e => e.iIDMainData);
                entity.ToTable("tblRethusData_Main", "Rethus");
                entity.Property(e => e.iIDMainData).HasColumnName("iIDMainData");
            });

            modelBuilder.Entity<tblRethusData_Academic>(entity =>
            {
                entity.HasKey(e => e.iIDAcademicData);
                entity.ToTable("tblRethusData_Academic", "Rethus");
                entity.Property(e => e.iIDAcademicData).HasColumnName("iIDAcademicData");
            });

            modelBuilder.Entity<tblRethusData_Sanctions>(entity =>
            {
                entity.HasKey(e => e.iIDSanctionData);
                entity.ToTable("tblRethusData_Sanctions", "Rethus");
                entity.Property(e => e.iIDSanctionData).HasColumnName("iIDSanctionData");
            });

            modelBuilder.Entity<tblRethusData_SSO>(entity =>
            {
                entity.HasKey(e => e.iIDSSOData);
                entity.ToTable("tblRethusData_SSO", "Rethus");
                entity.Property(e => e.iIDSSOData).HasColumnName("iIDSSOData");
            });

            modelBuilder.Entity<TblAccidentesTrabajo>(entity =>
            {
                entity.HasKey(e => e.IIdaccidenteTrabajo);

                entity.ToTable("tblAccidentesTrabajo", "negocio");

                entity.Property(e => e.IIdaccidenteTrabajo).HasColumnName("iIDAccidenteTrabajo");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.BInvolucraMedioAmb).HasColumnName("bInvolucraMedioAmb");

                entity.Property(e => e.BInvolucraPropiedad).HasColumnName("bInvolucraPropiedad");

                entity.Property(e => e.BInvolucraTrabajador).HasColumnName("bInvolucraTrabajador");

                entity.Property(e => e.BTrabajadorElementoProtec).HasColumnName("bTrabajadorElementoProtec");

                entity.Property(e => e.BTrabajadorEntrenamCargo).HasColumnName("bTrabajadorEntrenamCargo");

                entity.Property(e => e.BTrabajadorLaborHabitual).HasColumnName("bTrabajadorLaborHabitual");

                entity.Property(e => e.BTrabajadorRecibAtencMed).HasColumnName("bTrabajadorRecibAtencMed");

                entity.Property(e => e.BTrabajadorinduccionSaludOcup).HasColumnName("bTrabajadorinduccionSaludOcup");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaEvento)
                    .HasColumnName("dtFechaEvento")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaInvestigacion)
                    .HasColumnName("dtFechaInvestigacion")
                    .HasColumnType("date");

                entity.Property(e => e.IIdactividadEconomica).HasColumnName("iIDActividadEconomica");

                entity.Property(e => e.IIdcargoTrab).HasColumnName("iIDCargoTrab");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IIdepstrabajador).HasColumnName("iIDEPSTrabajador");

                entity.Property(e => e.IIdipsantendio).HasColumnName("iIDIPSAntendio");

                entity.Property(e => e.IIdtipoEvento).HasColumnName("iIDTipoEvento");

                entity.Property(e => e.IIdtipoIdentificacion).HasColumnName("iIDTipoIdentificacion");

                entity.Property(e => e.IIdtipoVinculaciontrab).HasColumnName("iIDTipoVinculaciontrab");

                entity.Property(e => e.IIdtipoVinculador).HasColumnName("iIDTipoVinculador");

                entity.Property(e => e.IIdtrabajador).HasColumnName("iIDTrabajador");

                entity.Property(e => e.IIdubicacionSucEmpleador).HasColumnName("iIDUbicacionSucEmpleador");

                entity.Property(e => e.IIdubicacionTrabajador).HasColumnName("iIDUbicacionTrabajador");

                entity.Property(e => e.IJornada).HasColumnName("iJornada");

                entity.Property(e => e.IOcupacionHabDias).HasColumnName("iOcupacionHabDias");

                entity.Property(e => e.IOcupacionHabMeses).HasColumnName("iOcupacionHabMeses");

                entity.Property(e => e.ISalario).HasColumnName("iSalario");

                entity.Property(e => e.ITiempoTranscurrAntesEvento).HasColumnName("iTiempoTranscurrAntesEvento");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TCodigoOcupacionHabTrab)
                    .IsRequired()
                    .HasColumnName("tCodigoOcupacionHabTrab")
                    .HasMaxLength(200);

                entity.Property(e => e.TDescripcionSuceso)
                    .IsRequired()
                    .HasColumnName("tDescripcionSuceso")
                    .HasMaxLength(4000);

                entity.Property(e => e.TJornadaHabitualTrab)
                    .IsRequired()
                    .HasColumnName("tJornadaHabitualTrab")
                    .HasMaxLength(200);

                entity.Property(e => e.TNombreEmpresa)
                    .IsRequired()
                    .HasColumnName("tNombreEmpresa")
                    .HasMaxLength(100);

                entity.Property(e => e.TNumIdentiTrab)
                    .IsRequired()
                    .HasColumnName("tNumIdentiTrab")
                    .HasMaxLength(100);

                entity.Property(e => e.TNumeroIdentificacion)
                    .IsRequired()
                    .HasColumnName("tNumeroIdentificacion")
                    .HasMaxLength(100);

                entity.Property(e => e.TObservacionesInvestigacion)
                    .HasColumnName("tObservacionesInvestigacion")
                    .HasMaxLength(1000);

                entity.Property(e => e.TOcupacionHabitualTrab)
                    .IsRequired()
                    .HasColumnName("tOcupacionHabitualTrab")
                    .HasMaxLength(100);

                entity.Property(e => e.TSucursalEmpleador)
                    .IsRequired()
                    .HasColumnName("tSucursalEmpleador")
                    .HasMaxLength(200);

                entity.Property(e => e.TSucursalTrabajador)
                    .IsRequired()
                    .HasColumnName("tSucursalTrabajador")
                    .HasMaxLength(100);

                entity.Property(e => e.TSucursalTrabajadorDireccion)
                    .IsRequired()
                    .HasColumnName("tSucursalTrabajadorDireccion")
                    .HasMaxLength(500);

                entity.Property(e => e.TSucursalTrabajadorFax)
                    .IsRequired()
                    .HasColumnName("tSucursalTrabajadorFax")
                    .HasMaxLength(50);

                entity.Property(e => e.TSucursalTrabajadorTelefono)
                    .IsRequired()
                    .HasColumnName("tSucursalTrabajadorTelefono")
                    .HasMaxLength(50);

                entity.Property(e => e.TSucursalTrabajadorZona)
                    .IsRequired()
                    .HasColumnName("tSucursalTrabajadorZona")
                    .HasMaxLength(50);

                entity.Property(e => e.TTipoIdentificacionTrab)
                    .IsRequired()
                    .HasColumnName("tTipoIdentificacionTrab")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IIdactividadEconomicaNavigation)
                    .WithMany(p => p.TblAccidentesTrabajoIIdactividadEconomicaNavigation)
                    .HasForeignKey(d => d.IIdactividadEconomica)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAccidentesTrabajo_tblMultivalores");

                entity.HasOne(d => d.IIdcargoTrabNavigation)
                    .WithMany(p => p.TblAccidentesTrabajo)
                    .HasForeignKey(d => d.IIdcargoTrab)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAccidentesTrabajo_tblCargos");

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblAccidentesTrabajo)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAccidentesTrabajo_tblEmpresas");

                entity.HasOne(d => d.IIdepstrabajadorNavigation)
                    .WithMany(p => p.TblAccidentesTrabajo)
                    .HasForeignKey(d => d.IIdepstrabajador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAccidentesTrabajo_tblEPS");

                entity.HasOne(d => d.IIdtipoEventoNavigation)
                    .WithMany(p => p.TblAccidentesTrabajoIIdtipoEventoNavigation)
                    .HasForeignKey(d => d.IIdtipoEvento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAccidentesTrabajo_tblMultivalores6");

                entity.HasOne(d => d.IIdtipoIdentificacionNavigation)
                    .WithMany(p => p.TblAccidentesTrabajoIIdtipoIdentificacionNavigation)
                    .HasForeignKey(d => d.IIdtipoIdentificacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAccidentesTrabajo_tblMultivalores1");

                entity.HasOne(d => d.IIdtipoVinculaciontrabNavigation)
                    .WithMany(p => p.TblAccidentesTrabajoIIdtipoVinculaciontrabNavigation)
                    .HasForeignKey(d => d.IIdtipoVinculaciontrab)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAccidentesTrabajo_tblMultivalores4");

                entity.HasOne(d => d.IIdtipoVinculadorNavigation)
                    .WithMany(p => p.TblAccidentesTrabajoIIdtipoVinculadorNavigation)
                    .HasForeignKey(d => d.IIdtipoVinculador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAccidentesTrabajo_tblMultivalores2");

                entity.HasOne(d => d.IIdtrabajadorNavigation)
                    .WithMany(p => p.TblAccidentesTrabajo)
                    .HasForeignKey(d => d.IIdtrabajador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAccidentesTrabajo_tblAccidentesTrabajo");

                entity.HasOne(d => d.IIdubicacionSucEmpleadorNavigation)
                    .WithMany(p => p.TblAccidentesTrabajoIIdubicacionSucEmpleadorNavigation)
                    .HasForeignKey(d => d.IIdubicacionSucEmpleador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAccidentesTrabajo_tblDivipola");

                entity.HasOne(d => d.IIdubicacionTrabajadorNavigation)
                    .WithMany(p => p.TblAccidentesTrabajoIIdubicacionTrabajadorNavigation)
                    .HasForeignKey(d => d.IIdubicacionTrabajador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAccidentesTrabajo_tblMultivalores3");

                entity.HasOne(d => d.IJornadaNavigation)
                    .WithMany(p => p.TblAccidentesTrabajoIJornadaNavigation)
                    .HasForeignKey(d => d.IJornada)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAccidentesTrabajo_tblMultivalores5");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblAccidentesTrabajo)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAccidentesTrabajo_tblUsuarios");
            });

            modelBuilder.Entity<TblActaMensual>(entity =>
            {
                entity.HasKey(e => e.IIdactaMensual);

                entity.ToTable("tblActaMensual", "negocio");

                entity.Property(e => e.IIdactaMensual).HasColumnName("iIDActaMensual");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.BAprobacionActaAnt).HasColumnName("bAprobacionActaAnt");

                entity.Property(e => e.BVerificacionQuorum).HasColumnName("bVerificacionQuorum");

                entity.Property(e => e.DtFechaActa)
                    .HasColumnName("dtFechaActa")
                    .HasColumnType("date");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaProximaReunion)
                    .HasColumnName("dtFechaProximaReunion")
                    .HasColumnType("date");

                entity.Property(e => e.DtHoraFin).HasColumnName("dtHoraFin");

                entity.Property(e => e.DtHoraInicio).HasColumnName("dtHoraInicio");

                entity.Property(e => e.IIdclaseActa).HasColumnName("iIDClaseActa");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IIdubicacion).HasColumnName("iIDUbicacion");

                entity.Property(e => e.INumeroActa).HasColumnName("iNumeroActa");

                entity.Property(e => e.ITipoReunion).HasColumnName("iTipoReunion");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TObjetivos)
                    .IsRequired()
                    .HasColumnName("tObjetivos")
                    .HasMaxLength(4000);

                entity.Property(e => e.TTemas)
                    .IsRequired()
                    .HasColumnName("tTemas")
                    .HasMaxLength(4000);

                entity.HasOne(d => d.IIdclaseActaNavigation)
                    .WithMany(p => p.TblActaMensualIIdclaseActaNavigation)
                    .HasForeignKey(d => d.IIdclaseActa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblActaMensual_tblMultivalores");

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblActaMensual)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblActaMensual_tblEmpresas");

                entity.HasOne(d => d.IIdubicacionNavigation)
                    .WithMany(p => p.TblActaMensual)
                    .HasForeignKey(d => d.IIdubicacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblActaMensual_tblDivipola");

                entity.HasOne(d => d.ITipoReunionNavigation)
                    .WithMany(p => p.TblActaMensualITipoReunionNavigation)
                    .HasForeignKey(d => d.ITipoReunion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblActaMensual_tblMultivalores1");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblActaMensual)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblActaMensual_tblUsuarios");
            });

            modelBuilder.Entity<TblActaMensualCompromisoActividades>(entity =>
            {
                entity.HasKey(e => e.IIdactaMensualCompromisoActividad);

                entity.ToTable("tblActaMensualCompromisoActividades", "negocio");

                entity.Property(e => e.IIdactaMensualCompromisoActividad).HasColumnName("iIDActaMensualCompromisoActividad");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdactaMensualCompromiso).HasColumnName("iIDActaMensualCompromiso");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TDescripcion)
                    .IsRequired()
                    .HasColumnName("tDescripcion")
                    .HasMaxLength(1000);

                entity.HasOne(d => d.IIdactaMensualCompromisoNavigation)
                    .WithMany(p => p.TblActaMensualCompromisoActividades)
                    .HasForeignKey(d => d.IIdactaMensualCompromiso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblActaMensualCompromisoActividades_tblActaMensualCompromisos");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblActaMensualCompromisoActividades)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblActaMensualCompromisoActividades_tblUsuarios");
            });

            modelBuilder.Entity<TblActaMensualCompromisos>(entity =>
            {
                entity.HasKey(e => e.IIdactaMensualCompromisos);

                entity.ToTable("tblActaMensualCompromisos", "negocio");

                entity.Property(e => e.IIdactaMensualCompromisos).HasColumnName("iIDActaMensualCompromisos");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCompromiso)
                    .HasColumnName("dtFechaCompromiso")
                    .HasColumnType("date");

                entity.Property(e => e.DtFechaConfirmacion)
                    .HasColumnName("dtFechaConfirmacion")
                    .HasColumnType("date");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaInicio)
                    .HasColumnName("dtFechaInicio")
                    .HasColumnType("date");

                entity.Property(e => e.IActaConfirmacion).HasColumnName("iActaConfirmacion");

                entity.Property(e => e.IEstado).HasColumnName("iEstado");

                entity.Property(e => e.IIdactaMensual).HasColumnName("iIDActaMensual");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IUsuarioAsignado).HasColumnName("iUsuarioAsignado");

                entity.Property(e => e.IUsuarioConfirmacion).HasColumnName("iUsuarioConfirmacion");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TDescripcion)
                    .IsRequired()
                    .HasColumnName("tDescripcion")
                    .HasMaxLength(500);

                entity.HasOne(d => d.IActaConfirmacionNavigation)
                    .WithMany(p => p.TblActaMensualCompromisos)
                    .HasForeignKey(d => d.IActaConfirmacion)
                    .HasConstraintName("FK_tblActaMensualCompromisos_tblActaMensual1");

                entity.HasOne(d => d.IEstadoNavigation)
                    .WithMany(p => p.TblActaMensualCompromisos)
                    .HasForeignKey(d => d.IEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblActaMensualCompromisos_tblActaMensual");

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblActaMensualCompromisos)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblActaMensualCompromisos_tblEmpresas");

                entity.HasOne(d => d.IUsuarioAsignadoNavigation)
                    .WithMany(p => p.TblActaMensualCompromisosIUsuarioAsignadoNavigation)
                    .HasForeignKey(d => d.IUsuarioAsignado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblActaMensualCompromisos_tblUsuarios");

                entity.HasOne(d => d.IUsuarioConfirmacionNavigation)
                    .WithMany(p => p.TblActaMensualCompromisosIUsuarioConfirmacionNavigation)
                    .HasForeignKey(d => d.IUsuarioConfirmacion)
                    .HasConstraintName("FK_tblActaMensualCompromisos_tblUsuarios1");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblActaMensualCompromisosIUsuarioCreacionNavigation)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblActaMensualCompromisos_tblUsuarios2");
            });

            modelBuilder.Entity<TblActaMensualParticipantes>(entity =>
            {
                entity.HasKey(e => e.IIdactaMensualParti);

                entity.ToTable("tblActaMensualParticipantes", "negocio");

                entity.Property(e => e.IIdactaMensualParti).HasColumnName("iIDActaMensualParti");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdactaMensual).HasColumnName("iIDActaMensual");

                entity.Property(e => e.IIdempleado).HasColumnName("iIDEmpleado");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.HasOne(d => d.IIdactaMensualNavigation)
                    .WithMany(p => p.TblActaMensualParticipantes)
                    .HasForeignKey(d => d.IIdactaMensual)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblActaMensualParticipantes_tblActaMensual");

                entity.HasOne(d => d.IIdempleadoNavigation)
                    .WithMany(p => p.TblActaMensualParticipantes)
                    .HasForeignKey(d => d.IIdempleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblActaMensualParticipantes_tblEmpleados");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblActaMensualParticipantes)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblActaMensualParticipantes_tblUsuarios");
            });

            modelBuilder.Entity<TblActas>(entity =>
            {
                entity.HasKey(e => e.IIdacta);

                entity.ToTable("tblActas", "negocio");

                entity.Property(e => e.IIdacta).HasColumnName("iIDActa");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaActa)
                    .HasColumnName("dtFechaActa")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdclaseActa).HasColumnName("iIDClaseActa");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IIdtipoActa).HasColumnName("iIDTipoActa");

                entity.Property(e => e.INumeroActa).HasColumnName("iNumeroActa");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TContenido)
                    .IsRequired()
                    .HasColumnName("tContenido")
                    .HasColumnType("ntext");

                entity.HasOne(d => d.IIdclaseActaNavigation)
                    .WithMany(p => p.TblActasIIdclaseActaNavigation)
                    .HasForeignKey(d => d.IIdclaseActa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblActas_tblMultivalores");

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblActas)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblActas_tblEmpresas");

                entity.HasOne(d => d.IIdtipoActaNavigation)
                    .WithMany(p => p.TblActasIIdtipoActaNavigation)
                    .HasForeignKey(d => d.IIdtipoActa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblActas_tblMultivalores1");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblActas)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblActas_tblUsuarios");
            });

            modelBuilder.Entity<TblActividadEconomica>(entity =>
            {
                entity.HasKey(e => e.IId)
                    .HasName("PK__tblActiv__DC512D721E5F7FD0");

                entity.ToTable("tblActividadEconomica");

                entity.HasIndex(e => e.TCiiu)
                    .HasName("UQ_tCIIU")
                    .IsUnique();

                entity.Property(e => e.IId).HasColumnName("iID");

                entity.Property(e => e.TCiiu)
                    .IsRequired()
                    .HasColumnName("tCIIU")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TNombreActividad)
                    .IsRequired()
                    .HasColumnName("tNombreActividad")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblAfp>(entity =>
            {
                entity.HasKey(e => e.IIdafp);

                entity.ToTable("tblAFP", "negocio");

                entity.Property(e => e.IIdafp).HasColumnName("iIDAFP");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdtipoIdentificacion).HasColumnName("iIDTipoIdentificacion");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.TCodigoExterno)
                    .HasColumnName("tCodigoExterno")
                    .HasMaxLength(10);

                entity.Property(e => e.TDigitoVerificacion).HasColumnName("tDigitoVerificacion");

                entity.Property(e => e.TNombre)
                    .IsRequired()
                    .HasColumnName("tNombre")
                    .HasMaxLength(200);

                entity.Property(e => e.TNumeroIdentificacion)
                    .HasColumnName("tNumeroIdentificacion")
                    .HasMaxLength(200);

                entity.HasOne(d => d.IIdtipoIdentificacionNavigation)
                    .WithMany(p => p.TblAfp)
                    .HasForeignKey(d => d.IIdtipoIdentificacion)
                    .HasConstraintName("FK_tblAFP_tblAFP");

                entity.HasOne(d => d.IIdusuarioCreacionNavigation)
                    .WithMany(p => p.TblAfp)
                    .HasForeignKey(d => d.IIdusuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAFP_tblUsuarios");
            });

            modelBuilder.Entity<TblArls>(entity =>
            {
                entity.HasKey(e => e.IIdarl);

                entity.ToTable("tblARLs", "negocio");

                entity.Property(e => e.IIdarl).HasColumnName("iIDARL");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdtipoIdentificacion).HasColumnName("iIDTipoIdentificacion");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.TCodigoExterno)
                    .HasColumnName("tCodigoExterno")
                    .HasMaxLength(5);

                entity.Property(e => e.TDigitoVerificacion).HasColumnName("tDigitoVerificacion");

                entity.Property(e => e.TNombre)
                    .IsRequired()
                    .HasColumnName("tNombre")
                    .HasMaxLength(200);

                entity.Property(e => e.TNumeroIdentificacion)
                    .HasColumnName("tNumeroIdentificacion")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IIdtipoIdentificacionNavigation)
                    .WithMany(p => p.TblArls)
                    .HasForeignKey(d => d.IIdtipoIdentificacion)
                    .HasConstraintName("FK_tblARLs_tblMultivalores");

                entity.HasOne(d => d.IIdusuarioCreacionNavigation)
                    .WithMany(p => p.TblArls)
                    .HasForeignKey(d => d.IIdusuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblARLs_tblUsuarios");
            });

            modelBuilder.Entity<TblAsignacion>(entity =>
            {
                entity.HasKey(e => e.IIdasignacion);

                entity.ToTable("tblAsignacion", "proceso");

                entity.Property(e => e.IIdasignacion).HasColumnName("iIDAsignacion");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdcargo).HasColumnName("iIDCargo");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IIdproceso).HasColumnName("iIDProceso");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.HasOne(d => d.IIdcargoNavigation)
                    .WithMany(p => p.TblAsignacion)
                    .HasForeignKey(d => d.IIdcargo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAsignacion_tblCargos");

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblAsignacion)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAsignacion_tblEmpresas");

                entity.HasOne(d => d.IIdprocesoNavigation)
                    .WithMany(p => p.TblAsignacion)
                    .HasForeignKey(d => d.IIdproceso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAsignacion_tblEmpresaProcesos");

                entity.HasOne(d => d.IIdusuarioCreacionNavigation)
                    .WithMany(p => p.TblAsignacion)
                    .HasForeignKey(d => d.IIdusuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAsignacion_tblUsuarios");
            });

            modelBuilder.Entity<TblAtanalisisCausas>(entity =>
            {
                entity.HasKey(e => e.IIdanalisisCausa);

                entity.ToTable("tblATAnalisisCausas", "negocio");

                entity.Property(e => e.IIdanalisisCausa).HasColumnName("iIDAnalisisCausa");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdaccidenteTrabajo).HasColumnName("iIDAccidenteTrabajo");

                entity.Property(e => e.IIdsubtablaAnalisisCausa).HasColumnName("iIDSubtablaAnalisisCausa");

                entity.Property(e => e.IIdsubtablaTipoAnalisisCausa).HasColumnName("iIDSubtablaTipoAnalisisCausa");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TValorAnalisisCausa)
                    .IsRequired()
                    .HasColumnName("tValorAnalisisCausa")
                    .HasMaxLength(100);

                entity.Property(e => e.TValorTipoAnalisisCausa)
                    .IsRequired()
                    .HasColumnName("tValorTipoAnalisisCausa")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IIdaccidenteTrabajoNavigation)
                    .WithMany(p => p.TblAtanalisisCausas)
                    .HasForeignKey(d => d.IIdaccidenteTrabajo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblATAnalisisCausas_tblAccidentesTrabajo");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblAtanalisisCausas)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblATAnalisisCausas_tblUsuarios");
            });

            modelBuilder.Entity<TblAtequiposProteccion>(entity =>
            {
                entity.HasKey(e => e.IIdatequipoProteccion);

                entity.ToTable("tblATEquiposProteccion", "negocio");

                entity.Property(e => e.IIdatequipoProteccion).HasColumnName("iIDATEquipoProteccion");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdacidenteTrabajo).HasColumnName("iIDAcidenteTrabajo");

                entity.Property(e => e.IIdequipoProteccion).HasColumnName("iIDEquipoProteccion");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.HasOne(d => d.IIdacidenteTrabajoNavigation)
                    .WithMany(p => p.TblAtequiposProteccion)
                    .HasForeignKey(d => d.IIdacidenteTrabajo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblATEquiposProteccion_tblAccidentesTrabajo");

                entity.HasOne(d => d.IIdequipoProteccionNavigation)
                    .WithMany(p => p.TblAtequiposProteccion)
                    .HasForeignKey(d => d.IIdequipoProteccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblATEquiposProteccion_tblMultivalores");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblAtequiposProteccion)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblATEquiposProteccion_tblUsuarios");
            });

            modelBuilder.Entity<TblAtinformacionSuceso>(entity =>
            {
                entity.HasKey(e => e.IIdinformacionSuceso);

                entity.ToTable("tblATInformacionSuceso", "negocio");

                entity.Property(e => e.IIdinformacionSuceso).HasColumnName("iIDInformacionSuceso");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.ICosto).HasColumnName("iCosto");

                entity.Property(e => e.IIdaccidenteTrabajo).HasColumnName("iIDAccidenteTrabajo");

                entity.Property(e => e.IIdsubtablaTipoDano).HasColumnName("iIDSubtablaTipoDano");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TDescripcion)
                    .IsRequired()
                    .HasColumnName("tDescripcion")
                    .HasMaxLength(200);

                entity.Property(e => e.TEntidadNotificada)
                    .IsRequired()
                    .HasColumnName("tEntidadNotificada")
                    .HasMaxLength(100);

                entity.Property(e => e.TValorTipoDano)
                    .IsRequired()
                    .HasColumnName("tValorTipoDano")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IIdaccidenteTrabajoNavigation)
                    .WithMany(p => p.TblAtinformacionSuceso)
                    .HasForeignKey(d => d.IIdaccidenteTrabajo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblATInformacionSuceso_tblAccidentesTrabajo");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblAtinformacionSuceso)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblATInformacionSuceso_tblUsuarios");
            });

            modelBuilder.Entity<TblAtmedidasAccionesCorrectivas>(entity =>
            {
                entity.HasKey(e => e.IIdmedidaAccionCorrectiva)
                    .HasName("PK_tblMedidasAccionesCorrectivas");

                entity.ToTable("tblATMedidasAccionesCorrectivas", "negocio");

                entity.Property(e => e.IIdmedidaAccionCorrectiva).HasColumnName("iIDMedidaAccionCorrectiva");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaEjecucion)
                    .HasColumnName("dtFechaEjecucion")
                    .HasColumnType("date");

                entity.Property(e => e.DtFechaSeguimiento)
                    .HasColumnName("dtFechaSeguimiento")
                    .HasColumnType("date");

                entity.Property(e => e.IIdaccidenteTrabajo).HasColumnName("iIDAccidenteTrabajo");

                entity.Property(e => e.IIdsubtablaTipoMedida).HasColumnName("iIDSubtablaTipoMedida");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TEjecucion)
                    .IsRequired()
                    .HasColumnName("tEjecucion")
                    .HasMaxLength(200);

                entity.Property(e => e.TImplementacion)
                    .IsRequired()
                    .HasColumnName("tImplementacion")
                    .HasMaxLength(200);

                entity.Property(e => e.TMedidasPlanteadas)
                    .IsRequired()
                    .HasColumnName("tMedidasPlanteadas")
                    .HasMaxLength(200);

                entity.Property(e => e.TValorTipoMedida)
                    .IsRequired()
                    .HasColumnName("tValorTipoMedida")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IIdaccidenteTrabajoNavigation)
                    .WithMany(p => p.TblAtmedidasAccionesCorrectivas)
                    .HasForeignKey(d => d.IIdaccidenteTrabajo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblATMedidasAccionesCorrectivas_tblAccidentesTrabajo");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblAtmedidasAccionesCorrectivas)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblATMedidasAccionesCorrectivas_tblUsuarios");
            });

            modelBuilder.Entity<TblAtmedidasSeguridad>(entity =>
            {
                entity.HasKey(e => e.IIdatmedidaSeguridad);

                entity.ToTable("tblATMedidasSeguridad", "negocio");

                entity.Property(e => e.IIdatmedidaSeguridad).HasColumnName("iIDATMedidaSeguridad");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdaccidenteTrabajo).HasColumnName("iIDAccidenteTrabajo");

                entity.Property(e => e.IIdsubtablaTipoControl).HasColumnName("iIDSubtablaTipoControl");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TMedidaSeguridad)
                    .IsRequired()
                    .HasColumnName("tMedidaSeguridad")
                    .HasMaxLength(300);

                entity.Property(e => e.TValorTipoControl)
                    .IsRequired()
                    .HasColumnName("tValorTipoControl")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IIdaccidenteTrabajoNavigation)
                    .WithMany(p => p.TblAtmedidasSeguridad)
                    .HasForeignKey(d => d.IIdaccidenteTrabajo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblATMedidasSeguridad_tblAccidentesTrabajo");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblAtmedidasSeguridad)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblATMedidasSeguridad_tblUsuarios");
            });

            modelBuilder.Entity<TblAtpartesAfectadas>(entity =>
            {
                entity.HasKey(e => e.IIdatparteAfectada);

                entity.ToTable("tblATPartesAfectadas", "negocio");

                entity.Property(e => e.IIdatparteAfectada).HasColumnName("iIDATParteAfectada");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdaccidenteTrabajo).HasColumnName("iIDAccidenteTrabajo");

                entity.Property(e => e.IIdparteCuerpo).HasColumnName("iIDParteCuerpo");

                entity.Property(e => e.IIdsubtablaAgenteLesion).HasColumnName("iIDSubtablaAgenteLesion");

                entity.Property(e => e.IIdsubtablaCostadoCuerpo).HasColumnName("iIDSubtablaCostadoCuerpo");

                entity.Property(e => e.IIdsubtablaMecanismoLesion).HasColumnName("iIDSubtablaMecanismoLesion");

                entity.Property(e => e.IIdsubtablaTipoLesion).HasColumnName("iIDSubtablaTipoLesion");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TIdvalorCostadoCuerpo)
                    .HasColumnName("tIDValorCostadoCuerpo")
                    .HasMaxLength(100);

                entity.Property(e => e.TValorAgenteLesion)
                    .IsRequired()
                    .HasColumnName("tValorAgenteLesion")
                    .HasMaxLength(100);

                entity.Property(e => e.TValorMecanismoLesion)
                    .IsRequired()
                    .HasColumnName("tValorMecanismoLesion")
                    .HasMaxLength(100);

                entity.Property(e => e.TValorTipoLesion)
                    .IsRequired()
                    .HasColumnName("tValorTipoLesion")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IIdaccidenteTrabajoNavigation)
                    .WithMany(p => p.TblAtpartesAfectadas)
                    .HasForeignKey(d => d.IIdaccidenteTrabajo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblATPartesAfectadas_tblAccidentesTrabajo");

                entity.HasOne(d => d.IIdparteCuerpoNavigation)
                    .WithMany(p => p.TblAtpartesAfectadas)
                    .HasForeignKey(d => d.IIdparteCuerpo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblATPartesAfectadas_tblPartesCuerpo");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblAtpartesAfectadas)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblATPartesAfectadas_tblUsuarios");
            });

            modelBuilder.Entity<TblAtpersonas>(entity =>
            {
                entity.HasKey(e => e.IIdpersona);

                entity.ToTable("tblATPersonas", "negocio");

                entity.Property(e => e.IIdpersona).HasColumnName("iIDPersona");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.BLicenciaSo).HasColumnName("bLicenciaSO");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdaccidenteTrabajo).HasColumnName("iIDAccidenteTrabajo");

                entity.Property(e => e.IIdsubtablaTipoPersona).HasColumnName("iIDSubtablaTipoPersona");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TCargo)
                    .IsRequired()
                    .HasColumnName("tCargo")
                    .HasMaxLength(150);

                entity.Property(e => e.TNombre)
                    .IsRequired()
                    .HasColumnName("tNombre")
                    .HasMaxLength(150);

                entity.Property(e => e.TNumeroLicSo)
                    .HasColumnName("tNumeroLicSO")
                    .HasMaxLength(50);

                entity.Property(e => e.TValorTipoPersona)
                    .IsRequired()
                    .HasColumnName("tValorTipoPersona")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IIdaccidenteTrabajoNavigation)
                    .WithMany(p => p.TblAtpersonas)
                    .HasForeignKey(d => d.IIdaccidenteTrabajo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblATPersonas_tblAccidentesTrabajo");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblAtpersonas)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblATPersonas_tblUsuarios");
            });

            modelBuilder.Entity<TblAuditoria>(entity =>
            {
                entity.HasKey(e => e.IIdauditoria);

                entity.ToTable("tblAuditoria", "auditoria");

                entity.Property(e => e.IIdauditoria).HasColumnName("iIDAuditoria");

                entity.Property(e => e.DtFechaInsercion)
                    .HasColumnName("dtFechaInsercion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.TDescripcion)
                    .IsRequired()
                    .HasColumnName("tDescripcion")
                    .HasMaxLength(1000);

                entity.Property(e => e.TFormulario)
                    .IsRequired()
                    .HasColumnName("tFormulario")
                    .HasMaxLength(500);

                entity.Property(e => e.TUsuarioInsercion)
                    .IsRequired()
                    .HasColumnName("tUsuarioInsercion")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblAusentismoHorasHombreTrabajadas>(entity =>
            {
                entity.HasKey(e => e.IIdhorasHombreTrabajadas);

                entity.ToTable("tblAusentismoHorasHombreTrabajadas", "negocio");

                entity.Property(e => e.IIdhorasHombreTrabajadas).HasColumnName("iIDHorasHombreTrabajadas");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.INumDiasTrabajados).HasColumnName("iNumDiasTrabajados");

                entity.Property(e => e.INumEmpleados).HasColumnName("iNumEmpleados");

                entity.Property(e => e.INumHorasTrabajadas).HasColumnName("iNumHorasTrabajadas");

                entity.Property(e => e.INumTotalHorasAusentismo).HasColumnName("iNumTotalHorasAusentismo");

                entity.Property(e => e.INumTotalHorasExtras).HasColumnName("iNumTotalHorasExtras");

                entity.Property(e => e.INumTrabajadores).HasColumnName("iNumTrabajadores");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.IVigencia).HasColumnName("iVigencia");

                entity.Property(e => e.TMes)
                    .IsRequired()
                    .HasColumnName("tMes")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblAusentismoHorasHombreTrabajadas)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAusentismoHorasHombreTrabajadas_tblEmpresas");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblAusentismoHorasHombreTrabajadas)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAusentismoHorasHombreTrabajadas_tblUsuarios");

                entity.HasOne(d => d.IVigenciaNavigation)
                    .WithMany(p => p.TblAusentismoHorasHombreTrabajadas)
                    .HasForeignKey(d => d.IVigencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAusentismoHorasHombreTrabajadas_tblEmpresasVigencia");
            });

            modelBuilder.Entity<TblAusentismoIndicadoresInfraestructura>(entity =>
            {
                entity.HasKey(e => e.IIdindicadorInfraestructura)
                    .HasName("PK_tblIndicadoresInfraestructura");

                entity.ToTable("tblAusentismoIndicadoresInfraestructura", "negocio");

                entity.Property(e => e.IIdindicadorInfraestructura).HasColumnName("iIDIndicadorInfraestructura");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.INumHorasDisponibles).HasColumnName("iNumHorasDisponibles");

                entity.Property(e => e.IRecursosFinancieros).HasColumnName("iRecursosFinancieros");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.IVigencia).HasColumnName("iVigencia");

                entity.Property(e => e.TMes)
                    .IsRequired()
                    .HasColumnName("tMes")
                    .HasMaxLength(50);

                entity.Property(e => e.TObservaciones)
                    .HasColumnName("tObservaciones")
                    .HasMaxLength(500);

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblAusentismoIndicadoresInfraestructura)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblIndicadoresInfraestructura_tblEmpresas");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblAusentismoIndicadoresInfraestructura)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblIndicadoresInfraestructura_tblUsuarios");

                entity.HasOne(d => d.IVigenciaNavigation)
                    .WithMany(p => p.TblAusentismoIndicadoresInfraestructura)
                    .HasForeignKey(d => d.IVigencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblIndicadoresInfraestructura_tblEmpresasVigencia");
            });

            modelBuilder.Entity<TblAusentismoIndicadoresProceso>(entity =>
            {
                entity.HasKey(e => e.IIdindicadorProceso);

                entity.ToTable("tblAusentismoIndicadoresProceso", "negocio");

                entity.Property(e => e.IIdindicadorProceso).HasColumnName("iIDIndicadorProceso");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.INumUsuariosChequeoMedico).HasColumnName("iNumUsuariosChequeoMedico");

                entity.Property(e => e.INumUsuariosEquipoProtPersonal).HasColumnName("iNumUsuariosEquipoProtPersonal");

                entity.Property(e => e.INumUsuariosPrimAuxilios).HasColumnName("iNumUsuariosPrimAuxilios");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.IVigencia).HasColumnName("iVigencia");

                entity.Property(e => e.TMes)
                    .IsRequired()
                    .HasColumnName("tMes")
                    .HasMaxLength(50);

                entity.Property(e => e.TObservaciones)
                    .HasColumnName("tObservaciones")
                    .HasMaxLength(500);

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblAusentismoIndicadoresProceso)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAusentismoIndicadoresProceso_tblEmpresas");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblAusentismoIndicadoresProceso)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAusentismoIndicadoresProceso_tblUsuarios");

                entity.HasOne(d => d.IVigenciaNavigation)
                    .WithMany(p => p.TblAusentismoIndicadoresProceso)
                    .HasForeignKey(d => d.IVigencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAusentismoIndicadoresProceso_tblEmpresasVigencia");
            });

            modelBuilder.Entity<TblAusentismoIndiceAccidentalidad>(entity =>
            {
                entity.HasKey(e => e.IIdindiceAccidentalidad);

                entity.ToTable("tblAusentismoIndiceAccidentalidad", "negocio");

                entity.Property(e => e.IIdindiceAccidentalidad).HasColumnName("iIDIndiceAccidentalidad");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.INumCasos).HasColumnName("iNumCasos");

                entity.Property(e => e.INumDiasCargados).HasColumnName("iNumDiasCargados");

                entity.Property(e => e.INumDiasPerdidos).HasColumnName("iNumDiasPerdidos");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.IVigencia).HasColumnName("iVigencia");

                entity.Property(e => e.TMes)
                    .IsRequired()
                    .HasColumnName("tMes")
                    .HasMaxLength(50);

                entity.Property(e => e.TObservaciones)
                    .HasColumnName("tObservaciones")
                    .HasMaxLength(500);

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblAusentismoIndiceAccidentalidad)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAusentismoIndiceAccidentalidad_tblEmpresas");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblAusentismoIndiceAccidentalidad)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAusentismoIndiceAccidentalidad_tblUsuarios");

                entity.HasOne(d => d.IVigenciaNavigation)
                    .WithMany(p => p.TblAusentismoIndiceAccidentalidad)
                    .HasForeignKey(d => d.IVigencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAusentismoIndiceAccidentalidad_tblEmpresasVigencia");
            });

            modelBuilder.Entity<TblAusentismoIndiceEnfermedadProfesional>(entity =>
            {
                entity.HasKey(e => e.IIdindiceEnfProfesional);

                entity.ToTable("tblAusentismoIndiceEnfermedadProfesional", "negocio");

                entity.Property(e => e.IIdindiceEnfProfesional).HasColumnName("iIDIndiceEnfProfesional");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.INumCasos).HasColumnName("iNumCasos");

                entity.Property(e => e.INumDias).HasColumnName("iNumDias");

                entity.Property(e => e.INumDiasCargados).HasColumnName("iNumDiasCargados");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.IVigencia).HasColumnName("iVigencia");

                entity.Property(e => e.TMes)
                    .IsRequired()
                    .HasColumnName("tMes")
                    .HasMaxLength(50);

                entity.Property(e => e.TObservaciones)
                    .HasColumnName("tObservaciones")
                    .HasMaxLength(500);

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblAusentismoIndiceEnfermedadProfesional)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAusentismoIndiceEnfermedadProfesional_tblEmpresas");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblAusentismoIndiceEnfermedadProfesional)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAusentismoIndiceEnfermedadProfesional_tblUsuarios");

                entity.HasOne(d => d.IVigenciaNavigation)
                    .WithMany(p => p.TblAusentismoIndiceEnfermedadProfesional)
                    .HasForeignKey(d => d.IVigencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAusentismoIndiceEnfermedadProfesional_tblEmpresasVigencia");
            });

            modelBuilder.Entity<TblAusentismoPrevalenciaIncidencia>(entity =>
            {
                entity.HasKey(e => e.IIdprevalenciaIncidenciaAusentismo);

                entity.ToTable("tblAusentismoPrevalenciaIncidencia", "negocio");

                entity.Property(e => e.IIdprevalenciaIncidenciaAusentismo).HasColumnName("iIDPrevalenciaIncidenciaAusentismo");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.INumCasosPrevalencia).HasColumnName("iNumCasosPrevalencia");

                entity.Property(e => e.INumEpisodiosNuevos).HasColumnName("iNumEpisodiosNuevos");

                entity.Property(e => e.INumHorasPerdidas).HasColumnName("iNumHorasPerdidas");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.IVigencia).HasColumnName("iVigencia");

                entity.Property(e => e.TMes)
                    .IsRequired()
                    .HasColumnName("tMes")
                    .HasMaxLength(50);

                entity.Property(e => e.TObservaciones)
                    .HasColumnName("tObservaciones")
                    .HasMaxLength(500);

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblAusentismoPrevalenciaIncidencia)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAusentismoPrevalenciaIncidencia_tblEmpresas");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblAusentismoPrevalenciaIncidencia)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAusentismoPrevalenciaIncidencia_tblUsuarios");

                entity.HasOne(d => d.IVigenciaNavigation)
                    .WithMany(p => p.TblAusentismoPrevalenciaIncidencia)
                    .HasForeignKey(d => d.IVigencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAusentismoPrevalenciaIncidencia_tblEmpresasVigencia");
            });

            modelBuilder.Entity<TblAyudas>(entity =>
            {
                entity.HasKey(e => e.IIdayuda);

                entity.ToTable("tblAyudas", "negocio");

                entity.Property(e => e.IIdayuda).HasColumnName("iIDAyuda");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TFuncionalidad)
                    .IsRequired()
                    .HasColumnName("tFuncionalidad")
                    .HasColumnType("ntext");

                entity.Property(e => e.TObjetivo)
                    .IsRequired()
                    .HasColumnName("tObjetivo")
                    .HasColumnType("ntext");

                entity.Property(e => e.TUrl)
                    .IsRequired()
                    .HasColumnName("tUrl")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblAyudas)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAyudas_tblUsuarios");
            });

            modelBuilder.Entity<TblBlobs>(entity =>
            {
                entity.ToTable("tblBlobs", "files");

                entity.Property(e => e.Id)
                    .HasMaxLength(225)
                    .ValueGeneratedNever();

                entity.Property(e => e.Creator).HasMaxLength(100);

                entity.Property(e => e.MimeType).HasMaxLength(50);

                entity.Property(e => e.OriginalName).HasMaxLength(200);

                entity.Property(e => e.Year).HasColumnType("date");

                entity.HasOne(d => d.FileTypeNavigation)
                    .WithMany(p => p.TblBlobs)
                    .HasForeignKey(d => d.FileType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblBlobs_tblTiposArchivo");
            });

            modelBuilder.Entity<TblCajasCompensacion>(entity =>
            {
                entity.HasKey(e => e.IIdcajaCompensacion);

                entity.ToTable("tblCajasCompensacion", "negocio");

                entity.Property(e => e.IIdcajaCompensacion).HasColumnName("iIDCajaCompensacion");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdtipoIdentificacion).HasColumnName("iIDTipoIdentificacion");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.TCodigoExterno)
                    .HasColumnName("tCodigoExterno")
                    .HasMaxLength(10);

                entity.Property(e => e.TDigitoVerificacion).HasColumnName("tDigitoVerificacion");

                entity.Property(e => e.TNombre)
                    .IsRequired()
                    .HasColumnName("tNombre")
                    .HasMaxLength(200);

                entity.Property(e => e.TNumeroIdentificacion)
                    .HasColumnName("tNumeroIdentificacion")
                    .HasMaxLength(200);

                entity.HasOne(d => d.IIdtipoIdentificacionNavigation)
                    .WithMany(p => p.TblCajasCompensacion)
                    .HasForeignKey(d => d.IIdtipoIdentificacion)
                    .HasConstraintName("FK_tblCajasCompensacion_tblCajasCompensacion");

                entity.HasOne(d => d.IIdusuarioCreacionNavigation)
                    .WithMany(p => p.TblCajasCompensacion)
                    .HasForeignKey(d => d.IIdusuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCajasCompensacion_tblUsuarios");
            });

            modelBuilder.Entity<TblCargoPerfil>(entity =>
            {
                entity.HasKey(e => e.IIdcargoPerfil);

                entity.ToTable("tblCargoPerfil", "negocio");

                entity.Property(e => e.IIdcargoPerfil).HasColumnName("iIDCargoPerfil");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.BEstudioSeguridad).HasColumnName("bEstudioSeguridad");

                entity.Property(e => e.BVisitaDomiciliaria).HasColumnName("bVisitaDomiciliaria");

                entity.Property(e => e.DtFechaActualizacion)
                    .HasColumnName("dtFechaActualizacion")
                    .HasColumnType("date");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IEdadDesde).HasColumnName("iEdadDesde");

                entity.Property(e => e.IEdadHasta).HasColumnName("iEdadHasta");

                entity.Property(e => e.IExperienciaAños).HasColumnName("iExperienciaAños");

                entity.Property(e => e.IGenero).HasColumnName("iGenero");

                entity.Property(e => e.IIdarea).HasColumnName("iIDArea");

                entity.Property(e => e.IIdcargo).HasColumnName("iIDCargo");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.HasOne(d => d.IIdareaNavigation)
                    .WithMany(p => p.TblCargoPerfil)
                    .HasForeignKey(d => d.IIdarea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCargoPerfil_tblEmpresaArea");

                entity.HasOne(d => d.IIdcargoNavigation)
                    .WithMany(p => p.TblCargoPerfil)
                    .HasForeignKey(d => d.IIdcargo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCargoPerfil_tblCargos");

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblCargoPerfil)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCargoPerfil_tblEmpresas");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblCargoPerfil)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCargoPerfil_tblUsuarios");
            });

            modelBuilder.Entity<TblCargoPerfilCompetenciasCorporativas>(entity =>
            {
                entity.HasKey(e => e.IIdperfilCargoCompetenciasCorp);

                entity.ToTable("tblCargoPerfilCompetenciasCorporativas", "negocio");

                entity.Property(e => e.IIdperfilCargoCompetenciasCorp).HasColumnName("iIDPerfilCargoCompetenciasCorp");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.ICompetenciaCorporativa).HasColumnName("iCompetenciaCorporativa");

                entity.Property(e => e.IIdperfilCargo).HasColumnName("iIDPerfilCargo");

                entity.Property(e => e.INivelRequerido).HasColumnName("iNivelRequerido");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TObservaciones)
                    .IsRequired()
                    .HasColumnName("tObservaciones")
                    .HasMaxLength(500);

                entity.HasOne(d => d.ICompetenciaCorporativaNavigation)
                    .WithMany(p => p.TblCargoPerfilCompetenciasCorporativasICompetenciaCorporativaNavigation)
                    .HasForeignKey(d => d.ICompetenciaCorporativa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCargoPerfilCompetenciasCorporativas_tblMultivalores");

                entity.HasOne(d => d.IIdperfilCargoNavigation)
                    .WithMany(p => p.TblCargoPerfilCompetenciasCorporativas)
                    .HasForeignKey(d => d.IIdperfilCargo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCargoPerfilCompetenciasCorporativas_tblCargoPerfil");

                entity.HasOne(d => d.INivelRequeridoNavigation)
                    .WithMany(p => p.TblCargoPerfilCompetenciasCorporativasINivelRequeridoNavigation)
                    .HasForeignKey(d => d.INivelRequerido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCargoPerfilCompetenciasCorporativas_tblMultivalores1");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblCargoPerfilCompetenciasCorporativas)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCargoPerfilCompetenciasCorporativas_tblUsuarios");
            });

            modelBuilder.Entity<TblCargoPerfilCompetenciasFuncionales>(entity =>
            {
                entity.HasKey(e => e.IIdcargoPerfilCompetenciasFunc);

                entity.ToTable("tblCargoPerfilCompetenciasFuncionales", "negocio");

                entity.Property(e => e.IIdcargoPerfilCompetenciasFunc).HasColumnName("iIDCargoPerfilCompetenciasFunc");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.ICompetenciaFuncional).HasColumnName("iCompetenciaFuncional");

                entity.Property(e => e.IIdcargoPerfil).HasColumnName("iIDCargoPerfil");

                entity.Property(e => e.INivelRequerido).HasColumnName("iNivelRequerido");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TObservaciones)
                    .IsRequired()
                    .HasColumnName("tObservaciones")
                    .HasMaxLength(500);

                entity.HasOne(d => d.ICompetenciaFuncionalNavigation)
                    .WithMany(p => p.TblCargoPerfilCompetenciasFuncionalesICompetenciaFuncionalNavigation)
                    .HasForeignKey(d => d.ICompetenciaFuncional)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCargoPerfilCompetenciasFuncionales_tblMultivalores");

                entity.HasOne(d => d.IIdcargoPerfilNavigation)
                    .WithMany(p => p.TblCargoPerfilCompetenciasFuncionales)
                    .HasForeignKey(d => d.IIdcargoPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCargoPerfilCompetenciasFuncionales_tblCargoPerfil");

                entity.HasOne(d => d.INivelRequeridoNavigation)
                    .WithMany(p => p.TblCargoPerfilCompetenciasFuncionalesINivelRequeridoNavigation)
                    .HasForeignKey(d => d.INivelRequerido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCargoPerfilCompetenciasFuncionales_tblMultivalores1");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblCargoPerfilCompetenciasFuncionales)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCargoPerfilCompetenciasFuncionales_tblUsuarios");
            });

            modelBuilder.Entity<TblCargoPerfilFuncionesAmbientales>(entity =>
            {
                entity.HasKey(e => e.IIdcargoPerfilFuncionAmbi);

                entity.ToTable("tblCargoPerfilFuncionesAmbientales", "negocio");

                entity.Property(e => e.IIdcargoPerfilFuncionAmbi).HasColumnName("iIDCargoPerfilFuncionAmbi");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IFuncionAmbiental).HasColumnName("iFuncionAmbiental");

                entity.Property(e => e.IIdcargoPerfil).HasColumnName("iIDCargoPerfil");

                entity.Property(e => e.IPeriodicidad).HasColumnName("iPeriodicidad");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.HasOne(d => d.IFuncionAmbientalNavigation)
                    .WithMany(p => p.TblCargoPerfilFuncionesAmbientalesIFuncionAmbientalNavigation)
                    .HasForeignKey(d => d.IFuncionAmbiental)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCargoPerfilFuncionesAmbientales_tblMultivalores");

                entity.HasOne(d => d.IIdcargoPerfilNavigation)
                    .WithMany(p => p.TblCargoPerfilFuncionesAmbientales)
                    .HasForeignKey(d => d.IIdcargoPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCargoPerfilFuncionesAmbientales_tblCargoPerfil");

                entity.HasOne(d => d.IPeriodicidadNavigation)
                    .WithMany(p => p.TblCargoPerfilFuncionesAmbientalesIPeriodicidadNavigation)
                    .HasForeignKey(d => d.IPeriodicidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCargoPerfilFuncionesAmbientales_tblMultivalores1");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblCargoPerfilFuncionesAmbientales)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCargoPerfilFuncionesAmbientales_tblUsuarios");
            });

            modelBuilder.Entity<TblCargoPerfilFuncionesSst>(entity =>
            {
                entity.HasKey(e => e.IIdcargoPerfilFuncionesSst);

                entity.ToTable("tblCargoPerfilFuncionesSST", "negocio");

                entity.Property(e => e.IIdcargoPerfilFuncionesSst).HasColumnName("iIDCargoPerfilFuncionesSST");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdcargoPerfil).HasColumnName("iIDCargoPerfil");

                entity.Property(e => e.IPeriodicidad).HasColumnName("iPeriodicidad");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TFuncionSst)
                    .IsRequired()
                    .HasColumnName("tFuncionSST")
                    .HasMaxLength(500);

                entity.HasOne(d => d.IIdcargoPerfilNavigation)
                    .WithMany(p => p.TblCargoPerfilFuncionesSst)
                    .HasForeignKey(d => d.IIdcargoPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCargoPerfilFuncionesSST_tblCargoPerfil");

                entity.HasOne(d => d.IPeriodicidadNavigation)
                    .WithMany(p => p.TblCargoPerfilFuncionesSst)
                    .HasForeignKey(d => d.IPeriodicidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCargoPerfilFuncionesSST_tblMultivalores1");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblCargoPerfilFuncionesSst)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCargoPerfilFuncionesSST_tblUsuarios");
            });

            modelBuilder.Entity<TblCargoPerfilIdiomas>(entity =>
            {
                entity.HasKey(e => e.IIdcargoPerfilIdiomas);

                entity.ToTable("tblCargoPerfilIdiomas", "negocio");

                entity.Property(e => e.IIdcargoPerfilIdiomas).HasColumnName("iIDCargoPerfilIdiomas");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdcargoPerfil).HasColumnName("iIDCargoPerfil");

                entity.Property(e => e.IIdioma).HasColumnName("iIdioma");

                entity.Property(e => e.INivelConversacion).HasColumnName("iNivelConversacion");

                entity.Property(e => e.INivelEscritura).HasColumnName("iNivelEscritura");

                entity.Property(e => e.INivelLectura).HasColumnName("iNivelLectura");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.HasOne(d => d.IIdcargoPerfilNavigation)
                    .WithMany(p => p.TblCargoPerfilIdiomas)
                    .HasForeignKey(d => d.IIdcargoPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCargoPerfilIdiomas_tblCargoPerfil");

                entity.HasOne(d => d.IIdiomaNavigation)
                    .WithMany(p => p.TblCargoPerfilIdiomasIIdiomaNavigation)
                    .HasForeignKey(d => d.IIdioma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCargoPerfilIdiomas_tblMultivalores");

                entity.HasOne(d => d.INivelConversacionNavigation)
                    .WithMany(p => p.TblCargoPerfilIdiomasINivelConversacionNavigation)
                    .HasForeignKey(d => d.INivelConversacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCargoPerfilIdiomas_tblMultivalores3");

                entity.HasOne(d => d.INivelEscrituraNavigation)
                    .WithMany(p => p.TblCargoPerfilIdiomasINivelEscrituraNavigation)
                    .HasForeignKey(d => d.INivelEscritura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCargoPerfilIdiomas_tblMultivalores2");

                entity.HasOne(d => d.INivelLecturaNavigation)
                    .WithMany(p => p.TblCargoPerfilIdiomasINivelLecturaNavigation)
                    .HasForeignKey(d => d.INivelLectura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCargoPerfilIdiomas_tblMultivalores1");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblCargoPerfilIdiomas)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCargoPerfilIdiomas_tblUsuarios");
            });

            modelBuilder.Entity<TblCargoPerfilNivelAcademico>(entity =>
            {
                entity.HasKey(e => e.IIdcargoPerfilNivAcad);

                entity.ToTable("tblCargoPerfilNivelAcademico", "negocio");

                entity.Property(e => e.IIdcargoPerfilNivAcad).HasColumnName("iIDCargoPerfilNivAcad");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.ICarrera).HasColumnName("iCarrera");

                entity.Property(e => e.IIdcargoPerfil).HasColumnName("iIDCargoPerfil");

                entity.Property(e => e.IIdnivelAcademico).HasColumnName("iIDNivelAcademico");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.HasOne(d => d.IIdcargoPerfilNavigation)
                    .WithMany(p => p.TblCargoPerfilNivelAcademico)
                    .HasForeignKey(d => d.IIdcargoPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCargoPerfilNivelAcademico_tblCargoPerfil");

                entity.HasOne(d => d.IIdnivelAcademicoNavigation)
                    .WithMany(p => p.TblCargoPerfilNivelAcademico)
                    .HasForeignKey(d => d.IIdnivelAcademico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCargoPerfilNivelAcademico_tblMultivalores");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblCargoPerfilNivelAcademico)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCargoPerfilNivelAcademico_tblUsuarios");
            });

            modelBuilder.Entity<TblCargoPerfilNivelAutoridad>(entity =>
            {
                entity.HasKey(e => e.IIdcargoPerfilNivelAutoridad);

                entity.ToTable("tblCargoPerfilNivelAutoridad", "negocio");

                entity.Property(e => e.IIdcargoPerfilNivelAutoridad).HasColumnName("iIDCargoPerfilNivelAutoridad");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdcargoPerfil).HasColumnName("iIDCargoPerfil");

                entity.Property(e => e.INivelAutoridad).HasColumnName("iNivelAutoridad");

                entity.Property(e => e.IRendicionCuentas).HasColumnName("iRendicionCuentas");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.HasOne(d => d.IIdcargoPerfilNavigation)
                    .WithMany(p => p.TblCargoPerfilNivelAutoridad)
                    .HasForeignKey(d => d.IIdcargoPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCargoPerfilNivelAutoridad_tblCargoPerfil");

                entity.HasOne(d => d.INivelAutoridadNavigation)
                    .WithMany(p => p.TblCargoPerfilNivelAutoridad)
                    .HasForeignKey(d => d.INivelAutoridad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCargoPerfilNivelAutoridad_tblMultivalores");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblCargoPerfilNivelAutoridad)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCargoPerfilNivelAutoridad_tblUsuarios");
            });

            modelBuilder.Entity<TblCargoPerfilObjetivos>(entity =>
            {
                entity.HasKey(e => e.IIdcargoPerfilObj);

                entity.ToTable("tblCargoPerfilObjetivos", "negocio");

                entity.Property(e => e.IIdcargoPerfilObj).HasColumnName("iIDCargoPerfilObj");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdcargoPerfil).HasColumnName("iIDCargoPerfil");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TObjetivoCargo)
                    .IsRequired()
                    .HasColumnName("tObjetivoCargo")
                    .HasMaxLength(500);

                entity.HasOne(d => d.IIdcargoPerfilNavigation)
                    .WithMany(p => p.TblCargoPerfilObjetivos)
                    .HasForeignKey(d => d.IIdcargoPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCargoPerfilObjetivos_tblCargoPerfil");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblCargoPerfilObjetivos)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCargoPerfilObjetivos_tblUsuarios");
            });

            modelBuilder.Entity<TblCargoPerfilResponsabilidadSst>(entity =>
            {
                entity.HasKey(e => e.IIdcargoPerfilResponSst);

                entity.ToTable("tblCargoPerfilResponsabilidadSST", "negocio");

                entity.Property(e => e.IIdcargoPerfilResponSst).HasColumnName("iIDCargoPerfilResponSST");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdcargoPerfil).HasColumnName("iIDCargoPerfil");

                entity.Property(e => e.IPeriodicidad).HasColumnName("iPeriodicidad");

                entity.Property(e => e.IResponsabilidad).HasColumnName("iResponsabilidad");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.HasOne(d => d.IIdcargoPerfilNavigation)
                    .WithMany(p => p.TblCargoPerfilResponsabilidadSst)
                    .HasForeignKey(d => d.IIdcargoPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCargoPerfilResponsabilidadSST_tblCargoPerfil");

                entity.HasOne(d => d.IPeriodicidadNavigation)
                    .WithMany(p => p.TblCargoPerfilResponsabilidadSstIPeriodicidadNavigation)
                    .HasForeignKey(d => d.IPeriodicidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCargoPerfilResponsabilidadSST_tblMultivalores1");

                entity.HasOne(d => d.IResponsabilidadNavigation)
                    .WithMany(p => p.TblCargoPerfilResponsabilidadSstIResponsabilidadNavigation)
                    .HasForeignKey(d => d.IResponsabilidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCargoPerfilResponsabilidadSST_tblMultivalores");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblCargoPerfilResponsabilidadSst)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCargoPerfilResponsabilidadSST_tblUsuarios");
            });

            modelBuilder.Entity<TblCargoPerfilResponsabilidades>(entity =>
            {
                entity.HasKey(e => e.IIdcargoPerfilResponsabilidades);

                entity.ToTable("tblCargoPerfilResponsabilidades", "negocio");

                entity.Property(e => e.IIdcargoPerfilResponsabilidades).HasColumnName("iIDCargoPerfilResponsabilidades");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.BResponsabilidad).HasColumnName("bResponsabilidad");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdcargoPerfil).HasColumnName("iIDCargoPerfil");

                entity.Property(e => e.IResponsabilidad).HasColumnName("iResponsabilidad");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TAclaracion)
                    .IsRequired()
                    .HasColumnName("tAclaracion")
                    .HasMaxLength(500);

                entity.HasOne(d => d.IIdcargoPerfilNavigation)
                    .WithMany(p => p.TblCargoPerfilResponsabilidades)
                    .HasForeignKey(d => d.IIdcargoPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCargoPerfilResponsabilidades_tblCargoPerfil");

                entity.HasOne(d => d.IResponsabilidadNavigation)
                    .WithMany(p => p.TblCargoPerfilResponsabilidades)
                    .HasForeignKey(d => d.IResponsabilidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCargoPerfilResponsabilidades_tblMultivalores");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblCargoPerfilResponsabilidades)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCargoPerfilResponsabilidades_tblUsuarios");
            });

            modelBuilder.Entity<TblCargos>(entity =>
            {
                entity.HasKey(e => e.IIdcargo);

                entity.ToTable("tblCargos", "negocio");

                entity.Property(e => e.IIdcargo).HasColumnName("iIDCargo");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.BRepresentanteLegal).HasColumnName("bRepresentanteLegal");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtUsuarioModificacion)
                    .HasColumnName("dtUsuarioModificacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IIdjefe).HasColumnName("iIDJefe");

                entity.Property(e => e.IIdusuarioCreador).HasColumnName("iIDUsuarioCreador");

                entity.Property(e => e.IIdusuarioModificacion).HasColumnName("iIDUsuarioModificacion");

                entity.Property(e => e.TDescripcion)
                    .IsRequired()
                    .HasColumnName("tDescripcion")
                    .HasMaxLength(500);

                entity.Property(e => e.TNombreCargo)
                    .IsRequired()
                    .HasColumnName("tNombreCargo")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblCargos)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCargos_tblEmpresas");

                entity.HasOne(d => d.IIdusuarioCreadorNavigation)
                    .WithMany(p => p.TblCargosIIdusuarioCreadorNavigation)
                    .HasForeignKey(d => d.IIdusuarioCreador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCargos_tblUsuarios");

                entity.HasOne(d => d.IIdusuarioModificacionNavigation)
                    .WithMany(p => p.TblCargosIIdusuarioModificacionNavigation)
                    .HasForeignKey(d => d.IIdusuarioModificacion)
                    .HasConstraintName("FK_tblCargos_tblUsuarios1");
            });

            modelBuilder.Entity<TblCie>(entity =>
            {
                entity.HasKey(e => e.IdCie);

                entity.ToTable("tblCIE");

                entity.Property(e => e.IdCie)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Actualizacion).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Clave)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LimiteInferiorEscala)
                    .HasColumnName("Limite_Inferior_Escala")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.LimiteInferiorTiempo)
                    .HasColumnName("Limite_Inferior_Tiempo")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.LimiteSuperiorEscala)
                    .HasColumnName("Limite_Superior_Escala")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.LimiteSuperiorTiempo)
                    .HasColumnName("Limite_Superior_Tiempo")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Lista1).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Lista2).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Lista3).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Lista4).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ListaBecker).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ListaCpu)
                    .HasColumnName("ListaCPU")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ListaCsemm)
                    .HasColumnName("ListaCSEMM")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ListaGbd)
                    .HasColumnName("ListaGBD")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ListaOps)
                    .HasColumnName("ListaOPS")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Modificacion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NoDefuncion).HasColumnName("No_Defuncion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.OpcionA).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.OpcionB).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.OpcionC).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Sexo).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Lista1Navigation)
                    .WithMany(p => p.TblCieLista1Navigation)
                    .HasForeignKey(d => d.Lista1)
                    .HasConstraintName("FK_tblCIE_tblListaDetalle");

                entity.HasOne(d => d.Lista2Navigation)
                    .WithMany(p => p.TblCieLista2Navigation)
                    .HasForeignKey(d => d.Lista2)
                    .HasConstraintName("FK_tblCIE_tblListaDetalle1");

                entity.HasOne(d => d.Lista3Navigation)
                    .WithMany(p => p.TblCieLista3Navigation)
                    .HasForeignKey(d => d.Lista3)
                    .HasConstraintName("FK_tblCIE_tblListaDetalle2");

                entity.HasOne(d => d.Lista4Navigation)
                    .WithMany(p => p.TblCieLista4Navigation)
                    .HasForeignKey(d => d.Lista4)
                    .HasConstraintName("FK_tblCIE_tblListaDetalle3");

                entity.HasOne(d => d.ListaBeckerNavigation)
                    .WithMany(p => p.TblCieListaBeckerNavigation)
                    .HasForeignKey(d => d.ListaBecker)
                    .HasConstraintName("FK_tblCIE_tblListaDetalle5");

                entity.HasOne(d => d.ListaCpuNavigation)
                    .WithMany(p => p.TblCieListaCpuNavigation)
                    .HasForeignKey(d => d.ListaCpu)
                    .HasConstraintName("FK_tblCIE_tblListaDetalle7");

                entity.HasOne(d => d.ListaCsemmNavigation)
                    .WithMany(p => p.TblCieListaCsemmNavigation)
                    .HasForeignKey(d => d.ListaCsemm)
                    .HasConstraintName("FK_tblCIE_tblListaDetalle8");

                entity.HasOne(d => d.ListaGbdNavigation)
                    .WithMany(p => p.TblCieListaGbdNavigation)
                    .HasForeignKey(d => d.ListaGbd)
                    .HasConstraintName("FK_tblCIE_tblListaDetalle4");

                entity.HasOne(d => d.ListaOpsNavigation)
                    .WithMany(p => p.TblCieListaOpsNavigation)
                    .HasForeignKey(d => d.ListaOps)
                    .HasConstraintName("FK_tblCIE_tblListaDetalle6");
            });

            modelBuilder.Entity<TblCie10>(entity =>
            {
                entity.HasKey(e => e.IIdcie10);

                entity.ToTable("tblCIE10", "Incapacidades");

                entity.Property(e => e.IIdcie10).HasColumnName("iIDCIE10");

                entity.Property(e => e.IDiasMaxAcumulados).HasColumnName("iDiasMaxAcumulados");

                entity.Property(e => e.IDiasMaxConsulta).HasColumnName("iDiasMaxConsulta");

                entity.Property(e => e.IIdsexo).HasColumnName("iIDSexo");

                entity.Property(e => e.IIdtipoCie).HasColumnName("iIDTipoCie");

                entity.Property(e => e.TCapitulo)
                    .IsRequired()
                    .HasColumnName("tCapitulo")
                    .HasMaxLength(50);

                entity.Property(e => e.TCaracter)
                    .IsRequired()
                    .HasColumnName("tCaracter")
                    .HasMaxLength(50);

                entity.Property(e => e.TCategoria)
                    .IsRequired()
                    .HasColumnName("tCategoria")
                    .HasMaxLength(50);

                entity.Property(e => e.TCie)
                    .IsRequired()
                    .HasColumnName("tCIE")
                    .HasMaxLength(50);

                entity.Property(e => e.TCie10)
                    .IsRequired()
                    .HasColumnName("tCIE10")
                    .HasMaxLength(50);

                entity.Property(e => e.TDescripcion)
                    .IsRequired()
                    .HasColumnName("tDescripcion")
                    .HasMaxLength(500);

                entity.Property(e => e.TTituloCapitulo)
                    .IsRequired()
                    .HasColumnName("tTituloCapitulo")
                    .HasMaxLength(500);

                entity.HasOne(d => d.IIdsexoNavigation)
                    .WithMany(p => p.TblCie10)
                    .HasForeignKey(d => d.IIdsexo)
                    .HasConstraintName("FK_tblCIE10_tblMultivalores");

                entity.HasOne(d => d.IIdtipoCieNavigation)
                    .WithMany(p => p.TblCie10)
                    .HasForeignKey(d => d.IIdtipoCie)
                    .HasConstraintName("FK_tblCIE10_tblTipoCIE");
            });

            modelBuilder.Entity<TblCie10DiagnosticoIncapacidad>(entity =>
            {
                entity.HasKey(e => e.IIdcie10DiagnosticoIncapacidad);

                entity.ToTable("tblCie10DiagnosticoIncapacidad", "Incapacidades");

                entity.Property(e => e.IIdcie10DiagnosticoIncapacidad).HasColumnName("iIDCie10DiagnosticoIncapacidad");

                entity.Property(e => e.IIdcie10).HasColumnName("iIDCIE10");

                entity.Property(e => e.IIddiagnosticoIncapacidad).HasColumnName("iIDDiagnosticoIncapacidad");

                entity.HasOne(d => d.IIdcie10Navigation)
                    .WithMany(p => p.TblCie10DiagnosticoIncapacidad)
                    .HasForeignKey(d => d.IIdcie10)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCie10DiagnosticoIncapacidad_tblCIE10");

                entity.HasOne(d => d.IIddiagnosticoIncapacidadNavigation)
                    .WithMany(p => p.TblCie10DiagnosticoIncapacidad)
                    .HasForeignKey(d => d.IIddiagnosticoIncapacidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCie10DiagnosticoIncapacidad_tblDiagnosticosIncapacidades");
            });

            modelBuilder.Entity<TblCiedetalle>(entity =>
            {
                entity.HasKey(e => e.IdCieDetalle);

                entity.ToTable("tblCIEDetalle");

                entity.Property(e => e.IdCieDetalle)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Clave)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IdCie).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCieNavigation)
                    .WithMany(p => p.TblCiedetalle)
                    .HasForeignKey(d => d.IdCie)
                    .HasConstraintName("FK_tblCIEDetalle_tblCIE");
            });

            modelBuilder.Entity<TblCiiu>(entity =>
            {
                entity.HasKey(e => e.IId)
                    .HasName("PK_tblCIUU");

                entity.ToTable("tblCIIU");

                entity.Property(e => e.IId).HasColumnName("iID");

                entity.Property(e => e.Clase).HasMaxLength(255);

                entity.Property(e => e.Descripcion).HasMaxLength(500);

                entity.Property(e => e.Division).HasMaxLength(255);

                entity.Property(e => e.Grupo).HasMaxLength(255);

                entity.Property(e => e.Seccion).HasMaxLength(255);
            });

            modelBuilder.Entity<TblCiuo08>(entity =>
            {
                entity.HasKey(e => e.IId);

                entity.ToTable("tblCIUO08");

                entity.Property(e => e.IId).HasColumnName("iID");

                entity.Property(e => e.BEsCategoria).HasColumnName("bEsCategoria");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.ICategoria).HasColumnName("iCategoria");

                entity.Property(e => e.TDescripcion)
                    .IsRequired()
                    .HasColumnName("tDescripcion")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TIdentificador)
                    .IsRequired()
                    .HasColumnName("tIdentificador")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblClasificacionRiesgos>(entity =>
            {
                entity.HasKey(e => e.IIdclasificacionRiesgo);

                entity.ToTable("tblClasificacionRiesgos", "negocio");

                entity.Property(e => e.IIdclasificacionRiesgo).HasColumnName("iIDClasificacionRiesgo");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdarea).HasColumnName("iIDArea");

                entity.Property(e => e.IIdriesgo).HasColumnName("iIDRiesgo");

                entity.Property(e => e.IIdtipoRiesgo).HasColumnName("iIDTipoRiesgo");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.TNombreArea)
                    .IsRequired()
                    .HasColumnName("tNombreArea")
                    .HasMaxLength(200);

                entity.Property(e => e.TNombreRiesgo)
                    .IsRequired()
                    .HasColumnName("tNombreRiesgo")
                    .HasMaxLength(200);

                entity.Property(e => e.TRiesgo)
                    .IsRequired()
                    .HasColumnName("tRiesgo")
                    .HasMaxLength(200);

                entity.HasOne(d => d.IIdusuarioCreacionNavigation)
                    .WithMany(p => p.TblClasificacionRiesgos)
                    .HasForeignKey(d => d.IIdusuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblClasificacionRiesgos_tblUsuarios");
            });

            modelBuilder.Entity<TblCodigosCorrelacion>(entity =>
            {
                entity.HasKey(e => e.IIdcodigoCorrelacion);

                entity.ToTable("tblCodigosCorrelacion", "Incapacidades");

                entity.Property(e => e.IIdcodigoCorrelacion).HasColumnName("iIDCodigoCorrelacion");

                entity.Property(e => e.IIdcie10).HasColumnName("iIDCIE10");

                entity.Property(e => e.TCodigoCorrelacion)
                    .IsRequired()
                    .HasColumnName("tCodigoCorrelacion")
                    .HasMaxLength(10);

                entity.HasOne(d => d.IIdcie10Navigation)
                    .WithMany(p => p.TblCodigosCorrelacion)
                    .HasForeignKey(d => d.IIdcie10)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCodigosCorrelacion_tblCIE10");
            });

            modelBuilder.Entity<TblConceptoRehabilitacion>(entity =>
            {
                entity.HasKey(e => e.IIdConceptoRehabilitacion);

                entity.ToTable("tblConceptoRehabilitacion", "Incapacidades");

                entity.Property(e => e.IIdConceptoRehabilitacion).HasColumnName("iIdConceptoRehabilitacion");

                entity.Property(e => e.DescripcionOtrosTratamientos).HasMaxLength(4000);

                entity.Property(e => e.FechaEmision).HasColumnType("datetime");

                entity.Property(e => e.IIdconcepto).HasColumnName("iIDConcepto");

                entity.Property(e => e.IIdeps).HasColumnName("iIDEPS");

                entity.Property(e => e.IIdfinalidadTratamiento).HasColumnName("iIDFinalidadTratamiento");

                entity.Property(e => e.IIdmedico).HasColumnName("iIDMedico");

                entity.Property(e => e.IIdpaciente).HasColumnName("iIDPaciente");

                entity.Property(e => e.IIdplazoCorto).HasColumnName("iIDPlazoCorto");

                entity.Property(e => e.IIdplazoLargo).HasColumnName("iIDPlazoLargo");

                entity.Property(e => e.IIdpronostico).HasColumnName("iIDPronostico");

                entity.Property(e => e.IIdremision).HasColumnName("iIDRemision");

                entity.Property(e => e.IIdsecuela).HasColumnName("iIDSecuela");

                entity.HasOne(d => d.IIdmedicoNavigation)
                    .WithMany(p => p.TblConceptoRehabilitacion)
                    .HasForeignKey(d => d.IIdmedico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblConceptoRehabilitacion_tblEmpleados");
            });

            modelBuilder.Entity<TblCorredores>(entity =>
            {
                entity.HasKey(e => e.IIdcorredor);

                entity.ToTable("tblCorredores", "negocio");

                entity.Property(e => e.IIdcorredor).HasColumnName("iIDCorredor");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdtipoIdentificacion).HasColumnName("iIDTipoIdentificacion");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.TCodigoExterno)
                    .HasColumnName("tCodigoExterno")
                    .HasMaxLength(10);

                entity.Property(e => e.TDigitoVerificacion).HasColumnName("tDigitoVerificacion");

                entity.Property(e => e.TNombre)
                    .IsRequired()
                    .HasColumnName("tNombre")
                    .HasMaxLength(400);

                entity.Property(e => e.TNumeroIdentificacion)
                    .HasColumnName("tNumeroIdentificacion")
                    .HasMaxLength(200);

                entity.HasOne(d => d.IIdtipoIdentificacionNavigation)
                    .WithMany(p => p.TblCorredores)
                    .HasForeignKey(d => d.IIdtipoIdentificacion)
                    .HasConstraintName("FK_tblCorredores_tblMultivalores");

                entity.HasOne(d => d.IIdusuarioCreacionNavigation)
                    .WithMany(p => p.TblCorredores)
                    .HasForeignKey(d => d.IIdusuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCorredores_tblUsuarios");
            });

            modelBuilder.Entity<TblDashBoard>(entity =>
            {
                entity.HasKey(e => new { e.IIdperfil, e.IIdtipoTarea });

                entity.ToTable("tblDashBoard", "negocio");

                entity.Property(e => e.IIdperfil).HasColumnName("iIDPerfil");

                entity.Property(e => e.IIdtipoTarea).HasColumnName("iIDTipoTarea");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.HasOne(d => d.IIdperfilNavigation)
                    .WithMany(p => p.TblDashBoard)
                    .HasForeignKey(d => d.IIdperfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDashBoard_tblPerfiles");

                entity.HasOne(d => d.IIdtipoTareaNavigation)
                    .WithMany(p => p.TblDashBoard)
                    .HasForeignKey(d => d.IIdtipoTarea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDashBoard_tblDashBoard");

                entity.HasOne(d => d.IIdusuarioCreacionNavigation)
                    .WithMany(p => p.TblDashBoard)
                    .HasForeignKey(d => d.IIdusuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDashBoard_tblUsuarios");
            });

            modelBuilder.Entity<TblDiagnosticoCondicionTrabajo>(entity =>
            {
                entity.HasKey(e => e.IIdcondicionTrabajo);

                entity.ToTable("tblDiagnosticoCondicionTrabajo", "negocio");

                entity.Property(e => e.IIdcondicionTrabajo).HasColumnName("iIDCondicionTrabajo");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaDiagnostico)
                    .HasColumnName("dtFechaDiagnostico")
                    .HasColumnType("date");

                entity.Property(e => e.IActividades).HasColumnName("iActividades");

                entity.Property(e => e.ICargo).HasColumnName("iCargo");

                entity.Property(e => e.IControlAdministrativo).HasColumnName("iControlAdministrativo");

                entity.Property(e => e.IControlFuente).HasColumnName("iControlFuente");

                entity.Property(e => e.IControlIndividuo).HasColumnName("iControlIndividuo");

                entity.Property(e => e.IControlIngenieria).HasColumnName("iControlIngenieria");

                entity.Property(e => e.IControlMedio).HasColumnName("iControlMedio");

                entity.Property(e => e.IElementosProteccion).HasColumnName("iElementosProteccion");

                entity.Property(e => e.IEvaluacionDeficiencia).HasColumnName("iEvaluacionDeficiencia");

                entity.Property(e => e.IEvaluacionExposicion).HasColumnName("iEvaluacionExposicion");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.INivelConsecuencia).HasColumnName("iNivelConsecuencia");

                entity.Property(e => e.INivelRiesgo).HasColumnName("iNivelRiesgo");

                entity.Property(e => e.INumeroExpuestos).HasColumnName("iNumeroExpuestos");

                entity.Property(e => e.IPeligrosCalificacion).HasColumnName("iPeligrosCalificacion");

                entity.Property(e => e.IPeligrosDescripcion).HasColumnName("iPeligrosDescripcion");

                entity.Property(e => e.IProceso).HasColumnName("iProceso");

                entity.Property(e => e.IRequisitoLegal).HasColumnName("iRequisitoLegal");

                entity.Property(e => e.IRutinarias).HasColumnName("iRutinarias");

                entity.Property(e => e.ISucursal).HasColumnName("iSucursal");

                entity.Property(e => e.ITareas).HasColumnName("iTareas");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TAceptabilidadRiesgo)
                    .IsRequired()
                    .HasColumnName("tAceptabilidadRiesgo")
                    .HasMaxLength(50);

                entity.Property(e => e.TEliminacion)
                    .IsRequired()
                    .HasColumnName("tEliminacion")
                    .HasMaxLength(1000);

                entity.Property(e => e.TInterpretacionNivelRiesgo)
                    .IsRequired()
                    .HasColumnName("tInterpretacionNivelRiesgo")
                    .HasMaxLength(1000);

                entity.Property(e => e.TInterpretacionProbabilidad)
                    .IsRequired()
                    .HasColumnName("tInterpretacionProbabilidad")
                    .HasMaxLength(1000);

                entity.Property(e => e.TNivelProbabilidad)
                    .IsRequired()
                    .HasColumnName("tNivelProbabilidad")
                    .HasMaxLength(50);

                entity.Property(e => e.TPeorConsecuencia)
                    .IsRequired()
                    .HasColumnName("tPeorConsecuencia")
                    .HasMaxLength(500);

                entity.Property(e => e.TSustitucion)
                    .IsRequired()
                    .HasColumnName("tSustitucion")
                    .HasMaxLength(1000);

                entity.HasOne(d => d.IActividadesNavigation)
                    .WithMany(p => p.TblDiagnosticoCondicionTrabajoIActividadesNavigation)
                    .HasForeignKey(d => d.IActividades)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDiagnosticoCondicionTrabajo_tblMultivalores");

                entity.HasOne(d => d.ICargoNavigation)
                    .WithMany(p => p.TblDiagnosticoCondicionTrabajo)
                    .HasForeignKey(d => d.ICargo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDiagnosticoCondicionTrabajo_tblCargos");

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblDiagnosticoCondicionTrabajo)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDiagnosticoCondicionTrabajo_tblEmpresas");

                entity.HasOne(d => d.IRequisitoLegalNavigation)
                    .WithMany(p => p.TblDiagnosticoCondicionTrabajo)
                    .HasForeignKey(d => d.IRequisitoLegal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDiagnosticoCondicionTrabajo_tblJurisprudencias");

                entity.HasOne(d => d.ISucursalNavigation)
                    .WithMany(p => p.TblDiagnosticoCondicionTrabajo)
                    .HasForeignKey(d => d.ISucursal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDiagnosticoCondicionTrabajo_tblSucursalesEmpresas");

                entity.HasOne(d => d.ITareasNavigation)
                    .WithMany(p => p.TblDiagnosticoCondicionTrabajoITareasNavigation)
                    .HasForeignKey(d => d.ITareas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDiagnosticoCondicionTrabajo_tblMultivalores1");
            });

            modelBuilder.Entity<TblDiagnosticoInicial>(entity =>
            {
                entity.HasKey(e => new { e.IIdempresa, e.IIdestandar, e.IVersion, e.DtFechaDiagnostico, e.TPregunta })
                    .HasName("PK_tblDiagnosticoInicial_1");

                entity.ToTable("tblDiagnosticoInicial", "negocio");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IIdestandar).HasColumnName("iIDEstandar");

                entity.Property(e => e.IVersion).HasColumnName("iVersion");

                entity.Property(e => e.DtFechaDiagnostico)
                    .HasColumnName("dtFechaDiagnostico")
                    .HasColumnType("date");

                entity.Property(e => e.TPregunta)
                    .HasColumnName("tPregunta")
                    .HasMaxLength(50);

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.BCumple).HasColumnName("bCumple");

                entity.Property(e => e.BNoAplica).HasColumnName("bNoAplica");

                entity.Property(e => e.BNoCumple).HasColumnName("bNoCumple");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblDiagnosticoInicial)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDiagnosticoInicial_tblEmpresas");

                entity.HasOne(d => d.IIdestandarNavigation)
                    .WithMany(p => p.TblDiagnosticoInicial)
                    .HasForeignKey(d => d.IIdestandar)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDiagnosticoInicial_tblMultivalores");

                entity.HasOne(d => d.IIdusuarioCreacionNavigation)
                    .WithMany(p => p.TblDiagnosticoInicial)
                    .HasForeignKey(d => d.IIdusuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDiagnosticoInicial_tblUsuarios");
            });

            modelBuilder.Entity<TblDiagnosticos>(entity =>
            {
                entity.HasKey(e => e.IIddiagnostico);

                entity.ToTable("tblDiagnosticos", "administracion");

                entity.Property(e => e.IIddiagnostico).HasColumnName("iIDDiagnostico");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaInsercion)
                    .HasColumnName("dtFechaInsercion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaModificacion)
                    .HasColumnName("dtFechaModificacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIddiagnosticoCapitulo).HasColumnName("iIDDiagnosticoCapitulo");

                entity.Property(e => e.IIddiagnosticoNomenclatura).HasColumnName("iIDDiagnosticoNomenclatura");

                entity.Property(e => e.IIdpais).HasColumnName("iIDPais");

                entity.Property(e => e.IIdusuarioInsercion).HasColumnName("iIDUsuarioInsercion");

                entity.Property(e => e.IIdusuarioModificacion).HasColumnName("iIDUsuarioModificacion");

                entity.Property(e => e.TClave)
                    .HasColumnName("tClave")
                    .HasMaxLength(200);

                entity.Property(e => e.TDescripcion)
                    .HasColumnName("tDescripcion")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<TblDiagnosticosCapitulos>(entity =>
            {
                entity.HasKey(e => e.IIddiagnosticoCapitulo);

                entity.ToTable("tblDiagnosticosCapitulos", "administracion");

                entity.Property(e => e.IIddiagnosticoCapitulo).HasColumnName("iIDDiagnosticoCapitulo");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaInsercion)
                    .HasColumnName("dtFechaInsercion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaModificacion)
                    .HasColumnName("dtFechaModificacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IGrupoCapitulo).HasColumnName("iGrupoCapitulo");

                entity.Property(e => e.IIddiagnosticoNomenclatura).HasColumnName("iIDDiagnosticoNomenclatura");

                entity.Property(e => e.IIdusuarioInsercion).HasColumnName("iIDUsuarioInsercion");

                entity.Property(e => e.IIdusuarioModificacion).HasColumnName("iIDUsuarioModificacion");

                entity.Property(e => e.TCodigoCapitulo)
                    .HasColumnName("tCodigoCapitulo")
                    .HasMaxLength(200);

                entity.Property(e => e.TNombreCapitulo)
                    .HasColumnName("tNombreCapitulo")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<TblDiagnosticosIncapacidades>(entity =>
            {
                entity.HasKey(e => e.IIddiagnosticoIncapacidad)
                    .HasName("PK_tblDiagnosticos_1");

                entity.ToTable("tblDiagnosticosIncapacidades", "Incapacidades");

                entity.Property(e => e.IIddiagnosticoIncapacidad).HasColumnName("iIDDiagnosticoIncapacidad");

                entity.Property(e => e.BEsTranscripcion).HasColumnName("bEsTranscripcion");

                entity.Property(e => e.BProrroga).HasColumnName("bProrroga");

                entity.Property(e => e.BSoat).HasColumnName("bSOAT");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaEmisionIncapacidad)
                    .HasColumnName("dtFechaEmisionIncapacidad")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaFin)
                    .HasColumnName("dtFechaFin")
                    .HasColumnType("datetime");

                entity.Property(e => e.IDiasAcumuladosPorroga).HasColumnName("iDiasAcumuladosPorroga");

                entity.Property(e => e.IDiasIncapacidad).HasColumnName("iDiasIncapacidad");

                entity.Property(e => e.IIdafp).HasColumnName("iIDAFP");

                entity.Property(e => e.IIdarl).HasColumnName("iIDARL");

                entity.Property(e => e.IIddiagnosticoCorrelacion).HasColumnName("iIDDiagnosticoCorrelacion");

                entity.Property(e => e.IIdeps).HasColumnName("iIDEPS");

                entity.Property(e => e.IIdips).HasColumnName("iIDIPS");

                entity.Property(e => e.IIdorigenCalificadoIncapacidad).HasColumnName("iIDOrigenCalificadoIncapacidad");

                entity.Property(e => e.IIdpaciente).HasColumnName("iIDPaciente");

                entity.Property(e => e.IIdpresuntoOrigenIncapacidad).HasColumnName("iIDPresuntoOrigenIncapacidad");

                entity.Property(e => e.IIdtipoAtencion).HasColumnName("iIDTipoAtencion");

                entity.Property(e => e.IIdusuarioCreador).HasColumnName("iIDUsuarioCreador");

                entity.Property(e => e.NumeroIncapacidadIpstranscripcion)
                    .HasColumnName("NumeroIncapacidadIPSTranscripcion")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TCodigoCorto)
                    .IsRequired()
                    .HasColumnName("tCodigoCorto")
                    .HasMaxLength(50);

                entity.Property(e => e.TDescripcionSintomatologica)
                    .HasColumnName("tDescripcionSintomatologica")
                    .IsUnicode(false);

                entity.Property(e => e.TLugar)
                    .HasColumnName("tLugar")
                    .HasMaxLength(1000);

                entity.Property(e => e.TModo)
                    .HasColumnName("tModo")
                    .HasMaxLength(1000);

                entity.Property(e => e.TTiempo)
                    .HasColumnName("tTiempo")
                    .HasMaxLength(1000);

                entity.Property(e => e.UiCodigoDiagnostico)
                    .HasColumnName("uiCodigoDiagnostico")
                    .HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.IIdafpNavigation)
                    .WithMany(p => p.TblDiagnosticosIncapacidades)
                    .HasForeignKey(d => d.IIdafp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDiagnosticosIncapacidades_tblAFP");

                entity.HasOne(d => d.IIdarlNavigation)
                    .WithMany(p => p.TblDiagnosticosIncapacidades)
                    .HasForeignKey(d => d.IIdarl)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDiagnosticosIncapacidades_tblARLs");

                entity.HasOne(d => d.IIddiagnosticoCorrelacionNavigation)
                    .WithMany(p => p.InverseIIddiagnosticoCorrelacionNavigation)
                    .HasForeignKey(d => d.IIddiagnosticoCorrelacion)
                    .HasConstraintName("FK_tblDiagnosticosIncapacidades_tblDiagnosticosIncapacidades");

                entity.HasOne(d => d.IIdepsNavigation)
                    .WithMany(p => p.TblDiagnosticosIncapacidades)
                    .HasForeignKey(d => d.IIdeps)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDiagnosticosIncapacidades_tblEPS");

                entity.HasOne(d => d.IIdipsNavigation)
                    .WithMany(p => p.TblDiagnosticosIncapacidades)
                    .HasForeignKey(d => d.IIdips)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDiagnosticosIncapacidades_tblIPS");

                entity.HasOne(d => d.IIdorigenCalificadoIncapacidadNavigation)
                    .WithMany(p => p.TblDiagnosticosIncapacidadesIIdorigenCalificadoIncapacidadNavigation)
                    .HasForeignKey(d => d.IIdorigenCalificadoIncapacidad)
                    .HasConstraintName("FK_tblDiagnosticosIncapacidades_tblMultivalores3");

                entity.HasOne(d => d.IIdpacienteNavigation)
                    .WithMany(p => p.TblDiagnosticosIncapacidades)
                    .HasForeignKey(d => d.IIdpaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDiagnosticosIncapacidades_tblPacientes");

                entity.HasOne(d => d.IIdpresuntoOrigenIncapacidadNavigation)
                    .WithMany(p => p.TblDiagnosticosIncapacidadesIIdpresuntoOrigenIncapacidadNavigation)
                    .HasForeignKey(d => d.IIdpresuntoOrigenIncapacidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDiagnosticosIncapacidades_tblMultivalores2");

                entity.HasOne(d => d.IIdtipoAtencionNavigation)
                    .WithMany(p => p.TblDiagnosticosIncapacidadesIIdtipoAtencionNavigation)
                    .HasForeignKey(d => d.IIdtipoAtencion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDiagnosticosIncapacidades_tblMultivalores1");
            });

            modelBuilder.Entity<TblDiagnosticosNomenclaturas>(entity =>
            {
                entity.HasKey(e => e.IIddiagnosticoNomenclatura)
                    .HasName("PK_tblDiagnosticoNomenclatura");

                entity.ToTable("tblDiagnosticosNomenclaturas", "administracion");

                entity.Property(e => e.IIddiagnosticoNomenclatura).HasColumnName("iIDDiagnosticoNomenclatura");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaInsercion)
                    .HasColumnName("dtFechaInsercion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaModificacion)
                    .HasColumnName("dtFechaModificacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdusuarioInsercion).HasColumnName("iIDUsuarioInsercion");

                entity.Property(e => e.IIdusuarioModificacion).HasColumnName("iIDUsuarioModificacion");

                entity.Property(e => e.TNomenclatura)
                    .HasColumnName("tNomenclatura")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<TblDivipola>(entity =>
            {
                entity.HasKey(e => e.Iddivipola);

                entity.ToTable("tblDivipola");

                entity.Property(e => e.Iddivipola).HasColumnName("IDDIVIPOLA");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.Codigodivipola)
                    .HasColumnName("CODIGODIVIPOLA")
                    .HasMaxLength(20);

                entity.Property(e => e.Fechainsercion)
                    .HasColumnName("FECHAINSERCION")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fechamodificacion)
                    .HasColumnName("FECHAMODIFICACION")
                    .HasColumnType("datetime");

                entity.Property(e => e.Iddepto)
                    .HasColumnName("IDDEPTO")
                    .HasMaxLength(50);

                entity.Property(e => e.Idmunicipio)
                    .HasColumnName("IDMUNICIPIO")
                    .HasMaxLength(50);

                entity.Property(e => e.Idpais)
                    .HasColumnName("IDPAIS")
                    .HasMaxLength(20);

                entity.Property(e => e.Nombredepto)
                    .HasColumnName("NOMBREDEPTO")
                    .HasMaxLength(100);

                entity.Property(e => e.Nombremunicipio)
                    .HasColumnName("NOMBREMUNICIPIO")
                    .HasMaxLength(100);

                entity.Property(e => e.Nombrepais)
                    .HasColumnName("NOMBREPAIS")
                    .HasMaxLength(100);

                entity.Property(e => e.Nombrepoblacion)
                    .HasColumnName("NOMBREPOBLACION")
                    .HasMaxLength(100);

                entity.Property(e => e.Usuarioinsercion)
                    .HasColumnName("USUARIOINSERCION")
                    .HasMaxLength(50);

                entity.Property(e => e.Usuariomodificacion)
                    .HasColumnName("USUARIOMODIFICACION")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblElementos>(entity =>
            {
                entity.HasKey(e => e.IIdelemento);

                entity.ToTable("tblElementos", "administracion");

                entity.Property(e => e.IIdelemento).HasColumnName("iIDElemento");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaInsercion)
                    .HasColumnName("dtFechaInsercion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaModificacion)
                    .HasColumnName("dtFechaModificacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdpais).HasColumnName("iIDPais");

                entity.Property(e => e.IIdusuarioInsercion).HasColumnName("iIDUsuarioInsercion");

                entity.Property(e => e.IIdusuarioModificacion).HasColumnName("iIDUsuarioModificacion");

                entity.Property(e => e.TCodigo)
                    .HasColumnName("tCodigo")
                    .HasMaxLength(200);

                entity.Property(e => e.TDescripcion)
                    .HasColumnName("tDescripcion")
                    .HasMaxLength(300);

                entity.HasOne(d => d.IIdusuarioInsercionNavigation)
                    .WithMany(p => p.TblElementosIIdusuarioInsercionNavigation)
                    .HasForeignKey(d => d.IIdusuarioInsercion)
                    .HasConstraintName("FK_tblElementos_tblUsuarios");

                entity.HasOne(d => d.IIdusuarioModificacionNavigation)
                    .WithMany(p => p.TblElementosIIdusuarioModificacionNavigation)
                    .HasForeignKey(d => d.IIdusuarioModificacion)
                    .HasConstraintName("FK_tblElementos_tblUsuarios1");
            });

            modelBuilder.Entity<TblEmisores>(entity =>
            {
                entity.HasKey(e => e.IIdemisor);

                entity.ToTable("tblEmisores", "jurisprudencia");

                entity.Property(e => e.IIdemisor).HasColumnName("iIDEmisor");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdtipoIdentificacion).HasColumnName("iIDTipoIdentificacion");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.TCodigoExterno)
                    .IsRequired()
                    .HasColumnName("tCodigoExterno")
                    .HasMaxLength(10);

                entity.Property(e => e.TDigitoVerificacion).HasColumnName("tDigitoVerificacion");

                entity.Property(e => e.TNombre)
                    .IsRequired()
                    .HasColumnName("tNombre")
                    .HasMaxLength(200);

                entity.Property(e => e.TNumeroIdentificacion)
                    .IsRequired()
                    .HasColumnName("tNumeroIdentificacion")
                    .HasMaxLength(200);

                entity.HasOne(d => d.IIdtipoIdentificacionNavigation)
                    .WithMany(p => p.TblEmisores)
                    .HasForeignKey(d => d.IIdtipoIdentificacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmisores_tblMultivalores");

                entity.HasOne(d => d.IIdusuarioCreacionNavigation)
                    .WithMany(p => p.TblEmisores)
                    .HasForeignKey(d => d.IIdusuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmisores_tblUsuarios");
            });

            modelBuilder.Entity<TblEmpleados>(entity =>
            {
                entity.HasKey(e => e.IIdempleado);

                entity.ToTable("tblEmpleados", "negocio");

                entity.Property(e => e.IIdempleado).HasColumnName("iIDEmpleado");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.BExamenMedico).HasColumnName("bExamenMedico");

                entity.Property(e => e.BInduccion).HasColumnName("bInduccion");

                entity.Property(e => e.BRepresentanteLegal).HasColumnName("bRepresentanteLegal");

                entity.Property(e => e.DtFechaAfiliacionAfp)
                    .HasColumnName("dtFechaAfiliacionAFP")
                    .HasColumnType("date");

                entity.Property(e => e.DtFechaAfiliacionArl)
                    .HasColumnName("dtFechaAfiliacionARL")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaAfiliacionEps)
                    .HasColumnName("dtFechaAfiliacionEPS")
                    .HasColumnType("date");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaExamenMedico)
                    .HasColumnName("dtFechaExamenMedico")
                    .HasColumnType("date");

                entity.Property(e => e.DtFechaInduccion)
                    .HasColumnName("dtFechaInduccion")
                    .HasColumnType("date");

                entity.Property(e => e.DtFechaIngreso)
                    .HasColumnName("dtFechaIngreso")
                    .HasColumnType("date");

                entity.Property(e => e.DtFechaModificacion)
                    .HasColumnName("dtFechaModificacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaNacimiento)
                    .HasColumnName("dtFechaNacimiento")
                    .HasColumnType("date");

                entity.Property(e => e.EmployeeDetailsId).HasDefaultValueSql("(CONVERT([bigint],(0),0))");

                entity.Property(e => e.IIdafp).HasColumnName("iIDAFP");

                entity.Property(e => e.IIdarl).HasColumnName("iIDARL");

                entity.Property(e => e.IIdcargo).HasColumnName("iIDCargo");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IIdeps).HasColumnName("iIDEPS");

                entity.Property(e => e.IIdestadoCivil).HasColumnName("iIDEstadoCivil");

                entity.Property(e => e.IIdformacionEducativa).HasColumnName("iIDFormacionEducativa");

                entity.Property(e => e.IIdgenero).HasColumnName("iIDGenero");

                entity.Property(e => e.IIdlugarDomicilio).HasColumnName("iIDLugarDomicilio");

                entity.Property(e => e.IIdlugarExpedicion).HasColumnName("iIDLugarExpedicion");

                entity.Property(e => e.IIdlugarNacimiento).HasColumnName("iIDLugarNacimiento");

                entity.Property(e => e.IIdmonedaSalario).HasColumnName("iIDMonedaSalario");

                entity.Property(e => e.IIdnacionalidad).HasColumnName("iIDNacionalidad");

                entity.Property(e => e.IIdsucursal).HasColumnName("iIDSucursal");

                entity.Property(e => e.IIdtipoDocumento).HasColumnName("iIDTipoDocumento");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.IIdusuarioModificacion).HasColumnName("iIDUsuarioModificacion");

                entity.Property(e => e.IValorSalario).HasColumnName("iValorSalario");

                entity.Property(e => e.IiDtipoVinculacion).HasColumnName("iiDTipoVinculacion");

                entity.Property(e => e.TDireccionDomicilio)
                    .IsRequired()
                    .HasColumnName("tDireccionDomicilio")
                    .HasMaxLength(300);

                entity.Property(e => e.TEmail)
                    .HasColumnName("tEmail")
                    .HasMaxLength(200);

                entity.Property(e => e.TNumeroDocumento)
                    .IsRequired()
                    .HasColumnName("tNumeroDocumento")
                    .HasMaxLength(50);

                entity.Property(e => e.TPrimerApellido)
                    .IsRequired()
                    .HasColumnName("tPrimerApellido")
                    .HasMaxLength(100);

                entity.Property(e => e.TPrimerNombre)
                    .IsRequired()
                    .HasColumnName("tPrimerNombre")
                    .HasMaxLength(100);

                entity.Property(e => e.TSegundoApellido)
                    .HasColumnName("tSegundoApellido")
                    .HasMaxLength(100);

                entity.Property(e => e.TSegundoNombre)
                    .HasColumnName("tSegundoNombre")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IIdarlNavigation)
                    .WithMany(p => p.TblEmpleados)
                    .HasForeignKey(d => d.IIdarl)
                    .HasConstraintName("FK_tblEmpleados_tblARLs");

                entity.HasOne(d => d.IIdcargoNavigation)
                    .WithMany(p => p.TblEmpleados)
                    .HasForeignKey(d => d.IIdcargo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpleados_tblCargos");

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblEmpleados)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpleados_tblEmpresas");

                entity.HasOne(d => d.IIdepsNavigation)
                    .WithMany(p => p.TblEmpleados)
                    .HasForeignKey(d => d.IIdeps)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpleados_tblEPS");

                entity.HasOne(d => d.IIdestadoCivilNavigation)
                    .WithMany(p => p.TblEmpleadosIIdestadoCivilNavigation)
                    .HasForeignKey(d => d.IIdestadoCivil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpleados_tblEmpleados");

                entity.HasOne(d => d.IIdformacionEducativaNavigation)
                    .WithMany(p => p.TblEmpleadosIIdformacionEducativaNavigation)
                    .HasForeignKey(d => d.IIdformacionEducativa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpleados_tblMultivalores2");

                entity.HasOne(d => d.IIdgeneroNavigation)
                    .WithMany(p => p.TblEmpleadosIIdgeneroNavigation)
                    .HasForeignKey(d => d.IIdgenero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpleados_tblMultivalores");

                entity.HasOne(d => d.IIdlugarDomicilioNavigation)
                    .WithMany(p => p.TblEmpleadosIIdlugarDomicilioNavigation)
                    .HasForeignKey(d => d.IIdlugarDomicilio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpleados_tblDivipola1");

                entity.HasOne(d => d.IIdlugarExpedicionNavigation)
                    .WithMany(p => p.TblEmpleadosIIdlugarExpedicionNavigation)
                    .HasForeignKey(d => d.IIdlugarExpedicion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpleados_tblDivipola2");

                entity.HasOne(d => d.IIdlugarNacimientoNavigation)
                    .WithMany(p => p.TblEmpleadosIIdlugarNacimientoNavigation)
                    .HasForeignKey(d => d.IIdlugarNacimiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpleados_tblDivipola");

                entity.HasOne(d => d.IIdsucursalNavigation)
                    .WithMany(p => p.TblEmpleados)
                    .HasForeignKey(d => d.IIdsucursal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpleados_tblSucursalesEmpresas");

                entity.HasOne(d => d.IIdtipoDocumentoNavigation)
                    .WithMany(p => p.TblEmpleadosIIdtipoDocumentoNavigation)
                    .HasForeignKey(d => d.IIdtipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpleados_tblMultivalores1");

                entity.HasOne(d => d.IIdusuarioCreacionNavigation)
                    .WithMany(p => p.TblEmpleados)
                    .HasForeignKey(d => d.IIdusuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpleados_tblUsuarios");

                entity.HasOne(d => d.IiDtipoVinculacionNavigation)
                    .WithMany(p => p.TblEmpleadosIiDtipoVinculacionNavigation)
                    .HasForeignKey(d => d.IiDtipoVinculacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpleados_tblMultivalores3");
            });

            modelBuilder.Entity<TblEmpleadosDetalles>(entity =>
            {
                entity.ToTable("tblEmpleadosDetalles");

                entity.HasIndex(e => e.EmployeeId);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TblEmpleadosDetalles)
                    .HasForeignKey(d => d.EmployeeId);
            });

            modelBuilder.Entity<TblEmpresaArea>(entity =>
            {
                entity.HasKey(e => e.IIdempresaArea);

                entity.ToTable("tblEmpresaArea", "negocio");

                entity.Property(e => e.IIdempresaArea).HasColumnName("iIDEmpresaArea");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtUsuarioCreacion)
                    .HasColumnName("dtUsuarioCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TCodigo)
                    .HasColumnName("tCodigo")
                    .HasMaxLength(20);

                entity.Property(e => e.TNombreArea)
                    .IsRequired()
                    .HasColumnName("tNombreArea")
                    .HasMaxLength(200);

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblEmpresaArea)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresaArea_tblEmpresas");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblEmpresaArea)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresaArea_tblUsuarios");
            });

            modelBuilder.Entity<TblEmpresaControlEficacia>(entity =>
            {
                entity.HasKey(e => e.IIdcontrolEficacia);

                entity.ToTable("tblEmpresaControlEficacia", "proceso");

                entity.Property(e => e.IIdcontrolEficacia).HasColumnName("iIDControlEficacia");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IOrden).HasColumnName("iOrden");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.IValor).HasColumnName("iValor");

                entity.Property(e => e.TDescripcion)
                    .IsRequired()
                    .HasColumnName("tDescripcion")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblEmpresaControlEficacia)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresaControlEficacia_tblEmpresas");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblEmpresaControlEficacia)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresaControlEficacia_tblUsuarios");
            });

            modelBuilder.Entity<TblEmpresaControlFrecuencia>(entity =>
            {
                entity.HasKey(e => e.IIdcontrolFrecuencia);

                entity.ToTable("tblEmpresaControlFrecuencia", "proceso");

                entity.Property(e => e.IIdcontrolFrecuencia).HasColumnName("iIDControlFrecuencia");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IOrden).HasColumnName("iOrden");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.IValor).HasColumnName("iValor");

                entity.Property(e => e.TDescripcion)
                    .IsRequired()
                    .HasColumnName("tDescripcion")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblEmpresaControlFrecuencia)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresaControlFrecuencia_tblEmpresas");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblEmpresaControlFrecuencia)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresaControlFrecuencia_tblUsuarios");
            });

            modelBuilder.Entity<TblEmpresaControlHerramientas>(entity =>
            {
                entity.HasKey(e => e.IIdcontrolHerramienta)
                    .HasName("PK_tblEmpresaControlHerramienta");

                entity.ToTable("tblEmpresaControlHerramientas", "proceso");

                entity.Property(e => e.IIdcontrolHerramienta).HasColumnName("iIDControlHerramienta");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IOrden).HasColumnName("iOrden");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.IValor).HasColumnName("iValor");

                entity.Property(e => e.TDescripcion)
                    .IsRequired()
                    .HasColumnName("tDescripcion")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblEmpresaControlHerramientas)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresaControlHerramientas_tblEmpresas");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblEmpresaControlHerramientas)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresaControlHerramienta_tblUsuarios");
            });

            modelBuilder.Entity<TblEmpresaControlProcedimientos>(entity =>
            {
                entity.HasKey(e => e.IIdcontrolProcedimiento);

                entity.ToTable("tblEmpresaControlProcedimientos", "proceso");

                entity.Property(e => e.IIdcontrolProcedimiento).HasColumnName("iIDControlProcedimiento");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IOrden).HasColumnName("iOrden");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.IValor).HasColumnName("iValor");

                entity.Property(e => e.TDescripcion)
                    .IsRequired()
                    .HasColumnName("tDescripcion")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblEmpresaControlProcedimientos)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresaControlProcedimientos_tblEmpresas");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblEmpresaControlProcedimientos)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresaControlProcedimientos_tblUsuarios");
            });

            modelBuilder.Entity<TblEmpresaControlResponsable>(entity =>
            {
                entity.HasKey(e => e.IIdcontrolResponsable);

                entity.ToTable("tblEmpresaControlResponsable", "proceso");

                entity.Property(e => e.IIdcontrolResponsable).HasColumnName("iIDControlResponsable");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IOrden).HasColumnName("iOrden");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.IValor).HasColumnName("iValor");

                entity.Property(e => e.TDescripcion)
                    .IsRequired()
                    .HasColumnName("tDescripcion")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblEmpresaControlResponsable)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresaControlResponsable_tblEmpresas");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblEmpresaControlResponsable)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresaControlResponsable_tblUsuarios");
            });

            modelBuilder.Entity<TblEmpresaEstandarDocGenSis>(entity =>
            {
                entity.HasKey(e => e.IIdempresaEstandarDocGenSis);

                entity.ToTable("tblEmpresaEstandarDocGenSis", "negocio");

                entity.Property(e => e.IIdempresaEstandarDocGenSis).HasColumnName("iIDEmpresaEstandarDocGenSis");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdclasePolitica).HasColumnName("iIDClasePolitica");

                entity.Property(e => e.IIdcobertura).HasColumnName("iIDCobertura");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IIdestado).HasColumnName("iIDEstado");

                entity.Property(e => e.IIdsubtablaNivelCobertura).HasColumnName("iIDSubtablaNivelCobertura");

                entity.Property(e => e.IIdtipoDocumento).HasColumnName("iIDTipoDocumento");

                entity.Property(e => e.IIdtipoPolitica).HasColumnName("iIDTipoPolitica");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.IVersion).HasColumnName("iVersion");

                entity.Property(e => e.TDescripcion)
                    .IsRequired()
                    .HasColumnName("tDescripcion")
                    .HasColumnType("text");

                entity.Property(e => e.TIdvalorNivelCobertura)
                    .HasColumnName("tIDValorNivelCobertura")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IIdcoberturaNavigation)
                    .WithMany(p => p.TblEmpresaEstandarDocGenSisIIdcoberturaNavigation)
                    .HasForeignKey(d => d.IIdcobertura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresaEstandarDocGenSis_tblMultivalores");

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblEmpresaEstandarDocGenSis)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresaEstandarDocGenSis_tblEmpresas");

                entity.HasOne(d => d.IIdestadoNavigation)
                    .WithMany(p => p.TblEmpresaEstandarDocGenSisIIdestadoNavigation)
                    .HasForeignKey(d => d.IIdestado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresaEstandarDocGenSis_tblMultivalores2");

                entity.HasOne(d => d.IIdtipoDocumentoNavigation)
                    .WithMany(p => p.TblEmpresaEstandarDocGenSisIIdtipoDocumentoNavigation)
                    .HasForeignKey(d => d.IIdtipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresaEstandarDocGenSis_tblMultivalores1");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblEmpresaEstandarDocGenSis)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresaEstandarDocGenSis_tblUsuarios");
            });

            modelBuilder.Entity<TblEmpresaEstandares>(entity =>
            {
                entity.HasKey(e => e.IIdempresaEstandar)
                    .HasName("PK_tblEmpresaPoliticas");

                entity.ToTable("tblEmpresaEstandares", "negocio");

                entity.Property(e => e.IIdempresaEstandar).HasColumnName("iIDEmpresaEstandar");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IIdestandar).HasColumnName("iIDEstandar");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblEmpresaEstandares)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresaPoliticas_tblEmpresas");

                entity.HasOne(d => d.IIdestandarNavigation)
                    .WithMany(p => p.TblEmpresaEstandares)
                    .HasForeignKey(d => d.IIdestandar)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresaPoliticas_tblMultivalores");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblEmpresaEstandares)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresaPoliticas_tblUsuarios");
            });

            modelBuilder.Entity<TblEmpresaEstructuraProcesos>(entity =>
            {
                entity.HasKey(e => e.IIdempresaEstructuraProceso);

                entity.ToTable("tblEmpresaEstructuraProcesos", "negocio");

                entity.Property(e => e.IIdempresaEstructuraProceso).HasColumnName("iIDEmpresaEstructuraProceso");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.INivelProceso).HasColumnName("iNivelProceso");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblEmpresaEstructuraProcesos)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresaEstructuraProcesos_tblEmpresas");

                entity.HasOne(d => d.INivelProcesoNavigation)
                    .WithMany(p => p.TblEmpresaEstructuraProcesos)
                    .HasForeignKey(d => d.INivelProceso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresaEstructuraProcesos_tblMultivalores");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblEmpresaEstructuraProcesos)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresaEstructuraProcesos_tblUsuarios");
            });

            modelBuilder.Entity<TblEmpresaGestora>(entity =>
            {
                entity.HasKey(e => e.IIdempresaGestora);

                entity.ToTable("tblEmpresaGestora", "negocio");

                entity.Property(e => e.IIdempresaGestora).HasColumnName("iIDEmpresaGestora");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IDigitoVerificacion).HasColumnName("iDigitoVerificacion");

                entity.Property(e => e.IIdtipoIdentificacion).HasColumnName("iIDTipoIdentificacion");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TNumeroIdentificacion)
                    .IsRequired()
                    .HasColumnName("tNumeroIdentificacion")
                    .HasMaxLength(200);

                entity.Property(e => e.TRazonSocial)
                    .IsRequired()
                    .HasColumnName("tRazonSocial")
                    .HasMaxLength(400);

                entity.Property(e => e.TUrl)
                    .HasColumnName("tUrl")
                    .HasMaxLength(300);

                entity.HasOne(d => d.IIdtipoIdentificacionNavigation)
                    .WithMany(p => p.TblEmpresaGestora)
                    .HasForeignKey(d => d.IIdtipoIdentificacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresaGestora_tblMultivalores");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblEmpresaGestora)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresaGestora_tblUsuarios");
            });

            modelBuilder.Entity<TblEmpresaJurisprudencias>(entity =>
            {
                entity.HasKey(e => e.IIdempresaJurisprudencia);

                entity.ToTable("tblEmpresaJurisprudencias", "jurisprudencia");

                entity.Property(e => e.IIdempresaJurisprudencia).HasColumnName("iIDEmpresaJurisprudencia");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IIdjurisprudencia).HasColumnName("iIDJurisprudencia");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblEmpresaJurisprudencias)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresaJurisprudencias_tblEmpresas");

                entity.HasOne(d => d.IIdjurisprudenciaNavigation)
                    .WithMany(p => p.TblEmpresaJurisprudencias)
                    .HasForeignKey(d => d.IIdjurisprudencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresaJurisprudencias_tblJurisprudencias");

                entity.HasOne(d => d.IIdusuarioCreacionNavigation)
                    .WithMany(p => p.TblEmpresaJurisprudencias)
                    .HasForeignKey(d => d.IIdusuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresaJurisprudencias_tblUsuarios");
            });

            modelBuilder.Entity<TblEmpresaParametros>(entity =>
            {
                entity.HasKey(e => e.IIdempresaParametro);

                entity.ToTable("tblEmpresaParametros", "negocio");

                entity.Property(e => e.IIdempresaParametro).HasColumnName("iIDEmpresaParametro");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFecha)
                    .HasColumnName("dtFecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdcampo).HasColumnName("iIDCampo");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.IValor).HasColumnName("iValor");

                entity.Property(e => e.TDescripcion)
                    .IsRequired()
                    .HasColumnName("tDescripcion")
                    .HasMaxLength(500);

                entity.Property(e => e.TTexto)
                    .HasColumnName("tTexto")
                    .HasMaxLength(200);

                entity.Property(e => e.TTipo)
                    .IsRequired()
                    .HasColumnName("tTipo")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblEmpresaParametros)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresaParametros_tblEmpresas");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblEmpresaParametros)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresaParametros_tblUsuarios");
            });

            modelBuilder.Entity<TblEmpresaPolitica>(entity =>
            {
                entity.HasKey(e => e.IIdempresaPolitica);

                entity.ToTable("tblEmpresaPolitica", "negocio");

                entity.Property(e => e.IIdempresaPolitica).HasColumnName("iIDEmpresaPolitica");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.IidtipoPolitica).HasColumnName("IIDTipoPolitica");

                entity.Property(e => e.TPolitica)
                    .IsRequired()
                    .HasColumnName("tPolitica")
                    .HasColumnType("text");

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblEmpresaPolitica)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresaPolitica_tblEmpresas");

                entity.HasOne(d => d.IidtipoPoliticaNavigation)
                    .WithMany(p => p.TblEmpresaPolitica)
                    .HasForeignKey(d => d.IidtipoPolitica)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresaPolitica_tblEmpresaPolitica");
            });

            modelBuilder.Entity<TblEmpresaPoliticaControlCambios>(entity =>
            {
                entity.HasKey(e => e.IIdempresaPoliticaControlCambio);

                entity.ToTable("tblEmpresaPoliticaControlCambios", "negocio");

                entity.Property(e => e.IIdempresaPoliticaControlCambio).HasColumnName("iIDEmpresaPoliticaControlCambio");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCambio)
                    .HasColumnName("dtFechaCambio")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaModificacion)
                    .HasColumnName("dtFechaModificacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdempresaPolitica).HasColumnName("iIDEmpresaPolitica");

                entity.Property(e => e.IIdusuario).HasColumnName("iIDUsuario");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.IIdusuarioModificacion).HasColumnName("iIDUsuarioModificacion");

                entity.Property(e => e.IVersion).HasColumnName("iVersion");

                entity.Property(e => e.TDescripcionCambio).HasColumnName("tDescripcionCambio");

                entity.HasOne(d => d.IIdempresaPoliticaNavigation)
                    .WithMany(p => p.TblEmpresaPoliticaControlCambios)
                    .HasForeignKey(d => d.IIdempresaPolitica)
                    .HasConstraintName("FK_tblEmpresaPoliticaControlCambios_tblEmpresaPolitica");

                entity.HasOne(d => d.IIdusuarioNavigation)
                    .WithMany(p => p.TblEmpresaPoliticaControlCambiosIIdusuarioNavigation)
                    .HasForeignKey(d => d.IIdusuario)
                    .HasConstraintName("FK_tblEmpresaPoliticaControlCambios_tblUsuarios");

                entity.HasOne(d => d.IIdusuarioCreacionNavigation)
                    .WithMany(p => p.TblEmpresaPoliticaControlCambiosIIdusuarioCreacionNavigation)
                    .HasForeignKey(d => d.IIdusuarioCreacion)
                    .HasConstraintName("FK_tblEmpresaPoliticaControlCambios_tblUsuarios1");

                entity.HasOne(d => d.IIdusuarioModificacionNavigation)
                    .WithMany(p => p.TblEmpresaPoliticaControlCambiosIIdusuarioModificacionNavigation)
                    .HasForeignKey(d => d.IIdusuarioModificacion)
                    .HasConstraintName("FK_tblEmpresaPoliticaControlCambios_tblUsuarios2");
            });

            modelBuilder.Entity<TblEmpresaProcesoRiesgos>(entity =>
            {
                entity.HasKey(e => e.IIdempresaProcesoRiesgo);

                entity.ToTable("tblEmpresaProcesoRiesgos", "negocio");

                entity.Property(e => e.IIdempresaProcesoRiesgo).HasColumnName("iIDEmpresaProcesoRiesgo");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdclasificacionRiesgo).HasColumnName("iIDClasificacionRiesgo");

                entity.Property(e => e.IIdempresaProceso).HasColumnName("iIDEmpresaProceso");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.HasOne(d => d.IIdclasificacionRiesgoNavigation)
                    .WithMany(p => p.TblEmpresaProcesoRiesgos)
                    .HasForeignKey(d => d.IIdclasificacionRiesgo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresaProcesoRiesgos_tblClasificacionRiesgos");

                entity.HasOne(d => d.IIdempresaProcesoNavigation)
                    .WithMany(p => p.TblEmpresaProcesoRiesgos)
                    .HasForeignKey(d => d.IIdempresaProceso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresaProcesoRiesgos_tblEmpresaProcesos");
            });

            modelBuilder.Entity<TblEmpresaProcesos>(entity =>
            {
                entity.HasKey(e => e.IIdempresaProceso);

                entity.ToTable("tblEmpresaProcesos", "negocio");

                entity.Property(e => e.IIdempresaProceso).HasColumnName("iIDEmpresaProceso");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IIdnivelProceso).HasColumnName("iIDNivelProceso");

                entity.Property(e => e.IIdpadre).HasColumnName("iIDPadre");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TCodigo)
                    .HasColumnName("tCodigo")
                    .HasMaxLength(20);

                entity.Property(e => e.TNombre)
                    .IsRequired()
                    .HasColumnName("tNombre")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblEmpresaProcesos)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresaProcesos_tblEmpresas");

                entity.HasOne(d => d.IIdnivelProcesoNavigation)
                    .WithMany(p => p.TblEmpresaProcesos)
                    .HasForeignKey(d => d.IIdnivelProceso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresaProcesos_tblMultivalores");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblEmpresaProcesos)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresaProcesos_tblUsuarios");
            });

            modelBuilder.Entity<TblEmpresaRiesgoValoracion>(entity =>
            {
                entity.HasKey(e => e.IIdriesgoValoracion)
                    .HasName("PK_tblEmpresaProbabilidadImpacto");

                entity.ToTable("tblEmpresaRiesgoValoracion", "proceso");

                entity.Property(e => e.IIdriesgoValoracion).HasColumnName("iIDRiesgoValoracion");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IAlcanceMapa).HasColumnName("iAlcanceMapa");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IIdvaloracion).HasColumnName("iIDValoracion");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.IValorInferior).HasColumnName("iValorInferior");

                entity.Property(e => e.IValorSuperior).HasColumnName("iValorSuperior");

                entity.Property(e => e.IValoracionRiesgo).HasColumnName("iValoracionRiesgo");

                entity.Property(e => e.TColor)
                    .HasColumnName("tColor")
                    .HasMaxLength(50);

                entity.Property(e => e.TValoracion)
                    .IsRequired()
                    .HasColumnName("tValoracion")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblEmpresaRiesgoValoracion)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresaRiesgoValoracion_tblEmpresas");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblEmpresaRiesgoValoracion)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresaRiesgoValoracion_tblUsuarios");
            });

            modelBuilder.Entity<TblEmpresas>(entity =>
            {
                entity.HasKey(e => e.IIdempresa);

                entity.ToTable("tblEmpresas", "negocio");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaInicialArl)
                    .HasColumnName("dtFechaInicialARL")
                    .HasColumnType("date");

                entity.Property(e => e.DtFechaInicialCaja)
                    .HasColumnName("dtFechaInicialCaja")
                    .HasColumnType("date");

                entity.Property(e => e.DtFechaInicialCorredor)
                    .HasColumnName("dtFechaInicialCorredor")
                    .HasColumnType("date");

                entity.Property(e => e.DtFechaModificacion)
                    .HasColumnName("dtFechaModificacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdactividadEconomica1).HasColumnName("iIDActividadEconomica1");

                entity.Property(e => e.IIdactividadEconomica2).HasColumnName("iIDActividadEconomica2");

                entity.Property(e => e.IIdactividadEconomica3).HasColumnName("iIDActividadEconomica3");

                entity.Property(e => e.IIdarl).HasColumnName("iIDARL");

                entity.Property(e => e.IIdcajaCompensacion).HasColumnName("iIDCajaCompensacion");

                entity.Property(e => e.IIdcorredor).HasColumnName("iIDCorredor");

                entity.Property(e => e.IIdempresaGestora).HasColumnName("iIDEmpresaGestora");

                entity.Property(e => e.IIdtipoIdentificacion).HasColumnName("iIDTipoIdentificacion");

                entity.Property(e => e.IIdubicacion).HasColumnName("iIDUbicacion");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.IIdusuarioModificacion).HasColumnName("iIDUsuarioModificacion");

                entity.Property(e => e.IIdvendedor).HasColumnName("iIDVendedor");

                entity.Property(e => e.TDigitoVerificacion).HasColumnName("tDigitoVerificacion");

                entity.Property(e => e.TDireccion)
                    .HasColumnName("tDireccion")
                    .HasMaxLength(1200);

                entity.Property(e => e.TFax)
                    .HasColumnName("tFax")
                    .HasMaxLength(100);

                entity.Property(e => e.TNombreComercial)
                    .IsRequired()
                    .HasColumnName("tNombreComercial")
                    .HasMaxLength(400);

                entity.Property(e => e.TNumeroIdentificacion)
                    .IsRequired()
                    .HasColumnName("tNumeroIdentificacion")
                    .HasMaxLength(100);

                entity.Property(e => e.TRazonSocial)
                    .IsRequired()
                    .HasColumnName("tRazonSocial")
                    .HasMaxLength(510);

                entity.Property(e => e.TTelefonoPrincipal)
                    .HasColumnName("tTelefonoPrincipal")
                    .HasMaxLength(200);

                entity.Property(e => e.TTelefonoSecundario)
                    .HasColumnName("tTelefonoSecundario")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IIdtipoIdentificacionNavigation)
                    .WithMany(p => p.TblEmpresas)
                    .HasForeignKey(d => d.IIdtipoIdentificacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresas_tblMultivalores");
            });

            modelBuilder.Entity<TblEmpresasArls>(entity =>
            {
                entity.HasKey(e => new { e.IIdempresa, e.IIdarl });

                entity.ToTable("tblEmpresas-ARLs", "negocio");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IIdarl).HasColumnName("iIDARL");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DFechaInicio)
                    .HasColumnName("dFechaInicio")
                    .HasColumnType("date");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdusuarioCreador).HasColumnName("iIDUsuarioCreador");

                entity.HasOne(d => d.IIdarlNavigation)
                    .WithMany(p => p.TblEmpresasArls)
                    .HasForeignKey(d => d.IIdarl)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresas-ARLs_tblARLs");

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblEmpresasArls)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresas-ARLs_tblEmpresas");

                entity.HasOne(d => d.IIdusuarioCreadorNavigation)
                    .WithMany(p => p.TblEmpresasArls)
                    .HasForeignKey(d => d.IIdusuarioCreador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresas-ARLs_tblUsuarios");
            });

            modelBuilder.Entity<TblEmpresasCajasCompensacion>(entity =>
            {
                entity.HasKey(e => new { e.IIdempresa, e.IIdcajaCompensacion });

                entity.ToTable("tblEmpresas-CajasCompensacion", "negocio");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IIdcajaCompensacion).HasColumnName("iIDCajaCompensacion");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DFechaInicio)
                    .HasColumnName("dFechaInicio")
                    .HasColumnType("date");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdusuarioCreador).HasColumnName("iIDUsuarioCreador");

                entity.HasOne(d => d.IIdcajaCompensacionNavigation)
                    .WithMany(p => p.TblEmpresasCajasCompensacion)
                    .HasForeignKey(d => d.IIdcajaCompensacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresas-CajasCompensacion_tblCajasCompensacion");

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblEmpresasCajasCompensacion)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresas-CajasCompensacion_tblEmpresas");
            });

            modelBuilder.Entity<TblEmpresasCorredores>(entity =>
            {
                entity.HasKey(e => new { e.IIdempresa, e.IIdcorredor });

                entity.ToTable("tblEmpresas-Corredores", "negocio");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IIdcorredor).HasColumnName("iIDCorredor");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DFechaInicio)
                    .HasColumnName("dFechaInicio")
                    .HasColumnType("date");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdusuarioCreador).HasColumnName("iIDUsuarioCreador");

                entity.HasOne(d => d.IIdcorredorNavigation)
                    .WithMany(p => p.TblEmpresasCorredores)
                    .HasForeignKey(d => d.IIdcorredor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresas-Corredores_tblCorredores");

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblEmpresasCorredores)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresas-Corredores_tblEmpresas");

                entity.HasOne(d => d.IIdusuarioCreadorNavigation)
                    .WithMany(p => p.TblEmpresasCorredores)
                    .HasForeignKey(d => d.IIdusuarioCreador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresas-Corredores_tblUsuarios");
            });

            modelBuilder.Entity<TblEmpresasPacientes>(entity =>
            {
                entity.HasKey(e => e.IIdempresaPaciente);

                entity.ToTable("tblEmpresasPacientes", "Incapacidades");

                entity.Property(e => e.IIdempresaPaciente).HasColumnName("iIDEmpresaPaciente");

                entity.Property(e => e.TCiiun)
                    .IsRequired()
                    .HasColumnName("tCIIUN")
                    .HasMaxLength(20);

                entity.Property(e => e.TDireccion)
                    .IsRequired()
                    .HasColumnName("tDireccion")
                    .HasMaxLength(50);

                entity.Property(e => e.TEmail)
                    .IsRequired()
                    .HasColumnName("tEmail")
                    .HasMaxLength(200);

                entity.Property(e => e.TNit)
                    .IsRequired()
                    .HasColumnName("tNIT")
                    .HasMaxLength(20);

                entity.Property(e => e.TRazonSocial)
                    .IsRequired()
                    .HasColumnName("tRazonSocial")
                    .HasMaxLength(200);

                entity.Property(e => e.TTelefono)
                    .IsRequired()
                    .HasColumnName("tTelefono")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblEmpresasTerceros>(entity =>
            {
                entity.HasKey(e => e.IId)
                    .HasName("PK__TblEmpre__DC512D72840ED019");

                entity.HasIndex(e => e.TRazonSocial)
                    .HasName("UQ_RazonSocial")
                    .IsUnique();

                entity.Property(e => e.IId).HasColumnName("iID");

                entity.Property(e => e.IIdactividadEconomica).HasColumnName("iIDActividadEconomica");

                entity.Property(e => e.IIdtipoSociedad).HasColumnName("iIDTipoSociedad");

                entity.Property(e => e.INit).HasColumnName("iNIT");

                entity.Property(e => e.TDireccion)
                    .IsRequired()
                    .HasColumnName("tDireccion")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.TObjetoSocial)
                    .IsRequired()
                    .HasColumnName("tObjetoSocial")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.TRazonSocial)
                    .IsRequired()
                    .HasColumnName("tRazonSocial")
                    .HasMaxLength(700)
                    .IsUnicode(false);

                entity.HasOne(d => d.IIdactividadEconomicaNavigation)
                    .WithMany(p => p.TblEmpresasTerceros)
                    .HasForeignKey(d => d.IIdactividadEconomica)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_tblEmpresasTerceros_tblActividadEconomica");

                entity.HasOne(d => d.IIdtipoSociedadNavigation)
                    .WithMany(p => p.TblEmpresasTerceros)
                    .HasForeignKey(d => d.IIdtipoSociedad)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_tblEmpresasTerceros_tblTipoSociedadEmpresa");
            });

            modelBuilder.Entity<TblEmpresasVigencia>(entity =>
            {
                entity.HasKey(e => e.IIdempresaVigencia);

                entity.ToTable("tblEmpresasVigencia", "negocio");

                entity.Property(e => e.IIdempresaVigencia).HasColumnName("iIDEmpresaVigencia");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaDesde)
                    .HasColumnName("dtFechaDesde")
                    .HasColumnType("date");

                entity.Property(e => e.DtFechaHasta)
                    .HasColumnName("dtFechaHasta")
                    .HasColumnType("date");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IIdestadoVigencia).HasColumnName("iIDEstadoVigencia");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.IVigencia).HasColumnName("iVigencia");

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblEmpresasVigencia)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresasVigencia_tblEmpresas");

                entity.HasOne(d => d.IIdestadoVigenciaNavigation)
                    .WithMany(p => p.TblEmpresasVigencia)
                    .HasForeignKey(d => d.IIdestadoVigencia)
                    .HasConstraintName("FK_tblEmpresasVigencia_tblMultivalores");

                entity.HasOne(d => d.IIdusuarioCreacionNavigation)
                    .WithMany(p => p.TblEmpresasVigencia)
                    .HasForeignKey(d => d.IIdusuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmpresasVigencia_tblUsuarios");
            });

            modelBuilder.Entity<TblEntradasSalidas>(entity =>
            {
                entity.HasKey(e => e.IIdentradaSalida);

                entity.ToTable("tblEntradasSalidas", "proceso");

                entity.Property(e => e.IIdentradaSalida).HasColumnName("iIDEntradaSalida");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdareaProceso).HasColumnName("iIDAreaProceso");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IIdproceso).HasColumnName("iIDProceso");

                entity.Property(e => e.IIdsubtablaClaseOrigen).HasColumnName("iIDSubtablaClaseOrigen");

                entity.Property(e => e.IIdsubtablaPeriodicidad).HasColumnName("iIDSubtablaPeriodicidad");

                entity.Property(e => e.IIdsubtablaTipoEntradaSalidaProceso).HasColumnName("iIDSubtablaTipoEntradaSalidaProceso");

                entity.Property(e => e.IIdsubtablaTipoOrigen).HasColumnName("iIDSubtablaTipoOrigen");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.TDescripcion)
                    .IsRequired()
                    .HasColumnName("tDescripcion")
                    .HasMaxLength(300);

                entity.Property(e => e.TIdvalorClaseOrigen)
                    .HasColumnName("tIDValorClaseOrigen")
                    .HasMaxLength(100);

                entity.Property(e => e.TIdvalorPeriodicidad)
                    .IsRequired()
                    .HasColumnName("tIDValorPeriodicidad")
                    .HasMaxLength(100);

                entity.Property(e => e.TIdvalorTipoEntradaSalidaProceso)
                    .IsRequired()
                    .HasColumnName("tIDValorTipoEntradaSalidaProceso")
                    .HasMaxLength(100);

                entity.Property(e => e.TIdvalorTipoOrigen)
                    .IsRequired()
                    .HasColumnName("tIDValorTipoOrigen")
                    .HasMaxLength(100);

                entity.Property(e => e.TOrigenExterno)
                    .HasColumnName("tOrigenExterno")
                    .HasMaxLength(200);

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblEntradasSalidas)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEntradasSalidas_tblEmpresas");

                entity.HasOne(d => d.IIdprocesoNavigation)
                    .WithMany(p => p.TblEntradasSalidas)
                    .HasForeignKey(d => d.IIdproceso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEntradasSalidas_tblEmpresaProcesos");

                entity.HasOne(d => d.IIdusuarioCreacionNavigation)
                    .WithMany(p => p.TblEntradasSalidas)
                    .HasForeignKey(d => d.IIdusuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEntradasSalidas_tblUsuarios");
            });

            modelBuilder.Entity<TblEps>(entity =>
            {
                entity.HasKey(e => e.IIdeps);

                entity.ToTable("tblEPS", "negocio");

                entity.Property(e => e.IIdeps).HasColumnName("iIDEPS");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdtipoIdentificacion).HasColumnName("iIDTipoIdentificacion");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.TCodigoExterno)
                    .HasColumnName("tCodigoExterno")
                    .HasMaxLength(10);

                entity.Property(e => e.TDigitoVerificacion).HasColumnName("tDigitoVerificacion");

                entity.Property(e => e.TNombre)
                    .IsRequired()
                    .HasColumnName("tNombre")
                    .HasMaxLength(200);

                entity.Property(e => e.TNumeroIdentificacion)
                    .HasColumnName("tNumeroIdentificacion")
                    .HasMaxLength(200);

                entity.Property(e => e.TPathLogo)
                    .IsRequired()
                    .HasColumnName("tPathLogo")
                    .HasMaxLength(200);

                entity.HasOne(d => d.IIdtipoIdentificacionNavigation)
                    .WithMany(p => p.TblEps)
                    .HasForeignKey(d => d.IIdtipoIdentificacion)
                    .HasConstraintName("FK_tblEPS_tblEPS");

                entity.HasOne(d => d.IIdusuarioCreacionNavigation)
                    .WithMany(p => p.TblEps)
                    .HasForeignKey(d => d.IIdusuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEPS_tblUsuarios");
            });

            modelBuilder.Entity<TblEstadoAfiliacion>(entity =>
            {
                entity.HasKey(e => e.IId);

                entity.ToTable("tblEstadoAfiliacion", "Incapacidades");

                entity.Property(e => e.IId)
                    .HasColumnName("iID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.TNombre)
                    .IsRequired()
                    .HasColumnName("tNombre")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblEstandarNumerales>(entity =>
            {
                entity.HasKey(e => e.IIdnumeral);

                entity.ToTable("tblEstandarNumerales", "proceso");

                entity.Property(e => e.IIdnumeral).HasColumnName("iIDNumeral");

                entity.Property(e => e.TDescripcion)
                    .IsRequired()
                    .HasColumnName("tDescripcion")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<TblEstandarTipoPoliticas>(entity =>
            {
                entity.HasKey(e => e.IIdestandarTipoPolitica);

                entity.ToTable("tblEstandarTipoPoliticas", "negocio");

                entity.Property(e => e.IIdestandarTipoPolitica).HasColumnName("iIDEstandarTipoPolitica");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IIdestandar).HasColumnName("iIDEstandar");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TTipoPolitica)
                    .IsRequired()
                    .HasColumnName("tTipoPolitica")
                    .HasMaxLength(250);

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblEstandarTipoPoliticas)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEstandarTipoPoliticas_tblEmpresas");

                entity.HasOne(d => d.IIdestandarNavigation)
                    .WithMany(p => p.TblEstandarTipoPoliticas)
                    .HasForeignKey(d => d.IIdestandar)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEstandarTipoPoliticas_tblMultivalores");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblEstandarTipoPoliticas)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEstandarTipoPoliticas_tblUsuarios");
            });

            modelBuilder.Entity<TblEventosCalendario>(entity =>
            {
                entity.HasKey(e => e.IIdeventoCalendario);

                entity.ToTable("tblEventosCalendario", "negocio");

                entity.Property(e => e.IIdeventoCalendario).HasColumnName("iIDEventoCalendario");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaFin)
                    .HasColumnName("dtFechaFin")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaInicio)
                    .HasColumnName("dtFechaInicio")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaModificacion)
                    .HasColumnName("dtFechaModificacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdentidad).HasColumnName("iIDEntidad");

                entity.Property(e => e.IIdsubTablaTipoCalendario).HasColumnName("iIDSubTablaTipoCalendario");

                entity.Property(e => e.IIdusuarioAsignado).HasColumnName("iIDUsuarioAsignado");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.IIdusuarioModificacion).HasColumnName("iIDUsuarioModificacion");

                entity.Property(e => e.TAsunto).HasColumnName("tAsunto");

                entity.Property(e => e.TDescripcion).HasColumnName("tDescripcion");

                entity.Property(e => e.TIdvalorTipoCalendario)
                    .HasColumnName("tIDValorTipoCalendario")
                    .HasMaxLength(200);

                entity.Property(e => e.TLugar).HasColumnName("tLugar");
            });

            modelBuilder.Entity<TblEventosCalendarioParticipantes>(entity =>
            {
                entity.HasKey(e => e.IIdeventoCalendarioParticipante);

                entity.ToTable("tblEventosCalendarioParticipantes", "negocio");

                entity.Property(e => e.IIdeventoCalendarioParticipante).HasColumnName("iIDEventoCalendarioParticipante");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaModificacion)
                    .HasColumnName("dtFechaModificacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdeventoCalendario).HasColumnName("iIDEventoCalendario");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.IIdusuarioModificacion).HasColumnName("iIDUsuarioModificacion");

                entity.Property(e => e.TCorreoElectronico)
                    .HasColumnName("tCorreoElectronico")
                    .HasMaxLength(200);

                entity.HasOne(d => d.IIdeventoCalendarioNavigation)
                    .WithMany(p => p.TblEventosCalendarioParticipantes)
                    .HasForeignKey(d => d.IIdeventoCalendario)
                    .HasConstraintName("FK_tblEventosCalendarioParticipantes_tblEventosCalendario");
            });

            modelBuilder.Entity<TblExtintoresTipo>(entity =>
            {
                entity.HasKey(e => e.IIdextintorTipo);

                entity.ToTable("tblExtintoresTipo", "Equipos");

                entity.Property(e => e.IIdextintorTipo).HasColumnName("iIDExtintorTipo");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IAgente).HasColumnName("iAgente");

                entity.Property(e => e.ICapacidad).HasColumnName("iCapacidad");

                entity.Property(e => e.IUnidad).HasColumnName("iUnidad");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TAgente)
                    .IsRequired()
                    .HasColumnName("tAgente")
                    .HasMaxLength(50);

                entity.Property(e => e.TCapacidad)
                    .IsRequired()
                    .HasColumnName("tCapacidad")
                    .HasMaxLength(50);

                entity.Property(e => e.TUnidad)
                    .IsRequired()
                    .HasColumnName("tUnidad")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblExtintoresTipo)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblExtintoresTipo_tblUsuarios");
            });

            modelBuilder.Entity<TblFormatos>(entity =>
            {
                entity.HasKey(e => e.IIdformato)
                    .HasName("PK_administracion.tblFormatos");

                entity.ToTable("tblFormatos", "negocio");

                entity.Property(e => e.IIdformato).HasColumnName("iIDFormato");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaModificacion)
                    .HasColumnName("dtFechaModificacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdclaseFormato).HasColumnName("iIDClaseFormato");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.IIdusuarioModificacion).HasColumnName("iIDUsuarioModificacion");

                entity.Property(e => e.IVersion).HasColumnName("iVersion");

                entity.Property(e => e.TContenido)
                    .IsRequired()
                    .HasColumnName("tContenido")
                    .HasColumnType("ntext");

                entity.Property(e => e.TDescripcion)
                    .IsRequired()
                    .HasColumnName("tDescripcion")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IIdclaseFormatoNavigation)
                    .WithMany(p => p.TblFormatos)
                    .HasForeignKey(d => d.IIdclaseFormato)
                    .HasConstraintName("FK_tblFormatos_tblFormatos");

                entity.HasOne(d => d.IIdusuarioCreacionNavigation)
                    .WithMany(p => p.TblFormatos)
                    .HasForeignKey(d => d.IIdusuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblFormatos_tblUsuarios");
            });

            modelBuilder.Entity<TblFormularios>(entity =>
            {
                entity.HasKey(e => e.IIdformulario);

                entity.ToTable("tblFormularios", "encuestas");

                entity.Property(e => e.IIdformulario).HasColumnName("iIDFormulario");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DTamanoArchivo)
                    .HasColumnName("dTamanoArchivo")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaModificacion)
                    .HasColumnName("dtFechaModificacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.IIdusuarioModificacion).HasColumnName("iIDUsuarioModificacion");

                entity.Property(e => e.TDirectorio)
                    .HasColumnName("tDirectorio")
                    .HasMaxLength(200);

                entity.Property(e => e.TFormulario)
                    .IsRequired()
                    .HasColumnName("tFormulario");

                entity.Property(e => e.TNombreArchivo)
                    .HasColumnName("tNombreArchivo")
                    .HasMaxLength(200);

                entity.Property(e => e.TNombreArchivoOriginal)
                    .HasColumnName("tNombreArchivoOriginal")
                    .HasMaxLength(200);

                entity.Property(e => e.TNombreFormulario)
                    .IsRequired()
                    .HasColumnName("tNombreFormulario")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IIdusuarioCreacionNavigation)
                    .WithMany(p => p.TblFormulariosIIdusuarioCreacionNavigation)
                    .HasForeignKey(d => d.IIdusuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblFormularios_tblUsuarios");

                entity.HasOne(d => d.IIdusuarioModificacionNavigation)
                    .WithMany(p => p.TblFormulariosIIdusuarioModificacionNavigation)
                    .HasForeignKey(d => d.IIdusuarioModificacion)
                    .HasConstraintName("FK_tblFormularios_tblUsuarios1");
            });

            modelBuilder.Entity<TblFormulariosRespuestas>(entity =>
            {
                entity.HasKey(e => e.IIdformularioRespuesta);

                entity.ToTable("tblFormulariosRespuestas", "encuestas");

                entity.Property(e => e.IIdformularioRespuesta).HasColumnName("iIDFormularioRespuesta");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdformularioRespuestaEncabezado).HasColumnName("iIDFormularioRespuestaEncabezado");

                entity.Property(e => e.TCampo)
                    .IsRequired()
                    .HasColumnName("tCampo")
                    .HasMaxLength(50);

                entity.Property(e => e.TRespuesta)
                    .HasColumnName("tRespuesta")
                    .HasMaxLength(200);

                entity.HasOne(d => d.IIdformularioRespuestaEncabezadoNavigation)
                    .WithMany(p => p.TblFormulariosRespuestas)
                    .HasForeignKey(d => d.IIdformularioRespuestaEncabezado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblFormulariosRespuestas_tblFormulariosRespuestasEncabezados");
            });

            modelBuilder.Entity<TblFormulariosRespuestasEncabezados>(entity =>
            {
                entity.HasKey(e => e.IIdformularioRespuestaEncabezado);

                entity.ToTable("tblFormulariosRespuestasEncabezados", "encuestas");

                entity.Property(e => e.IIdformularioRespuestaEncabezado).HasColumnName("iIDFormularioRespuestaEncabezado");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdformulario).HasColumnName("iIDFormulario");

                entity.Property(e => e.TDireccionIp)
                    .IsRequired()
                    .HasColumnName("tDireccionIP")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IIdformularioNavigation)
                    .WithMany(p => p.TblFormulariosRespuestasEncabezados)
                    .HasForeignKey(d => d.IIdformulario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblFormulariosRespuestasEncabezados_tblFormularios");
            });

            modelBuilder.Entity<TblIdiomas>(entity =>
            {
                entity.HasKey(e => e.IIdidioma);

                entity.ToTable("tblIdiomas", "administracion");

                entity.Property(e => e.IIdidioma).HasColumnName("iIDIdioma");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.TCodigo)
                    .HasColumnName("tCodigo")
                    .HasMaxLength(200);

                entity.Property(e => e.TCodigoPais)
                    .HasColumnName("tCodigoPais")
                    .HasMaxLength(200);

                entity.Property(e => e.TNombre)
                    .HasColumnName("tNombre")
                    .HasMaxLength(200);

                entity.Property(e => e.TPais)
                    .HasColumnName("tPais")
                    .HasMaxLength(200);

                entity.HasOne(d => d.IIdusuarioCreacionNavigation)
                    .WithMany(p => p.TblIdiomas)
                    .HasForeignKey(d => d.IIdusuarioCreacion)
                    .HasConstraintName("FK_tblIdiomas_tblUsuarios");
            });

            modelBuilder.Entity<TblIndicadoresDetalle>(entity =>
            {
                entity.HasKey(e => e.IIdindicadorDetalle)
                    .HasName("PK_tblIndicadores");

                entity.ToTable("tblIndicadoresDetalle", "proceso");

                entity.Property(e => e.IIdindicadorDetalle).HasColumnName("iIDIndicadorDetalle");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdmatrizIndicador).HasColumnName("iIDMatrizIndicador");

                entity.Property(e => e.IIdresponsableAnalisis).HasColumnName("iIDResponsableAnalisis");

                entity.Property(e => e.IIdresponsableInformacion).HasColumnName("iIDResponsableInformacion");

                entity.Property(e => e.IIdsubtablaFrecuenciaAnalisis).HasColumnName("iIDSubtablaFrecuenciaAnalisis");

                entity.Property(e => e.IIdsubtablaRecoleccionPeriodicidad).HasColumnName("iIDSubtablaRecoleccionPeriodicidad");

                entity.Property(e => e.IIdsubtablaTipoIndicador).HasColumnName("iIDSubtablaTipoIndicador");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.TDescripcion)
                    .IsRequired()
                    .HasColumnName("tDescripcion")
                    .HasMaxLength(200);

                entity.Property(e => e.TFormula)
                    .IsRequired()
                    .HasColumnName("tFormula")
                    .HasMaxLength(200);

                entity.Property(e => e.TIdvalorFrecuenciaAnalisis)
                    .IsRequired()
                    .HasColumnName("tIDValorFrecuenciaAnalisis")
                    .HasMaxLength(100);

                entity.Property(e => e.TIdvalorRecoleccionPeriodicidad)
                    .IsRequired()
                    .HasColumnName("tIDValorRecoleccionPeriodicidad")
                    .HasMaxLength(100);

                entity.Property(e => e.TIdvalorTipoIndicador)
                    .IsRequired()
                    .HasColumnName("tIDValorTipoIndicador")
                    .HasMaxLength(100);

                entity.Property(e => e.TMeta)
                    .IsRequired()
                    .HasColumnName("tMeta")
                    .HasMaxLength(200);

                entity.Property(e => e.TNombreIndicador)
                    .IsRequired()
                    .HasColumnName("tNombreIndicador")
                    .HasMaxLength(100);

                entity.Property(e => e.TOrigenDatos)
                    .IsRequired()
                    .HasColumnName("tOrigenDatos")
                    .HasMaxLength(200);

                entity.HasOne(d => d.IIdresponsableAnalisisNavigation)
                    .WithMany(p => p.TblIndicadoresDetalleIIdresponsableAnalisisNavigation)
                    .HasForeignKey(d => d.IIdresponsableAnalisis)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblIndicadores_tblCargos1");

                entity.HasOne(d => d.IIdresponsableInformacionNavigation)
                    .WithMany(p => p.TblIndicadoresDetalleIIdresponsableInformacionNavigation)
                    .HasForeignKey(d => d.IIdresponsableInformacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblIndicadores_tblCargos");

                entity.HasOne(d => d.IIdusuarioCreacionNavigation)
                    .WithMany(p => p.TblIndicadoresDetalle)
                    .HasForeignKey(d => d.IIdusuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblIndicadores_tblUsuarios");
            });

            modelBuilder.Entity<TblIndicadoresDetalleHistorico>(entity =>
            {
                entity.HasKey(e => e.IIdindicadorDetalleHistorico);

                entity.ToTable("tblIndicadoresDetalleHistorico", "proceso");

                entity.Property(e => e.IIdindicadorDetalleHistorico).HasColumnName("iIDIndicadorDetalleHistorico");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdindicadorDetalle).HasColumnName("iIDIndicadorDetalle");

                entity.Property(e => e.IIdmatrizIndicador).HasColumnName("iIDMatrizIndicador");

                entity.Property(e => e.IIdresponsableAnalisis).HasColumnName("iIDResponsableAnalisis");

                entity.Property(e => e.IIdresponsableInformacion).HasColumnName("iIDResponsableInformacion");

                entity.Property(e => e.IIdsubtablaFrecuenciaAnalisis).HasColumnName("iIDSubtablaFrecuenciaAnalisis");

                entity.Property(e => e.IIdsubtablaRecoleccionPeriodicidad).HasColumnName("iIDSubtablaRecoleccionPeriodicidad");

                entity.Property(e => e.IIdsubtablaTipoIndicador).HasColumnName("iIDSubtablaTipoIndicador");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.IVersion).HasColumnName("iVersion");

                entity.Property(e => e.TDescripcion)
                    .IsRequired()
                    .HasColumnName("tDescripcion")
                    .HasMaxLength(200);

                entity.Property(e => e.TFormula)
                    .IsRequired()
                    .HasColumnName("tFormula")
                    .HasMaxLength(200);

                entity.Property(e => e.TIdvalorFrecuenciaAnalisis)
                    .IsRequired()
                    .HasColumnName("tIDValorFrecuenciaAnalisis")
                    .HasMaxLength(100);

                entity.Property(e => e.TIdvalorRecoleccionPeriodicidad)
                    .IsRequired()
                    .HasColumnName("tIDValorRecoleccionPeriodicidad")
                    .HasMaxLength(100);

                entity.Property(e => e.TIdvalorTipoIndicador)
                    .IsRequired()
                    .HasColumnName("tIDValorTipoIndicador")
                    .HasMaxLength(100);

                entity.Property(e => e.TMeta)
                    .IsRequired()
                    .HasColumnName("tMeta")
                    .HasMaxLength(200);

                entity.Property(e => e.TNombreIndicador)
                    .IsRequired()
                    .HasColumnName("tNombreIndicador")
                    .HasMaxLength(100);

                entity.Property(e => e.TOrigenDatos)
                    .IsRequired()
                    .HasColumnName("tOrigenDatos")
                    .HasMaxLength(200);

                entity.HasOne(d => d.IIdindicadorDetalleNavigation)
                    .WithMany(p => p.TblIndicadoresDetalleHistorico)
                    .HasForeignKey(d => d.IIdindicadorDetalle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblIndicadoresDetalleHistorico_tblIndicadoresDetalle");
            });

            modelBuilder.Entity<TblIndicadoresMatriz>(entity =>
            {
                entity.HasKey(e => e.IIdmatrizIndicador)
                    .HasName("PK_tblMatrizIndicadores");

                entity.ToTable("tblIndicadoresMatriz", "proceso");

                entity.Property(e => e.IIdmatrizIndicador).HasColumnName("iIDMatrizIndicador");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaEmision)
                    .HasColumnName("dtFechaEmision")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdempleadoAprobo).HasColumnName("iIDEmpleadoAprobo");

                entity.Property(e => e.IIdempleadoElaboro).HasColumnName("iIDEmpleadoElaboro");

                entity.Property(e => e.IIdempleadoReviso).HasColumnName("iIDEmpleadoReviso");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IIdproceso).HasColumnName("iIDProceso");

                entity.Property(e => e.IIdsubtablaEstadoIndicadoresMatriz).HasColumnName("iIDSubtablaEstadoIndicadoresMatriz");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.IVersion).HasColumnName("iVersion");

                entity.Property(e => e.TIdvalorEstadoIndicadoresMatriz)
                    .IsRequired()
                    .HasColumnName("tIDValorEstadoIndicadoresMatriz")
                    .HasMaxLength(100);

                entity.Property(e => e.TObjetivo)
                    .IsRequired()
                    .HasColumnName("tObjetivo")
                    .HasMaxLength(200);

                entity.HasOne(d => d.IIdempleadoAproboNavigation)
                    .WithMany(p => p.TblIndicadoresMatrizIIdempleadoAproboNavigation)
                    .HasForeignKey(d => d.IIdempleadoAprobo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblMatrizIndicadores_tblEmpleados2");

                entity.HasOne(d => d.IIdempleadoElaboroNavigation)
                    .WithMany(p => p.TblIndicadoresMatrizIIdempleadoElaboroNavigation)
                    .HasForeignKey(d => d.IIdempleadoElaboro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblMatrizIndicadores_tblEmpleados");

                entity.HasOne(d => d.IIdempleadoRevisoNavigation)
                    .WithMany(p => p.TblIndicadoresMatrizIIdempleadoRevisoNavigation)
                    .HasForeignKey(d => d.IIdempleadoReviso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblMatrizIndicadores_tblEmpleados1");

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblIndicadoresMatriz)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblMatrizIndicadores_tblEmpresas");

                entity.HasOne(d => d.IIdprocesoNavigation)
                    .WithMany(p => p.TblIndicadoresMatriz)
                    .HasForeignKey(d => d.IIdproceso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblMatrizIndicadores_tblEmpresaProcesos");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblIndicadoresMatriz)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblMatrizIndicadores_tblUsuarios");
            });

            modelBuilder.Entity<TblIndicadoresMatrizHistorico>(entity =>
            {
                entity.HasKey(e => e.IIdmatrizIndicadorHistorico)
                    .HasName("PK_tblMatrizIndicadoresHistorico");

                entity.ToTable("tblIndicadoresMatrizHistorico", "proceso");

                entity.Property(e => e.IIdmatrizIndicadorHistorico).HasColumnName("iIDMatrizIndicadorHistorico");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaEmision)
                    .HasColumnName("dtFechaEmision")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdempleadoAprobo).HasColumnName("iIDEmpleadoAprobo");

                entity.Property(e => e.IIdempleadoElaboro).HasColumnName("iIDEmpleadoElaboro");

                entity.Property(e => e.IIdempleadoReviso).HasColumnName("iIDEmpleadoReviso");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IIdmatrizIndicador).HasColumnName("iIDMatrizIndicador");

                entity.Property(e => e.IIdproceso).HasColumnName("iIDProceso");

                entity.Property(e => e.IIdsubtablaEstadoIndicadoresMatriz).HasColumnName("iIDSubtablaEstadoIndicadoresMatriz");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.IVersion).HasColumnName("iVersion");

                entity.Property(e => e.TIdvalorEstadoIndicadoresMatriz)
                    .IsRequired()
                    .HasColumnName("tIDValorEstadoIndicadoresMatriz")
                    .HasMaxLength(100);

                entity.Property(e => e.TObjetivo)
                    .IsRequired()
                    .HasColumnName("tObjetivo")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<TblIndicadoresSeguimiento>(entity =>
            {
                entity.HasKey(e => e.IIdindicadorSeguimiento);

                entity.ToTable("tblIndicadoresSeguimiento", "proceso");

                entity.Property(e => e.IIdindicadorSeguimiento).HasColumnName("iIDIndicadorSeguimiento");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdindicadorDetalle).HasColumnName("iIDIndicadorDetalle");

                entity.Property(e => e.IIdsubtablaRequierePlanAccion).HasColumnName("iIDSubtablaRequierePlanAccion");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.IResultado).HasColumnName("iResultado");

                entity.Property(e => e.TAnalisis)
                    .IsRequired()
                    .HasColumnName("tAnalisis")
                    .HasMaxLength(200);

                entity.Property(e => e.TIdvalorRequierePlanAccion)
                    .IsRequired()
                    .HasColumnName("tIDValorRequierePlanAccion")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IIdindicadorDetalleNavigation)
                    .WithMany(p => p.TblIndicadoresSeguimiento)
                    .HasForeignKey(d => d.IIdindicadorDetalle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblIndicadoresSeguimiento_tblIndicadoresDetalle");
            });

            modelBuilder.Entity<TblInspeccionExtintoresDetalle>(entity =>
            {
                entity.HasKey(e => e.IIdinspeccionExtintorDetalle);

                entity.ToTable("tblInspeccionExtintoresDetalle", "Inspecciones");

                entity.Property(e => e.IIdinspeccionExtintorDetalle).HasColumnName("iIDInspeccionExtintorDetalle");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.BMedidaIntervencion).HasColumnName("bMedidaIntervencion");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaProximaRecarga)
                    .HasColumnName("dtFechaProximaRecarga")
                    .HasColumnType("date");

                entity.Property(e => e.DtFechaProximoMtto)
                    .HasColumnName("dtFechaProximoMtto")
                    .HasColumnType("date");

                entity.Property(e => e.DtFechaUltimaRecarga)
                    .HasColumnName("dtFechaUltimaRecarga")
                    .HasColumnType("date");

                entity.Property(e => e.DtFechaUltimoMtto)
                    .HasColumnName("dtFechaUltimoMtto")
                    .HasColumnType("date");

                entity.Property(e => e.IIdarea).HasColumnName("iIDArea");

                entity.Property(e => e.IIdextintorTipo).HasColumnName("iIDExtintorTipo");

                entity.Property(e => e.IIdinspeccion).HasColumnName("iIDInspeccion");

                entity.Property(e => e.IIdsubtablaAccesoExtintor).HasColumnName("iIDSubtablaAccesoExtintor");

                entity.Property(e => e.IIdsubtablaSenalizacionExtintor).HasColumnName("iIDSubtablaSenalizacionExtintor");

                entity.Property(e => e.IIdsubtablaUbicacionExtintor).HasColumnName("iIDSubtablaUbicacionExtintor");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TCodigoInterno)
                    .IsRequired()
                    .HasColumnName("tCodigoInterno")
                    .HasMaxLength(100);

                entity.Property(e => e.TIdvalorAccesoExtintor)
                    .IsRequired()
                    .HasColumnName("tIDValorAccesoExtintor")
                    .HasMaxLength(100);

                entity.Property(e => e.TIdvalorSenalizacionExtintor)
                    .IsRequired()
                    .HasColumnName("tIDValorSenalizacionExtintor")
                    .HasMaxLength(100);

                entity.Property(e => e.TIdvalorUbicacionExtintor)
                    .IsRequired()
                    .HasColumnName("tIDValorUbicacionExtintor")
                    .HasMaxLength(100);

                entity.Property(e => e.TObservaciones)
                    .IsRequired()
                    .HasColumnName("tObservaciones")
                    .HasMaxLength(500);

                entity.HasOne(d => d.IIdareaNavigation)
                    .WithMany(p => p.TblInspeccionExtintoresDetalle)
                    .HasForeignKey(d => d.IIdarea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblInspeccionExtintoresDetalle_tblEmpresaArea");

                entity.HasOne(d => d.IIdextintorTipoNavigation)
                    .WithMany(p => p.TblInspeccionExtintoresDetalle)
                    .HasForeignKey(d => d.IIdextintorTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblInspeccionExtintores_tblExtintoresTipo");

                entity.HasOne(d => d.IIdinspeccionNavigation)
                    .WithMany(p => p.TblInspeccionExtintoresDetalle)
                    .HasForeignKey(d => d.IIdinspeccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblInspeccionExtintoresDetalle_tblInspeccionExtintores");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblInspeccionExtintoresDetalle)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblInspeccionExtintores_tblUsuarios");
            });

            modelBuilder.Entity<TblInspeccionExtintoresDetalleMtto>(entity =>
            {
                entity.HasKey(e => e.IIdinspeccionExtintorDetalleMtto)
                    .HasName("PK_tblInspeccionExtintoresMtto");

                entity.ToTable("tblInspeccionExtintoresDetalleMtto", "Inspecciones");

                entity.Property(e => e.IIdinspeccionExtintorDetalleMtto).HasColumnName("iIDInspeccionExtintorDetalleMtto");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdinspeccionExtintorDetalle).HasColumnName("iIDInspeccionExtintorDetalle");

                entity.Property(e => e.IIdsubtablaParteExtintor).HasColumnName("iIDSubtablaParteExtintor");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TIdvalorParteExtintor)
                    .IsRequired()
                    .HasColumnName("tIDValorParteExtintor")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblInspeccionExtintoresDetalleMtto)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblInspeccionExtintoresMtto_tblUsuarios");
            });

            modelBuilder.Entity<TblInspecciones>(entity =>
            {
                entity.HasKey(e => e.IIdinspeccion)
                    .HasName("PK_tblInspeccionExtintores");

                entity.ToTable("tblInspecciones", "Inspecciones");

                entity.Property(e => e.IIdinspeccion).HasColumnName("iIDInspeccion");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaInspeccion)
                    .HasColumnName("dtFechaInspeccion")
                    .HasColumnType("date");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IIdinspector).HasColumnName("iIDInspector");

                entity.Property(e => e.IIdsubtablaTipoInspeccion).HasColumnName("iIDSubtablaTipoInspeccion");

                entity.Property(e => e.IIdsubtablaTipoInspector).HasColumnName("iIDSubtablaTipoInspector");

                entity.Property(e => e.IIdtarea).HasColumnName("iIDTarea");

                entity.Property(e => e.IIdvigencia).HasColumnName("iIDVigencia");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TIdvalorTipoInspeccion)
                    .IsRequired()
                    .HasColumnName("tIDValorTipoInspeccion")
                    .HasMaxLength(100);

                entity.Property(e => e.TIdvalorTipoInspector)
                    .IsRequired()
                    .HasColumnName("tIDValorTipoInspector")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblInspecciones)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblInspeccionExtintores_tblEmpresas");

                entity.HasOne(d => d.IIdtareaNavigation)
                    .WithMany(p => p.TblInspecciones)
                    .HasForeignKey(d => d.IIdtarea)
                    .HasConstraintName("FK_tblInspeccionExtintores_tblTareas");

                entity.HasOne(d => d.IIdvigenciaNavigation)
                    .WithMany(p => p.TblInspecciones)
                    .HasForeignKey(d => d.IIdvigencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblInspeccionExtintores_tblEmpresasVigencia");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblInspecciones)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblInspeccionExtintores_tblUsuarios1");
            });

            modelBuilder.Entity<TblInspeccionesPrograma>(entity =>
            {
                entity.HasKey(e => e.IIdinspeccionPrograma);

                entity.ToTable("tblInspeccionesPrograma", "negocio");

                entity.Property(e => e.IIdinspeccionPrograma).HasColumnName("iIDInspeccionPrograma");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.BTipoResponsable).HasColumnName("bTipoResponsable");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaInspeccion)
                    .HasColumnName("dtFechaInspeccion")
                    .HasColumnType("date");

                entity.Property(e => e.IIdarea).HasColumnName("iIDArea");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IIdresponsable).HasColumnName("iIDResponsable");

                entity.Property(e => e.IIdsubtablaTipoInspeccion).HasColumnName("iIDSubtablaTipoInspeccion");

                entity.Property(e => e.IIdtarea).HasColumnName("iIDTarea");

                entity.Property(e => e.IIdvigencia).HasColumnName("iIDVigencia");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TIdvalorTipoInspeccion)
                    .IsRequired()
                    .HasColumnName("tIDValorTipoInspeccion")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IIdareaNavigation)
                    .WithMany(p => p.TblInspeccionesPrograma)
                    .HasForeignKey(d => d.IIdarea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblInspeccionesPrograma_tblEmpresaArea");

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblInspeccionesPrograma)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblInspeccionesPrograma_tblEmpresas");

                entity.HasOne(d => d.IIdtareaNavigation)
                    .WithMany(p => p.TblInspeccionesPrograma)
                    .HasForeignKey(d => d.IIdtarea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblInspeccionesPrograma_tblTareas");

                entity.HasOne(d => d.IIdvigenciaNavigation)
                    .WithMany(p => p.TblInspeccionesPrograma)
                    .HasForeignKey(d => d.IIdvigencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblInspeccionesPrograma_tblEmpresasVigencia");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblInspeccionesPrograma)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblInspeccionesPrograma_tblUsuarios");
            });

            modelBuilder.Entity<TblInstalacionElectricaAlumbrado>(entity =>
            {
                entity.HasKey(e => e.IIdalumbrado);

                entity.ToTable("tblInstalacionElectricaAlumbrado", "Inspecciones");

                entity.Property(e => e.IIdalumbrado).HasColumnName("iIDAlumbrado");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdarea).HasColumnName("iIDArea");

                entity.Property(e => e.IIdinspeccion).HasColumnName("iIDInspeccion");

                entity.Property(e => e.IIdsubtablaEstadoLuminarias).HasColumnName("iIDSubtablaEstadoLuminarias");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TCantidad)
                    .IsRequired()
                    .HasColumnName("tCantidad")
                    .HasMaxLength(100);

                entity.Property(e => e.TIdvalorEstadoLuminarias)
                    .IsRequired()
                    .HasColumnName("tIDValorEstadoLuminarias")
                    .HasMaxLength(100);

                entity.Property(e => e.TObservaciones)
                    .HasColumnName("tObservaciones")
                    .HasMaxLength(200);

                entity.Property(e => e.TPotencia)
                    .IsRequired()
                    .HasColumnName("tPotencia")
                    .HasMaxLength(100);

                entity.Property(e => e.TTipoLampara)
                    .IsRequired()
                    .HasColumnName("tTipoLampara")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IIdareaNavigation)
                    .WithMany(p => p.TblInstalacionElectricaAlumbrado)
                    .HasForeignKey(d => d.IIdarea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblInstalacionElectricaAlumbrado_tblEmpresaArea");

                entity.HasOne(d => d.IIdinspeccionNavigation)
                    .WithMany(p => p.TblInstalacionElectricaAlumbrado)
                    .HasForeignKey(d => d.IIdinspeccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblInstalacionElectricaAlumbrado_tblInspecciones");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblInstalacionElectricaAlumbrado)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblInstalacionElectricaAlumbrado_tblUsuarios");
            });

            modelBuilder.Entity<TblInstalacionElectricaCircuitos>(entity =>
            {
                entity.HasKey(e => e.IIdcircuito);

                entity.ToTable("tblInstalacionElectricaCircuitos", "Inspecciones");

                entity.Property(e => e.IIdcircuito).HasColumnName("iIDCircuito");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdarea).HasColumnName("iIDArea");

                entity.Property(e => e.IIdinspeccion).HasColumnName("iIDInspeccion");

                entity.Property(e => e.IIdsubtablaEstadoProteccion).HasColumnName("iIDSubtablaEstadoProteccion");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TCapacidadAcometida)
                    .IsRequired()
                    .HasColumnName("tCapacidadAcometida")
                    .HasMaxLength(100);

                entity.Property(e => e.TCorrienteNominal)
                    .IsRequired()
                    .HasColumnName("tCorrienteNominal")
                    .HasMaxLength(100);

                entity.Property(e => e.TTablero)
                    .IsRequired()
                    .HasColumnName("tTablero")
                    .HasMaxLength(100);

                entity.Property(e => e.TTipoProteccion)
                    .IsRequired()
                    .HasColumnName("tTipoProteccion")
                    .HasMaxLength(100);

                entity.Property(e => e.TValorEstadoProteccion)
                    .IsRequired()
                    .HasColumnName("tValorEstadoProteccion")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IIdareaNavigation)
                    .WithMany(p => p.TblInstalacionElectricaCircuitos)
                    .HasForeignKey(d => d.IIdarea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblInstalacionElectricaCircuitos_tblEmpresaArea");

                entity.HasOne(d => d.IIdinspeccionNavigation)
                    .WithMany(p => p.TblInstalacionElectricaCircuitos)
                    .HasForeignKey(d => d.IIdinspeccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblInstalacionElectricaCircuitos_tblInspecciones");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblInstalacionElectricaCircuitos)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblInstalacionElectricaCircuitos_tblUsuarios");
            });

            modelBuilder.Entity<TblInstalacionElectricaInterruptores>(entity =>
            {
                entity.HasKey(e => e.IIdinterruptor);

                entity.ToTable("tblInstalacionElectricaInterruptores", "Inspecciones");

                entity.Property(e => e.IIdinterruptor).HasColumnName("iIDInterruptor");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.BFunciona).HasColumnName("bFunciona");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdarea).HasColumnName("iIDArea");

                entity.Property(e => e.IIdinspeccion).HasColumnName("iIDInspeccion");

                entity.Property(e => e.IIdsubtablaEstadoInterruptor).HasColumnName("iIDSubtablaEstadoInterruptor");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TCalibre)
                    .IsRequired()
                    .HasColumnName("tCalibre")
                    .HasMaxLength(100);

                entity.Property(e => e.TCantidad)
                    .IsRequired()
                    .HasColumnName("tCantidad")
                    .HasMaxLength(100);

                entity.Property(e => e.TIdvalorEstadoInterruptor)
                    .IsRequired()
                    .HasColumnName("tIDValorEstadoInterruptor")
                    .HasMaxLength(100);

                entity.Property(e => e.TObservaciones)
                    .HasColumnName("tObservaciones")
                    .HasMaxLength(200);

                entity.HasOne(d => d.IIdareaNavigation)
                    .WithMany(p => p.TblInstalacionElectricaInterruptores)
                    .HasForeignKey(d => d.IIdarea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblInstalacionElectricaInterruptores_tblEmpresaArea");

                entity.HasOne(d => d.IIdinspeccionNavigation)
                    .WithMany(p => p.TblInstalacionElectricaInterruptores)
                    .HasForeignKey(d => d.IIdinspeccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblInstalacionElectricaInterruptores_tblInspecciones");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblInstalacionElectricaInterruptores)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblInstalacionElectricaInterruptores_tblUsuarios");
            });

            modelBuilder.Entity<TblInstalacionElectricaTomas>(entity =>
            {
                entity.HasKey(e => e.IIdtoma);

                entity.ToTable("tblInstalacionElectricaTomas", "Inspecciones");

                entity.Property(e => e.IIdtoma).HasColumnName("iIDToma");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.BFunciona).HasColumnName("bFunciona");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdarea).HasColumnName("iIDArea");

                entity.Property(e => e.IIdinspeccion).HasColumnName("iIDInspeccion");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TCantidad)
                    .IsRequired()
                    .HasColumnName("tCantidad")
                    .HasMaxLength(100);

                entity.Property(e => e.TObservaciones)
                    .HasColumnName("tObservaciones")
                    .HasMaxLength(200);

                entity.Property(e => e.TPotencia)
                    .IsRequired()
                    .HasColumnName("tPotencia")
                    .HasMaxLength(100);

                entity.Property(e => e.TTipo)
                    .IsRequired()
                    .HasColumnName("tTipo")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IIdareaNavigation)
                    .WithMany(p => p.TblInstalacionElectricaTomas)
                    .HasForeignKey(d => d.IIdarea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblInstalacionElectricaTomas_tblEmpresaArea");

                entity.HasOne(d => d.IIdinspeccionNavigation)
                    .WithMany(p => p.TblInstalacionElectricaTomas)
                    .HasForeignKey(d => d.IIdinspeccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblInstalacionElectricaTomas_tblInspecciones");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblInstalacionElectricaTomas)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblInstalacionElectricaTomas_tblUsuarios");
            });

            modelBuilder.Entity<TblInventarioEmpresas>(entity =>
            {
                entity.HasKey(e => e.IIdinventarioEmpresas);

                entity.ToTable("tblInventarioEmpresas", "recobro");

                entity.Property(e => e.IIdinventarioEmpresas)
                    .HasColumnName("iIDInventarioEmpresas")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<TblIps>(entity =>
            {
                entity.HasKey(e => e.IIdips);

                entity.ToTable("tblIPS", "negocio");

                entity.Property(e => e.IIdips).HasColumnName("iIDIPS");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.ICodigoHabilitacion).HasColumnName("iCodigoHabilitacion");

                entity.Property(e => e.IIdtipoIdentificacion).HasColumnName("iIDTipoIdentificacion");

                entity.Property(e => e.IIdubicacion).HasColumnName("iIDUbicacion");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.ITipoIps).HasColumnName("iTipoIPS");

                entity.Property(e => e.TCodigoExterno)
                    .HasColumnName("tCodigoExterno")
                    .HasMaxLength(20);

                entity.Property(e => e.TDigitoVerificacion).HasColumnName("tDigitoVerificacion");

                entity.Property(e => e.TDireccion)
                    .HasColumnName("tDireccion")
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.TEmail)
                    .HasColumnName("tEmail")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.TNombre)
                    .IsRequired()
                    .HasColumnName("tNombre")
                    .HasMaxLength(200);

                entity.Property(e => e.TNumeroIdentificacion)
                    .HasColumnName("tNumeroIdentificacion")
                    .HasMaxLength(100);

                entity.Property(e => e.TPathLogo)
                    .IsRequired()
                    .HasColumnName("tPathLogo")
                    .HasMaxLength(200);

                entity.Property(e => e.TTelefono)
                    .HasColumnName("tTelefono")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.IIdtipoIdentificacionNavigation)
                    .WithMany(p => p.TblIpsIIdtipoIdentificacionNavigation)
                    .HasForeignKey(d => d.IIdtipoIdentificacion)
                    .HasConstraintName("FK_tblIPS_tblMultivalores");

                entity.HasOne(d => d.IIdubicacionNavigation)
                    .WithMany(p => p.TblIps)
                    .HasForeignKey(d => d.IIdubicacion)
                    .HasConstraintName("FK_tblIPS_tblDivipola");

                entity.HasOne(d => d.IIdusuarioCreacionNavigation)
                    .WithMany(p => p.TblIps)
                    .HasForeignKey(d => d.IIdusuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblIPS_tblUsuarios");

                entity.HasOne(d => d.ITipoIpsNavigation)
                    .WithMany(p => p.TblIpsITipoIpsNavigation)
                    .HasForeignKey(d => d.ITipoIps)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblIPS_tblMultivalores1");
            });

            modelBuilder.Entity<TblIpssEps>(entity =>
            {
                entity.HasKey(e => e.IIdipseps)
                    .HasName("PK_tblIPS-EPS");

                entity.ToTable("tblIPSs-EPS", "negocio");

                entity.Property(e => e.IIdipseps).HasColumnName("iIDIPSEPS");

                entity.Property(e => e.IIdeps).HasColumnName("iIDEPS");

                entity.Property(e => e.IIdips).HasColumnName("iIDIPS");

                entity.HasOne(d => d.IIdepsNavigation)
                    .WithMany(p => p.TblIpssEps)
                    .HasForeignKey(d => d.IIdeps)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblIPSs-EPS_tblEPS");

                entity.HasOne(d => d.IIdipsNavigation)
                    .WithMany(p => p.TblIpssEps)
                    .HasForeignKey(d => d.IIdips)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblIPSs-EPS_tblIPS");
            });

            modelBuilder.Entity<TblJurisprudencias>(entity =>
            {
                entity.HasKey(e => e.IIdjurisprudencia);

                entity.ToTable("tblJurisprudencias", "jurisprudencia");

                entity.Property(e => e.IIdjurisprudencia).HasColumnName("iIDJurisprudencia");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IAño).HasColumnName("iAño");

                entity.Property(e => e.IIdemisor).HasColumnName("iIDEmisor");

                entity.Property(e => e.ILegislacion).HasColumnName("iLegislacion");

                entity.Property(e => e.INumero).HasColumnName("iNumero");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TArticulos)
                    .IsRequired()
                    .HasColumnName("tArticulos")
                    .HasMaxLength(500);

                entity.Property(e => e.TControl)
                    .IsRequired()
                    .HasColumnName("tControl")
                    .HasMaxLength(500);

                entity.Property(e => e.TDescripcion)
                    .IsRequired()
                    .HasColumnName("tDescripcion")
                    .HasMaxLength(500);

                entity.Property(e => e.TObligacion)
                    .IsRequired()
                    .HasColumnName("tObligacion")
                    .HasMaxLength(500);

                entity.HasOne(d => d.IIdemisorNavigation)
                    .WithMany(p => p.TblJurisprudencias)
                    .HasForeignKey(d => d.IIdemisor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblJurisprudencias_tblEmisores");

                entity.HasOne(d => d.ILegislacionNavigation)
                    .WithMany(p => p.TblJurisprudencias)
                    .HasForeignKey(d => d.ILegislacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblJurisprudencias_tblMultivalores");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblJurisprudencias)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblJurisprudencias_tblUsuarios");
            });

            modelBuilder.Entity<TblListaDetalle>(entity =>
            {
                entity.HasKey(e => e.IdListaDetalle);

                entity.ToTable("tblListaDetalle");

                entity.Property(e => e.IdListaDetalle)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Codigos)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionEsp)
                    .HasColumnName("Descripcion_Esp")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionIng)
                    .HasColumnName("Descripcion_ing")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Grupo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Lista).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblMapaProcesoPosiciones>(entity =>
            {
                entity.HasKey(e => e.IIdposicionProceso);

                entity.ToTable("tblMapaProcesoPosiciones", "proceso");

                entity.Property(e => e.IIdposicionProceso).HasColumnName("iIDPosicionProceso");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IIdempresaProceso).HasColumnName("iIDEmpresaProceso");

                entity.Property(e => e.IPosicionX).HasColumnName("iPosicionX");

                entity.Property(e => e.IPosicionY).HasColumnName("iPosicionY");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblMapaProcesoPosiciones)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblMapaProcesoPosiciones_tblEmpresas");

                entity.HasOne(d => d.IIdempresaProcesoNavigation)
                    .WithMany(p => p.TblMapaProcesoPosiciones)
                    .HasForeignKey(d => d.IIdempresaProceso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblMapaProcesoPosiciones_tblEmpresaProcesos");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblMapaProcesoPosiciones)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblMapaProcesoPosiciones_tblUsuarios");
            });

            modelBuilder.Entity<TblMedicamentos>(entity =>
            {
                entity.HasKey(e => e.IIdmedicamento)
                    .HasName("PK_tblMedicamentos_1");

                entity.ToTable("tblMedicamentos", "administracion");

                entity.Property(e => e.IIdmedicamento).HasColumnName("iIDMedicamento");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DCantidad)
                    .HasColumnName("dCantidad")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.DCantidadCum)
                    .HasColumnName("dCantidadCum")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.DtFechaActivo)
                    .HasColumnName("dtFechaActivo")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaExpedicion)
                    .HasColumnName("dtFechaExpedicion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaInactivo)
                    .HasColumnName("dtFechaInactivo")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaModificacion)
                    .HasColumnName("dtFechaModificacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaVencimiento)
                    .HasColumnName("dtFechaVencimiento")
                    .HasColumnType("datetime");

                entity.Property(e => e.IConsecutivo).HasColumnName("iConsecutivo");

                entity.Property(e => e.IIdpais).HasColumnName("iIDPais");

                entity.Property(e => e.IIdsubtablaInvimaEstado).HasColumnName("iIDSubtablaInvimaEstado");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.IIdusuarioModificacion).HasColumnName("iIDUsuarioModificacion");

                entity.Property(e => e.ILlaveValidacion).HasColumnName("iLlaveValidacion");

                entity.Property(e => e.TAtc)
                    .HasColumnName("tATC")
                    .HasMaxLength(400);

                entity.Property(e => e.TConcentracion)
                    .HasColumnName("tConcentracion")
                    .HasMaxLength(400);

                entity.Property(e => e.TDescripcionAtc)
                    .HasColumnName("tDescripcionATC")
                    .HasMaxLength(400);

                entity.Property(e => e.TDescripcionComercial)
                    .HasColumnName("tDescripcionComercial")
                    .HasMaxLength(800);

                entity.Property(e => e.TEstadoCum)
                    .HasColumnName("tEstadoCum")
                    .HasMaxLength(400);

                entity.Property(e => e.TEstadoRegistro)
                    .HasColumnName("tEstadoRegistro")
                    .HasMaxLength(400);

                entity.Property(e => e.TExpediente)
                    .HasColumnName("tExpediente")
                    .HasMaxLength(400);

                entity.Property(e => e.TExpedienteCum)
                    .HasColumnName("tExpedienteCum")
                    .HasMaxLength(400);

                entity.Property(e => e.TFormaFarmaceutica)
                    .HasColumnName("tFormaFarmaceutica")
                    .HasMaxLength(400);

                entity.Property(e => e.TModalidad)
                    .HasColumnName("tModalidad")
                    .HasMaxLength(400);

                entity.Property(e => e.TMuestraMedica)
                    .HasColumnName("tMuestraMedica")
                    .HasMaxLength(400);

                entity.Property(e => e.TNombreRol)
                    .HasColumnName("tNombreROL")
                    .HasMaxLength(400);

                entity.Property(e => e.TPrincipioActivo)
                    .HasColumnName("tPrincipioActivo")
                    .HasMaxLength(600);

                entity.Property(e => e.TProducto)
                    .HasColumnName("tProducto")
                    .HasMaxLength(400);

                entity.Property(e => e.TRegistroSanitario)
                    .HasColumnName("tRegistroSanitario")
                    .HasMaxLength(400);

                entity.Property(e => e.TTipoRol)
                    .HasColumnName("tTipoROL")
                    .HasMaxLength(400);

                entity.Property(e => e.TTitular)
                    .HasColumnName("tTitular")
                    .HasMaxLength(400);

                entity.Property(e => e.TUnidad)
                    .HasColumnName("tUnidad")
                    .HasMaxLength(400);

                entity.Property(e => e.TUnidadMedida)
                    .HasColumnName("tUnidadMedida")
                    .HasMaxLength(400);

                entity.Property(e => e.TUnidadReferencia)
                    .HasColumnName("tUnidadReferencia")
                    .HasMaxLength(400);

                entity.Property(e => e.TValorInvimaEstado)
                    .HasColumnName("tValorInvimaEstado")
                    .HasMaxLength(200);

                entity.Property(e => e.TViaAdministracion)
                    .HasColumnName("tViaAdministracion")
                    .HasMaxLength(400);

                entity.HasOne(d => d.TblMultivalores)
                    .WithMany(p => p.TblMedicamentos)
                    .HasPrincipalKey(p => new { p.IIdsubtabla, p.TValor })
                    .HasForeignKey(d => new { d.IIdsubtablaInvimaEstado, d.TValorInvimaEstado })
                    .HasConstraintName("FK_tblMedicamentos_tblMultivalores");
            });

            modelBuilder.Entity<TblMedicamentosTemp>(entity =>
            {
                entity.HasKey(e => e.IIdmedicamentoTemp)
                    .HasName("PK_tblMedicamentosTemp_1");

                entity.ToTable("tblMedicamentosTemp", "administracion");

                entity.Property(e => e.IIdmedicamentoTemp).HasColumnName("iIDMedicamentoTemp");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DCantidad)
                    .HasColumnName("dCantidad")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.DCantidadCum)
                    .HasColumnName("dCantidadCum")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.DtFechaActivo)
                    .HasColumnName("dtFechaActivo")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaExpedicion)
                    .HasColumnName("dtFechaExpedicion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaInactivo)
                    .HasColumnName("dtFechaInactivo")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaModificacion)
                    .HasColumnName("dtFechaModificacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaVencimiento)
                    .HasColumnName("dtFechaVencimiento")
                    .HasColumnType("datetime");

                entity.Property(e => e.IConsecutivo).HasColumnName("iConsecutivo");

                entity.Property(e => e.IIdpais).HasColumnName("iIDPais");

                entity.Property(e => e.IIdsubtablaInvimaEstado).HasColumnName("iIDSubtablaInvimaEstado");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.IIdusuarioModificacion).HasColumnName("iIDUsuarioModificacion");

                entity.Property(e => e.ILlaveValidacion).HasColumnName("iLlaveValidacion");

                entity.Property(e => e.TAtc)
                    .HasColumnName("tATC")
                    .HasMaxLength(400);

                entity.Property(e => e.TConcentracion)
                    .HasColumnName("tConcentracion")
                    .HasMaxLength(400);

                entity.Property(e => e.TDescripcionAtc)
                    .HasColumnName("tDescripcionATC")
                    .HasMaxLength(400);

                entity.Property(e => e.TDescripcionComercial)
                    .HasColumnName("tDescripcionComercial")
                    .HasMaxLength(800);

                entity.Property(e => e.TEstadoCum)
                    .HasColumnName("tEstadoCum")
                    .HasMaxLength(400);

                entity.Property(e => e.TEstadoRegistro)
                    .HasColumnName("tEstadoRegistro")
                    .HasMaxLength(400);

                entity.Property(e => e.TExpediente)
                    .HasColumnName("tExpediente")
                    .HasMaxLength(400);

                entity.Property(e => e.TExpedienteCum)
                    .HasColumnName("tExpedienteCum")
                    .HasMaxLength(400);

                entity.Property(e => e.TFormaFarmaceutica)
                    .HasColumnName("tFormaFarmaceutica")
                    .HasMaxLength(400);

                entity.Property(e => e.TModalidad)
                    .HasColumnName("tModalidad")
                    .HasMaxLength(400);

                entity.Property(e => e.TMuestraMedica)
                    .HasColumnName("tMuestraMedica")
                    .HasMaxLength(400);

                entity.Property(e => e.TNombreRol)
                    .HasColumnName("tNombreROL")
                    .HasMaxLength(400);

                entity.Property(e => e.TPrincipioActivo)
                    .HasColumnName("tPrincipioActivo")
                    .HasMaxLength(600);

                entity.Property(e => e.TProducto)
                    .HasColumnName("tProducto")
                    .HasMaxLength(400);

                entity.Property(e => e.TRegistroSanitario)
                    .HasColumnName("tRegistroSanitario")
                    .HasMaxLength(400);

                entity.Property(e => e.TTipoRol)
                    .HasColumnName("tTipoROL")
                    .HasMaxLength(400);

                entity.Property(e => e.TTitular)
                    .HasColumnName("tTitular")
                    .HasMaxLength(400);

                entity.Property(e => e.TUnidad)
                    .HasColumnName("tUnidad")
                    .HasMaxLength(400);

                entity.Property(e => e.TUnidadMedida)
                    .HasColumnName("tUnidadMedida")
                    .HasMaxLength(400);

                entity.Property(e => e.TUnidadReferencia)
                    .HasColumnName("tUnidadReferencia")
                    .HasMaxLength(400);

                entity.Property(e => e.TValorInvimaEstado)
                    .HasColumnName("tValorInvimaEstado")
                    .HasMaxLength(200);

                entity.Property(e => e.TViaAdministracion)
                    .HasColumnName("tViaAdministracion")
                    .HasMaxLength(400);

                entity.HasOne(d => d.TblMultivalores)
                    .WithMany(p => p.TblMedicamentosTemp)
                    .HasPrincipalKey(p => new { p.IIdsubtabla, p.TValor })
                    .HasForeignKey(d => new { d.IIdsubtablaInvimaEstado, d.TValorInvimaEstado })
                    .HasConstraintName("FK_tblMedicamentosTemp_tblMultivalores");
            });

            modelBuilder.Entity<TblMenu>(entity =>
            {
                entity.HasKey(e => e.IIdmenu);

                entity.ToTable("tblMenu", "seguridad");

                entity.Property(e => e.IIdmenu).HasColumnName("iIDMenu");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.IIdpadre).HasColumnName("iIDPadre");

                entity.Property(e => e.IPosicion).HasColumnName("iPosicion");

                entity.Property(e => e.IPosicionPadre).HasColumnName("iPosicionPadre");

                entity.Property(e => e.Icon).HasMaxLength(50);

                entity.Property(e => e.TDescripcion)
                    .IsRequired()
                    .HasColumnName("tDescripcion")
                    .HasMaxLength(50);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<TblMenuPerfiles>(entity =>
            {
                entity.HasKey(e => new { e.IIdperfil, e.IIdmenu })
                    .HasName("PK__tblMenuP__2B258DC93650AE39");

                entity.ToTable("tblMenuPerfiles", "seguridad");

                entity.Property(e => e.IIdperfil).HasColumnName("iIDPerfil");

                entity.Property(e => e.IIdmenu).HasColumnName("iIDMenu");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.HasOne(d => d.IIdmenuNavigation)
                    .WithMany(p => p.TblMenuPerfiles)
                    .HasForeignKey(d => d.IIdmenu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblMenuPerfiles_tblMenu");

                entity.HasOne(d => d.IIdperfilNavigation)
                    .WithMany(p => p.TblMenuPerfiles)
                    .HasForeignKey(d => d.IIdperfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblMenuPerfiles_tblPerfiles");
            });

            modelBuilder.Entity<TblMultivalores>(entity =>
            {
                entity.HasKey(e => e.IIdmultivalor);

                entity.ToTable("tblMultivalores");

                entity.HasIndex(e => new { e.IIdsubtabla, e.TValor })
                    .HasName("IDX_Subtabla")
                    .IsUnique();

                entity.Property(e => e.IIdmultivalor).HasColumnName("iIDMultivalor");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdsubtabla).HasColumnName("iIDSubtabla");

                entity.Property(e => e.IIdusuarioCreador).HasColumnName("iIDUsuarioCreador");

                entity.Property(e => e.IOrden).HasColumnName("iOrden");

                entity.Property(e => e.TDescripcion)
                    .IsRequired()
                    .HasColumnName("tDescripcion")
                    .HasMaxLength(4000);

                entity.Property(e => e.TSubtabla)
                    .IsRequired()
                    .HasColumnName("tSubtabla")
                    .HasMaxLength(200);

                entity.Property(e => e.TValor)
                    .IsRequired()
                    .HasColumnName("tValor")
                    .HasMaxLength(200);

                entity.HasOne(d => d.IIdusuarioCreadorNavigation)
                    .WithMany(p => p.TblMultivalores)
                    .HasForeignKey(d => d.IIdusuarioCreador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblMultivalores_tblUsuarios");
            });

            modelBuilder.Entity<TblNotificacionesElectronicas>(entity =>
            {
                entity.HasKey(e => e.IId)
                    .HasName("PK__tblNotif__DC512D72AD5DFFA3");

                entity.ToTable("tblNotificacionesElectronicas");

                entity.HasIndex(e => e.TIdentificador)
                    .HasName("UQ_tblNotificacionesElectronicas_tIdentificador")
                    .IsUnique();

                entity.Property(e => e.IId).HasColumnName("iID");

                entity.Property(e => e.IIdtemplateNotificacion).HasColumnName("iIDTemplateNotificacion");

                entity.Property(e => e.INumeroDias).HasColumnName("iNumeroDias");

                entity.Property(e => e.TDescripcion)
                    .IsRequired()
                    .HasColumnName("tDescripcion")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.TIdentificador)
                    .IsRequired()
                    .HasColumnName("tIdentificador")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.IIdtemplateNotificacionNavigation)
                    .WithMany(p => p.TblNotificacionesElectronicas)
                    .HasForeignKey(d => d.IIdtemplateNotificacion)
                    .HasConstraintName("FK_tblNotificacionesElectronicas_tblTemplate");
            });

            modelBuilder.Entity<TblNotificacionesUsuarios>(entity =>
            {
                entity.HasKey(e => e.IId)
                    .HasName("PK__tblNotif__DC512D7225EE4213");

                entity.ToTable("tblNotificaciones_Usuarios");

                entity.Property(e => e.IId).HasColumnName("iID");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.IIdNotificacionElectronica).HasColumnName("iIdNotificacionElectronica");

                entity.Property(e => e.IIdTipoNotificacion).HasColumnName("iIdTipoNotificacion");

                entity.Property(e => e.IIdusuarioNotificacion).HasColumnName("iIDUsuarioNotificacion");
            });

            modelBuilder.Entity<TblNumerales>(entity =>
            {
                entity.HasKey(e => e.IIdnumeral);

                entity.ToTable("tblNumerales", "proceso");

                entity.Property(e => e.IIdnumeral).HasColumnName("iIDNumeral");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.BSoa).HasColumnName("bSOA");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdsubtablaEstandar).HasColumnName("iIDSubtablaEstandar");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TDescripcion)
                    .IsRequired()
                    .HasColumnName("tDescripcion")
                    .HasMaxLength(300);

                entity.Property(e => e.TIdvalorEstandar)
                    .IsRequired()
                    .HasColumnName("tIDValorEstandar")
                    .HasMaxLength(100);

                entity.Property(e => e.TNumeral)
                    .IsRequired()
                    .HasColumnName("tNumeral")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblNumerales)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblNumerales_tblUsuarios");
            });

            modelBuilder.Entity<TblNumeralesProceso>(entity =>
            {
                entity.HasKey(e => e.IIdnumeralProceso);

                entity.ToTable("tblNumeralesProceso", "proceso");

                entity.Property(e => e.IIdnumeralProceso).HasColumnName("iIDNumeralProceso");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IIdnumeral).HasColumnName("iIDNumeral");

                entity.Property(e => e.IIdproceso).HasColumnName("iIDProceso");

                entity.Property(e => e.IIdsubtablaEstandar).HasColumnName("iIDSubtablaEstandar");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.TIdvalorEstandar)
                    .IsRequired()
                    .HasColumnName("tIDValorEstandar")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblNumeralesProceso)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblNumeralesProceso_tblEmpresas");

                entity.HasOne(d => d.IIdnumeralNavigation)
                    .WithMany(p => p.TblNumeralesProceso)
                    .HasForeignKey(d => d.IIdnumeral)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblNumeralesProceso_tblNumerales");

                entity.HasOne(d => d.IIdprocesoNavigation)
                    .WithMany(p => p.TblNumeralesProceso)
                    .HasForeignKey(d => d.IIdproceso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblNumeralesProceso_tblEmpresaProcesos");

                entity.HasOne(d => d.IIdusuarioCreacionNavigation)
                    .WithMany(p => p.TblNumeralesProceso)
                    .HasForeignKey(d => d.IIdusuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblNumeralesProceso_tblUsuarios");
            });

            modelBuilder.Entity<TblPacientes>(entity =>
            {
                entity.HasKey(e => e.IIdpaciente);

                entity.ToTable("tblPacientes", "Incapacidades");

                entity.Property(e => e.IIdpaciente).HasColumnName("iIDPaciente");

                entity.Property(e => e.DtFechaNacimiento)
                    .HasColumnName("dtFechaNacimiento")
                    .HasColumnType("date");

                entity.Property(e => e.IEdad)
                    .HasColumnName("iEdad")
                    .HasComputedColumnSql("((CONVERT([int],CONVERT([char](8),sysdatetime(),(112)),0)-CONVERT([char](8),[dtFechaNacimiento],(112)))/(10000))");

                entity.Property(e => e.IIdafp).HasColumnName("iIDAFP");

                entity.Property(e => e.IIdarl).HasColumnName("iIDARL");

                entity.Property(e => e.IIdciuo08).HasColumnName("iIDCIUO08");

                entity.Property(e => e.IIddane).HasColumnName("iIDDANE");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IIdempresaPaciente).HasColumnName("iIDEmpresaPaciente");

                entity.Property(e => e.IIdeps).HasColumnName("iIDEPS");

                entity.Property(e => e.IIdestadoAfiliacion).HasColumnName("iIDEstadoAfiliacion");

                entity.Property(e => e.IIdgenero).HasColumnName("iIDGenero");

                entity.Property(e => e.IIdregimenAfiliacion).HasColumnName("iIDRegimenAfiliacion");

                entity.Property(e => e.IIdtipoAfiliacion).HasColumnName("iIDTipoAfiliacion");

                entity.Property(e => e.IIdtipoDoc).HasColumnName("iIDTipoDoc");

                entity.Property(e => e.TDireccion)
                    .IsRequired()
                    .HasColumnName("tDireccion")
                    .HasMaxLength(50);

                entity.Property(e => e.TEmail)
                    .IsRequired()
                    .HasColumnName("tEmail")
                    .HasMaxLength(200);

                entity.Property(e => e.TNumeroDocumento)
                    .IsRequired()
                    .HasColumnName("tNumeroDocumento")
                    .HasMaxLength(50);

                entity.Property(e => e.TPrimerApellido)
                    .IsRequired()
                    .HasColumnName("tPrimerApellido")
                    .HasMaxLength(50);

                entity.Property(e => e.TPrimerNombre)
                    .IsRequired()
                    .HasColumnName("tPrimerNombre")
                    .HasMaxLength(50);

                entity.Property(e => e.TSegundoApellido)
                    .IsRequired()
                    .HasColumnName("tSegundoApellido")
                    .HasMaxLength(50);

                entity.Property(e => e.TSegundoNombre)
                    .IsRequired()
                    .HasColumnName("tSegundoNombre")
                    .HasMaxLength(50);

                entity.Property(e => e.TTelefono)
                    .IsRequired()
                    .HasColumnName("tTelefono")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IIdafpNavigation)
                    .WithMany(p => p.TblPacientes)
                    .HasForeignKey(d => d.IIdafp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPacientes_tblAFP");

                entity.HasOne(d => d.IIdarlNavigation)
                    .WithMany(p => p.TblPacientes)
                    .HasForeignKey(d => d.IIdarl)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPacientes_tblARLs");

                entity.HasOne(d => d.IIdciuo08Navigation)
                    .WithMany(p => p.TblPacientes)
                    .HasForeignKey(d => d.IIdciuo08)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCIUO08_iID");

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblPacientes)
                    .HasForeignKey(d => d.IIdempresa)
                    .HasConstraintName("FK_tblPacientes_tblEmpresas");

                entity.HasOne(d => d.IIdepsNavigation)
                    .WithMany(p => p.TblPacientes)
                    .HasForeignKey(d => d.IIdeps)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPacientes_tblEPS");

                entity.HasOne(d => d.IIdestadoAfiliacionNavigation)
                    .WithMany(p => p.TblPacientes)
                    .HasForeignKey(d => d.IIdestadoAfiliacion)
                    .HasConstraintName("FK_tblPacientes_tblEstadoAfiliacion");

                entity.HasOne(d => d.IIdgeneroNavigation)
                    .WithMany(p => p.TblPacientesIIdgeneroNavigation)
                    .HasForeignKey(d => d.IIdgenero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPacientes_tblMultivalores1");

                entity.HasOne(d => d.IIdregimenAfiliacionNavigation)
                    .WithMany(p => p.TblPacientes)
                    .HasForeignKey(d => d.IIdregimenAfiliacion)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_tblPacientes_tblRegimenAfiliacion");

                entity.HasOne(d => d.IIdtipoAfiliacionNavigation)
                    .WithMany(p => p.TblPacientes)
                    .HasForeignKey(d => d.IIdtipoAfiliacion)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_tblPacientes_tblTipoAfiliacion");

                entity.HasOne(d => d.IIdtipoDocNavigation)
                    .WithMany(p => p.TblPacientesIIdtipoDocNavigation)
                    .HasForeignKey(d => d.IIdtipoDoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPacientes_tblMultivalores");
            });

            modelBuilder.Entity<TblParametrosEmpresas>(entity =>
            {
                entity.HasKey(e => e.IIdparametro)
                    .HasName("PK__Parametr__7F00682EEC2DDBB7");

                entity.ToTable("tblParametrosEmpresas");

                entity.HasIndex(e => new { e.TIdentificador, e.IIdempresa })
                    .HasName("UQ_tblParametrosEmpresas_tIdentificador")
                    .IsUnique();

                entity.Property(e => e.IIdparametro).HasColumnName("iIDParametro");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.TDescripcion)
                    .HasColumnName("tDescripcion")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.TIdentificador)
                    .HasColumnName("tIdentificador")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.TValor).HasColumnName("tValor");
            });

            modelBuilder.Entity<TblPartesCuerpo>(entity =>
            {
                entity.HasKey(e => e.IIdparteCuerpo);

                entity.ToTable("tblPartesCuerpo", "negocio");

                entity.Property(e => e.IIdparteCuerpo).HasColumnName("iIDParteCuerpo");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdpadre).HasColumnName("iIDPadre");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TCodigo)
                    .IsRequired()
                    .HasColumnName("tCodigo")
                    .HasMaxLength(30);

                entity.Property(e => e.TNombre)
                    .IsRequired()
                    .HasColumnName("tNombre")
                    .HasMaxLength(200);

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblPartesCuerpo)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPartesCuerpo_tblUsuarios");
            });

            modelBuilder.Entity<TblPeoresConsecuencias>(entity =>
            {
                entity.HasKey(e => e.IIdpeorConsecuencia);

                entity.ToTable("tblPeoresConsecuencias", "negocio");

                entity.Property(e => e.IIdpeorConsecuencia).HasColumnName("iIDPeorConsecuencia");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdclasificacionRiesgo).HasColumnName("iIDClasificacionRiesgo");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TPeorConsecuencia)
                    .IsRequired()
                    .HasColumnName("tPeorConsecuencia")
                    .HasMaxLength(300);
            });

            modelBuilder.Entity<TblPerfilSocioDemoAfp>(entity =>
            {
                entity.HasKey(e => e.IIdperfilSocioDemoAfp);

                entity.ToTable("tblPerfilSocioDemoAFP", "negocio");

                entity.Property(e => e.IIdperfilSocioDemoAfp).HasColumnName("iIDPerfilSocioDemoAFP");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdafp).HasColumnName("iIDAFP");

                entity.Property(e => e.IIdperfilSocioDemo).HasColumnName("iIDPerfilSocioDemo");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.HasOne(d => d.IIdafpNavigation)
                    .WithMany(p => p.TblPerfilSocioDemoAfp)
                    .HasForeignKey(d => d.IIdafp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPerfilSocioDemoAFP_tblAFP");

                entity.HasOne(d => d.IIdperfilSocioDemoNavigation)
                    .WithMany(p => p.TblPerfilSocioDemoAfp)
                    .HasForeignKey(d => d.IIdperfilSocioDemo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPerfilSocioDemoAFP_tblPerfilSocioDemografico");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblPerfilSocioDemoAfp)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPerfilSocioDemoAFP_tblUsuarios");
            });

            modelBuilder.Entity<TblPerfilSocioDemoCargo>(entity =>
            {
                entity.HasKey(e => e.IIdperfilSocioDemoCargo);

                entity.ToTable("tblPerfilSocioDemoCargo", "negocio");

                entity.Property(e => e.IIdperfilSocioDemoCargo).HasColumnName("iIDPerfilSocioDemoCargo");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdcargo).HasColumnName("iIDCargo");

                entity.Property(e => e.IIdperfilSocioDemo).HasColumnName("iIDPerfilSocioDemo");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.HasOne(d => d.IIdcargoNavigation)
                    .WithMany(p => p.TblPerfilSocioDemoCargo)
                    .HasForeignKey(d => d.IIdcargo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPerfilSocioDemoCargo_tblCargos");

                entity.HasOne(d => d.IIdperfilSocioDemoNavigation)
                    .WithMany(p => p.TblPerfilSocioDemoCargo)
                    .HasForeignKey(d => d.IIdperfilSocioDemo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPerfilSocioDemoCargo_tblPerfilSocioDemografico");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblPerfilSocioDemoCargo)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPerfilSocioDemoCargo_tblUsuarios");
            });

            modelBuilder.Entity<TblPerfilSocioDemoEdad>(entity =>
            {
                entity.HasKey(e => e.IIdperfilSocioDemoEdad);

                entity.ToTable("tblPerfilSocioDemoEdad", "negocio");

                entity.Property(e => e.IIdperfilSocioDemoEdad).HasColumnName("iIDPerfilSocioDemoEdad");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdgenero).HasColumnName("iIDGenero");

                entity.Property(e => e.IIdperfilSocioDemo).HasColumnName("iIDPerfilSocioDemo");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TRangoEdad)
                    .IsRequired()
                    .HasColumnName("tRangoEdad")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IIdgeneroNavigation)
                    .WithMany(p => p.TblPerfilSocioDemoEdad)
                    .HasForeignKey(d => d.IIdgenero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPerfilSocioDemoEdad_tblMultivalores");

                entity.HasOne(d => d.IIdperfilSocioDemoNavigation)
                    .WithMany(p => p.TblPerfilSocioDemoEdad)
                    .HasForeignKey(d => d.IIdperfilSocioDemo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPerfilSocioDemoEdad_tblPerfilSocioDemografico");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblPerfilSocioDemoEdad)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPerfilSocioDemoEdad_tblUsuarios");
            });

            modelBuilder.Entity<TblPerfilSocioDemoEps>(entity =>
            {
                entity.HasKey(e => e.IIdperfilSocioDemoEps);

                entity.ToTable("tblPerfilSocioDemoEPS", "negocio");

                entity.Property(e => e.IIdperfilSocioDemoEps).HasColumnName("iIDPerfilSocioDemoEPS");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdeps).HasColumnName("iIDEPS");

                entity.Property(e => e.IIdperfilSocioDemo).HasColumnName("iIDPerfilSocioDemo");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.HasOne(d => d.IIdepsNavigation)
                    .WithMany(p => p.TblPerfilSocioDemoEps)
                    .HasForeignKey(d => d.IIdeps)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPerfilSocioDemoEPS_tblEPS");

                entity.HasOne(d => d.IIdperfilSocioDemoNavigation)
                    .WithMany(p => p.TblPerfilSocioDemoEps)
                    .HasForeignKey(d => d.IIdperfilSocioDemo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPerfilSocioDemoEPS_tblPerfilSocioDemografico");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblPerfilSocioDemoEps)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPerfilSocioDemoEPS_tblUsuarios");
            });

            modelBuilder.Entity<TblPerfilSocioDemoEstadoCivil>(entity =>
            {
                entity.HasKey(e => e.IIdperfilSocioDemoEstadoCivil);

                entity.ToTable("tblPerfilSocioDemoEstadoCivil", "negocio");

                entity.Property(e => e.IIdperfilSocioDemoEstadoCivil).HasColumnName("iIDPerfilSocioDemoEstadoCivil");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdestadoCivil).HasColumnName("iIDEstadoCivil");

                entity.Property(e => e.IIdperfilSocioDemo).HasColumnName("iIDPerfilSocioDemo");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.HasOne(d => d.IIdestadoCivilNavigation)
                    .WithMany(p => p.TblPerfilSocioDemoEstadoCivil)
                    .HasForeignKey(d => d.IIdestadoCivil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPerfilSocioDemoEstadoCivil_tblMultivalores");

                entity.HasOne(d => d.IIdperfilSocioDemoNavigation)
                    .WithMany(p => p.TblPerfilSocioDemoEstadoCivil)
                    .HasForeignKey(d => d.IIdperfilSocioDemo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPerfilSocioDemoEstadoCivil_tblPerfilSocioDemografico");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblPerfilSocioDemoEstadoCivil)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPerfilSocioDemoEstadoCivil_tblUsuarios");
            });

            modelBuilder.Entity<TblPerfilSocioDemoFormacionEduc>(entity =>
            {
                entity.HasKey(e => e.IIdperfilSocioDemoFormacionEduc);

                entity.ToTable("tblPerfilSocioDemoFormacionEduc", "negocio");

                entity.Property(e => e.IIdperfilSocioDemoFormacionEduc).HasColumnName("iIDPerfilSocioDemoFormacionEduc");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdformacionEduc).HasColumnName("iIDFormacionEduc");

                entity.Property(e => e.IIdperfilSocioDemo).HasColumnName("iIDPerfilSocioDemo");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.HasOne(d => d.IIdformacionEducNavigation)
                    .WithMany(p => p.TblPerfilSocioDemoFormacionEduc)
                    .HasForeignKey(d => d.IIdformacionEduc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPerfilSocioDemoFormacionEduc_tblMultivalores");

                entity.HasOne(d => d.IIdperfilSocioDemoNavigation)
                    .WithMany(p => p.TblPerfilSocioDemoFormacionEduc)
                    .HasForeignKey(d => d.IIdperfilSocioDemo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPerfilSocioDemoFormacionEduc_tblPerfilSocioDemografico");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblPerfilSocioDemoFormacionEduc)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPerfilSocioDemoFormacionEduc_tblUsuarios");
            });

            modelBuilder.Entity<TblPerfilSocioDemoSucursal>(entity =>
            {
                entity.HasKey(e => e.IIdperfilSocioDemoSucursal);

                entity.ToTable("tblPerfilSocioDemoSucursal", "negocio");

                entity.Property(e => e.IIdperfilSocioDemoSucursal).HasColumnName("iIDPerfilSocioDemoSucursal");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdperfilSocioDemo).HasColumnName("iIDPerfilSocioDemo");

                entity.Property(e => e.IIdsucursal).HasColumnName("iIDSucursal");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.HasOne(d => d.IIdperfilSocioDemoNavigation)
                    .WithMany(p => p.TblPerfilSocioDemoSucursal)
                    .HasForeignKey(d => d.IIdperfilSocioDemo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPerfilSocioDemoSucursal_tblPerfilSocioDemografico");

                entity.HasOne(d => d.IIdsucursalNavigation)
                    .WithMany(p => p.TblPerfilSocioDemoSucursal)
                    .HasForeignKey(d => d.IIdsucursal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPerfilSocioDemoSucursal_tblSucursalesEmpresas");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblPerfilSocioDemoSucursal)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPerfilSocioDemoSucursal_tblUsuarios");
            });

            modelBuilder.Entity<TblPerfilSocioDemoTipoVincul>(entity =>
            {
                entity.HasKey(e => e.IIdperfilSocioDemoTipoVincul);

                entity.ToTable("tblPerfilSocioDemoTipoVincul", "negocio");

                entity.Property(e => e.IIdperfilSocioDemoTipoVincul).HasColumnName("iIDPerfilSocioDemoTipoVincul");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdperfilSocioDemo).HasColumnName("iIDPerfilSocioDemo");

                entity.Property(e => e.IIdtipoVinculacion).HasColumnName("iIDTipoVinculacion");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.HasOne(d => d.IIdperfilSocioDemoNavigation)
                    .WithMany(p => p.TblPerfilSocioDemoTipoVincul)
                    .HasForeignKey(d => d.IIdperfilSocioDemo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPerfilSocioDemoTipoVincul_tblPerfilSocioDemografico");

                entity.HasOne(d => d.IIdtipoVinculacionNavigation)
                    .WithMany(p => p.TblPerfilSocioDemoTipoVincul)
                    .HasForeignKey(d => d.IIdtipoVinculacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPerfilSocioDemoTipoVincul_tblMultivalores");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblPerfilSocioDemoTipoVincul)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPerfilSocioDemoTipoVincul_tblUsuarios");
            });

            modelBuilder.Entity<TblPerfilSocioDemografico>(entity =>
            {
                entity.HasKey(e => e.IIdperfilSocioDemografico);

                entity.ToTable("tblPerfilSocioDemografico", "negocio");

                entity.Property(e => e.IIdperfilSocioDemografico).HasColumnName("iIDPerfilSocioDemografico");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblPerfilSocioDemografico)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPerfilSocioDemografico_tblEmpresas");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblPerfilSocioDemografico)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPerfilSocioDemografico_tblUsuarios");
            });

            modelBuilder.Entity<TblPerfiles>(entity =>
            {
                entity.HasKey(e => e.IIdperfil)
                    .HasName("PK_tblPefiles");

                entity.ToTable("tblPerfiles", "seguridad");

                entity.Property(e => e.IIdperfil).HasColumnName("iIDPerfil");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.TDescripcion)
                    .IsRequired()
                    .HasColumnName("tDescripcion")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<TblPhva>(entity =>
            {
                entity.HasKey(e => e.IIdphva);

                entity.ToTable("tblPHVA", "proceso");

                entity.Property(e => e.IIdphva).HasColumnName("iIDPHVA");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IIdproceso).HasColumnName("iIDProceso");

                entity.Property(e => e.IIdsubtablaTipoPhva).HasColumnName("iIDSubtablaTipoPHVA");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TActividad)
                    .IsRequired()
                    .HasColumnName("tActividad")
                    .HasMaxLength(200);

                entity.Property(e => e.TIdvalorTipoPhva)
                    .IsRequired()
                    .HasColumnName("tIDValorTipoPHVA")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblPhva)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPHVA_tblEmpresas");

                entity.HasOne(d => d.IIdprocesoNavigation)
                    .WithMany(p => p.TblPhva)
                    .HasForeignKey(d => d.IIdproceso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPHVA_tblEmpresaProcesos");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblPhva)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPHVA_tblUsuarios");
            });

            modelBuilder.Entity<TblPlanAccion>(entity =>
            {
                entity.HasKey(e => e.IIdplanAccion);

                entity.ToTable("tblPlanAccion", "negocio");

                entity.Property(e => e.IIdplanAccion).HasColumnName("iIDPlanAccion");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaFinal)
                    .HasColumnName("dtFechaFinal")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaInicial)
                    .HasColumnName("dtFechaInicial")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IIdproceso).HasColumnName("iIDProceso");

                entity.Property(e => e.IIdresponsable).HasColumnName("iIDResponsable");

                entity.Property(e => e.IIdsucursal).HasColumnName("iIDSucursal");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TDescripcion)
                    .IsRequired()
                    .HasColumnName("tDescripcion")
                    .HasMaxLength(1000);

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblPlanAccion)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPlanAccion_tblEmpresas");

                entity.HasOne(d => d.IIdprocesoNavigation)
                    .WithMany(p => p.TblPlanAccion)
                    .HasForeignKey(d => d.IIdproceso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPlanAccion_tblProcesos");

                entity.HasOne(d => d.IIdresponsableNavigation)
                    .WithMany(p => p.TblPlanAccionIIdresponsableNavigation)
                    .HasForeignKey(d => d.IIdresponsable)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPlanAccion_tblUsuarios");

                entity.HasOne(d => d.IIdsucursalNavigation)
                    .WithMany(p => p.TblPlanAccion)
                    .HasForeignKey(d => d.IIdsucursal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPlanAccion_tblSucursalesEmpresas");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblPlanAccionIUsuarioCreacionNavigation)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPlanAccion_tblUsuarios1");
            });

            modelBuilder.Entity<TblPlanAccionActividades>(entity =>
            {
                entity.HasKey(e => e.IIdplanAccionActividad);

                entity.ToTable("tblPlanAccionActividades", "negocio");

                entity.Property(e => e.IIdplanAccionActividad).HasColumnName("iIDPlanAccionActividad");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCompromiso)
                    .HasColumnName("dtFechaCompromiso")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdplanAccionRazon).HasColumnName("iIDPlanAccionRazon");

                entity.Property(e => e.IIdresponsable).HasColumnName("iIDResponsable");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TDescripcion)
                    .IsRequired()
                    .HasColumnName("tDescripcion")
                    .HasMaxLength(1000);

                entity.HasOne(d => d.IIdplanAccionRazonNavigation)
                    .WithMany(p => p.TblPlanAccionActividades)
                    .HasForeignKey(d => d.IIdplanAccionRazon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPlanAccionActividades_tblPlanAccionRazones");

                entity.HasOne(d => d.IIdresponsableNavigation)
                    .WithMany(p => p.TblPlanAccionActividadesIIdresponsableNavigation)
                    .HasForeignKey(d => d.IIdresponsable)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPlanAccionActividades_tblUsuarios");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblPlanAccionActividadesIUsuarioCreacionNavigation)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPlanAccionActividades_tblUsuarios1");
            });

            modelBuilder.Entity<TblPlanAccionRazones>(entity =>
            {
                entity.HasKey(e => e.IIdplanAccionRazon);

                entity.ToTable("tblPlanAccionRazones", "negocio");

                entity.Property(e => e.IIdplanAccionRazon).HasColumnName("iIDPlanAccionRazon");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdplanAccion).HasColumnName("iIDPlanAccion");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TDescripcion)
                    .IsRequired()
                    .HasColumnName("tDescripcion")
                    .HasMaxLength(2000);

                entity.HasOne(d => d.IIdplanAccionNavigation)
                    .WithMany(p => p.TblPlanAccionRazones)
                    .HasForeignKey(d => d.IIdplanAccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPlanAccionRazones_tblPlanAccion");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblPlanAccionRazones)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPlanAccionRazones_tblUsuarios");
            });

            modelBuilder.Entity<TblPlanAccionTareas>(entity =>
            {
                entity.HasKey(e => e.IIdplanAccionTarea);

                entity.ToTable("tblPlanAccionTareas", "negocio");

                entity.Property(e => e.IIdplanAccionTarea).HasColumnName("iIDPlanAccionTarea");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdplanAccionActividad).HasColumnName("iIDPlanAccionActividad");

                entity.Property(e => e.IIdtarea).HasColumnName("iIDTarea");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.HasOne(d => d.IIdplanAccionActividadNavigation)
                    .WithMany(p => p.TblPlanAccionTareas)
                    .HasForeignKey(d => d.IIdplanAccionActividad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPlanAccionTareas_tblPlanAccionActividades");

                entity.HasOne(d => d.IIdtareaNavigation)
                    .WithMany(p => p.TblPlanAccionTareas)
                    .HasForeignKey(d => d.IIdtarea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPlanAccionTareas_tblTareas");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblPlanAccionTareas)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPlanAccionTareas_tblUsuarios");
            });

            modelBuilder.Entity<TblPlanCapacitacion>(entity =>
            {
                entity.HasKey(e => e.IIdplanCapacitacion);

                entity.ToTable("tblPlanCapacitacion", "negocio");

                entity.Property(e => e.IIdplanCapacitacion).HasColumnName("iIDPlanCapacitacion");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaEvaluacion)
                    .HasColumnName("dtFechaEvaluacion")
                    .HasColumnType("date");

                entity.Property(e => e.DtFechaFinal)
                    .HasColumnName("dtFechaFinal")
                    .HasColumnType("date");

                entity.Property(e => e.DtFechaInicial)
                    .HasColumnName("dtFechaInicial")
                    .HasColumnType("date");

                entity.Property(e => e.IIdcapacitador).HasColumnName("iIDCapacitador");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IIdresponsable).HasColumnName("iIDResponsable");

                entity.Property(e => e.IIdsubtablaTipoCapacitador).HasColumnName("iIDSubtablaTipoCapacitador");

                entity.Property(e => e.IIdtarea).HasColumnName("iIDTarea");

                entity.Property(e => e.IIdtipoCapacitacion).HasColumnName("iIDTipoCapacitacion");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TIdvalorTipoCapacitador)
                    .IsRequired()
                    .HasColumnName("tIDValorTipoCapacitador")
                    .HasMaxLength(100);

                entity.Property(e => e.TObjetivos)
                    .IsRequired()
                    .HasColumnName("tObjetivos")
                    .HasMaxLength(500);

                entity.Property(e => e.TRecursos)
                    .IsRequired()
                    .HasColumnName("tRecursos")
                    .HasMaxLength(500);

                entity.Property(e => e.TTematica)
                    .IsRequired()
                    .HasColumnName("tTematica")
                    .HasMaxLength(500);

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblPlanCapacitacion)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPlanCapacitacion_tblEmpresas");

                entity.HasOne(d => d.IIdresponsableNavigation)
                    .WithMany(p => p.TblPlanCapacitacion)
                    .HasForeignKey(d => d.IIdresponsable)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPlanCapacitacion_tblEmpleados");

                entity.HasOne(d => d.IIdtareaNavigation)
                    .WithMany(p => p.TblPlanCapacitacion)
                    .HasForeignKey(d => d.IIdtarea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPlanCapacitacion_tblTareas");

                entity.HasOne(d => d.IIdtipoCapacitacionNavigation)
                    .WithMany(p => p.TblPlanCapacitacion)
                    .HasForeignKey(d => d.IIdtipoCapacitacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPlanCapacitacion_tblMultivalores");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblPlanCapacitacion)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPlanCapacitacion_tblUsuarios");
            });

            modelBuilder.Entity<TblPlanCapacitacionAsistentes>(entity =>
            {
                entity.HasKey(e => e.IIdplanCapacitacionAsistente);

                entity.ToTable("tblPlanCapacitacionAsistentes", "negocio");

                entity.Property(e => e.IIdplanCapacitacionAsistente).HasColumnName("iIDPlanCapacitacionAsistente");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdempleado).HasColumnName("iIDEmpleado");

                entity.Property(e => e.IIdplanCapacitacion).HasColumnName("iIDPlanCapacitacion");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.HasOne(d => d.IIdempleadoNavigation)
                    .WithMany(p => p.TblPlanCapacitacionAsistentes)
                    .HasForeignKey(d => d.IIdempleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPlanCapacitacionAsistentes_tblEmpleados");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblPlanCapacitacionAsistentes)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPlanCapacitacionAsistentes_tblUsuarios");
            });

            modelBuilder.Entity<TblPlanCapacitacionSesiones>(entity =>
            {
                entity.HasKey(e => e.IIdplanCapacitacionSesion);

                entity.ToTable("tblPlanCapacitacionSesiones", "negocio");

                entity.Property(e => e.IIdplanCapacitacionSesion).HasColumnName("iIDPlanCapacitacionSesion");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaFinal)
                    .HasColumnName("dtFechaFinal")
                    .HasColumnType("date");

                entity.Property(e => e.DtFechaInicial)
                    .HasColumnName("dtFechaInicial")
                    .HasColumnType("date");

                entity.Property(e => e.IHoraFinal).HasColumnName("iHoraFinal");

                entity.Property(e => e.IHoraInicial).HasColumnName("iHoraInicial");

                entity.Property(e => e.IIdplanCapacitacion).HasColumnName("iIDPlanCapacitacion");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TNombre)
                    .IsRequired()
                    .HasColumnName("tNombre")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblPlanCapacitacionSesiones)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPlanCapacitacionSesiones_tblUsuarios");
            });

            modelBuilder.Entity<TblPosiblesRiesgos>(entity =>
            {
                entity.HasKey(e => e.IIdposibleRiesgo);

                entity.ToTable("tblPosiblesRiesgos", "negocio");

                entity.Property(e => e.IIdposibleRiesgo).HasColumnName("iIDPosibleRiesgo");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TPosibleRiesgo)
                    .IsRequired()
                    .HasColumnName("tPosibleRiesgo")
                    .HasMaxLength(300);

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblPosiblesRiesgos)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPosiblesRiesgos_tblUsuarios");
            });

            modelBuilder.Entity<TblProcedimientos>(entity =>
            {
                entity.HasKey(e => e.IIdprocedimiento);

                entity.ToTable("tblProcedimientos", "proceso");

                entity.Property(e => e.IIdprocedimiento).HasColumnName("iIDProcedimiento");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IIdproceso).HasColumnName("iIDProceso");

                entity.Property(e => e.IIdresponsable).HasColumnName("iIDResponsable");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TActividad)
                    .IsRequired()
                    .HasColumnName("tActividad")
                    .HasMaxLength(300);

                entity.Property(e => e.TDescripcion)
                    .IsRequired()
                    .HasColumnName("tDescripcion")
                    .HasMaxLength(500);

                entity.Property(e => e.TEntradaSalida)
                    .IsRequired()
                    .HasColumnName("tEntradaSalida")
                    .HasMaxLength(300);

                entity.Property(e => e.TVa)
                    .IsRequired()
                    .HasColumnName("tVA")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblProcedimientos)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblProcedimientos_tblEmpresas");

                entity.HasOne(d => d.IIdprocesoNavigation)
                    .WithMany(p => p.TblProcedimientos)
                    .HasForeignKey(d => d.IIdproceso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblProcedimientos_tblEmpresaProcesos");

                entity.HasOne(d => d.IIdresponsableNavigation)
                    .WithMany(p => p.TblProcedimientos)
                    .HasForeignKey(d => d.IIdresponsable)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblProcedimientos_tblCargos");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblProcedimientos)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblProcedimientos_tblUsuarios");
            });

            modelBuilder.Entity<TblProcesos>(entity =>
            {
                entity.HasKey(e => e.IIdproceso);

                entity.ToTable("tblProcesos", "negocio");

                entity.Property(e => e.IIdproceso).HasColumnName("iIDProceso");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtUsuarioCreacion)
                    .HasColumnName("dtUsuarioCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IIdtipoProceso).HasColumnName("iIDTipoProceso");

                entity.Property(e => e.ILider).HasColumnName("iLider");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TCodigo)
                    .HasColumnName("tCodigo")
                    .HasMaxLength(20);

                entity.Property(e => e.TNombreProceso)
                    .IsRequired()
                    .HasColumnName("tNombreProceso")
                    .HasMaxLength(200);

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblProcesos)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblProcesos_tblEmpresas");

                entity.HasOne(d => d.IIdtipoProcesoNavigation)
                    .WithMany(p => p.TblProcesos)
                    .HasForeignKey(d => d.IIdtipoProceso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblProcesos_tblTipoProceso");

                entity.HasOne(d => d.ILiderNavigation)
                    .WithMany(p => p.TblProcesos)
                    .HasForeignKey(d => d.ILider)
                    .HasConstraintName("FK_tblProcesos_tblEmpleados");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblProcesos)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblProcesos_tblUsuarios");
            });

            modelBuilder.Entity<TblRecobroEstados>(entity =>
            {
                entity.HasKey(e => e.IIdrecobroEstado)
                    .HasName("PK_tblEstadosRecobro");

                entity.ToTable("tblRecobroEstados", "administracion");

                entity.Property(e => e.IIdrecobroEstado).HasColumnName("iIDRecobroEstado");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdentidad).HasColumnName("iIDEntidad");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.TColor)
                    .HasColumnName("tColor")
                    .HasMaxLength(200);

                entity.HasOne(d => d.IIdentidadNavigation)
                    .WithMany(p => p.TblRecobroEstados)
                    .HasForeignKey(d => d.IIdentidad)
                    .HasConstraintName("FK_tblRecobroEstados_tblEmpresas");

                entity.HasOne(d => d.IIdusuarioCreacionNavigation)
                    .WithMany(p => p.TblRecobroEstados)
                    .HasForeignKey(d => d.IIdusuarioCreacion)
                    .HasConstraintName("FK_tblRecobroEstados_tblUsuarios1");
            });

            modelBuilder.Entity<TblRecobroEstadosDocumentos>(entity =>
            {
                entity.HasKey(e => e.IIdrecobroEstadoDocumentos)
                    .HasName("PK_tblEstadosRecobroDocumentos");

                entity.ToTable("tblRecobroEstadosDocumentos", "administracion");

                entity.Property(e => e.IIdrecobroEstadoDocumentos).HasColumnName("iIDRecobroEstadoDocumentos");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdentidad).HasColumnName("iIDEntidad");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.TColor)
                    .HasColumnName("tColor")
                    .HasMaxLength(200);

                entity.HasOne(d => d.IIdusuarioCreacionNavigation)
                    .WithMany(p => p.TblRecobroEstadosDocumentos)
                    .HasForeignKey(d => d.IIdusuarioCreacion)
                    .HasConstraintName("FK_tblRecobroEstadosDocumentos_tblUsuarios");
            });

            modelBuilder.Entity<TblRecobroEstadosDocumentosIdiomas>(entity =>
            {
                entity.HasKey(e => e.IIdrecobroEstadosDocumentosIdiomas)
                    .HasName("PK_tblEstadosRecobroDocumentosIdiomas");

                entity.ToTable("tblRecobroEstadosDocumentosIdiomas", "administracion");

                entity.Property(e => e.IIdrecobroEstadosDocumentosIdiomas).HasColumnName("iIDRecobroEstadosDocumentosIdiomas");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdidioma).HasColumnName("iIDIdioma");

                entity.Property(e => e.IIdrecobroEstado).HasColumnName("iIDRecobroEstado");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.TEstadoNombre)
                    .HasColumnName("tEstadoNombre")
                    .HasMaxLength(200);

                entity.HasOne(d => d.IIdidiomaNavigation)
                    .WithMany(p => p.TblRecobroEstadosDocumentosIdiomas)
                    .HasForeignKey(d => d.IIdidioma)
                    .HasConstraintName("FK_tblEstadosRecobroDocumentosIdiomas_tblIdiomas");

                entity.HasOne(d => d.IIdrecobroEstadoNavigation)
                    .WithMany(p => p.TblRecobroEstadosDocumentosIdiomas)
                    .HasForeignKey(d => d.IIdrecobroEstado)
                    .HasConstraintName("FK_tblRecobroEstadosDocumentosIdiomas_tblRecobroEstadosDocumentos");

                entity.HasOne(d => d.IIdusuarioCreacionNavigation)
                    .WithMany(p => p.TblRecobroEstadosDocumentosIdiomas)
                    .HasForeignKey(d => d.IIdusuarioCreacion)
                    .HasConstraintName("FK_tblEstadosRecobroDocumentosIdiomas_tblUsuarios");
            });

            modelBuilder.Entity<TblRecobroEstadosIdiomas>(entity =>
            {
                entity.HasKey(e => e.IIdrecobroEstadosIdiomas)
                    .HasName("PK_tblEstadosRecobroIdiomas");

                entity.ToTable("tblRecobroEstadosIdiomas", "administracion");

                entity.Property(e => e.IIdrecobroEstadosIdiomas).HasColumnName("iIDRecobroEstadosIdiomas");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdidioma).HasColumnName("iIDIdioma");

                entity.Property(e => e.IIdrecobroEstado).HasColumnName("iIDRecobroEstado");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.TEstadoNombre)
                    .HasColumnName("tEstadoNombre")
                    .HasMaxLength(200);

                entity.HasOne(d => d.IIdidiomaNavigation)
                    .WithMany(p => p.TblRecobroEstadosIdiomas)
                    .HasForeignKey(d => d.IIdidioma)
                    .HasConstraintName("FK_tblEstadosRecobroIdiomas_tblIdiomas");

                entity.HasOne(d => d.IIdrecobroEstadoNavigation)
                    .WithMany(p => p.TblRecobroEstadosIdiomas)
                    .HasForeignKey(d => d.IIdrecobroEstado)
                    .HasConstraintName("FK_tblEstadosRecobroIdiomas_tblEstadosCaso");

                entity.HasOne(d => d.IIdusuarioCreacionNavigation)
                    .WithMany(p => p.TblRecobroEstadosIdiomas)
                    .HasForeignKey(d => d.IIdusuarioCreacion)
                    .HasConstraintName("FK_tblEstadosRecobroIdiomas_tblUsuarios");
            });

            modelBuilder.Entity<TblRecobros>(entity =>
            {
                entity.HasKey(e => e.IIdrecobro);

                entity.ToTable("tblRecobros", "recobro");

                entity.Property(e => e.IIdrecobro).HasColumnName("iIDRecobro");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaFinRecobro)
                    .HasColumnName("dtFechaFinRecobro")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaInicioRecobro)
                    .HasColumnName("dtFechaInicioRecobro")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaModificacion)
                    .HasColumnName("dtFechaModificacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIddivipolaDestino).HasColumnName("iIDDivipolaDestino");

                entity.Property(e => e.IIddivipolaOrigen).HasColumnName("iIDDivipolaOrigen");

                entity.Property(e => e.IIdempresaDestino).HasColumnName("iIDEmpresaDestino");

                entity.Property(e => e.IIdempresaOrigen).HasColumnName("iIDEmpresaOrigen");

                entity.Property(e => e.IIdrecobroEstado).HasColumnName("iIDRecobroEstado");

                entity.Property(e => e.IIdsubtablaTipoRecobro).HasColumnName("iIDSubtablaTipoRecobro");

                entity.Property(e => e.IIdtipoEmpresaDestino).HasColumnName("iIDTipoEmpresaDestino");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.IIdusuarioModificacion).HasColumnName("iIDUsuarioModificacion");

                entity.Property(e => e.TObservacionRecobro)
                    .HasColumnName("tObservacionRecobro")
                    .HasMaxLength(2000);

                entity.Property(e => e.TValorTipoRecobro)
                    .HasColumnName("tValorTipoRecobro")
                    .HasMaxLength(200);

                entity.HasOne(d => d.IIdempresaOrigenNavigation)
                    .WithMany(p => p.TblRecobros)
                    .HasForeignKey(d => d.IIdempresaOrigen)
                    .HasConstraintName("FK_tblRecobros_tblEmpresas");

                entity.HasOne(d => d.IIdrecobroEstadoNavigation)
                    .WithMany(p => p.TblRecobros)
                    .HasForeignKey(d => d.IIdrecobroEstado)
                    .HasConstraintName("FK_tblRecobros_tblRecobroEstados");

                entity.HasOne(d => d.IIdusuarioCreacionNavigation)
                    .WithMany(p => p.TblRecobrosIIdusuarioCreacionNavigation)
                    .HasForeignKey(d => d.IIdusuarioCreacion)
                    .HasConstraintName("FK_tblRecobros_tblUsuarios");

                entity.HasOne(d => d.IIdusuarioModificacionNavigation)
                    .WithMany(p => p.TblRecobrosIIdusuarioModificacionNavigation)
                    .HasForeignKey(d => d.IIdusuarioModificacion)
                    .HasConstraintName("FK_tblRecobros_tblUsuarios1");
            });

            modelBuilder.Entity<TblRecobrosDocumentos>(entity =>
            {
                entity.HasKey(e => e.IIdrecobroDocumento);

                entity.ToTable("tblRecobrosDocumentos", "recobro");

                entity.Property(e => e.IIdrecobroDocumento).HasColumnName("iIDRecobroDocumento");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DImpuestos)
                    .HasColumnName("dImpuestos")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DValorBruto)
                    .HasColumnName("dValorBruto")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DValorNeto)
                    .HasColumnName("dValorNeto")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaDocumento)
                    .HasColumnName("dtFechaDocumento")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaModificacion)
                    .HasColumnName("dtFechaModificacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdestado).HasColumnName("iIDEstado");

                entity.Property(e => e.IIdrecobro).HasColumnName("iIDRecobro");

                entity.Property(e => e.IIdsubtablaTipoDocumento).HasColumnName("iIDSubtablaTipoDocumento");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.IIdusuarioModificacion).HasColumnName("iIDUsuarioModificacion");

                entity.Property(e => e.TNumeroDocumento)
                    .HasColumnName("tNumeroDocumento")
                    .HasMaxLength(200);

                entity.Property(e => e.TValorTipoDocumento)
                    .HasColumnName("tValorTipoDocumento")
                    .HasMaxLength(200);

                entity.HasOne(d => d.IIdestadoNavigation)
                    .WithMany(p => p.TblRecobrosDocumentos)
                    .HasForeignKey(d => d.IIdestado)
                    .HasConstraintName("FK_tblRecobrosDocumentos_tblRecobroEstadosDocumentos1");

                entity.HasOne(d => d.IIdrecobroNavigation)
                    .WithMany(p => p.TblRecobrosDocumentos)
                    .HasForeignKey(d => d.IIdrecobro)
                    .HasConstraintName("FK_tblRecobrosDocumentos_tblRecobros");

                entity.HasOne(d => d.IIdusuarioCreacionNavigation)
                    .WithMany(p => p.TblRecobrosDocumentosIIdusuarioCreacionNavigation)
                    .HasForeignKey(d => d.IIdusuarioCreacion)
                    .HasConstraintName("FK_tblRecobrosDocumentos_tblUsuarios");

                entity.HasOne(d => d.IIdusuarioModificacionNavigation)
                    .WithMany(p => p.TblRecobrosDocumentosIIdusuarioModificacionNavigation)
                    .HasForeignKey(d => d.IIdusuarioModificacion)
                    .HasConstraintName("FK_tblRecobrosDocumentos_tblUsuarios1");

                entity.HasOne(d => d.TblMultivalores)
                    .WithMany(p => p.TblRecobrosDocumentos)
                    .HasPrincipalKey(p => new { p.IIdsubtabla, p.TValor })
                    .HasForeignKey(d => new { d.IIdsubtablaTipoDocumento, d.TValorTipoDocumento })
                    .HasConstraintName("FK_tblRecobrosDocumentos_tblMultivalores");
            });

            modelBuilder.Entity<TblRecobrosDocumentosSoportes>(entity =>
            {
                entity.HasKey(e => e.IIdrecobroDocumentoSoporte);

                entity.ToTable("tblRecobrosDocumentosSoportes", "recobro");

                entity.Property(e => e.IIdrecobroDocumentoSoporte).HasColumnName("iIDRecobroDocumentoSoporte");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaModificacion)
                    .HasColumnName("dtFechaModificacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdrecobroDocumento).HasColumnName("iIDRecobroDocumento");

                entity.Property(e => e.IIdsubtablaTipoSoporte).HasColumnName("iIDSubtablaTipoSoporte");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.IIdusuarioModificacion).HasColumnName("iIDUsuarioModificacion");

                entity.Property(e => e.ITamanoArchivo)
                    .HasColumnName("iTamanoArchivo")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TDirectorio)
                    .HasColumnName("tDirectorio")
                    .HasMaxLength(200);

                entity.Property(e => e.TNombreArchivo)
                    .HasColumnName("tNombreArchivo")
                    .HasMaxLength(200);

                entity.Property(e => e.TNombreArchivoOriginal)
                    .HasColumnName("tNombreArchivoOriginal")
                    .HasMaxLength(200);

                entity.Property(e => e.TValorTipoSoporte)
                    .HasColumnName("tValorTipoSoporte")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<TblRecobrosDocumentosUsuarios>(entity =>
            {
                entity.HasKey(e => e.IIdrecobroDocumentoUsuario);

                entity.ToTable("tblRecobrosDocumentosUsuarios", "recobro");

                entity.Property(e => e.IIdrecobroDocumentoUsuario).HasColumnName("iIDRecobroDocumentoUsuario");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaModificacion)
                    .HasColumnName("dtFechaModificacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdrecobroDocumento).HasColumnName("iIDRecobroDocumento");

                entity.Property(e => e.IIdsubtablaTipoIdentificacion).HasColumnName("iIDSubtablaTipoIdentificacion");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.IIdusuarioModificacion).HasColumnName("iIDUsuarioModificacion");

                entity.Property(e => e.TNumeroIdentificacion)
                    .HasColumnName("tNumeroIdentificacion")
                    .HasMaxLength(200);

                entity.Property(e => e.TPrimerApellido)
                    .HasColumnName("tPrimerApellido")
                    .HasMaxLength(200);

                entity.Property(e => e.TPrimerNombre)
                    .HasColumnName("tPrimerNombre")
                    .HasMaxLength(200);

                entity.Property(e => e.TSegundoApellido)
                    .HasColumnName("tSegundoApellido")
                    .HasMaxLength(200);

                entity.Property(e => e.TSegundoNombre)
                    .HasColumnName("tSegundoNombre")
                    .HasMaxLength(200);

                entity.Property(e => e.TValorTipoIdentificacion)
                    .HasColumnName("tValorTipoIdentificacion")
                    .HasMaxLength(200);

                entity.HasOne(d => d.IIdrecobroDocumentoNavigation)
                    .WithMany(p => p.TblRecobrosDocumentosUsuarios)
                    .HasForeignKey(d => d.IIdrecobroDocumento)
                    .HasConstraintName("FK_tblRecobrosDocumentosUsuarios_tblRecobrosDocumentos");

                entity.HasOne(d => d.IIdusuarioCreacionNavigation)
                    .WithMany(p => p.TblRecobrosDocumentosUsuariosIIdusuarioCreacionNavigation)
                    .HasForeignKey(d => d.IIdusuarioCreacion)
                    .HasConstraintName("FK_tblRecobrosDocumentosUsuarios_tblUsuarios");

                entity.HasOne(d => d.IIdusuarioModificacionNavigation)
                    .WithMany(p => p.TblRecobrosDocumentosUsuariosIIdusuarioModificacionNavigation)
                    .HasForeignKey(d => d.IIdusuarioModificacion)
                    .HasConstraintName("FK_tblRecobrosDocumentosUsuarios_tblUsuarios1");

                entity.HasOne(d => d.TblMultivalores)
                    .WithMany(p => p.TblRecobrosDocumentosUsuarios)
                    .HasPrincipalKey(p => new { p.IIdsubtabla, p.TValor })
                    .HasForeignKey(d => new { d.IIdsubtablaTipoIdentificacion, d.TValorTipoIdentificacion })
                    .HasConstraintName("FK_tblRecobrosDocumentosUsuarios_tblMultivalores");
            });

            modelBuilder.Entity<TblRecobrosDocumentosUsuariosDiagnosticos>(entity =>
            {
                entity.HasKey(e => e.IIdrecobroDocumentoUsuarioDiagnostico);

                entity.ToTable("tblRecobrosDocumentosUsuariosDiagnosticos", "recobro");

                entity.Property(e => e.IIdrecobroDocumentoUsuarioDiagnostico).HasColumnName("iIDRecobroDocumentoUsuarioDiagnostico");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaDiagnostico)
                    .HasColumnName("dtFechaDiagnostico")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaInsercion)
                    .HasColumnName("dtFechaInsercion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaModificacion)
                    .HasColumnName("dtFechaModificacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaOcurrenciaOrigen)
                    .HasColumnName("dtFechaOcurrenciaOrigen")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIddiagnostico).HasColumnName("iIDDiagnostico");

                entity.Property(e => e.IIdrecobroDocumentoUsuario).HasColumnName("iIDRecobroDocumentoUsuario");

                entity.Property(e => e.IIdsubTablaTipoOrigen).HasColumnName("iIDSubTablaTipoOrigen");

                entity.Property(e => e.IIdusuarioInsercion).HasColumnName("iIDUsuarioInsercion");

                entity.Property(e => e.IIdusuarioModificacion).HasColumnName("iIDUsuarioModificacion");

                entity.Property(e => e.TValorTipoOrigen)
                    .HasColumnName("tValorTipoOrigen")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<TblRecobrosDocumentosUsuariosDiagnosticosSoportes>(entity =>
            {
                entity.HasKey(e => e.IIdrecobroDocumentoUsuarioDiagnosticoSoporte);

                entity.ToTable("tblRecobrosDocumentosUsuariosDiagnosticosSoportes", "recobro");

                entity.Property(e => e.IIdrecobroDocumentoUsuarioDiagnosticoSoporte).HasColumnName("iIDRecobroDocumentoUsuarioDiagnosticoSoporte");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaModificacion)
                    .HasColumnName("dtFechaModificacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdrecobroDocumentoUsuarioDiagnostico).HasColumnName("iIDRecobroDocumentoUsuarioDiagnostico");

                entity.Property(e => e.IIdsubtablaTipoSoporte).HasColumnName("iIDSubtablaTipoSoporte");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.IIdusuarioModificacion).HasColumnName("iIDUsuarioModificacion");

                entity.Property(e => e.ITamanoArchivo)
                    .HasColumnName("iTamanoArchivo")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TDirectorio)
                    .HasColumnName("tDirectorio")
                    .HasMaxLength(200);

                entity.Property(e => e.TNombreArchivo)
                    .HasColumnName("tNombreArchivo")
                    .HasMaxLength(200);

                entity.Property(e => e.TNombreArchivoOriginal)
                    .HasColumnName("tNombreArchivoOriginal")
                    .HasMaxLength(200);

                entity.Property(e => e.TValorTipoSoporte)
                    .HasColumnName("tValorTipoSoporte")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<TblRecobrosDocumentosUsuariosSoportes>(entity =>
            {
                entity.HasKey(e => e.IIdrecobroDocumentoUsuarioSoporte);

                entity.ToTable("tblRecobrosDocumentosUsuariosSoportes", "recobro");

                entity.Property(e => e.IIdrecobroDocumentoUsuarioSoporte).HasColumnName("iIDRecobroDocumentoUsuarioSoporte");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaModificacion)
                    .HasColumnName("dtFechaModificacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdrecobroDocumentoUsuario).HasColumnName("iIDRecobroDocumentoUsuario");

                entity.Property(e => e.IIdsubtablaTipoSoporte).HasColumnName("iIDSubtablaTipoSoporte");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.IIdusuarioModificacion).HasColumnName("iIDUsuarioModificacion");

                entity.Property(e => e.ITamanoArchivo)
                    .HasColumnName("iTamanoArchivo")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TDirectorio)
                    .HasColumnName("tDirectorio")
                    .HasMaxLength(200);

                entity.Property(e => e.TNombreArchivo)
                    .HasColumnName("tNombreArchivo")
                    .HasMaxLength(200);

                entity.Property(e => e.TNombreArchivoOriginal)
                    .HasColumnName("tNombreArchivoOriginal")
                    .HasMaxLength(200);

                entity.Property(e => e.TValorTipoSoporte)
                    .HasColumnName("tValorTipoSoporte")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<TblRecobrosSoportes>(entity =>
            {
                entity.HasKey(e => e.IIdrecobroSoporte);

                entity.ToTable("tblRecobrosSoportes", "recobro");

                entity.Property(e => e.IIdrecobroSoporte).HasColumnName("iIDRecobroSoporte");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaModificacion)
                    .HasColumnName("dtFechaModificacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdrecobro).HasColumnName("iIDRecobro");

                entity.Property(e => e.IIdsubtablaTipoSoporte).HasColumnName("iIDSubtablaTipoSoporte");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.IIdusuarioModificacion).HasColumnName("iIDUsuarioModificacion");

                entity.Property(e => e.ITamanoArchivo)
                    .HasColumnName("iTamanoArchivo")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TDirectorio)
                    .HasColumnName("tDirectorio")
                    .HasMaxLength(200);

                entity.Property(e => e.TNombreArchivo)
                    .HasColumnName("tNombreArchivo")
                    .HasMaxLength(200);

                entity.Property(e => e.TNombreArchivoOriginal)
                    .HasColumnName("tNombreArchivoOriginal")
                    .HasMaxLength(200);

                entity.Property(e => e.TValorTipoSoporte)
                    .HasColumnName("tValorTipoSoporte")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<TblRecobrosUsuariosElementos>(entity =>
            {
                entity.HasKey(e => e.IIdrecobroUsuarioElemento);

                entity.ToTable("tblRecobrosUsuariosElementos", "recobro");

                entity.Property(e => e.IIdrecobroUsuarioElemento).HasColumnName("iIDRecobroUsuarioElemento");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaEntrega)
                    .HasColumnName("dtFechaEntrega")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaFormulacion)
                    .HasColumnName("dtFechaFormulacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaModificacion)
                    .HasColumnName("dtFechaModificacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.ICantidad).HasColumnName("iCantidad");

                entity.Property(e => e.IIdelemento).HasColumnName("iIDElemento");

                entity.Property(e => e.IIdrecobroDocumentoUsuarioDiagnostico).HasColumnName("iIDRecobroDocumentoUsuarioDiagnostico");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.IIdusuarioModificacion).HasColumnName("iIDUsuarioModificacion");

                entity.Property(e => e.TCodigoAutorizacion)
                    .HasColumnName("tCodigoAutorizacion")
                    .HasMaxLength(200);

                entity.Property(e => e.TNombreQuienFormula)
                    .HasColumnName("tNombreQuienFormula")
                    .HasMaxLength(300);

                entity.HasOne(d => d.IIdrecobroDocumentoUsuarioDiagnosticoNavigation)
                    .WithMany(p => p.TblRecobrosUsuariosElementos)
                    .HasForeignKey(d => d.IIdrecobroDocumentoUsuarioDiagnostico)
                    .HasConstraintName("FK_tblRecobrosUsuariosElementos_tblRecobrosDocumentosUsuariosDiagnosticos");

                entity.HasOne(d => d.IIdusuarioCreacionNavigation)
                    .WithMany(p => p.TblRecobrosUsuariosElementosIIdusuarioCreacionNavigation)
                    .HasForeignKey(d => d.IIdusuarioCreacion)
                    .HasConstraintName("FK_tblRecobrosUsuariosElementos_tblUsuarios");

                entity.HasOne(d => d.IIdusuarioModificacionNavigation)
                    .WithMany(p => p.TblRecobrosUsuariosElementosIIdusuarioModificacionNavigation)
                    .HasForeignKey(d => d.IIdusuarioModificacion)
                    .HasConstraintName("FK_tblRecobrosUsuariosElementos_tblUsuarios1");
            });

            modelBuilder.Entity<TblRecobrosUsuariosElementosSoportes>(entity =>
            {
                entity.HasKey(e => e.IIdrecobroUsuarioElementosSoporte);

                entity.ToTable("tblRecobrosUsuariosElementosSoportes", "recobro");

                entity.Property(e => e.IIdrecobroUsuarioElementosSoporte).HasColumnName("iIDRecobroUsuarioElementosSoporte");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaModificacion)
                    .HasColumnName("dtFechaModificacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdrecobroUsuarioElemento).HasColumnName("iIDRecobroUsuarioElemento");

                entity.Property(e => e.IIdsubtablaTipoSoporte).HasColumnName("iIDSubtablaTipoSoporte");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.IIdusuarioModificacion).HasColumnName("iIDUsuarioModificacion");

                entity.Property(e => e.ITamanoArchivo)
                    .HasColumnName("iTamanoArchivo")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TDirectorio)
                    .HasColumnName("tDirectorio")
                    .HasMaxLength(200);

                entity.Property(e => e.TNombreArchivo)
                    .HasColumnName("tNombreArchivo")
                    .HasMaxLength(200);

                entity.Property(e => e.TNombreArchivoOriginal)
                    .HasColumnName("tNombreArchivoOriginal")
                    .HasMaxLength(200);

                entity.Property(e => e.TValorTipoSoporte)
                    .HasColumnName("tValorTipoSoporte")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<TblRecobrosUsuariosMedicamentos>(entity =>
            {
                entity.HasKey(e => e.IIdrecobroUsuarioMedicamento)
                    .HasName("PK_tblRecobroUsuarioMedicamentos");

                entity.ToTable("tblRecobrosUsuariosMedicamentos", "recobro");

                entity.Property(e => e.IIdrecobroUsuarioMedicamento).HasColumnName("iIDRecobroUsuarioMedicamento");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaEntrega)
                    .HasColumnName("dtFechaEntrega")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaFormulacion)
                    .HasColumnName("dtFechaFormulacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaModificacion)
                    .HasColumnName("dtFechaModificacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.ICantidad).HasColumnName("iCantidad");

                entity.Property(e => e.IIdmedicamento).HasColumnName("iIDMedicamento");

                entity.Property(e => e.IIdrecobroDocumentoUsuarioDiagnostico).HasColumnName("iIDRecobroDocumentoUsuarioDiagnostico");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.IIdusuarioModificacion).HasColumnName("iIDUsuarioModificacion");

                entity.Property(e => e.TCodigoAutorizacion)
                    .HasColumnName("tCodigoAutorizacion")
                    .HasMaxLength(200);

                entity.Property(e => e.TNombreQuienFormula)
                    .HasColumnName("tNombreQuienFormula")
                    .HasMaxLength(300);
            });

            modelBuilder.Entity<TblRecobrosUsuariosMedicamentosSoportes>(entity =>
            {
                entity.HasKey(e => e.IIdrecobroUsuarioMedicamentoSoporte);

                entity.ToTable("tblRecobrosUsuariosMedicamentosSoportes", "recobro");

                entity.Property(e => e.IIdrecobroUsuarioMedicamentoSoporte).HasColumnName("iIDRecobroUsuarioMedicamentoSoporte");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaModificacion)
                    .HasColumnName("dtFechaModificacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdrecobroUsuarioMedicamento).HasColumnName("iIDRecobroUsuarioMedicamento");

                entity.Property(e => e.IIdsubtablaTipoSoporte).HasColumnName("iIDSubtablaTipoSoporte");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.IIdusuarioModificacion).HasColumnName("iIDUsuarioModificacion");

                entity.Property(e => e.ITamanoArchivo)
                    .HasColumnName("iTamanoArchivo")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TDirectorio)
                    .HasColumnName("tDirectorio")
                    .HasMaxLength(200);

                entity.Property(e => e.TNombreArchivo)
                    .HasColumnName("tNombreArchivo")
                    .HasMaxLength(200);

                entity.Property(e => e.TNombreArchivoOriginal)
                    .HasColumnName("tNombreArchivoOriginal")
                    .HasMaxLength(200);

                entity.Property(e => e.TValorTipoSoporte)
                    .HasColumnName("tValorTipoSoporte")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<TblRecobrosUsuariosServiciosProcedimientos>(entity =>
            {
                entity.HasKey(e => e.IIdrecobroUsuarioServicioProcedimiento);

                entity.ToTable("tblRecobrosUsuariosServiciosProcedimientos", "recobro");

                entity.Property(e => e.IIdrecobroUsuarioServicioProcedimiento).HasColumnName("iIDRecobroUsuarioServicioProcedimiento");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaEntrega)
                    .HasColumnName("dtFechaEntrega")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaFormulacion)
                    .HasColumnName("dtFechaFormulacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaModificacion)
                    .HasColumnName("dtFechaModificacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.ICantidad).HasColumnName("iCantidad");

                entity.Property(e => e.IIdrecobroDocumentoUsuarioDiagnostico).HasColumnName("iIDRecobroDocumentoUsuarioDiagnostico");

                entity.Property(e => e.IIdservicioProcedimiento).HasColumnName("iIDServicioProcedimiento");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.IIdusuarioModificacion).HasColumnName("iIDUsuarioModificacion");

                entity.Property(e => e.TCodigoAutorizacion)
                    .HasColumnName("tCodigoAutorizacion")
                    .HasMaxLength(200);

                entity.Property(e => e.TNombreQuienFormula)
                    .HasColumnName("tNombreQuienFormula")
                    .HasMaxLength(300);

                entity.HasOne(d => d.IIdrecobroDocumentoUsuarioDiagnosticoNavigation)
                    .WithMany(p => p.TblRecobrosUsuariosServiciosProcedimientos)
                    .HasForeignKey(d => d.IIdrecobroDocumentoUsuarioDiagnostico)
                    .HasConstraintName("FK_tblRecobrosUsuariosServiciosProcedimientos_tblRecobrosDocumentosUsuariosDiagnosticos");

                entity.HasOne(d => d.IIdservicioProcedimientoNavigation)
                    .WithMany(p => p.TblRecobrosUsuariosServiciosProcedimientos)
                    .HasForeignKey(d => d.IIdservicioProcedimiento)
                    .HasConstraintName("FK_tblRecobrosUsuariosServiciosProcedimientos_tblServiciosProcedimientos");

                entity.HasOne(d => d.IIdusuarioCreacionNavigation)
                    .WithMany(p => p.TblRecobrosUsuariosServiciosProcedimientosIIdusuarioCreacionNavigation)
                    .HasForeignKey(d => d.IIdusuarioCreacion)
                    .HasConstraintName("FK_tblRecobrosUsuariosServiciosProcedimientos_tblUsuarios");

                entity.HasOne(d => d.IIdusuarioModificacionNavigation)
                    .WithMany(p => p.TblRecobrosUsuariosServiciosProcedimientosIIdusuarioModificacionNavigation)
                    .HasForeignKey(d => d.IIdusuarioModificacion)
                    .HasConstraintName("FK_tblRecobrosUsuariosServiciosProcedimientos_tblUsuarios1");
            });

            modelBuilder.Entity<TblRecobrosUsuariosServiciosProcedimientosSoportes>(entity =>
            {
                entity.HasKey(e => e.IIdrecobroUsuarioServiciosProcedimientosSoporte);

                entity.ToTable("tblRecobrosUsuariosServiciosProcedimientosSoportes", "recobro");

                entity.Property(e => e.IIdrecobroUsuarioServiciosProcedimientosSoporte).HasColumnName("iIDRecobroUsuarioServiciosProcedimientosSoporte");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaModificacion)
                    .HasColumnName("dtFechaModificacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdrecobroUsuarioServicioProcedimiento).HasColumnName("iIDRecobroUsuarioServicioProcedimiento");

                entity.Property(e => e.IIdsubtablaTipoSoporte).HasColumnName("iIDSubtablaTipoSoporte");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.IIdusuarioModificacion).HasColumnName("iIDUsuarioModificacion");

                entity.Property(e => e.ITamanoArchivo)
                    .HasColumnName("iTamanoArchivo")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TDirectorio)
                    .HasColumnName("tDirectorio")
                    .HasMaxLength(200);

                entity.Property(e => e.TNombreArchivo)
                    .HasColumnName("tNombreArchivo")
                    .HasMaxLength(200);

                entity.Property(e => e.TNombreArchivoOriginal)
                    .HasColumnName("tNombreArchivoOriginal")
                    .HasMaxLength(200);

                entity.Property(e => e.TValorTipoSoporte)
                    .HasColumnName("tValorTipoSoporte")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<TblRecursos>(entity =>
            {
                entity.HasKey(e => e.IIdrecurso);

                entity.ToTable("tblRecursos", "proceso");

                entity.Property(e => e.IIdrecurso).HasColumnName("iIDRecurso");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.ICantidadValor).HasColumnName("iCantidadValor");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IIdproceso).HasColumnName("iIDProceso");

                entity.Property(e => e.IIdsubtablaTipoRecurso).HasColumnName("iIDSubtablaTipoRecurso");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.TDescripcion)
                    .IsRequired()
                    .HasColumnName("tDescripcion")
                    .HasMaxLength(300);

                entity.Property(e => e.TIdvalorTipoRecurso)
                    .IsRequired()
                    .HasColumnName("tIDValorTipoRecurso")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblRecursos)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRecursos_tblEmpresas");

                entity.HasOne(d => d.IIdprocesoNavigation)
                    .WithMany(p => p.TblRecursos)
                    .HasForeignKey(d => d.IIdproceso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRecursos_tblEmpresaProcesos");

                entity.HasOne(d => d.IIdusuarioCreacionNavigation)
                    .WithMany(p => p.TblRecursos)
                    .HasForeignKey(d => d.IIdusuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRecursos_tblUsuarios");
            });

            modelBuilder.Entity<TblRegimenAfiliacion>(entity =>
            {
                entity.HasKey(e => e.IId)
                    .HasName("PK__tblRegim__DC512D720DE71FBD");

                entity.ToTable("tblRegimenAfiliacion", "Incapacidades");

                entity.Property(e => e.IId).HasColumnName("iID");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.TNombre)
                    .IsRequired()
                    .HasColumnName("tNombre")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblRhsi>(entity =>
            {
                entity.HasKey(e => new { e.IIdempresa, e.IIdformato, e.DtFechaRhsi })
                    .HasName("PK_administracion.tblRHSI");

                entity.ToTable("tblRHSI", "negocio");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IIdformato).HasColumnName("iIDFormato");

                entity.Property(e => e.DtFechaRhsi)
                    .HasColumnName("dtFechaRHSI")
                    .HasColumnType("date");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.TArl)
                    .IsRequired()
                    .HasColumnName("tARL")
                    .HasMaxLength(100);

                entity.Property(e => e.TCiudad)
                    .IsRequired()
                    .HasColumnName("tCiudad")
                    .HasMaxLength(50);

                entity.Property(e => e.TDepartamento)
                    .IsRequired()
                    .HasColumnName("tDepartamento")
                    .HasMaxLength(50);

                entity.Property(e => e.TDireccion)
                    .IsRequired()
                    .HasColumnName("tDireccion")
                    .HasMaxLength(100);

                entity.Property(e => e.TNit)
                    .IsRequired()
                    .HasColumnName("tNit")
                    .HasMaxLength(50);

                entity.Property(e => e.TNombreEmpresa)
                    .IsRequired()
                    .HasColumnName("tNombreEmpresa")
                    .HasMaxLength(100);

                entity.Property(e => e.TPais)
                    .IsRequired()
                    .HasColumnName("tPais")
                    .HasMaxLength(50);

                entity.Property(e => e.TRepresentanteLegal)
                    .IsRequired()
                    .HasColumnName("tRepresentanteLegal")
                    .HasMaxLength(150);

                entity.Property(e => e.TSucursales)
                    .IsRequired()
                    .HasColumnName("tSucursales")
                    .HasMaxLength(500);

                entity.Property(e => e.TTelefono)
                    .IsRequired()
                    .HasColumnName("tTelefono")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblRhsi)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRHSI_tblEmpresas");

                entity.HasOne(d => d.IIdformatoNavigation)
                    .WithMany(p => p.TblRhsi)
                    .HasForeignKey(d => d.IIdformato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRHSI_tblFormatos");

                entity.HasOne(d => d.IIdusuarioCreacionNavigation)
                    .WithMany(p => p.TblRhsi)
                    .HasForeignKey(d => d.IIdusuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRHSI_tblUsuarios");
            });

            modelBuilder.Entity<TblRhsiactividadEconomica>(entity =>
            {
                entity.HasKey(e => e.IIdrhsiactividadEconomica);

                entity.ToTable("tblRHSIActividadEconomica", "negocio");

                entity.Property(e => e.IIdrhsiactividadEconomica).HasColumnName("iIDRHSIActividadEconomica");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaRhsi)
                    .HasColumnName("dtFechaRHSI")
                    .HasColumnType("date");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IIdformato).HasColumnName("iIDFormato");

                entity.Property(e => e.TActividadEconomica)
                    .IsRequired()
                    .HasColumnName("tActividadEconomica")
                    .HasMaxLength(1000);

                entity.Property(e => e.TCodigo)
                    .IsRequired()
                    .HasColumnName("tCodigo")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblRhsiactividadEconomica)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRHSIActividadEconomica_tblEmpresas");

                entity.HasOne(d => d.IIdformatoNavigation)
                    .WithMany(p => p.TblRhsiactividadEconomica)
                    .HasForeignKey(d => d.IIdformato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRHSIActividadEconomica_tblFormatos");
            });

            modelBuilder.Entity<TblRhsiriesgos>(entity =>
            {
                entity.HasKey(e => e.IIdrhsiriesgo)
                    .HasName("PK_administracion.tblRHSIRiesgos");

                entity.ToTable("tblRHSIRiesgos", "negocio");

                entity.Property(e => e.IIdrhsiriesgo).HasColumnName("iIDRHSIRiesgo");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaRhsi)
                    .HasColumnName("dtFechaRHSI")
                    .HasColumnType("date");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IIdformato).HasColumnName("iIDFormato");

                entity.Property(e => e.TArea)
                    .IsRequired()
                    .HasColumnName("tArea")
                    .HasMaxLength(50);

                entity.Property(e => e.TTipoRiesgo)
                    .IsRequired()
                    .HasColumnName("tTipoRiesgo")
                    .HasMaxLength(50);

                entity.Property(e => e.Triesgo)
                    .IsRequired()
                    .HasColumnName("TRiesgo")
                    .HasMaxLength(1000);

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblRhsiriesgos)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRHSIRiesgos_tblEmpresas");

                entity.HasOne(d => d.IIdformatoNavigation)
                    .WithMany(p => p.TblRhsiriesgos)
                    .HasForeignKey(d => d.IIdformato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRHSIRiesgos_tblFormatos");
            });

            modelBuilder.Entity<TblRiesgoAnalisis>(entity =>
            {
                entity.HasKey(e => e.IIdriesgoAnalisis);

                entity.ToTable("tblRiesgoAnalisis", "proceso");

                entity.Property(e => e.IIdriesgoAnalisis).HasColumnName("iIDRiesgoAnalisis");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaInsercion)
                    .HasColumnName("dtFechaInsercion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdriesgoIdentificacion).HasColumnName("iIDRiesgoIdentificacion");

                entity.Property(e => e.IIdsubtablaRiesgoImpacto).HasColumnName("iIDSubtablaRiesgoImpacto");

                entity.Property(e => e.IIdsubtablaRiesgoProbabilidad).HasColumnName("iIDSubtablaRiesgoProbabilidad");

                entity.Property(e => e.IUsuarioInsercion).HasColumnName("iUsuarioInsercion");

                entity.Property(e => e.TEvaluacion)
                    .IsRequired()
                    .HasColumnName("tEvaluacion")
                    .HasMaxLength(100);

                entity.Property(e => e.TIdvalorRiesgoImpacto)
                    .IsRequired()
                    .HasColumnName("tIDValorRiesgoImpacto")
                    .HasMaxLength(100);

                entity.Property(e => e.TIdvalorRiesgoProbabilidad)
                    .IsRequired()
                    .HasColumnName("tIDValorRiesgoProbabilidad")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IUsuarioInsercionNavigation)
                    .WithMany(p => p.TblRiesgoAnalisis)
                    .HasForeignKey(d => d.IUsuarioInsercion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRiesgoAnalisis_tblUsuarios");
            });

            modelBuilder.Entity<TblRiesgoCausas>(entity =>
            {
                entity.HasKey(e => e.IIdriesgoCausa);

                entity.ToTable("tblRiesgoCausas", "proceso");

                entity.Property(e => e.IIdriesgoCausa).HasColumnName("iIDRiesgoCausa");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaInsercion)
                    .HasColumnName("dtFechaInsercion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdriesgoIdentificacion).HasColumnName("iIDRiesgoIdentificacion");

                entity.Property(e => e.IUsuarioInsercion).HasColumnName("iUsuarioInsercion");

                entity.Property(e => e.TCausa)
                    .IsRequired()
                    .HasColumnName("tCausa")
                    .HasMaxLength(250);

                entity.HasOne(d => d.IUsuarioInsercionNavigation)
                    .WithMany(p => p.TblRiesgoCausas)
                    .HasForeignKey(d => d.IUsuarioInsercion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRiesgoCausas_tblUsuarios");
            });

            modelBuilder.Entity<TblRiesgoControlValoraciones>(entity =>
            {
                entity.HasKey(e => e.IIdriesgoControlValoracion);

                entity.ToTable("tblRiesgoControlValoraciones", "proceso");

                entity.Property(e => e.IIdriesgoControlValoracion).HasColumnName("iIDRiesgoControlValoracion");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaInsercion)
                    .HasColumnName("dtFechaInsercion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdcontrolEficacia).HasColumnName("iIDControlEficacia");

                entity.Property(e => e.IIdcontrolFrecuencia).HasColumnName("iIDControlFrecuencia");

                entity.Property(e => e.IIdcontrolHerramienta).HasColumnName("iIDControlHerramienta");

                entity.Property(e => e.IIdcontrolProcedimiento).HasColumnName("iIDControlProcedimiento");

                entity.Property(e => e.IIdcontrolResponsable).HasColumnName("iIDControlResponsable");

                entity.Property(e => e.IIdriesgoControl).HasColumnName("iIDRiesgoControl");

                entity.Property(e => e.ITotal).HasColumnName("iTotal");

                entity.Property(e => e.IUsuarioInsercion).HasColumnName("iUsuarioInsercion");

                entity.HasOne(d => d.IIdcontrolEficaciaNavigation)
                    .WithMany(p => p.TblRiesgoControlValoraciones)
                    .HasForeignKey(d => d.IIdcontrolEficacia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRiesgoControlValoraciones_tblEmpresaControlEficacia");

                entity.HasOne(d => d.IIdcontrolFrecuenciaNavigation)
                    .WithMany(p => p.TblRiesgoControlValoraciones)
                    .HasForeignKey(d => d.IIdcontrolFrecuencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRiesgoControlValoraciones_tblEmpresaControlFrecuencia");

                entity.HasOne(d => d.IIdcontrolHerramientaNavigation)
                    .WithMany(p => p.TblRiesgoControlValoraciones)
                    .HasForeignKey(d => d.IIdcontrolHerramienta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRiesgoControlValoraciones_tblEmpresaControlHerramientas");

                entity.HasOne(d => d.IIdcontrolProcedimientoNavigation)
                    .WithMany(p => p.TblRiesgoControlValoraciones)
                    .HasForeignKey(d => d.IIdcontrolProcedimiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRiesgoControlValoraciones_tblEmpresaControlProcedimientos");

                entity.HasOne(d => d.IIdcontrolResponsableNavigation)
                    .WithMany(p => p.TblRiesgoControlValoraciones)
                    .HasForeignKey(d => d.IIdcontrolResponsable)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRiesgoControlValoraciones_tblEmpresaControlResponsable");

                entity.HasOne(d => d.IIdriesgoControlNavigation)
                    .WithMany(p => p.TblRiesgoControlValoraciones)
                    .HasForeignKey(d => d.IIdriesgoControl)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRiesgoControlValoraciones_tblRiesgoControles");

                entity.HasOne(d => d.IUsuarioInsercionNavigation)
                    .WithMany(p => p.TblRiesgoControlValoraciones)
                    .HasForeignKey(d => d.IUsuarioInsercion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRiesgoControlValoraciones_tblUsuarios");
            });

            modelBuilder.Entity<TblRiesgoControles>(entity =>
            {
                entity.HasKey(e => e.IIdriesgoControl);

                entity.ToTable("tblRiesgoControles", "proceso");

                entity.Property(e => e.IIdriesgoControl).HasColumnName("iIDRiesgoControl");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaInsercion)
                    .HasColumnName("dtFechaInsercion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdriesgoIdentificacion).HasColumnName("iIDRiesgoIdentificacion");

                entity.Property(e => e.IIdsubtablaTipoControl).HasColumnName("iIDSubtablaTipoControl");

                entity.Property(e => e.IUsuarioInsercion).HasColumnName("iUsuarioInsercion");

                entity.Property(e => e.TControl)
                    .IsRequired()
                    .HasColumnName("tControl")
                    .HasMaxLength(250);

                entity.Property(e => e.TIdvalorTipoControl)
                    .IsRequired()
                    .HasColumnName("tIDValorTipoControl")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IUsuarioInsercionNavigation)
                    .WithMany(p => p.TblRiesgoControles)
                    .HasForeignKey(d => d.IUsuarioInsercion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRiesgoControles_tblUsuarios");
            });

            modelBuilder.Entity<TblRiesgoEfectos>(entity =>
            {
                entity.HasKey(e => e.IIdriesgoEfecto);

                entity.ToTable("tblRiesgoEfectos", "proceso");

                entity.Property(e => e.IIdriesgoEfecto).HasColumnName("iIDRiesgoEfecto");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaInsercion)
                    .HasColumnName("dtFechaInsercion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdriesgoIdentificacion).HasColumnName("iIDRiesgoIdentificacion");

                entity.Property(e => e.IUsuarioInsercion).HasColumnName("iUsuarioInsercion");

                entity.Property(e => e.TEfecto)
                    .IsRequired()
                    .HasColumnName("tEfecto")
                    .HasMaxLength(250);

                entity.HasOne(d => d.IUsuarioInsercionNavigation)
                    .WithMany(p => p.TblRiesgoEfectos)
                    .HasForeignKey(d => d.IUsuarioInsercion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRiesgoEfectos_tblUsuarios");
            });

            modelBuilder.Entity<TblRiesgoIdentificacion>(entity =>
            {
                entity.HasKey(e => e.IIdriesgoIdentificacion);

                entity.ToTable("tblRiesgoIdentificacion", "proceso");

                entity.Property(e => e.IIdriesgoIdentificacion).HasColumnName("iIDRiesgoIdentificacion");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaInsercion)
                    .HasColumnName("dtFechaInsercion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IIdproceso).HasColumnName("iIDProceso");

                entity.Property(e => e.IIdsubtablaTipoRiesgo).HasColumnName("iIDSubtablaTipoRiesgo");

                entity.Property(e => e.IUsuarioInsercion).HasColumnName("iUsuarioInsercion");

                entity.Property(e => e.TDescripcionAgente)
                    .IsRequired()
                    .HasColumnName("tDescripcionAgente")
                    .HasMaxLength(250);

                entity.Property(e => e.TDescripcionRiesgo)
                    .IsRequired()
                    .HasColumnName("tDescripcionRiesgo")
                    .HasMaxLength(250);

                entity.Property(e => e.TIdvalorTipoRiesgo)
                    .IsRequired()
                    .HasColumnName("tIDValorTipoRiesgo")
                    .HasMaxLength(100);

                entity.Property(e => e.TNombreRiesgo)
                    .IsRequired()
                    .HasColumnName("tNombreRiesgo")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblRiesgoIdentificacion)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRiesgoIdentificacion_tblEmpresas");

                entity.HasOne(d => d.IIdprocesoNavigation)
                    .WithMany(p => p.TblRiesgoIdentificacion)
                    .HasForeignKey(d => d.IIdproceso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRiesgoIdentificacion_tblEmpresaProcesos");

                entity.HasOne(d => d.IUsuarioInsercionNavigation)
                    .WithMany(p => p.TblRiesgoIdentificacion)
                    .HasForeignKey(d => d.IUsuarioInsercion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRiesgoIdentificacion_tblUsuarios");
            });

            modelBuilder.Entity<TblRiesgoResidual>(entity =>
            {
                entity.HasKey(e => e.IIdriesgoResidual);

                entity.ToTable("tblRiesgoResidual", "proceso");

                entity.Property(e => e.IIdriesgoResidual).HasColumnName("iIDRiesgoResidual");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaInsercion)
                    .HasColumnName("dtFechaInsercion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdriesgoIdentificacion).HasColumnName("iIDRiesgoIdentificacion");

                entity.Property(e => e.IIdsubtablaOpcionManejo).HasColumnName("iIDSubtablaOpcionManejo");

                entity.Property(e => e.IIdsubtablaRiesgoImpacto).HasColumnName("iIDSubtablaRiesgoImpacto");

                entity.Property(e => e.IIdsubtablaRiesgoProbabilidad).HasColumnName("iIDSubtablaRiesgoProbabilidad");

                entity.Property(e => e.IUsuarioInsercion).HasColumnName("iUsuarioInsercion");

                entity.Property(e => e.TIdvalorOpcionManejo)
                    .HasColumnName("tIDValorOpcionManejo")
                    .HasMaxLength(100);

                entity.Property(e => e.TIdvalorRiesgoImpacto)
                    .IsRequired()
                    .HasColumnName("tIDValorRiesgoImpacto")
                    .HasMaxLength(100);

                entity.Property(e => e.TIdvalorRiesgoProbabilidad)
                    .IsRequired()
                    .HasColumnName("tIDValorRiesgoProbabilidad")
                    .HasMaxLength(100);

                entity.Property(e => e.TValoracion)
                    .IsRequired()
                    .HasColumnName("tValoracion")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IIdriesgoIdentificacionNavigation)
                    .WithMany(p => p.TblRiesgoResidual)
                    .HasForeignKey(d => d.IIdriesgoIdentificacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRiesgoResidual_tblRiesgoIdentificacion");

                entity.HasOne(d => d.IUsuarioInsercionNavigation)
                    .WithMany(p => p.TblRiesgoResidual)
                    .HasForeignKey(d => d.IUsuarioInsercion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRiesgoResidual_tblUsuarios");
            });

            modelBuilder.Entity<TblRiesgoResidualAcciones>(entity =>
            {
                entity.HasKey(e => e.IIdriesgoResidualAccion);

                entity.ToTable("tblRiesgoResidualAcciones", "proceso");

                entity.Property(e => e.IIdriesgoResidualAccion).HasColumnName("iIDRiesgoResidualAccion");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaInsercion)
                    .HasColumnName("dtFechaInsercion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdresponsable).HasColumnName("iIDResponsable");

                entity.Property(e => e.IIdriesgoResidual).HasColumnName("iIDRiesgoResidual");

                entity.Property(e => e.IUsuarioInsercion).HasColumnName("iUsuarioInsercion");

                entity.Property(e => e.TAccion)
                    .IsRequired()
                    .HasColumnName("tAccion")
                    .HasMaxLength(200);

                entity.Property(e => e.TIndicadores)
                    .IsRequired()
                    .HasColumnName("tIndicadores")
                    .HasMaxLength(200);

                entity.HasOne(d => d.IIdriesgoResidualNavigation)
                    .WithMany(p => p.TblRiesgoResidualAcciones)
                    .HasForeignKey(d => d.IIdriesgoResidual)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRiesgoResidualAcciones_tblRiesgoResidual");
            });

            modelBuilder.Entity<TblServiciosProcedimientos>(entity =>
            {
                entity.HasKey(e => e.IIdservicioProcedimiento);

                entity.ToTable("tblServiciosProcedimientos", "administracion");

                entity.Property(e => e.IIdservicioProcedimiento).HasColumnName("iIDServicioProcedimiento");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaInsercion)
                    .HasColumnName("dtFechaInsercion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaModificacion)
                    .HasColumnName("dtFechaModificacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdpais).HasColumnName("iIDPais");

                entity.Property(e => e.IIdusuarioInsercion).HasColumnName("iIDUsuarioInsercion");

                entity.Property(e => e.IIdusuarioModificacion).HasColumnName("iIDUsuarioModificacion");

                entity.Property(e => e.TCodigo)
                    .HasColumnName("tCodigo")
                    .HasMaxLength(200);

                entity.Property(e => e.TDescripcion)
                    .HasColumnName("tDescripcion")
                    .HasMaxLength(300);

                entity.HasOne(d => d.IIdusuarioInsercionNavigation)
                    .WithMany(p => p.TblServiciosProcedimientosIIdusuarioInsercionNavigation)
                    .HasForeignKey(d => d.IIdusuarioInsercion)
                    .HasConstraintName("FK_tblServiciosProcedimientos_tblUsuarios");

                entity.HasOne(d => d.IIdusuarioModificacionNavigation)
                    .WithMany(p => p.TblServiciosProcedimientosIIdusuarioModificacionNavigation)
                    .HasForeignKey(d => d.IIdusuarioModificacion)
                    .HasConstraintName("FK_tblServiciosProcedimientos_tblUsuarios1");
            });

            modelBuilder.Entity<TblSoa>(entity =>
            {
                entity.HasKey(e => e.IIdsoa);

                entity.ToTable("tblSOA", "proceso");

                entity.Property(e => e.IIdsoa).HasColumnName("iIDSOA");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IIdnumeral).HasColumnName("iIDNumeral");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TAplicacion)
                    .IsRequired()
                    .HasColumnName("tAplicacion")
                    .HasMaxLength(300);

                entity.Property(e => e.TJustificacion)
                    .IsRequired()
                    .HasColumnName("tJustificacion")
                    .HasMaxLength(300);

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblSoa)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblSOA_tblEmpresas");

                entity.HasOne(d => d.IIdnumeralNavigation)
                    .WithMany(p => p.TblSoa)
                    .HasForeignKey(d => d.IIdnumeral)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblSOA_tblNumerales");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblSoa)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblSOA_tblUsuarios");
            });

            modelBuilder.Entity<TblSoportes>(entity =>
            {
                entity.HasKey(e => e.IIdsoporte)
                    .HasName("PK_tblSoportes_1");

                entity.ToTable("tblSoportes", "negocio");

                entity.Property(e => e.IIdsoporte).HasColumnName("iIDSoporte");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdclaseSoporte).HasColumnName("iIDClaseSoporte");

                entity.Property(e => e.IIddocumento).HasColumnName("iIDDocumento");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IIdplataforma).HasColumnName("iIDPlataforma");

                entity.Property(e => e.IIdtipoDocumento).HasColumnName("iIDTipoDocumento");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.ITamañoArchivo).HasColumnName("iTamañoArchivo");

                entity.Property(e => e.TDirectorio)
                    .IsRequired()
                    .HasColumnName("tDirectorio")
                    .HasMaxLength(4000);

                entity.Property(e => e.TNombreArchivo)
                    .IsRequired()
                    .HasColumnName("tNombreArchivo")
                    .HasMaxLength(4000);

                entity.HasOne(d => d.IIdclaseSoporteNavigation)
                    .WithMany(p => p.TblSoportesIIdclaseSoporteNavigation)
                    .HasForeignKey(d => d.IIdclaseSoporte)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblSoportes_tblMultivalores");

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblSoportes)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblSoportes_tblEmpresas");

                entity.HasOne(d => d.IIdtipoDocumentoNavigation)
                    .WithMany(p => p.TblSoportesIIdtipoDocumentoNavigation)
                    .HasForeignKey(d => d.IIdtipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblSoportes_tblMultivalores1");

                entity.HasOne(d => d.IIdusuarioCreacionNavigation)
                    .WithMany(p => p.TblSoportes)
                    .HasForeignKey(d => d.IIdusuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblSoportes_tblUsuarios");
            });

            modelBuilder.Entity<TblSoportes1>(entity =>
            {
                entity.HasKey(e => e.IIdsoporte);

                entity.ToTable("tblSoportes", "jurisprudencia");

                entity.Property(e => e.IIdsoporte).HasColumnName("iIDSoporte");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdjurisprudencia).HasColumnName("iIDJurisprudencia");

                entity.Property(e => e.IIdplataforma).HasColumnName("iIDPlataforma");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.ITamañoArchivo).HasColumnName("iTamañoArchivo");

                entity.Property(e => e.TDirectorio)
                    .IsRequired()
                    .HasColumnName("tDirectorio")
                    .HasMaxLength(4000);

                entity.Property(e => e.TNombreArchivo)
                    .IsRequired()
                    .HasColumnName("tNombreArchivo")
                    .HasMaxLength(4000);

                entity.HasOne(d => d.IIdjurisprudenciaNavigation)
                    .WithMany(p => p.TblSoportes1)
                    .HasForeignKey(d => d.IIdjurisprudencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblSoportes_tblJurisprudencias");

                entity.HasOne(d => d.IIdusuarioCreacionNavigation)
                    .WithMany(p => p.TblSoportes1)
                    .HasForeignKey(d => d.IIdusuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblSoportes_tblUsuarios");
            });

            modelBuilder.Entity<TblSucursalRiesgo>(entity =>
            {
                entity.HasKey(e => new { e.IIdsucursal, e.IIdclaseRiesgo, e.IIdcodigoRiesgo });

                entity.ToTable("tblSucursalRiesgo", "negocio");

                entity.Property(e => e.IIdsucursal).HasColumnName("iIDSucursal");

                entity.Property(e => e.IIdclaseRiesgo).HasColumnName("iIDClaseRiesgo");

                entity.Property(e => e.IIdcodigoRiesgo).HasColumnName("iIDCodigoRiesgo");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.HasOne(d => d.IIdclaseRiesgoNavigation)
                    .WithMany(p => p.TblSucursalRiesgo)
                    .HasForeignKey(d => d.IIdclaseRiesgo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblSucursalRiesgo_tblMultivalores");

                entity.HasOne(d => d.IIdsucursalNavigation)
                    .WithMany(p => p.TblSucursalRiesgo)
                    .HasForeignKey(d => d.IIdsucursal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblSucursalRiesgo_tblSucursalesEmpresas");
            });

            modelBuilder.Entity<TblSucursalesEmpresas>(entity =>
            {
                entity.HasKey(e => e.IIdsucursal);

                entity.ToTable("tblSucursalesEmpresas", "negocio");

                entity.Property(e => e.IIdsucursal).HasColumnName("iIDSucursal");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaModificacion)
                    .HasColumnName("dtFechaModificacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IIdestado).HasColumnName("iIDEstado");

                entity.Property(e => e.IIdubicacion).HasColumnName("iIDUbicacion");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.IIdusuarioModifiacion).HasColumnName("iIDUsuarioModifiacion");

                entity.Property(e => e.TCodigo)
                    .IsRequired()
                    .HasColumnName("tCodigo")
                    .HasMaxLength(50);

                entity.Property(e => e.TDireccion)
                    .IsRequired()
                    .HasColumnName("tDireccion")
                    .HasMaxLength(300);

                entity.Property(e => e.TEmail)
                    .HasColumnName("tEmail")
                    .HasMaxLength(50);

                entity.Property(e => e.TFax)
                    .HasColumnName("tFax")
                    .HasMaxLength(10);

                entity.Property(e => e.TNombre)
                    .IsRequired()
                    .HasColumnName("tNombre")
                    .HasMaxLength(100);

                entity.Property(e => e.TSigla)
                    .IsRequired()
                    .HasColumnName("tSigla")
                    .HasMaxLength(10);

                entity.Property(e => e.TTelefono)
                    .IsRequired()
                    .HasColumnName("tTelefono")
                    .HasMaxLength(50);

                entity.Property(e => e.TTelefono2)
                    .HasColumnName("tTelefono2")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblSucursalesEmpresas)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblSucursalesEmpresas_tblEmpresas");

                entity.HasOne(d => d.IIdestadoNavigation)
                    .WithMany(p => p.TblSucursalesEmpresas)
                    .HasForeignKey(d => d.IIdestado)
                    .HasConstraintName("FK_tblSucursalesEmpresas_tblMultivalores");

                entity.HasOne(d => d.IIdubicacionNavigation)
                    .WithMany(p => p.TblSucursalesEmpresas)
                    .HasForeignKey(d => d.IIdubicacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblSucursalesEmpresas_tblDivipola");

                entity.HasOne(d => d.IIdusuarioCreacionNavigation)
                    .WithMany(p => p.TblSucursalesEmpresas)
                    .HasForeignKey(d => d.IIdusuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblSucursalesEmpresas_tblUsuarios");
            });

            modelBuilder.Entity<TblTareaActividades>(entity =>
            {
                entity.HasKey(e => e.IIdtareaActividad);

                entity.ToTable("tblTareaActividades", "negocio");

                entity.Property(e => e.IIdtareaActividad).HasColumnName("iIDTareaActividad");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaFin)
                    .HasColumnName("dtFechaFin")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaInicio)
                    .HasColumnName("dtFechaInicio")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdtarea).HasColumnName("iIDTarea");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TDescripcion)
                    .IsRequired()
                    .HasColumnName("tDescripcion")
                    .HasMaxLength(500);

                entity.HasOne(d => d.IIdtareaNavigation)
                    .WithMany(p => p.TblTareaActividades)
                    .HasForeignKey(d => d.IIdtarea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblTareaActividades_tblTareas");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblTareaActividades)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblTareaActividades_tblUsuarios");
            });

            modelBuilder.Entity<TblTareas>(entity =>
            {
                entity.HasKey(e => e.IIdtarea);

                entity.ToTable("tblTareas", "negocio");

                entity.Property(e => e.IIdtarea).HasColumnName("iIDTarea");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaFin)
                    .HasColumnName("dtFechaFin")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaInicio)
                    .HasColumnName("dtFechaInicio")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaInsercion)
                    .HasColumnName("dtFechaInsercion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaVencimiento)
                    .HasColumnName("dtFechaVencimiento")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IIdestadoTarea).HasColumnName("iIDEstadoTarea");

                entity.Property(e => e.IIdtipoTarea).HasColumnName("iIDTipoTarea");

                entity.Property(e => e.IIdusuarioInsecion).HasColumnName("iIDUsuarioInsecion");

                entity.Property(e => e.IIdusuarioTarea).HasColumnName("iIDUsuarioTarea");

                entity.Property(e => e.TDescripcion)
                    .IsRequired()
                    .HasColumnName("tDescripcion")
                    .HasMaxLength(1000);

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblTareas)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblTareas_tblEmpresas");

                entity.HasOne(d => d.IIdestadoTareaNavigation)
                    .WithMany(p => p.TblTareasIIdestadoTareaNavigation)
                    .HasForeignKey(d => d.IIdestadoTarea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblTareas_tblMultivalores1");

                entity.HasOne(d => d.IIdtipoTareaNavigation)
                    .WithMany(p => p.TblTareasIIdtipoTareaNavigation)
                    .HasForeignKey(d => d.IIdtipoTarea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblTareas_tblMultivalores");

                entity.HasOne(d => d.IIdusuarioInsecionNavigation)
                    .WithMany(p => p.TblTareasIIdusuarioInsecionNavigation)
                    .HasForeignKey(d => d.IIdusuarioInsecion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblTareas_tblUsuarios1");

                entity.HasOne(d => d.IIdusuarioTareaNavigation)
                    .WithMany(p => p.TblTareasIIdusuarioTareaNavigation)
                    .HasForeignKey(d => d.IIdusuarioTarea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblTareas_tblUsuarios");
            });

            modelBuilder.Entity<TblTemplateNotificaciones>(entity =>
            {
                entity.HasKey(e => e.IId)
                    .HasName("PK__tblTempl__DC512D72314575BF");

                entity.ToTable("tblTemplateNotificaciones");

                entity.HasIndex(e => e.TNombre)
                    .HasName("UQ_tblTemplateNotificaciones")
                    .IsUnique();

                entity.Property(e => e.IId)
                    .HasColumnName("iID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.TDescripcion)
                    .IsRequired()
                    .HasColumnName("tDescripcion")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TNombre)
                    .IsRequired()
                    .HasColumnName("tNombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TTemplate)
                    .IsRequired()
                    .HasColumnName("tTemplate");
            });

            modelBuilder.Entity<TblTipoAfiliacion>(entity =>
            {
                entity.HasKey(e => e.IId)
                    .HasName("PK__tblTipoA__DC512D721A0FFEF8");

                entity.ToTable("tblTipoAfiliacion", "Incapacidades");

                entity.Property(e => e.IId)
                    .HasColumnName("iID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.TNombre)
                    .IsRequired()
                    .HasColumnName("tNombre")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblTipoCie>(entity =>
            {
                entity.HasKey(e => e.IIdtipoCie);

                entity.ToTable("tblTipoCIE", "Incapacidades");

                entity.Property(e => e.IIdtipoCie).HasColumnName("iIDTipoCie");

                entity.Property(e => e.TTipoCie)
                    .IsRequired()
                    .HasColumnName("tTipoCie")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblTipoEmpresa>(entity =>
            {
                entity.HasKey(e => e.IIdtipoEmpresa);

                entity.ToTable("tblTipoEmpresa", "recobro");

                entity.Property(e => e.IIdtipoEmpresa).HasColumnName("iIDTipoEmpresa");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaModificacion)
                    .HasColumnName("dtFechaModificacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdusuarioCreacion).HasColumnName("iIDUsuarioCreacion");

                entity.Property(e => e.IIdusuarioModificacion).HasColumnName("iIDUsuarioModificacion");

                entity.Property(e => e.TTipoEmpresa)
                    .HasColumnName("tTipoEmpresa")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<TblTipoProceso>(entity =>
            {
                entity.HasKey(e => e.IIdtipoProceso);

                entity.ToTable("tblTipoProceso", "negocio");

                entity.Property(e => e.IIdtipoProceso).HasColumnName("iIDTipoProceso");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TCodigoTipoProceso)
                    .HasColumnName("tCodigoTipoProceso")
                    .HasMaxLength(50);

                entity.Property(e => e.TNombreTipoProceso)
                    .IsRequired()
                    .HasColumnName("tNombreTipoProceso")
                    .HasMaxLength(200);

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblTipoProceso)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblTipoProceso_tblEmpresas");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblTipoProceso)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblTipoProceso_tblUsuarios");
            });

            modelBuilder.Entity<TblTipoSociedadEmpresa>(entity =>
            {
                entity.HasKey(e => e.IId)
                    .HasName("PK__tblTipoS__DC512D720EDAFB87");

                entity.ToTable("tblTipoSociedadEmpresa");

                entity.HasIndex(e => e.TNombre)
                    .HasName("UQ_tNombreSociedad")
                    .IsUnique();

                entity.Property(e => e.IId)
                    .HasColumnName("iID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.TNombre)
                    .IsRequired()
                    .HasColumnName("tNombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblTiposArchivo>(entity =>
            {
                entity.ToTable("tblTiposArchivo", "files");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<TblTiposNotificaciones>(entity =>
            {
                entity.HasKey(e => e.Iid)
                    .HasName("PK__tblTipos__C4972B4C30B48AA3");

                entity.ToTable("tblTiposNotificaciones");

                entity.HasIndex(e => e.TNombre)
                    .HasName("UQ_tblTiposNotificaciones")
                    .IsUnique();

                entity.Property(e => e.Iid)
                    .HasColumnName("IID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BActivo)
                    .HasColumnName("bActivo")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TDescripcion)
                    .HasColumnName("tDescripcion")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TNombre)
                    .IsRequired()
                    .HasColumnName("tNombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblTranscripciones>(entity =>
            {
                entity.HasKey(e => e.Iid)
                    .HasName("PK__tblTrans__C4972BAC02938F0D");

                entity.ToTable("tblTranscripciones", "Incapacidades");

                entity.Property(e => e.Iid).HasColumnName("IId");

                entity.Property(e => e.DtfechaCreacion)
                    .HasColumnName("DTFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IDiasIncapacidad).HasColumnName("iDiasIncapacidad");

                entity.Property(e => e.IedadPaciente)
                    .HasColumnName("IEdadPaciente")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IidDiagnostico).HasColumnName("IIdDiagnostico");

                entity.Property(e => e.OcrproviderId).HasColumnName("OCRProviderId");

                entity.Property(e => e.OcrserviceText)
                    .HasColumnName("OCRServiceText")
                    .IsUnicode(false);

                entity.Property(e => e.Ocrtext)
                    .HasColumnName("OCRText")
                    .IsUnicode(false);

                entity.Property(e => e.TblobId)
                    .HasColumnName("TBlobId")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.TcentroAtencion)
                    .HasColumnName("TCentroAtencion")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TclaseIncapacidad)
                    .HasColumnName("TClaseIncapacidad")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TcodigoExternoIps)
                    .HasColumnName("TCodigoExternoIPS")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Tdiagnostico)
                    .HasColumnName("TDiagnostico")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TfechaCreacion)
                    .HasColumnName("TFechaCreacion")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TfechaFinal)
                    .HasColumnName("TFechaFinal")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TfechaInicial)
                    .HasColumnName("TFechaInicial")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TgeneroPaciente)
                    .HasColumnName("TGeneroPaciente")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TidCie10)
                    .HasColumnName("TIdCie10")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TnombreEps)
                    .HasColumnName("TNombreEPS")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TnombreIps)
                    .HasColumnName("TNombreIPS")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TnombreMedico)
                    .HasColumnName("TNombreMedico")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TnombrePaciente)
                    .HasColumnName("TNombrePaciente")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TnumeroIdentificacionEps)
                    .HasColumnName("TNumeroIdentificacionEPS")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TnumeroIdentificacionIps)
                    .HasColumnName("TNumeroIdentificacionIPS")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TnumeroIdentificacionPaciente)
                    .HasColumnName("TNumeroIdentificacionPaciente")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TnumeroIncapacidad)
                    .HasColumnName("TNumeroIncapacidad")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TregistroMedico)
                    .HasColumnName("TRegistroMedico")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TtipoIdentificacionIps)
                    .HasColumnName("TTipoIdentificacionIPS")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TtipoIdentificacionMedico)
                    .HasColumnName("TTIpoIdentificacionMedico")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TtipoIdentificacionPaciente)
                    .HasColumnName("TTipoIdentificacionPaciente")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblUsuarios>(entity =>
            {
                entity.HasKey(e => e.IIdusuario);

                entity.ToTable("tblUsuarios", "seguridad");

                entity.Property(e => e.IIdusuario).HasColumnName("iIDUsuario");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.BCambioPassword).HasColumnName("bCambioPassword");

                entity.Property(e => e.DtFechaCambioPassword)
                    .HasColumnName("dtFechaCambioPassword")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdgenero).HasColumnName("iIDGenero");

                entity.Property(e => e.IIdsubtablaTipoDoc).HasColumnName("iIDSubtablaTipoDoc");

                entity.Property(e => e.IIdtipoDoc).HasColumnName("iIDTipoDoc");

                entity.Property(e => e.IIdusuarioCreador).HasColumnName("iIDUsuarioCreador");

                entity.Property(e => e.IPerfilDocumentos).HasColumnName("iPerfilDocumentos");

                entity.Property(e => e.TCelular)
                    .HasColumnName("tCelular")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TClave)
                    .IsRequired()
                    .HasColumnName("tClave")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TEmail)
                    .IsRequired()
                    .HasColumnName("tEmail")
                    .HasMaxLength(50);

                entity.Property(e => e.TIdnumDoc)
                    .IsRequired()
                    .HasColumnName("tIDNumDoc")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.TIdvalorTipoDoc)
                    .HasColumnName("tIDValorTipoDoc")
                    .HasMaxLength(50);

                entity.Property(e => e.TPrimerApellido)
                    .IsRequired()
                    .HasColumnName("tPrimerApellido")
                    .HasMaxLength(50);

                entity.Property(e => e.TPrimerNombre)
                    .IsRequired()
                    .HasColumnName("tPrimerNombre")
                    .HasMaxLength(50);

                entity.Property(e => e.TSegundoApellido)
                    .HasColumnName("tSegundoApellido")
                    .HasMaxLength(50);

                entity.Property(e => e.TSegundoNombre)
                    .HasColumnName("tSegundoNombre")
                    .HasMaxLength(50);

                entity.Property(e => e.TTelefono)
                    .HasColumnName("tTelefono")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TUsuario)
                    .IsRequired()
                    .HasColumnName("tUsuario")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IIdtipoDocNavigation)
                    .WithMany(p => p.TblUsuarios)
                    .HasForeignKey(d => d.IIdtipoDoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblUsuarios_tblMultivalores");
            });

            modelBuilder.Entity<TblUsuariosEmpresas>(entity =>
            {
                entity.HasKey(e => new { e.IIdempresa, e.IIdusuario });

                entity.ToTable("tblUsuariosEmpresas", "seguridad");

                entity.Property(e => e.IIdempresa).HasColumnName("iIDEmpresa");

                entity.Property(e => e.IIdusuario).HasColumnName("iIDUsuario");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.HasOne(d => d.IIdempresaNavigation)
                    .WithMany(p => p.TblUsuariosEmpresas)
                    .HasForeignKey(d => d.IIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblUsuariosEmpresas_tblEmpresas");

                entity.HasOne(d => d.IIdusuarioNavigation)
                    .WithMany(p => p.TblUsuariosEmpresas)
                    .HasForeignKey(d => d.IIdusuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblUsuariosEmpresas_tblUsuarios");
            });

            modelBuilder.Entity<TblUsuariosNotificaciones>(entity =>
            {
                entity.HasKey(e => e.IId)
                    .HasName("PK__tblUsuar__DC512D72DF444916");

                entity.ToTable("tblUsuariosNotificaciones");

                entity.Property(e => e.IId).HasColumnName("iID");

                entity.Property(e => e.BActivo)
                    .HasColumnName("bActivo")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IIdips).HasColumnName("iIDIPS");

                entity.Property(e => e.TCargo)
                    .IsRequired()
                    .HasColumnName("tCargo")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TEmail)
                    .IsRequired()
                    .HasColumnName("tEmail")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.TNombreEmpresa)
                    .IsRequired()
                    .HasColumnName("tNombreEmpresa")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TNumeroCelular)
                    .HasColumnName("tNumeroCelular")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TPrimerApellido)
                    .IsRequired()
                    .HasColumnName("tPrimerApellido")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TPrimerNombre)
                    .IsRequired()
                    .HasColumnName("tPrimerNombre")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TSegundoApellido)
                    .HasColumnName("tSegundoApellido")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TSegundoNombre)
                    .HasColumnName("tSegundoNombre")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblUsuariosPerfiles>(entity =>
            {
                entity.HasKey(e => new { e.IIdusuario, e.IIdperfil })
                    .HasName("PK__tblUsuar__757DB5881C870FD6");

                entity.ToTable("tblUsuariosPerfiles", "seguridad");

                entity.Property(e => e.IIdusuario).HasColumnName("iIDUsuario");

                entity.Property(e => e.IIdperfil).HasColumnName("iIDPerfil");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.HasOne(d => d.IIdperfilNavigation)
                    .WithMany(p => p.TblUsuariosPerfiles)
                    .HasForeignKey(d => d.IIdperfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblUsuariosPerfiles_tblPerfiles");

                entity.HasOne(d => d.IIdusuarioNavigation)
                    .WithMany(p => p.TblUsuariosPerfiles)
                    .HasForeignKey(d => d.IIdusuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblUsuariosPerfiles_tblUsuarios");
            });

            modelBuilder.Entity<Correo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("Correos", "CalificacionOrigen");
                entity.Property(e => e.Id).HasColumnName("Id");
            });

            modelBuilder.Entity<TextoReconocidoCarta>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("TextoReconocidoCartas", "CalificacionOrigen");
                entity.Property(e => e.Id).HasColumnName("Id");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("Empresas", "CalificacionOrigen");
                entity.Property(e => e.Id).HasColumnName("Id");
            });

            modelBuilder.Entity<Adjunto>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("CorreoAdjuntos", "CalificacionOrigen");
                entity.Property(e => e.Id).HasColumnName("Id");
            });

            modelBuilder.Entity<Carta>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("Carta", "CalificacionOrigen");
                entity.Property(e => e.Id).HasColumnName("Id");
            });

            modelBuilder.Entity<TblVendedor>(entity =>
            {
                entity.HasKey(e => e.IIdvendedor);

                entity.ToTable("tblVendedor", "negocio");

                entity.Property(e => e.IIdvendedor).HasColumnName("iIDVendedor");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DtFechaCreacion)
                    .HasColumnName("dtFechaCreacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IIdempresaGestora).HasColumnName("iIDEmpresaGestora");

                entity.Property(e => e.IIdtipoIdentificacion).HasColumnName("iIDTipoIdentificacion");

                entity.Property(e => e.IUsuarioCreacion).HasColumnName("iUsuarioCreacion");

                entity.Property(e => e.TNumeroIdentificacion)
                    .IsRequired()
                    .HasColumnName("tNumeroIdentificacion")
                    .HasMaxLength(200);

                entity.Property(e => e.TPrimerApellido)
                    .IsRequired()
                    .HasColumnName("tPrimerApellido")
                    .HasMaxLength(100);

                entity.Property(e => e.TPrimerNombre)
                    .IsRequired()
                    .HasColumnName("tPrimerNombre")
                    .HasMaxLength(100);

                entity.Property(e => e.TSegundoApellido)
                    .HasColumnName("tSegundoApellido")
                    .HasMaxLength(100);

                entity.Property(e => e.TSegundoNombre)
                    .HasColumnName("tSegundoNombre")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IIdempresaGestoraNavigation)
                    .WithMany(p => p.TblVendedor)
                    .HasForeignKey(d => d.IIdempresaGestora)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblVendedor_tblEmpresaGestora");

                entity.HasOne(d => d.IIdtipoIdentificacionNavigation)
                    .WithMany(p => p.TblVendedor)
                    .HasForeignKey(d => d.IIdtipoIdentificacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblVendedor_tblMultivalores");

                entity.HasOne(d => d.IUsuarioCreacionNavigation)
                    .WithMany(p => p.TblVendedor)
                    .HasForeignKey(d => d.IUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblVendedor_tblUsuarios");
            });
        }
    }
}
