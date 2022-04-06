using Kustodya.ApplicationCore.Entities.Concepto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Incapacidades.Modelos
{
    public class DashboardOutputModel
    {
        public string categorias { get; set; }
        public DashBoardGlobales dashBoardGlobales { get; set; }

    }
}
