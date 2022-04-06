using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Incapacidades.Modelos
{
    public class DiagnosticoInputModel
    {
        public int Id { get; set; }
        public int ConceptoRehabilitacionId { get; set; }
        public int CIE10Id { get; set; }
        public long FechaIncapacidad { get; set; }
        public int Etiologia { get; set; }
    }
}
