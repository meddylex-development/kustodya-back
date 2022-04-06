using AutoMapper;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Specifications;
using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Dtos.Multivalores;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kustodya.ApplicationCore.Interfaces.General;
using Kustodya.ApplicationCore.Constants;

namespace Kustodya.BusinessLogic.Services.General
{
    

    public class MultivaloresServices : IMultivaloresService
    {
        private readonly ILoggerService<MultivaloresServices> _logger;
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<TblMultivalores> _multivaloresRepository;

        public MultivaloresServices(IAsyncRepository<TblMultivalores> multivaloresRepository,
            IMapper mapper, ILoggerService<MultivaloresServices> logger)
        {
            _multivaloresRepository = multivaloresRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<TblMultivalores>> GetDatosSubtabla(Subtabla subtabla)
        {
            if (subtabla == Subtabla.TipoAtencion)
            {

            }
            MultivaloresSpec multivaloresSpec = new MultivaloresSpec((int)subtabla);
            var multivalores = await _multivaloresRepository.ListAsync(multivaloresSpec).ConfigureAwait(false);

            return multivalores;
        }

        public async Task<MultivaloresModel> GetMultivalorById(long tipoAtencion)
        {
            MultivaloresSpec multivaloresSpec = new MultivaloresSpec(tipoAtencion);
            var multivalores = await _multivaloresRepository.GetOneAsync(multivaloresSpec).ConfigureAwait(false);
            var model = _mapper.Map<MultivaloresModel>(multivalores);
            return model;
        }
    }
}