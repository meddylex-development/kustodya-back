using System;
using System.Threading.Tasks;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.Medicos.Data;
using Kustodya.Medicos.Data.Medicos;
using Kustodya.Medicos.Specifications;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Linq;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Kustodya.Medicos.Services;
using System.Collections.Generic;

namespace Kustodya.Medicos.Controllers
{
    public class AseguradorDeCarguesTimmer
    {
        public ICosmosDbAsyncRepository<CargueMasivo, MedicosContext> _repo { get; set; }
        public AseguradorDeCarguesTimmer(ICosmosDbAsyncRepository<CargueMasivo, MedicosContext> repo)
        {
            _repo = repo;
        }

        [FunctionName(nameof(AsegurarProcesamiento))]
        public async Task AsegurarProcesamiento([TimerTrigger("0 10 * * * *")] TimerInfo myTimer, [DurableClient] IDurableClient durableClient, IBinder binder)
        {
            return;
            /*var cargueObsoletoSpec = new CarguesObsoletosSpec();
            var carguesObsoletos = ConsultarCarguesMasivos(1, binder);

            foreach (var cargue in carguesObsoletos)
            {
                var intancia = await durableClient.StartNewAsync(
                    nameof(ServicioDeOrquestacion.Orchestrator),
                    Guid.NewGuid().ToString(),
                    input: (cargue.PeticionId, cargue.NombreArchivo, cargue.NombreUsuario)
                );
            }*/
        }

        private ICollection<CargueMasivo> ConsultarCarguesMasivos(int top, IBinder binder)
        {
            var container = Environment.GetEnvironmentVariable("CosmosDb:DefaultContainer");
            var database = Environment.GetEnvironmentVariable("CosmosDb:DatabaseName");
            var datetime = DateTime.Now;
            var cosmosBinding = new CosmosDBAttribute(database, container)
            {
                ConnectionStringSetting = "CosmosDb:ConnectionString",
                SqlQuery = 
                $@"SELECT TOP {top}
                    * 
                FROM c 
                WHERE 
                    c.Discriminator = 'CargueMasivo' 
                    AND c.Estado = 'Cargado' 
                    AND c.Validos <= 50 
                    AND c.Creado < '{datetime.Year}-{datetime.Month}-{datetime.Day}T{datetime.ToUniversalTime().ToUniversalTime().TimeOfDay.ToString()}'
                ORDER BY c.Creado DESC"
                // 2020-05-13T00:09:45.0920099+00:00
            };

            var existentes = binder.Bind<IEnumerable<CargueMasivo>>(cosmosBinding);

            return existentes.ToList().AsReadOnly();
        }
    }
    
    public class CarguesObsoletosSpec : BaseSpec<CargueMasivo>
    {
        public CarguesObsoletosSpec()
            : base(c =>
            // c.Creado > DateTime.Now.AddHours(-1)
            // && 
            (c.Estado == Estado.Cargado
            || c.Estado == Estado.Fallido))
        {

        }
    }
}