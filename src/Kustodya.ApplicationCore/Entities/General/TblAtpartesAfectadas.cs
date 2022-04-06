using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblAtpartesAfectadas
    {
        public long IIdatparteAfectada { get; set; }
        public long IIdaccidenteTrabajo { get; set; }
        public long IIdparteCuerpo { get; set; }
        public int IIdsubtablaTipoLesion { get; set; }
        public string TValorTipoLesion { get; set; }
        public int IIdsubtablaAgenteLesion { get; set; }
        public string TValorAgenteLesion { get; set; }
        public int IIdsubtablaMecanismoLesion { get; set; }
        public string TValorMecanismoLesion { get; set; }
        public int IIdsubtablaCostadoCuerpo { get; set; }
        public string TIdvalorCostadoCuerpo { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblAccidentesTrabajo IIdaccidenteTrabajoNavigation { get; set; }
        public virtual TblPartesCuerpo IIdparteCuerpoNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
    }
}
