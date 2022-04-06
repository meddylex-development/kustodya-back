using Kustodya.ApplicationCore.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.MallaValidadora
{
    public class Afiliado : BaseEntity
    {
        public TiposAfiliacion? TipoAfiliacion { get; set; }
        public bool? Activo { get; set; }
        public Sexos? Sexo { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public bool? PermisoTrabajo { get; set; }
        public bool? Pensionado { get; set; }
        public int? CalificacionPcl { get; set; }
        public bool? ChrbDesfavorable { get; set; }
        public bool? AsisteATratamientos { get; set; }
        public bool? AsisteAExamenes { get; set; }
        public bool? CalificacionAtel { get; set; }
        public bool? ConductasContrarias { get; set; }
        public bool? ActividadimpideRecuperacion { get; set; }
        public bool? DatosFalsos { get; set; }
        public string? CodigoDaneMunicipio { get; set; }  // CodigoDaneMunicipio y no Divipola
        public Guid IpsId { get; set; }
        // public List<Incapacidad> Incapacidades { get; set; }

        public enum TiposAfiliacion
        {
            Cotizante = 1,
            SegundoCotizante,
            Beneficiario,
            BeneficiarioAdicional,
            Subsidiado
        }
    }

}
