using Kustodya.ApplicationCore.Dtos;
using Kustodya.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Administrativo.Usuarios.Modelos
{
    public class UsuariosOutputModel
    {
        public IReadOnlyList<UsuarioOutputModel> usuariosOutputModel { get; set; }
        public PaginacionModel paginacion { get; set; }
    }
}
