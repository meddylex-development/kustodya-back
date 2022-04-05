using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.CalificacionOrigen
{
    public class Adjunto : BaseEntity
    {
        public int Id { get; set; }
        public int CorreoId { get; set; }
        public Correo Correo { get; set; }
        public string NombreArchivo { get; set; }
        public string Contenido { get; set; }
        public string TextoReconocido { get; set; }
    }
}   
