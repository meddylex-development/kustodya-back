using System;
using System.Threading.Tasks;
using Kustodya.Core.Reportes.Services;
using Kustodya.Infrastructure.Reportes.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Kustodya.Reportes
{
    public class CambioEstadoTrigger
    {
        private ISwitchearCapacidadService _servicioSwitcheo;

        public CambioEstadoTrigger(ISwitchearCapacidadService switchearCapacidadService)
        {
            _servicioSwitcheo = switchearCapacidadService;
        }

        [FunctionName("Reportes")]
        public async Task Run([TimerTrigger("%PeriodoEjecucion%")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            await _servicioSwitcheo.EjecutarAsync();
        }
    }
}
