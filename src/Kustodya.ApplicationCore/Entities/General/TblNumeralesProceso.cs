using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblNumeralesProceso
    {
        public long IIdnumeralProceso { get; set; }
        public long IIdempresa { get; set; }
        public long IIdproceso { get; set; }
        public long IIdsubtablaEstandar { get; set; }
        public string TIdvalorEstandar { get; set; }
        public long IIdnumeral { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IIdusuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblEmpresas IIdempresaNavigation { get; set; }
        public virtual TblNumerales IIdnumeralNavigation { get; set; }
        public virtual TblEmpresaProcesos IIdprocesoNavigation { get; set; }
        public virtual TblUsuarios IIdusuarioCreacionNavigation { get; set; }
    }
}
