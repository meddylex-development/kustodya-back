using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblInspecciones
    {
        public TblInspecciones()
        {
            TblInspeccionExtintoresDetalle = new HashSet<TblInspeccionExtintoresDetalle>();
            TblInstalacionElectricaAlumbrado = new HashSet<TblInstalacionElectricaAlumbrado>();
            TblInstalacionElectricaCircuitos = new HashSet<TblInstalacionElectricaCircuitos>();
            TblInstalacionElectricaInterruptores = new HashSet<TblInstalacionElectricaInterruptores>();
            TblInstalacionElectricaTomas = new HashSet<TblInstalacionElectricaTomas>();
        }

        public long IIdinspeccion { get; set; }
        public long IIdempresa { get; set; }
        public long IIdvigencia { get; set; }
        public long? IIdtarea { get; set; }
        public int IIdsubtablaTipoInspeccion { get; set; }
        public string TIdvalorTipoInspeccion { get; set; }
        public int IIdsubtablaTipoInspector { get; set; }
        public string TIdvalorTipoInspector { get; set; }
        public long IIdinspector { get; set; }
        public DateTime DtFechaInspeccion { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblEmpresas IIdempresaNavigation { get; set; }
        public virtual TblTareas IIdtareaNavigation { get; set; }
        public virtual TblEmpresasVigencia IIdvigenciaNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
        public virtual ICollection<TblInspeccionExtintoresDetalle> TblInspeccionExtintoresDetalle { get; set; }
        public virtual ICollection<TblInstalacionElectricaAlumbrado> TblInstalacionElectricaAlumbrado { get; set; }
        public virtual ICollection<TblInstalacionElectricaCircuitos> TblInstalacionElectricaCircuitos { get; set; }
        public virtual ICollection<TblInstalacionElectricaInterruptores> TblInstalacionElectricaInterruptores { get; set; }
        public virtual ICollection<TblInstalacionElectricaTomas> TblInstalacionElectricaTomas { get; set; }
    }
}
