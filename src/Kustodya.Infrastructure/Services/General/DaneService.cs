using AutoMapper;
using Kustodya.Entities.Specifications.General;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Dtos.General;
using System.Linq;
using System.Threading.Tasks;
using Kustodya.ApplicationCore.Interfaces.General;

namespace Kustodya.BusinessLogic.Services.General
{
    public class DaneService : IDANEService
    {
        private readonly IAsyncRepository<TblDivipola> _daneRepository;
        private readonly ILoggerService<DaneService> _logger;
        private readonly IMapper _mapper;

        public DaneService(IAsyncRepository<TblDivipola> daneRepository, IMapper mapper, ILoggerService<DaneService> logger)
        {
            _daneRepository = daneRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<UbicacionModel> GetUbicacionById(int iddane)
        {
            var ubicacionspec = new DaneSpec(iddane);
            var ubicacionTbl = await _daneRepository.ListAsync(ubicacionspec).ConfigureAwait(false);
            var ubicacion = _mapper.Map<UbicacionModel>(ubicacionTbl.ElementAt(0));
            return ubicacion;
        }
    }
}