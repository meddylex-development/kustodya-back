using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.CalificacionOrigen
{
    public class Correo : BaseEntity
    {
        public int Id { get; set; }
        public string MessageId { get; set; }
        public string De { get; set; }
        public string Para { get; set; }
        public string CC { get; set; }
        public string Asunto { get; set; }
        public string Cuerpo { get; set; }
        public EstadoCorreo Estado { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime? FechaTranscripcion { get; set; }
        public string CartaTranscripcion { get; set; }
        public string FormatoWebArl { get; set; }
        public string FechaCovid { get; set; }
        public string NombresYApellidos { get; set; }
        public string NumeroDocumento { get; set; }
        public string NumeroTelefonico { get; set; }
        public string Edad { get; set; }
        public string Ciudad { get; set; }
        public string CodigoEL { get; set; }
        public string CodigoCTO { get; set; }
        public string EPS { get; set; }
        public string Empresa { get; set; }
        public string CorreoEmpresa { get; set; }
        public string AFP { get; set; }
        public string Cargo { get; set; }
        public string CorreoPaciente { get; set; }
        public string TipoPrueba { get; set; }
        public string CargoNombreArchivo { get; set; }
        public string CargoGuid { get; set; }
        public string EdadNombreArchivo { get; set; }
        public string EdadGuid { get; set; }
        public string EmpresaNombreArchivo { get; set; }
        public string EmpresaGuid { get; set; }
        public string CorreoEmpresaNombreArchivo { get; set; }
        public string CorreoEmpresaGuid { get; set; }
        public string EPSNombreArchivo { get; set; }
        public string EPSGuid { get; set; }
        public string NumeroDocumentoNombreArchivo { get; set; }
        public string NumeroDocumentoGuid { get; set; }
        public string NombresYApellidosNombreArchivo { get; set; }
        public string NombresYApellidosGuid { get; set; }
        public string NumeroTelefonicoNombreArchivo { get; set; }
        public string NumeroTelefonicoGuid { get; set; }
        public string AFPNombreArchivo { get; set; }
        public string AFPGuid { get; set; }
        public string FechaCovidNombreArchivo { get; set; }
        public string FechaCovidGuid { get; set; }
        public string FechaHistoriaClinica { get; set; }
        public List<Adjunto> Adjuntos { get; set; }
        public enum EstadoCorreo : int
        {
            Por_Gestionar = 1,
            Sin_Transcribir = 2,
            Transcrito = 3
        }
    }
}
