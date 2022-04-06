using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Kustodya.Core.Reportes.Services;
using Kustodya.Core.Reportes.Exceptions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Kustodya.Infrastructure.Reportes.Services
{
    public class PowerBiClient : IPowerBiClient
    {
        private readonly ConfiguracionPowerBiClient _opciones;
        private readonly ILogger<PowerBiClient> _logger;
        private readonly HttpClient _httpClient;

        public PowerBiClient(
            ILogger<PowerBiClient> logger,
            IHttpClientFactory httpClientFactory,
            IOptionsMonitor<ConfiguracionPowerBiClient> opciones)
        {
            _opciones = opciones.CurrentValue;
            _logger = logger;
            _httpClient = httpClientFactory.CreateClient(nameof(PowerBiClient));
        }

        public async Task PausarCapacidadAsync(string nombreCapacidad, string token)
        {
            SetTokenAutorizacion(token);
            var response = await _httpClient.PostAsync(nombreCapacidad + "/suspend?api-version=2017-10-01", null);
            var r = response;
        }

        public async Task ReanudarCapacidadAsync(string nombreCapacidad, string token)
        {
            SetTokenAutorizacion(token);
            var respuesta = await _httpClient.PostAsync(nombreCapacidad + "/resume?api-version=2017-10-01", null);
            ValidarEstadoExitoso(respuesta);
        }


        public async Task<IPowerBiClient.EstadoIncapacidad> ConsultarEstadoCapacidadAsync(string nombreCapacidad, string token)
        {
            SetTokenAutorizacion(token);
            var respuesta = await _httpClient.GetAsync(nombreCapacidad + "?api-version=2017-10-01");
            ValidarEstadoExitoso(respuesta);
            var capacidad = await respuesta.Content.ReadAsAsync<PowerBICapacityModel>();

            if(capacidad.properties.state == "Paused") 
                return IPowerBiClient.EstadoIncapacidad.Pausado;

            return IPowerBiClient.EstadoIncapacidad.Reanudado;
        }

        private static void ValidarEstadoExitoso(HttpResponseMessage respuesta)
        {
            if (!respuesta.IsSuccessStatusCode) throw new NoAutorizadoException("Error de autorización al consumir el servicio de reanudación de Power BI");
        }

        private void SetTokenAutorizacion(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                            new AuthenticationHeaderValue("Bearer", token);
        }

}
}