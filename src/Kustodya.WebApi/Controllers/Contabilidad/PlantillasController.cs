using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kustodya.ApplicationCore.Services.Contabilidades;
using Kustodya.WebApi.Services.Contabilidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Kustodya.ApplicationCore.DTOs.Contabilidades;
using Kustodya.ApplicationCore.Entities.Contabilidades;

namespace Kustodya.WebApi.Controllers.Contabilidades
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantillasController : BaseController
    {
        #region Dependency Injection
        private IPlantillaOutputModelService _plantillaOutputModelService;
        private IPlantillaService _plantillaService;
        private IPlantillaInputModelService _plantillaInputModelService;

        public PlantillasController(IPlantillaOutputModelService plantillaOutputModelService, IPlantillaService plantillaService,
            IPlantillaInputModelService plantillaInputModelService)
        {
            _plantillaOutputModelService = plantillaOutputModelService;
            _plantillaService = plantillaService;
            _plantillaInputModelService = plantillaInputModelService;
        }
        #endregion
        [HttpGet]
        public async Task<IActionResult> ObtenerPlantillas([FromQuery] string busqueda, [FromQuery] Plantilla.TiposPlantillaContable? tipoPlantilla, [FromQuery] int pagina = 1, [FromQuery] int tamanoPagina = 10)
        {
            GetEntidadId(out int entidadId);
            var plantillas = await _plantillaOutputModelService.GetListaPlantillasOutputModel(entidadId, busqueda, tipoPlantilla, pagina, tamanoPagina);
            return Ok(plantillas);
        }
        [HttpPut("plantillaId")]
        public async Task<IActionResult> ActualizarPlantilla(PlantillaInputModel plantillaInputModel, Guid plantillaId)
        {
            GetEntidadId(out int entidadId);
            //Validar comodines usados
            try
            {
                _plantillaInputModelService.ValidarComodines(plantillaInputModel.Texto);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }

            //Actualizar Plantilla
            try
            {
                await _plantillaService.ActualizarPlantilla(plantillaInputModel, plantillaId, entidadId);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> CrearPlantilla(PlantillaInputModel plantillaInputModel)
        {
            GetEntidadId(out int entidadId);

            //Validar comodines usados
            try
            {
                _plantillaInputModelService.ValidarComodines(plantillaInputModel.Texto);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
            

            //Crear Plantilla
            try
            {
                await _plantillaService.CrearPlantilla(plantillaInputModel, entidadId);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
            return Ok();
        }

        [HttpDelete("{plantillaId}")]
        public async Task<IActionResult> EliminarPlantilla(Guid plantillaId) {
            
            GetEntidadId(out int entidadId);
            try
            {
                await _plantillaService.EliminarPlantilla(plantillaId, entidadId);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
            return Ok();
        }
    }
}