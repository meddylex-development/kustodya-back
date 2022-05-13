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
using System.Collections;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Kustodya.BussinessLogic.Interfaces.General;

namespace Kustodya.WebApi.Controllers
{
    public class K2UsuariosController : BaseController
    {
        private readonly IUsuariosService _usuariosService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        private readonly IAsyncRepository<TblUsuarios> _repo;
        private readonly IBlobService _blobService;


        public K2UsuariosController
            (
            IMapper mapper,
            IUsuariosService usuariosService,
            IWebHostEnvironment env,
            IAsyncRepository<TblUsuarios> repo,
            IBlobService blobService
            )
        {
            _mapper = mapper;
            _usuariosService = usuariosService;
            _env = env;
            _repo = repo;
            _blobService = blobService;
        }

        // Consulta Usuarios por perfil
        [HttpGet("entidad/{entidadId:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> ConsultarUsuarios(int entidadId, int? perfil, [FromQuery] string busqueda = "", [FromQuery] int pagina = 1, [FromQuery] int cantidad = 10)
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

        [HttpPost]
        [AllowAnonymous]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Files/Firmas/" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
                return new JsonResult(filename);
            }
            catch (Exception)
            {

                return new JsonResult("anonymous.png");
            }
        }

        /*[HttpGet("{usuarioId:int}/Firma")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int usuarioId)
        {
            TblUsuarios usuario = await _repo.GetByIdAsync(usuarioId);
            if (usuario == null)
                return NotFound("Usuario no existe");
            if (usuario.Firma == null)
                return NotFound("El usuario no tiene firma");
            var stream = await _blobService.GetBlobFileByGuidAsync(usuario.Firma, "firmas");
            if (stream == null) return NotFound("No se encontro la firma del usuario en el repositorio de firmas");
            stream.Position = 0;
            return File(stream, "image/png", "firma.png");
        }*/

    }
}
