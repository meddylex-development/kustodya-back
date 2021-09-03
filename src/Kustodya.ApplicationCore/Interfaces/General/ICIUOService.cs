using Kustodya.ApplicationCore.Dtos.General;
using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.Interfaces.General
{
    public interface ICIUOService
    {
        Task<OcupacionModel> GetOcupacionById(short idciuo08);
    }
}