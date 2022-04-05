using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.CalificacionOrigen.Modelos
{
    public class CorreoInputModel
    {
        public string Fecha { get; set; }
        public string FechaCovid { get; set; }
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public string Telefono { get; set; }
        public string Ciudad { get; set; }
        public string EnfermedadLaboral { get; set; }
        public string Contrato { get; set; }
        public string Eps { get; set; }
        public string Empresa { get; set; }
        public string EmpresaCorreo { get; set; }
        public string Afp { get; set; }
        public string Edad { get; set; }
        public string Cargo { get; set; }
        public string CorreoPaciente { get; set; }
        public string TipoPrueba { get; set; }
        public string FechaHistoriaClinica { get; set; }
    }
}
