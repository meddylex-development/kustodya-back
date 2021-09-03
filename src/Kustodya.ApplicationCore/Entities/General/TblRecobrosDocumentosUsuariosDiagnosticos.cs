using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblRecobrosDocumentosUsuariosDiagnosticos
    {
        public TblRecobrosDocumentosUsuariosDiagnosticos()
        {
            TblRecobrosUsuariosElementos = new HashSet<TblRecobrosUsuariosElementos>();
            TblRecobrosUsuariosServiciosProcedimientos = new HashSet<TblRecobrosUsuariosServiciosProcedimientos>();
        }

        public int IIdrecobroDocumentoUsuarioDiagnostico { get; set; }
        public int? IIdrecobroDocumentoUsuario { get; set; }
        public int? IIddiagnostico { get; set; }
        public DateTime? DtFechaDiagnostico { get; set; }
        public int? IIdsubTablaTipoOrigen { get; set; }
        public string TValorTipoOrigen { get; set; }
        public DateTime? DtFechaOcurrenciaOrigen { get; set; }
        public int? IIdusuarioInsercion { get; set; }
        public DateTime? DtFechaInsercion { get; set; }
        public int? IIdusuarioModificacion { get; set; }
        public DateTime? DtFechaModificacion { get; set; }
        public bool? BActivo { get; set; }

        public virtual ICollection<TblRecobrosUsuariosElementos> TblRecobrosUsuariosElementos { get; set; }
        public virtual ICollection<TblRecobrosUsuariosServiciosProcedimientos> TblRecobrosUsuariosServiciosProcedimientos { get; set; }
    }
}
