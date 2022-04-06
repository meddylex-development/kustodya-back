using AutoMapper;
using Kustodya.ApplicationCore.DTOs.MallaValidadora.ModelosDeEntrada;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Kustodya.ApplicationCore.DTOs;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Kustodya.Homologacion.Famisanar.ModelosDeEntrada;
using Kustodya.Homologacion.Famisanar.Servicios;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;

namespace Kustodya.Homologacion.Famisanar
{
    public class ServicioDeHomologacion
    {
        public ServicioDeHomologacion(ServicioDeValidacion servicioDeValidacion, IMapper mapper, ILoggerFactory loggerFactory
            , TelemetryConfiguration  telemetryConfiguration)
        {
            _servicioDeValidacion = servicioDeValidacion;
            _mapper = mapper;
            _logger = loggerFactory.CreateLogger<ServicioDeHomologacion>();
            _telemetryClient = new TelemetryClient(telemetryConfiguration);
        }

        private readonly ServicioDeValidacion _servicioDeValidacion;
        private readonly IMapper _mapper;
        private readonly ILogger<ServicioDeHomologacion> _logger;
        private readonly TelemetryClient _telemetryClient;

        public List<IncapacidadInputModel> Homologar(string paginasJson)
        {
            _logger.LogInformation($"ℹ Homologando nuevo set de páginas: {paginasJson} ⏳");
            _telemetryClient.TrackTrace($"ℹ Homologando nuevo set de páginas: {paginasJson} ⏳", SeverityLevel.Information);
            var pagina = JsonConvert.DeserializeObject<List<IncapacidadFamisanar>>(paginasJson);
            
            var modelosDeEntrada = _mapper.Map<List<IncapacidadInputModel>>(pagina);
            
            _logger.LogInformation($"ℹ Página homologada: {JsonConvert.SerializeObject(modelosDeEntrada)} ✅");
            _telemetryClient.TrackTrace($"ℹ Página homologada: {JsonConvert.SerializeObject(modelosDeEntrada)} ✅", SeverityLevel.Information);
            return modelosDeEntrada;
        }
    }
}
