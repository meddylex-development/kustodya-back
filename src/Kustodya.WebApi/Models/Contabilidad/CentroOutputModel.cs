using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Models.Contabilidades
{
    public class CentroOutputModel
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
    }
}
