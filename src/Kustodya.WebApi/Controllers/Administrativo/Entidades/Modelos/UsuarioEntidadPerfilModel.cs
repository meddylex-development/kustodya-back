using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Administrativo.Entidades.Modelos
{
    public class UsuarioEntidadPerfilModel
    {
        public int UsuarioId { get; set; }
        public int EntidadId { get; set; }
        [Range(2, int.MaxValue, ErrorMessage = "El perfil no puede ser 1")]
        public int PerfilId { get; set; }
    }
}
