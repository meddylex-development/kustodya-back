using AutoMapper;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Interfaces.General;
using Kustodya.ApplicationCore.Specifications.General;
using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Dtos.General;
using System.Threading.Tasks;

namespace Kustodya.BusinessLogic.Services.General
{
    public class CIIUService : ICIIUService
    {
        private readonly IAsyncRepository<TblCiiu> _ciuuRepository;
        private readonly ILoggerService<CIIUService> _logger;
        private readonly IMapper _mapper;

        public CIIUService(
            IMapper mapper,
            ILoggerService<CIIUService> logger,
            IAsyncRepository<TblCiiu> ciuuRepository
            )
        {
            _mapper = mapper;
            _logger = logger;
            _ciuuRepository = ciuuRepository;
        }

        public async Task<ActividadEconomicaModel> GetCIIUById(short? idactividadEconomica1)
        {
            CIUUSpec spec = new CIUUSpec((short)idactividadEconomica1);
            var tbl = await _ciuuRepository.GetOneAsync(spec).ConfigureAwait(false);
            var ubicacion = _mapper.Map<ActividadEconomicaModel>(tbl);
            return ubicacion;
        }
    }
}