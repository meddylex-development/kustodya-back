using System;

namespace Kustodya.Medicos.Models
{
    public class DetalleOutputModel
    {
        public string TipoDeProgramaOrigen { get; set; }
        public string TituloObtenido { get; set; }
        public string Ocupacion { get; set; }
        public DateTime AutorizadoParaEjercerHasta { get; set; }
        public string EntidadQueReporta { get; set; }
    }
}
