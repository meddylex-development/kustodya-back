using Kustodya.Medicos.Data;
using Kustodya.Medicos.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace Kustodya.Medicos.Controllers
{
    public class CargueMasivoController
    {
        public CargueMasivoController(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<CargueMasivoController>();
        }

        private readonly ILogger _logger;
        private readonly IServicioDeOrquestacion _orquestador;
        private readonly IServicioCargueMasivo _cargueMasivo;

        [FunctionName(nameof(Post))]
        public async Task<HttpResponseMessage> Post(
            [HttpTrigger(AuthorizationLevel.Function, methods: "post", Route = "CargueMasivo")] HttpRequestMessage req,
            [Blob("peticiones/{rand-guid}", FileAccess.Write, Connection = "StorageConnection")] CloudBlockBlob peticionOutput,
            [DurableClient] IDurableClient starter)
        {
            // La entrada de la función viene del contenido de la solicitud
            var peticionInput = await req.Content.ReadAsStreamAsync();
            var provider = new RestrictiveMultipartMemoryStreamProvider();
            try
            {
                await req.Content.ReadAsMultipartAsync(provider);
            }
            catch (ArgumentException)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(new
                    {
                        Error = "El archivo debe ser de tipo 'multipart/form-data'"
                    }))
                };
            }
            await peticionOutput.UploadFromStreamAsync(await provider.Contents[0].ReadAsStreamAsync());

            _logger.LogInformation($"ℹ Orquestación iniciada para la peticion: {peticionOutput.Name}");

            var peticionId = peticionOutput.Name;
            var fileName = provider.Contents[0].Headers.ContentDisposition.FileName.Replace("\"",string.Empty);
            
            try{

                string instanciaId = await starter.StartNewAsync(
                    nameof(_orquestador.Orchestrator),
                    peticionId,
                    input: (Guid.Parse(peticionId), fileName, string.Empty/*TODO: agregar nombreUsuario*/));
                return starter.CreateCheckStatusResponse(req, instanciaId);
            }
            catch(Exception ex){
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(new
                    {
                        Error = ex.Message
                    }))
                };
            }
        }

        [FunctionName(nameof(Get))]
        public async Task<HttpResponseMessage> Get(
            [HttpTrigger(AuthorizationLevel.Function, methods: "get", Route = "CargueMasivo")] HttpRequestMessage req, [DurableClient] IDurableClient client)
        {
            var query = HttpUtility.ParseQueryString(req.RequestUri.Query);
            int pagina = query["pagina"] == null ? 1 :  Convert.ToInt32(query["pagina"]);
            string guid = Guid.NewGuid().ToString();
            var cargues = await client.StartNewAsync(
                nameof(_cargueMasivo.ConsultarCarguesMasivos), 
                guid, 
                ("",pagina));

            _logger.LogInformation($"ℹ Consulta de Cargues masivos iniciada");
            
            // return new OkObjectResult(cargues);
            return await client.WaitForCompletionOrCreateCheckStatusResponseAsync(req, guid, new TimeSpan(0, 1, 0));
        }

        private class RestrictiveMultipartMemoryStreamProvider : MultipartMemoryStreamProvider
        {
            public override Stream GetStream(HttpContent parent, HttpContentHeaders headers)
            {
                var extensions = new[] { "csv" };
                var filename = headers.ContentDisposition.FileName.Replace("\"", string.Empty);

                if (filename.IndexOf('.') < 0)
                    return Stream.Null;

                var extension = filename.Split('.').Last();

                return extensions.Any(i => i.Equals(extension, StringComparison.InvariantCultureIgnoreCase))
                        ? base.GetStream(parent, headers)
                        : Stream.Null;

            }
        }
    }

}
