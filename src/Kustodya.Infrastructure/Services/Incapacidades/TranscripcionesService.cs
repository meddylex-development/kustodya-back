using AutoMapper;
using DinkToPdf;
using DinkToPdf.Contracts;
using Kustodya.Shared.Wrappers;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Interfaces.Incapacidades;
using Kustodya.ApplicationCore.Specifications.Incapacidades;
using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Constants;
using Kustodya.ApplicationCore.Dtos.Configuracion.Notificaciones;
using Kustodya.ApplicationCore.Dtos.General;
using Kustodya.ApplicationCore.Dtos.Incapacidades;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Kustodya.ApplicationCore.Interfaces.AI;
using Kustodya.ApplicationCore.Interfaces.Configuracion.Parametros;
using Kustodya.ApplicationCore.Interfaces.Configuracion.Notificaciones;
using Kustodya.ApplicationCore.Interfaces.Configuracion.CodigoQR;
using Kustodya.ApplicationCore.Interfaces.Configuracion.Email;

namespace Kustodya.BusinessLogic.Services.Incapacidades
{
    public class TranscripcionesService : ITranscripcionesService
    {
        #region DI
        private readonly IPacienteService _pacienteService;
        private readonly IDiagnosticoIncapacidadService _diagnosticoIncapacidad;
        private readonly IOCREngineService _ocrEngineService;
        private readonly IMapper _mapper;
        private readonly IParametrosService _parametrosService;
        private readonly IAsyncRepository<TblTranscripciones> _transcripcionRepository;
        private readonly INotificacionService _notificacionService;
        private readonly IConfiguration _configuration;
        private readonly ICodigoQRService _codigoQRService;
        private readonly IConverter _converter;
        private readonly IEmailService _emailService;

        public TranscripcionesService(IPacienteService pacienteService,
            IDiagnosticoIncapacidadService diagnosticoService,
            IOCREngineService ocrService,
            IParametrosService parametrosService,
            IMapper mapper,
            IAsyncRepository<TblTranscripciones> transcripcionRepository,
            INotificacionService notificacionService,
            IConfiguration configuration,
            ICodigoQRService qrService,
            IConverter converter,
            IEmailService emailService)
        {
            _mapper = mapper;
            _pacienteService = pacienteService;
            _ocrEngineService = ocrService;
            _diagnosticoIncapacidad = diagnosticoService;
            _parametrosService = parametrosService;
            _transcripcionRepository = transcripcionRepository;
            _notificacionService = notificacionService;
            _configuration = configuration;
            _codigoQRService = qrService;
            _converter = converter;
            _emailService = emailService;
        }
        #endregion

        public async Task<TranscripcionConfirmationModel> AddTranscription(TranscripcionModel transcripcionModel)
        {
            if (transcripcionModel == null)
            {
                throw new ArgumentNullException(nameof(transcripcionModel));
            }
            TblPacientes paciente = null;
            if (transcripcionModel.TipoDocumentoId != null
                && !string.IsNullOrEmpty(transcripcionModel.NumeroDocumento))
            {
                paciente = await _pacienteService.ValidarPacientePorNumeroDocumento((int)transcripcionModel.TipoDocumentoId, transcripcionModel.NumeroDocumento).ConfigureAwait(false);
                if (paciente == null)
                {
                    throw new NullReferenceException($"Paciente [{ transcripcionModel.NumeroDocumento}] no encontrado.");
                }
            }

            OCRExtractionMethod ocrExtractMethod = await GetOCRExtractionMethod().ConfigureAwait(false);
            var blobId = transcripcionModel.BlobCertificadoIncapacidadId;
            var ocrModel = await _ocrEngineService.GetOCRTextByAzureBlobId(blobId, ocrExtractMethod, "mycontainer").ConfigureAwait(false);

            TranscripcionAIModel modelT = await _ocrEngineService.PerformTextTranscription(ocrModel.Sentences, ocrExtractMethod, paciente).ConfigureAwait(false);
            paciente = await _pacienteService.GetPacienteByNumeroDocumento(9, modelT.Paciente.TNumeroDocumento);

            if (modelT.Diagnostico == null)
            {
                const string Message = "Invalid Object (Diagnostico) null.";
                throw new NullReferenceException(Message);
            }

            var diagnostico = _mapper.Map<TblDiagnosticosIncapacidades>(modelT.Diagnostico);
            diagnostico.BEsTranscripcion = true;

            var extractId = (short)Convert.ToInt32(ocrExtractMethod, CultureInfo.InvariantCulture);
            //send Email
            var OCRTextJoin = string.Join(Environment.NewLine, ocrModel.Sentences);
            var transcripcion = new TblTranscripciones()
            {
                DtfechaCreacion = diagnostico.DtFechaCreacion,
                IidDiagnostico = diagnostico.IIddiagnosticoIncapacidad,
                TblobId = transcripcionModel.BlobCertificadoIncapacidadId,
                OcrserviceText = ocrModel.RawOcrResponse,
                Ocrtext = OCRTextJoin,
                OcrproviderId = extractId,
                IDiasIncapacidad = modelT.DiasIncapacidad,
                TcentroAtencion = modelT.CentroAtencion,
                TfechaFinal = modelT.FechaFinal.ToString(CultureInfo.InvariantCulture),
                TfechaInicial = modelT.FechaInicial.ToString(CultureInfo.InvariantCulture),
                TidCie10 = modelT.IdCie10,
                TnombreMedico = modelT.NombreMedico,
                TfechaCreacion = modelT.FechaCreacion.ToString(CultureInfo.InvariantCulture),
                TregistroMedico = modelT.RegistroMedico,
                TnumeroIncapacidad = modelT.NumeroIncapacidad,
                Tdiagnostico = modelT.DiagnosticoMedico,
                TclaseIncapacidad = modelT.ClaseIncapacidad.ToString(),
                TtipoIdentificacionPaciente = modelT.TipoDocumentoPaciente,
                TnumeroIdentificacionPaciente = modelT.NumeroDocumentoPaciente,
                TnombrePaciente = modelT.NombrePaciente,
                TgeneroPaciente = modelT.GeneroPaciente,
                IedadPaciente = modelT.EdadPaciente,
                TnombreIps = modelT.IpsNombre,
                TnombreEps = modelT.NombreEps
            };

            transcripcion = await _transcripcionRepository.AddAsync(transcripcion).ConfigureAwait(false);

            diagnostico = await _diagnosticoIncapacidad.CrearDiagnosticosIncapacidad(diagnostico, paciente, paciente.IIdpaciente, modelT, transcripcion).ConfigureAwait(false);

            var confirmation = new TranscripcionConfirmationModel
            {
                NombrePaciente = $"{modelT.NombrePaciente}",
                NumeroDocumento = modelT.NumeroDocumentoPaciente,
                IdTranscripcion = transcripcion.Iid,
                IdPaciente = paciente.IIdpaciente,

            };
            return confirmation;
        }

        public async Task<TranscripcionConfirmationModel> AddTranscriptionOnlyOcr(TranscripcionModel transcripcionModel)
        {
            if (transcripcionModel == null)
            {
                string message = $"Null Object ({nameof(transcripcionModel)})";
                throw new ArgumentNullException(nameof(transcripcionModel), message);
            }
            TblPacientes paciente = null;

            OCRExtractionMethod ocrExtractMethod = await GetOCRExtractionMethod().ConfigureAwait(false);
            var blobId = transcripcionModel.BlobCertificadoIncapacidadId;
            var ocrModel = await _ocrEngineService.GetOCRTextByAzureBlobId(blobId, ocrExtractMethod, "mycontainer").ConfigureAwait(false);

            TranscripcionAIModel modelT = await _ocrEngineService.PerformTextTranscription(ocrModel.Sentences, ocrExtractMethod, paciente).ConfigureAwait(false);

            if (modelT.Diagnostico == null)
            {
                const string Message = "Invalid Object (Diagnostico) null.";
                throw new NullReferenceException(nameof(modelT.Diagnostico));
            }

            var diagnostico = _mapper.Map<TblDiagnosticosIncapacidades>(modelT.Diagnostico);
            diagnostico.BEsTranscripcion = true;
            var extractId = (short)Convert.ToInt32(ocrExtractMethod, CultureInfo.InvariantCulture);
            var OCRTextJoin = string.Join(Environment.NewLine, ocrModel.Sentences);

            var transcripcion = new TblTranscripciones()
            {
                DtfechaCreacion = diagnostico.DtFechaCreacion,
                IidDiagnostico = diagnostico.IIddiagnosticoIncapacidad,
                TblobId = transcripcionModel.BlobCertificadoIncapacidadId,
                OcrserviceText = ocrModel.RawOcrResponse,
                Ocrtext = OCRTextJoin,
                OcrproviderId = extractId,
                IDiasIncapacidad = modelT.DiasIncapacidad,
                TcentroAtencion = modelT.CentroAtencion,
                TfechaFinal = modelT.FechaFinal.ToString(CultureInfo.InvariantCulture),
                TfechaInicial = modelT.FechaInicial.ToString(CultureInfo.InvariantCulture),
                TidCie10 = modelT.IdCie10,
                TnombreMedico = modelT.NombreMedico,
                TfechaCreacion = modelT.FechaCreacion.ToString(CultureInfo.InvariantCulture),
                TregistroMedico = modelT.RegistroMedico,
                TnumeroIncapacidad = modelT.NumeroIncapacidad,
                Tdiagnostico = modelT.DiagnosticoMedico,
                TclaseIncapacidad = modelT.ClaseIncapacidad.ToString(),
                TtipoIdentificacionPaciente = modelT.TipoDocumentoPaciente,
                TnumeroIdentificacionPaciente = modelT.NumeroDocumentoPaciente,
                TnombrePaciente = modelT.NombrePaciente,
                TgeneroPaciente = modelT.GeneroPaciente,
                IedadPaciente = modelT.EdadPaciente,
                TnombreIps = modelT.IpsNombre,
                TnombreEps = modelT.NombreEps
            };

            transcripcion = await _transcripcionRepository.AddAsync(transcripcion).ConfigureAwait(false);

            await SendEmail(diagnostico, modelT, transcripcion).ConfigureAwait(false);

            var confirmation = new TranscripcionConfirmationModel
            {
                NombrePaciente = $"{modelT.NombrePaciente}",
                NumeroDocumento = modelT.NumeroDocumentoPaciente,
                IdTranscripcion = transcripcion.Iid
            };

            return confirmation;
        }

        #region Helper Methods
        private async Task<OCRExtractionMethod> GetOCRExtractionMethod()
        {
            OCRExtractionMethod ocrExtractMethod = OCRExtractionMethod.Azure;
            var extractParam = await _parametrosService.GetParameterByIdentificator("OCRExtractMethod").ConfigureAwait(false);

            if (extractParam != null && Enum.IsDefined(typeof(OCRExtractionMethod), Convert.ToInt32(extractParam.TValor, CultureInfo.InvariantCulture)))
            {
                ocrExtractMethod = (OCRExtractionMethod)int.Parse(extractParam.TValor, CultureInfo.InvariantCulture);
            }

            return ocrExtractMethod;
        }


        private async Task SendEmail(TblDiagnosticosIncapacidades diagnosticosIncapacidad, TranscripcionAIModel transcripcionAIModel, TblTranscripciones transcripcion)
        {
            SendgridEmailWrapper sendGridWrapper = new SendgridEmailWrapper();

            PersonalizationWrapper personalization = sendGridWrapper.personalizations[0];

            personalization.subject = $"Kustodya - Certificado de Incapacidad Medica Laboral - {transcripcionAIModel.NombrePaciente}";
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

            //var eps = await _epsService.GetEPSById(paciente.IIdeps).ConfigureAwait(false);
            //var ips = await _ipsService.GetIPSById(diagnosticosIncapacidad.IIdips).ConfigureAwait(false);

            var tipoEmision = (diagnosticosIncapacidad.BEsTranscripcion == true) ? "TRANSCRIPCIÓN" : "PRIMARIA";

            emailTemplate = emailTemplate.Replace("{{##MEDICO##}", "", StringComparison.Ordinal);
            emailTemplate = emailTemplate.Replace("{{##NUMERO_IDENTIFICACION_AFILIADO##}}", transcripcionAIModel.NumeroDocumentoPaciente, StringComparison.Ordinal);
            if (transcripcionAIModel != null)
            {
                emailTemplate = emailTemplate.Replace("{{##NOMBRE_PACIENTE##}}", transcripcionAIModel.NombrePaciente, StringComparison.Ordinal);
                emailTemplate = emailTemplate.Replace("{{##APELLIDO_PACIENTE##}}", "", StringComparison.Ordinal);
            }
            else
            {
                emailTemplate = emailTemplate.Replace("{{##NOMBRE_PACIENTE##}}", transcripcionAIModel.NombrePaciente, StringComparison.Ordinal);
                emailTemplate = emailTemplate.Replace("{{##APELLIDO_PACIENTE##}}", "", StringComparison.Ordinal);
            }

            emailTemplate = emailTemplate.Replace("{{##CLASE_INCAPACIDAD##}}", tipoEmision, StringComparison.Ordinal);
            emailTemplate = emailTemplate.Replace("{{##DIAS_INCAPACIDAD##}}", transcripcionAIModel.DiasIncapacidad.ToString(CultureInfo.InvariantCulture), StringComparison.Ordinal);
            emailTemplate = emailTemplate.Replace("{{##FECHA_INICIAL_INCAPACIDAD##}}", $"{transcripcionAIModel.FechaInicial.Day}/{transcripcionAIModel.FechaInicial.ToString("MMMM", cultureInfoFechas)}/{transcripcionAIModel.FechaInicial.Year}", StringComparison.Ordinal);

            var diasIncapacidad = 1;
            if (diagnosticosIncapacidad.DtFechaFin != null)
            {
                diasIncapacidad = (int)(diagnosticosIncapacidad.DtFechaFin.Date - ((DateTime)diagnosticosIncapacidad.DtFechaEmisionIncapacidad).Date).TotalDays;
            }
            emailTemplate = emailTemplate.Replace("{{##FECHA_FINAL_INCAPACIDAD##}}", $"{transcripcionAIModel.FechaFinal.Day}/{transcripcionAIModel.FechaFinal.ToString("MMMM", cultureInfoFechas)}/{transcripcionAIModel.FechaFinal.Year}", StringComparison.Ordinal);
            emailTemplate = emailTemplate.Replace("{{##URL_INCAPACIDAD##}}", $"https://Kustodyadev.azurewebsites.net/#/auth/login/{diagnosticosIncapacidad.UiCodigoDiagnostico}", StringComparison.Ordinal);
            emailTemplate = emailTemplate.Replace("{{##NOMBRE_EPS##}}", $"{transcripcionAIModel.NombreEps}", StringComparison.Ordinal);
            emailTemplate = emailTemplate.Replace("{{##NOMBRE_IPS##}}", $"{transcripcionAIModel.IpsNombre}", StringComparison.Ordinal);
            emailTemplate = emailTemplate.Replace("{{##CODIGO_CASO##}}", $"{diagnosticosIncapacidad.UiCodigoDiagnostico}", StringComparison.Ordinal);
            emailTemplate = emailTemplate.Replace("{{##NUIM##}}", $"{diagnosticosIncapacidad.TCodigoCorto}", StringComparison.Ordinal);

            if ((bool)diagnosticosIncapacidad.BEsTranscripcion)
            {
                ParametrosModel parametroPDF = await _parametrosService.GetParameterByIdentificator("TEMPLATE_PDF_TRANSCRIPCION").ConfigureAwait(false);
                string pdfTemplate = parametroPDF.TValor;
                //var empresaPaciente = await _empresaService.GetEmpresaById((long)paciente.IIdempresa).ConfigureAwait(false);

                #region pdfTemplate
                pdfTemplate = pdfTemplate.Replace("{{##EPS_IDENTIFICACION##}}", transcripcionAIModel.NumeroIdentificacionEps, StringComparison.InvariantCultureIgnoreCase);
                pdfTemplate = pdfTemplate.Replace("{{##EPS_CODIGO_HABILITACION##}}", transcripcionAIModel.NumeroHabilitacionEPS, StringComparison.InvariantCultureIgnoreCase);
                pdfTemplate = pdfTemplate.Replace("{{##EPS_EMAIL##}}", "", StringComparison.InvariantCultureIgnoreCase);

                pdfTemplate = pdfTemplate.Replace("{{##INCAPACIDAD_NUIM##}}", diagnosticosIncapacidad.TCodigoCorto, StringComparison.InvariantCultureIgnoreCase);
                if (transcripcion != null)
                {
                    pdfTemplate = pdfTemplate.Replace("{{##INCAPACIDAD_No_SOLICITUD##}}", transcripcion.Iid.ToString(CultureInfo.InvariantCulture), StringComparison.InvariantCultureIgnoreCase);
                }
                pdfTemplate = pdfTemplate.Replace("{{##INCAPACIDAD_FECHA_EXPEDICION##}}", $"{diagnosticosIncapacidad.DtFechaCreacion.Day}/{diagnosticosIncapacidad.DtFechaCreacion.ToString("MMMM", cultureInfoFechas)}/{diagnosticosIncapacidad.DtFechaCreacion.Year} {diagnosticosIncapacidad.DtFechaCreacion.ToString("hh:mm:ss tt", CultureInfo.InvariantCulture)}", StringComparison.InvariantCultureIgnoreCase);

                pdfTemplate = pdfTemplate.Replace("{{##PACIENTE_TIPO_IDENTIFICACION##}}", transcripcionAIModel.TipoDocumentoPaciente, StringComparison.InvariantCultureIgnoreCase);
                pdfTemplate = pdfTemplate.Replace("{{##PACIENTE_No_IDENTIFICACION##}}", transcripcionAIModel.NumeroDocumentoPaciente, StringComparison.InvariantCultureIgnoreCase);
                pdfTemplate = pdfTemplate.Replace("{{##PACIENTE_SEXO##}}", transcripcionAIModel.GeneroPaciente, StringComparison.InvariantCultureIgnoreCase);
                pdfTemplate = pdfTemplate.Replace("{{##PACIENTE_EDAD##}}", transcripcionAIModel.EdadPaciente, StringComparison.InvariantCultureIgnoreCase);
                pdfTemplate = pdfTemplate.Replace("{{##PACIENTE_NOMBRE##}}", transcripcionAIModel.NombrePaciente, StringComparison.InvariantCultureIgnoreCase);
                if (transcripcionAIModel == null)
                {
                    var fechaNacimiento = (DateTime)transcripcionAIModel.fechaNacimiento;
                    pdfTemplate = pdfTemplate.Replace("{{##PACIENTE_FECHA_NACIMIENTO##}}", $"{transcripcionAIModel.fechaNacimiento}", StringComparison.InvariantCultureIgnoreCase);
                }
                else
                {
                    pdfTemplate = pdfTemplate.Replace("{{##PACIENTE_FECHA_NACIMIENTO##}}", $"{transcripcionAIModel.FechaNacimientoText}", StringComparison.InvariantCultureIgnoreCase);
                }
                pdfTemplate = pdfTemplate.Replace("{{##EMPLEADOR_TIPO_IDENTIFICACION##}}", "", StringComparison.InvariantCultureIgnoreCase);
                pdfTemplate = pdfTemplate.Replace("{{##EMPLEADOR_IDENTIFICACION##}}", "", StringComparison.InvariantCultureIgnoreCase);
                pdfTemplate = pdfTemplate.Replace("{{##EMPLEADOR_RAZON_SOCIAL##}}", "", StringComparison.InvariantCultureIgnoreCase);
                pdfTemplate = pdfTemplate.Replace("{{##EMPLEADOR_ACTIVIDAD_ECONOMICA##}}", "", StringComparison.InvariantCultureIgnoreCase);
                pdfTemplate = pdfTemplate.Replace("{{##EMPLEADOR_CIU##}}", "", StringComparison.InvariantCultureIgnoreCase);

                pdfTemplate = pdfTemplate.Replace("{{##IPS_TIPO_IDENTIFICACION##}}", transcripcionAIModel.IpsTipoIdentificacion, StringComparison.InvariantCultureIgnoreCase);
                pdfTemplate = pdfTemplate.Replace("{{##IPS_IDENTIFICACION##}}", transcripcionAIModel.IpsNumeroIdentificacion, StringComparison.InvariantCultureIgnoreCase);
                if (transcripcionAIModel == null)
                {
                    pdfTemplate = pdfTemplate.Replace("{{##IPS_RAZON_SOCIAL##}}", transcripcionAIModel.IpsNombre, StringComparison.InvariantCultureIgnoreCase);
                }
                else
                {
                    pdfTemplate = pdfTemplate.Replace("{{##IPS_RAZON_SOCIAL##}}", transcripcionAIModel.CentroAtencionFull, StringComparison.InvariantCultureIgnoreCase);
                }
                pdfTemplate = pdfTemplate.Replace("{{##IPS_CODIGO_HABILITACION##}}", transcripcionAIModel.IpsCodigoExterno, StringComparison.InvariantCultureIgnoreCase);
                pdfTemplate = pdfTemplate.Replace("{{##MEDICO_TIPO_IDENTIFICACION##}}", transcripcionAIModel.MedicoTipoIdentificacion, StringComparison.InvariantCultureIgnoreCase);
                pdfTemplate = pdfTemplate.Replace("{{##MEDICO_IDENTIFICACION##}}", transcripcionAIModel.RegistroMedico, StringComparison.InvariantCultureIgnoreCase);
                pdfTemplate = pdfTemplate.Replace("{{##MEDICO_NOMBRE##}}", transcripcionAIModel.NombreMedico, StringComparison.InvariantCultureIgnoreCase);
                pdfTemplate = pdfTemplate.Replace("{{##MEDICO_CODIGO_REGISTRO_MEDICO##}}", transcripcionAIModel.RegistroMedico, StringComparison.InvariantCultureIgnoreCase);
                pdfTemplate = pdfTemplate.Replace("{{##MEDICO_ESPECIALIDAD##}}", string.IsNullOrEmpty(transcripcionAIModel.EspecialidadMedico) ? "" : transcripcionAIModel.EspecialidadMedico, StringComparison.InvariantCultureIgnoreCase);

                pdfTemplate = pdfTemplate.Replace("{{##INCAPACIDAD_TIPO_EMISION##}}", tipoEmision, StringComparison.InvariantCultureIgnoreCase);
                pdfTemplate = pdfTemplate.Replace("{{##INCAPACIDAD_No_INCAPACIDAD_TRANSCRITA##}}", transcripcionAIModel.NumeroIncapacidad, StringComparison.InvariantCultureIgnoreCase);
                var fechaEmision = (DateTime)diagnosticosIncapacidad.DtFechaEmisionIncapacidad;
                if (transcripcionAIModel != null)
                {
                    pdfTemplate = pdfTemplate.Replace("{{##INCAPACIDAD_FECHA_INCAPACIDAD_TRANSCRITA##}}", $"{transcripcionAIModel.FechaDocumento}", StringComparison.InvariantCultureIgnoreCase);
                }
                else
                {
                    pdfTemplate = pdfTemplate.Replace("{{##INCAPACIDAD_FECHA_INCAPACIDAD_TRANSCRITA##}}", $"{fechaEmision.Day}/{fechaEmision.ToString("MMMM", cultureInfoFechas)}/{fechaEmision.Year}", StringComparison.InvariantCultureIgnoreCase);
                }
                pdfTemplate = pdfTemplate.Replace("{{##INCAPACIDAD_DIAGNOSTICO##}}", $"{transcripcionAIModel.IdCie10} - {transcripcionAIModel.DescripcionCie10}", StringComparison.InvariantCultureIgnoreCase);
                pdfTemplate = pdfTemplate.Replace("{{##INCAPACIDAD_TIPO_ORIGEN##}}", transcripcionAIModel.TipoOrigen, StringComparison.InvariantCultureIgnoreCase);

                pdfTemplate = pdfTemplate.Replace("{{##INCAPACIDAD_DIAS_INCAPACIDAD##}}", $"{transcripcionAIModel.DiasIncapacidad}", StringComparison.InvariantCultureIgnoreCase);
                pdfTemplate = pdfTemplate.Replace("{{##INCAPACIDAD_FECHA_INICIO##}}", $"{transcripcionAIModel.FechaInicial.Day}/{transcripcionAIModel.FechaInicial.ToString("MMMM", cultureInfoFechas)}/{transcripcionAIModel.FechaInicial.Year}", StringComparison.InvariantCultureIgnoreCase);
                pdfTemplate = pdfTemplate.Replace("{{##INCAPACIDAD_FECHA_FINAL##}}", $"{transcripcionAIModel.FechaFinal.Day}/{transcripcionAIModel.FechaFinal.ToString("MMMM", cultureInfoFechas)}/{transcripcionAIModel.FechaFinal.Year}", StringComparison.InvariantCultureIgnoreCase);
                pdfTemplate = pdfTemplate.Replace("{{##INCAPACIDAD_PRORROGA##}}", transcripcionAIModel.ClaseIncapacidadText, StringComparison.InvariantCultureIgnoreCase);
                pdfTemplate = pdfTemplate.Replace("{{##INCAPACIDAD_TRASLAPE##}}", "NO", StringComparison.InvariantCultureIgnoreCase);
                pdfTemplate = pdfTemplate.Replace("{{##INCAPACIDAD_DESCRIPCION##}}", transcripcionAIModel.DiagnosticoMedico, StringComparison.InvariantCultureIgnoreCase);
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

        #endregion
    }
}
