using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using Kustodya.ApplicationCore.Constants;
using Kustodya.ApplicationCore.Dtos;
using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Entities.CalificacionOrigen;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Interfaces.AI;
using Kustodya.ApplicationCore.Interfaces.CalificacionOrigen;
using Kustodya.BussinessLogic.Interfaces.General;
using Kustodya.WebApi.Controllers.CalificacionOrigen.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Kustodya.WebApi.Controllers.CalificacionOrigen
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalificacionOrigenController : BaseController
    {
        private readonly MapperConfiguration _config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfiles>();
            cfg.CreateMap<CorreoOutputModel, Correo>();
            cfg.CreateMap<AdjuntoOutputModel, Adjunto>();
        });
        private readonly ICalificacionOrigenService _repoCalificacionOrigenService;
        private IMapper _mapper;
        private readonly IBlobService _blobService;
        private readonly IOCREngineService _ocrEngineService;
        private readonly IConfiguration _configuration;
        private readonly IUsuariosService _usuariosService;
        public CalificacionOrigenController(
            ICalificacionOrigenService repoCalificacionOrigenService, IBlobService blobService,
            IOCREngineService ocrEngineService, IConfiguration configuration, IUsuariosService usuariosService
            )
        {
            _repoCalificacionOrigenService = repoCalificacionOrigenService;
            _mapper = _config.CreateMapper();
            _blobService = blobService;
            _ocrEngineService = ocrEngineService;
            _configuration = configuration;
            _usuariosService = usuariosService;
        }
        [HttpGet]
        [Route("Correos")]
        public async Task<IActionResult> GetCorreos([FromQuery] string busqueda = "", [FromQuery] int pagina = 1,
            [FromQuery] Correo.EstadoCorreo estadoCorreo = Correo.EstadoCorreo.Por_Gestionar, [FromQuery] long fechaDesde = 978103108000, [FromQuery] long fechaHasta = 4133776708000)
        {
            var correos = await _repoCalificacionOrigenService.ObtenerCorreos(estadoCorreo, busqueda, fechaDesde, fechaHasta, pagina, 10);
            var total = await _repoCalificacionOrigenService.ObtenerCorreos(estadoCorreo, busqueda, fechaDesde, fechaHasta, null, null);
            var output = _mapper.Map<List<CorreoOutputModel>>(correos);
            foreach (var item in output)
            {
                item.FechaCorreo = item.FechaCorreo + (3600000 * 5);
                var FechaTransripcion = correos.Where(c => c.Id == item.Id).First().FechaTranscripcion;
                if (FechaTransripcion != null)
                    item.FechaTranscripcion = ((DateTime)FechaTransripcion).ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
            }

            CorreosOutputModel correosOutputModel = new CorreosOutputModel
            {
                correoOutputModel = output,
                paginacion = new PaginacionModel(total.Count, pagina, 10),
            };
            return Ok(correosOutputModel);
        }
        [HttpGet]
        [Route("AdjuntoId/{guid}")]
        public async Task<IActionResult> GetAdjunto(string guid)
        {
            var archivo = await _repoCalificacionOrigenService.ObtenerNombreArchivo(guid);
            byte[] contenido = _repoCalificacionOrigenService.ObtenerContenidoArchivo(guid);
            switch (archivo.Split('.')[archivo.Split('.').Length -1].ToLower())
            {
                case "pdf":
                    return File(contenido.ToArray(), "application/pdf", archivo); ;
                case "doc":
                    return File(contenido.ToArray(), "application/msword", archivo); ;
                case "bmp":
                    return File(contenido.ToArray(), "image/bmp", archivo); ;
                case "csv":
                    return File(contenido.ToArray(), "text/csv", archivo); ;
                case "docx":
                    return File(contenido.ToArray(), "application/vnd.openxmlformats-officedocument.wordprocessingml.document", archivo); ;
                case "gif":
                    return File(contenido.ToArray(), "image/gif", archivo);
                case "htm":
                    return File(contenido.ToArray(), "text/html", archivo);
                case "html":
                    return File(contenido.ToArray(), "text/html", archivo);
                case "jpeg":
                    return File(contenido.ToArray(), "image/jpeg", archivo);
                case "jpg":
                    return File(contenido.ToArray(), "image/jpeg", archivo);
                case "png":
                    return File(contenido.ToArray(), "image/png", archivo);
                case "ppt":
                    return File(contenido.ToArray(), "application/vnd.ms-powerpoint", archivo);
                case "pptx":
                    return File(contenido.ToArray(), "application/vnd.openxmlformats-officedocument.presentationml.presentation", archivo);
                case "xls":
                    return File(contenido.ToArray(), "application/vnd.ms-excel", archivo);
                case "xlsx":
                    return File(contenido.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", archivo);
                case "xml":
                    return File(contenido.ToArray(), "application/xml", archivo);
                default:
                    return File(contenido.ToArray(), "appliation/octet-stream", archivo);
            }
        }
        [HttpGet("{correoId:int}")]
        public async Task<IActionResult> GetCorreo(int correoId) {
            var correo = await _repoCalificacionOrigenService.ObtenerCorreo(correoId);
            var carta = await _repoCalificacionOrigenService.ObtenerModeloCarta();
            var divipolas = new List<TblDivipola>(); //await _repoCalificacionOrigenService.ObtenerDivipolas();
            var departamentos = (from d in divipolas
                                 select new
                                 {
                                     DeptoOrigen = d.Nombredepto,
                                     DeptoSinTildes = QuitarTildes(d.Nombredepto).ToLower(),
                                     Ciudad = d.Nombremunicipio,
                                     CiudadSinTildes = QuitarTildes(d.Nombremunicipio).ToLower()
                                 }).Distinct().OrderByDescending(c=>c.DeptoOrigen).ToList();
            var ciudades = (from d in divipolas
                            select new
                            {
                                CiudadOrigen = d.Nombremunicipio,
                                CiudadSinTildes = QuitarTildes(d.Nombremunicipio).ToLower()
                            }).Distinct().ToList();
            string departamento = "";
            string ciudad = "";
            if (correo.Asunto.Contains(",")) {
                var posibledepartamento = correo.Asunto.Split(',')[1].Trim();
                if (posibledepartamento.Split(' ')[0].Length > 3)
                {
                    posibledepartamento = posibledepartamento.Split(' ')[0].Trim();
                }
                else {
                    posibledepartamento = posibledepartamento.Split(' ')[0].Trim() + posibledepartamento.Split(' ')[1].Trim();
                }
                posibledepartamento = posibledepartamento.ToLower().Trim();
                posibledepartamento = QuitarTildes(posibledepartamento);

                if (departamentos.Where(c => c.DeptoSinTildes.Contains(posibledepartamento)).Count() > 0)
                {
                    departamento = departamentos.Where(c => c.DeptoSinTildes.Contains(posibledepartamento)).First().DeptoOrigen;

                    var posibleciudad = correo.Asunto.Split(',')[0].Trim();
                    var divisiones = posibleciudad.Split(' ').Count();
                    if (posibleciudad.Split(' ')[divisiones - 1].Length > 3)
                    {
                        posibleciudad = posibleciudad.Split(' ')[divisiones - 1].Trim();
                    }
                    else {
                        posibleciudad = posibleciudad.Split(' ')[divisiones - 2].Trim() + posibleciudad.Split(' ')[divisiones - 1].Trim();
                    }

                    posibleciudad = posibleciudad.ToLower().Trim();
                    posibleciudad = QuitarTildes(posibleciudad);

                    var departamentociudades = departamentos.Where(c => c.DeptoOrigen == departamento).ToList();

                    if (departamentociudades.Where(c => c.CiudadSinTildes.Contains(posibleciudad)).Count() > 0)
                        ciudad = departamentociudades.Where(c => c.CiudadSinTildes.Contains(posibleciudad)).First().Ciudad;
                }
            }

            if (departamento == "")
            {
                foreach (var item in departamentos)
                {
                    if (QuitarTildes(correo.Asunto).ToLower().Contains(item.DeptoSinTildes))
                    {
                        departamento = item.DeptoOrigen;
                        break;
                    }
                }
                foreach (var item in ciudades)
                {
                    if (QuitarTildes(correo.Asunto).ToLower().Contains(item.CiudadSinTildes))
                    {
                        ciudad = item.CiudadOrigen;
                        break;
                    }
                }
            }
            CorreoDetalleOutputModel correoDetalleOutputModel = new CorreoDetalleOutputModel();
            correoDetalleOutputModel.Afp = new PropiedadCorreoDetalleOutputModel();
            correoDetalleOutputModel.Cargo = new PropiedadCorreoDetalleOutputModel();
            correoDetalleOutputModel.Ciudad = new PropiedadCorreoDetalleOutputModel();
            correoDetalleOutputModel.Contrato = new PropiedadCorreoDetalleOutputModel();
            correoDetalleOutputModel.Edad = new PropiedadCorreoDetalleOutputModel();
            correoDetalleOutputModel.Empresa = new PropiedadCorreoDetalleOutputModel();
            correoDetalleOutputModel.EmpresaCorreo = new PropiedadCorreoDetalleOutputModel();
            correoDetalleOutputModel.EnfermedadLaboral = new PropiedadCorreoDetalleOutputModel();
            correoDetalleOutputModel.Eps = new PropiedadCorreoDetalleOutputModel();
            correoDetalleOutputModel.Fecha = new PropiedadCorreoDetalleOutputModel();
            correoDetalleOutputModel.FechaCovid = new PropiedadCorreoDetalleOutputModel();
            correoDetalleOutputModel.Identificacion = new PropiedadCorreoDetalleOutputModel();
            correoDetalleOutputModel.Nombre = new PropiedadCorreoDetalleOutputModel();
            correoDetalleOutputModel.Telefono = new PropiedadCorreoDetalleOutputModel();
            correoDetalleOutputModel.CorreoPaciente = new PropiedadCorreoDetalleOutputModel();
            correoDetalleOutputModel.TipoPrueba = new PropiedadCorreoDetalleOutputModel();
            correoDetalleOutputModel.FechaHistoriaClinica = new PropiedadCorreoDetalleOutputModel();

            //Diligenciar información temporal almacenada

            correoDetalleOutputModel.Afp.Texto = correo.AFP;
            correoDetalleOutputModel.Cargo.Texto = correo.Cargo;
            correoDetalleOutputModel.Ciudad.Texto = correo.Ciudad;
            correoDetalleOutputModel.Contrato.Texto = correo.CodigoCTO;
            correoDetalleOutputModel.Edad.Texto = correo.Edad;
            correoDetalleOutputModel.Empresa.Texto = correo.Empresa;
            correoDetalleOutputModel.EmpresaCorreo.Texto = correo.CorreoEmpresa;
            correoDetalleOutputModel.EnfermedadLaboral.Texto = correo.CodigoEL;
            correoDetalleOutputModel.Eps.Texto = correo.EPS;
            correoDetalleOutputModel.FechaCovid.Texto = correo.FechaCovid;
            correoDetalleOutputModel.Identificacion.Texto = correo.NumeroDocumento;
            correoDetalleOutputModel.Nombre.Texto = correo.NombresYApellidos;
            correoDetalleOutputModel.Telefono.Texto = correo.NumeroTelefonico;
            correoDetalleOutputModel.CorreoPaciente.Texto = correo.CorreoPaciente;
            correoDetalleOutputModel.TipoPrueba.Texto = correo.TipoPrueba;
            correoDetalleOutputModel.FechaHistoriaClinica.Texto = correo.FechaHistoriaClinica;

            if (correo.Ciudad == null)
            {
                correoDetalleOutputModel.Ciudad.Texto = (ciudad.Trim() + " " + departamento.Trim()).Trim();
                correo.Ciudad = correoDetalleOutputModel.Ciudad.Texto;
            }
            else {
                correoDetalleOutputModel.Ciudad.Texto = correo.Ciudad;
            }
            correoDetalleOutputModel.Adjuntos = new List<AdjuntoOutputModel>();
            correo.Asunto = correo.Asunto.Replace("\t", " ");
            if (correo.CodigoEL == null)
            {
                if (correo.Asunto.Contains("EP"))
                {
                    var sentence = correo.Asunto.Split("EP")[1].Trim();
                    correoDetalleOutputModel.EnfermedadLaboral.Texto = sentence.Split(" ")[0];
                    correo.CodigoEL = correoDetalleOutputModel.EnfermedadLaboral.Texto;
                }
                else if (correo.Asunto.Contains("EL"))
                {
                    var sentence = correo.Asunto.Split("EL")[1].Trim();
                    correoDetalleOutputModel.EnfermedadLaboral.Texto = sentence.Split(" ")[0];
                    correo.CodigoEL = correoDetalleOutputModel.EnfermedadLaboral.Texto;
                }
                else if (correo.Asunto.Contains("Caso N°"))
                {
                    var sentence = correo.Asunto.Split("Caso N°")[1].Trim();
                    correoDetalleOutputModel.EnfermedadLaboral.Texto = sentence.Split(" ")[0];
                    correo.CodigoEL = correoDetalleOutputModel.EnfermedadLaboral.Texto;
                }
            }
            else {
                correoDetalleOutputModel.EnfermedadLaboral.Texto = correo.CodigoEL;
            }

            var fechaActual = DateTime.Now.AddHours(-5);
            correoDetalleOutputModel.Fecha.Texto = fechaActual.Date.Day.ToString().PadLeft(2, '0') + "/" + fechaActual.Date.Month.ToString().PadLeft(2, '0') + "/" + fechaActual.Date.Year.ToString().PadLeft(2, '0');

            foreach (Adjunto item in correo.Adjuntos)
            {
                AdjuntoOutputModel adjuntoOutputModel = new AdjuntoOutputModel
                {
                    ArchivoId =item.Contenido,
                    NombreArchivo = item.NombreArchivo
                };
                correoDetalleOutputModel.Adjuntos.Add(adjuntoOutputModel);
                //correoDetalleOutputModel.FechaCovid = DateTime.Now.Date.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
                var extension = item.NombreArchivo.Split('.')[item.NombreArchivo.Split('.').Count() - 1];
                ApplicationCore.Dtos.Incapacidades.OCRExtractionMethodModel OCRModel;
                switch (extension.ToLower())
                {
                    case "docx":
                        string textoReconocido = "";
                        if (item.TextoReconocido == null)
                        {
                            try
                            {
                                OCRModel = await _ocrEngineService.GetOCRTextByAzureBlobId(item.Contenido, OCRExtractionMethod.Word, "calificacionorigencorreos");
                                foreach (var sentence in OCRModel.Sentences)
                                {
                                    textoReconocido = textoReconocido + " " + sentence;
                                }
                                textoReconocido = textoReconocido.Trim();
                                item.TextoReconocido = textoReconocido;
                                await _repoCalificacionOrigenService.ActualizarAdjunto(item);
                            }
                            catch (Exception ex) { continue; }
                        }
                        
                        break;
                    case "jpg":
                        textoReconocido = "";
                        if (item.TextoReconocido == null)
                        {
                            try
                            {
                                OCRModel = await _ocrEngineService.GetOCRTextByAzureBlobId(item.Contenido, OCRExtractionMethod.Tesseract, "calificacionorigencorreos");
                                foreach (var sentence in OCRModel.Sentences)
                                {
                                    textoReconocido = textoReconocido + " " + sentence;
                                }
                                textoReconocido = textoReconocido.Trim();
                                item.TextoReconocido = textoReconocido;
                                await _repoCalificacionOrigenService.ActualizarAdjunto(item);
                            }
                            catch (Exception ex) { continue; }
                        }
                        break;
                    case "png":
                        textoReconocido = "";
                        if (item.TextoReconocido == null)
                        {
                            try
                            {
                                OCRModel = await _ocrEngineService.GetOCRTextByAzureBlobId(item.Contenido, OCRExtractionMethod.Tesseract, "calificacionorigencorreos");
                                foreach (var sentence in OCRModel.Sentences)
                                {
                                    textoReconocido = textoReconocido + " " + sentence;
                                }
                                textoReconocido = textoReconocido.Trim();
                                item.TextoReconocido = textoReconocido;
                                await _repoCalificacionOrigenService.ActualizarAdjunto(item);
                            }
                            catch (Exception ex) { continue; }
                        }
                        break;
                    case "gif":
                        textoReconocido = "";
                        if (item.TextoReconocido == null)
                        {
                            try
                            {
                                OCRModel = await _ocrEngineService.GetOCRTextByAzureBlobId(item.Contenido, OCRExtractionMethod.Tesseract, "calificacionorigencorreos");
                                foreach (var sentence in OCRModel.Sentences)
                                {
                                    textoReconocido = textoReconocido + " " + sentence;
                                }
                                textoReconocido = textoReconocido.Trim();
                                item.TextoReconocido = textoReconocido;
                                await _repoCalificacionOrigenService.ActualizarAdjunto(item);
                            }
                            catch (Exception ex) { continue; }
                        }
                        break;
                    case "pdf":
                        //OCRModel = await _ocrEngineService.GetOCRTextByAzureBlobId(item.Contenido, OCRExtractionMethod.Google_VisionAI, "calificacionorigencorreos");
                        textoReconocido = "";
                        if (item.TextoReconocido == null)
                        {
                            try
                            {
                                OCRModel = await _ocrEngineService.GetOCRTextByAzureBlobId(item.Contenido, OCRExtractionMethod.iTextSharp, "calificacionorigencorreos");
                                foreach (var sentence in OCRModel.Sentences)
                                {
                                    textoReconocido = textoReconocido + " " + sentence;
                                }
                                textoReconocido = textoReconocido.Trim();
                                item.TextoReconocido = textoReconocido;
                                await _repoCalificacionOrigenService.ActualizarAdjunto(item);
                            }
                            catch (Exception) { continue; }
                        }
                        textoReconocido = item.TextoReconocido;
                        if (textoReconocido.Contains("CARGO") && correoDetalleOutputModel.Cargo.Texto == null && textoReconocido.Contains("IDENTIFICACIÓN GENERAL DEL EMPLEADOR") && correo.Cargo == null)
                        {
                            var sentence = textoReconocido;
                            if (sentence != null)
                            {
                                sentence = sentence.Replace("\n", " ");
                                sentence = sentence.Replace("\n", " ").Replace("  ", " ").Replace("  ", " ").Replace("  ", " ").Replace("  ", " ").Replace("  ", " ");
                                sentence = sentence.Split("CARGO")[1];
                                sentence = sentence.Replace("U R", "").Trim();

                                var cargo = sentence.Split(" ")[5] + " " + sentence.Split(" ")[6] + " " + sentence.Split(" ")[7] + " " +
                                    sentence.Split(" ")[8] + " " + sentence.Split(" ")[9] + " " + sentence.Split(" ")[10] + " " + sentence.Split(" ")[11] + " " + sentence.Split(" ")[12] + " " + sentence.Split(" ")[13];

                                if (cargo.Contains(" X "))
                                    cargo = cargo.Split(" X ")[1].Trim();

                                correoDetalleOutputModel.Cargo.Texto = cargo.Split("OCUPACIÓN HABITUAL")[0].Trim();
                                if (correoDetalleOutputModel.Cargo.Texto.EndsWith('X'))
                                    correoDetalleOutputModel.Cargo.Texto = correoDetalleOutputModel.Cargo.Texto.Substring(0, correoDetalleOutputModel.Cargo.Texto.Length - 1).Trim();
                                if (correoDetalleOutputModel.Cargo.Texto.StartsWith('X'))
                                    correoDetalleOutputModel.Cargo.Texto = correoDetalleOutputModel.Cargo.Texto.Substring(1, correoDetalleOutputModel.Cargo.Texto.Length - 1).Trim();
                                correoDetalleOutputModel.Cargo.NombreArchivo = item.NombreArchivo;
                                correoDetalleOutputModel.Cargo.Guid = item.Contenido;
                                correo.Cargo = correoDetalleOutputModel.Cargo.Texto;
                                correo.CargoNombreArchivo = correoDetalleOutputModel.Cargo.NombreArchivo;
                                correo.CargoGuid = correoDetalleOutputModel.Cargo.Guid;
                            }
                        }
                        else {
                            correoDetalleOutputModel.Cargo.Texto = correo.Cargo;
                            correoDetalleOutputModel.Cargo.NombreArchivo = correo.CargoNombreArchivo;
                            correoDetalleOutputModel.Cargo.Guid = correo.CargoGuid;
                        }
                        if (textoReconocido.Contains("GENERO") && correoDetalleOutputModel.Edad.Texto == null && textoReconocido.Contains("IDENTIFICACIÓN GENERAL DEL EMPLEADOR") && correo.Edad == null)
                        {
                            var sentence = textoReconocido;
                            if (sentence != null)
                            {
                                sentence = sentence.Replace("\n", " ");
                                sentence = sentence.Split("GENERO")[1];
                                var fechastring = sentence.Substring(0, 16).Replace(" ", "").Trim();
                                DateTime fecha = DateTime.Now; ;
                                try
                                {
                                    fecha = new DateTime(Convert.ToInt32(fechastring.Substring(4, 4)), Convert.ToInt32(fechastring.Substring(2, 2)), Convert.ToInt32(fechastring.Substring(0, 2)));
                                    correoDetalleOutputModel.Edad.Texto = ((DateTime.Now - fecha).Days / 360).ToString();
                                    correoDetalleOutputModel.Edad.NombreArchivo = item.NombreArchivo;
                                    correoDetalleOutputModel.Edad.Guid = item.Contenido;
                                    correo.Edad = correoDetalleOutputModel.Edad.Texto;
                                    correo.EdadNombreArchivo = correoDetalleOutputModel.Edad.NombreArchivo;
                                    correo.EdadGuid = correoDetalleOutputModel.Edad.Guid;
                                }
                                catch (Exception) { }
                            }
                        }
                        else {
                            correoDetalleOutputModel.Edad.Texto = correo.Edad;
                            correoDetalleOutputModel.Edad.NombreArchivo = correo.EdadNombreArchivo;
                            correoDetalleOutputModel.Edad.Guid = correo.EdadGuid;
                        }
                        if (textoReconocido.Contains("TIPO DE IDENTIFICACIÓN") && correoDetalleOutputModel.Empresa.Texto == null && textoReconocido.Contains("IDENTIFICACIÓN GENERAL DEL EMPLEADOR") && correo.Empresa == null)
                        {
                            var sentence = textoReconocido;
                            if (sentence != null)
                            {
                                sentence = sentence.Replace("\n", " ");
                                sentence = sentence.Split("TIPO DE IDENTIFICACIÓN")[1];
                                if (sentence.Split(" NI ")[0].Length < 100)
                                {
                                    correoDetalleOutputModel.Empresa.Texto = sentence.Split(" NI ")[0].Trim();
                                }
                                else
                                {
                                    correoDetalleOutputModel.Empresa.Texto = sentence.Split(" NIT ")[0].Trim();
                                }
                                correoDetalleOutputModel.Empresa.NombreArchivo = item.NombreArchivo;
                                correoDetalleOutputModel.Empresa.Guid = item.Contenido;

                                //Obtener datos empresa
                                var datos = await _repoCalificacionOrigenService.ObtenerEmpresaDatos(correoDetalleOutputModel.Empresa.Texto);
                                string valor = "";
                                datos.TryGetValue("contrato", out valor);
                                correoDetalleOutputModel.Contrato.Texto = valor;
                                datos.TryGetValue("correo", out valor);
                                correoDetalleOutputModel.EmpresaCorreo.Texto = valor;

                                correo.Empresa = correoDetalleOutputModel.Empresa.Texto;
                                correo.EmpresaNombreArchivo = correoDetalleOutputModel.Empresa.NombreArchivo;
                                correo.EmpresaGuid = correoDetalleOutputModel.Empresa.Guid;
                                correo.CodigoCTO = correoDetalleOutputModel.Contrato.Texto;
                                correo.CorreoEmpresa = correoDetalleOutputModel.EmpresaCorreo.Texto;
                            }
                        }
                        else {
                            correoDetalleOutputModel.Empresa.Texto = correo.Empresa;
                            correoDetalleOutputModel.Empresa.NombreArchivo = correo.EmpresaNombreArchivo;
                            correoDetalleOutputModel.Empresa.Guid = correo.EmpresaGuid;
                            correoDetalleOutputModel.Contrato.Texto = correo.CodigoCTO;
                            correoDetalleOutputModel.EmpresaCorreo.Texto = correo.CorreoEmpresa;
                        }
                        /*if (textoReconocido.Contains("CORREO ELECTRÓNICO (MAIL)") && correoDetalleOutputModel.EmpresaCorreo.Texto == null && textoReconocido.Contains("IDENTIFICACIÓN GENERAL DEL EMPLEADOR") && correo.CorreoEmpresa == null)
                        {
                            var sentence = textoReconocido;
                            if (sentence != null)
                            {
                                sentence = sentence.Replace("\n", " ");
                                sentence = sentence.Split("CORREO ELECTRÓNICO (MAIL)")[1];
                                correoDetalleOutputModel.EmpresaCorreo.Texto = sentence.Split("DEPARTAMENTO")[0].Trim();
                                correoDetalleOutputModel.EmpresaCorreo.NombreArchivo = item.NombreArchivo;
                                correoDetalleOutputModel.EmpresaCorreo.Guid = item.Contenido;

                                correo.CorreoEmpresa = correoDetalleOutputModel.EmpresaCorreo.Texto;
                                correo.CorreoEmpresaNombreArchivo = correoDetalleOutputModel.EmpresaCorreo.NombreArchivo;
                                correo.CorreoEmpresaGuid = correoDetalleOutputModel.EmpresaCorreo.Guid;
                            }
                        }
                        else {
                            correoDetalleOutputModel.EmpresaCorreo.Texto = correo.CorreoEmpresa;
                            correoDetalleOutputModel.EmpresaCorreo.NombreArchivo = correo.CorreoEmpresaNombreArchivo;
                            correoDetalleOutputModel.EmpresaCorreo.Guid = correo.CorreoEmpresaGuid;
                        }*/
                        if (textoReconocido.Contains("CÓDIGO ARL") && correoDetalleOutputModel.Eps.Texto == null && textoReconocido.Contains("IDENTIFICACIÓN GENERAL DEL EMPLEADOR") && correo.EPS == null)
                        {
                            var sentence = textoReconocido;
                            if (sentence != null)
                            {
                                sentence = sentence.Replace("\n", " ");
                                sentence = sentence.Split("CÓDIGO ARL")[1];

                                correoDetalleOutputModel.Eps.Texto = sentence.Split("0")[0].Trim();
                                correoDetalleOutputModel.Eps.Texto = Regex.Replace(correoDetalleOutputModel.Eps.Texto, @"[\d-]", string.Empty).Trim();
                                correoDetalleOutputModel.Eps.NombreArchivo = item.NombreArchivo;
                                correoDetalleOutputModel.Eps.Guid = item.Contenido;

                                correo.EPS = correoDetalleOutputModel.Eps.Texto;
                                correo.EPSNombreArchivo = correoDetalleOutputModel.Eps.NombreArchivo;
                                correo.EPSGuid = correoDetalleOutputModel.Eps.Guid;
                            }
                        }
                        else {
                            correoDetalleOutputModel.Eps.Texto = correo.EPS;
                            correoDetalleOutputModel.Eps.NombreArchivo = correo.EPSNombreArchivo;
                            correoDetalleOutputModel.Eps.Guid = correo.EPSGuid;
                        }
                        if (textoReconocido.Contains("PA NO.") && correoDetalleOutputModel.Identificacion.Texto == null && textoReconocido.Contains("IDENTIFICACIÓN GENERAL DEL EMPLEADOR") && correo.NumeroDocumento == null)
                        {
                            var sentence = textoReconocido;
                            if (sentence != null)
                            {
                                sentence = sentence.Replace("\n", " ");
                                sentence = sentence.Split("PA NO.")[1];

                                correoDetalleOutputModel.Identificacion.Texto = sentence.Split("M")[0].Trim();
                                correoDetalleOutputModel.Identificacion.NombreArchivo = item.NombreArchivo;
                                correoDetalleOutputModel.Identificacion.Guid = item.Contenido;

                                correo.NumeroDocumento = correoDetalleOutputModel.Identificacion.Texto;
                                correo.NumeroDocumentoNombreArchivo = correoDetalleOutputModel.Identificacion.NombreArchivo;
                                correo.NumeroDocumentoGuid = correoDetalleOutputModel.Identificacion.Guid;
                            }
                        }
                        else {
                            correoDetalleOutputModel.Identificacion.Texto = correo.NumeroDocumento;
                            correoDetalleOutputModel.Identificacion.NombreArchivo = correo.NumeroDocumentoNombreArchivo;
                            correoDetalleOutputModel.Identificacion.Guid = correo.NumeroDocumentoGuid;
                        }
                        string apellidos = "";
                        string nombres = "";
                        if (textoReconocido.Contains("SEGUNDO APELLIDO") && correoDetalleOutputModel.Nombre.Texto == null && textoReconocido.Contains("IDENTIFICACIÓN GENERAL DEL EMPLEADOR") && correo.NombresYApellidos == null)
                        {
                            var sentence = textoReconocido;
                            if (sentence != null)
                            {
                                sentence = sentence.Replace("\n", " ");
                                sentence = sentence.Split("SEGUNDO APELLIDO")[1];
                                apellidos = sentence.Split("PRIMER NOMBRE")[0].Trim();
                            }
                        }
                        if (textoReconocido.Contains("SEGUNDO NOMBRE") && correoDetalleOutputModel.Nombre.Texto == null && textoReconocido.Contains("IDENTIFICACIÓN GENERAL DEL EMPLEADOR"))
                        {
                            var sentence = textoReconocido;
                            if (sentence != null)
                            {
                                sentence = sentence.Replace("\n", " ");
                                sentence = sentence.Split("SEGUNDO NOMBRE")[1];
                                nombres = sentence.Split("FECHA DE NACIMIENTO")[0].Trim();
                            }
                        }
                        if ((nombres + " " + apellidos).Length > 5 && correo.NombresYApellidos == null)
                        {
                            correoDetalleOutputModel.Nombre.Texto = nombres + " " + apellidos;
                            correoDetalleOutputModel.Nombre.NombreArchivo = item.NombreArchivo;
                            correoDetalleOutputModel.Nombre.Guid = item.Contenido;

                            correo.NombresYApellidos = correoDetalleOutputModel.Nombre.Texto;
                            correo.NombresYApellidosNombreArchivo = correoDetalleOutputModel.Nombre.NombreArchivo;
                            correo.NombresYApellidosGuid = correoDetalleOutputModel.Nombre.Guid;
                        }
                        else {
                            correoDetalleOutputModel.Nombre.Texto = correo.NombresYApellidos;
                            correoDetalleOutputModel.Nombre.NombreArchivo = correo.NombresYApellidosNombreArchivo;
                            correoDetalleOutputModel.Nombre.Guid = correo.NombresYApellidosGuid;
                        }

                        if (textoReconocido.Contains("TELÉFONO FAX") && correoDetalleOutputModel.Telefono.Texto == null && textoReconocido.Contains("IDENTIFICACIÓN GENERAL DEL EMPLEADOR") && correo.NumeroTelefonico == null)
                        {
                            var sentence = textoReconocido;
                            if (sentence != null)
                            {
                                sentence = sentence.Replace("\n", " ");
                                sentence = sentence.Split("TELÉFONO FAX")[3];
                                sentence = sentence.Split("DEPARTAMENTO")[0].Trim();
                                correoDetalleOutputModel.Telefono.Texto = sentence.Substring(sentence.Length - 11, 11).Trim();
                                correoDetalleOutputModel.Telefono.Texto = Regex.Replace(correoDetalleOutputModel.Telefono.Texto, @"[^0-9]+", string.Empty).Trim();
                                correoDetalleOutputModel.Telefono.NombreArchivo = item.NombreArchivo;
                                correoDetalleOutputModel.Telefono.Guid = item.Contenido;

                                correo.NumeroTelefonico = correoDetalleOutputModel.Telefono.Texto;
                                correo.NumeroTelefonicoNombreArchivo = correoDetalleOutputModel.Telefono.NombreArchivo;
                                correo.NumeroTelefonicoGuid = correoDetalleOutputModel.Telefono.Guid;
                            }
                        }
                        else {
                            correoDetalleOutputModel.Telefono.Texto = correo.NumeroTelefonico;
                            correoDetalleOutputModel.Telefono.NombreArchivo = correo.NumeroTelefonicoNombreArchivo;
                            correoDetalleOutputModel.Telefono.Guid = correo.NumeroTelefonicoGuid;
                        }
                        if (textoReconocido.Contains("CUAL") && correoDetalleOutputModel.Afp.Texto == null && textoReconocido.Contains("IDENTIFICACIÓN GENERAL DEL EMPLEADOR") && correo.AFP == null)
                        {
                            var sentence = textoReconocido;
                            if (sentence != null)
                            {
                                sentence = sentence.Replace("\n", " ");
                                sentence = sentence.Split("CUAL")[1];
                                correoDetalleOutputModel.Afp.Texto = sentence.Split("IDENTIFICACIÓN GENERAL")[0].Trim();
                                correoDetalleOutputModel.Afp.Texto = Regex.Replace(correoDetalleOutputModel.Afp.Texto, @"[\d-]", string.Empty).Trim();
                                correoDetalleOutputModel.Afp.Texto = correoDetalleOutputModel.Afp.Texto.Replace("—", "").Replace("De .", "").Replace("I.", "").Trim();
                                correoDetalleOutputModel.Afp.NombreArchivo = item.NombreArchivo;
                                correoDetalleOutputModel.Afp.Guid = item.Contenido;

                                correo.AFP = correoDetalleOutputModel.Afp.Texto;
                                correo.AFPNombreArchivo = correoDetalleOutputModel.Afp.NombreArchivo;
                                correo.AFPGuid = correoDetalleOutputModel.Afp.Guid;
                            }
                        }
                        else {
                            correoDetalleOutputModel.Afp.Texto = correo.AFP;
                            correoDetalleOutputModel.Afp.NombreArchivo = correo.AFPNombreArchivo;
                            correoDetalleOutputModel.Afp.Guid = correo.AFPGuid;
                        }
                        if (textoReconocido.ToLower().Contains("positivo") && correoDetalleOutputModel.FechaCovid.Texto == null && correo.FechaCovid == null)
                        {
                            var sentence = textoReconocido.ToLower();
                            if (sentence != null)
                            {
                                sentence = sentence.Replace("\n", " ").ToLower();
                                if (sentence.Split("fecha de impresion").Count() > 1)
                                    sentence = sentence.Split("fecha de impresion")[1];

                                if (sentence.Split("fecha de informe de resultados (mm/dd/aaaa):").Count() > 1)
                                    sentence = sentence.Split("fecha de informe de resultados (mm/dd/aaaa):")[1];

                                if (sentence.Split("fecha de resultado:").Count() > 1)
                                    sentence = sentence.Split("fecha de resultado:")[1];

                                if (sentence.Split("fecha de validación:").Count() > 1)
                                    sentence = sentence.Split("fecha de validación:")[1];

                                if (sentence.Split("fecha validación:").Count() > 1)
                                    sentence = sentence.Split("fecha validación:")[1];

                                var fechaSinFormato = sentence.Replace(":", "").Trim();
                                fechaSinFormato = fechaSinFormato.Trim().Split(" ")[0].Trim();
                                fechaSinFormato = fechaSinFormato.Replace(".", "").Replace(":", "").Replace("-", "/").Replace("  ", " ").Replace("ene", "01")
                                    .Replace("feb", "02").Replace("mar", "03").Replace("abr", "04").Replace("may", "05").Replace("jun", "06").Replace("jul", "07")
                                    .Replace("ago", "08").Replace("sep", "09").Replace("oct", "10").Replace("nov", "11").Replace("dic", "12").Trim();

                                fechaSinFormato = fechaSinFormato.Replace("jan", "01").Replace("feb", "02").Replace("mar", "03").Replace("apr", "04").Replace("may", "05").Replace("jun", "06").Replace("jul", "07")
                                    .Replace("aug", "08").Replace("sep", "09").Replace("oct", "10").Replace("nov", "11").Replace("dec", "12").Trim();

                                DateTime? dateValue = null;
                                try
                                {
                                    dateValue = new DateTime(Convert.ToInt32(fechaSinFormato.Split('/')[2]), Convert.ToInt32(fechaSinFormato.Split('/')[1]), Convert.ToInt32(fechaSinFormato.Split('/')[0]));
                                }
                                catch (Exception)
                                {
                                    try { dateValue = new DateTime(Convert.ToInt32(fechaSinFormato.Split('/')[2]), Convert.ToInt32(fechaSinFormato.Split('/')[0]), Convert.ToInt32(fechaSinFormato.Split('/')[1])); }
                                    catch (Exception)
                                    {
                                        try { dateValue = new DateTime(Convert.ToInt32(fechaSinFormato.Split('/')[0]), Convert.ToInt32(fechaSinFormato.Split('/')[1]), Convert.ToInt32(fechaSinFormato.Split('/')[2])); }
                                        catch (Exception)
                                        {

                                        }
                                    }
                                }
                                if (dateValue != null)
                                {
                                    //correoDetalleOutputModel.FechaCovid.Texto = dateValue?.Date.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds.ToString();
                                    correoDetalleOutputModel.FechaCovid.Texto = dateValue?.Date.Day.ToString().PadLeft(2, '0') + "/" + dateValue?.Date.Month.ToString().PadLeft(2, '0') + "/" + dateValue?.Date.Year.ToString();
                                    correoDetalleOutputModel.FechaCovid.NombreArchivo = item.NombreArchivo;
                                    correoDetalleOutputModel.FechaCovid.Guid = item.Contenido;

                                    correo.FechaCovid = correoDetalleOutputModel.FechaCovid.Texto;
                                    correo.FechaCovidNombreArchivo = correoDetalleOutputModel.FechaCovid.NombreArchivo;
                                    correo.FechaCovidGuid = correoDetalleOutputModel.FechaCovid.Guid;
                                }
                            }
                        }
                        else {
                            correoDetalleOutputModel.FechaCovid.Texto = correo.FechaCovid;
                            correoDetalleOutputModel.FechaCovid.NombreArchivo = correo.FechaCovidNombreArchivo;
                            correoDetalleOutputModel.FechaCovid.Guid = correo.FechaCovidGuid;
                        }
                        break;
                    default:
                        break;
                }
            }
            correoDetalleOutputModel.Afp.Texto = CortarTexto(correoDetalleOutputModel.Afp.Texto);
            correoDetalleOutputModel.Cargo.Texto = CortarTexto(correoDetalleOutputModel.Cargo.Texto);
            correoDetalleOutputModel.Ciudad.Texto = CortarTexto(correoDetalleOutputModel.Ciudad.Texto);
            correoDetalleOutputModel.Contrato.Texto = CortarTexto(correoDetalleOutputModel.Contrato.Texto);
            correoDetalleOutputModel.Edad.Texto = CortarTexto(correoDetalleOutputModel.Edad.Texto);
            correoDetalleOutputModel.Empresa.Texto = CortarTexto(correoDetalleOutputModel.Empresa.Texto);
            correoDetalleOutputModel.EmpresaCorreo.Texto = CortarTexto(correoDetalleOutputModel.EmpresaCorreo.Texto);
            correoDetalleOutputModel.EnfermedadLaboral.Texto = CortarTexto(correoDetalleOutputModel.EnfermedadLaboral.Texto);
            correoDetalleOutputModel.Eps.Texto = CortarTexto(correoDetalleOutputModel.Eps.Texto);
            correoDetalleOutputModel.Fecha.Texto = CortarTexto(correoDetalleOutputModel.Fecha.Texto);
            correoDetalleOutputModel.FechaCovid.Texto = CortarTexto(correoDetalleOutputModel.FechaCovid.Texto);
            correoDetalleOutputModel.Identificacion.Texto = CortarTexto(correoDetalleOutputModel.Identificacion.Texto);
            correoDetalleOutputModel.Nombre.Texto = CortarTexto(correoDetalleOutputModel.Nombre.Texto);
            correoDetalleOutputModel.Telefono.Texto = CortarTexto(correoDetalleOutputModel.Telefono.Texto);

            correoDetalleOutputModel.CartaTranscripcion = carta.TextoTranscripcion;
            correoDetalleOutputModel.FormatoWebArl = carta.FormatoWebArl;

            await _repoCalificacionOrigenService.ActualizarCorreo(correo);

            return Ok(correoDetalleOutputModel);
        }
        [HttpPut("{correoId:int}")]
        public async Task<IActionResult> PutCorreoDiligenciado(CorreoInputModel correoInputModel, int correoId) {
            var carta = await _repoCalificacionOrigenService.ObtenerModeloCarta();
            var textoTranscripcion = carta.ObtenerTextoTranscripcion(correoInputModel.Fecha, correoInputModel.Nombre, correoInputModel.Identificacion, 
                correoInputModel.Telefono, correoInputModel.Ciudad, correoInputModel.EnfermedadLaboral, correoInputModel.Contrato,
                correoInputModel.Eps, correoInputModel.Empresa, correoInputModel.EmpresaCorreo, correoInputModel.Afp,
                correoInputModel.Edad, correoInputModel.Cargo, correoInputModel.FechaCovid);

            var textoFormatoWebArl = carta.ObtenerFormatoWebArl(correoInputModel.Fecha, correoInputModel.Nombre, correoInputModel.Identificacion,
                correoInputModel.Telefono, correoInputModel.Ciudad, correoInputModel.EnfermedadLaboral, correoInputModel.Contrato,
                correoInputModel.Eps, correoInputModel.Empresa, correoInputModel.EmpresaCorreo, correoInputModel.Afp,
                correoInputModel.Edad, correoInputModel.Cargo, correoInputModel.FechaCovid);
            await _repoCalificacionOrigenService.GuardarCarta(textoTranscripcion, textoFormatoWebArl, correoId);

            return Ok();
        }
        [HttpPost("Documento")]
        public async Task<IActionResult> ObtenerDocumento(CorreoInputModel correoInputModel)
        {
            GetUserId(out int userId);
            Dictionary<string, string> variables = new Dictionary<string, string>();

            if (correoInputModel.CorreoPaciente != null) { 
                if (correoInputModel.CorreoPaciente.Length > 0) {
                    correoInputModel.CorreoPaciente = "<br />" + correoInputModel.CorreoPaciente;
                }
            }

            variables.Add("afp", correoInputModel.Afp);
            variables.Add("cargo", correoInputModel.Cargo);
            variables.Add("ciudad", correoInputModel.Ciudad);
            variables.Add("contrato", correoInputModel.Contrato);
            variables.Add("edad", correoInputModel.Edad);
            variables.Add("empresa", correoInputModel.Empresa);
            variables.Add("empresacorreo", correoInputModel.EmpresaCorreo);
            variables.Add("enfermedadlaboral", correoInputModel.EnfermedadLaboral);
            variables.Add("eps", correoInputModel.Eps);
            variables.Add("fecha", correoInputModel.Fecha);
            variables.Add("fechacovid", correoInputModel.FechaCovid);
            variables.Add("identificacion", correoInputModel.Identificacion);
            variables.Add("nombre", correoInputModel.Nombre);
            variables.Add("telefono", correoInputModel.Telefono);
            variables.Add("correoPaciente", correoInputModel.CorreoPaciente);
            var stream = await _blobService.GetBlobFileByGuidAsync("Formato Calificación laboral.docx", "public");
            var usuario = await _usuariosService.ObtenerUsuarioDetalle(userId);
            var firma = await _blobService.GetBlobFileByGuidAsync(usuario.Firma, "firmas");
            var documento = await _repoCalificacionOrigenService.ObtenerDocumento(stream, variables, firma);
            return File(documento.ToArray(), "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "Carta Transcripcion.docx");
        }
        [HttpPut("DatosTemporales/{correoId:int}")]
        public async Task<IActionResult> PutDatosTemporalesCorreo(CorreoInputModel correoInputModel, int correoId)
        {
            var correo = await _repoCalificacionOrigenService.ObtenerCorreo(correoId);

            correo.FechaCovid = correoInputModel.FechaCovid;
            correo.NombresYApellidos = correoInputModel.Nombre;
            correo.NumeroDocumento = correoInputModel.Identificacion;
            correo.NumeroTelefonico = correoInputModel.Telefono;
            correo.Edad = correoInputModel.Edad;
            correo.Ciudad = correoInputModel.Ciudad;
            correo.CodigoEL = correoInputModel.EnfermedadLaboral;
            correo.CodigoCTO = correoInputModel.Contrato;
            correo.EPS = correoInputModel.Eps;
            correo.Empresa = correoInputModel.Empresa;
            correo.CorreoEmpresa = correoInputModel.EmpresaCorreo;
            correo.AFP = correoInputModel.Afp;
            correo.Cargo = correoInputModel.Cargo;
            correo.CorreoPaciente = correoInputModel.CorreoPaciente;
            correo.TipoPrueba = correoInputModel.TipoPrueba;
            correo.FechaHistoriaClinica = correoInputModel.FechaHistoriaClinica;

            await _repoCalificacionOrigenService.ActualizarCorreo(correo);
            return Ok();
        }
        [HttpGet("ProcesarCorreosCalificacionOrigen")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProcesarCorreosCalificacionOrigen()
        {
            await _repoCalificacionOrigenService.ProcesarCorreosCalificacionOrigen();
            return Ok();
        }
        static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }
        static string QuitarTildes(string s) {
            return s.Replace("á", "a").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("é", "e");
        }
        static string CortarTexto(string texto) {
            if (texto == null)
                return "";
            if (texto.Length > 60) {
                texto = texto.Substring(0, 60);
                string ultimoTexto = texto.Split(' ')[texto.Split(' ').Length - 1];
                texto = texto.Replace(ultimoTexto, "").Trim();
            }
            return texto;
        }
    }
}