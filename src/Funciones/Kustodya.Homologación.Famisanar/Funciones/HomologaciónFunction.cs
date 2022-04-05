using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Kustodya.ApplicationCore.Entities.MallaValidadora;
using Kustodya.Homologacion;
using Kustodya.Homologacion.Famisanar.Servicios;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Kustodya.Homologacion.Famisanar
{
    public class HomologacionFunction
    {
        public HomologacionFunction(IMapper mapper, ServicioDeHomologacion service, ServicioDeValidacion servicioDeValidacion)
        {
            _mapper = mapper;
            _service = service;
            _servicioDeValidacion = servicioDeValidacion;
        }

        private readonly IMapper _mapper;
        private readonly ServicioDeHomologacion _service;
        private ServicioDeValidacion _servicioDeValidacion;

        [FunctionName("HomologacionDeIncapacidades")]
        public async Task Run(
        [ServiceBusTrigger("incapacidades-dev", Connection = "ServiceBus")]
        string paginasJson,
        Int32 deliveryCount,
        DateTime enqueuedTimeUtc,
        string messageId,
        ILogger log)
        {
            log.LogInformation($"🚩 Nuevo Mensaje ❕");
            //log.LogInformation($"ℹ La funcion accionada por un gatillo de Service bus proceso: {paginaJson}");
            log.LogInformation($"ℹ Tiempo de encolamiento UTC: {enqueuedTimeUtc}");
            log.LogInformation($"ℹ Conteo de entrega: {deliveryCount}");
            log.LogInformation($"ℹ Id del mensaje: {messageId}");

            var incapacidades = _service.Homologar(paginasJson);
            await _servicioDeValidacion.ValidarAsync(incapacidades);
            // _mapper.Map<Incapacidad>(pagina);

            //log.LogInformation($"Primera incapacidad: {pagina}\n\n");
        }
    }
}
