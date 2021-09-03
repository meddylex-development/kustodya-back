using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblCodigosCorrelacion
    {
        public int IIdcodigoCorrelacion { get; set; }
        public int IIdcie10 { get; set; }
        public string TCodigoCorrelacion { get; set; }

        public virtual TblCie10 IIdcie10Navigation { get; set; }
    }
}
