using Kustodya.ApplicationCore.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Contabilidades
.Modelo
{
    public class EncabezadoOutputModel
    {
        public int Id { get; set; }
        public long FechaElaboracion { get; set; }
        public string FichaTecnica { get; set; }
        public string DescripcionFicha { get; set; }
        public int Subcuenta { get; set; }
        public string Segmento { get; set; }
        public string ClaseDocumento { get; set; }
        public string Estado { get; set; }
    }
}
