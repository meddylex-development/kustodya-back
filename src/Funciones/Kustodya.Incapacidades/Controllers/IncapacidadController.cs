using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Kustodya.MallaValidadora;
using Kustodya.ApplicationCore.DTOs.MallaValidadora.ModelosDeEntrada;
using System.Collections.Generic;
using AutoMapper;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Entities.MallaValidadora;

namespace Kustodya.Incapacidades
{
    public class IncapacidadController
    {
        private readonly IncapacidadService _incapacidadService;
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Incapacidad> _repo;

        public IncapacidadController(
            IncapacidadService incapacidadService, 
            IMapper mapper,
            IAsyncRepository<Incapacidad> repo)
        {
            _incapacidadService = incapacidadService;
            _mapper = mapper;
            _repo = repo;
        }

        [FunctionName("Validar")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var modelosDeEntradaDeIncapacidad = JsonConvert.DeserializeObject<List<IncapacidadInputModel>>(requestBody);
            
            await _incapacidadService.ValidarAsync(modelosDeEntradaDeIncapacidad);

            return new OkObjectResult(null);
        }
    }
}
