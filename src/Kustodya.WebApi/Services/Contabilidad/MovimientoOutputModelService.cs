using AutoMapper;
using Kustodya.ApplicationCore.Dtos;
using Kustodya.ApplicationCore.Entities.Contabilidades;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Specifications;
using Kustodya.ApplicationCore.Specifications.Contabilidad;
using Kustodya.WebApi.Models.Contabilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Services.Contabilidades
{
    public class MovimientoOutputModelService : IMovimientoOutputModelService
    {
        private readonly IMapper _mapper;
        private readonly IAsyncContabilidadRepository<Movimiento> _movimientoContableRepo;

        public MovimientoOutputModelService(IMapper mapper,
            IAsyncContabilidadRepository<Movimiento> movimientoContableRepo) {
            _mapper = mapper;
            _movimientoContableRepo = movimientoContableRepo;
        }

        public async Task<OutputModel<MovimientoOutputModel>> GetListaMovimientoOutputModelAsync(int entidadId, string busqueda, int pagina)
        {
            var spec = new MovimientosporCodigoDescripcionTerceroyReferenciaSpec(entidadId, busqueda);
            var movimientos = await _movimientoContableRepo.ListAsync(spec);

            var specTotal = new MovimientosporCodigoDescripcionTerceroyReferenciaSpec(entidadId, busqueda, null);
            var total = await _movimientoContableRepo.CountAsync(specTotal);

            movimientos = movimientos.Where(c => c.Eliminado == false).ToList();

            if (movimientos is null)
                return null;

            var movimientosmodel = _mapper.Map<List<MovimientoOutputModel>>(movimientos);
            
            var movimientosOutputModel = new OutputModel<MovimientoOutputModel>(movimientosmodel, pagina, total);
            
            return movimientosOutputModel;
        }

        public async Task<OutputModel<MovimientoOutputModel>> GetListaMovimientoOutputModelAsync(int entidadId, Guid depuracionContableId, string busqueda, int pagina)
        {
            var spec = new MovimientosPorDepuracionContableyBusqueda(entidadId, depuracionContableId, busqueda);
            var movimientos = await _movimientoContableRepo.ListAsync(spec);

            var specTotal = new MovimientosPorDepuracionContableyBusqueda(entidadId, depuracionContableId, busqueda, null);
            var total = await _movimientoContableRepo.CountAsync(specTotal);

            if (movimientos is null)
                return null;

            var movimientosmodel = _mapper.Map<List<MovimientoOutputModel>>(movimientos);
            
            var movimientosOutputModel = new OutputModel<MovimientoOutputModel>(movimientosmodel, pagina, total);
            
            return movimientosOutputModel;
        }

        public async Task<DetalleMovimientoOutputModel> ObtenerMovimientoPorIdAsync(Guid Id, int entidadId)
        {
            var movimientoSpec = new NoEliminadaPaginadaPorEntidadYIdSpec<Movimiento>(Id, entidadId);
            var movimiento = await _movimientoContableRepo.GetOneAsync(movimientoSpec);
            return _mapper.Map<DetalleMovimientoOutputModel>(movimiento);
        }
    }
}
