using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Incapacidades.Modelos
{
    public class HistorialConceptoOutputModel
    {
        public int Id { get; set; }
        public string CodigoCorto { get; set; }
        public double FechaEmision { get; set; }
        public ICollection<DiagnosticosOutputModel> Diagnosticos { get; set; }
        public int Concepto { get; set; }

        public string Medico { get; set; }
    }
}
