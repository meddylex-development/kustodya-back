using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblEntradasSalidas
    {
        public long IIdentradaSalida { get; set; }
        public long IIdempresa { get; set; }
        public long IIdproceso { get; set; }
        public int IIdsubtablaTipoEntradaSalidaProceso { get; set; }
        public string TIdvalorTipoEntradaSalidaProceso { get; set; }
        public int IIdsubtablaTipoOrigen { get; set; }
        public string TIdvalorTipoOrigen { get; set; }
        public int? IIdsubtablaClaseOrigen { get; set; }
        public string TIdvalorClaseOrigen { get; set; }
        public long? IIdareaProceso { get; set; }
        public string TOrigenExterno { get; set; }
        public string TDescripcion { get; set; }
        public int IIdsubtablaPeriodicidad { get; set; }
        public string TIdvalorPeriodicidad { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IIdusuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblEmpresas IIdempresaNavigation { get; set; }
        public virtual TblEmpresaProcesos IIdprocesoNavigation { get; set; }
        public virtual TblUsuarios IIdusuarioCreacionNavigation { get; set; }
    }
}
