using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Administrativo.Auditoria.Modelos
{
    public class AuditoriaInputModel
    {
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public ApplicationCore.Entities.Administracion.Auditoria.TipoAccion Accion { get; set; }
    }
}

