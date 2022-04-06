using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblTranscripciones
    {
        public int Iid { get; set; }
        public long? IidDiagnostico { get; set; }
        public DateTime DtfechaCreacion { get; set; }
        public string OcrserviceText { get; set; }
        public string Ocrtext { get; set; }
        public short? OcrproviderId { get; set; }
        public string TblobId { get; set; }
        public string TnumeroIncapacidad { get; set; }
        public string Tdiagnostico { get; set; }
        public short? IDiasIncapacidad { get; set; }
        public string TfechaInicial { get; set; }
        public string TfechaFinal { get; set; }
        public string TcentroAtencion { get; set; }
        public string TclaseIncapacidad { get; set; }
        public string TidCie10 { get; set; }
        public string TtipoIdentificacionMedico { get; set; }
        public string TregistroMedico { get; set; }
        public string TnombreMedico { get; set; }
        public string TtipoIdentificacionPaciente { get; set; }
        public string TnumeroIdentificacionPaciente { get; set; }
        public string TnombrePaciente { get; set; }
        public string TgeneroPaciente { get; set; }
        public string IedadPaciente { get; set; }
        public string TnumeroIdentificacionEps { get; set; }
        public string TtipoIdentificacionIps { get; set; }
        public string TnumeroIdentificacionIps { get; set; }
        public string TnombreIps { get; set; }
        public string TcodigoExternoIps { get; set; }
        public string TfechaCreacion { get; set; }
        public string TnombreEps { get; set; }
    }
}
