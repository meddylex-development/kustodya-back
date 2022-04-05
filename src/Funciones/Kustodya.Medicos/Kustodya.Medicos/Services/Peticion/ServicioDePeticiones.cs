
using Kustodya.Medicos.Data;
using Kustodya.Medicos.Specifications;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Kustodya.Medicos.Services
{
    public class ServicioDePeticiones : IServicioDePeticiones
    {
        private ILoggerFactory _logger;
        private ICosmosDbAsyncRepository<CargueMasivo, MedicosContext> _repo;

        public ServicioDePeticiones(ILoggerFactory logger, ICosmosDbAsyncRepository<CargueMasivo, MedicosContext> repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [FunctionName(nameof(PersistirPeticion))]
        public async Task<CargueMasivo> PersistirPeticion([ActivityTrigger] CargueMasivo cargue)
        {
            var cargueConPeticionIdSpec = new CargueConPeticionIdSpec(cargue.PeticionId);
            var cargueExistente = await _repo.GetOneAsync(cargueConPeticionIdSpec);
            if (cargueExistente is null)
            {
                return await _repo.AddAsync(cargue);
            }
            else
            {
                cargueExistente.Actualizado = DateTime.Now;
                cargueExistente.Estado = Data.Medicos.Estado.Cargado;
                await _repo.UpdateAsync(cargueExistente);
                
                return cargueExistente;
            }
        }
    }
    public class CargueConPeticionIdSpec : BaseSpec<CargueMasivo>
    {
        public CargueConPeticionIdSpec(Guid peticionId)
            : base(c => c.PeticionId == peticionId)
        {

        }
    }
}
