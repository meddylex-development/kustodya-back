using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Administrativo.Entidades.Modelos
{
    public class CorreoOutputModel
    {
        public int Id { get; set; }
        public string CorreoElectronico { get; set; }
        public string Descripcion { get; set; }
    }
}
