using System;
using System.Threading.Tasks;
using Kustodya.ApplicationCore.DTOs.Contabilidades;
using Kustodya.ApplicationCore.Entities.Contabilidades;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Services;
using Kustodya.ApplicationCore.Specifications.Contabilidades;
using Kustodya.WebApi.Controllers.Contabilidades.Modelo;
using Kustodya.WebApi.Models.Contabilidades;
using Microsoft.AspNetCore.Mvc;

namespace Kustodya.WebApi.Controllers.Contabilidades
{
    [Route("api/[controller]/")]
    public class ClasesDocumentoController : BaseController
    {
        #region DI
        private readonly IClaseDocumentoDomainService _domainService;
        private readonly IClasesDocumentoOutputModelService _outputModelService;

        public ClasesDocumentoController(
            IClasesDocumentoOutputModelService outputModelService
            , IClaseDocumentoDomainService domainService
            )
        {
            _domainService = domainService;
            _outputModelService = outputModelService;
        }
        #endregion

        [HttpGet("/api/ClasesDocumento/")]
        public async Task<IActionResult> Get(string busqueda, int pagina = 1)
        {
            GetEntidadId(out int entidadId);

            OutputModel<ClaseDocumentoOutputModel> clasesDocumento = null;
            try
            {
                clasesDocumento = await _outputModelService
                    .GetOutputModelsAsync(entidadId, busqueda, pagina);
            }
            catch (EntidadNoExisteException)
            {
                return NotFound();
            }

            return Ok(clasesDocumento);
        }

        [HttpGet("/api/Contabilidades/{codigoContabilidad}/ClasesDocumento/{descripcion}")]
        public async Task<IActionResult> GetConContabilidad(string descripcion, string codigoContabilidad)
        {
            GetEntidadId(out int entidadId);

            ClaseDocumentoOutputModel claseDocumento = null;
            try
            {
                claseDocumento = await _outputModelService
                    .GetOutputModelAsync(codigoContabilidad, entidadId, descripcion);
            }
            catch (EntidadNoExisteException)
            {
                return NotFound();
            }

            return Ok(claseDocumento);
        }

        [HttpGet("/api/Contabilidades/{codigoContabilidad}/ClasesDocumento/")]
        public async Task<IActionResult> GetLista(string busqueda, string codigoContabilidad, int pagina = 1)
        {
            GetEntidadId(out int entidadId);

            var clasesDocumento = await _outputModelService
                .GetOutputModelsAsync(codigoContabilidad, entidadId, busqueda, pagina);

            if (clasesDocumento is null) return NotFound();

            return Ok(clasesDocumento);
        }

        [HttpPost]
        [Route("/api/Contabilidades/{codigoContabilidad}/ClasesDocumento/")]
        public async Task<IActionResult> Post(ClaseDocumentoInputModel inputModel, string codigoContabilidad)
        {
            GetEntidadId(out int entidadId);
            ClaseDocumento claseDocumento;
            try
            {
                claseDocumento = await _domainService.CrearAsync(inputModel, codigoContabilidad, entidadId);
            }
            catch (EntidadYaExisteException ex)
            {
                return Conflict(ex.Message);
            }
            catch(EntidadNoExisteException ex)
            {
                return NotFound(ex.Message);
            }

            if (claseDocumento is null) return NotFound();

            return CreatedAtAction(nameof(Get), new { descripcion = inputModel.Descripcion });
        }

        [HttpPut]
        [Route("/api/Contabilidades/{codigoContabilidad}/ClasesDocumento/{descripcion}")]
        public async Task<IActionResult> Put(string descripcion, ClaseDocumentoInputModel inputModel, string codigoContabilidad)
        {
            GetEntidadId(out int entidadId);

            ClaseDocumento claseDocumento;// = new ClaseDocumento();
            try
            {
                claseDocumento = await _domainService.ActualizarAsync(descripcion, inputModel, codigoContabilidad, entidadId);
            }
            catch (EntidadNoExisteException)
            {
                return NotFound();
            }

            if (claseDocumento is null) return NotFound();

            return NoContent();
        }

        [HttpDelete]
        [Route("/api/Contabilidades/{codigoContabilidad}/ClasesDocumento/{descripcion}")]
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
            catch(EntidadUsadaNoSePuedeEliminarException ex)
            {
                return Conflict(ex.Message);
            }

            return NoContent();
        }
    }
}