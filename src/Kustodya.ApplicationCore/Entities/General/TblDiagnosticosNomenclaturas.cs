using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblDiagnosticosNomenclaturas
    {
        public int IIddiagnosticoNomenclatura { get; set; }
        public string TNomenclatura { get; set; }
        public DateTime? DtFechaInsercion { get; set; }
        public int? IIdusuarioInsercion { get; set; }
        public DateTime? DtFechaModificacion { get; set; }
        public int? IIdusuarioModificacion { get; set; }
        public bool? BActivo { get; set; }
    }
}
