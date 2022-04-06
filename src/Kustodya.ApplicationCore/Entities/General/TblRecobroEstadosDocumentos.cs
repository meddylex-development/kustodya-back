using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblRecobroEstadosDocumentos
    {
        public TblRecobroEstadosDocumentos()
        {
            TblRecobroEstadosDocumentosIdiomas = new HashSet<TblRecobroEstadosDocumentosIdiomas>();
            TblRecobrosDocumentos = new HashSet<TblRecobrosDocumentos>();
        }

        public int IIdrecobroEstadoDocumentos { get; set; }
        public int? IIdentidad { get; set; }
        public string TColor { get; set; }
        public DateTime? DtFechaCreacion { get; set; }
        public int? IIdusuarioCreacion { get; set; }
        public bool? BActivo { get; set; }

        public virtual TblUsuarios IIdusuarioCreacionNavigation { get; set; }
        public virtual ICollection<TblRecobroEstadosDocumentosIdiomas> TblRecobroEstadosDocumentosIdiomas { get; set; }
        public virtual ICollection<TblRecobrosDocumentos> TblRecobrosDocumentos { get; set; }
    }
}
