using System.Collections.Generic;
using System.Net.Http;
using Kustodya.ApplicationCore.DTOs.MallaValidadora.ModelosDeEntrada;
using System;
using System.Threading.Tasks;

namespace Kustodya.Homologacion.Famisanar.Servicios
{
    public class ServicioDeValidacion
    {
        private readonly HttpClient _servicioRest;

        public ServicioDeValidacion(IHttpClientFactory factory)
        {
            _servicioRest = factory.CreateClient("Kustodya.Incapacidades");
        }

        public async Task ValidarAsync(List<IncapacidadInputModel> inputModels)
        {
            var response = await _servicioRest.PostAsJsonAsync("Validar", inputModels);
            if(!response.IsSuccessStatusCode) 
                throw new HttpRequestException($"La respuesta del servicio indica una solicitud no exitosa. \n\tCodigo de respuesta: {response.StatusCode}\n\tRazon: {response.ReasonPhrase}\n\tContenido: {await response.Content.ReadAsStringAsync()}");
        }
    }
}