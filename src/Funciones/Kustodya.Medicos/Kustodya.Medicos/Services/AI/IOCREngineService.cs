using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Constants;
using Kustodya.ApplicationCore.Dtos.Incapacidades;

namespace Kustodya.Medicos.Services.AI
{
    public interface IOCREngineService
    {
        Task<OCRExtractionMethodModel> GetOCRTextByAzureBlobId(string blobCertificadoIncapacidadId, OCRExtractionMethod ocrExtractMethod, string container);
        Task<TranscripcionAIModel> PerformTextTranscription(IList<string> ocrText, OCRExtractionMethod ocrExtractMethod, TblPacientes paciente);
    }
}
