using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Entities.Contabilidades;
using Kustodya.ApplicationCore.DTOs.Contabilidades;
using Kustodya.ApplicationCore.Services.Contabilidades;
using Kustodya.ApplicationCore.Services;
using Kustodya.WebApi.Services.Contabilidades;

namespace Kustodya.WebApi.Controllers.Contabilidades
{
    [Route("/api/DepuracionesContables/{padreId}/[Controller]/")]
    public class MovimientosController : BaseControllerCrud<MovimientoInputModel, Movimiento>
    {
        private readonly IMovimientoOutputModelService _movimientoOutputModelService;
        public MovimientosController(
            IDomainService<Movimiento, MovimientoInputModel> movimientoDomainService
            , IMovimientoOutputModelService movimientoOutputModelService)
            : base(movimientoDomainService)
        {
            _movimientoOutputModelService = movimientoOutputModelService;
        }

        public override async Task<IActionResult> GetList(string busqueda, int pagina = 1)
        {
            GetEntidadId(out int entidadId);
            var movimientos = await _movimientoOutputModelService.GetListaMovimientoOutputModelAsync(entidadId, busqueda, pagina);

            if (movimientos is null) return NotFound();
            
            return Ok(movimientos);
        }

        public override async Task<IActionResult> GetList(Guid padreId, string busqueda, int pagina = 1)
        {
            GetEntidadId(out int entidadId);
            var movimientos = await _movimientoOutputModelService.GetListaMovimientoOutputModelAsync(entidadId, padreId, busqueda, pagina);

            if(movimientos is null) return NotFound();

            return Ok(movimientos);
        }

        public override async Task<IActionResult> GetOne(Guid id)
        {
            GetEntidadId(out int entidadId);
            var movimientos = await _movimientoOutputModelService.ObtenerMovimientoPorIdAsync(id, entidadId);
            return Ok(movimientos);
        }
    }
}