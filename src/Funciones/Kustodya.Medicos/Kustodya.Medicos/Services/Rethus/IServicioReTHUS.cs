using System.Threading.Tasks;
using Kustodya.ApplicationCore.Constants;
using System.Collections.Generic;
using Kustodya.Medicos.Services.Input;
using Kustodya.Medicos.Models;

namespace Kustodya.Medicos.Services
{
    public interface IServicioReTHUS
    {
        Task<RethusResponseModel> ConsultarUnMedicoAsync(string numeroIdentificacion, Roojo.Rethus.TipoIdentificacion tipoIdentificacion);
    }
}