using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblEmpresaEstandarDocGenSis
    {
        public long IIdempresaEstandarDocGenSis { get; set; }
        public long IIdempresa { get; set; }
        public long IIdcobertura { get; set; }
        public long IIdtipoDocumento { get; set; }
        public long IIdestado { get; set; }
        public int? IVersion { get; set; }
        public string TDescripcion { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }
        public long? IIdclasePolitica { get; set; }
        public long? IIdtipoPolitica { get; set; }
        public int? IIdsubtablaNivelCobertura { get; set; }
        public string TIdvalorNivelCobertura { get; set; }

        public virtual TblMultivalores IIdcoberturaNavigation { get; set; }
        public virtual TblEmpresas IIdempresaNavigation { get; set; }
        public virtual TblMultivalores IIdestadoNavigation { get; set; }
        public virtual TblMultivalores IIdtipoDocumentoNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
    }
}
