using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using Kustodya.ApplicationCore.DTOs.Contabilidades;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Services;
using Kustodya.ApplicationCore.Specifications.Contabilidades;
using Kustodya.WebApi.Models.Contabilidades;
using Kustodya.WebApi.Services.Contabilidades;
using Microsoft.AspNetCore.Mvc;
using Kustodya.ApplicationCore.Entities.Contabilidades;

namespace Kustodya.WebApi.Controllers.Contabilidades

{
    [Route("api/[controller]")]
    [ApiController]
    public class ContabilidadesController : BaseController
    {
        #region Dependency Injection
        private IContabilidadOutputModelService _contabilidadOutputModelService;
        private IContabilidadService _contabilidadService;
        private IMapper _mapper;

        public ContabilidadesController(
            IContabilidadOutputModelService contabilidadOutputModelService
            , IContabilidadService contabilidadService
            , IMapper mapper
            )
        {
            _contabilidadOutputModelService = contabilidadOutputModelService;
            _contabilidadService = contabilidadService;
            _mapper = mapper;
        }
        #endregion

        [HttpGet("{codigo}")]
        public async Task<IActionResult> GetContabilidad(string codigo)
        {
            GetEntidadId(out int entidadId);
            var contabilidad = await _contabilidadService.ObtenerContabilidadPorCodigo(codigo, entidadId);
            if (contabilidad is null)
                return NotFound();
            var output = _mapper.Map<ContabilidadOutputModel>(contabilidad);
            return Ok(output);
        }

        [HttpGet()]
        public async Task<IActionResult> GetContabilidad([FromQuery] string busqueda, int pagina)
        {
            GetEntidadId(out int entidadId);
            var contabilidades = await _contabilidadOutputModelService.GetListaContabilidadOutputModel(busqueda, entidadId, pagina);
            if (contabilidades.Contabilidades.Count == 0)
                return NotFound();

            return Ok(contabilidades);
        }

        [HttpPut]
        [ProducesResponseType(typeof(ContabilidadInputModel), 200)]
        public async Task<IActionResult> PostContabilidad([Required] ContabilidadInputModel inputModel)
        {
            GetEntidadId(out int entidadId);
            if (entidadId == 0)
                return Forbid();

            ApplicationCore.Entities.Contabilidades.Contabilidad contabilidad;
            try
            {
                contabilidad = await _contabilidadService.CrearOActualizarContabilidadAsync(inputModel, entidadId);
            }
            catch(EntidadNoExisteException ex)
            {
                return BadRequest(ex.Message);
            } 
            catch (PucNoExisteException ex)
            {
                return BadRequest($"PUC con codigo \"" + ex.Message + "\" no existe");
            }
            if (contabilidad is null)
                return NotFound();

            var outputmodel = await _contabilidadOutputModelService.GetContabilidadOutputModel(contabilidad);

            return CreatedAtAction(nameof(GetContabilidad), new { codigo = contabilidad.Codigo }, outputmodel);
        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> DeleteContabilidad(string codigo)
        {
            GetEntidadId(out int entidadId);
            try
            {
                await _contabilidadService.EliminarContabilidad(codigo, entidadId);
            }
            catch (EntidadNoExisteException ex)
            {
                return NotFound($"La contabilidad con id: {ex.Message}, no existe");
            }

            return NoContent();
        }
    }
}