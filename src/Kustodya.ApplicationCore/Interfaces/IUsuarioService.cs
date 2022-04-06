using Kustodya.ApplicationCore.Entities;
using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.Interfaces
{
    public interface IUsuarioService
    {
        Task<TblUsuarios> Login(string user, string password);
    }
}