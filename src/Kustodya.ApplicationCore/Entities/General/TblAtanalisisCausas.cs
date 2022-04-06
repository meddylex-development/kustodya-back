using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblAtanalisisCausas
    {
        public long IIdanalisisCausa { get; set; }
        public long IIdaccidenteTrabajo { get; set; }
        public int IIdsubtablaAnalisisCausa { get; set; }
        public string TValorAnalisisCausa { get; set; }
        public int IIdsubtablaTipoAnalisisCausa { get; set; }
        public string TValorTipoAnalisisCausa { get; set; }
        public int IUsuarioCreacion { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblAccidentesTrabajo IIdaccidenteTrabajoNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
    }
}
