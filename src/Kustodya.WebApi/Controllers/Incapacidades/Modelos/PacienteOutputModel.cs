using Kustodya.ApplicationCore.Entities.Concepto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Incapacidades.Modelos
{
    public class PacienteOutputModel
    {
        public int idpacienteporemitir { get; set; }
        public int idPaciente { get; set; }
        public string numeroIdentificacion { get; set; }
        public long fechaAsignacion { get; set; }
        public string nombre { get; set; }
        public string estado { get; set; }
        public string codigoCorto { get; set; }
    }
}
