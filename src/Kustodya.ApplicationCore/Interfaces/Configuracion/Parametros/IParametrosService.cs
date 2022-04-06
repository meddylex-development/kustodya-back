using Kustodya.ApplicationCore.Dtos.General;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.Interfaces.Configuracion.Parametros
{
    public interface IParametrosService
    {
        Task<ICollection<ParametrosModel>> GetAllParameters();

        Task<ParametrosModel> GetParameterByIdentificator(string identificator);
    }
}