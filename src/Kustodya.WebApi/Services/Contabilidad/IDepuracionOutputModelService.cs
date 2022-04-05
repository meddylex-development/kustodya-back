using Kustodya.ApplicationCore.Entities.Contabilidades;
using Kustodya.WebApi.Models.Contabilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Services.Contabilidades
{
    public interface IDepuracionOutputModelService
    {
        Task<DepuracionesOutputModel> GetListaDepuracionOutputModelAsync(int entidadId, string busqueda, DepuracionContable.CausaDepuracion? causaDepuracion,
            DepuracionContable.EstadoPago? estadoPago, int pagina, int tamanoPagina, int userId, DepuracionContable.EstadoDepuracion? estadoDepuracion);
        DetalleDepuracionOutputModel GetOutputModel(DepuracionContable depuracionContable);
        Task<DetalleDepuracionOutputModel> ObtenerDepuracionPorIdAsync(Guid Id, int entidadId, int userId);
        Task<byte[]> GenerarPDF(Guid Id, int entidadId, string access_token);
    }
}
