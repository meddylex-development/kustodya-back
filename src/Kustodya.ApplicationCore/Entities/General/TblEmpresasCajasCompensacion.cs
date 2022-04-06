using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblEmpresasCajasCompensacion
    {
        public long IIdempresa { get; set; }
        public long IIdcajaCompensacion { get; set; }
        public DateTime? DFechaInicio { get; set; }
        public bool BActivo { get; set; }
        public int IIdusuarioCreador { get; set; }
        public DateTime DtFechaCreacion { get; set; }

        public virtual TblCajasCompensacion IIdcajaCompensacionNavigation { get; set; }
        public virtual TblEmpresas IIdempresaNavigation { get; set; }
    }
}
