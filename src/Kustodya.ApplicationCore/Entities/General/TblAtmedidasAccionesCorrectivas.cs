using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblAtmedidasAccionesCorrectivas
    {
        public long IIdmedidaAccionCorrectiva { get; set; }
        public long IIdaccidenteTrabajo { get; set; }
        public string TMedidasPlanteadas { get; set; }
        public string TImplementacion { get; set; }
        public string TEjecucion { get; set; }
        public int IIdsubtablaTipoMedida { get; set; }
        public string TValorTipoMedida { get; set; }
        public DateTime DtFechaEjecucion { get; set; }
        public DateTime DtFechaSeguimiento { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblAccidentesTrabajo IIdaccidenteTrabajoNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
    }
}
