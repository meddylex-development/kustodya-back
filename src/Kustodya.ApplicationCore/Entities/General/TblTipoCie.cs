using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblTipoCie
    {
        public TblTipoCie()
        {
            TblCie10 = new HashSet<TblCie10>();
        }

        public int IIdtipoCie { get; set; }
        public string TTipoCie { get; set; }

        public virtual ICollection<TblCie10> TblCie10 { get; set; }
    }
}
