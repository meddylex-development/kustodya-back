using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblConceptoRehabilitacion
    {
        public int IIdConceptoRehabilitacion { get; set; }
        public long IIdeps { get; set; }
        public int IIdpaciente { get; set; }
        public long IIdsecuela { get; set; }
        public long IIdpronostico { get; set; }
        public long IIdfinalidadTratamiento { get; set; }
        public long IIdplazoCorto { get; set; }
        public long IIdplazoLargo { get; set; }
        public long IIdconcepto { get; set; }
        public long IIdremision { get; set; }
        public long IIdmedico { get; set; }
        public DateTime FechaEmision { get; set; }
        public bool? EsFarmacologico { get; set; }
        public bool? EsQuirurgico { get; set; }
        public bool? EsTerapiaFisica { get; set; }
        public bool? EsTerapiaOcupaciona { get; set; }
        public bool? EsFonoaudiologia { get; set; }
        public bool? EsOtrosTratamientos { get; set; }
        public string DescripcionOtrosTratamientos { get; set; }

        public virtual TblEmpleados IIdmedicoNavigation { get; set; }
    }
}
