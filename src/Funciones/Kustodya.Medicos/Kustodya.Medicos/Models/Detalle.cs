using System;

namespace Kustodya.Medicos.Models
{
    public class Detalle
    {
        public string TTipoProgramaOrigen { get; set; }
        public string TTituloObtenido { get; set; }
        public string TProfesionOcupacion { get; set; }
        public DateTime? DtFechaAutorizacionEjercer { get; set; }
        public string TEntidadReportante { get; set; }
        public string TActoAdministrativo { get; set; }
    }
}
