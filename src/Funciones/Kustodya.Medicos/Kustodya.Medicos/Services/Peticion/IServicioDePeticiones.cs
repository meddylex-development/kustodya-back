using Kustodya.Medicos.Data;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using System.Threading.Tasks;

namespace Kustodya.Medicos.Services
{
    public interface IServicioDePeticiones
    {
        Task<CargueMasivo> PersistirPeticion([ActivityTrigger] CargueMasivo peticion);
    }
}