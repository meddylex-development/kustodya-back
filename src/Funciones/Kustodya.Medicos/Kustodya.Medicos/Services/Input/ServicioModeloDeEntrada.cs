using Kustodya.Medicos.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TinyCsvParser;
using TinyCsvParser.Mapping;
using System.Threading.Tasks;
using Kustodya.Medicos.Input;
using Kustodya.Medicos.Services.Input;
using AutoMapper;

namespace Kustodya.Medicos.Services
{
    public class ServicioModeloDeEntrada : IServicioModeloDeEntrada
    {
        public ServicioModeloDeEntrada(ILoggerFactory loggerFactory, IMapper mapper)
        {
            _logger = loggerFactory.CreateLogger<ServicioModeloDeEntrada>();
            _mapper = mapper;
        }

        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        [FunctionName(nameof(ConstruirModeloDeEntrada))]
        public async Task<InputModel> ConstruirModeloDeEntrada(
            [OrchestrationTrigger] IDurableOrchestrationContext context)
        {
            var peticionId = context.GetInput<string>();
            _logger.LogInformation($"ℹ Obteniendo InputModel para: '{peticionId}'...");

            var csvConvertido = await context.CallActivityAsync<ICollection<CsvMappingResult<Registro>>>
                    (nameof(ConvertirCsv), peticionId);

            if(csvConvertido.Count() > 50)
            {
                throw new System.Exception("La cantidad máxima de registro permitida es 50 registros");
            }
            
            var modeloEntrada = await context.CallActivityAsync<InputModel>(nameof(CrearModeloDeEntrada), csvConvertido);
            
            _logger.LogInformation($@"ℹ Orquestador - Peticion {peticionId} con {modeloEntrada.TotalSubido} registros:\n
                ⚙ Procesables: {modeloEntrada.Convertibles.Count()}\n
                ✅ Validos: {modeloEntrada.Validos.Count()}\n
                🦄 Unicos: {modeloEntrada.Unicos.Count()}\n
                🔁 Duplicados: {modeloEntrada.TotalDuplicados}");

            return modeloEntrada;
        }

        [FunctionName(nameof(ConvertirCsv))]
        public ICollection<CsvMappingResult<Registro>> ConvertirCsv([ActivityTrigger] string peticionId, [Blob("peticiones/{peticionId}", FileAccess.Read, Connection = "StorageConnection")] Stream request)
        {
            CsvParserOptions csvParserOptions = new CsvParserOptions(false, ';');
            CsvMedicoInputModelMap csvMapper = new CsvMedicoInputModelMap();
            CsvParser<Registro> csvParser = new CsvParser<Registro>(csvParserOptions, csvMapper);

            var resultado = csvParser
                .ReadFromStream(request, Encoding.ASCII).ToList();

            return resultado;
        }

        [FunctionName(nameof(CrearModeloDeEntrada))]
        public InputModel CrearModeloDeEntrada([ActivityTrigger] ICollection<CsvMappingResult<Registro>> csvConvertido)
        {
            var resultadosmapeo = _mapper.Map<ICollection<CsvMappingResult<Registro>>, ICollection<ResultadoDeMapeo>>(csvConvertido);

            return InputModel.Fabrica.CrearDesdeCsvConvertido(resultadosmapeo);
        }
    }
}
