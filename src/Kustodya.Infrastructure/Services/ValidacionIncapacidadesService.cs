using AutoMapper;
using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Entities.MallaValidadora;
using Kustodya.ApplicationCore.Entities.Medicos;
using Kustodya.ApplicationCore.Interfaces;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kustodya.Infrastructure.Services
{
    public class ValidacionIncapacidadesService : IValidacionIncapacidadesService
    {
        public ValidacionIncapacidadesService(IServiceBusPersisterConnection serviceBus, IMapper mapper)
        {
            _serviceBus = serviceBus;
            _mapper = mapper;
        }

        private IServiceBusPersisterConnection _serviceBus { get; set; }
        private IMapper _mapper { get; set; }

        public async Task<Guid> SolicitarAsync(TblDiagnosticosIncapacidades diagnosticoIncapacidad)
        {
            var incapacidad = _mapper.Map<Incapacidad>(diagnosticoIncapacidad);
            incapacidad.ValidacionId = Guid.NewGuid();

            var message = new Message(Encoding.Unicode.GetBytes(JsonConvert.SerializeObject(incapacidad)));
            var topicClient = _serviceBus.CreateModel();

            await topicClient.SendAsync(message);

            return incapacidad.ValidacionId;
        }
    }
}
