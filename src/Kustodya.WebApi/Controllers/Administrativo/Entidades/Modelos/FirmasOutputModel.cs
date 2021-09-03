using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Administrativo.Entidades.Modelos
{
    public class FirmasOutputModel
    {
        public string Rol { get; set; }
        public int? UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Cargo { get; set; }
    }
}
