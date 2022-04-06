using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Models.Rethus
{
    public class SancionesMedicoOutputModel
    {
        public string instanciaEmiteFallo { get; set; }
        public string codigoTipoSancion { get; set; }
        public string fechaEjecucion { get; set; }
        public string fechaInicio { get; set; }
        public string fechaFin { get; set; }
    }
}
