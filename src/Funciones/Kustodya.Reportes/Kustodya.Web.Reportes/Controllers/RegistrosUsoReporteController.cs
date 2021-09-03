using System.IO;
using System.Threading.Tasks;
using Kustodya.Core.Reportes.DTOs;
using Kustodya.Core.Interfaces;
using Kustodya.Core.Reportes.Entities;
using Kustodya.Web.Reportes.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Kustodya.Infrastructure.Reportes.Data;
using Kustodya.Core.Reportes.Services;
using System;

namespace Kustodya.Reportes.Controllers
{
    public partial class RegistrosUsoReporteController
    {
        private readonly IRegistrosUsoReporteInputModelService _inputModelService;
        private readonly IIniciarCapacidadService _iniciarCapacidadService;

        public RegistrosUsoReporteController(
            IRegistrosUsoReporteInputModelService inputModelService
            // , IAsyncRepository<UsoReporte, ReportesContext> reportesRepository
            , IIniciarCapacidadService iniciarCapacidadService
            )
        {
            _inputModelService = inputModelService;
            // TODO: Se puede llamar al repositorio directamente si la logica de solicitud del reporte está encapsulada en la entidad?
            // _reportesRepository = reportesRepository;
            _iniciarCapacidadService = iniciarCapacidadService;
        }

        [FunctionName(nameof(RegistrosUsosReporte))]
        public async Task<IActionResult> RegistrosUsosReporte(
           [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
           ILogger log)
        {
            log.LogInformation("Creando uso de reporte");
            try
            {
                string body = await new StreamReader(req.Body).ReadToEndAsync();
                var registro = _inputModelService.GetRegistrosUsoReporteModelAsync(body);

                await GuardarUsoDeReporteAsync(registro);

                return new OkObjectResult(registro);
            }
            catch (JsonSerializationException ex)
            {
                return new BadRequestObjectResult($"No pudimos deserializar el objeto que enviaste, asegurate de enviar un objeto con el formato adecuado\nDetalles: {ex.Message}");
            }
        }

        [FunctionName(nameof(SolicitarReporte))]
        public async Task<IActionResult> SolicitarReporte(
           [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
           ILogger log)
        {
            log.LogInformation("Creando uso de reporte");
            try
            {
                string body = await new StreamReader(req.Body).ReadToEndAsync();
                var solicitud = _inputModelService.GetRegistrosUsoReporteModelAsync(body);

                await SolicitarUsoDelReporteAsync(solicitud);

                return new OkObjectResult(solicitud);
            }
            catch (JsonSerializationException ex)
            {
                return new BadRequestObjectResult($"No pudimos deserializar el objeto que enviaste, asegurate de enviar un objeto con el formato adecuado\nDetalles: {ex.Message}");
            }
        }

        private async Task GuardarUsoDeReporteAsync(SolicitudReporteModel solicitud)
        {
            await Task.Run(() => throw new NotImplementedException());
            // await _reportesRepository.AddAsync(usoReporte);
        }

        
        private async Task<bool> SolicitarUsoDelReporteAsync(SolicitudReporteModel solicitud)
        {
            return await _iniciarCapacidadService.SolicitarAsync(solicitud.UsuarioId, solicitud.EntidadId, solicitud.ReporteId, solicitud.WorkspaceId);
        }
    }
}