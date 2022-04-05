using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblInspeccionExtintoresDetalleMtto
    {
        public long IIdinspeccionExtintorDetalleMtto { get; set; }
        public long IIdinspeccionExtintorDetalle { get; set; }
        public int IIdsubtablaParteExtintor { get; set; }
        public string TIdvalorParteExtintor { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
    }
}
