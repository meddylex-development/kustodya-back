using AutoMapper;
using Google.Cloud.Vision.V1;
using Google.Protobuf;
using Kustodya.BussinessLogic.Interfaces.General;
using Kustodya.ApplicationCore.Interfaces.Incapacidades;
using Kustodya.ApplicationCore.Interfaces.Negocio;
using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Constants;
using Kustodya.ApplicationCore.Dtos.Incapacidades;
using Kustodya.ApplicationCore.Dtos.Negocio;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Kustodya.ApplicationCore.Interfaces.AI;
using Kustodya.ApplicationCore.Interfaces.General;
using Kustodya.ApplicationCore.Interfaces.Configuracion.Parametros;
using Tesseract;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using SautinSoft.Document;

namespace Kustodya.Medicos.Services.AI
{
    public class OCREngineService : IOCREngineService
    {

        private const string patternNumeroIncapacidad = @"\b[Nn][o°][0-9]*\b";
        private const string patternRM = @"[R][.]*[M]";
        private const string patternCie10 = @"[A-z]{1}[0-9]{3}[\t|\n|\r]*";
        private const string centroAtencionrx = @"CENTRO\sATENCION";
        private const string cruzRojaPattern = @"CRUZ\sROJ";
        private const string medimaseEPSPattern = @"[Mm]edim[a|a]?s";
        private const string patternPacienteCedula = "C[e|e]?dula";
        private const string medicoRx = @"M[e|e]?dico[:]?";
        private const string matchMedimasFecha = @"[2]{1}[0-9]{3}-[0-9]{2}-[0-9]{2}";
        private const string centroAtencionMedimasrx = @"EXPEDICION:";
        private const string PatternNombrePaciente = @"informaci[o|o]?n";
        private readonly string[] _separators = new string[5] { " ", Environment.NewLine, "\t", "\n", "\t" };


        private readonly IMapper _mapper;
        private readonly ICie10Service _cie10Service;
        private readonly IMultivaloresService _multivaloresService;
        private readonly IEPSService _epsService;
        private readonly IPacienteService _pacientesService;
        private readonly IParametrosService _ParametrosService;
        private readonly IBlobService _blobService;
        private readonly IComputerVision _computerVision;
        private readonly ITextAnalytics _textAnalytics;
        private readonly IIPSService _ipsService;
        private readonly IConfiguration _configuration;
        private IDictionary<string, int> months = new Dictionary<string, int>();
        public OCREngineService(
            IMultivaloresService multivaloresService,
            IMapper mapper,
            ICie10Service cie10Service,
            IEPSService epsService,
            IPacienteService pacientesService,
            IParametrosService parametrosService,
            IBlobService blobService,
            IComputerVision computerVision,
            ITextAnalytics textAnalytics,
            IIPSService ipsService,
            IConfiguration configuration
            )
        {
            _cie10Service = cie10Service;
            _multivaloresService = multivaloresService;
            _mapper = mapper;
            _epsService = epsService;
            _pacientesService = pacientesService;
            _ParametrosService = parametrosService;
            _blobService = blobService;
            _computerVision = computerVision;
            _textAnalytics = textAnalytics;
            _ipsService = ipsService;
            _configuration = configuration;
            #region Init_Months
            months.Add("enero", 1);
            months.Add("febrero", 2);
            months.Add("marzo", 3);
            months.Add("abril", 4);
            months.Add("mayo", 5);
            months.Add("junio", 6);
            months.Add("julio", 7);
            months.Add("agosto", 8);
            months.Add("septiembre", 9);
            months.Add("octubre", 10);
            #endregion
        }

        public async Task<OCRExtractionMethodModel> GetOCRTextByAzureBlobId(string blobId, OCRExtractionMethod ocrExtractMethod, string container)
        {
            if (string.IsNullOrEmpty(blobId))
            {
                const string Message = "Null Argument";
                throw new ArgumentNullException(nameof(blobId), Message);
            }

            MemoryStream stream = await _blobService.GetBlobFileByGuidAsync(blobId, container).ConfigureAwait(false);
            var imageMemoryStream = stream.ToArray();
            var text = string.Empty;
            OCRExtractionMethodModel ocrMethod = new OCRExtractionMethodModel();
            switch (ocrExtractMethod)
            {
                case OCRExtractionMethod.Tesseract:
                    ocrMethod = GetOCRTextWithTesseract(imageMemoryStream);
                    break;
                case OCRExtractionMethod.Azure:
                    ocrMethod = await GetOCRTextWithAzureCognitive(stream, blobId).ConfigureAwait(false);
                    break;
                case OCRExtractionMethod.Google_VisionAI:
                    ocrMethod = await GetOCRTextWithGoogleVisionAI(stream).ConfigureAwait(false);
                    break;
                case OCRExtractionMethod.iTextSharp:
                    ocrMethod = GetTextFromPDF(stream.ToArray());
                    if (ocrMethod.Sentences[0].Length == 0)
                        ocrMethod = ExtractImagesFromPDF(stream.ToArray());
                    break;
                case OCRExtractionMethod.Word:
                    ocrMethod = GetTextFromDoc(stream);
                    break;

                default:
                    //ocrMethod = await GetOCRTextWithAzureCognitive(stream, blobId).ConfigureAwait(false);
                    
                    break;
            }
            return ocrMethod;
        }

        private async Task<OCRExtractionMethodModel> GetOCRTextWithGoogleVisionAI(MemoryStream stream)
        {
            var ocrModel = new OCRExtractionMethodModel();
            var googleConfigJsonName = _configuration["GoogleVisionAI:CredentialsFilename"];
            string folderPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            string fullPath = System.IO.Path.Combine(folderPath.Substring(6), "assets", googleConfigJsonName);
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", fullPath, EnvironmentVariableTarget.Process);
            stream.Position = 0;
            var imageGoogleVision = await Image.FromStreamAsync(stream).ConfigureAwait(false);
            var client = ImageAnnotatorClient.Create();
            var response = await client.DetectDocumentTextAsync(imageGoogleVision).ConfigureAwait(false);

            var lSentences = response.Text.Split("\n").ToList();
            //foreach (var page in response.Pages)
            //{
            //    foreach (var block in page.Blocks)
            //    {
            //        foreach (var paragraph in block.Paragraphs)
            //        {
            //            Console.WriteLine(string.Join("\n", paragraph.Words));
            //            lSentences.Add($"{paragraph.Words}");
            //        }
            //    }
            //}

            //foreach (var annotation in response)
            //{
            //    if (annotation.Description != null)
            //        lSentences.Add(annotation.Description);
            //}

            var jsonRaw = JsonConvert.SerializeObject(response);
            ocrModel.RawOcrResponse = jsonRaw;
            ocrModel.Sentences = lSentences;
            return ocrModel;
        }

        private async Task<OCRExtractionMethodModel> GetOCRTextWithAzureCognitive(MemoryStream stream, string uuid)
        {
            var text = await _computerVision.ReadPrintedTextAsync(stream, uuid).ConfigureAwait(false);
            return text;
        }

        private static OCRExtractionMethodModel GetOCRTextWithTesseract(byte[] imageMemoryStream)
        {
            OCRExtractionMethodModel ocrModel = new OCRExtractionMethodModel();
            IList<string> lPhrases = new List<string>();
            StringBuilder sb = new StringBuilder();
            string text = string.Empty;
            try
            {
                using (var engine = new TesseractEngine(@".\TrainedLanguageData", "spa", EngineMode.Default))
                {
                    using (var img = Pix.LoadFromMemory(imageMemoryStream))
                    {
                        using (var page = engine.Process(img))
                        {
                            using (var iter = page.GetIterator())
                            {
                                iter.Begin();
                                do
                                {
                                    do
                                    {
                                        do
                                        {
                                            do
                                            {
                                                if (iter.IsAtBeginningOf(PageIteratorLevel.Block))
                                                {
                                                    lPhrases.Add(sb.ToString());
                                                    sb.Clear();
                                                }
                                                sb.Append(iter.GetText(PageIteratorLevel.Word)).Append(" ");

                                                if (iter.IsAtFinalOf(PageIteratorLevel.TextLine, PageIteratorLevel.Word))
                                                {
                                                    //Console.WriteLine();
                                                }
                                            } while (iter.Next(PageIteratorLevel.TextLine, PageIteratorLevel.Word));

                                            if (iter.IsAtFinalOf(PageIteratorLevel.Para, PageIteratorLevel.TextLine))
                                            {
                                                //Console.WriteLine();
                                            }
                                        } while (iter.Next(PageIteratorLevel.Para, PageIteratorLevel.TextLine));
                                    } while (iter.Next(PageIteratorLevel.Block, PageIteratorLevel.Para));
                                } while (iter.Next(PageIteratorLevel.Block));
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Trace.TraceError(e.ToString());
            }

            ocrModel.Sentences = lPhrases;
            return ocrModel;
        }

        public async Task<TranscripcionAIModel> PerformTextTranscription(IList<string> ocrText, OCRExtractionMethod ocrExtractMethod, TblPacientes paciente)
        {
            if (ocrText == null || ocrText.Count < 1)
            {
                const string Message = "Invalid Argument";
                throw new ArgumentNullException(nameof(ocrText), Message);
            }

            TranscripcionAIModel AIModel = new TranscripcionAIModel();

            switch (ocrExtractMethod)
            {
                case OCRExtractionMethod.Tesseract:
                    AIModel = PerformTextTranscriptionByExpertSystem(ocrText);
                    break;
                case OCRExtractionMethod.Azure:
                    AIModel = PerformTextTranscriptionWithAzureCognitive(ocrText);
                    break;
                case OCRExtractionMethod.Google_VisionAI:
                    AIModel = PerformTextTranscriptionByExpertSystem(ocrText);
                    break;
                default:
                    AIModel = PerformTextTranscriptionWithAzureCognitive(ocrText);
                    break;
            }

            AIModel = await FillInDiagnostico(AIModel);


            if (paciente == null)
            {
                paciente = await _pacientesService.GetPacienteByNumeroDocumento(9, AIModel.NumeroDocumentoPaciente).ConfigureAwait(false);
                if (paciente == null)
                {
                    const string Message = "Paciente no encontrado en BD.";
                    throw new Exception(Message);
                }

            }

            TblDiagnosticosIncapacidades diagnostico = _mapper.Map<TblDiagnosticosIncapacidades>(AIModel.Diagnostico);

            IReadOnlyList<TblMultivalores> lTiposAtencion = await _multivaloresService.GetDatosSubtabla(Subtabla.TipoAtencion).ConfigureAwait(false);

            diagnostico.IIdtipoAtencionNavigation = lTiposAtencion.First(x => x.IIdmultivalor == 3563);
            diagnostico.IIdtipoAtencion = diagnostico.IIdtipoAtencionNavigation.IIdmultivalor;

            IReadOnlyList<TblMultivalores> lTiposIdentiuficacion = await _multivaloresService.GetDatosSubtabla(Subtabla.TipoIdentificacion).ConfigureAwait(false);
            var idTipoDocumento = int.Parse(lTiposAtencion.First(x => x.TValor == "1").IIdmultivalor.ToString(CultureInfo.InvariantCulture), CultureInfo.InvariantCulture);

            EpsModel modelEps = await _epsService.GetEPSById(paciente.IIdeps).ConfigureAwait(false);
            diagnostico.IIdeps = modelEps.IIdeps;
            TblEps eps = _mapper.Map<TblEps>(modelEps);
            diagnostico.IIdepsNavigation = eps;

            IPSModel modelIps = await _ipsService.GetIPSByName(AIModel.CentroAtencion).ConfigureAwait(false);
            diagnostico.IIdips = modelIps.IIdips;
            TblIps ips = _mapper.Map<TblIps>(modelIps);
            diagnostico.IIdipsNavigation = ips;

            diagnostico.DtFechaEmisionIncapacidad = AIModel.FechaInicial;
            diagnostico.DtFechaFin = AIModel.FechaFinal;
            diagnostico.DtFechaCreacion = DateTime.Now;
            TblCie10 cie10 = await _cie10Service.GetCie10BytCie10(AIModel.IdCie10).ConfigureAwait(false);



            diagnostico.TblCie10DiagnosticoIncapacidad = new List<TblCie10DiagnosticoIncapacidad>();

            diagnostico.TblCie10DiagnosticoIncapacidad.Add(new TblCie10DiagnosticoIncapacidad()
            {
                IIdcie10 = cie10.IIdcie10,
                IIdcie10Navigation = cie10
            });

            IReadOnlyList<TblMultivalores> lOrigenIncapacidad = await _multivaloresService.GetDatosSubtabla(Subtabla.OrigenIncapacidad).ConfigureAwait(false);
            diagnostico.IIdpresuntoOrigenIncapacidadNavigation = lOrigenIncapacidad.First(x => x.IIdmultivalor == 3550);
            diagnostico.IIdpresuntoOrigenIncapacidad = diagnostico.IIdpresuntoOrigenIncapacidadNavigation.IIdmultivalor;

            diagnostico.IIdpaciente = paciente.IIdpaciente;
            diagnostico.IIdpacienteNavigation = paciente;
            diagnostico.IDiasIncapacidad = Convert.ToInt32((diagnostico.DtFechaFin.Date - ((DateTime)diagnostico.DtFechaEmisionIncapacidad).Date).TotalDays);
            diagnostico.IDiasIncapacidad = (diagnostico.IDiasIncapacidad == 0) ? 1 : diagnostico.IDiasIncapacidad;
            diagnostico.NumeroIncapacidadIpstranscripcion = AIModel.NumeroIncapacidad;
            diagnostico.TCodigoCorto = GetCodigoIncapacidad(paciente);

            var model = _mapper.Map<DiagnosticoIncapacidadModel>(diagnostico);

            if (paciente != null)
            {
                var pacienteModel = _mapper.Map<PacienteModel>(paciente);
                AIModel.Paciente = pacienteModel;
            }

            AIModel.Diagnostico = model;
            return AIModel;
        }

        private static string GenerateRndString(int size)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString().ToUpper(CultureInfo.InvariantCulture);
        }

        private string GetCodigoIncapacidad(TblPacientes paciente)
        {
            //TODO Consumes micro-service
            string shortCode = GenerateRndString(4);
            StringBuilder builder = new StringBuilder();
            builder.Append(paciente.IIdepsNavigation.TCodigoExterno)
                .Append("-").Append(shortCode)
                .Append("-").Append(paciente.TNumeroDocumento)
                ;

            return builder.ToString();
        }

        private TranscripcionAIModel PerformTextTranscriptionWithAzureCognitive(IList<string> text)
        {
            if (text == null || text.Count < 1)
            {
                const string Message = "Null Object";
                throw new ArgumentNullException(nameof(text), Message);
            }
            TranscripcionAIModel model = new TranscripcionAIModel();

            //TODO Cuando el modelo de IA se perfeccione aqui se ingresa
            //var entities = await _textAnalytics.ExtractEntitiesAsync(string.Join(Environment.NewLine, text.ToArray())).ConfigureAwait(false);

            model = PerformTextTranscriptionByExpertSystem(text);

            return model;

        }

        private async Task<TranscripcionAIModel> FillInDiagnostico(TranscripcionAIModel model)
        {
            if (model == null)
            {
                const string Message = "Invalid Object / Null";
                throw new ArgumentNullException(nameof(model), Message);
            }

            if (string.IsNullOrEmpty(model.IdCie10))
            {
                const string Message = "CIE-10 no valido / null";
                throw new NullReferenceException(Message);
            }

            //if (string.IsNullOrEmpty(model.RegistroMedico))
            //{
            //    throw new NullReferenceException("Registro Medico no valido / null");
            //}

            if (model.FechaInicial == null)
            {
                const string Message = "Fecha inicial no valida / null";
                throw new NullReferenceException(Message);
            }

            if (model.FechaFinal == null)
            {
                const string Message = "Fecha Final no valida/ null";
                throw new NullReferenceException(Message);
            }

            if (string.IsNullOrEmpty(model.CentroAtencion))
            {
                //throw new NullReferenceException("Centro de Atencion no Identificado / null");
            }

            TblCie10 cie10 = await _cie10Service.GetCie10BytCie10(model.IdCie10);


            var diagnostico = model.Diagnostico;

            var cie10Model = _mapper.Map<CIE10Model>(cie10);

            //Cie10
            var lCie10 = new List<CIE10Model>();
            lCie10.Add(cie10Model);
            diagnostico.Cie10 = lCie10;

            //Of Course
            diagnostico.EsTranscripcion = true;
            //
            if (!diagnostico.BProrroga)
            {
                diagnostico.IDiasAcumuladosPorroga = 0;
            }


            return model;
        }

        private TranscripcionAIModel PerformTextTranscriptionByExpertSystem(IList<string> ocrText)
        {
            string NumeroIncapacidad = string.Empty;
            string RegistroMedico = string.Empty;
            string fecha_inicial = string.Empty;
            string fecha_final = string.Empty;
            string centroAtencion = string.Empty;
            string claseIncapacidad = string.Empty;
            string Cie10Id = string.Empty;
            string nombreyRegistroMedico = string.Empty;
            var TipoIdentificacionPaciente = string.Empty;
            var NumeroDocumentoPaciente = string.Empty;
            //------------------------------
            var diagnosticoMedico = string.Empty;
            var nombrePaciente = string.Empty;
            var generoPaciente = string.Empty;
            var edadPaciente = string.Empty;
            var numeroIdentificacionEps = string.Empty;
            var IpsTipoIdentificacion = string.Empty;
            var ipsNumeroIdentificacion = string.Empty;
            var ipsNombre = string.Empty;
            var ipsCodigoExterno = string.Empty;
            var tipoIdentificacionMedico = string.Empty;
            var nombreEps = string.Empty;
            var diagnosticoIncapacidad = string.Empty;
            var centroAtencionFull = string.Empty;

            TranscripcionAIModel model = new TranscripcionAIModel();
            IncapacidadClassification classificationId = GetIncapacidadClassificationId(ocrText);
            NumeroDocumentoPaciente = GetPacientDocumentNumber(ocrText, classificationId);
            NumeroIncapacidad = GetDocumentNumber(ocrText, classificationId);
            centroAtencionFull = GetFullMedicalCenter(ocrText, classificationId);
            centroAtencion = GetMedicalCenter(ocrText, classificationId);
            nombreEps = GetNombreEps(ocrText, classificationId);
            model.NumeroHabilitacionEPS = GetCodigoHabilitacion(ocrText, classificationId);
            nombrePaciente = GetNombrePaciente(ocrText, classificationId);
            nombreyRegistroMedico = GetDoctorNameAndRM(ocrText, classificationId);
            generoPaciente = GetGeneroPaciente(ocrText, classificationId);
            Cie10Id = GetCie10(ocrText, classificationId);
            claseIncapacidad = GetClaseIncapacidad(ocrText, classificationId);
            diagnosticoMedico = GetDiagnosticoCie10(ocrText, classificationId);
            model.TipoOrigen = GetTipoOrigen(ocrText, classificationId);
            model.TipoDocumentoPaciente = GetTipoDocumentoPaciente(ocrText, classificationId);
            edadPaciente = GetEdadPaciente(ocrText, classificationId);
            diagnosticoIncapacidad = GetDiagnosticoIncapacidad(ocrText, classificationId);
            //Provisional
            model.FechaNacimientoText = GetBirthDateFromText(ocrText, classificationId);
            IDictionary<string, DateTime> lDates = GetDatesFromText(ocrText, classificationId);
            model.FechaDocumento = GetFechaDocumento(ocrText, classificationId);
            ClasificacionIncapacidad clasificacionIncapacidad = GetClasificacionIncapacidad(ocrText, classificationId);
            var rm = string.Empty;

            var registroMedico = nombreyRegistroMedico.Split(":");
            if (registroMedico.Length > 1)
            {
                model.RegistroMedico = registroMedico[0];
            }
            model.GeneroPaciente = generoPaciente;
            model.IpsNombre = centroAtencion;
            model.NombrePaciente = nombrePaciente;
            model.NombreMedico = registroMedico[1];
            model.NumeroIncapacidad = NumeroIncapacidad;
            model.EspecialidadMedico = registroMedico[2];
            model.FechaInicial = lDates["fecha_inicial"];
            try
            {
                model.FechaFinal = lDates["fecha_final"];
            }
            catch (Exception)
            {

                //throw;
            }
            model.ClaseIncapacidadText = claseIncapacidad;
            if (lDates.ContainsKey("fecha_nacimiento"))
            {
                model.fechaNacimiento = lDates["fecha_nacimiento"];
            }

            model.DescripcionCie10 = diagnosticoMedico;
            model.DiasIncapacidad = (short)(model.FechaFinal.Date - model.FechaInicial.Date).TotalDays;
            model.DiasIncapacidad = (short)((model.DiasIncapacidad == 0) ? 1 : model.DiasIncapacidad);
            model.DiagnosticoMedico = diagnosticoIncapacidad;
            DateTime? fechaCreacion = null;
            if (lDates.ContainsKey("fecha_creacion"))
            {
                fechaCreacion = lDates["fecha_creacion"];
            }
            model.FechaCreacion = fechaCreacion != null ? (DateTime)fechaCreacion : DateTime.Now;
            model.CentroAtencion = centroAtencion;
            model.CentroAtencionFull = centroAtencionFull;
            model.ClaseIncapacidad = clasificacionIncapacidad;
            model.IdCie10 = Cie10Id;
            model.NumeroDocumentoPaciente = NumeroDocumentoPaciente;
            model.IpsNombre = centroAtencion;
            model.NombreEps = nombreEps;
            model.EdadPaciente = edadPaciente;

            return model;
        }

        private static string GetClaseIncapacidad(IList<string> ocrText, IncapacidadClassification classificationId)
        {
            string claseIncapacidad = string.Empty;
            foreach (string sentence in ocrText)
            {
                #region CRUZ_ROJA
                if (classificationId.Equals(IncapacidadClassification.CRUZ_ROJA)
                    || classificationId.Equals(IncapacidadClassification.ANY))
                {
                    if (sentence.Contains("clase", StringComparison.InvariantCultureIgnoreCase)
                        && sentence.Contains("incapa", StringComparison.InvariantCultureIgnoreCase))
                    {
                        var tclasiff = sentence.Split(":")[1].Trim();
                        if (tclasiff.Contains("pror", StringComparison.OrdinalIgnoreCase))
                        {
                            claseIncapacidad = tclasiff;
                            break;
                        }
                        if (tclasiff.Contains("inic", StringComparison.OrdinalIgnoreCase))
                        {
                            claseIncapacidad = tclasiff;
                            break;
                        }

                    }
                }
                #endregion
                #region MEDIMAS
                if (classificationId.Equals(IncapacidadClassification.MEDIMAS)
                    || classificationId.Equals(IncapacidadClassification.ANY))
                {
                    if (sentence.Contains("PRORROGA", StringComparison.OrdinalIgnoreCase))
                    {
                        claseIncapacidad = sentence;
                    }
                }
                #endregion
            }

            return claseIncapacidad;
        }

        private static string GetFullMedicalCenter(IList<string> ocrText, IncapacidadClassification classificationId)
        {
            string centroAtencion = string.Empty;
            for (int i = 0; i < ocrText.Count; i++)
            {
                string sentence = ocrText.ElementAt(i);
                #region CRUZ_ROJA
                if (classificationId.Equals(IncapacidadClassification.CRUZ_ROJA) || classificationId.Equals(IncapacidadClassification.ANY))
                {
                    Match centroAtencionm = Regex.Match(sentence, centroAtencionrx, RegexOptions.IgnoreCase);
                    if (centroAtencionm.Success)
                    {
                        centroAtencion = sentence;
                        centroAtencion = ocrText.ElementAt(0) + " " + centroAtencion;
                        break;
                    }
                    if (sentence.Contains("Centro", StringComparison.InvariantCultureIgnoreCase)
                        && sentence.Contains("ATENCION", StringComparison.InvariantCultureIgnoreCase))
                    {
                        centroAtencion = sentence.Split(":")[1].Trim();
                        centroAtencion = ocrText.ElementAt(0) + " " + centroAtencion;
                        break;
                    }
                }
                #endregion

                #region MEDIMAS
                if (classificationId.Equals(IncapacidadClassification.MEDIMAS) || classificationId.Equals(IncapacidadClassification.ANY))
                {
                    Match centroAtencionmedimas = Regex.Match(sentence, centroAtencionMedimasrx, RegexOptions.IgnoreCase);
                    if (centroAtencionmedimas.Success)
                    {
                        if (sentence.Contains("OFICINA", StringComparison.InvariantCultureIgnoreCase)
                        && sentence.Contains("IPS", StringComparison.InvariantCultureIgnoreCase)
                        )
                        {
                            centroAtencion = sentence.Split(":")[1].Trim();
                            break;
                        }
                    }

                }
                #endregion
            }
            return centroAtencion;
        }

        private static string GetFechaDocumento(IList<string> ocrText, IncapacidadClassification classificationId)
        {
            string fecha_documento = string.Empty;
            string[] splitters = new string[3] { " ", "\\", "/" };
            IDictionary<string, DateTime> ldate = new Dictionary<string, DateTime>();

            for (int i = 0; i < ocrText.Count; i++)
            {
                var sentenceTrim = ocrText.ElementAt(i).Trim();
                #region CRUZ_ROJA
                if (classificationId.Equals(IncapacidadClassification.CRUZ_ROJA) || classificationId.Equals(IncapacidadClassification.ANY))
                {
                    if (sentenceTrim.Contains("Fecha", StringComparison.OrdinalIgnoreCase)
                        && sentenceTrim.Contains("Documento", StringComparison.OrdinalIgnoreCase))
                    {
                        var sp = sentenceTrim.Split(":", StringSplitOptions.RemoveEmptyEntries);
                        fecha_documento = sp[1].Trim().Replace(".", " ", StringComparison.InvariantCultureIgnoreCase);
                        break;
                    }
                }
                #endregion CRUZ_ROJA

                #region MEDIMAS
                if (classificationId.Equals(IncapacidadClassification.MEDIMAS) || classificationId.Equals(IncapacidadClassification.ANY))
                {
                }
                #endregion MEDIMAS
            }
            return fecha_documento;
        }

        private static string GetBirthDateFromText(IList<string> ocrText, IncapacidadClassification classificationId)
        {
            string fecha_nacimiento = string.Empty;
            string[] splitters = new string[3] { " ", "\\", "/" };
            IDictionary<string, DateTime> ldate = new Dictionary<string, DateTime>();

            for (int i = 0; i < ocrText.Count; i++)
            {
                var sentenceTrim = ocrText.ElementAt(i).Trim();
                #region CRUZ_ROJA
                if (classificationId.Equals(IncapacidadClassification.CRUZ_ROJA) || classificationId.Equals(IncapacidadClassification.ANY))
                {
                    if (sentenceTrim.Contains("Nacimiento", StringComparison.OrdinalIgnoreCase))
                    {
                        var sp = sentenceTrim.Split(":", StringSplitOptions.RemoveEmptyEntries);
                        var splits = sp[sp.Length - 1].Trim().Replace(".", "/", StringComparison.InvariantCultureIgnoreCase);
                        fecha_nacimiento = splits;
                        break;
                    }
                }
                #endregion CRUZ_ROJA

                #region MEDIMAS
                if (classificationId.Equals(IncapacidadClassification.MEDIMAS) || classificationId.Equals(IncapacidadClassification.ANY))
                {
                }
                #endregion MEDIMAS
            }
            return fecha_nacimiento;
        }

        private static string GetTipoDocumentoPaciente(IList<string> ocrText, IncapacidadClassification classificationId)
        {
            string tipodocumento = string.Empty;
            for (int i = 0; i < ocrText.Count; i++)
            {
                var sentenceTrim = ocrText.ElementAt(i).Trim();
                #region CRUZ_ROJA
                if (classificationId.Equals(IncapacidadClassification.CRUZ_ROJA) || classificationId.Equals(IncapacidadClassification.ANY))
                {
                    if (sentenceTrim.Contains("Cedula", StringComparison.OrdinalIgnoreCase))
                    {
                        var sp = sentenceTrim.Split(":")[0]?.Trim();
                        tipodocumento = sp;
                    }
                    if (sentenceTrim.Contains("tipo", StringComparison.OrdinalIgnoreCase)
                        && sentenceTrim.Contains("documen", StringComparison.OrdinalIgnoreCase)
                        && !string.IsNullOrWhiteSpace(sentenceTrim.Split(":")[1]))
                    {
                        var sp = sentenceTrim.Split(":")[1]?.Trim();
                        var or = sp.Split(" ");
                        tipodocumento = string.Join(" ", or, 0, 2);
                        break;
                    }
                }
                #endregion CRUZ_ROJA
            }
            return tipodocumento;
        }

        private static string GetTipoOrigen(IList<string> ocrText, IncapacidadClassification classificationId)
        {
            string origen = string.Empty;
            for (int i = 0; i < ocrText.Count; i++)
            {
                var sentenceTrim = ocrText.ElementAt(i).Trim();
                #region CRUZ_ROJA
                if (classificationId.Equals(IncapacidadClassification.CRUZ_ROJA) || classificationId.Equals(IncapacidadClassification.ANY))
                {
                    if (sentenceTrim.Contains("causa", StringComparison.OrdinalIgnoreCase)
                        && sentenceTrim.Contains("extern", StringComparison.OrdinalIgnoreCase))
                    {
                        origen = sentenceTrim.Split(":")[1]?.Trim();
                        break;
                    }
                }
                #endregion CRUZ_ROJA
            }
            return origen;
        }

        private string GetEdadPaciente(IList<string> ocrText, IncapacidadClassification classificationId)
        {
            string edad = string.Empty;
            for (int i = 0; i < ocrText.Count; i++)
            {
                var sentenceTrim = ocrText.ElementAt(i).Trim();
                #region CRUZ_ROJA
                if (classificationId.Equals(IncapacidadClassification.CRUZ_ROJA) || classificationId.Equals(IncapacidadClassification.ANY))
                {
                    if (sentenceTrim.Contains("edad", StringComparison.OrdinalIgnoreCase) && !sentenceTrim.Contains("Tipo", StringComparison.Ordinal))
                    {
                        var a = sentenceTrim.Split(":").Length - 1;
                        var sp = sentenceTrim.Split(":", StringSplitOptions.RemoveEmptyEntries)[a];
                        var nsp = sp.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        var splits = string.Join(" ", nsp, 0, nsp.Length - 2);

                        edad = splits;
                        break;
                    }
                    else if (sentenceTrim.Contains("edad", StringComparison.OrdinalIgnoreCase) && sentenceTrim.Contains("Tipo", StringComparison.Ordinal))
                    {
                        var sp = sentenceTrim.Split(":", StringSplitOptions.RemoveEmptyEntries)[3];
                        edad = sp.Split(" ")[1];
                        break;
                    }
                }
                #endregion CRUZ_ROJA
            }
            return edad;
        }

        private static string GetGeneroPaciente(IList<string> ocrText, IncapacidadClassification classificationId)
        {
            string genero = string.Empty;

            for (int i = 0; i < ocrText.Count; i++)
            {
                string sentence = ocrText.ElementAt(i).Trim();
                #region CRUZ_ROJA
                if (classificationId.Equals(IncapacidadClassification.CRUZ_ROJA) || classificationId.Equals(IncapacidadClassification.ANY))
                {
                    //Match centroAtencionm = Regex.Match(sentence, PatternNombrePaciente, RegexOptions.IgnoreCase);
                    if (sentence.Contains("Sexo", StringComparison.OrdinalIgnoreCase))
                    {
                        var sp = sentence.Split(" ");
                        genero = sp[sp.Length - 1];
                        break;
                    }
                }
                #endregion
            }
            return genero;
        }

        private static string GetDiagnosticoIncapacidad(IList<string> ocrText, IncapacidadClassification classificationId)
        {
            string diagnosticoIncapacidad = string.Empty;

            for (int i = 0; i < ocrText.Count; i++)
            {
                string sentence = ocrText.ElementAt(i).Trim();
                #region CRUZ_ROJA
                if (classificationId.Equals(IncapacidadClassification.CRUZ_ROJA) || classificationId.Equals(IncapacidadClassification.ANY))
                {
                    //Match centroAtencionm = Regex.Match(sentence, PatternNombrePaciente, RegexOptions.IgnoreCase);
                    if (sentence.Contains("Fecha", StringComparison.OrdinalIgnoreCase)
                        && sentence.Contains("Final", StringComparison.OrdinalIgnoreCase))
                    {
                        diagnosticoIncapacidad = ocrText.ElementAt(i + 1).Trim();
                        break;
                    }
                }
                #endregion
            }
            return diagnosticoIncapacidad;
        }


        private static string GetCodigoHabilitacion(IList<string> ocrText, IncapacidadClassification clasificatorId)
        {
            string nombreEps = string.Empty;

            for (int i = 0; i < ocrText.Count; i++)
            {
                string sentence = ocrText.ElementAt(i);
                #region CRUZ_ROJA
                if (clasificatorId.Equals(IncapacidadClassification.CRUZ_ROJA) || clasificatorId.Equals(IncapacidadClassification.ANY))
                {
                    //Match centroAtencionm = Regex.Match(sentence, PatternNombrePaciente, RegexOptions.IgnoreCase);
                    if (sentence.Contains("entidad", StringComparison.InvariantCultureIgnoreCase))
                    {
                        sentence = ocrText.ElementAt(i + 1);
                        var sp = sentence.Split(" ");
                        nombreEps = $"{sp[0]}";
                        break;
                    }
                }
                #endregion
            }
            return nombreEps;
        }



        private static string GetNombreEps(IList<string> ocrText, IncapacidadClassification clasificatorId)
        {
            string nombreEps = string.Empty;

            for (int i = 0; i < ocrText.Count; i++)
            {
                string sentence = ocrText.ElementAt(i);
                #region CRUZ_ROJA
                if (clasificatorId.Equals(IncapacidadClassification.CRUZ_ROJA) || clasificatorId.Equals(IncapacidadClassification.ANY))
                {
                    //Match centroAtencionm = Regex.Match(sentence, PatternNombrePaciente, RegexOptions.IgnoreCase);
                    if (sentence.Contains("entidad", StringComparison.InvariantCultureIgnoreCase))
                    {
                        sentence = ocrText.ElementAt(i + 1);
                        var sp = sentence.Split(" ");
                        if (sentence.Split(" ").Length == 1)
                            nombreEps = sp[0];
                        else
                            nombreEps = $"{sp[1]} {sp[2]}";
                        break;
                    }
                }
                #endregion
            }
            return nombreEps;
        }

        private string GetNombrePaciente(IList<string> ocrText, IncapacidadClassification clasificatorId)
        {
            string nombrePaciente = string.Empty;
            foreach (string sentence in ocrText)
            {
                #region CRUZ_ROJA
                if (clasificatorId.Equals(IncapacidadClassification.CRUZ_ROJA) || clasificatorId.Equals(IncapacidadClassification.ANY))
                {
                    Match centroAtencionm = Regex.Match(sentence, PatternNombrePaciente, RegexOptions.IgnoreCase);
                    if (centroAtencionm.Success && sentence.Contains("paciente", StringComparison.InvariantCultureIgnoreCase))
                    {
                        nombrePaciente = sentence.Split(":")[1].Trim();
                        break;
                    }
                }
                #endregion
            }
            return nombrePaciente;
        }

        private static string GetPacientDocumentNumber(IList<string> ocrText, IncapacidadClassification classificationId)
        {
            string pacientNumber = string.Empty;
            foreach (string sentence in ocrText)
            {
                #region CRUZ_ROJA
                if (classificationId.Equals(IncapacidadClassification.CRUZ_ROJA) || classificationId.Equals(IncapacidadClassification.ANY))
                {
                    Match cedulaMatcher = Regex.Match(sentence, patternPacienteCedula, RegexOptions.IgnoreCase);
                    if (cedulaMatcher.Success)
                    {
                        var i = sentence.Split(":").Length - 1;
                        pacientNumber = sentence.Split(":")[i].Trim();
                        pacientNumber = pacientNumber.Split(" ")[0];
                        break;
                    }
                }
                #endregion
            }
            return pacientNumber;
        }

        private static ClasificacionIncapacidad GetClasificacionIncapacidad(IList<string> ocrText, IncapacidadClassification classificationId)
        {
            ClasificacionIncapacidad clasificacion = ClasificacionIncapacidad.INICIAL;
            foreach (string sentence in ocrText)
            {
                #region CRUZ_ROJA
                if (classificationId.Equals(IncapacidadClassification.CRUZ_ROJA)
                    || classificationId.Equals(IncapacidadClassification.ANY))
                {
                    if (sentence.Contains("clase", StringComparison.InvariantCultureIgnoreCase)
                        && sentence.Contains("incapa", StringComparison.InvariantCultureIgnoreCase))
                    {
                        var tclasiff = sentence.Split(":")[1].Trim();
                        if (tclasiff.Contains("pror", StringComparison.OrdinalIgnoreCase))
                        {
                            clasificacion = ClasificacionIncapacidad.PRORROGA;
                        }
                    }
                }
                #endregion
                #region MEDIMAS
                if (classificationId.Equals(IncapacidadClassification.MEDIMAS)
                    || classificationId.Equals(IncapacidadClassification.ANY))
                {
                    if (sentence.Contains("PRORROGA", StringComparison.OrdinalIgnoreCase))
                    {
                        clasificacion = ClasificacionIncapacidad.PRORROGA;
                    }
                }
                #endregion

            }

            return clasificacion;
        }

        private static IncapacidadClassification GetIncapacidadClassificationId(IList<string> ocrText)
        {
            IncapacidadClassification Classification = IncapacidadClassification.ANY;
            foreach (string sentence in ocrText)
            {
                Match cruzRoja = Regex.Match(sentence, cruzRojaPattern, RegexOptions.IgnoreCase);
                if (cruzRoja.Success)
                {
                    Classification = IncapacidadClassification.CRUZ_ROJA;
                    break;
                }

                Match medimas = Regex.Match(sentence, medimaseEPSPattern, RegexOptions.IgnoreCase);
                if (medimas.Success)
                {
                    Classification = IncapacidadClassification.MEDIMAS;
                    break;
                }
            }

            return Classification;
        }

        private string GetPacientId(IList<string> ocrText, IncapacidadClassification clasificatorId)
        {
            throw new NotImplementedException();
        }

        private static string GetDocumentNumber(IList<string> ocrText, IncapacidadClassification clasificatorId)
        {
            string NumeroIncapacidad = string.Empty;
            #region CRUZ_ROJA
            if (clasificatorId.Equals(IncapacidadClassification.CRUZ_ROJA) || clasificatorId.Equals(IncapacidadClassification.ANY))
            {
                foreach (string sentence in ocrText)
                {
                    Match m = Regex.Match(sentence, patternNumeroIncapacidad, RegexOptions.IgnoreCase);
                    if (m.Success)
                    {
                        if (sentence.Any(char.IsDigit))
                        {
                            NumeroIncapacidad = sentence;
                        }
                    }
                }
            }
            #endregion

            #region MEDIMAS
            if (clasificatorId.Equals(IncapacidadClassification.MEDIMAS) || clasificatorId.Equals(IncapacidadClassification.ANY))
            {
                foreach (string sentence in ocrText)
                {
                    Match m = Regex.Match(sentence, patternNumeroIncapacidad, RegexOptions.IgnoreCase);
                    if (m.Success)
                    {
                        if (sentence.Any(char.IsDigit))
                        {

                            NumeroIncapacidad = sentence.Split(":")[1].Trim();
                        }
                    }
                }
            }
            #endregion


            return NumeroIncapacidad;
        }

        private static string GetMedicalCenter(IList<string> ocrText, IncapacidadClassification clasificatorId)
        {
            string centroAtencion = string.Empty;
            for (int i = 0; i < ocrText.Count; i++)
            {
                string sentence = ocrText.ElementAt(i);
                #region CRUZ_ROJA
                if (clasificatorId.Equals(IncapacidadClassification.CRUZ_ROJA) || clasificatorId.Equals(IncapacidadClassification.ANY))
                {
                    Match centroAtencionm = Regex.Match(sentence, centroAtencionrx, RegexOptions.IgnoreCase);
                    if (centroAtencionm.Success)
                    {
                        centroAtencion = sentence;
                        break;
                    }
                    if (sentence.Contains("Centro", StringComparison.InvariantCultureIgnoreCase)
                        && sentence.Contains("ATENCION", StringComparison.InvariantCultureIgnoreCase))
                    {
                        centroAtencion = sentence.Split(":")[1].Trim();
                        break;
                    }
                }
                #endregion

                #region MEDIMAS
                if (clasificatorId.Equals(IncapacidadClassification.MEDIMAS) || clasificatorId.Equals(IncapacidadClassification.ANY))
                {
                    Match centroAtencionmedimas = Regex.Match(sentence, centroAtencionMedimasrx, RegexOptions.IgnoreCase);
                    if (centroAtencionmedimas.Success)
                    {
                        if (sentence.Contains("OFICINA", StringComparison.InvariantCultureIgnoreCase)
                        && sentence.Contains("IPS", StringComparison.InvariantCultureIgnoreCase)
                        )
                        {
                            centroAtencion = sentence.Split(":")[1].Trim();
                            break;
                        }
                    }

                }
                #endregion

            }
            return centroAtencion;
        }

        private static string GetDoctorNameAndRM(IList<string> ocrText, IncapacidadClassification clasificatorId)
        {
            string registroMedico = string.Empty;
            string nombreMedico = string.Empty;
            string especialidad = string.Empty;
            for (int i = 0; i < ocrText.Count; i++)
            {
                string sentence = ocrText.ElementAt(i);
                #region CRUZ_ROJA
                if (clasificatorId.Equals(IncapacidadClassification.CRUZ_ROJA) || clasificatorId.Equals(IncapacidadClassification.ANY))
                {
                    Match rmedico = Regex.Match(sentence, patternRM, RegexOptions.IgnoreCase);
                    if (rmedico.Success)
                    {
                        if (sentence.Any(char.IsDigit))
                        {
                            registroMedico = sentence.Split(" ")[1];
                            especialidad = ocrText.ElementAt(i - 1)?.Trim();
                            break;
                        }
                    }

                }
                #endregion
                #region MEDIMAS
                if (clasificatorId.Equals(IncapacidadClassification.MEDIMAS) || clasificatorId.Equals(IncapacidadClassification.ANY))
                {
                    if (sentence.Contains("Usuario", StringComparison.OrdinalIgnoreCase) &&
                        sentence.Contains("expide", StringComparison.OrdinalIgnoreCase))
                    {
                        nombreMedico = sentence.Split(":")[1].Trim();
                    }
                }
                #endregion
            }


            for (int i = 0; i < ocrText.Count; i++)
            {
                string sentence = ocrText.ElementAt(i);

                #region CRUZ_ROJA
                if (clasificatorId.Equals(IncapacidadClassification.CRUZ_ROJA) || clasificatorId.Equals(IncapacidadClassification.ANY))
                {
                    Match rxmedico = Regex.Match(sentence, medicoRx, RegexOptions.IgnoreCase);
                    if (rxmedico.Success)
                    {
                        if (!sentence.Any(char.IsDigit))
                        {
                            var sp = ocrText.ElementAt(i + 1).Split(" ");
                            nombreMedico = string.Join(" ", sp, 1, sp.Length - 1);
                            break;
                        }
                    }
                }
                #endregion

                if (!string.IsNullOrEmpty(registroMedico)
                   && !string.IsNullOrEmpty(nombreMedico))
                {
                    break;
                }
            }


            if (string.IsNullOrEmpty(registroMedico)
                      && string.IsNullOrEmpty(nombreMedico))
            {
                return null;
            }

            return $"{registroMedico}:{nombreMedico}:{especialidad}";

        }

        private IDictionary<string, DateTime> GetDatesFromText(IList<string> ocrText, IncapacidadClassification clasificatorId)
        {
            string fecha_inicial = string.Empty;
            string fecha_final = string.Empty;
            string[] splitters = new string[3] { " ", "\\", "/" };
            IDictionary<string, DateTime> ldate = new Dictionary<string, DateTime>();

            for (int i = 0; i < ocrText.Count; i++)
            {
                var sentenceTrim = ocrText.ElementAt(i).Trim();
                #region CRUZ_ROJA
                if (clasificatorId.Equals(IncapacidadClassification.CRUZ_ROJA) || clasificatorId.Equals(IncapacidadClassification.ANY))
                {
                    if (sentenceTrim.Contains("Fecha", StringComparison.OrdinalIgnoreCase)
                        && sentenceTrim.Contains("Inicial", StringComparison.OrdinalIgnoreCase))
                    {
                        var sp = sentenceTrim.Replace(":", "", StringComparison.Ordinal).Split("Fecha Inicial", StringSplitOptions.RemoveEmptyEntries);
                        var a = sp.Length - 1;
                        var splits = sp[a].Trim().Split(splitters, StringSplitOptions.RemoveEmptyEntries);
                        //var j = splits[1] == "Fecha" ? 1 : 3;
                        months.TryGetValue(splits[1].ToUpperInvariant(), out int monthNumber);

                        if (monthNumber == 0)
                        {
                            const string Message = "Fecha Inicial no valida.";
                            throw new Exception(Message);
                        }
                        var b = splits[1] == "Fecha" ? 1 : 2;
                        var c = splits[1] == "Fecha" ? 2 : 4;
                        var date = Convert.ToDateTime($"{monthNumber}-{splits[0]}-{splits[2]}", CultureInfo.InvariantCulture);
                        ldate.Add("fecha_inicial", date);
                    }

                    if (sentenceTrim.Contains("Fecha", StringComparison.OrdinalIgnoreCase)
                        && sentenceTrim.Contains("Final", StringComparison.OrdinalIgnoreCase))
                    {
                        var sp = sentenceTrim.Split(":", StringSplitOptions.RemoveEmptyEntries);
                        var a = sp.Length - 1;
                        var splits = sp[a].Trim().Split(splitters, StringSplitOptions.RemoveEmptyEntries);

                        var b = splits[1] == "Fecha" ? 1 : 2;
                        var c = splits[1] == "Fecha" ? 2 : 4;

                        months.TryGetValue(splits[1], out int monthNumber);
                        if (monthNumber == 0)
                        {
                            throw new Exception("Fecha Inicial no valida.");
                        }
                        var date = Convert.ToDateTime($"{monthNumber}-{splits[0]}-{splits[2]}", CultureInfo.InvariantCulture);
                        ldate.Add("fecha_final", date);

                    }
                    if (sentenceTrim.Contains("Nacimiento", StringComparison.OrdinalIgnoreCase))
                    {
                        var sp = sentenceTrim.Split(":", StringSplitOptions.RemoveEmptyEntries);
                        var splits = sp[sp.Length - 1].Trim().Replace(".", "/", StringComparison.Ordinal);

                        //var date = Convert.ToDateTime(splits, CultureInfo.InvariantCulture);
                        var date = DateTime.ParseExact(splits, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        ldate.Add("fecha_nacimiento", date);
                    }



                }
                #endregion CRUZ_ROJA

                #region MEDIMAS
                if (clasificatorId.Equals(IncapacidadClassification.MEDIMAS) || clasificatorId.Equals(IncapacidadClassification.ANY))
                {


                    if (sentenceTrim.Contains("Fecha", StringComparison.OrdinalIgnoreCase)
                        && sentenceTrim.Contains("Inicial", StringComparison.OrdinalIgnoreCase))
                    {
                        var fechainicial = ocrText.ElementAt(i + 1).Trim();
                        Match rxfecha = Regex.Match(ocrText.ElementAt(i + 1).Trim(), matchMedimasFecha, RegexOptions.IgnoreCase);
                        if (rxfecha.Success)
                        {
                            var date = Convert.ToDateTime($"{fechainicial}", CultureInfo.InvariantCulture);
                            ldate.Add("fecha_inicial", date);
                        }
                    }

                    if (sentenceTrim.Contains("Fecha", StringComparison.OrdinalIgnoreCase)
                        && sentenceTrim.Contains("Final", StringComparison.OrdinalIgnoreCase))
                    {
                        var fechafinal = ocrText.ElementAt(i + 1).Trim();
                        Match rxfecha = Regex.Match(ocrText.ElementAt(i + 1).Trim(), matchMedimasFecha, RegexOptions.IgnoreCase);
                        if (rxfecha.Success)
                        {
                            var date = Convert.ToDateTime($"{fechafinal}", CultureInfo.InvariantCulture);
                            ldate.Add("fecha_final", date);
                        }
                    }

                    if (sentenceTrim.Contains("Fecha", StringComparison.OrdinalIgnoreCase)
                       && sentenceTrim.Contains("EXPEDICION", StringComparison.OrdinalIgnoreCase))
                    {
                        var fechafinal = ocrText.ElementAt(i + 1).Trim();
                        Match rxfecha = Regex.Match(ocrText.ElementAt(i + 1).Trim(), matchMedimasFecha, RegexOptions.IgnoreCase);
                        if (rxfecha.Success)
                        {
                            var date = Convert.ToDateTime($"{fechafinal}", CultureInfo.InvariantCulture);
                            ldate.Add("fecha_creacion", date);
                        }
                    }

                }
                #endregion MEDIMAS


            }

            return ldate;

        }

        private string GetCie10(IList<string> ocrText, IncapacidadClassification clasificatorId)
        {
            if (ocrText == null || ocrText.Count < 1)
            {
                const string Message = "Invalid Argument";
                throw new ArgumentNullException(nameof(ocrText), Message);
            }

            string idCie10 = string.Empty; ;

            foreach (string sentence in ocrText)
            {
                #region CRUZ_ROJA
                if (clasificatorId.Equals(IncapacidadClassification.CRUZ_ROJA) || clasificatorId.Equals(IncapacidadClassification.ANY))
                {
                    Match rCie10 = Regex.Match(sentence, patternCie10, RegexOptions.IgnoreCase);
                    if (rCie10.Success)
                    {
                        if (sentence.Length.Equals(4))
                        {
                            idCie10 = sentence;
                        }
                        else
                        {
                            string[] sentenceSp = sentence.Split(_separators, StringSplitOptions.RemoveEmptyEntries);
                            if (sentenceSp != null && sentenceSp.Length > 1)
                            {
                                foreach (string sub in sentenceSp)
                                {
                                    Match Cie10mt = Regex.Match(sub, patternCie10, RegexOptions.IgnoreCase);
                                    if (Cie10mt.Success)
                                    {
                                        idCie10 = sub;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                #endregion

                #region MEDIMAS
                if (clasificatorId.Equals(IncapacidadClassification.MEDIMAS) || clasificatorId.Equals(IncapacidadClassification.ANY))
                {
                    Match rCie10 = Regex.Match(sentence, patternCie10, RegexOptions.IgnoreCase);
                    if (rCie10.Success)
                    {
                        if (sentence.Length.Equals(4))
                        {
                            idCie10 = sentence;
                        }
                    }
                }
                #endregion
            }
            return idCie10;
        }


        private string GetDiagnosticoCie10(IList<string> ocrText, IncapacidadClassification clasificatorId)
        {
            if (ocrText == null || ocrText.Count < 1)
            {
                const string Message = "Invalid Argument";
                throw new ArgumentNullException(nameof(ocrText), Message);
            }

            string diagnostico = string.Empty; ;

            for (int i = 0; i < ocrText.Count; i++)
            {
                string sentence = ocrText.ElementAt(i);
                #region CRUZ_ROJA
                if (clasificatorId.Equals(IncapacidadClassification.CRUZ_ROJA) || clasificatorId.Equals(IncapacidadClassification.ANY))
                {
                    Match rCie10 = Regex.Match(sentence, patternCie10, RegexOptions.IgnoreCase);
                    if (rCie10.Success)
                    {
                        if (sentence.Length.Equals(4))
                        {
                            diagnostico = ocrText.ElementAt(i + 1);
                            break;
                        }
                        else
                        {
                            string[] sentenceSp = sentence.Split(_separators, StringSplitOptions.RemoveEmptyEntries);
                            if (sentenceSp != null && sentenceSp.Length > 1)
                            {
                                foreach (string sub in sentenceSp)
                                {
                                    Match Cie10mt = Regex.Match(sub, patternCie10, RegexOptions.IgnoreCase);
                                    if (Cie10mt.Success)
                                    {
                                        diagnostico = ocrText.ElementAt(i + 1);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                #endregion

                #region MEDIMAS
                if (clasificatorId.Equals(IncapacidadClassification.MEDIMAS) || clasificatorId.Equals(IncapacidadClassification.ANY))
                {
                    Match rCie10 = Regex.Match(sentence, patternCie10, RegexOptions.IgnoreCase);
                    if (rCie10.Success)
                    {
                        if (sentence.Length.Equals(4))
                        {
                            diagnostico = ocrText.ElementAt(i + 1);
                            break;
                        }
                    }
                }
                #endregion
            }
            return diagnostico;
        }

        private OCRExtractionMethodModel GetTextFromPDF(byte[] bytes)
        {
            var sb = new StringBuilder();

            try
            {
                var reader = new PdfReader(bytes);
                var numberOfPages = reader.NumberOfPages;

                for (var currentPageIndex = 1; currentPageIndex <= numberOfPages; currentPageIndex++)
                {
                    sb.Append(PdfTextExtractor.GetTextFromPage(reader, currentPageIndex));
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            if (sb.ToString().Length == 0) { 
            
            }
            
            OCRExtractionMethodModel oCRExtractionMethodModel = new OCRExtractionMethodModel
            {
                Sentences = new List<string> { sb.ToString() }
            };
            return oCRExtractionMethodModel;
        }

        private OCRExtractionMethodModel ExtractImagesFromPDF(byte[] sourcepdf)
        {
            // NOTE:  This will only get the first image it finds per page.
            PdfReader pdf = new PdfReader(sourcepdf);
            RandomAccessFileOrArray raf = new RandomAccessFileOrArray(sourcepdf);

            try
            {
                for (int pageNumber = 1; pageNumber <= pdf.NumberOfPages; pageNumber++)
                {
                    PdfDictionary pg = pdf.GetPageN(pageNumber);
                    PdfDictionary res = (PdfDictionary)PdfReader.GetPdfObject(pg.Get(PdfName.RESOURCES));

                    PdfDictionary xobj = (PdfDictionary)PdfReader.GetPdfObject(res.Get(PdfName.XOBJECT));
                    if (xobj != null)
                    {
                        foreach (PdfName name in xobj.Keys)
                        {
                            PdfObject obj = xobj.Get(name);
                            if (obj.IsIndirect())
                            {
                                PdfDictionary tg = (PdfDictionary)PdfReader.GetPdfObject(obj);
                                PdfName type = (PdfName)PdfReader.GetPdfObject(tg.Get(PdfName.SUBTYPE));
                                if (PdfName.IMAGE.Equals(type))
                                {
                                    int XrefIndex = Convert.ToInt32(((PRIndirectReference)obj).Number.ToString(CultureInfo.InvariantCulture));
                                    PdfObject pdfObj = pdf.GetPdfObject(XrefIndex);
                                    PdfStream pdfStrem = (PdfStream)pdfObj;
                                    byte[] bytes = PdfReader.GetStreamBytesRaw((PRStream)pdfStrem);
                                    return GetOCRTextWithTesseract(bytes);
                                }
                            }
                        }
                    }
                }
            }

            catch
            {
                throw;
            }
            finally
            {
                pdf.Close();
                raf.Close();
            }
            return null;
        }

        public OCRExtractionMethodModel GetTextFromDoc(MemoryStream stream) {
            DocumentCore dc = null;
            stream.Position = 0;
            dc = DocumentCore.Load(stream, new DocxLoadOptions());
            OCRExtractionMethodModel oCRExtractionMethodModel = new OCRExtractionMethodModel
            {
                Sentences = new List<string> { dc.Content.ToString() }
            };
            return oCRExtractionMethodModel;
        }
    }
}

