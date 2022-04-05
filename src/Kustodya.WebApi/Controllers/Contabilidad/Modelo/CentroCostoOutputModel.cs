using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Contabilidades
.Modelo
{
    public class CentroCostoOutputModel
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public SegmentoOutputModel Segmento { get; set; }
        public RegionalOutputModel Regional { get; set; }
    }
}
