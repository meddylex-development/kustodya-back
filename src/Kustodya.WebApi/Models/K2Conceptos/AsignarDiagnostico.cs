using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Models.K2Conceptos
{
    public class AsignarDiagnostico
    {
        public string SP { get; set; }
        public int Id { get; set; }
        public int ConceptoRehabilitacionId { get; set; }
        public int Cie10Id { get; set; }
        public DateTime? FechaIncapacidad { get; set; }
        public int? Etiologia { get; set; }

    }
}
