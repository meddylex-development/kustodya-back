using Kustodya.ApplicationCore.Constants;
using System;
using System.Collections.Generic;

namespace Kustodya.WebApi.Models
{
    public class MedicoOutputModel
    {
        public string NumeroIdentifiacion { get; set; }
        public TipoIdentificacion TipoIdentificacion { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public List<Detalle> Detalles { get; set; }
        public List<Error> Errors { get; set; }

        public class Detalle
        {
            public string TipoDeProgramaOrigen { get; set; }
            public string TituloObtenido { get; set; }
            public string Ocupacion { get; set; }
            public DateTime AutorizadoParaEjercerHasta { get; set; }
            public string EntidadQueReporta { get; set; }
        }
    }
}
