using AutoMapper;
using Kustodya.ApplicationCore.Constants;
using Kustodya.ApplicationCore.DTOs;
using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Entities.General;
using Kustodya.ApplicationCore.Entities.Medicos;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Specifications;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.Services
{
    public class MedicoService : IMedicoService
    {
        public MedicoService(IRethusService rethusService,
                               IAsyncRepository<Medico> medicoRepo,
                               IMapper mapper,
                               IOptionsMonitor<MedicoServiceOptions> options)
        {
            _options = options.CurrentValue;
            DiasObsolencia = _options.DiasObsolencia;
            _rethusService = rethusService;
            _mapper = mapper;
            _medicoRepo = medicoRepo;
        }

        private readonly MedicoServiceOptions _options;
        private readonly IAsyncRepository<Medico> _medicoRepo;
        private readonly IRethusService _rethusService;
        private readonly IMapper _mapper;
        private readonly int DiasObsolencia; 

        public async Task<Medico> GetMedicoAsync(string documentNumber, TipoIdentificacion identificationType)
        {
            var medicoSpecification = new MedicoSpecification(documentNumber, identificationType);
            var medicoLocal = await _medicoRepo.GetOneAsync(medicoSpecification);

            // Return the current medico if exists and is not too old
            if (!(medicoLocal is null) && medicoLocal.UltimaActualizacion >= DateTime.Now.AddDays(-DiasObsolencia))
                return medicoLocal;

            var medicoRethus = await _rethusService.GetPhysicianAsync(documentNumber, identificationType);
            if (medicoRethus.PrimerNombre == null && medicoRethus.PrimerApellido == null)
            {
                medicoRethus.TNumeroIdentificacion = documentNumber;
                medicoRethus.TIdValorTipoIdentificacion = (int)identificationType;
            }

            return await CreateOrUpdateAsync(medicoLocal, medicoRethus);
        }

        private async Task<Medico> CreateOrUpdateAsync(Medico medicoLocal, RethusResponse medicoRethus)
        {
            // Create
            if (medicoLocal is null)
            {
                medicoLocal = _mapper.Map<Medico>(medicoRethus);
                medicoLocal.UltimaConsulta = DateTime.Now;
                return await _medicoRepo.AddAsync(medicoLocal);
            }

            // Update current employee 
            medicoLocal = _mapper.Map(medicoRethus, medicoLocal);
            medicoLocal.UltimaConsulta = DateTime.Now;
            await _medicoRepo.UpdateAsync(medicoLocal);

            return medicoLocal;
        }
    }
}
