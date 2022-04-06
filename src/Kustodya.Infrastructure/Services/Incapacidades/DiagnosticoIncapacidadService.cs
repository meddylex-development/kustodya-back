using AutoMapper;
using DinkToPdf;
using DinkToPdf.Contracts;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Interfaces.Incapacidades;
using Kustodya.ApplicationCore.Interfaces.Negocio;
using Kustodya.ApplicationCore.Specifications.Incapacidades;
using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Constants;
using Kustodya.ApplicationCore.Dtos.Configuracion.Notificaciones;
using Kustodya.ApplicationCore.Dtos.General;
using Kustodya.ApplicationCore.Dtos.Incapacidades;
using Kustodya.Shared.Wrappers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using TitanSoft.HTMLToPDF;
using Kustodya.ApplicationCore.Interfaces.General;
using Kustodya.ApplicationCore.Interfaces.Configuracion.Email;
using Kustodya.ApplicationCore.Interfaces.Configuracion.Notificaciones;
using Kustodya.ApplicationCore.Interfaces.Configuracion.Parametros;
using Kustodya.ApplicationCore.Interfaces.Configuracion.CodigoQR;
using Kustodya.ApplicationCore.Entities.Incapacidad;

namespace Kustodya.Infrastructure.Services.Incapacidades
{
    public class DiagnosticoIncapacidadService : IDiagnosticoIncapacidadService
    {
        #region Dependency Injection
        private readonly IAsyncRepository<TblCie10DiagnosticoIncapacidad> _cie10DiagnosticoIncapacidad;
        private readonly ICie10Service _cie10Service;
        private readonly IDANEService _daneService;
        private readonly IAsyncRepository<TblDiagnosticosIncapacidades> _incapacidadesRepo;
        private readonly IEmailService _emailService;
        private readonly IEPSService _epsService;
        private readonly IIPSService _ipsService;
        private readonly ILoggerService<DiagnosticoIncapacidadService> _logger;
        private readonly IMapper _mapper;
        private readonly IMultivaloresService _multivaloresServices;
        private readonly INotificacionService _notificacionService;
        private readonly IParametrosService _parametrosService;
        private readonly ICodigoQRService _codigoQRService;
        private readonly IConverter _converter;
        private readonly IConfiguration _configuration;
        private readonly IEmpresaService _empresaService;
        private readonly IValidacionIncapacidadesService _validacionService;
        private readonly IAsyncRepository<tblLateralidad> _lateralidadRepo;

        public DiagnosticoIncapacidadService(IAsyncRepository<TblDiagnosticosIncapacidades> diagnosticosIncapacidades,
            IAsyncRepository<TblCie10DiagnosticoIncapacidad> cie10DiagnosticoIncapacidad,
            ICie10Service cie10Service, ILoggerService<DiagnosticoIncapacidadService> logger,
            IMapper mapper, IDANEService daneService, IIPSService ipsService,
            IEmailService emailService,
            IParametrosService parametrosService,
            INotificacionService notificacionService,
            IEPSService epsService,
            IMultivaloresService multivaloresService,
            ICodigoQRService codigoQRService,
            IConverter converter,
            IConfiguration configuration,
            IEmpresaService empresaService,
            IValidacionIncapacidadesService validacionService,
            IAsyncRepository<tblLateralidad> lateralidadRepo)
        {
            _multivaloresServices = multivaloresService;
            _incapacidadesRepo = diagnosticosIncapacidades;
            _cie10DiagnosticoIncapacidad = cie10DiagnosticoIncapacidad;
            _cie10Service = cie10Service;
            _daneService = daneService;
            _ipsService = ipsService;
            _epsService = epsService;
            _emailService = emailService;
            _notificacionService = notificacionService;
            _parametrosService = parametrosService;
            _mapper = mapper;
            _logger = logger;
            _codigoQRService = codigoQRService;
            _converter = converter;
            _configuration = configuration;
            _empresaService = empresaService;
            _validacionService = validacionService;
            _lateralidadRepo = lateralidadRepo;
        }
        #endregion

        public async Task<IReadOnlyList<TblCie10DiagnosticoIncapacidad>> GetCie10DiagnosticosByPacienteUnAñoAtras(int iIDPaciente)
        {
            DateTime dateTime = DateTime.Today.AddYears(-1);
            var diagnosticoIncapacidadSpec = new Cie10DiagnosticoIncapacidadSpec(iIDPaciente, 1, dateTime);
            var diagnosticos = await _cie10DiagnosticoIncapacidad.ListAsync(diagnosticoIncapacidadSpec).ConfigureAwait(false);

            return diagnosticos;
        }

        public async Task<TblDiagnosticosIncapacidades> GetDiagnosticosIncapacidadByCodigoDiagnostico(Guid UiCodigoDiagnostico)
        {
            var diagnosticoIncapacidadSpec = new DiagnosticoIncapacidadSpec(UiCodigoDiagnostico);
            var diagnosticos = await _incapacidadesRepo.GetOneAsync(diagnosticoIncapacidadSpec).ConfigureAwait(false);

            return diagnosticos;
        }

        public async Task<IReadOnlyList<DiagnosticoIncapacidadModel>> GetDiagnosticosIncapacidadByPaciente(int iIDPaciente)
        {
            var diagnosticoIncapacidadSpec = new DiagnosticoIncapacidadSpec(iIDPaciente);
            var diagnosticos = await _incapacidadesRepo.ListAsync(diagnosticoIncapacidadSpec).ConfigureAwait(false);
            List<DiagnosticoIncapacidadModel> result = _mapper.Map<List<DiagnosticoIncapacidadModel>>(diagnosticos);

            foreach (var item in result)
            {
                var ips = await _ipsService.GetIPSById((int)item.IIdips).ConfigureAwait(false);
                item.LugarExpedicion = ips.Ubicacion;
                item.TLugarExpedicion = ips.Ubicacion.GetLugarExpedicion();
                item.DtFechaFin = item.FechaEmisionIncapacidad.AddDays(item.IDiasIncapacidad);
            }

            return result;
        }

        public async Task<IReadOnlyList<TblDiagnosticosIncapacidades>> GetDiagnosticosIncapacidadByPacienteUnAñoAtras(int iIDPaciente)
        {
            DateTime dateTime = DateTime.Today.AddYears(-1);
            var diagnosticoIncapacidadSpec = new DiagnosticoIncapacidadSpec(iIDPaciente, dateTime);
            var diagnosticos = await _incapacidadesRepo.ListAsync(diagnosticoIncapacidadSpec).ConfigureAwait(false);

            return diagnosticos;
        }

        public async Task<TblDiagnosticosIncapacidades> GetDiagnosticoCorrelacion(int cie10Id, int pacientId)
        {
            //TODO Prametrizacion
            DateTime from = DateTime.Today.AddDays(-30);

            var incapacidadSpec = new DiagnosticoIncapacidadSpec(pacientId, from);
            IReadOnlyList<TblDiagnosticosIncapacidades> incapacidadesUltimoMes = await _incapacidadesRepo.ListAsync(incapacidadSpec).ConfigureAwait(false);

            //var cie10IncapacidadSpec = new Cie10DiagnosticoIncapacidadSpec(pacientId, (int)TipoCIE10.DIAGNOSTICO, from);
            //var cie10Incapacidad = await _cie10DiagnosticoIncapacidad.ListAsync(cie10IncapacidadSpec);

            TblDiagnosticosIncapacidades result = null;

            if (incapacidadesUltimoMes == null || incapacidadesUltimoMes.Count <= 0)
                return result;

            TblCie10 diagnosticoActual = await _cie10Service.GetCie10ById(cie10Id).ConfigureAwait(false);
            List<string> codigosActualDiagnostico = diagnosticoActual.TblCodigosCorrelacion.Select(d => d.TCodigoCorrelacion).ToList();

            foreach (TblDiagnosticosIncapacidades incapacidad in incapacidadesUltimoMes)
            {
                TblCie10 ultimoDiagnostico = incapacidad.TblCie10DiagnosticoIncapacidad
                    .Where(d => d.IIdcie10Navigation?.IIdtipoCie == (int)TipoCIE.DIAGNOSTICO)
                    .Select(d => d.IIdcie10Navigation)
                    .FirstOrDefault();

                List<string> codigosUltimaIncapacidad = ultimoDiagnostico.TblCodigosCorrelacion.Select(d => d.TCodigoCorrelacion).ToList();

                if (codigosUltimaIncapacidad.Intersect(codigosActualDiagnostico).Any())
                {
                    result = incapacidad;
                    break;
                }
            }
            return result;
        }

        public Task<DiagnosticoIncapacidadModel> GuardarIncapacidad(DiagnosticoIncapacidadModel idDiagnosticoIncapacidad)
        {
            return null;
        }

        public async Task<TblDiagnosticosIncapacidades> CrearDiagnosticosIncapacidad(TblDiagnosticosIncapacidades diagnosticosIncapacidad, TblPacientes paciente, long IIdusuarioCreador, TranscripcionAIModel transcripcionAIModel = null, TblTranscripciones transcripcion = null)
        {
            if (diagnosticosIncapacidad == null)
                throw new ArgumentNullException(nameof(diagnosticosIncapacidad));
            if (paciente is null)
                throw new ArgumentNullException(nameof(paciente));

            diagnosticosIncapacidad.IIdeps = paciente.IIdeps;
            diagnosticosIncapacidad.IIdafp = paciente.IIdafp;
            diagnosticosIncapacidad.IIdarl = paciente.IIdarl;
            diagnosticosIncapacidad.IIdusuarioCreador = IIdusuarioCreador;

            TblCie10 diagnosticoActual = new TblCie10();
            foreach (var item in diagnosticosIncapacidad.TblCie10DiagnosticoIncapacidad)
            {
                int iid = item.IIdcie10;
                TblCie10 tempDiagnosticoActual = await _cie10Service.GetCie10ById(iid).ConfigureAwait(false);
                if (tempDiagnosticoActual.IIdtipoCie == (int)TipoCIE.DIAGNOSTICO)
                {
                    diagnosticoActual = tempDiagnosticoActual;
                    break;
                }
            }

            var diagnosticoCorrelacion = await GetDiagnosticoCorrelacion(diagnosticoActual.IIdcie10, paciente.IIdpaciente);
            var localTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time"));
            diagnosticosIncapacidad.DtFechaCreacion = localTime;

            if (diagnosticosIncapacidad.DtFechaEmisionIncapacidad == null || diagnosticosIncapacidad.DtFechaEmisionIncapacidad == DateTime.MinValue)
            {
                diagnosticosIncapacidad.DtFechaEmisionIncapacidad = diagnosticosIncapacidad.DtFechaCreacion;
            }

            if (diagnosticoCorrelacion != null)
            {
                diagnosticosIncapacidad.IDiasAcumuladosPorroga = diagnosticoCorrelacion.IDiasIncapacidad + diagnosticoCorrelacion.IDiasAcumuladosPorroga;
                diagnosticosIncapacidad.IIddiagnosticoCorrelacion = diagnosticoCorrelacion.IIddiagnosticoIncapacidad;
                diagnosticosIncapacidad.BProrroga = true;
            }

            IReadOnlyList<TblMultivalores> origenIncapacidad = await _multivaloresServices.GetDatosSubtabla(Subtabla.OrigenIncapacidad).ConfigureAwait(false);

            if (/*diagnosticosIncapacidad.IIdpresuntoOrigenIncapacidadNavigation == null ||*/diagnosticosIncapacidad.IIdpresuntoOrigenIncapacidad == null ||
                diagnosticosIncapacidad.IIdpresuntoOrigenIncapacidad == 0)
            {
                TblMultivalores presuntoorigen = origenIncapacidad.First(x => (long.Parse(x.TValor, CultureInfo.InvariantCulture) == (long)OrigenIncapacidad.Enfermedad_general));
                diagnosticosIncapacidad.IIdpresuntoOrigenIncapacidad = (long)OrigenIncapacidad.Enfermedad_general;
                diagnosticosIncapacidad.IIdpresuntoOrigenIncapacidadNavigation = presuntoorigen;
            }

            IReadOnlyList<TblMultivalores> tblMultivaloresTipoAtencion = await _multivaloresServices.GetDatosSubtabla(Subtabla.TipoAtencion).ConfigureAwait(false);
            if (diagnosticosIncapacidad.BEsTranscripcion.Value && diagnosticosIncapacidad.IIdtipoAtencion == 0)
            {
                var multivalor = tblMultivaloresTipoAtencion.First(p => p.IIdmultivalor == 3563);
                diagnosticosIncapacidad.IIdtipoAtencion = multivalor.IIdmultivalor;
            }
            else
            {
                TblMultivalores tipoatencion = tblMultivaloresTipoAtencion.First(x => x.IIdmultivalor == diagnosticosIncapacidad.IIdtipoAtencion);
                diagnosticosIncapacidad.IIdtipoAtencionNavigation = tipoatencion;
            }

            diagnosticosIncapacidad = await _incapacidadesRepo.AddAsync(diagnosticosIncapacidad).ConfigureAwait(false);

            try
            {
                var SolicitudId = await _validacionService.SolicitarAsync(diagnosticosIncapacidad);
                _logger.LogInformation($"Solicitud de validacion: {SolicitudId}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"No se pudo validar la incapacidad. Mensaje:{ex.Message}");
            }

            await SendEmail(diagnosticosIncapacidad, paciente, transcripcionAIModel, transcripcion, diagnosticoActual);

            return diagnosticosIncapacidad;
        }

        private async Task SendEmail(TblDiagnosticosIncapacidades diagnosticosIncapacidad, TblPacientes paciente, TranscripcionAIModel transcripcionAIModel, TblTranscripciones transcripcion, TblCie10 diagnosticoActual)
        {
            SendgridEmailWrapper sendGridWrapper = new SendgridEmailWrapper();

            PersonalizationWrapper personalization = sendGridWrapper.personalizations[0];
            if (transcripcionAIModel != null)
            {
                personalization.subject = $"Kustodya - Certificado de Incapacidad Medica Laboral - {transcripcionAIModel?.NombrePaciente}";
            }
            else
            {
                personalization.subject = $"Kustodya - Certificado de Incapacidad Medica Laboral - {paciente.TPrimerNombre} {paciente.TPrimerApellido}";
            }
            ICollection<UsuariosNotificacionesModel> lUsersNotificaciones = await _notificacionService.GetEmailConfigurationByIdEmpresa(11); //TODO Replace IidIPS
            string emails = string.Empty;

            SendgridEmailTo[] to = new SendgridEmailTo[lUsersNotificaciones.Count];

            ICollection<SendgridEmailTo> collectionTo = new List<SendgridEmailTo>();
            foreach (UsuariosNotificacionesModel user in lUsersNotificaciones)
            {
                var emailto = new SendgridEmailTo
                {
                    email = user.TEmail,
                    name = user.TPrimerNombre + " " + user.TPrimerApellido
                };
                collectionTo.Add(emailto);
            }

            CultureInfo cultureInfoFechas = new CultureInfo(_configuration.GetSection("cultureInfo").Value);

            personalization.to = collectionTo.ToArray();
            ContentWrapper content = sendGridWrapper.content[0];

            content.type = "text/html";
            content.value = string.Empty;

            ParametrosModel parametro = await _parametrosService.GetParameterByIdentificator("TEMPLATE_EMAIL_INCAPACIDAD").ConfigureAwait(false);

            string emailTemplate = parametro.TValor;

            var eps = await _epsService.GetEPSById(paciente.IIdeps).ConfigureAwait(false);
            var ips = await _ipsService.GetIPSById(diagnosticosIncapacidad.IIdips).ConfigureAwait(false);

            var tipoEmision = (diagnosticosIncapacidad.BEsTranscripcion == true) ? "TRANSCRIPCIÓN" : "PRIMARIA";

            emailTemplate = emailTemplate.Replace("{{##MEDICO##}", "", StringComparison.InvariantCultureIgnoreCase);
            emailTemplate = emailTemplate.Replace("{{##NUMERO_IDENTIFICACION_AFILIADO##}}", paciente.TNumeroDocumento, StringComparison.InvariantCultureIgnoreCase);
            if (transcripcionAIModel != null)
            {
                emailTemplate = emailTemplate.Replace("{{##NOMBRE_PACIENTE##}}", transcripcionAIModel?.NombrePaciente, StringComparison.InvariantCultureIgnoreCase);
                emailTemplate = emailTemplate.Replace("{{##APELLIDO_PACIENTE##}}", "", StringComparison.InvariantCultureIgnoreCase);
                emailTemplate = emailTemplate.Replace("{{##DIAS_INCAPACIDAD##}}", transcripcionAIModel?.DiasIncapacidad.ToString(CultureInfo.InvariantCulture), StringComparison.InvariantCultureIgnoreCase);

            }
            else
            {
                emailTemplate = emailTemplate.Replace("{{##NOMBRE_PACIENTE##}}", paciente.TPrimerNombre + " " + paciente.TSegundoNombre, StringComparison.InvariantCultureIgnoreCase);
                emailTemplate = emailTemplate.Replace("{{##APELLIDO_PACIENTE##}}", paciente.TPrimerApellido + " " + paciente.TSegundoApellido, StringComparison.InvariantCultureIgnoreCase);
                emailTemplate = emailTemplate.Replace("{{##DIAS_INCAPACIDAD##}}", diagnosticosIncapacidad?.IDiasIncapacidad.ToString(CultureInfo.InvariantCulture), StringComparison.InvariantCultureIgnoreCase);
            }
            emailTemplate = emailTemplate.Replace("{{##CLASE_INCAPACIDAD##}}", tipoEmision, StringComparison.InvariantCultureIgnoreCase);

            var diasIncapacidad = 1;
            if (diagnosticosIncapacidad.DtFechaFin != null)
            {
                diasIncapacidad = (int)(diagnosticosIncapacidad.DtFechaFin.Date - ((DateTime)diagnosticosIncapacidad.DtFechaEmisionIncapacidad).Date).TotalDays;
            }
            else
            {
                diasIncapacidad = diagnosticoActual.IDiasMaxConsulta - 1;
            }
            emailTemplate = emailTemplate.Replace("{{##FECHA_INICIAL_INCAPACIDAD##}}", $"{transcripcionAIModel?.FechaInicial.Day}/{transcripcionAIModel?.FechaInicial.ToString("MMMM", cultureInfoFechas)}/{transcripcionAIModel?.FechaInicial.Year}", StringComparison.InvariantCultureIgnoreCase);
            emailTemplate = emailTemplate.Replace("{{##FECHA_FINAL_INCAPACIDAD##}}", $"{transcripcionAIModel?.FechaFinal.Day}/{transcripcionAIModel?.FechaFinal.ToString("MMMM", cultureInfoFechas)}/{transcripcionAIModel?.FechaFinal.Year}", StringComparison.InvariantCultureIgnoreCase);
            emailTemplate = emailTemplate.Replace("{{##URL_INCAPACIDAD##}}", $"https://Kustodyadev.azurewebsites.net/#/auth/login/{diagnosticosIncapacidad.UiCodigoDiagnostico}", StringComparison.InvariantCultureIgnoreCase);
            emailTemplate = emailTemplate.Replace("{{##NOMBRE_EPS##}}", $"{eps.TNombre}", StringComparison.InvariantCultureIgnoreCase);
            emailTemplate = emailTemplate.Replace("{{##NOMBRE_IPS##}}", $"{ips.TNombre}", StringComparison.InvariantCultureIgnoreCase);
            emailTemplate = emailTemplate.Replace("{{##CODIGO_CASO##}}", $"{diagnosticosIncapacidad.UiCodigoDiagnostico}", StringComparison.InvariantCultureIgnoreCase);
            emailTemplate = emailTemplate.Replace("{{##NUIM##}}", $"{diagnosticosIncapacidad.TCodigoCorto}", StringComparison.InvariantCultureIgnoreCase);

            if ((bool)diagnosticosIncapacidad.BEsTranscripcion)
            {
                ParametrosModel parametroPDF = await _parametrosService.GetParameterByIdentificator("TEMPLATE_PDF_TRANSCRIPCION").ConfigureAwait(false);
                string pdfTemplate = parametroPDF.TValor;
                var empresaPaciente = await _empresaService.GetEmpresaById((long)paciente.IIdempresa).ConfigureAwait(false);

                #region pdfTemplate
                if (transcripcionAIModel != null)
                {
                    pdfTemplate = pdfTemplate.Replace("{{##EPS_IDENTIFICACION##}}", transcripcionAIModel?.NumeroIdentificacionEps, StringComparison.InvariantCultureIgnoreCase);
                    pdfTemplate = pdfTemplate.Replace("{{##EPS_CODIGO_HABILITACION##}}", transcripcionAIModel?.NumeroHabilitacionEPS, StringComparison.InvariantCultureIgnoreCase);

                    pdfTemplate = pdfTemplate.Replace("{{##PACIENTE_TIPO_IDENTIFICACION##}}", transcripcionAIModel?.TipoDocumentoPaciente, StringComparison.InvariantCultureIgnoreCase);
                    pdfTemplate = pdfTemplate.Replace("{{##PACIENTE_No_IDENTIFICACION##}}", transcripcionAIModel?.NumeroDocumentoPaciente, StringComparison.InvariantCultureIgnoreCase);
                    pdfTemplate = pdfTemplate.Replace("{{##PACIENTE_SEXO##}}", transcripcionAIModel?.GeneroPaciente, StringComparison.InvariantCultureIgnoreCase);
                    pdfTemplate = pdfTemplate.Replace("{{##PACIENTE_EDAD##}}", transcripcionAIModel?.EdadPaciente, StringComparison.InvariantCultureIgnoreCase);
                    pdfTemplate = pdfTemplate.Replace("{{##PACIENTE_NOMBRE##}}", transcripcionAIModel?.NombrePaciente, StringComparison.InvariantCultureIgnoreCase);
                    pdfTemplate = pdfTemplate.Replace("{{##PACIENTE_FECHA_NACIMIENTO##}}", $"{transcripcionAIModel?.FechaNacimientoText}", StringComparison.InvariantCultureIgnoreCase);

                    pdfTemplate = pdfTemplate.Replace("{{##EMPLEADOR_TIPO_IDENTIFICACION##}}", "", StringComparison.InvariantCultureIgnoreCase);
                    pdfTemplate = pdfTemplate.Replace("{{##EMPLEADOR_IDENTIFICACION##}}", "", StringComparison.InvariantCultureIgnoreCase);
                    pdfTemplate = pdfTemplate.Replace("{{##EMPLEADOR_RAZON_SOCIAL##}}", "", StringComparison.InvariantCultureIgnoreCase);
                    pdfTemplate = pdfTemplate.Replace("{{##EMPLEADOR_ACTIVIDAD_ECONOMICA##}}", "", StringComparison.InvariantCultureIgnoreCase);
                    pdfTemplate = pdfTemplate.Replace("{{##EMPLEADOR_CIU##}}", "", StringComparison.InvariantCultureIgnoreCase);

                    pdfTemplate = pdfTemplate.Replace("{{##IPS_TIPO_IDENTIFICACION##}}", transcripcionAIModel?.IpsTipoIdentificacion, StringComparison.InvariantCultureIgnoreCase);
                    pdfTemplate = pdfTemplate.Replace("{{##IPS_IDENTIFICACION##}}", transcripcionAIModel?.IpsNumeroIdentificacion, StringComparison.InvariantCultureIgnoreCase);
                    pdfTemplate = pdfTemplate.Replace("{{##IPS_RAZON_SOCIAL##}}", transcripcionAIModel?.CentroAtencionFull, StringComparison.InvariantCultureIgnoreCase);
                    pdfTemplate = pdfTemplate.Replace("{{##IPS_CODIGO_HABILITACION##}}", transcripcionAIModel?.IpsCodigoExterno, StringComparison.InvariantCultureIgnoreCase);

                    pdfTemplate = pdfTemplate.Replace("{{##INCAPACIDAD_No_INCAPACIDAD_TRANSCRITA##}}", transcripcionAIModel?.NumeroIncapacidad, StringComparison.InvariantCultureIgnoreCase);

                    pdfTemplate = pdfTemplate.Replace("{{##INCAPACIDAD_FECHA_INCAPACIDAD_TRANSCRITA##}}", $"{transcripcionAIModel?.FechaDocumento}", StringComparison.InvariantCultureIgnoreCase);

                    pdfTemplate = pdfTemplate.Replace("{{##INCAPACIDAD_DIAGNOSTICO##}}", $"{transcripcionAIModel?.IdCie10} - {transcripcionAIModel?.DescripcionCie10}", StringComparison.InvariantCultureIgnoreCase);
                    pdfTemplate = pdfTemplate.Replace("{{##INCAPACIDAD_TIPO_ORIGEN##}}", transcripcionAIModel?.TipoOrigen, StringComparison.InvariantCultureIgnoreCase);

                    pdfTemplate = pdfTemplate.Replace("{{##INCAPACIDAD_DIAS_INCAPACIDAD##}}", $"{transcripcionAIModel?.DiasIncapacidad}", StringComparison.InvariantCultureIgnoreCase);
                }
                else
                {
                    pdfTemplate = pdfTemplate.Replace("{{##EPS_IDENTIFICACION##}}", eps.TNumeroIdentificacion, StringComparison.InvariantCultureIgnoreCase);
                    pdfTemplate = pdfTemplate.Replace("{{##EPS_CODIGO_HABILITACION##}}", eps.TCodigoExterno, StringComparison.InvariantCultureIgnoreCase);

                    pdfTemplate = pdfTemplate.Replace("{{##PACIENTE_TIPO_IDENTIFICACION##}}", paciente.IIdtipoDocNavigation.TDescripcion, StringComparison.InvariantCultureIgnoreCase);
                    pdfTemplate = pdfTemplate.Replace("{{##PACIENTE_No_IDENTIFICACION##}}", paciente.TNumeroDocumento, StringComparison.InvariantCultureIgnoreCase);
                    pdfTemplate = pdfTemplate.Replace("{{##PACIENTE_SEXO##}}", paciente.IIdgeneroNavigation.TDescripcion, StringComparison.InvariantCultureIgnoreCase);
                    pdfTemplate = pdfTemplate.Replace("{{##PACIENTE_EDAD##}}", $"{paciente.IEdad} años", StringComparison.InvariantCultureIgnoreCase);
                    pdfTemplate = pdfTemplate.Replace("{{##PACIENTE_NOMBRE##}}", $"{paciente.TPrimerNombre} {paciente.TSegundoNombre} {paciente.TPrimerApellido} {paciente.TSegundoApellido}", StringComparison.InvariantCultureIgnoreCase);
                    var fechaNacimiento = (DateTime)paciente.DtFechaNacimiento;
                    pdfTemplate = pdfTemplate.Replace("{{##PACIENTE_FECHA_NACIMIENTO##}}", $"{fechaNacimiento.Day}/{fechaNacimiento.ToString("MMMM", cultureInfoFechas)}/{fechaNacimiento.Year}", StringComparison.InvariantCultureIgnoreCase);

                    pdfTemplate = pdfTemplate.Replace("{{##EMPLEADOR_TIPO_IDENTIFICACION##}}", "NIT", StringComparison.InvariantCultureIgnoreCase);
                    pdfTemplate = pdfTemplate.Replace("{{##EMPLEADOR_IDENTIFICACION##}}", $"{empresaPaciente.NIT.ToString(CultureInfo.InvariantCulture)}-{empresaPaciente.TDigitoVerificacion}", StringComparison.InvariantCultureIgnoreCase);
                    pdfTemplate = pdfTemplate.Replace("{{##EMPLEADOR_RAZON_SOCIAL##}}", empresaPaciente.TRazonSocial, StringComparison.InvariantCultureIgnoreCase);
                    pdfTemplate = pdfTemplate.Replace("{{##EMPLEADOR_ACTIVIDAD_ECONOMICA##}}", empresaPaciente.ActividadEconomica.TNombreActividad, StringComparison.InvariantCultureIgnoreCase);
                    pdfTemplate = pdfTemplate.Replace("{{##EMPLEADOR_CIU##}}", empresaPaciente.ActividadEconomica.CIIU, StringComparison.InvariantCultureIgnoreCase);

                    pdfTemplate = pdfTemplate.Replace("{{##IPS_TIPO_IDENTIFICACION##}}", "NIT", StringComparison.InvariantCultureIgnoreCase);
                    pdfTemplate = pdfTemplate.Replace("{{##IPS_IDENTIFICACION##}}", ips.TNumeroIdentificacion, StringComparison.InvariantCultureIgnoreCase);
                    pdfTemplate = pdfTemplate.Replace("{{##IPS_RAZON_SOCIAL##}}", ips.TNombre, StringComparison.InvariantCultureIgnoreCase);
                    pdfTemplate = pdfTemplate.Replace("{{##IPS_CODIGO_HABILITACION##}}", ips.TCodigoExterno, StringComparison.InvariantCultureIgnoreCase);

                    pdfTemplate = pdfTemplate.Replace("{{##INCAPACIDAD_No_INCAPACIDAD_TRANSCRITA##}}", diagnosticosIncapacidad.NumeroIncapacidadIpstranscripcion, StringComparison.InvariantCultureIgnoreCase);
                    var fechaEmision = (DateTime)diagnosticosIncapacidad.DtFechaEmisionIncapacidad;
                    pdfTemplate = pdfTemplate.Replace("{{##INCAPACIDAD_FECHA_INCAPACIDAD_TRANSCRITA##}}", $"{fechaEmision.Day}/{fechaEmision.ToString("MMMM", cultureInfoFechas)}/{fechaEmision.Year}", StringComparison.InvariantCultureIgnoreCase);

                    pdfTemplate = pdfTemplate.Replace("{{##INCAPACIDAD_DIAGNOSTICO##}}", $"{diagnosticoActual.TCie10} - {diagnosticoActual.TDescripcion}", StringComparison.InvariantCultureIgnoreCase);
                    pdfTemplate = pdfTemplate.Replace("{{##INCAPACIDAD_TIPO_ORIGEN##}}", diagnosticosIncapacidad.IIdpresuntoOrigenIncapacidadNavigation.TDescripcion, StringComparison.InvariantCultureIgnoreCase);

                    pdfTemplate = pdfTemplate.Replace("{{##INCAPACIDAD_DIAS_INCAPACIDAD##}}", diagnosticosIncapacidad.IDiasIncapacidad.ToString(CultureInfo.InvariantCulture), StringComparison.InvariantCultureIgnoreCase);
                }

                pdfTemplate = pdfTemplate.Replace("{{##EPS_EMAIL##}}", "", StringComparison.InvariantCultureIgnoreCase);
                pdfTemplate = pdfTemplate.Replace("{{##INCAPACIDAD_NUIM##}}", diagnosticosIncapacidad.TCodigoCorto, StringComparison.InvariantCultureIgnoreCase);
                if (transcripcion != null)
                {
                    pdfTemplate = pdfTemplate.Replace("{{##INCAPACIDAD_No_SOLICITUD##}}", transcripcion.Iid.ToString(CultureInfo.InvariantCulture), StringComparison.InvariantCultureIgnoreCase);
                }
                else
                {
                    pdfTemplate = pdfTemplate.Replace("{{##INCAPACIDAD_No_SOLICITUD##}}", "", StringComparison.InvariantCultureIgnoreCase);
                }
                pdfTemplate = pdfTemplate.Replace("{{##INCAPACIDAD_FECHA_EXPEDICION##}}", $"{diagnosticosIncapacidad.DtFechaCreacion.Day}/{diagnosticosIncapacidad.DtFechaCreacion.ToString("MMMM", cultureInfoFechas)}/{diagnosticosIncapacidad.DtFechaCreacion.Year} {diagnosticosIncapacidad.DtFechaCreacion.ToString("hh:mm:ss tt", CultureInfo.InvariantCulture)}", StringComparison.InvariantCultureIgnoreCase);

                pdfTemplate = pdfTemplate.Replace("{{##MEDICO_TIPO_IDENTIFICACION##}}", transcripcionAIModel?.MedicoTipoIdentificacion, StringComparison.InvariantCultureIgnoreCase);
                pdfTemplate = pdfTemplate.Replace("{{##MEDICO_IDENTIFICACION##}}", transcripcionAIModel?.RegistroMedico, StringComparison.InvariantCultureIgnoreCase);
                pdfTemplate = pdfTemplate.Replace("{{##MEDICO_NOMBRE##}}", transcripcionAIModel?.NombreMedico, StringComparison.InvariantCultureIgnoreCase);
                pdfTemplate = pdfTemplate.Replace("{{##MEDICO_CODIGO_REGISTRO_MEDICO##}}", transcripcionAIModel?.RegistroMedico, StringComparison.InvariantCultureIgnoreCase);
                pdfTemplate = pdfTemplate.Replace("{{##MEDICO_ESPECIALIDAD##}}", string.IsNullOrEmpty(transcripcionAIModel?.EspecialidadMedico) ? "" : transcripcionAIModel?.EspecialidadMedico, StringComparison.InvariantCultureIgnoreCase);

                pdfTemplate = pdfTemplate.Replace("{{##INCAPACIDAD_TIPO_EMISION##}}", tipoEmision, StringComparison.InvariantCultureIgnoreCase);

                pdfTemplate = pdfTemplate.Replace("{{##INCAPACIDAD_FECHA_INICIO##}}", $"{transcripcionAIModel?.FechaInicial.Day}/{transcripcionAIModel?.FechaInicial.ToString("MMMM", cultureInfoFechas)}/{transcripcionAIModel?.FechaInicial.Year}", StringComparison.InvariantCultureIgnoreCase);
                pdfTemplate = pdfTemplate.Replace("{{##INCAPACIDAD_FECHA_FINAL##}}", $"{transcripcionAIModel?.FechaFinal.Day}/{transcripcionAIModel?.FechaFinal.ToString("MMMM", cultureInfoFechas)}/{transcripcionAIModel?.FechaFinal.Year}", StringComparison.InvariantCultureIgnoreCase);
                //pdfTemplate = pdfTemplate.Replace("{{##INCAPACIDAD_PRORROGA##}}", transcripcionAIModel.ClaseIncapacidad == ClasificacionIncapacidad.INICIAL ? "NO" : "SI");
                pdfTemplate = pdfTemplate.Replace("{{##INCAPACIDAD_PRORROGA##}}", transcripcionAIModel?.ClaseIncapacidadText, StringComparison.InvariantCultureIgnoreCase);
                pdfTemplate = pdfTemplate.Replace("{{##INCAPACIDAD_TRASLAPE##}}", "NO", StringComparison.InvariantCultureIgnoreCase);
                pdfTemplate = pdfTemplate.Replace("{{##INCAPACIDAD_DESCRIPCION##}}", transcripcionAIModel?.DiagnosticoMedico, StringComparison.InvariantCultureIgnoreCase);
                pdfTemplate = pdfTemplate.Replace("{{##INCAPACIDAD_VALOR##}}", "COP - $0.0", StringComparison.InvariantCultureIgnoreCase);

                var logo = "img/eps_img_012.png";
                var pathLogo = Path.Combine(Directory.GetCurrentDirectory(), "assets", logo);

                pdfTemplate = pdfTemplate.Replace("{0}", pathLogo, StringComparison.InvariantCultureIgnoreCase);
                pdfTemplate = pdfTemplate.Replace("{1}", _codigoQRService.GenerateCodeQR($"https://Kustodyadev.azurewebsites.net/#/auth/login/{diagnosticosIncapacidad.UiCodigoDiagnostico}"), StringComparison.InvariantCultureIgnoreCase);
                #endregion

                //Convertidor de html a pdf
                byte[] data = ConvertDocument("transcripcionPDF", pdfTemplate);

                //IronPdf.Installation.TempFolderPath = Path.GetTempPath();
                //var Renderer = new IronPdf.HtmlToPdf();

                //Renderer.PrintOptions.MarginTop = 0;  //millimeters
                //Renderer.PrintOptions.MarginLeft = 5;  //millimeters
                //Renderer.PrintOptions.MarginRight = 5;  //millimeters
                //Renderer.PrintOptions.MarginBottom = 2;  //millimeters

                //// add a footer too
                //Renderer.PrintOptions.Footer.DrawDividerLine = false;
                //Renderer.PrintOptions.Footer.FontFamily = "Arial";
                //Renderer.PrintOptions.Footer.FontSize = 10;
                //Renderer.PrintOptions.Footer.LeftText = "Fecha Impresion: {date} {time}";
                //Renderer.PrintOptions.Footer.RightText = "Pagina: {page} de {total-pages}";
                //Renderer.PrintOptions.Footer.CenterText = "Impreso por: Steven Rio";

                //// mergable fields are:
                //// {page} {total-pages} {url} {date} {time} {html-title} & {pdf-title}

                //Uri uri = new Uri(@"https://fonts.googleapis.com/css?family=Roboto&display=swap");
                //var pdf = await Renderer.RenderHtmlAsPdfAsync(pdfTemplate);

                //var data = pdf.Stream.ToArray();

                //Renderer.RenderHtmlAsPdf(pdfTemplate).SaveAs(string.Format(CultureInfo.InvariantCulture, "Transcripcion{0}.pdf", diagnosticosIncapacidad.TCodigoCorto));

                //se adjunta el archivo al email
                if (data != null)
                {
                    var file = new ObjectAttachmentWrapper()
                    {
                        type = "application /pdf",
                        filename = string.Format(CultureInfo.InvariantCulture, $"{0}_{DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture)}.pdf", diagnosticosIncapacidad.TCodigoCorto),
                        content = System.Convert.ToBase64String(data),
                        disposition = "attachment"
                    };
                    sendGridWrapper.AddAttachment(file);
                }

            }


            content.value = emailTemplate;

            SenderWrapper sender = sendGridWrapper.from;
            sender.email = "roojotechsas@gmail.com";
            sender.name = "Kustodya - Emision Incapacidad";

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                _emailService.SendEmail(sendGridWrapper);
            }).Start();
        }

        public byte[] ConvertDocument(string nameSection, string html)
        {
            var sectionTrans = _configuration.GetSection(nameSection);
            try
            {
                var messageOK = sectionTrans.GetSection("messageOK").Value;
                var sectionGlobalSettings = sectionTrans.GetSection("globalSettings");
                var sectionObjectSettings = sectionTrans.GetSection("objectSettings");
                var filePath = sectionGlobalSettings.GetSection("filePath").Value;
                var documentTitle = sectionGlobalSettings.GetSection("documentTitle").Value;
                var textHeaderSettings = sectionObjectSettings.GetSection("textHeaderSettings").Value;
                var fontNameHeaderSettings = sectionObjectSettings.GetSection("fontNameHeaderSettings").Value;
                var fontSizeHeaderSettings = Convert.ToInt32(sectionObjectSettings.GetSection("fontSizeHeaderSettings").Value, CultureInfo.InvariantCulture);
                var textRightFooterSettings = sectionObjectSettings.GetSection("textRightFooterSettings").Value;
                var textLeftFooterSettings = sectionObjectSettings.GetSection("textLeftFooterSettings").Value;
                var textCenterFooterSettings = sectionObjectSettings.GetSection("textCenterFooterSettings").Value;
                var fontNameFooterSettings = sectionObjectSettings.GetSection("fontNameFooterSettings").Value;
                var fontSizeFooterSettings = Convert.ToInt32(sectionObjectSettings.GetSection("fontSizeFooterSettings").Value, CultureInfo.InvariantCulture);

                var globalSettings = new GlobalSettings
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                    Margins = new MarginSettings { Top = 0, Bottom = 2, Left = 5, Right = 5 },
                    DocumentTitle = documentTitle,
                    //Out = string.Format(filePath, endfilename)
                };

                var objectSettings = new ObjectSettings
                {
                    PagesCount = true,
                    HtmlContent = html,
                    WebSettings = { DefaultEncoding = "utf-8" },
                    HeaderSettings = { FontName = fontNameHeaderSettings, FontSize = fontSizeHeaderSettings, Right = textHeaderSettings, Line = false },
                    FooterSettings = { FontName = fontNameFooterSettings, FontSize = fontSizeFooterSettings, Line = false, Right = textRightFooterSettings, Left = textLeftFooterSettings, Center = textCenterFooterSettings }
                };

                var pdf = new HtmlToPdfDocument()
                {
                    GlobalSettings = globalSettings,
                    Objects = { objectSettings }
                };

                byte[] result = _converter.Convert(pdf);

                return result;
            }
            catch(Exception)
            {
                return null;
            }
        }
        public async Task<IReadOnlyList<tblLateralidad>> GetLateralidades()
        {
            return await _lateralidadRepo.ListAllAsync().ConfigureAwait(false);
        }
    }
}