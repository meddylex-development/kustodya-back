using System;
using System.Collections.Generic;

namespace Roojo.Rethus
{
    public partial class Dato
    {
        public int Id { get; set; }
        public int? ConsultaId { get; set; }
        public string TipoIdentificacion { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string EstadoIdentificacion { get; set; }
        public Consulta Consulta { get; set; }

        public static class Nuevo
        {
            public static Dato DePrueba(int idDeLaConsulta)
            {
                return new Dato
                {
                    Id = 100,
                    ConsultaId = idDeLaConsulta,
                    TipoIdentificacion = ((int)Rethus.TipoIdentificacionRethus.Cédula_de_Extranjería).ToString(),
                    EstadoIdentificacion = "Vigente",
                    NumeroIdentificacion = "1234567890",
                    PrimerNombre = "Obi",
                    PrimerApellido = "Kenobi",
                    SegundoApellido = "Pinilla",
                    SegundoNombre = "Wan"
                };
            }
        }

        public enum EstadosDeIdentificacion
        {
            Vigente = 1
        }
    }
}
