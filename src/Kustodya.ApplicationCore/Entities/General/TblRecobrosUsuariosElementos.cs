using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblRecobrosUsuariosElementos
    {
        public int IIdrecobroUsuarioElemento { get; set; }
        public int? IIdrecobroDocumentoUsuarioDiagnostico { get; set; }
        public int? IIdelemento { get; set; }
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

        public virtual TblRecobrosDocumentosUsuariosDiagnosticos IIdrecobroDocumentoUsuarioDiagnosticoNavigation { get; set; }
        public virtual TblUsuarios IIdusuarioCreacionNavigation { get; set; }
        public virtual TblUsuarios IIdusuarioModificacionNavigation { get; set; }
    }
}
