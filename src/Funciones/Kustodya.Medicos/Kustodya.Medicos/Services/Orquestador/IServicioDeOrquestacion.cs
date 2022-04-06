using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using System.Threading.Tasks;

namespace Kustodya.Medicos.Services
{
    public interface IServicioDeOrquestacion
    {
        Task<IActionResult> Orchestrator([OrchestrationTrigger] IDurableOrchestrationContext context);
    }
}