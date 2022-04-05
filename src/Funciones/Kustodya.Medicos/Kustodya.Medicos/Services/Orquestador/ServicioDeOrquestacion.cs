using Kustodya.Medicos.Controllers;
using Kustodya.Medicos.Data;
using Kustodya.Medicos.Input;
using Kustodya.Medicos.Services.Input;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Kustodya.ApplicationCore.Entities;

namespace Kustodya.Medicos.Services
{
    public class ServicioDeOrquestacion : IServicioDeOrquestacion
    {
        public ServicioDeOrquestacion(
            ILoggerFactory loggerFactory,
            IOptionsMonitor<OpcionesCargueMasivo> options,
            IServicioDeConsultaDeMedicos servicioMedicos
            )
        {
            _logger = loggerFactory.CreateLogger<ServicioDeOrquestacion>();
            tamanoPagina = options.CurrentValue.tamanoPagina;
            _servicioMedicos = servicioMedicos;
        }

        private readonly ILogger _logger;
        private readonly IServicioCargueMasivo _servicioCargueMasivo;
        private readonly int tamanoPagina;
        private readonly IServicioDeConsultaDeMedicos _servicioMedicos;

        [FunctionName(nameof(Orchestrator))]
        public async Task<IActionResult> Orchestrator([OrchestrationTrigger] IDurableOrchestrationContext context)
        {
            #region Configuracion
            var _log = context.CreateReplaySafeLogger(_logger);
            var (peticionId, nombreArchivo, nombreUsuario) = context.GetInput<(Guid, string, string)>();
            var procesarPaginasId = Guid.NewGuid();
            #endregion

            InputModel inputModel = null;
        
            inputModel = await context.CallSubOrchestratorAsync<InputModel>(
            nameof(IServicioModeloDeEntrada.ConstruirModeloDeEntrada),
            peticionId);

            var cargue = new CargueMasivo(peticionId)
            {
                NombreArchivo = nombreArchivo,
                Creado = DateTime.Now,
                TotalSubido = inputModel.TotalSubido,
                Validos = inputModel.Validos.Count(),
                Unicos = inputModel.Unicos.Count(),
                TotalDuplicados = inputModel.TotalDuplicados,
                Duplicados = inputModel.DuplicadosValidosDistintos
                    .GroupBy(dd => dd)
                    .Select(dd => new
                    {
                        dd.Key.NumeroIdentificacion,
                        dd.Key.TipoIdentificacion,
                        Duplicados = dd.Count() - 1
                    }),
                Estado = Data.Medicos.Estado.Cargado
                //RegistradosEnRethus = medicos.Result.Select(m => m.RegistradoEnRethus).Count()
            };

            cargue = await context.CallActivityAsync<CargueMasivo>(
                nameof(IServicioDePeticiones.PersistirPeticion),
                cargue);

            var medicos = context.CallSubOrchestratorAsync<List<Medico>>(
                nameof(_servicioMedicos.GetMedicosAsync),
                (inputModel.Unicos, cargue.PeticionId, 1)
            );

            #region Timeout
            var timeout = 30;
            using var cts = new CancellationTokenSource();
            var timeoutTask = context.CreateTimer(context.CurrentUtcDateTime.AddMinutes(timeout), cts.Token);

            await Task.WhenAny(medicos, timeoutTask);
            if (timeoutTask.IsCompleted)
            {
                _log.LogWarning($"⚠ Orquestador - Timeout después de {timeout} minutos. Finalizando la orquestación");
                var result = await context.CallHttpAsync(HttpMethod.Post, new Uri($"http://localhost:7071/runtime/webhooks/durabletask/instances/{procesarPaginasId}/terminate"));
                context.SetCustomStatus(new
                {
                    context.Name,
                    context.InstanceId,
                    RuntimeStatus = "TimedOut",
                    Input = "peticionId",
                });
            }
            else
                cts.Cancel();
            #endregion
            
            cargue.RegistradosEnRethus = medicos.Result.Where(m => m.RegistradoEnRethus == true).Count();
            cargue = await context.CallActivityAsync<CargueMasivo>(
                nameof(_servicioCargueMasivo.ActualizarCargueMasivo), 
                (Data.Medicos.Estado.Terminado, cargue));

            var emails = await context.CallActivityAsync<List<string>>(
                nameof(IServicioDeNotificaciones.ConsultarCorreosAsync),
                null);

            await context.CallActivityAsync(
                nameof(IServicioDeNotificaciones.EnviarCorreos),
                (emails, cargue));

            _log.LogInformation($"ℹ Orquestador - Peticion {peticionId} finalizada 🔚");

            return new OkObjectResult(cargue);
        }

        [FunctionName(nameof(PaginarConsultas))]
        public List<List<Registro>> PaginarConsultas([ActivityTrigger] List<Registro> inputModels)
        {
            int totalPaginas = GetTotalPaginas(inputModels);

            var tasksPaginadas = new List<List<Registro>>();
            for (int i = 0; i < totalPaginas; i++)
            {
                var pagina = inputModels.Skip(tamanoPagina * i).Take(tamanoPagina).ToList();
                tasksPaginadas.Add(pagina);
            }

            return tasksPaginadas;
        }
        private int GetTotalPaginas(IReadOnlyList<Registro> inputModels) => inputModels.Count % tamanoPagina != 0 ? inputModels.Count / tamanoPagina + 1 : inputModels.Count / tamanoPagina;
    }
}
