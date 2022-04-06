using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Interfaces.Incapacidades;
using Kustodya.ApplicationCore.Specifications.Incapacidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kustodya.Infrastructure.Services.Incapacidades
{
    public class Cie10Service : ICie10Service
    {
        private readonly IAsyncRepository<TblCie10> _cie10Repository;
        private readonly ILoggerService<Cie10Service> _logger;

        public Cie10Service(IAsyncRepository<TblCie10> cie10Repository, ILoggerService<Cie10Service> logger)
        {
            _cie10Repository = cie10Repository;
            _logger = logger;
        }

        public async Task<IReadOnlyList<TblCie10>> GetCie10(int IIdtipoCie)
        {
            var cieSpec = new Cie10Spec(IIdtipoCie, true);
            var cie10 = await _cie10Repository.ListAsync(cieSpec);
            return cie10;
        }

        public async Task<TblCie10> GetCie10ById(int IIdcie10)
        {
            var cieSpec = new Cie10Spec(IIdcie10);
            var cie10 = await _cie10Repository.GetOneAsync(cieSpec);
            return cie10;
        }

        public async Task<TblCie10> GetCie10BytCie10(string idCie10)
        {
            var cieSpec = new Cie10Spec(idCie10);
            var cie10 = await _cie10Repository.GetOneAsync(cieSpec).ConfigureAwait(false);
            return cie10;
        }
        public async Task<IReadOnlyCollection<TblCie10>> GetCie10()
        {
            return await _cie10Repository.ListAllAsync();
        }
    }
}