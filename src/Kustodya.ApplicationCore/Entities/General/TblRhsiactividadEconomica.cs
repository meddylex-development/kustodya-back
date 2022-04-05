using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblRhsiactividadEconomica
    {
        public long IIdrhsiactividadEconomica { get; set; }
        public long IIdempresa { get; set; }
        public long IIdformato { get; set; }
        public DateTime DtFechaRhsi { get; set; }
        public string TCodigo { get; set; }
        public string TActividadEconomica { get; set; }
        public bool BActivo { get; set; }

        public virtual TblEmpresas IIdempresaNavigation { get; set; }
        public virtual TblFormatos IIdformatoNavigation { get; set; }
    }
}
