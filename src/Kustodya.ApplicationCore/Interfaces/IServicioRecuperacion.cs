using System.Threading.Tasks;
using Kustodya.ApplicationCore.Entities;

namespace Kustodya.ApplicationCore.Interfaces
{
    public interface IServicioRecuperacion
    {
        Task Recuperar(string origin, string template, string requestPasswordUrl, TblUsuarios u);
    }
}