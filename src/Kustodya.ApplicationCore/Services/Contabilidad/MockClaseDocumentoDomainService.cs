using System.Threading.Tasks;
using Kustodya.ApplicationCore.DTOs.Contabilidades;
using Kustodya.ApplicationCore.Entities.Contabilidades;
using System;

namespace Kustodya.ApplicationCore.Services
{
    public class MockClaseDocumentoDomainService : IClaseDocumentoDomainService
    {
        public Task<ClaseDocumento> ActualizarAsync(string decripcion, ClaseDocumentoInputModel inputModel, string codigoContabilidad, int entidadId)
        {
            return Task.Run(() =>
            new ClaseDocumento(Guid.NewGuid(), decripcion)
            {
                Contabilidad = new Entities.Contabilidades.Contabilidad(entidadId, codigoContabilidad, "Vaca pal almuerzo")
            });
        }

        public Task<ClaseDocumento> CrearAsync(ClaseDocumentoInputModel inputModel, string codigoContabilidad, int entidadId)
        {
            return Task.Run(() => new ClaseDocumento(Guid.NewGuid(), inputModel.Descripcion)
            {
                Contabilidad = new Entities.Contabilidades.Contabilidad(entidadId, codigoContabilidad, "Vaca pal almuerzo")
            });
        }

        public Task EliminarAsync(string descripcion, string codigoContabilidad, int entidadId)
        {
            return Task.CompletedTask;
        }
    }
}