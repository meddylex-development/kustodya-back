using Kustodya.ApplicationCore.Constants;
using Kustodya.ApplicationCore.DTOs;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.Infrastructure.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class SmartLawRethusService : IRethusService
    {
        public SmartLawRethusService(IHttpClientFactory factory, IOptionsMonitor<RethusServiceOptions> optionsAccessor)
        {
            _client = factory.CreateClient("Rethus");

        }
        #region Dependency Injection

        private readonly HttpClient _client;
        #endregion

        public async Task<RethusResponse> GetPhysicianAsync(string documentNumber, TipoIdentificacion identificacion)
        {
            var request = new Request
            {
                iIDServicio = 1, // Rethus
                iIDEntidad = 2,
                tTipoIdentificacion = ((int)identificacion).ToString(),
                tNumeroIdentificacion = documentNumber
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("Values/Post", stringContent);

            var content = await response.Content.ReadAsStringAsync();
            var rethusEmployee = JsonConvert.DeserializeObject<RethusResponse>(content);

            return rethusEmployee;
        }

        private class Request
        {
            public int iIDEntidad;
            public int iIDServicio { get; set; }
            public string tTipoIdentificacion { get; set; }
            public string tNumeroIdentificacion { get; set; }
        }

    }
}

