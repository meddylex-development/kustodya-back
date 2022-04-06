using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblDiagnosticos
    {
        public int IIddiagnostico { get; set; }
        public int? IIdpais { get; set; }
        public int? IIddiagnosticoNomenclatura { get; set; }
        public int? IIddiagnosticoCapitulo { get; set; }
        public string TClave { get; set; }
        public string TDescripcion { get; set; }
        public DateTime? DtFechaInsercion { get; set; }
        public int? IIdusuarioInsercion { get; set; }
        public DateTime? DtFechaModificacion { get; set; }
        public int? IIdusuarioModificacion { get; set; }
        public bool? BActivo { get; set; }
    }
}
