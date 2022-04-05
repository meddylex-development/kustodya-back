using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Contabilidades
.Modelo
{
    public class DetalleInputModel
    {
        public int Id { get; set; }
        public int EncabezadoId { get; set; }
        public long CodigoContable { get; set; }
        public string DescripcionMovimiento { get; set; }
        public int CentroBeneficioId { get; set; }
        public string NitTercero { get; set; }
        public int? Debito { get; set; }
        public int? Credito { get; set; }
        public string Referencia { get; set; }
        public long NumComprobanteCierre { get; set; }
        public string ReferenciacionSoportes { get; set; }
        public string TipoAjuste { get; set; }
    }
}
