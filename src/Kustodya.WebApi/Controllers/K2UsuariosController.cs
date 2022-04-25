using AutoMapper;
using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kustodya.WebApi.Controllers.Administrativo.Usuarios.Modelos;
using Kustodya.ApplicationCore.Dtos;

namespace Kustodya.WebApi.Controllers
{
    public class K2UsuariosController : BaseController
    {
        private readonly IUsuariosService _usuariosService;
        private readonly IMapper _mapper;

        public K2UsuariosController(
            IMapper mapper,
            IUsuariosService usuariosService
            )
        {
            _mapper = mapper;
            _usuariosService = usuariosService;
        }

        // Consulta Usuarios por perfil
        [HttpGet("entidad/{entidadId:int}")]
        //[AllowAnonymous]
        public async Task<IActionResult> ConsultarUsuarios(int entidadId, int? perfil, [FromQuery] string busqueda = "", [FromQuery] int pagina = 1, [FromQuery] int cantidad = 10 )
        {
            int total = await _usuariosService.TotalUsuariosPerfil(entidadId, perfil, busqueda);
            IReadOnlyList<TblUsuarios> listaUsuarios = await _usuariosService.ObtenerUsuariosporFiltroperfil(entidadId, perfil, busqueda, (pagina - 1) * cantidad, cantidad);
            IReadOnlyList<UsuarioOutputModel> UsuarioOutputModel = _mapper.Map<IReadOnlyList<UsuarioOutputModel>>(listaUsuarios);
            UsuariosOutputModel usuariosOutputModel = new UsuariosOutputModel
            {
                usuariosOutputModel = UsuarioOutputModel,
                paginacion = new PaginacionModel(total, pagina, cantidad)
            };
            return Ok(usuariosOutputModel);
        }

    }
}
