using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Kustodya.WebApi.Models.K2Conceptos
{
    public class MailRequest
    {
        public string email { get; set; }
        public string nombrePaciente { get; set; }
        public string codigo { get; set; }
        public string tipoDocumento { get; set; }
        public string numeroDocumento { get; set; }
        public string nombreAFP { get; set; }
        public string nombreEPS { get; set; }
        public string pronostico { get; set; }
        public string conIncapacidades { get; set; }
    }
}
