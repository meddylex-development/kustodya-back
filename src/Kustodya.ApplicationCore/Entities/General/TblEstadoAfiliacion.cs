using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblEstadoAfiliacion
    {
        public TblEstadoAfiliacion()
        {
            TblPacientes = new HashSet<TblPacientes>();
        }

        public byte IId { get; set; }
        public string TNombre { get; set; }

        public virtual ICollection<TblPacientes> TblPacientes { get; set; }
    }
}
