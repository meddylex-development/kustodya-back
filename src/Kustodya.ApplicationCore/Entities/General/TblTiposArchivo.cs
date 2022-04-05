using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblTiposArchivo
    {
        public TblTiposArchivo()
        {
            TblBlobs = new HashSet<TblBlobs>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TblBlobs> TblBlobs { get; set; }
    }
}
