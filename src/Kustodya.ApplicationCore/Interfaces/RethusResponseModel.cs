using System;

namespace Kustodya.ApplicationCore.Interfaces
{
    public class RethusResponseModel
    {
        public long? IIdSolicitud { get; set; }
        public int? TIdValorTipoIdentificacion { get; set; }
        public string? TNumeroIdentificacion { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateTime? DtFechaltimaActualizacion { get; set; }
        public DateTime? DtFechaSolicitud { get; set; }
        public DateTime? DtFechaResultado { get; set; }
        public Detalle[] Detalles { get; set; }
        public string Mensaje { get; set; }
    }

    public class Detalle
    {
        public string TTipoProgramaOrigen { get; set; }
        public string TTituloObtenido { get; set; }
        public string TProfesionOcupacion { get; set; }
        public DateTime DtFechaAutorizacionEjercer { get; set; }
        public string TEntidadReportante { get; set; }
    }
}