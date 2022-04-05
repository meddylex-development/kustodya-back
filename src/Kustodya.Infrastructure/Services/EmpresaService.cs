using AutoMapper;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Specifications;
using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Dtos;
using Kustodya.ApplicationCore.Dtos.General;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kustodya.ApplicationCore.Interfaces.General;

namespace Kustodya.Infrastructure.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly ICIIUService _CIIUService;
        private readonly IAsyncRepository<TblEmpresas> _empresaRepository;
        private readonly ILoggerService<EmpresaService> _logger;
        private readonly IMapper _mapper;

        public EmpresaService(
            IAsyncRepository<TblEmpresas> empresaRepository,
            ILoggerService<EmpresaService> logger,
            ICIIUService CIIUService,
            IMapper mapper)
        {
            _empresaRepository = empresaRepository;
            _logger = logger;
            _mapper = mapper;
            _CIIUService = CIIUService;
        }

        public async Task<EmpresaTercerosModel> GetEmpresaById(long id)
        {
            var empresaSpec = new EmpresaSpec(id);
            var empresa = await _empresaRepository.GetOneAsync(empresaSpec).ConfigureAwait(false);
            ActividadEconomicaModel actividadEconomica = await _CIIUService.GetCIIUById(empresa.IIdactividadEconomica1).ConfigureAwait(false);
            EmpresaTercerosModel model = _mapper.Map<EmpresaTercerosModel>(empresa);
            model.ActividadEconomica = actividadEconomica;
            return model;
        }

        public async Task<IList<EmpresaTercerosModel>> GetEmpresasByName(string name)
        {
            var empresaSpec = new EmpresaSpec(name, false);
            var lEmpresas = await _empresaRepository.ListAsync(empresaSpec).ConfigureAwait(false);
            var lModels = new List<EmpresaTercerosModel>();
            foreach (TblEmpresas empresa in lEmpresas)
            {
                lModels.Add(_mapper.Map<EmpresaTercerosModel>(empresa));
            }
            return lModels;
        }

        public async Task<EmpresaTercerosModel> GetEmpresasByNIT(string nit)
        {
            var empresaSpec = new EmpresaSpec(nit);
            var empresa = await _empresaRepository.GetOneAsync(empresaSpec).ConfigureAwait(false);
            EmpresaTercerosModel model = _mapper.Map<EmpresaTercerosModel>(empresa);
            return model;
        }

        public async Task<IList<EmpresaModel>> GetEmpresasUsuario(int IIdusuario)
        {
            //TODO CAmbiar metodo JUnto con front de EMpresasModel a EmpresasTerceros
            var empresaSpec = new EmpresaSpec(IIdusuario);
            var lEmpresas = await _empresaRepository.ListAsync(empresaSpec).ConfigureAwait(false);
            var lModels = new List<EmpresaModel>();
            foreach (TblEmpresas model in lEmpresas)
            {
                lModels.Add(_mapper.Map<EmpresaModel>(model));
            }
            return lModels;
        }
    }
}