using AutoMapper;
using Kustodya.ApplicationCore.DTOs.MallaValidadora.ModelosDeEntrada;
using Kustodya.ApplicationCore.Entities.MallaValidadora;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Services;
using Kustodya.Incapacidades.Data;
using Kustodya.MallaValidadora;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Kustodya.Incapacidades
{
    public class IncapacidadService
    {
        public IncapacidadService(IAsyncCosmosRepository<Incapacidad> incapacidadRepo,
                                  IMapper mapper,
                                  IIncapacidadService service,
                                  IAsyncRepository<Diagnostico> diagnosticoRepo)
        {
            _incapacidadRepo = incapacidadRepo;
            _mapper = mapper;
            _service = service;
            _diagnosticoRepo = diagnosticoRepo;
        }

        private readonly IAsyncCosmosRepository<Incapacidad> _incapacidadRepo;
        private readonly IMapper _mapper;
        private readonly IIncapacidadService _service;
        private readonly IAsyncRepository<Diagnostico> _diagnosticoRepo;

        public async Task CrearAsync(Incapacidad incapacidad)
        {
            await _incapacidadRepo.AddAsync(incapacidad);
        }

        public async Task ValidarAsync(List<IncapacidadInputModel> modelosDeEntradaIncapacidades)
        {
            var incapacidades = _mapper.Map<List<Incapacidad>>(modelosDeEntradaIncapacidades);

            foreach(var incapacidad in incapacidades)
            {
                var diagnosticoSpec = new DiagnosticoSpec(incapacidad.CodigoCie10);
                incapacidad.Diagnostico = await _diagnosticoRepo.GetOneAsync(diagnosticoSpec);

                incapacidad.Validar();
            }
            await _incapacidadRepo.AddRangeAsync(incapacidades);
        }
    }

}
