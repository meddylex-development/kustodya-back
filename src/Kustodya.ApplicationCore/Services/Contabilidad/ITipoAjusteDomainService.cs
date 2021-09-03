using System.Threading.Tasks;
using Kustodya.ApplicationCore.DTOs.Contabilidades;
using Kustodya.ApplicationCore.Entities.Contabilidades;

namespace Kustodya.ApplicationCore.Services
{
    public interface ITipoAjusteDomainService
    {
        Task<TipoAjuste> ActualizarAsync(string decripcion, TipoAjusteInputModel inputModel, string codigoContabilidad, int entidadId);
        Task<TipoAjuste> CrearAsync(TipoAjusteInputModel inputModel, string codigoContabilidad, int entidadId);
        Task EliminarAsync(string descripcion, string codigoContabilidad, int entidadId);
    }

}