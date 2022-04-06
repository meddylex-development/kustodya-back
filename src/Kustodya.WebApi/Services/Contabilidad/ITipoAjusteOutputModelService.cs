using System;
using System.Threading.Tasks;
using Kustodya.WebApi.Controllers.Contabilidades.Modelo;
using Kustodya.WebApi.Models.Contabilidades;

namespace Kustodya.WebApi.Controllers.Contabilidades
{
    public interface ITipoAjusteOutputModelService
    {
        Task<OutputModel<TipoAjusteOutputModel>> GetOutputModelsAsync(string codigoContabilidad, int entidadId, string busqueda, int pagina = 1);
        Task<TipoAjusteOutputModel> GetOutputModelAsync(string codigoContabilidad, int entidadId, string descripcion);
        Task<OutputModel<TipoAjusteOutputModel>> GetOutputModelsAsync(int entidadId, string busqueda, int pagina = 1);
        
        

    }

}