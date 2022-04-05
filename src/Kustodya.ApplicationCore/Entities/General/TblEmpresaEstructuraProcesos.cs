using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblEmpresaEstructuraProcesos
    {
        public long IIdempresaEstructuraProceso { get; set; }
        public long IIdempresa { get; set; }
        public long INivelProceso { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblEmpresas IIdempresaNavigation { get; set; }
        public virtual TblMultivalores INivelProcesoNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
    }
}
