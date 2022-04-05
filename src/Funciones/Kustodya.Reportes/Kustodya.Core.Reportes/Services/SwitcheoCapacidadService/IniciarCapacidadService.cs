using System;
using System.Threading.Tasks;
using Kustodya.Core.Interfaces;
using Kustodya.Core.Reportes.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Kustodya.Core.Reportes.Services
{

    public class IniciarCapacidadService : IIniciarCapacidadService
    {
        private readonly IAsyncRepository<Solicitud> _solicitudesRepository;
        private ILogger<IniciarCapacidadService> _logger;
        private IAadService _aadService;
        private IPowerBiService _powerBiService;
        private string _nombreCapacidad;
        private readonly IAsyncRepository<Reporte> _repository;

        public IniciarCapacidadService(
            ILogger<IniciarCapacidadService> logger,
            IAadService aadService,
            IPowerBiService powerBiService,
            IOptionsMonitor<ConfiguracionPowerBiClient> opciones,
            IAsyncRepository<Reporte> repository,
            IAsyncRepository<Solicitud> solicitudesRepository)
        {
            _solicitudesRepository = solicitudesRepository;
            _logger = logger;
            _aadService = aadService;
            _powerBiService = powerBiService;
            _repository = repository;
            _nombreCapacidad = opciones.CurrentValue.DedicatedCapacityName;
        }

        // TODO: Agregar DTO con los dos parametros de este metodo
        public async Task<bool> SolicitarAsync(int usuarioId, int entidadId, Guid reporteId, Guid workspaceId)
        {
            // TODO: Usar adaptador de log en vez del logger del framework
            _logger.LogInformation($"Solicitando permiso para usar el reporte {reporteId} del wrokspace {workspaceId}");
            var reporte = await GetReporteAsync(reporteId, workspaceId);
            // TODO: Agregar migraciones de Reportes o creación de contenedor en Cosmos

            // TODO: Revisar donde debe ir la lógica de validacion de inicio de la incapacidad, si en un servicio, en la entidad de reporte, o en la entidad de uso. El servicio es un intermediario entre el cliente de powerBI y los clientes del servicio de powerBI. Pero para seguir las pautas de DDD, la lógica del negocio debería estár encapsulada en la entidad. La entidad puede invocar servicios? debería?
            // TODO: El token deberia consultarse desde dentro del servicio de PowerBI? Si, es una responsabilidad del servicio de powerBI quien es que necesita el token
            var token = await _aadService.GetTokenAadAsync();
            var solicitud = reporte.SolicitarUso(usuarioId, entidadId);
            LoguearEstadoSolicitud(solicitud);
            await _solicitudesRepository.AddAsync(solicitud);
            await _repository.AddOrUpdateAsync(reporte);

            await _powerBiService.ReanudarCapacidadAsync(_nombreCapacidad, token, reporteId, solicitud);

            return solicitud.Aprobada;
        }

        private void LoguearEstadoSolicitud(Solicitud solicitud)
        {
            if(solicitud.Reporte.EsHorarioValido())
            {
                _logger.LogInformation($"La solicitud {solicitud.Id} para el reporte {solicitud.Reporte} en el workspace {solicitud.WorkspaceId} no fue aprobada para el usuario {solicitud.UsuarioId} de la entidad {solicitud.EntidadId} por no estar en un horario valido");
            } 
        }

        private async Task<Reporte> GetReporteAsync(Guid reporteId, Guid workspaceId)
        {
            // TODO: Cambiar crear por leer reporte
            var reporte = await _repository.GetByIdAsync(reporteId);
            if (reporte is null)
                reporte = Reporte.Fabrica.Crear(reporteId, workspaceId);

            return reporte;
        }
    }
}