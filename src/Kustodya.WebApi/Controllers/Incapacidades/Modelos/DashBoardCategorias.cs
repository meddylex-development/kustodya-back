using Kustodya.ApplicationCore.Entities.Concepto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Incapacidades.Modelos
{
    public class DashBoardCategoria
    {
        public string categoria { get; set; }
        public int cantidad { get; set; }
        public int estado { get; set; }
    }
}
