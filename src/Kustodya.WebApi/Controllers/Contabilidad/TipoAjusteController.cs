using System.Threading.Tasks;
using Kustodya.ApplicationCore.DTOs.Contabilidades;
using Kustodya.ApplicationCore.Entities.Contabilidades;
using Kustodya.ApplicationCore.Services;
using Kustodya.WebApi.Controllers.Contabilidades.Modelo;
using Kustodya.WebApi.Models.Contabilidades;
using Microsoft.AspNetCore.Mvc;

namespace Kustodya.WebApi.Controllers.Contabilidades
{
    [Route("api/[controller]/")]
    public class TipoAjusteController : BaseController
    {
        private readonly ITipoAjusteDomainService _domainService;
        private readonly ITipoAjusteOutputModelService _outputModelService;

        public TipoAjusteController(
            ITipoAjusteOutputModelService outputModelService
            , ITipoAjusteDomainService domainService
            )
        {
            _domainService = domainService;
            _outputModelService = outputModelService;
        }

        [HttpGet("/api/TiposAjuste/")]
        public async Task<IActionResult> Get(string busqueda, int pagina = 1)
        {
            GetEntidadId(out int entidadId);

            OutputModel<TipoAjusteOutputModel> tiposAjuste = null;
            try
            {
                tiposAjuste = await _outputModelService
                    .GetOutputModelsAsync(entidadId, busqueda, pagina);
            }
            catch (EntidadNoExisteException)
            {
                return NotFound();
            }

            return Ok(tiposAjuste);
        }

        [HttpGet("/api/Contabilidades/{codigoContabilidad}/TiposAjuste/{descripcion}")]
        public async Task<IActionResult> GetConContabilidad(string descripcion, string codigoContabilidad)
        {
            GetEntidadId(out int entidadId);

            TipoAjusteOutputModel tipoAjusteDocumento = null;
            try
            {
                tipoAjusteDocumento = await _outputModelService
                    .GetOutputModelAsync(codigoContabilidad, entidadId, descripcion);
            }
            catch (EntidadNoExisteException)
            {
                return NotFound();
            }

            return Ok(tipoAjusteDocumento);
        }

        [HttpGet("/api/Contabilidades/{codigoContabilidad}/TiposAjuste/")]
        public async Task<IActionResult> GetLista(string busqueda, string codigoContabilidad, int pagina = 1)
        {
            GetEntidadId(out int entidadId);

            var tiposDocumento = await _outputModelService
                .GetOutputModelsAsync(codigoContabilidad, entidadId, busqueda, pagina);

            if (tiposDocumento is null) return NotFound();

            return Ok(tiposDocumento);
        }

        [HttpPost]
        [Route("/api/Contabilidades/{codigoContabilidad}/TiposAjuste/")]
        public async Task<IActionResult> Post(TipoAjusteInputModel inputModel, string codigoContabilidad)
        {
            GetEntidadId(out int entidadId);
            TipoAjuste tipoAjuste;
            try
            {
                tipoAjuste = await _domainService.CrearAsync(inputModel, codigoContabilidad, entidadId);
            }
            catch (EntidadYaExisteException ex)
            {
                return Conflict(ex.Message);
            }
            catch (EntidadNoExisteException ex)
            {
                return NotFound(ex.Message);
            }

            if (tipoAjuste is null) return NotFound("No se pudo crear");

            return CreatedAtAction(nameof(Get), new { descripcion = inputModel.Descripcion });
        }

        [HttpPut]
        [Route("/api/Contabilidades/{codigoContabilidad}/TiposAjuste/{descripcion}")]
        public async Task<IActionResult> Put(string descripcion, TipoAjusteInputModel inputModel, string codigoContabilidad)
        {
            GetEntidadId(out int entidadId);

            TipoAjuste tipoAjuste;// = new ClaseDocumento();
            try
            {
                tipoAjuste = await _domainService.ActualizarAsync(descripcion, inputModel, codigoContabilidad, entidadId);
            }
            catch (EntidadNoExisteException)
            {
                return NotFound();
            }

            if (tipoAjuste is null) return NotFound();

            return NoContent();
        }

        [HttpDelete]
        [Route("/api/Contabilidades/{codigoContabilidad}/TiposAjuste/{descripcion}")]
        public async Task<IActionResult> Delete(string descripcion, string codigoContabilidad)
        {
            GetEntidadId(out int entidadId);

            try
            {
                await _domainService.EliminarAsync(descripcion, codigoContabilidad, entidadId);
            }
            catch (EntidadNoExisteException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }


}