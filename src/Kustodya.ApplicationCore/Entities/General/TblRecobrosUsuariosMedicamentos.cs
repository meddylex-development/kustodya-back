using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblRecobrosUsuariosMedicamentos
    {
        public int IIdrecobroUsuarioMedicamento { get; set; }
        public int? IIdrecobroDocumentoUsuarioDiagnostico { get; set; }
        public int? IIdmedicamento { get; set; }
        public int? ICantidad { get; set; }
        public DateTime? DtFechaFormulacion { get; set; }
        public string TNombreQuienFormula { get; set; }
        public DateTime? DtFechaEntrega { get; set; }
        public string TCodigoAutorizacion { get; set; }
        public int? IIdusuarioCreacion { get; set; }
        public DateTime? DtFechaCreacion { get; set; }
        public int? IIdusuarioModificacion { get; set; }
        public DateTime? DtFechaModificacion { get; set; }
        public bool? BActivo { get; set; }
    }
}
