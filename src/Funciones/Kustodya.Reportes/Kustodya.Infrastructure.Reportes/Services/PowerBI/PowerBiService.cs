using System;
using System.Threading.Tasks;
using Kustodya.Core.Reportes.Entities;
using Kustodya.Core.Reportes.Services;
using Microsoft.Extensions.Logging;
using Kustodya.Infrastructure.Reportes.Data;
using Kustodya.Core.Interfaces;
using Kustodya.Core.Reportes.Specifications;
using Microsoft.Extensions.DependencyInjection;

namespace Kustodya.Infrastructure.Reportes.Services
{
    public class PowerBiService : IPowerBiService
    {
        private readonly ILogger<PowerBiService> _logger;
        private readonly IPowerBiClient _powerBIiClient;
        private readonly IAsyncRepository<Reporte> _repository;
        private readonly IServiceScopeFactory _serviceFactory;
        private bool capacidadPausada;
        private bool reporteNoUsadoRecientemente;

        public PowerBiService(
            ILogger<PowerBiService> logger,
            IPowerBiClient powerBiClient,
            IAsyncRepository<Reporte> repository,
            IServiceScopeFactory serviceFactory)
        {
            _logger = logger;
            _powerBIiClient = powerBiClient;
            _repository = repository;
            _serviceFactory = serviceFactory;
        }

        public async Task PausarCapacidadAsync(string nombreCapacidad, string token, Guid workspaceId)
        {
            try
            {
                await ConsultarEstadoActualAsync(nombreCapacidad, token, workspaceId);

                if ((!capacidadPausada && reporteNoUsadoRecientemente) || FueraDelHorario())
                {
                    await _powerBIiClient.PausarCapacidadAsync(nombreCapacidad, token);
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        private bool FueraDelHorario()
        {
            var reporte = Reporte.Fabrica.Crear(Guid.NewGuid(), Guid.NewGuid());
            return !reporte.EsHorarioValido();
        }

        public async Task ReanudarCapacidadAsync(string nombreCapacidad, string token, Guid reporteId, Solicitud solicitud)
        {
            try
            {
                await ConsultarEstadoActualAsync(nombreCapacidad, token, reporteId);

                if (capacidadPausada && solicitud.Aprobada)
                    await _powerBIiClient.ReanudarCapacidadAsync(nombreCapacidad, token);
                return;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        private async Task ConsultarEstadoActualAsync(string nombreCapacidad, string token, Guid reporteId)
        {
            var estado = await _powerBIiClient.ConsultarEstadoCapacidadAsync(nombreCapacidad, token);
            capacidadPausada = estado == IPowerBiClient.EstadoIncapacidad.Pausado;
            reporteNoUsadoRecientemente = await WorkspaceNoUsadoRecientemente(reporteId);
        }


        private async Task<bool> WorkspaceNoUsadoRecientemente(Guid reporteId)
        {
            // var sp = _serviceFactory.CreateScope().ServiceProvider;
            // var repo = sp.GetRequiredService<IAsyncRepository<SolicitudDeUso>>();
            var spec = new ReporteConUsoRecienteSpecificaction(reporteId);
            int reportesConUsosRecientes = await _repository.CountAsync(spec);
            return reportesConUsosRecientes == 0;
        }

        public async Task DesasociarCapacidad(Guid capacidadId, Guid workspaceId, string token)
        {
            try
            {
                await Task.Run(() => throw new NotImplementedException());
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}