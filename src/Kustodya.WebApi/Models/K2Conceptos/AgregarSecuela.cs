using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Models.K2Conceptos
{
    public class AgregarSecuela
    {
        public int ConceptoRehabilitacionId { get; set; }
        public int Tipo { get; set; }
        public string Descripcion { get; set; }
        public int Pronostico { get; set; }
    }
}
