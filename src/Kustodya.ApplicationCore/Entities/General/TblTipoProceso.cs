using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblTipoProceso
    {
        public TblTipoProceso()
        {
            TblProcesos = new HashSet<TblProcesos>();
        }

        public long IIdtipoProceso { get; set; }
        public long IIdempresa { get; set; }
        public string TCodigoTipoProceso { get; set; }
        public string TNombreTipoProceso { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblEmpresas IIdempresaNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
        public virtual ICollection<TblProcesos> TblProcesos { get; set; }
    }
}
