using System;
using System.Collections.Generic;
using Kustodya.ApplicationCore.Entities;
namespace Roojo.CalificacionOrigen
{
    public partial class Correo : BaseEntity
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
        public List<Adjunto> Adjuntos { get; set; }
        public enum EstadoCorreo : int
        {
            Por_Gestionar = 1,
            Sin_Transcribir = 2,
            Transcrito = 3
        }
    }
}
        