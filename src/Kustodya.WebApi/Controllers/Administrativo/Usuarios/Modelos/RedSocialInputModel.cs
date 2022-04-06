using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Administrativo.Usuarios.Modelos
{
    public class RedSocialInputModel
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int RedSocial { get; set; }
        public string NombreUsuarioOLink { get; set; }
    }
}
