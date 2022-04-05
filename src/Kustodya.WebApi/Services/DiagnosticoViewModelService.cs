using AutoMapper;
using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Specifications.Rehabilitaciones;
using Kustodya.WebApi.Models.Rehabilitaciones;
using Kustodya.WebApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Services
{
    public class DiagnosticoViewModelService: IDiagnosticoViewModelService
    {
        private readonly IAsyncRepository<TblCie10DiagnosticoIncapacidad> _diagnosticosChrbRepository;
        private readonly IMapper _mapper;

        public DiagnosticoViewModelService(IAsyncRepository<TblCie10DiagnosticoIncapacidad> diagnosticosChrbRepository,
            IMapper mapper)
        {
            _diagnosticosChrbRepository = diagnosticosChrbRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<DiagnosticoChrbModel>> CreateViewModel(int iIDDiagnosticoIncapacidad)
        {
            var diagnosticosChrbSpec = new DiagnosticosChrbSpec(iIDDiagnosticoIncapacidad);
            var diagnosticosChrb = await _diagnosticosChrbRepository.ListAsync(diagnosticosChrbSpec).ConfigureAwait(false);
            List<DiagnosticoChrbModel> result = _mapper.Map<List<DiagnosticoChrbModel>>(diagnosticosChrb.Take(5));

            return result;
        }
    }
}
