using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.CalificacionOrigen.Modelos
{
    public class CorreoOutputModel
    {
        public int Id { get; set; }
        public string MessageId { get; set; }
        public string Remitente { get; set; }
        public string Asunto { get; set; }
        public long FechaCorreo { get; set; }
        public string Estado { get; set; }
        public double? FechaTranscripcion { get; set; }
        public List<AdjuntoOutputModel> Adjuntos { get; set; }
    }
}
