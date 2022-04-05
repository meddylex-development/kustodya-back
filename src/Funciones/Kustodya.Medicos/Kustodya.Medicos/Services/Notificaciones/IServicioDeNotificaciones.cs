using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kustodya.Medicos.Services
{
    public interface IServicioDeNotificaciones
    {
        Task<IReadOnlyList<string>> ConsultarCorreosAsync(IDurableActivityContext context);
        Task EnviarCorreos([ActivityTrigger] IDurableActivityContext context);
    }
}