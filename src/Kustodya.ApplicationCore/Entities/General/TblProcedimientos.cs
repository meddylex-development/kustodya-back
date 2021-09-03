using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblProcedimientos
    {
        public long IIdprocedimiento { get; set; }
        public long IIdempresa { get; set; }
        public long IIdproceso { get; set; }
        public string TActividad { get; set; }
        public long IIdresponsable { get; set; }
        public string TDescripcion { get; set; }
        public string TEntradaSalida { get; set; }
        public string TVa { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblEmpresas IIdempresaNavigation { get; set; }
        public virtual TblEmpresaProcesos IIdprocesoNavigation { get; set; }
        public virtual TblCargos IIdresponsableNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
    }
}
