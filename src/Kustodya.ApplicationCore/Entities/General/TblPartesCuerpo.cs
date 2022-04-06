using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblPartesCuerpo
    {
        public TblPartesCuerpo()
        {
            TblAtpartesAfectadas = new HashSet<TblAtpartesAfectadas>();
        }

        public long IIdparteCuerpo { get; set; }
        public string TCodigo { get; set; }
        public string TNombre { get; set; }
        public long? IIdpadre { get; set; }
        public int IUsuarioCreacion { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
        public virtual ICollection<TblAtpartesAfectadas> TblAtpartesAfectadas { get; set; }
    }
}
