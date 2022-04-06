using AutoMapper;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Interfaces.Configuracion.Parametros;
using Kustodya.ApplicationCore.Specifications.Configuracion.Parametros;
using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Dtos.General;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kustodya.BusinessLogic.Services.Configuracion.Parametros
{
    public class ParametrosService : IParametrosService
    {
        private readonly ILoggerService<ParametrosService> _logger;
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<TblParametrosEmpresas> _repositoryParametros;

        public ParametrosService(
            ILoggerService<ParametrosService> logger,
            IAsyncRepository<TblParametrosEmpresas> repositoryParametros,
            IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _repositoryParametros = repositoryParametros;
        }

        public async Task<ICollection<ParametrosModel>> GetAllParameters()
        {
            IReadOnlyList<TblParametrosEmpresas> lParametros = await _repositoryParametros.ListAllAsync().ConfigureAwait(false);
            ICollection<ParametrosModel> lModels = new List<ParametrosModel>();
            foreach (TblParametrosEmpresas param in lParametros)
            {
                lModels.Add(_mapper.Map<ParametrosModel>(param));
            }
            return lModels;
        }

        public async Task<ParametrosModel> GetParameterByIdentificator(string identificator)
        {
            var parametroSpec = new ParametrosSpec(identificator);
            TblParametrosEmpresas parametro = await _repositoryParametros.GetOneAsync(parametroSpec).ConfigureAwait(false);
            return _mapper.Map<ParametrosModel>(parametro);
        }
    }
}