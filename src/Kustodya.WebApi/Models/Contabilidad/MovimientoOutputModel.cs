using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Models.Contabilidades
{
    public class MovimientoOutputModel
    {
        public Guid Id { get; set; }
        public Guid DepuracionContableId { get; set; }
        public long CodigoContable { get; set; }
        public string DescripcionMovimiento { get; set; }
        public string NitTercero { get; set; }
        public int Debito { get; set; }
        public int Credito { get; set; }
        public string Referencia { get; set; }
        public long NumComprobanteCierre { get; set; }
        public string ReferenciacionSoportes { get; set; }
        public Guid TipoAjusteId { get; set; }
        public Guid CentroCostoId { get; set; }
    }
}
