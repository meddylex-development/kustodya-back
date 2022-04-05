using Kustodya.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Administrativo.Usuarios.Modelos
{
    public class EPSOutputModel
    {
        public int Id { get; set; }
        public  int EpsId { get; set; }
        public bool Activo { get; set; }

    }
}
