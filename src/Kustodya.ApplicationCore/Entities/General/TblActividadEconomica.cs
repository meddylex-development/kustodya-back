using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblActividadEconomica
    {
        public TblActividadEconomica()
        {
            TblEmpresasTerceros = new HashSet<TblEmpresasTerceros>();
        }

        public short IId { get; set; }
        public string TNombreActividad { get; set; }
        public string TCiiu { get; set; }

        public virtual ICollection<TblEmpresasTerceros> TblEmpresasTerceros { get; set; }
    }
}
