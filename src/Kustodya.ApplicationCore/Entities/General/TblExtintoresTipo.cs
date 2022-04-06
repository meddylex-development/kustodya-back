using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblExtintoresTipo
    {
        public TblExtintoresTipo()
        {
            TblInspeccionExtintoresDetalle = new HashSet<TblInspeccionExtintoresDetalle>();
        }

        public long IIdextintorTipo { get; set; }
        public int IAgente { get; set; }
        public string TAgente { get; set; }
        public int ICapacidad { get; set; }
        public string TCapacidad { get; set; }
        public int IUnidad { get; set; }
        public string TUnidad { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
        public virtual ICollection<TblInspeccionExtintoresDetalle> TblInspeccionExtintoresDetalle { get; set; }
    }
}
