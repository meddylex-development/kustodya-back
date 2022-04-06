using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblProcesos
    {
        public long IIdproceso { get; set; }
        public long IIdempresa { get; set; }
        public long IIdtipoProceso { get; set; }
        public string TNombreProceso { get; set; }
        public string TCodigo { get; set; }
        public long? ILider { get; set; }
        public DateTime DtUsuarioCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblEmpresas IIdempresaNavigation { get; set; }
        public virtual TblTipoProceso IIdtipoProcesoNavigation { get; set; }
        public virtual TblEmpleados ILiderNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
    }
}
