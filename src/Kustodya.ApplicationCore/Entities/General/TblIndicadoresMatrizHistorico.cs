using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblIndicadoresMatrizHistorico
    {
        public long IIdmatrizIndicadorHistorico { get; set; }
        public long IIdmatrizIndicador { get; set; }
        public long IIdempresa { get; set; }
        public long IIdproceso { get; set; }
        public int IVersion { get; set; }
        public DateTime DtFechaEmision { get; set; }
        public string TObjetivo { get; set; }
        public long IIdempleadoElaboro { get; set; }
        public long IIdempleadoReviso { get; set; }
        public long IIdempleadoAprobo { get; set; }
        public int IIdsubtablaEstadoIndicadoresMatriz { get; set; }
        public string TIdvalorEstadoIndicadoresMatriz { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }
    }
}
