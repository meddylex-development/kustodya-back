using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Constants;
using Kustodya.ApplicationCore.Dtos.Multivalores;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.Interfaces.General
{
    public interface IMultivaloresService
    {
        Task<IReadOnlyList<TblMultivalores>> GetDatosSubtabla(Subtabla subtabla);

        Task<MultivaloresModel> GetMultivalorById(long tipoAtencion);
    }
}