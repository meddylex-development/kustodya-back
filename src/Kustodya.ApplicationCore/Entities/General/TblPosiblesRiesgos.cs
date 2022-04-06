using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblPosiblesRiesgos
    {
        public long IIdposibleRiesgo { get; set; }
        public string TPosibleRiesgo { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
    }
}
