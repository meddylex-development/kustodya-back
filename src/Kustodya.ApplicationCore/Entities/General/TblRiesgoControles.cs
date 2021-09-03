using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblRiesgoControles
    {
        public TblRiesgoControles()
        {
            TblRiesgoControlValoraciones = new HashSet<TblRiesgoControlValoraciones>();
        }

        public long IIdriesgoControl { get; set; }
        public long IIdriesgoIdentificacion { get; set; }
        public string TControl { get; set; }
        public int IIdsubtablaTipoControl { get; set; }
        public string TIdvalorTipoControl { get; set; }
        public DateTime DtFechaInsercion { get; set; }
        public int IUsuarioInsercion { get; set; }
        public bool? BActivo { get; set; }

        public virtual TblUsuarios IUsuarioInsercionNavigation { get; set; }
        public virtual ICollection<TblRiesgoControlValoraciones> TblRiesgoControlValoraciones { get; set; }
    }
}
