using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblEmpresaJurisprudencias
    {
        public long IIdempresaJurisprudencia { get; set; }
        public long IIdempresa { get; set; }
        public long IIdjurisprudencia { get; set; }
        public int IIdusuarioCreacion { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblEmpresas IIdempresaNavigation { get; set; }
        public virtual TblJurisprudencias IIdjurisprudenciaNavigation { get; set; }
        public virtual TblUsuarios IIdusuarioCreacionNavigation { get; set; }
    }
}
