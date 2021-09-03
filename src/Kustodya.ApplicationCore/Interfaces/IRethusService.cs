using Kustodya.ApplicationCore.Constants;
using Kustodya.ApplicationCore.DTOs;
using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.Interfaces
{
    public interface IRethusService
    {
        Task<RethusResponse> GetPhysicianAsync(string identification, TipoIdentificacion identificacion);
    }
}