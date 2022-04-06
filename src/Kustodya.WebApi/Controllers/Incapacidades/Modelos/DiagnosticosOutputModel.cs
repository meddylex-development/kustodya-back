using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Incapacidades.Modelos
{
    public class DiagnosticosOutputModel
    {
        public long id { get; set; }
        public int CIE10Id { get; set; }
        public string nombreDiagnostico { get; set; }
        public double FechaIncapacidad { get; set; }
        public int Etiologia { get; set; }
        public string nombreEtiologia { get; set; }

    }
}
