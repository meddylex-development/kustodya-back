using Kustodya.ApplicationCore.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Administrativo.Usuarios.Modelos
{
    public class RedSocialOutputModel
    {
        public int Id { get; set; }
        public RedSocial TipoRedSocial { get; set; }
        public string NombreUsuarioOLink { get; set; }
    }
}
