using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Kustodya.ApplicationCore.DTOs.Contabilidades;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Services;
using Kustodya.ApplicationCore.Services.Contabilidades;
using Kustodya.WebApi.Models;
using Kustodya.WebApi.Services.Contabilidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kustodya.WebApi.Controllers.Contabilidades
{
    [Route("api/[controller]")]
    [ApiController]
    public class CentrosCostoController : BaseController
    {
        #region Dependency Injection
        private ICentroOutputModelService _centroOutputModelService;
        private IExcelService _ExcelService;
        private ICentroInputModelService _centroInputModelService;
        private ICentroService _centroService;
        private IContabilidadService _contabilidadService;
        private IAsyncContabilidadRepository<ApplicationCore.Entities.Contabilidades.Contabilidad> _repoContabilidad;
        public CentrosCostoController(ICentroOutputModelService centroOutputModelService, IExcelService ExcelService,
            ICentroInputModelService centroInputModelService, IContabilidadService contabilidadService,
            IAsyncContabilidadRepository<ApplicationCore.Entities.Contabilidades.Contabilidad> repoContabilidad,
            ICentroService centroService) {
            _centroOutputModelService = centroOutputModelService;
            _ExcelService = ExcelService;
            _centroInputModelService = centroInputModelService;
            _contabilidadService = contabilidadService;
            _repoContabilidad = repoContabilidad;
            _centroService = centroService;
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> ObtenerCentros([FromQuery] string busqueda, 
            [FromQuery] bool exportar = false, [FromQuery] int pagina = 1, [FromQuery] int tamanoPagina = 10)
        {
            GetEntidadId(out int entidadId);
            if (!exportar)
            {
                var centros = await _centroOutputModelService.GetListaCentrosOutputModel(busqueda, pagina, tamanoPagina);
                return Ok(centros);
            }
            else
            {
                string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                string fileName = "Centros de Costo.xlsx";
                var centrosRepo = await _centroOutputModelService.GetListaCentros(busqueda);
                byte[] archivoExcel = await _ExcelService.CentrostoExcel(centrosRepo, entidadId);
                return File(archivoExcel, contentType, fileName);
            }
        }

        [HttpPut]
        public async Task<IActionResult> ImportarCentro([FromForm] ArchivoModel model)
        {
            GetEntidadId(out int entidadId);
            var stream = new MemoryStream();
            await model.File.CopyToAsync(stream);
            stream.Position = 0;
            DataTable dt = _ExcelService.ExceltoDataTable(stream);
            IReadOnlyList<CentroInputModel> centrosInput;
            //Validar Archivo
            try
            {
                centrosInput = await _centroInputModelService.GetInputModel(dt, entidadId);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }

            //ActualizarPUC
            await _centroService.ActualizarCentros(centrosInput, entidadId);
            return Ok();
        }

        /// <summary>
        /// Elimina los pucs tipo otro de una entidad por contabilidad
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpDelete()]
        public async Task<IActionResult> EliminarCentros(Guid contabilidadId)
        {
            GetEntidadId(out int entidadId);
            var contabilidad = await _contabilidadService.ObtenerContabilidadConPUCyCentrosporId(contabilidadId);
            contabilidad.EliminarPucs();
            await _repoContabilidad.UpdateAsync(contabilidad);
            return Ok();
        }

        [HttpGet("Plantilla")]
        public async Task<IActionResult> ObtenerPlantilla()
        {
            GetEntidadId(out int entidadId);
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            string fileName = "Plantilla centro de costos.xlsx";
            byte[] archivoExcel = await _ExcelService.PlantillaCentroCostos(entidadId);
            return File(archivoExcel, contentType, fileName);
        }
    }
}