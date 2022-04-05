using System.Threading.Tasks;
using Kustodya.ApplicationCore.DTOs.Contabilidades;
using Kustodya.ApplicationCore.Entities.Contabilidades;

namespace Kustodya.ApplicationCore.Services
{
    public interface IClaseDocumentoDomainService
    {
        Task<ClaseDocumento> ActualizarAsync(string decripcion, ClaseDocumentoInputModel inputModel, string codigoContabilidad, int entidadId);
        Task<ClaseDocumento> CrearAsync(ClaseDocumentoInputModel inputModel, string codigoContabilidad, int entidadId);
        Task EliminarAsync(string descripcion, string codigoContabilidad, int entidadId);
    }

}