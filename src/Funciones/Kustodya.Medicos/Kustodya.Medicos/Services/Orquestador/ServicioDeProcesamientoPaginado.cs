using Kustodya.Medicos.Data;
using Kustodya.Medicos.Models;
using Kustodya.Medicos.Services.Input;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.Medicos.Services
{
    public class ServicioDeProcesamientoPaginado : IServicioProcesamientoPaginado
    {
        private ILogger<ServicioDeProcesamientoPaginado> _logger;
        
        public ServicioDeProcesamientoPaginado(ILoggerFactory loggerFactory, IServicioDeConsultaDeMedicos medicoService)
        {
            _logger = loggerFactory.CreateLogger<ServicioDeProcesamientoPaginado>();
        }

        [FunctionName(nameof(ProcesarPaginas))]
        public async Task<List<Medico>> ProcesarPaginas([OrchestrationTrigger]IDurableOrchestrationContext context)
        {
            // Get input
            var (peticionId, paginasInputModel) = context.GetInput<(Guid, List<List<Registro>>)>();

            // Crear lista de tareas con de paginas procesadas (listas de medicos), medico es la entidad procesada
            var tareas = new List<Task<List<Medico>>>();

            // Llamara una funcion de actividad por cada pagina
            foreach (var pagina in paginasInputModel)
            {
                int paginaActual = paginasInputModel.IndexOf(pagina) + 1;

                var retryPolicy = new RetryOptions(new TimeSpan(0, 0, 0, paginaActual * 10), 10)
                {
                    Handle = (ex) =>
                    {
                        _logger.LogInformation($"❗ Orchestrator - la pagina {paginaActual} ha fallado: {ex.Message}");
                        return false;
                    },
                    BackoffCoefficient = 1 + (0.01 * paginaActual),
                };

                var paginaMedicos = context.CallActivityWithRetryAsync<List<Medico>>(
                    nameof(IServicioDeConsultaDeMedicos.GetMedicosAsync), 
                    retryPolicy, 
                    (pagina, peticionId, paginaActual));

                // var paginaMedicos = context.CallActivityAsync<List<Medico>>(
                //     nameof(IServicioDeConsultaDeMedicos.GetMedicosAsync),
                //     (pagina, peticionId, paginaActual)
                // );

                tareas.Add(paginaMedicos);
            }

            var medicos = await Task.WhenAll(tareas);
            return medicos.SelectMany(r => r).ToList();
        }

    }
}
