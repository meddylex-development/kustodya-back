using System;
using System.Net.Http;
using System.Threading.Tasks;
using Kustodya.Medicos.Services;
using Kustodya.Medicos.Services.Input;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using System.Net;
using Microsoft.Extensions.Logging;
using System.Web;
using Kustodya.Medicos.Data;
using Kustodya.Medicos.Models;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;
using Kustodya.Medicos.Data.Medicos;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.IO;
using AutoMapper;

namespace Kustodya.Medicos.Controllers
{
    public class MedicosController
    {
        private readonly IMapper _mapper;
        public MedicosController(ILoggerFactory loggerFactory, IMapper mapper)
        {
            _logger = loggerFactory.CreateLogger(nameof(MedicosController));
            _mapper = mapper;
        }
        private readonly IServicioDeConsultaDeMedicos _servicio;
        private ILogger _logger;

        // # Opción 1 👌 Lista de medicos que cumplan con el query
        // GET /api/Medicos?documento=<123456>&tipo=<cedula>
        // Severa función❗ 🔥🔥🔥
        [FunctionName("GetMedicos")]
        public async Task<HttpResponseMessage> GetMedicos([HttpTrigger(AuthorizationLevel.Function, methods: "get", Route = "Medico")] HttpRequestMessage req, [DurableClient] IDurableClient cliente)
        {
            ExtraerDatosDeEntrada(req, out string documentoEntrada, out string tipoInput, out string primerNombre, out string primerApellido, out string CargueId, out bool exportar);

            var tipoConsulta = GetTipoConsulta(documentoEntrada, tipoInput, primerNombre, primerApellido, CargueId);

            switch (tipoConsulta)
            {
                case TipoConsulta.PorDocumento:
                    return await ConsultaPorDocumento(req, cliente, documentoEntrada, tipoInput);
                case TipoConsulta.PorNombres:
                    return await ConsultaPorNombre(req, cliente, primerNombre, primerApellido);
                default:
                    return new HttpResponseMessage(HttpStatusCode.BadRequest)
                            { Content = new StringContent("Datos Invalidos") };
            }

        }
        [FunctionName("GetMedicosCargue")]
        public async Task<IActionResult> GetMedicosCargue([HttpTrigger(AuthorizationLevel.Function, methods: "get", Route = "CargueMedicos")] HttpRequestMessage req, [DurableClient] IDurableClient cliente)
        {
            ExtraerDatosDeEntrada(req, out string documentoEntrada, out string tipoInput, out string primerNombre, out string primerApellido, out string CargueId, out bool exportar);

            var tipoConsulta = GetTipoConsulta(documentoEntrada, tipoInput, primerNombre, primerApellido, CargueId);

            switch (tipoConsulta)
            {
                case TipoConsulta.PorCargueId:
                    return await ConsultaPorCargueMasivoId(req, cliente, CargueId, exportar);
                default:
                    return new BadRequestObjectResult(SolicitudInvalida("Datos invalidos"));
            }

        }

        private async Task<HttpResponseMessage> ConsultaPorNombre(HttpRequestMessage req, IDurableClient cliente, string primerNombre, string primerApellido)
        {
            if (NombreYApelllidoInvalidoValido(primerNombre, primerApellido)) return SolicitudInvalida("Nombres o apellidos invalidos");

            var instanciaId = Guid.NewGuid().ToString();
            var medico = await cliente.StartNewAsync(
                nameof(_servicio.GetMedicosPorNombreAsync),
                instanciaId,
                (primerNombre, primerApellido, Guid.NewGuid()));

            _logger.LogInformation(
                    $"Solicitando consulta eReTHUS por nombre para: " +
                    $"{primerNombre} {primerApellido}"
                );

            return await cliente.WaitForCompletionOrCreateCheckStatusResponseAsync(req, instanciaId, new TimeSpan(0, 1, 0));
        }
        private async Task<IActionResult> ConsultaPorCargueMasivoId(HttpRequestMessage req, IDurableClient cliente, string CargueId, bool exportar)
        {
            var instanciaId = Guid.NewGuid().ToString();
            var instanciaexcelId = Guid.NewGuid().ToString();
            var medicos = await cliente.StartNewAsync(
                nameof(_servicio.GetMedicosPorCargueIdAsync),
                instanciaId,
                (CargueId, Guid.NewGuid()));

            var response = await cliente.WaitForCompletionOrCreateCheckStatusResponseAsync(req, instanciaId, new TimeSpan(0, 1, 0));
            if (exportar)
            {
                string jsonmedicos = await response.Content.ReadAsStringAsync();
                var excel = await cliente.StartNewAsync(
                nameof(_servicio.GetExcelMedicos),
                instanciaexcelId,
                (jsonmedicos, Guid.NewGuid()));
                HttpResponseMessage excelresponse = await cliente.WaitForCompletionOrCreateCheckStatusResponseAsync(req, instanciaexcelId, new TimeSpan(0, 1, 0));
                var base64ExcelCruo = await excelresponse.Content.ReadAsStringAsync();
                var base64Excel = base64ExcelCruo.Replace("\"", string.Empty);
                var bytes = Convert.FromBase64String(base64Excel);
               
                return new FileContentResult(bytes, "application/vnd.ms-excel");
            }

            return new OkObjectResult(response);
        }
        private async Task<HttpResponseMessage> ConsultaPorDocumento(HttpRequestMessage req, IDurableClient cliente, string documentoEntrada, string tipoInput)
        {
            if (DocumentoEsInvalido(documentoEntrada, out int documento))
                return SolicitudInvalida("Documento invalido");

            if (TipoEsInvalido(tipoInput, out Kustodya.Medicos.Data.Medicos.TiposDeDocumentoDeIdentificacion tipo))
                return SolicitudInvalida("Tipo de identificación no soportado");

            string instanciaId = await SolicitarConsultaIndividual(cliente, documento.ToString(), tipo);

            return await cliente.WaitForCompletionOrCreateCheckStatusResponseAsync(req, instanciaId, new TimeSpan(0, 1, 0));
        }
        private TipoConsulta GetTipoConsulta(string documentoEntrada, string tipoInput, string primerNombre, string primerApellido, string CargueMasivoId)
        {
            if (!TipoEsInvalido(tipoInput, out TiposDeDocumentoDeIdentificacion tipo) && !DocumentoEsInvalido(documentoEntrada, out int documento))
                return TipoConsulta.PorDocumento;
            if (!NombreYApelllidoInvalidoValido(primerNombre, primerApellido))
                return TipoConsulta.PorNombres;
            if (CargueMasivoId.Length > 0)
                return TipoConsulta.PorCargueId;

            return 0;
        }

        public enum TipoConsulta
        {
            PorDocumento = 1,
            PorNombres,
            PorCargueId
        }

        private bool NombreYApelllidoInvalidoValido(string primerNombre, string primerApellido)
        {
            return (string.IsNullOrWhiteSpace(primerNombre) && string.IsNullOrWhiteSpace(primerApellido));
        }

        [FunctionName(nameof(ConsultaIndividual))]
        public async Task<Medico> ConsultaIndividual([OrchestrationTrigger] IDurableOrchestrationContext context)
        {
            var (medico, peticionId) = context.GetInput<(Registro, Guid)>();
            var respuesta = await context.CallSubOrchestratorAsync<Medico>(
                nameof(_servicio.GetMedicoAsync),
                (medico, peticionId));


            //var outputModel = _mapper.Map<Kustodya.Medicos.Data.Rethus.Consulta>(respuesta);
            //var outputModel = new Kustodya.Medicos.Data.Rethus.Consulta();
            return respuesta;
        }

        private HttpResponseMessage SolicitudInvalida(string razon)
        {
            _logger.LogInformation($"Respondiendo solicitud invalida: {razon}");

            return new HttpResponseMessage(HttpStatusCode.BadRequest)
            { Content = new StringContent(razon) };
        }

        private async Task<string> SolicitarConsultaIndividual(IDurableClient cliente, Registro registro)
        {
            var instanciaId = Guid.NewGuid().ToString();
            var medico = await cliente.StartNewAsync(
                nameof(ConsultaIndividual),
                instanciaId,
                (registro, Guid.NewGuid()));

            _logger.LogInformation(
                    $"Solicitando consulta eReTHUS por documento para: " +
                    $"{Enum.GetName(typeof(TiposDeDocumentoDeIdentificacion), registro.TipoIdentificacion)} {registro.TipoIdentificacion}"
                );

            return instanciaId;
        }

        private async Task<string> SolicitarConsultaIndividual(IDurableClient cliente, string documento, TiposDeDocumentoDeIdentificacion tipo)
        {
            Registro registro = new Registro(documento.ToString(), tipo);
            return await SolicitarConsultaIndividual(cliente, registro);
        }

        private void ExtraerDatosDeEntrada(
            HttpRequestMessage req,
            out string documentoEntrada,
            out string tipoInput,
            out string primerNombre,
            out string primerApellido,
            out string CargueMasivoId,
            out bool exportar)
        {
            var query = HttpUtility.ParseQueryString(req.RequestUri.Query);
            documentoEntrada = query["documento"];
            tipoInput = query["tipo"];
            primerNombre = query["primerNombre"];
            primerApellido = query["primerApellido"];
            CargueMasivoId = query["CargueMasivoId"];
            exportar = query["exportar"] != null ? Convert.ToBoolean(query["exportar"].ToString()) : false;

            _logger.LogInformation($"ℹ MedicoController - Extrayendo información de: {tipoInput} {documentoEntrada}");
        }

        private bool TipoEsInvalido(string tipoInput, out TiposDeDocumentoDeIdentificacion tipo)
        {
            bool esInvalido = !Enum.TryParse<TiposDeDocumentoDeIdentificacion>(tipoInput, true, out tipo);
            if (esInvalido)
                _logger.LogInformation($"Tipo '{tipo}' invalido o no soportado");

            return esInvalido;
        }

        private bool DocumentoEsInvalido(string documentoEntrada, out int documento)
        {
            var documentoNoEsNumerico = !Int32.TryParse(documentoEntrada, out documento);
            bool esInvalido = string.IsNullOrWhiteSpace(documentoEntrada) || documentoNoEsNumerico;
            if (esInvalido)
                _logger.LogInformation($"Documento '{documento}' invalido");

            return esInvalido;
        }
        [FunctionName("GetTiposIdentificacion")]
        public async Task<HttpResponseMessage> GetTiposIdentificacion([HttpTrigger(AuthorizationLevel.Function, methods: "get", Route = "TiposIdentificacion")] HttpRequestMessage req, [DurableClient] IDurableClient cliente)
        {
            // TODO: Ponerlo en un servicio del proyecto web
            List<EnumValueModel> TiposDocumento = (((TiposDeDocumentoDeIdentificacion[])Enum.GetValues(typeof(TiposDeDocumentoDeIdentificacion)))
             .Select(c => new EnumValueModel() { Valor = (int)c, Nombre = c.ToString().Replace("_", " ") }).ToList());

            // TODO: Revisar si el HttResponseMessage tiene un constructor que recibe un objeto anonimo para no usar JsonConvert 
            var jsonString = JsonConvert.SerializeObject(TiposDocumento);
            //_logger.LogInformation(jsonString);
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(jsonString, Encoding.UTF8, "application/json")
            };
        }
    }
}