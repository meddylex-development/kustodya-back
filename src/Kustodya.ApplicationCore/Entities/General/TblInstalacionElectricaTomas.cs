using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblInstalacionElectricaTomas
    {
        public long IIdtoma { get; set; }
        public long IIdinspeccion { get; set; }
        public long IIdarea { get; set; }
        public string TTipo { get; set; }
        public string TCantidad { get; set; }
        public string TPotencia { get; set; }
        public bool BFunciona { get; set; }
        public string TObservaciones { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblEmpresaArea IIdareaNavigation { get; set; }
        public virtual TblInspecciones IIdinspeccionNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
    }
}
