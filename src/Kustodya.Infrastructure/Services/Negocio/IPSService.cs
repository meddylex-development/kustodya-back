using AutoMapper;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Interfaces.General;
using Kustodya.ApplicationCore.Interfaces.Negocio;
using Kustodya.ApplicationCore.Specifications.Negocio;
using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Dtos.General;
using Kustodya.ApplicationCore.Dtos.Negocio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kustodya.Infrastructure.Services.Negocio
{
    public class IPSService : IIPSService
    {
        private readonly IDANEService _daneService;
        private readonly IAsyncRepository<TblIps> _ipsRepository;
        private readonly ILoggerService<IPSService> _logger;
        private readonly IMapper _mapper;

        public IPSService(IAsyncRepository<TblIps> ipsRepository, ILoggerService<IPSService> logger,
            IDANEService daneservice, IMapper mapper)
        {
            _ipsRepository = ipsRepository;
            _logger = logger;
            _daneService = daneservice;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<IPSModel>> GetAllIPSByEps(int IIdeps)
        {
            var ipsSpec = new IPSSpec(IIdeps);
            var listIPS = await _ipsRepository.ListAsync(ipsSpec).ConfigureAwait(false);

            List<IPSModel> result = _mapper.Map<List<IPSModel>>(listIPS);

            foreach (var item in result)
            {
                item.Ubicacion = await _daneService.GetUbicacionById(item.Ubicacion.IIdDane).ConfigureAwait(false);
            }

            return result;
        }

        public async Task<IPSModel> GetIPSById(long idips)
        {
            var spec = new IPSSpec(idips);
            var obj = await _ipsRepository.GetOneAsync(spec).ConfigureAwait(false);
            IPSModel ips = _mapper.Map<IPSModel>(obj);
            var dane = await _daneService.GetUbicacionById((int)obj.IIdubicacion).ConfigureAwait(false);
            ips.Ubicacion = _mapper.Map<UbicacionModel>(dane);
            return ips;
        }

        public async Task<IPSModel> GetIPSByName(string centroAtencion)
        {
            var spec = new IPSSpec(centroAtencion);
            var obj = await _ipsRepository.GetOneAsync(spec).ConfigureAwait(false);
            IPSModel ips = _mapper.Map<IPSModel>(obj);
            var dane = await _daneService.GetUbicacionById((int)obj.IIdubicacion).ConfigureAwait(false);
            ips.Ubicacion = _mapper.Map<UbicacionModel>(dane);
            return ips;
        }
    }
}