using AutoMapper;
using Kustodya.Medicos.Input;
using Kustodya.Medicos.Services;
using Kustodya.Medicos.Services.Input;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TinyCsvParser.Mapping;
using Xunit;

namespace Kustodya.Medicos.Tests
{
    public class InputModelServiceTest
    {
        public InputModelServiceTest()
        {

        }

        [Theory]
        [InputModelTestData]
        public async void ConvertirCsv_Deberia_Convertir_Un_Csv(ICollection<ResultadoDeMapeo> resultadosDeMapeo)
        {
            // Mock Automapper
            var MockdeMapper = new Mock<IMapper>();

            // Mock metodo map
            MockdeMapper
                .Setup(m => m.Map<IEnumerable<ResultadoDeMapeo>>(It.IsAny<IEnumerable<CsvMappingResult<Registro>>>()))
                .Returns(resultadosDeMapeo);

            // Mock DurableOrchestrationClientBase
            var durableOrchestrationContextBaseMock = new Mock<IDurableOrchestrationContext>();

            // Mock CallActivityAsync method for ConvertirCsv
            durableOrchestrationContextBaseMock.
                Setup(x => 
                    x.CallActivityAsync<IEnumerable<CsvMappingResult<Registro>>>(
                        "ConvertirCsv", 
                        It.IsAny<string>()))
                .ReturnsAsync(new List<CsvMappingResult<Registro>>());

            // Mock CallActivityAsync method for ConvertirCsv
            var inputModel = InputModel.Fabrica.CrearDesdeCsvConvertido(resultadosDeMapeo);
            durableOrchestrationContextBaseMock.
                Setup(x =>
                    x.CallActivityAsync<InputModel>(
                        "CrearModeloDeEntrada",
                        It.IsAny<IEnumerable<CsvMappingResult<Registro>>> ()))
                .ReturnsAsync(inputModel);

            var sut = new ServicioModeloDeEntrada(new NullLoggerFactory(), MockdeMapper.Object);

            var modeloEntrada = await sut.ConstruirModeloDeEntrada(durableOrchestrationContextBaseMock.Object);

            Assert.Equal(inputModel, modeloEntrada);

        }
    }
}
