using System;
using System.Collections.Generic;

namespace Kustodya.ApplicationCore.Entities
{
    public partial class TblIndicadoresSeguimiento
    {
        public long IIdindicadorSeguimiento { get; set; }
        public long IIdindicadorDetalle { get; set; }
        public double IResultado { get; set; }
        public string TAnalisis { get; set; }
        public int IIdsubtablaRequierePlanAccion { get; set; }
        public string TIdvalorRequierePlanAccion { get; set; }
        public DateTime DtFechaCreacion { get; set; }
        public int IIdusuarioCreacion { get; set; }
        public bool BActivo { get; set; }

        public virtual TblIndicadoresDetalle IIdindicadorDetalleNavigation { get; set; }
    }
}
