using Kustodya.ApplicationCore.Entities.Contabilidades;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Interfaces.Contabilidades;
using Kustodya.ApplicationCore.Specifications.Contabilidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.Services
{/*
    public class DepuracionContableService : IDepuracionContableService
    {
        #region Dependency Injection
        private readonly IAsyncRepository<CentroCosto> _centroBeneficioRepo;
        private readonly IAsyncRepository<DepuracionContable> _repoDepuracionContable;
        private readonly IAsyncRepository<Movimiento> _repoDetalle;
        #endregion

        public DepuracionContableService(IAsyncRepository<CentroCosto> centroBeneficioRepo,
            IAsyncRepository<DepuracionContable> repoDepuracionContable,
            IAsyncRepository<Movimiento> repoDetalle)
        {
            _centroBeneficioRepo = centroBeneficioRepo;
            _repoDepuracionContable = repoDepuracionContable;
            _repoDetalle = repoDetalle;
        }
        public async Task<IReadOnlyList<CentroCosto>> GetCentrosConTexto(string busqueda = "", int? skip = null, int? take = null)
        {
            var spec = new CentroBeneficioPorCodigoSpec(busqueda, skip, take);
            var requests = await _centroBeneficioRepo.ListAsync(spec);
            return requests;
        }

        public async Task<IReadOnlyList<DepuracionContable>> GetDepuracionContableConSubcuenta(int busqueda, DateTime fechaDesde, DateTime fechaHasta, int? skip = null, int? take = null)
        {
            //buscar por subcuenta
            var spec = new DepuracionContableConSubcuentaSpec(busqueda, fechaDesde, fechaHasta, 0, int.MaxValue);
            return await _repoDepuracionContable.ListAsync(spec);

        }
        public async Task<IReadOnlyList<Movimiento>> GetDetallesConCodigoYNumumeroDeComprobante(int busqueda, DateTime fechaDesde, DateTime fechaHasta, int? skip = null, int? take = null)
        {
            //buscar por Codigo contable y numero de comprobante de cierre
            var spec = new DetallesConCodigoDeNumeroComprobanteSpec(busqueda, fechaDesde, fechaHasta, 0, int.MaxValue);
            return await _repoDetalle.ListAsync(spec);

        }
        public async Task<IReadOnlyList<DepuracionContable>> GetEncabezadosConSegmentoyClase(Guid? segmento, string busqueda, DateTime fechaDesde, DateTime fechaHasta, int? skip = null, int? take = null)
        {
            // buscar por segmento y clase 
            var spec = new DepuracionContableConSegmentoYClase(segmento, busqueda, fechaDesde, fechaHasta, 0, int.MaxValue);
            return await _repoDepuracionContable.ListAsync(spec);
        }
        public async Task<IReadOnlyList<Movimiento>> GetDetallesConTexto(string busqueda, DateTime fechaDesde, DateTime fechaHasta, int? skip = null, int? take = null)
        {
            var spec = new MovimientoConTextoSpec(busqueda, fechaDesde, fechaHasta, 0, int.MaxValue);
            return await _repoDetalle.ListAsync(spec);
        }
        public async Task<DepuracionContable> GetDepuracionContable(Guid depuracionContableId)
        {
            return await _repoDepuracionContable.GetByIdAsync(depuracionContableId);
        }
    }
*/
}
