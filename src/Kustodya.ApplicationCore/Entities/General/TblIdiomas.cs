using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblIdiomas
    {
        public TblIdiomas()
        {
            TblRecobroEstadosDocumentosIdiomas = new HashSet<TblRecobroEstadosDocumentosIdiomas>();
            TblRecobroEstadosIdiomas = new HashSet<TblRecobroEstadosIdiomas>();
        }

        public int IIdidioma { get; set; }
        public string TCodigo { get; set; }
        public string TCodigoPais { get; set; }
        public string TNombre { get; set; }
        public string TPais { get; set; }
        public DateTime? DtFechaCreacion { get; set; }
        public int? IIdusuarioCreacion { get; set; }
        public bool? BActivo { get; set; }

        public virtual TblUsuarios IIdusuarioCreacionNavigation { get; set; }
        public virtual ICollection<TblRecobroEstadosDocumentosIdiomas> TblRecobroEstadosDocumentosIdiomas { get; set; }
        public virtual ICollection<TblRecobroEstadosIdiomas> TblRecobroEstadosIdiomas { get; set; }
    }
}
