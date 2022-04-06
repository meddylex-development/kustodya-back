using Kustodya.Medicos.Input;
using Kustodya.Medicos.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Kustodya.Medicos.Services
{
    public interface IServicioModeloDeEntrada
    {
        Task<InputModel> ConstruirModeloDeEntrada([OrchestrationTrigger] IDurableOrchestrationContext context);
    }
}