using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblPeoresConsecuencias
    {
        public long IIdpeorConsecuencia { get; set; }
        public long IIdclasificacionRiesgo { get; set; }
        public string TPeorConsecuencia { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }
    }
}
