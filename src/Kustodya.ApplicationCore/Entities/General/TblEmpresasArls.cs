using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblEmpresasArls
    {
        public long IIdempresa { get; set; }
        public long IIdarl { get; set; }
        public DateTime? DFechaInicio { get; set; }
        public bool BActivo { get; set; }
        public int IIdusuarioCreador { get; set; }
        public DateTime DtFechaCreacion { get; set; }

        public virtual TblArls IIdarlNavigation { get; set; }
        public virtual TblEmpresas IIdempresaNavigation { get; set; }
        public virtual TblUsuarios IIdusuarioCreadorNavigation { get; set; }
    }
}
