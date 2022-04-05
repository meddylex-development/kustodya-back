using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblCiedetalle
    {
        public decimal IdCieDetalle { get; set; }
        public decimal? IdCie { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }

        public virtual TblCie IdCieNavigation { get; set; }
    }
}
