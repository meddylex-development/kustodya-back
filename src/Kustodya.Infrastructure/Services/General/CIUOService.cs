using AutoMapper;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Specifications.General;
using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Dtos.General;
using System.Threading.Tasks;
using Kustodya.ApplicationCore.Interfaces.General;

namespace Kustodya.BusinessLogic.Services.General
{
    public class CIUOService : ICIUOService
    {
        private readonly IAsyncRepository<TblCiuo08> _ciuoRepository;
        //private readonly ILoggerService<CIUOService> _logger;
        private readonly IMapper _mapper;

        public CIUOService(IAsyncRepository<TblCiuo08> ciuoRepository,
            IMapper mapper)
        {
            _ciuoRepository = ciuoRepository;
            _mapper = mapper;
        }

        public async Task<OcupacionModel> GetOcupacionById(short idciuo08)
        {
            var spec = new CIUOSpec(idciuo08);
            var tbl = await _ciuoRepository.GetOneAsync(spec).ConfigureAwait(false);
            var ubicacion = _mapper.Map<OcupacionModel>(tbl);
            return ubicacion;
        }
    }
}