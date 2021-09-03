using System;
using Kustodya.Medicos.Services;
using Roojo.Rethus;

namespace Kustodya.Medicos.Models
{
    public class RethusResponseModel
    {
        public long? IIdSolicitud { get; set; }
        public TipoIdentificacionRethus? TIdValorTipoIdentificacion { get; set; }
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
}
