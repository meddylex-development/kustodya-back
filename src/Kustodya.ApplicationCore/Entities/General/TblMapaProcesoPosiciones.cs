using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblMapaProcesoPosiciones
    {
        public long IIdposicionProceso { get; set; }
        public long IIdempresa { get; set; }
        public long IIdempresaProceso { get; set; }
        public int IPosicionX { get; set; }
        public int IPosicionY { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblEmpresas IIdempresaNavigation { get; set; }
        public virtual TblEmpresaProcesos IIdempresaProcesoNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
    }
}
