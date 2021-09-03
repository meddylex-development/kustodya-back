using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Incapacidades.Modelos
{
    public class DashBoardGlobales
    {
        public int TotalPendientes { get; set; }
        public int UltimoMes { get; set; }
        public int UltimaSemana { get; set; }
        public int Hoy { get; set; }
    }
}
