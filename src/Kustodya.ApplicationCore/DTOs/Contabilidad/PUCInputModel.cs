using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.DTOs.Contabilidades
{
    public class PUCInputModel
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Contabilidad { get; set; }
        public int EntidadId { get; set; }
    }
}
