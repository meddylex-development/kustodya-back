using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Kustodya.ApplicationCore.Entities.Contabilidades;
using Kustodya.ApplicationCore.Services;
using Kustodya.ApplicationCore.Services.Contabilidades;
using Kustodya.WebApi.Models.Contabilidades;
using Kustodya.WebApi.Services.Contabilidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Kustodya.ApplicationCore.Services.DepuracionesContables;
using Kustodya.ApplicationCore.DTOs.DepuracionesContables;
using Kustodya.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authentication;

namespace Kustodya.WebApi.Controllers.Contabilidades
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepuracionesContablesController : BaseController
    {
        #region Dependency Injection
        private IDepuracionOutputModelService _depuracionOutputModelService;
        private IDepuracionContableDomainService _depuracionesDomainService;
        private IAsyncContabilidadRepository<DepuracionContable> _repoDepuracionContable;
        private IMapper _mapper;
        public DepuracionesContablesController(IDepuracionOutputModelService depuracionOutputModelService,
            IDepuracionContableDomainService depuracionInputModelService, IMapper mapper,
            IAsyncContabilidadRepository<DepuracionContable> repoDepuracionContable)
        {
            _depuracionOutputModelService = depuracionOutputModelService;
            _depuracionesDomainService = depuracionInputModelService;
            _mapper = mapper;
            _repoDepuracionContable = repoDepuracionContable;
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> ObtenerDepuraciones(DepuracionContable.EstadoDepuracion? estadodepuracion, [FromQuery] string busqueda, DepuracionContable.CausaDepuracion? causaDepuracion, DepuracionContable.EstadoPago? estadoPago,
            [FromQuery] int pagina = 1, [FromQuery] int tamanoPagina = 10)
        {
            GetEntidadId(out int entidadId);
            
            GetUserId(out int userId);

            var depuraciones = await _depuracionOutputModelService.GetListaDepuracionOutputModelAsync(entidadId, busqueda, causaDepuracion, estadoPago, pagina, tamanoPagina, userId, estadodepuracion);
            return Ok(depuraciones);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerDepuracion(Guid id)
        {
            GetEntidadId(out int entidadId);
            GetUserId(out int userId);
            try
            {
                var depuracion = await _depuracionOutputModelService.ObtenerDepuracionPorIdAsync(id, entidadId, userId);
                if (depuracion is null)
                    return NotFound();
                return Ok(depuracion);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
            
            
        }

        [HttpPost("/api/Contabilidades/{contabilidadId:guid}/DepuracionesContables/")]
        public async Task<IActionResult> Crear(DepuracionContableInputModel inputModel, Guid contabilidadId)
        {
            GetEntidadId(out int entidadId);
            GetUserId(out int usuarioId);
            try
            {
                var depuracionContable = await _depuracionesDomainService.CrearAsync(usuarioId, entidadId, contabilidadId, inputModel);
                var outputModel = _depuracionOutputModelService.GetOutputModel(depuracionContable);
                return CreatedAtAction(nameof(ObtenerDepuracion), new { id = depuracionContable.Id }, outputModel);
            }
            catch (EntidadNoExisteException ex)
            {
                return NotFound(ex.Message);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPut("/api/Contabilidades/{contabilidadId:guid}/DepuracionesContables/{id}")]
        public async Task<IActionResult> ActualizarDepuracion(Guid id, DepuracionContableInputModel depuracionInputModel, Guid contabilidadId)
        {
            DepuracionContable depuracionContable = null;

            GetEntidadId(out int entidadId);
            GetUserId(out int userId);
            depuracionContable = await _repoDepuracionContable.GetByIdAsync(id);
            try
            {
                depuracionContable = await _depuracionesDomainService.ActualizarAsync(entidadId, id, depuracionInputModel, userId);
                AsegurarNoNulo(depuracionContable);
            }
            catch (EntidadNoExisteException ex)
            {
                return NotFound(ex.Message);
            }

            DepuracionOutputModel depuracionOutputModel = _mapper.Map<DepuracionOutputModel>(depuracionContable);
            return Ok(depuracionOutputModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Eliminar(Guid id)
        {
            GetEntidadId(out int entidadId);
            GetUserId(out int userId);
            DepuracionContable depuracionContable = await _repoDepuracionContable.GetByIdAsync(id);
            if (!depuracionContable.Eliminable(userId))
                return Conflict("No es posible eliminar la depuración por su estado o no tiene permisos para eliminar la depuración");
            try
            {
                await _depuracionesDomainService.EliminarAsync(id, entidadId);
            }
            catch (EntidadNoExisteException ex)
            {
                return NotFound(ex.Message);
            }
            catch (System.Exception)
            {
                throw;
            }

            return NoContent();
        }

        [HttpGet("{depuracionId}/PDF")]
        public async Task<IActionResult> ConstruirPDF(Guid depuracionId)
        {
            GetEntidadId(out int entidadId);
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            byte[] pdf = await _depuracionOutputModelService.GenerarPDF(depuracionId, entidadId, accessToken);
            return File(pdf.ToArray(), "application/pdf", "Depuración Contable.pdf");
        }
    }
}