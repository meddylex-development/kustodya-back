using Kustodya.ApplicationCore.Constants;
using Kustodya.Medicos.Services;
using Kustodya.Medicos.Services.AI;
using Microsoft.Azure.WebJobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kustodya.Medicos.Controllers
{
    public class EjecutarOCRCorreos
    {
        private readonly IServicioCorreo _servicioCorreo;
        private readonly IOCREngineService _ocrEngineService;
        
        public EjecutarOCRCorreos(IServicioCorreo servicioCorreo, IOCREngineService ocrEngineService)
        {
            _servicioCorreo = servicioCorreo;
            _ocrEngineService = ocrEngineService;
        }


        [FunctionName(nameof(EjecutarOCR))]
        public async Task EjecutarOCR([TimerTrigger("* */10 * * * *")] TimerInfo myTimer)
        {
            var archivosPendientes = _servicioCorreo.ObtenerArchivosPendientes();

            foreach (var item in archivosPendientes)
            {
                var extension = item.NombreArchivo.Split('.')[item.NombreArchivo.Split('.').Count() - 1];
                ApplicationCore.Dtos.Incapacidades.OCRExtractionMethodModel OCRModel;
                switch (extension.ToLower())
                {
                    case "docx":
                        string textoReconocido = "";
                        try
                        {
                            OCRModel = await _ocrEngineService.GetOCRTextByAzureBlobId(item.Contenido, OCRExtractionMethod.Word, "calificacionorigencorreos");
                            foreach (var sentence in OCRModel.Sentences)
                            {
                                textoReconocido = textoReconocido + " " + sentence;
                            }
                            textoReconocido = textoReconocido.Trim();
                            item.TextoReconocido = textoReconocido;
                            _servicioCorreo.ActualizarAdjunto(item);
                        }
                        catch (Exception ex)
                        {
                            item.TextoReconocido = textoReconocido;
                            _servicioCorreo.ActualizarAdjunto(item);
                        }
                        break;
                    case "jpg":
                        textoReconocido = "";
                        try
                        {
                            OCRModel = await _ocrEngineService.GetOCRTextByAzureBlobId(item.Contenido, OCRExtractionMethod.Tesseract, "calificacionorigencorreos");
                            foreach (var sentence in OCRModel.Sentences)
                            {
                                textoReconocido = textoReconocido + " " + sentence;
                            }
                            textoReconocido = textoReconocido.Trim();
                            item.TextoReconocido = textoReconocido;
                            _servicioCorreo.ActualizarAdjunto(item);
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                        break;
                    case "jpeg":
                        textoReconocido = "";
                        try
                        {
                            OCRModel = await _ocrEngineService.GetOCRTextByAzureBlobId(item.Contenido, OCRExtractionMethod.Tesseract, "calificacionorigencorreos");
                            foreach (var sentence in OCRModel.Sentences)
                            {
                                textoReconocido = textoReconocido + " " + sentence;
                            }
                            textoReconocido = textoReconocido.Trim();
                            item.TextoReconocido = textoReconocido;
                            _servicioCorreo.ActualizarAdjunto(item);
                        }
                        catch (Exception ex)
                        {
                            continue;
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
                                _servicioCorreo.ActualizarAdjunto(item);
                            }
                            catch (Exception ex)
                            {
                                continue;
                            }
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
                                _servicioCorreo.ActualizarAdjunto(item);
                            }
                            catch (Exception ex)
                            {
                                continue;
                            }
                        }
                        break;
                    case "pdf":
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
                                _servicioCorreo.ActualizarAdjunto(item);
                            }
                            catch (Exception)
                            {
                                continue;
                            }
                        }
                        break;
                    default:
                        item.TextoReconocido = "";
                        _servicioCorreo.ActualizarAdjunto(item);
                        break;

                }
            }
        }
    }
}