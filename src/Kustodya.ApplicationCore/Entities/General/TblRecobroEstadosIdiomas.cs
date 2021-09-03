using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblRecobroEstadosIdiomas
    {
        public int IIdrecobroEstadosIdiomas { get; set; }
        public int? IIdidioma { get; set; }
        public long? IIdrecobroEstado { get; set; }
        public string TEstadoNombre { get; set; }
        public DateTime? DtFechaCreacion { get; set; }
        public int? IIdusuarioCreacion { get; set; }
        public bool? BActivo { get; set; }

        public virtual TblIdiomas IIdidiomaNavigation { get; set; }
        public virtual TblRecobroEstados IIdrecobroEstadoNavigation { get; set; }
        public virtual TblUsuarios IIdusuarioCreacionNavigation { get; set; }
    }
}
