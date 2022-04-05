using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Incapacidades.Modelos
{
    public class SecuelasOutputModel
    {
        public int id { get; set; }
        public int tipoSecuela { get; set; }
        public string nombreTipoSecuela { get; set; }
        public string descripcion { get; set; }
        public int pronostico { get; set; }
        public string nombrePronostico { get; set; }
    }
}
