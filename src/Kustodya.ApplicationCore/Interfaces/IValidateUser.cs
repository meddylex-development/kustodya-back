using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.Interfaces
{
    public interface IValidateUser
    {
        Task Validar(int id);
    }
}