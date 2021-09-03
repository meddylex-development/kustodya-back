using Kustodya.ApplicationCore.Interfaces.Configuracion.Email;
using Kustodya.Medicos.Services;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Kustodya.Medicos.Tests
{
    public class NotificacionesServiceTests
    {
        public NotificacionesServiceTests()
        {
            _messageHandler = new Mock<HttpMessageHandler>();

            _messageHandler.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>()).ReturnsAsync(
                new HttpResponseMessage() { Content = new StringContent("[{\"bActivo\":true,\"iId\":23,\"iidips\":0,\"tCargo\":\"TECHNICAL LEADER\",\"tEmail\":\"CAMILOGO1200@GMAIL.COM\",\"tNombreEmpresa\":\"ROOJO TECH\",\"tPrimerApellido\":\"G�MEZ\",\"tPrimerNombre\":\"CRISTHIAN\",\"tSegundoApellido\":\"NARV�EZ\",\"tSegundoNombre\":\"CAMILO\"},{\"bActivo\":true,\"iId\":25,\"iidips\":11,\"tCargo\":\"PM\",\"tEmail\":\"CSANDOVAL@ROOJO.TECH\",\"tNombreEmpresa\":\"ROOJO\",\"tPrimerApellido\":\"SANDOVAL\",\"tPrimerNombre\":\"CARLOS\",\"tSegundoApellido\":\"SANDOVAL\",\"tSegundoNombre\":\"CARLOS\"},{\"bActivo\":true,\"iId\":32,\"iidips\":11,\"tCargo\":\"PM\",\"tEmail\":\"DAVIDCHAPARRO9894@GMAIL.COM\",\"tNombreEmpresa\":\"ROOJO\",\"tPrimerApellido\":\"CHAPARRO\",\"tPrimerNombre\":\"DAVID\",\"tSegundoApellido\":null,\"tSegundoNombre\":null}]") });
            _httpFactory = new Mock<IHttpClientFactory>();
            var _httpClient = new HttpClient(_messageHandler.Object);
            _httpClient.BaseAddress = new Uri("https://www.google.com");
            _httpFactory.Setup(h => h.CreateClient("webApiClient")).Returns(_httpClient);
        }

        private Mock<IHttpClientFactory> _httpFactory;
        private Mock<ILoggerFactory> _loggerFactory;
        private Mock<IEmailService> _emailService;
        private Mock<HttpMessageHandler> _messageHandler;

        [Fact]
        public async void ConsultarCorreosDeberia_RetornarUnaListaDeCorreos()
        {
            #region Setup
            _emailService = new Mock<IEmailService>();
            _emailService.Setup(e => e.SendEmailListAsync(It.IsAny<IReadOnlyList<string>>(), It.IsAny<string>(), It.IsAny<Dictionary<string, string>>())).ReturnsAsync(true);
            var durableActivityContextMock = new Mock<IDurableActivityContext>();
            #endregion

            var sut = new ServicioDeNotificaciones(_httpFactory.Object, new NullLoggerFactory(), _emailService.Object);

            var correos = new List<string> { "davidchaparro9894@gmail.com" };

            Assert.Equal(correos, await sut.ConsultarCorreosAsync(durableActivityContextMock.Object));
        }
    }
}
