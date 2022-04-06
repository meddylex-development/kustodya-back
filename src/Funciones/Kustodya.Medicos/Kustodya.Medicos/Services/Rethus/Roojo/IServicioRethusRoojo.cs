using System.Collections.Generic;
using System.Threading.Tasks;
using Kustodya.Medicos.Data;
using Kustodya.Medicos.Models;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Roojo.Rethus;

namespace Kustodya.Medicos.Services
{
    public interface IServicioRethusRoojo
    {
        Task<int> CrearTareaMultipleParaElRobot(ICollection<Medico> medicos);
        Task<Medico> ConsultarUnMedicoAsync([OrchestrationTrigger] IDurableOrchestrationContext context);
        Task<ICollection<Medico>> ConsultarMedicoPorNombresAsync([OrchestrationTrigger] IDurableOrchestrationContext context);
        Task<Consulta> ValidarExistenciaMedicoAsync(Medico medico);
    }
}