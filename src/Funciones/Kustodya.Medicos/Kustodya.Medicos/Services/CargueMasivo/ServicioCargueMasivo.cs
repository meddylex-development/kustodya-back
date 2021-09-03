using Kustodya.Medicos.Controllers;
using Kustodya.Medicos.Data;
using Kustodya.Medicos.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kustodya.Medicos.Services
{
    public class ServicioCargueMasivo : IServicioCargueMasivo
    {
        private OpcionesServicioCargueMasivo _opciones;
        private ICosmosDbAsyncRepository<CargueMasivo, MedicosContext> _repo;
        private ILogger _logger;

        public ServicioCargueMasivo(
            IOptionsMonitor<OpcionesServicioCargueMasivo> opciones,
            ILoggerFactory loggerFactory,
            ICosmosDbAsyncRepository<CargueMasivo, MedicosContext> repo)
        {
            _opciones = opciones.CurrentValue;
            _repo = repo;
            _logger = loggerFactory.CreateLogger(nameof(ServicioCargueMasivo));
        }

        // [FunctionName(nameof(ConsultarCarguesMasivos))]
        // public ICollection<CargueMasivo> ConsultarCarguesMasivos(
        //     [OrchestrationTrigger] IDurableOrchestrationContext context,
        //     [CosmosDB(
        //         "kustodya", "medicos_qa",
        //         ConnectionStringSetting = "CosmosDb:ConnectionString",
        //         SqlQuery = "SELECT * FROM c WHERE c.Discriminator = 'CargueMasivo'")] IEnumerable<CargueMasivo> cargues)
        // {
        //     context.CreateReplaySafeLogger(_logger);
        //     _logger.LogInformation($"ℹ Cargues: {JsonConvert.SerializeObject(cargues)}");
        //     return cargues.OrderByDescending(c => c.Creado).ToList();
        // }

        [FunctionName(nameof(ConsultarCarguesMasivos))]
        public CarguesOutputModel ConsultarCarguesMasivos(
            [OrchestrationTrigger] IDurableOrchestrationContext context,
            IBinder binder)
        {
            var (medicos, pagina) = context.GetInput<(string, int)>();
            context.CreateReplaySafeLogger(_logger);
            var container = Environment.GetEnvironmentVariable("CosmosDb:DefaultContainer");
            var database = Environment.GetEnvironmentVariable("CosmosDb:DatabaseName");
            var cosmosBinding = new CosmosDBAttribute(database, container)
            {
                ConnectionStringSetting = "CosmosDb:ConnectionString",
                SqlQuery = $@"SELECT * FROM c WHERE c.Discriminator = 'CargueMasivo' order by c.Creado desc OFFSET { (pagina - 1) * 10 } LIMIT 10"
            };
            var cargues = binder.Bind<IEnumerable<CargueMasivo>>(cosmosBinding);
            _logger.LogInformation($"ℹ Cargues: {JsonConvert.SerializeObject(cargues)}");

            cosmosBinding = new CosmosDBAttribute(database, container)
            {
                ConnectionStringSetting = "CosmosDb:ConnectionString",
                SqlQuery = $@"SELECT * FROM c WHERE c.Discriminator = 'CargueMasivo'"
            };
            var total = binder.Bind<IEnumerable<CargueMasivo>>(cosmosBinding);
            CarguesOutputModel cou = new CarguesOutputModel();
            cou.Cargues = cargues.OrderByDescending(c => c.Creado).ToList();
            cou.Paginacion = new PaginacionModel(total.Count(), pagina);
            return cou;
        }

        [FunctionName(nameof(ActualizarCargueMasivo))]
        public async Task<CargueMasivo> ActualizarCargueMasivo([ActivityTrigger] (Data.Medicos.Estado, CargueMasivo) context)
        {
            var (estado, cargue) = context;
            //var cargue = await _repo.GetByIdAsync(id);
            cargue.Estado = estado;
            await _repo.UpdateAsync(cargue);

            return cargue;
        }
    }
}
