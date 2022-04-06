using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblNumerales
    {
        public TblNumerales()
        {
            TblNumeralesProceso = new HashSet<TblNumeralesProceso>();
            TblSoa = new HashSet<TblSoa>();
        }

        public long IIdnumeral { get; set; }
        public int IIdsubtablaEstandar { get; set; }
        public string TIdvalorEstandar { get; set; }
        public string TNumeral { get; set; }
        public string TDescripcion { get; set; }
        public bool BSoa { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
        public virtual ICollection<TblNumeralesProceso> TblNumeralesProceso { get; set; }
        public virtual ICollection<TblSoa> TblSoa { get; set; }
    }
}
