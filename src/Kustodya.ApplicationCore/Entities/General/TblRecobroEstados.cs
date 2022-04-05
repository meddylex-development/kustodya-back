using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblRecobroEstados
    {
        public TblRecobroEstados()
        {
            TblRecobroEstadosIdiomas = new HashSet<TblRecobroEstadosIdiomas>();
            TblRecobros = new HashSet<TblRecobros>();
        }

        public long IIdrecobroEstado { get; set; }
        public long? IIdentidad { get; set; }
        public string TColor { get; set; }
        public DateTime? DtFechaCreacion { get; set; }
        public int? IIdusuarioCreacion { get; set; }
        public bool? BActivo { get; set; }

        public virtual TblEmpresas IIdentidadNavigation { get; set; }
        public virtual TblUsuarios IIdusuarioCreacionNavigation { get; set; }
        public virtual ICollection<TblRecobroEstadosIdiomas> TblRecobroEstadosIdiomas { get; set; }
        public virtual ICollection<TblRecobros> TblRecobros { get; set; }
    }
}
