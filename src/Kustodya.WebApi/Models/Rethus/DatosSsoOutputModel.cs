using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Models.Rethus
{
    public class DatosSsoOutputModel
    {
        public string tipoPrestacion { get; set; }
        public string tipoLugarPrestacion { get; set; }
        public string lugarPresentacion { get; set; }
        public string fechaInicio { get; set; }
        public string fechaFin { get; set; }
        public string modalidadPrestacion { get; set; }
        public string programaPrestacion { get; set; }
        public string entidadReportadora { get; set; }
    }
}
