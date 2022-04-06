using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Administrativo.Usuarios.Modelos
{
    public class EPSInputModel
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int EPSId { get; set; }
        public bool Activo { get; set; }

    }
}
