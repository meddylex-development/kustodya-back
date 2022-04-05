using Kustodya.Medicos.Data;
using Kustodya.Medicos.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kustodya.Medicos.Services
{
    public interface IServicioCargueMasivo
    {
        Task<CargueMasivo> ActualizarCargueMasivo([ActivityTrigger] (Data.Medicos.Estado, CargueMasivo) context);
        // ICollection<CargueMasivo> ConsultarCarguesMasivos([OrchestrationTrigger] IDurableOrchestrationContext context, [CosmosDB("kustodya", "medicos_qa", SqlQuery = "SELECT * FROM c WHERE c.Discriminator = 'CargueMasivo'")] IEnumerable<CargueMasivo> cargues);
        CarguesOutputModel ConsultarCarguesMasivos([OrchestrationTrigger] IDurableOrchestrationContext context, IBinder binder);
    }
}