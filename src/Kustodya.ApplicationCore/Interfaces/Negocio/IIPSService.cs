using Kustodya.ApplicationCore.Dtos.Negocio;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kustodya.ApplicationCore.Entities;

namespace Kustodya.ApplicationCore.Interfaces.Negocio
{
    public interface IIPSService
    {
        Task<IReadOnlyList<IPSModel>> GetAllIPSByEps(int IIdeps);
        Task<IPSModel> GetIPSById(long idips);
        Task<IPSModel> GetIPSByName(string centroAtencion);
    }
}