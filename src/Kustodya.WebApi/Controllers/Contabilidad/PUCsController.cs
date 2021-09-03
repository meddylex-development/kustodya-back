using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Kustodya.ApplicationCore.DTOs.Contabilidades;
using Kustodya.ApplicationCore.Entities.Contabilidades;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Services;
using Kustodya.ApplicationCore.Services.Contabilidades;
using Kustodya.WebApi.Models;
using Kustodya.WebApi.Models.Contabilidades;
using Kustodya.WebApi.Services.Contabilidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Kustodya.ApplicationCore.Entities.Contabilidades.Puc;

namespace Kustodya.WebApi.Controllers.Contabilidades
{
    [Route("api/[controller]")]
    [ApiController]
    public class PUCsController : BaseController
    {
        #region Dependency Injection
        private IPUCOutputModelService _pucOutputModelService;
        private IPUCInputModelService _pucInputModelService;
        private IPUCService _pucService;
        private IContabilidadService _contabilidadService;
        private IExcelService _ExcelService;
        private IMapper _mapper;
        private IAsyncContabilidadRepository<ApplicationCore.Entities.Contabilidades.Contabilidad> _repoContabilidad;
        private IAsyncContabilidadRepository<Puc> _repoPUC;
        public PUCsController(
            IPUCOutputModelService pucOutputModelService, IExcelService ExcelService, 
            IPUCService pucService, IPUCInputModelService pucInputModelService, IMapper mapper,
            IAsyncContabilidadRepository<ApplicationCore.Entities.Contabilidades.Contabilidad> contabilidad,
            IContabilidadService contabilidadService,
            IAsyncContabilidadRepository<Puc> repoPUC)
        {
            _pucOutputModelService = pucOutputModelService;
            _ExcelService = ExcelService;
            _pucService = pucService;
            _pucInputModelService = pucInputModelService;
            _mapper = mapper;
            _repoContabilidad = contabilidad;
            _contabilidadService = contabilidadService;
            _repoPUC = repoPUC;
        }
        #endregion
        [HttpGet]
        public async Task<IActionResult> ObtenerPUCs([FromQuery] string busqueda, [FromQuery] string contabilidad, 
            [FromQuery] TiposContabilidad? tipoContabilidad, [FromQuery] bool exportar = false, [FromQuery] int pagina = 1, [FromQuery] int tamanoPagina = 10)
        {
            GetEntidadId(out int entidadId);
            if (!exportar)
            {
                var PUCs = await _pucOutputModelService.GetListaPUCOutputModel(busqueda, contabilidad, tipoContabilidad, pagina, tamanoPagina);
                return Ok(PUCs);
            }
            else {
                string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                string fileName = "PUC.xlsx";
                var pucsRepo = await _pucOutputModelService.GetListaPUC(busqueda, contabilidad, tipoContabilidad);
                byte[] archivoExcel = await _ExcelService.PUCtoExcel(pucsRepo, entidadId);
                return File(archivoExcel, contentType, fileName);
            }
        }

        [HttpPut]
        public async Task<IActionResult> ImportarPUC([FromForm] ArchivoModel model) {
            GetEntidadId(out int entidadId);
            var stream = new MemoryStream();
            await model.File.CopyToAsync(stream);
            stream.Position = 0;
            DataTable dt = _ExcelService.ExceltoDataTable(stream);
            IReadOnlyList<PUCInputModel> pucsInput;
            //Validar Archivo
            try
            {
                pucsInput = await _pucInputModelService.GetInputModel(dt, entidadId);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }

            //ActualizarPUC
            await _pucService.ActualizarPUC(pucsInput, entidadId);
            return Ok();
        }

        /// <summary>
        /// Elimina los pucs tipo otro de una entidad por contabilidad
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpDelete()]
        public async Task<IActionResult> EliminarPUCs(Guid contabilidadId) {
            GetEntidadId(out int entidadId);
            var contabilidad = await _contabilidadService.ObtenerContabilidadConPUCyCentrosporId(contabilidadId);
            contabilidad.EliminarPucs();
            await _repoContabilidad.UpdateAsync(contabilidad);
            return Ok();
        }

        [HttpGet("Plantilla")]
        public async Task<IActionResult> ObtenerPlantilla() {

            GetEntidadId(out int entidadId);
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            string fileName = "PlantillaPUC.xlsx";
            byte[] archivoExcel = await _ExcelService.PlantillaPUC(entidadId);
            return File(archivoExcel, contentType, fileName);
        }
    }
}