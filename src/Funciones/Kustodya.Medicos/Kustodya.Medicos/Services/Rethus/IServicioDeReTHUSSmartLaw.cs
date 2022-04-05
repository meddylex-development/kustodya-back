
using Kustodya.Medicos.Models;
using System.Threading.Tasks;
using Kustodya.ApplicationCore.Constants;
using System.Collections.Generic;
using Kustodya.Medicos.Services.Input;

namespace Kustodya.Medicos.Services
{
    public interface IServicioDeReTHUSSmartLaw
    {
        Task<RethusResponseModel> ConsultarUnMedicoAsync(string documentNumber, TipoIdentificacion tipo);
        Task<RethusResponseModel> GetMedicosAsync(ICollection<Registro> registros);
        Task<RethusResponseModel> GetMedicosAsync(ICollection<Registro> registros, int usuarioId);
    }
}

