using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblRecobrosDocumentos
    {
        public TblRecobrosDocumentos()
        {
            TblRecobrosDocumentosUsuarios = new HashSet<TblRecobrosDocumentosUsuarios>();
        }

        public int IIdrecobroDocumento { get; set; }
        public int? IIdrecobro { get; set; }
        public int? IIdsubtablaTipoDocumento { get; set; }
        public string TValorTipoDocumento { get; set; }
        public DateTime? DtFechaDocumento { get; set; }
        public string TNumeroDocumento { get; set; }
        public decimal? DValorBruto { get; set; }
        public decimal? DValorNeto { get; set; }
        public decimal? DImpuestos { get; set; }
        public int? IIdusuarioCreacion { get; set; }
        public DateTime? DtFechaCreacion { get; set; }
        public int? IIdusuarioModificacion { get; set; }
        public DateTime? DtFechaModificacion { get; set; }
        public bool? BActivo { get; set; }
        public int? IIdestado { get; set; }

        public virtual TblRecobroEstadosDocumentos IIdestadoNavigation { get; set; }
        public virtual TblRecobros IIdrecobroNavigation { get; set; }
        public virtual TblUsuarios IIdusuarioCreacionNavigation { get; set; }
        public virtual TblUsuarios IIdusuarioModificacionNavigation { get; set; }
        public virtual TblMultivalores TblMultivalores { get; set; }
        public virtual ICollection<TblRecobrosDocumentosUsuarios> TblRecobrosDocumentosUsuarios { get; set; }
    }
}
