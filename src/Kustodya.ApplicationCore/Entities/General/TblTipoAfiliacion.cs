using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblTipoAfiliacion
    {
        public TblTipoAfiliacion()
        {
            TblPacientes = new HashSet<TblPacientes>();
        }

        public byte IId { get; set; }
        public string TNombre { get; set; }
        public DateTime DtFechaCreacion { get; set; }

        public virtual ICollection<TblPacientes> TblPacientes { get; set; }
    }
}
