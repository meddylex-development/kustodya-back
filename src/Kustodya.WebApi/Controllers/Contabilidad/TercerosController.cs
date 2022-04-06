using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Kustodya.ApplicationCore.Constants;
using Kustodya.ApplicationCore.DTOs.Contabilidades;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Services.Contabilidades;
using Kustodya.WebApi.Models;
using Kustodya.WebApi.Services.Contabilidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kustodya.WebApi.Controllers.Contabilidades
{
    [Route("api/[controller]")]
    [ApiController]
    public class TercerosController : BaseController
    {
        #region Dependency Injection
        private ITerceroOutputModelService _terceroOutputModelService;
        private ITerceroInputModelService _terceroInputModelService;
        private IExcelService _ExcelService;
        private ITerceroService _terceroService;
        public TercerosController(
            ITerceroOutputModelService terceroOutputModelService,
            IExcelService ExcelService,
            ITerceroInputModelService terceroInputModelService,
            ITerceroService terceroService
        )
        { 
            _terceroOutputModelService = terceroOutputModelService;
            _ExcelService = ExcelService;
            _terceroInputModelService = terceroInputModelService;
            _terceroService = terceroService;
        }
        #endregion
        [HttpGet]
        public async Task<IActionResult> ObtenerTerceros([FromQuery] string busqueda, [FromQuery] TiposPersona? tipoPersona, 
            [FromQuery] bool exportar = false, [FromQuery] int pagina = 1, [FromQuery] int tamanoPagina = 10)
        {
            if (!exportar)
            {
                var terceros = await _terceroOutputModelService.GetListaTercerosOutputModel(busqueda, tipoPersona, pagina, tamanoPagina);
                return Ok(terceros);
            }
            else
            {
                string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                string fileName = "Terceros.xlsx";
                var tercerosRepo = await _terceroOutputModelService.GetListaTerceros(busqueda, tipoPersona);
                byte[] archivoExcel = _ExcelService.TercerotoExcel(tercerosRepo);
                return File(archivoExcel, contentType, fileName);
            }
        }
        [HttpPut]
        public async Task<IActionResult> ImportarTerceros([FromForm] ArchivoModel model)
        {
            GetEntidadId(out int entidadId);
            var stream = new MemoryStream();
            await model.File.CopyToAsync(stream);
            stream.Position = 0;
            DataTable dt = _ExcelService.ExceltoDataTable(stream);
            IReadOnlyList<TerceroInputModel> tercerosInput;
            //Validar Archivo
            try
            {
                tercerosInput = _terceroInputModelService.GetInputModel(dt, entidadId);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }

            //ActualizarPUC
            await _terceroService.ActualizarTerceros(tercerosInput, entidadId);
            return Ok();
        }

        [HttpDelete()]
        public async Task<IActionResult> EliminarTerceros()
        {
            GetEntidadId(out int entidadId);
            await _terceroService.EliminarTerceros(entidadId);
            return Ok();
        }

        [HttpGet("Plantilla")]
        public async Task<IActionResult> ObtenerPlantilla()
        {
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            string fileName = "Plantilla Terceros.xlsx";
            byte[] archivoExcel = _ExcelService.PlantillaTerceros();
            return File(archivoExcel, contentType, fileName);
        }
    }   
}