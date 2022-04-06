using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.CalificacionOrigen.Modelos
{
    public class CorreoDetalleOutputModel
    {
        public PropiedadCorreoDetalleOutputModel Fecha { get; set; }
        public PropiedadCorreoDetalleOutputModel FechaCovid { get; set; }
        public PropiedadCorreoDetalleOutputModel Nombre { get; set; }
        public PropiedadCorreoDetalleOutputModel Identificacion { get; set; }
        public PropiedadCorreoDetalleOutputModel Telefono { get; set; }
        public PropiedadCorreoDetalleOutputModel Ciudad { get; set; }
        public PropiedadCorreoDetalleOutputModel EnfermedadLaboral { get; set; }
        public PropiedadCorreoDetalleOutputModel Contrato { get; set; }
        public PropiedadCorreoDetalleOutputModel Eps { get; set; }
        public PropiedadCorreoDetalleOutputModel Empresa { get; set; }
        public PropiedadCorreoDetalleOutputModel EmpresaCorreo { get; set; }
        public PropiedadCorreoDetalleOutputModel Edad { get; set; }
        public PropiedadCorreoDetalleOutputModel Cargo { get; set; }
        public PropiedadCorreoDetalleOutputModel Afp { get; set; }
        public PropiedadCorreoDetalleOutputModel CorreoPaciente { get; set; }
        public PropiedadCorreoDetalleOutputModel TipoPrueba { get; set; }
        public PropiedadCorreoDetalleOutputModel FechaHistoriaClinica { get; set; }
        public string CartaTranscripcion { get; set; }
        public string FormatoWebArl { get; set; }
        public List<AdjuntoOutputModel> Adjuntos { get; set; }
    }
}
