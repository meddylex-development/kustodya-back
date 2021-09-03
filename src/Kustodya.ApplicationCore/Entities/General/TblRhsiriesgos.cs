using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblRhsiriesgos
    {
        public long IIdrhsiriesgo { get; set; }
        public long IIdempresa { get; set; }
        public long IIdformato { get; set; }
        public DateTime DtFechaRhsi { get; set; }
        public string TArea { get; set; }
        public string TTipoRiesgo { get; set; }
        public string Triesgo { get; set; }
        public bool BActivo { get; set; }

        public virtual TblEmpresas IIdempresaNavigation { get; set; }
        public virtual TblFormatos IIdformatoNavigation { get; set; }
    }
}
