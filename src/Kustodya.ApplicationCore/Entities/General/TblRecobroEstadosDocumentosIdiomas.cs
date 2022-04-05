using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblRecobroEstadosDocumentosIdiomas
    {
        public int IIdrecobroEstadosDocumentosIdiomas { get; set; }
        public int? IIdidioma { get; set; }
        public int? IIdrecobroEstado { get; set; }
        public string TEstadoNombre { get; set; }
        public DateTime? DtFechaCreacion { get; set; }
        public int? IIdusuarioCreacion { get; set; }
        public bool? BActivo { get; set; }

        public virtual TblIdiomas IIdidiomaNavigation { get; set; }
        public virtual TblRecobroEstadosDocumentos IIdrecobroEstadoNavigation { get; set; }
        public virtual TblUsuarios IIdusuarioCreacionNavigation { get; set; }
    }
}
