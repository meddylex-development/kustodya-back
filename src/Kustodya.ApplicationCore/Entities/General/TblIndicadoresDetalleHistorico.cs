using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblIndicadoresDetalleHistorico
    {
        public long IIdindicadorDetalleHistorico { get; set; }
        public long IIdindicadorDetalle { get; set; }
        public int IVersion { get; set; }
        public long IIdmatrizIndicador { get; set; }
        public string TNombreIndicador { get; set; }
        public string TDescripcion { get; set; }
        public int IIdsubtablaTipoIndicador { get; set; }
        public string TIdvalorTipoIndicador { get; set; }
        public string TFormula { get; set; }
        public string TMeta { get; set; }
        public string TOrigenDatos { get; set; }
        public long IIdresponsableInformacion { get; set; }
        public int IIdsubtablaRecoleccionPeriodicidad { get; set; }
        public string TIdvalorRecoleccionPeriodicidad { get; set; }
        public long IIdresponsableAnalisis { get; set; }
        public int IIdsubtablaFrecuenciaAnalisis { get; set; }
        public string TIdvalorFrecuenciaAnalisis { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IIdusuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblIndicadoresDetalle IIdindicadorDetalleNavigation { get; set; }
    }
}
