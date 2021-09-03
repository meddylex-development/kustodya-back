using Kustodya.Medicos.Data;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Kustodya.Medicos.Services
{
    public interface IServicioDeConsultaDeMedicos
    {
        Task<Medico> GetMedicoAsync([OrchestrationTrigger] IDurableOrchestrationContext context);
        Task<List<Medico>> GetMedicosAsync([OrchestrationTrigger] IDurableOrchestrationContext context);
        Task<List<Medico>> GetMedicosPorNombreAsync([OrchestrationTrigger] IDurableOrchestrationContext context);
        Task<List<Medico>> GetMedicosPorCargueIdAsync([OrchestrationTrigger] IDurableOrchestrationContext context);
        byte[] GetExcelMedicos([OrchestrationTrigger] IDurableOrchestrationContext context);

        
        
    }
}