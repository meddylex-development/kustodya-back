using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblInstalacionElectricaCircuitos
    {
        public long IIdcircuito { get; set; }
        public long IIdinspeccion { get; set; }
        public long IIdarea { get; set; }
        public string TTablero { get; set; }
        public string TCapacidadAcometida { get; set; }
        public string TTipoProteccion { get; set; }
        public string TCorrienteNominal { get; set; }
        public int IIdsubtablaEstadoProteccion { get; set; }
        public string TValorEstadoProteccion { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblEmpresaArea IIdareaNavigation { get; set; }
        public virtual TblInspecciones IIdinspeccionNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
    }
}
