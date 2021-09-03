using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Administrativo.Entidades.Modelos
{
    public class FirmasInputModel
    {
        public int? Gerente { get; set; }
        public int? Coordinador { get; set; }
        public int? Interventor { get; set; }
        public int? Aprobador { get; set; }
        public string CargoGerente { get; set; }
        public string CargoCoordinador { get; set; }
        public string CargoInterventor { get; set; }
    }
}
