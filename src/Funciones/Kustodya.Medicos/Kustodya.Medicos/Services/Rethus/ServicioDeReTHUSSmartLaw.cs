
using Kustodya.Medicos.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Kustodya.ApplicationCore.Constants;
using AutoMapper;
using System.Collections.Generic;
using Kustodya.Medicos.Services.Input;

namespace Kustodya.Medicos.Services
{

    public class ServicioDeReTHUSSmartLaw : IServicioDeReTHUSSmartLaw
    {
        public ServicioDeReTHUSSmartLaw(IHttpClientFactory factory,
        ILoggerFactory loggerFactory,
        IMapper mapper)
        {
            _client = factory.CreateClient("Rethus");
            _logger = loggerFactory.CreateLogger<ServicioDeReTHUSSmartLaw>();
            _mapper = mapper;
        }
        #region Dependency Injection

        private readonly HttpClient _client;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        #endregion

        public async Task<RethusResponseModel> ConsultarUnMedicoAsync(string documentNumber, TipoIdentificacion tipo)
        {
            var tipoSmartLaw = _mapper.Map<Roojo.Rethus.TipoIdentificacionRethus>(tipo);
            var request = new Request
            {
                iIDServicio = 1, // Rethus
                iIDEntidad = 2,
                tTipoIdentificacion = ((int)tipoSmartLaw).ToString(),
                tNumeroIdentificacion = documentNumber
            };

            try
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

                var response = await _client.PostAsync("Values/Post", stringContent);

                var content = await response.Content.ReadAsStringAsync();
                var medicoRethus = JsonConvert.DeserializeObject<RethusResponseModel>(content);

                if (medicoRethus.PrimerNombre == null && medicoRethus.PrimerApellido == null)
                {
                    medicoRethus.TNumeroIdentificacion = documentNumber;
                    medicoRethus.TIdValorTipoIdentificacion = tipoSmartLaw;
                }

                if (medicoRethus.Mensaje != "Información Correcta")
                    throw new ErrorEnConsultaException(medicoRethus.Mensaje);

                return medicoRethus;
            }
            catch (ErrorEnConsultaException ex)
            {
                _logger.LogInformation($"❗ Error en servicio Rethus de SLT. " +
                    $"{Enum.GetName(typeof(TipoIdentificacion), tipoSmartLaw)}: {documentNumber}\n" +
                    $"Mensaje: {ex.Message}\n" +
                    $"InnerException: {ex.InnerException?.Message}");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"❗ Error en servicio Rethus de SLT. " +
                    $"{Enum.GetName(typeof(TipoIdentificacion), tipoSmartLaw)}: {documentNumber}\n" +
                    $"Mensaje: {ex.Message}\n" +
                    $"InnerException: {ex.InnerException?.Message}");
                throw;
            }
        }

        public Task<RethusResponseModel> GetMedicosAsync(ICollection<Registro> registros)
        {
            throw new NotImplementedException();
        }

        public Task<RethusResponseModel> GetMedicosAsync(ICollection<Registro> registros, int usuarioId)
        {
            throw new NotImplementedException();
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

