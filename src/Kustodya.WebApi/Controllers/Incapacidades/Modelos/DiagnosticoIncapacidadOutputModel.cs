using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Incapacidades.Modelos
{
    public class DiagnosticoIncapacidadOutputModel
    {
        public long id { get; set; }
        public string CodigoUnico { get; set; }
        public string CodigoCorto { get; set; }
        public long FechaInicio { get; set; }
        public long FechaFin { get; set; }
        public int DiasAcumulados { get; set; }
        public int DiasOtorgados { get; set; }
        public string CIE10 { get; set; }
        public string DescripcionSintomatologica { get; set; }
    }
}
