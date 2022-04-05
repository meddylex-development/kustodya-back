using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblAyudas
    {
        public long IIdayuda { get; set; }
        public string TUrl { get; set; }
        public string TObjetivo { get; set; }
        public string TFuncionalidad { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
    }
}
