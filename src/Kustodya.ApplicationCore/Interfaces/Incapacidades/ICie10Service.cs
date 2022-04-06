using Kustodya.ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.Interfaces.Incapacidades
{
    public interface ICie10Service
    {
        Task<IReadOnlyList<TblCie10>> GetCie10(int IIdtipoCie);

        Task<TblCie10> GetCie10ById(int IIdcie10);
        Task<TblCie10> GetCie10BytCie10(string idCie10);
        Task<IReadOnlyCollection<TblCie10>> GetCie10();
    }
}