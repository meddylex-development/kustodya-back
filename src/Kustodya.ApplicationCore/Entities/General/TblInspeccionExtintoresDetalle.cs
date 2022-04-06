using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblInspeccionExtintoresDetalle
    {
        public long IIdinspeccionExtintorDetalle { get; set; }
        public long IIdinspeccion { get; set; }
        public string TCodigoInterno { get; set; }
        public long IIdarea { get; set; }
        public int IIdsubtablaUbicacionExtintor { get; set; }
        public string TIdvalorUbicacionExtintor { get; set; }
        public long IIdextintorTipo { get; set; }
        public DateTime DtFechaUltimaRecarga { get; set; }
        public DateTime DtFechaProximaRecarga { get; set; }
        public DateTime DtFechaUltimoMtto { get; set; }
        public DateTime DtFechaProximoMtto { get; set; }
        public int IIdsubtablaSenalizacionExtintor { get; set; }
        public string TIdvalorSenalizacionExtintor { get; set; }
        public int IIdsubtablaAccesoExtintor { get; set; }
        public string TIdvalorAccesoExtintor { get; set; }
        public string TObservaciones { get; set; }
        public bool BMedidaIntervencion { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IUsuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblEmpresaArea IIdareaNavigation { get; set; }
        public virtual TblExtintoresTipo IIdextintorTipoNavigation { get; set; }
        public virtual TblInspecciones IIdinspeccionNavigation { get; set; }
        public virtual TblUsuarios IUsuarioCreacionNavigation { get; set; }
    }
}
