using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblSoa
    {
        public long IIdsoa { get; set; }
        public long IIdempresa { get; set; }
        public long IIdnumeral { get; set; }
        public string TAplicacion { get; set; }
        public string TJustificacion { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblEmpresas IIdempresaNavigation { get; set; }
        public virtual TblNumerales IIdnumeralNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
    }
}
