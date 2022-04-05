using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblCiuo08
    {
        public TblCiuo08()
        {
            TblPacientes = new HashSet<TblPacientes>();
        }

        public short IId { get; set; }
        public string TIdentificador { get; set; }
        public string TDescripcion { get; set; }
        public short? ICategoria { get; set; }
        public bool BEsCategoria { get; set; }
        public DateTime? DtFechaCreacion { get; set; }

        public virtual ICollection<TblPacientes> TblPacientes { get; set; }
    }
}
