using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblDiagnosticosCapitulos
    {
        public int IIddiagnosticoCapitulo { get; set; }
        public int? IIddiagnosticoNomenclatura { get; set; }
        public string TCodigoCapitulo { get; set; }
        public string TNombreCapitulo { get; set; }
        public int? IGrupoCapitulo { get; set; }
        public DateTime? DtFechaInsercion { get; set; }
        public int? IIdusuarioInsercion { get; set; }
        public DateTime? DtFechaModificacion { get; set; }
        public int? IIdusuarioModificacion { get; set; }
        public bool? BActivo { get; set; }
    }
}
