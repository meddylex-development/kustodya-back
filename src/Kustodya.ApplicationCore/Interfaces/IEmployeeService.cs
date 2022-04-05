using Kustodya.ApplicationCore.Constants;
using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Entities.General;
using Kustodya.ApplicationCore.Entities.Medicos;
using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.Interfaces
{
    public interface IMedicoService
    {
        Task<Medico> GetMedicoAsync(string documentNumber, TipoIdentificacion identificationType);
    }
}