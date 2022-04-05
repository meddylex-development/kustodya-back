using System;
using System.Threading.Tasks;
using Kustodya.ApplicationCore.DTOs.Contabilidades;
using Kustodya.ApplicationCore.Entities.Contabilidades;


namespace Kustodya.ApplicationCore.Services
{
    public interface IContabilidadService
    {
        Task<Entities.Contabilidades.Contabilidad> CrearOActualizarContabilidadAsync(ContabilidadInputModel inputModel, int entidadId);
        Task EliminarContabilidad(string code, int entidadId);
        Task<Entities.Contabilidades.Contabilidad> ObtenerContabilidadConPUCyCentrosporId(Guid Id);
        Task<Entities.Contabilidades.Contabilidad> ObtenerContabilidadPorCodigo(string codigo, int entidadId);
        
    }
}