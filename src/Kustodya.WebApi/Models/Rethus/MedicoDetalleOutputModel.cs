using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Models.Rethus
{
    public class MedicoDetalleOutputModel
    {
        public string tipoProgramaOrigen { get; set; }
        public string tituloObtenido { get; set; }
        public string ocupacion { get; set; }
        public string autorizadoParaEjercerHasta { get; set; }
        public string actoAdministrativo { get; set; }
        public string entidadQueReporta { get; set; }
    }
}
