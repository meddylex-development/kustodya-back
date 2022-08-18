using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Kustodya.WebApi.Models.K2Conceptos
{
    public class MailRequest
    {
        public string ToEmail { get; set; }
        public string tNombreAFP { get; set; }
        public string tDireccionAFP { get; set; }
        public string tNombreCiudadAFP { get; set; }
        public string tAsunto { get; set; }
        public string tNombrePaciente { get; set; }
        public string tIdentificacionPaciente { get; set; }
        public string tnombreEPS { get; set; }
        public string tPronostico { get; set; }
        public List<IFormFile> Attachments { get; set; }
    }
}
