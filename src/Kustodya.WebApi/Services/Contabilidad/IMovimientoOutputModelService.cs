using Kustodya.WebApi.Models.Contabilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Services.Contabilidades
{
    public interface IMovimientoOutputModelService
    {
        Task<OutputModel<MovimientoOutputModel>> GetListaMovimientoOutputModelAsync(int entidadId, string busqueda, int pagina);
        Task<OutputModel<MovimientoOutputModel>> GetListaMovimientoOutputModelAsync(int entidadId, Guid depuracionContableId, string busqueda, int pagina);
        Task<DetalleMovimientoOutputModel> ObtenerMovimientoPorIdAsync(Guid Id, int entidadId);
    }
}
