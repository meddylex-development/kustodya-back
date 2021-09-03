using Kustodya.ApplicationCore.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Dtos.Incapacidades
{
    public class TranscripcionModel
    {
        public int? TipoDocumentoId { get; set; }
        public string NumeroDocumento { get; set; }
        public string NombrePaciente { get; set; }
        public TipoTranscripcion TipoTranscripcionId { get; set; }

        public string BlobHistoriaClinicaId { get; set; }
        public string BlobCertificadoIncapacidadId { get; set; }
        public IEnumerable<string> BlobOtrosDocumentosIds { get; set; }

        public int? TipoOrigenId { get; set; }
        public bool AccidenteTrabajo { get; set; }
        public bool SOAT { get; set; }
        public int? TipoLicencia { get; set; }

        public bool CotizoMasEPSs { get; set; }
    }
}
