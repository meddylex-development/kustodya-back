using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblEmpresaControlEficacia
    {
        public TblEmpresaControlEficacia()
        {
            TblRiesgoControlValoraciones = new HashSet<TblRiesgoControlValoraciones>();
        }

        public long IIdcontrolEficacia { get; set; }
        public long IIdempresa { get; set; }
        public int IOrden { get; set; }
        public int IValor { get; set; }
        public string TDescripcion { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblEmpresas IIdempresaNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
        public virtual ICollection<TblRiesgoControlValoraciones> TblRiesgoControlValoraciones { get; set; }
    }
}
