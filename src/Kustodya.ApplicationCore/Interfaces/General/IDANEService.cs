using Kustodya.ApplicationCore.Dtos.General;
using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.Interfaces.General
{
    public interface IDANEService
    {
        Task<UbicacionModel> GetUbicacionById(int iddane);
    }
}