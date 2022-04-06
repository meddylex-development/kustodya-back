using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Administrativo.Usuarios.Modelos
{
    public class CorreoInputModel
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string CorreoElectronico { get; set; }
        public string Descripcion { get; set; }
    }
}
