using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Kustodya.Core.Reportes.Services
{
    public class SwitchearCapacidadService : ISwitchearCapacidadService
    {
        private readonly ILogger<SwitchearCapacidadService> _logger;
        private readonly IAadService _aadService;
        private readonly IPowerBiService _powerBiService;
        private readonly string _nombreCapacidad;
        private Guid _workspaceId;

        public SwitchearCapacidadService(
            ILogger<SwitchearCapacidadService> logger,
            IAadService aadService,
            IPowerBiService powerBiService,
            IOptionsMonitor<ConfiguracionPowerBiClient> opciones,
            IOptionsMonitor<ConfiguracionPowerBiService> opcionesService)
        {
            _logger = logger;
            _aadService = aadService;
            _powerBiService = powerBiService;
            _nombreCapacidad = opciones.CurrentValue.DedicatedCapacityName;
            _workspaceId = opcionesService.CurrentValue.WorkspaceId;
        }
        public async Task EjecutarAsync()
        {
            try
            {
                _logger.LogInformation($"Switcheando la capacidad con id {_nombreCapacidad} para el workspace {_workspaceId}");
                string token = await _aadService.GetTokenAadAsync();
                await _powerBiService.PausarCapacidadAsync(_nombreCapacidad, token, _workspaceId);
            }
            catch (System.Exception)
            {
                _logger.LogError($"Se produjo un error inesperado switcheando la capacidad {_nombreCapacidad} para el workspace {_workspaceId}");
                throw;
            }
        }
    }
}