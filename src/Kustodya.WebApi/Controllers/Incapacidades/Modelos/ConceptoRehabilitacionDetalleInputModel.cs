using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Incapacidades.Modelos
{
    public class ConceptoRehabilitacionDetalleInputModel
    {
        public int PacienteId { get; set; }
        public string ResumenHistoriaClinica { get; set; }
        public int FinalidadTratamientos { get; set; }
        public bool EsFarmacologico { get; set; }
        public bool EsTerapiaOcupacional { get; set; }
        public bool EsFonoaudiologia { get; set; }
        public bool EsQuirurgico { get; set; }
        public bool EsTerapiaFisica { get; set; }
        public bool EsOtrosTratamientos { get; set; }
        public string DescripcionOtrosTratamientos { get; set; }
        public int PlazoCorto { get; set; }
        public int PlazoMediano { get; set; }
        public int Concepto { get; set; }
        public int PacienteporEmitirId { get; set; }
        public ICollection<DiagnosticoInputModel> Diagnosticos { get; set; }
        public ICollection<SecuelaInputModel> Secuelas { get; set; }
    }
}
