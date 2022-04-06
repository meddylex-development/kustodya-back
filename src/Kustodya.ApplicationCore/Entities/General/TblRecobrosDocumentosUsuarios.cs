using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblRecobrosDocumentosUsuarios
    {
        public int IIdrecobroDocumentoUsuario { get; set; }
        public int? IIdrecobroDocumento { get; set; }
        public int? IIdsubtablaTipoIdentificacion { get; set; }
        public string TValorTipoIdentificacion { get; set; }
        public string TNumeroIdentificacion { get; set; }
        public string TPrimerNombre { get; set; }
        public string TSegundoNombre { get; set; }
        public string TPrimerApellido { get; set; }
        public string TSegundoApellido { get; set; }
        public DateTime? DtFechaCreacion { get; set; }
        public int? IIdusuarioCreacion { get; set; }
        public DateTime? DtFechaModificacion { get; set; }
        public int? IIdusuarioModificacion { get; set; }
        public bool? BActivo { get; set; }

        public virtual TblRecobrosDocumentos IIdrecobroDocumentoNavigation { get; set; }
        public virtual TblUsuarios IIdusuarioCreacionNavigation { get; set; }
        public virtual TblUsuarios IIdusuarioModificacionNavigation { get; set; }
        public virtual TblMultivalores TblMultivalores { get; set; }
    }
}
