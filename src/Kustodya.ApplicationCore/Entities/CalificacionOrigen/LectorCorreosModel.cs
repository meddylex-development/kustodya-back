using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.CalificacionOrigen
{
    public class LectorCorreosModel
    {
        public string MensajeId { get; set; }
        public string Id { get; set; }
        public string De { get; set; }
        public string Para { get; set; }
        public string CC { get; set; }
        public string Asunto { get; set; }
        public string Cuerpo { get; set; }
        public DateTime Fecha { get; set; }
        public List<LectorCorreosAdjunto> Adjuntos { get; set; }
    }
    public class LectorCorreosAdjunto
    {
        public string NombreArchivo { get; set; }
        public MemoryStream Contenido { get; set; }
    }
}
