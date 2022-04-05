using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.DTOs.Contabilidades
{
    public class TerceroInputModel
    {
        public string TipoPersona { get; set; }
        public string TipoId { get; set; }
        public string NumeroId { get; set; }
        public string RazonSocial { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public int? DigVerificacion { get; set; }
        public long NumeroComprobante { get; set; }
        public DateTime FechaComprobante { get; set; }
        public long CodigoContable { get; set; }
        public int ValorCredito { get; set; }
        public int ValorDebito { get; set; }
        public string CodigoContabilidad { get; set; }
        public string CentroCosto { get; set; }
        public DateTime FechaCorte { get; set; }
    }
}
