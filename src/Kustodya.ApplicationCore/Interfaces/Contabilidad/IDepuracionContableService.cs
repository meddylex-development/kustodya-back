using Kustodya.ApplicationCore.Entities.Contabilidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.Interfaces.Contabilidades
{
    public interface IDepuracionContableService
    {
        Task<IReadOnlyList<CentroCosto>> GetCentrosConTexto(string busqueda, int? skip = null, int? take = null);
        Task<IReadOnlyList<DepuracionContable>> GetDepuracionContableConSubcuenta(int busqueda, DateTime fechaDesde, DateTime fechaHasta, int? skip = null, int? take = null);
        Task<IReadOnlyList<DepuracionContable>> GetEncabezadosConSegmentoyClase(Guid? segmento, string busqueda, DateTime fechaDesde, DateTime fechaHasta, int? skip = null, int? take = null);
        Task<IReadOnlyList<Movimiento>> GetDetallesConCodigoYNumumeroDeComprobante(int busqueda, DateTime fechaDesde, DateTime fechaHasta, int? skip = null, int? take = null);
        Task<IReadOnlyList<Movimiento>> GetDetallesConTexto(string busqueda, DateTime fechaDesde, DateTime fechaHasta, int? skip = null, int? take = null);
        Task<DepuracionContable> GetDepuracionContable(Guid encabezadoId);
        
    }
}
