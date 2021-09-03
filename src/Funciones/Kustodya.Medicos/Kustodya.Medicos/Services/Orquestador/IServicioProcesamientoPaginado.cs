using Kustodya.Medicos.Data;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kustodya.Medicos.Services
{
    public interface IServicioProcesamientoPaginado
    {
        Task<List<Medico>> ProcesarPaginas([OrchestrationTrigger] IDurableOrchestrationContext context);
    }
}