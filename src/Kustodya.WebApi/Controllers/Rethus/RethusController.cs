using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Kustodya.ApplicationCore.Constants;
using Kustodya.ApplicationCore.DTOs.Rethus;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.WebApi.Models.Rethus;
using Kustodya.WebApi.Services.Rethus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kustodya.WebApi.Controllers.Rethus
{
    [Route("api/[controller]")]
    [ApiController]
    public class RethusController : BaseController
    {
        private IRethusModelService _rethusModelService;
        private IExcelService _ExcelService;

        public RethusController(IRethusModelService rethusModelService, IExcelService ExcelService)
        {
            _rethusModelService = rethusModelService;
            _ExcelService = ExcelService;
        }

        [HttpGet]
        [Route("IdentificationTypes")]
        public async Task<IActionResult> ObtenerIdentificaciones()
        {
            var identificaciones = await _rethusModelService.GetIdentificaciones();
            return Ok(identificaciones);
        }

        [HttpGet]
        [Route("Medico")]
        public async Task<IActionResult> ConsultarMedicos(string documento, string tipo, string PrimerNombre, string PrimerApellido)
        {
            bool eslista = false;
            int resultado = 0;
            int.TryParse(tipo, out resultado);
            if (resultado > 0)
            {
                eslista = true;
            }
            if (tipo == "2")
            {
                tipo = "CE";
            }
            else if (tipo != null)
            {
                tipo = "CC";
            }
            if (tipo == null)
                eslista = true;

            var medicos = await _rethusModelService.GetMedicos(documento, tipo, PrimerNombre, PrimerApellido);
            if (eslista)
            {
                var medico = medicos.FirstOrDefault();
                if (medico == null && tipo != null && documento != null)
                {
                    //insertar en la tabla de task y queries
                    await _rethusModelService.AddTask(tipo, documento);
                    medicos = await _rethusModelService.GetMedicos(documento, tipo, PrimerNombre, PrimerApellido);
                    int contador = 0;
                    while (medico == null && contador < 5)
                    {
                        Thread.Sleep(5000);
                        medicos = await _rethusModelService.GetMedicos(documento, tipo, PrimerNombre, PrimerApellido);
                        if (medicos.Count() > 0)
                        {
                            List<MedicosOutputModel> mOM = new List<MedicosOutputModel>();
                            foreach (var item in medicos)
                            {
                                mOM.Add(new MedicosOutputModel
                                {
                                    TipoIdentificacion = item.tTipoIdentificacion,
                                    NumeroIdentificacion = item.tNrodentificacion,
                                    PrimerNombre = item.tPrimerNombre,
                                    SegundoNombre = item.tSegundoNombre,
                                    PrimerApellido = item.tPrimerApellido,
                                    SegundoApellido = item.tSegundoApellido,
                                    RegistradoEnRethus = item.tEstadoIdentificacion
                                });
                            }
                            return Ok(mOM);
                        }
                        contador++;
                    }
                    return Ok(new List<MedicosOutputModel>());
                }
                else
                {
                    List<MedicosOutputModel> mOM = new List<MedicosOutputModel>();
                    foreach (var item in medicos)
                    {
                        mOM.Add(new MedicosOutputModel
                        {
                            TipoIdentificacion = item.tTipoIdentificacion,
                            NumeroIdentificacion = item.tNrodentificacion,
                            PrimerNombre = item.tPrimerNombre,
                            SegundoNombre = item.tSegundoNombre,
                            PrimerApellido = item.tPrimerApellido,
                            SegundoApellido = item.tSegundoApellido,
                            RegistradoEnRethus = item.tEstadoIdentificacion
                        });
                    }
                    return Ok(mOM);
                }
            }
            else
            {
                var medico = medicos.OrderByDescending(c => c.iIDMainData).FirstOrDefault();
                if (medico == null)
                    return Ok();
                var respuesta = (new MedicoOutputModel
                {
                    TipoIdentificacion = medico.tTipoIdentificacion,
                    NumeroIdentificacion = medico.tNrodentificacion,
                    PrimerNombre = medico.tPrimerNombre,
                    SegundoNombre = medico.tSegundoNombre,
                    PrimerApellido = medico.tPrimerApellido,
                    SegundoApellido = medico.tSegundoApellido,
                    RegistradoEnRethus = medico.tEstadoIdentificacion,
                });

                var academicos = await _rethusModelService.GetAcademicos(medico.iIDRethusQuery);
                List<MedicoDetalleOutputModel> detalles = new List<MedicoDetalleOutputModel>();
                foreach (var academico in academicos)
                {
                    detalles.Add(new MedicoDetalleOutputModel
                    {
                        tipoProgramaOrigen = academico.tTipoPrograma,
                        tituloObtenido = academico.tOrigenObtencionTitulo,
                        ocupacion = academico.tProfesionOcupacion,
                        autorizadoParaEjercerHasta = academico.tFechaInicioEjercerActoAdmin,
                        actoAdministrativo = academico.tActoAdministrativo,
                        entidadQueReporta = academico.tEntidadReportadora
                    });
                }
                respuesta.Detalles = detalles;

                var sancionesI = await _rethusModelService.GetSanciones(medico.iIDRethusQuery);
                List<SancionesMedicoOutputModel> sanciones = new List<SancionesMedicoOutputModel>();
                foreach (var sancion in sancionesI)
                {
                    sanciones.Add(new SancionesMedicoOutputModel
                    {
                        instanciaEmiteFallo = sancion.tInstanciaEmiteFallo,
                        codigoTipoSancion = sancion.tCodTipoSancion,
                        fechaEjecucion = sancion.tFechaEjecucion,
                        fechaInicio = sancion.tFechaInicio,
                        fechaFin = sancion.tFehaFin,
                    });
                }
                respuesta.Sanciones = sanciones;

                var datosSsoI = await _rethusModelService.GetSso(medico.iIDRethusQuery);
                List<DatosSsoOutputModel> datosSso = new List<DatosSsoOutputModel>();
                foreach (var datosso in datosSsoI)
                {
                    datosSso.Add(new DatosSsoOutputModel
                    {
                        tipoPrestacion = datosso.tTipoPrestacion,
                        tipoLugarPrestacion = datosso.tTipoLugarPrestacion,
                        lugarPresentacion = datosso.tLugarPrestacion,
                        fechaInicio = datosso.tFechaInicio,
                        fechaFin = datosso.tFechaFin,
                        modalidadPrestacion = datosso.tModalidadPrestacion,
                        programaPrestacion = datosso.tProgramaPrestacion,
                        entidadReportadora = datosso.tEntidadReportadora
                    });
                }
                respuesta.DatosSso = datosSso;

                return Ok(respuesta);
            }
        }

        [HttpPut]
        [Route("CargueMasivo")]
        public async Task<IActionResult> CargueMasivo([FromForm] Kustodya.WebApi.Models.ArchivoModel model)
        {
            GetEntidadId(out int entidadId);
            var stream = new MemoryStream();    
            await model.File.CopyToAsync(stream);
            stream.Position = 0;
            DataTable dt = _ExcelService.csvtoDataTable(stream);
            IReadOnlyList<CargueInputModel> pucsInput;
            //Validar Archivo
            try
            {
                pucsInput = _rethusModelService.GetInputModel(dt);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }

            //Crear tarea para el robot
            await _rethusModelService.CrearTareaRobot(pucsInput, entidadId);
            return Ok();
        }
        [HttpGet]
        [Route("ConsultarCargue")]
        public async Task<IActionResult> GetCargues()
        {
            GetEntidadId(out int entidadId);
            var cargues = await _rethusModelService.GetCargues(entidadId);
            return Ok(cargues);


        }

        [HttpGet]
        [Route("ExportarCargue/{taskId}")]
        public async Task<IActionResult> ExportarCargue(int taskId)
        {
            //GetEntidadId(out int entidadId);
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            string fileName = "CargueRethusMedicos.xlsx";
            byte[] archivoExcel = await _rethusModelService.ExportarCargue(taskId);
            return File(archivoExcel, contentType, fileName);
        }
    }
}