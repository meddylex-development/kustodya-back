using Kustodya.ApplicationCore.Dtos.Incapacidades;
using Kustodya.ApplicationCore.Dtos.Negocio;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Dtos.Rehabilitacion
{
    public class ConceptoRehabilitacionModel
    {
        public int IIdConceptoRehabilitacion { get; set; }

        public IPSModel IPS { get; set; }

        public PacienteModel Paciente { get; set; }

        private ICollection<DiagnosticoIncapacidadModel> Incapacidades { get; set; }
    }
}