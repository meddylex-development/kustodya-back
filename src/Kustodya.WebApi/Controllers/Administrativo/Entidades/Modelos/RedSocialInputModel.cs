using Kustodya.ApplicationCore.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Administrativo.Entidades.Modelos
{
    public class RedSocialInputModel
    {

        public int Id { get; set; }
        public int EntidadId { get; set; }
        public RedSocial RedSocial { get; set; }
        public string NombreUsuarioOLink { get; set; }
    }
}
