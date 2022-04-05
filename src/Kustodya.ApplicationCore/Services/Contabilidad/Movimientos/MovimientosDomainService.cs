using System;
using System.Threading.Tasks;
using Kustodya.ApplicationCore.DTOs.Contabilidades;
using Kustodya.ApplicationCore.Entities.Contabilidades;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Services;
using Kustodya.ApplicationCore.Specifications;

namespace Kustodya.ApplicationCore.Services.Contabilidades
{

    public class MovimientoDomainService
: BaseDomainService<Movimiento, MovimientoInputModel, IAsyncContabilidadRepository<Movimiento>>
    {
        private IAsyncContabilidadRepository<DepuracionContable> _repoDepuracionesContables;
        private IAsyncContabilidadRepository<TipoAjuste> _repoTipoAjuste;
        private IAsyncContabilidadRepository<CentroCosto> _repoCentroCostos;

        public MovimientoDomainService(
            IAsyncContabilidadRepository<Movimiento> repo
            , IAsyncContabilidadRepository<DepuracionContable> repoDepuraciones
            , IAsyncContabilidadRepository<TipoAjuste> repoTipoAjuste
            , IAsyncContabilidadRepository<CentroCosto> repoCentroCostos
        )
            : base(repo)
        {
            _repoTipoAjuste = repoTipoAjuste;
            _repoDepuracionesContables = repoDepuraciones;
            _repoCentroCostos = repoCentroCostos;
        }

        public override async Task<Movimiento> ActualizarAsync(int entidadId, Guid movimientoId, MovimientoInputModel inputModel, int userId)
        {
            var movimientoSpec = new NoEliminadaPaginadaPorEntidadYIdSpec<Movimiento>(movimientoId, entidadId);
            var movimiento = await _repo.GetOneAsync(movimientoSpec);
            AsegurarNoNulo(movimiento);

            var depuracionSpec = new NoEliminadaPaginadaPorEntidadYIdSpec<DepuracionContable>(movimiento.DepuracionContableId, entidadId);
            var depuracionContable = await _repoDepuracionesContables.GetOneAsync(depuracionSpec);
            AsegurarNoNulo(depuracionContable);

            var tipoAjusteSpec = new NoEliminadaPaginadaPorEntidadYIdSpec<TipoAjuste>(inputModel.TipoAjusteId, entidadId);
            var tipoAjuste = await _repoTipoAjuste.GetOneAsync(tipoAjusteSpec);
            AsegurarNoNulo(tipoAjuste);
            
            var centroCostosSpec = new NoEliminadaPaginadaPorEntidadYIdSpec<CentroCosto>(inputModel.CentroCostoId, entidadId);
            var centroCostos = await _repoCentroCostos.GetOneAsync(centroCostosSpec);
            AsegurarNoNulo(centroCostos);

            movimiento.Actualizar(inputModel);

            return movimiento;
        }

        public override async Task<Movimiento> CrearAsync(int usuarioId, int entidadId, Guid depuracionContableId, MovimientoInputModel inputModel)
        {
            var depuracionSpec = new NoEliminadaPaginadaPorEntidadYIdSpec<DepuracionContable>(depuracionContableId, entidadId);

            var depuracionContable = await _repoDepuracionesContables.GetOneAsync(depuracionSpec);
            AsegurarNoNulo(depuracionContable);

            var tipoAjusteSpec = new NoEliminadaPaginadaPorEntidadYIdSpec<TipoAjuste>(inputModel.TipoAjusteId, entidadId);

            var tipoAjuste = await _repoTipoAjuste.GetOneAsync(tipoAjusteSpec);
            AsegurarNoNulo(tipoAjuste);

            var movimiento = Movimiento.Nuevo.DesdeInputModel(inputModel, depuracionContable);

            return await _repo.AddAsync(movimiento);
        }
    }
}