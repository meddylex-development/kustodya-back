using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Incapacidades.Modelos
{
    public class SecuelaInputModel
    {
        public int Id { get; set; }
        public int ConceptoRehabilitacionId { get; set; }
        public int TipoSecuela { get; set; }
        public string Descripcion { get; set; }
        public int Pronostico { get; set; }

    }
}
