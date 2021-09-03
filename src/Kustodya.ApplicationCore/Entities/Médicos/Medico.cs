using Kustodya.ApplicationCore.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.Medicos
{
    public class Medico
    {
        public Guid Id { get; set; }
        public TipoIdentificacion? TipoIdentificacion { get; set; }
        public bool? RegistradoEnRethus { get; set; }
        public string NumeroIdentifiacion { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateTime UltimaActualizacion { get; set; }
        public DateTime UltimaConsulta { get; set; }
        public List<Detalle> Detalles { get; set; }
        public Guid Validacion { get; set; }
    }

    public class Detalle
    {
        public Guid MedicoId { get; set; }
        public Medico Medico { get; set; }
        public Guid Id { get; set; }
        public string TipoProgramaOrigen { get; set; }
        public string TituloObtenido { get; set; }
        public string Ocupacion { get; set; }
        public DateTime AutorizadoParaEjercerHasta { get; set; }
        public string EntidadQueReporta { get; set; }
    }
}
