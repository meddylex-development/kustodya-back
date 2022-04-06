using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kustodya.ApplicationCore;
using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Interfaces.General;
using Kustodya.ApplicationCore.Specifications;
using Kustodya.WebApi.Controllers.Administrativo.Usuarios;
using Kustodya.WebApi.Models.General;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;
using Kustodya.ApplicationCore.Constants;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Kustodya.ApplicationCore.Entities.Administracion;
using Kustodya.WebApi.Models;
using Kustodya.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Kustodya.ApplicationCore.Dtos;
using Kustodya.BussinessLogic.Interfaces.General;
using System.Text;
using System.IO;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Azure.Storage.Auth;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.KeyVault;
using System.Threading;
using Kustodya.WebApi.Controllers.Administrativo.Usuarios.Modelos;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;
using Kustodya.ApplicationCore.Interfaces.Configuracion.Email;

namespace Kustodya.WebApi.Controllers.Administrativo.Usuarios
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : BaseController
    {
        #region Dependency Injection
        private readonly IAsyncRepository<TblUsuarios> _repo;
        private readonly IAsyncRepository<UsuarioDireccion> _repoUsuarioDireccion;
        private readonly IAsyncRepository<UsuarioCorreo> _repoUsuarioCorreo;
        private readonly IAsyncRepository<UsuarioRedSocial> _repoUsuarioRedSocial;
        private readonly IAsyncRepository<UsuarioTelefono> _repoUsuarioTelefono;
        private readonly IAsyncRepository<UsuarioEntidad> _repoUsuarioEntidad;
        private readonly IAsyncRepository<UsuarioEntidadPerfil> _repoUsuarioEntidadPerfil;
        private readonly IAsyncRepository<UsuarioEPS> _repoUsuarioEPS;
        private readonly IAsyncRepository<Entidad> _repoEntidad;
        private readonly IAsyncRepository<TblDivipola> _repoDivipola;
        private readonly IAsyncRepository<TblPerfiles> _repoPerfiles;
        private readonly IUsuariosService _usuariosService;
        private readonly IMultivaloresService _multivaloresService;
        private readonly IMapper _mapper;
        private readonly IBlobService _blobService;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;
        #endregion
        public UsuariosController(
            IUsuariosService usuariosService,
            IMultivaloresService multivaloresService,
            IMapper mapper,
            IAsyncRepository<TblUsuarios> repo,
            IAsyncRepository<UsuarioDireccion> repoUsuarioDireccion,
            IAsyncRepository<UsuarioCorreo> repoUsuarioCorreo,
            IAsyncRepository<UsuarioRedSocial> repoUsuarioRedSocial,
            IAsyncRepository<UsuarioTelefono> repoUsuarioTelefono,
            IAsyncRepository<UsuarioEPS> repoUsuarioEPS,
            IBlobService blobService,
            IAsyncRepository<UsuarioEntidadPerfil> repoUsuarioEntidadPerfil,
            IAsyncRepository<Entidad> repoEntidad,
            IAsyncRepository<UsuarioEntidad> repoUsuarioEntidad,
            IAsyncRepository<TblDivipola> repoDivipola,
            IAsyncRepository<TblPerfiles> repoPerfiles,
            ITokenGenerator tokenGenerator,
            IConfiguration configuration,
            IEmailService emailService
            )
        {
            _repo = repo;
            _repoUsuarioDireccion = repoUsuarioDireccion;
            _repoUsuarioCorreo = repoUsuarioCorreo;
            _repoUsuarioTelefono = repoUsuarioTelefono;
            _repoUsuarioRedSocial = repoUsuarioRedSocial;
            _repoDivipola = repoDivipola;
            _repoUsuarioEPS = repoUsuarioEPS;
            _usuariosService = usuariosService;
            _multivaloresService = multivaloresService;
            _mapper = mapper;
            _blobService = blobService;
            _repoUsuarioEntidadPerfil = repoUsuarioEntidadPerfil;
            _repoEntidad = repoEntidad;
            _repoUsuarioEntidad = repoUsuarioEntidad;
            _repoPerfiles = repoPerfiles;
            _tokenGenerator = tokenGenerator;
            _configuration = configuration;
            _emailService = emailService;
        }

        /// <summary>
        /// Solo Admin
        /// </summary>
        /// <param name="entidadId"></param>
        /// <param name="busqueda"></param>
        /// <param name="pagina"></param>
        /// <returns></returns>
        [HttpGet("entidad/{entidadId:int}")]
        public async Task<IActionResult> ObtenerUsuarios(int entidadId, [FromQuery] string busqueda = "", [FromQuery] int pagina = 1)
        {
            bool EsSuperAdmin = Convert.ToBoolean(User.Claims.Where(c => c.Type == "EsSuperAdmin").FirstOrDefault().Value);
            bool Admin = (User.Claims.Where(c => c.Type == "AdminEntidades").FirstOrDefault().Value).ToString().Length > 0;
            if (EsSuperAdmin || !Admin)
                return Forbid("Este servicio solo es permitido para un administrador de entidad");

            int[] ientidadesArray = _usuariosService.ObtenerEntidades((User.Claims.Where(c => c.Type == "AdminEntidades").FirstOrDefault().Value).ToString());
            if (!ientidadesArray.Contains(entidadId))
                return Forbid("El usuario no tiene permisos para consultar los usuario de la entidad con Id: " + entidadId.ToString());
            
            int cantidad = 10;
            int total = await _usuariosService.TotalUsuarios(entidadId, busqueda);
            IReadOnlyList<TblUsuarios> listaUsuarios = await _usuariosService.ObtenerUsuariosporFiltro(entidadId, busqueda, (pagina - 1) * cantidad, cantidad);
            IReadOnlyList<UsuarioOutputModel> UsuarioOutputModel = _mapper.Map<IReadOnlyList<UsuarioOutputModel>>(listaUsuarios);
            UsuariosOutputModel usuariosOutputModel = new UsuariosOutputModel
            {
                usuariosOutputModel = UsuarioOutputModel,
                paginacion = new PaginacionModel(total, pagina, cantidad)
            };
            return Ok(usuariosOutputModel);
        }

        [HttpGet("{usuarioId:int}")]
        public async Task<IActionResult> ObtenerUsuario(int usuarioId)
        {
            GetEntidadId(out int entidadId);
            /*int userToken = Convert.ToInt32(User.Claims.Where(c => c.Type == "UserId").FirstOrDefault().Value);
            if (userToken != usuarioId)
                return Forbid();*/

            TblUsuarios usuario = await _usuariosService.ObtenerUsuarioDetalle(usuarioId);
            if (usuario == null)
                return NotFound("Usuario no existe");
            /*usuario.Entidades = usuario.Entidades.Where(c => c.EntidadId == entidadId).ToList();
            
            IReadOnlyList<Entidad> EntidadesTotal = await _repoEntidad.ListAllAsync();
            foreach (UsuarioEntidad item in usuario.Entidades)
            {
                var Entidad = EntidadesTotal.Where(c => c.Id == item.EntidadId).First();
                item.Entidad = new Entidad();
                item.Entidad = Entidad;
            }*/

            if (usuario.Firma != null)
            {
                if (usuario.Firma.Length > 0)
                {
                    try
                    {
                        MemoryStream stream = await _blobService.GetBlobFileByGuidAsync(usuario.Firma, "firmas");
                        stream.Position = 0;
                        StreamReader reader = new StreamReader(stream);
                        usuario.Firma = reader.ReadToEnd();
                    }
                    catch (Exception) { }
                }
            }
            UsuarioDetalleOutputModel usuarioDetalleOutputModel = _mapper.Map<UsuarioDetalleOutputModel>(usuario);
            IReadOnlyList<UsuarioEntidad> usuarioEntidades = await _repoUsuarioEntidad.ListAllAsync();
            var usuarioEntidad = usuarioEntidades
                .Where(c => c.UsuarioId == usuarioId && c.EntidadId == entidadId).FirstOrDefault();
            if (usuarioEntidad == null)
                return Ok(usuarioDetalleOutputModel);
            
            IReadOnlyList<UsuarioEntidadPerfil> usuarioEntidadPerfiles = await _repoUsuarioEntidadPerfil.ListAllAsync();
            var usuarioEntidadPerfil = usuarioEntidadPerfiles.Where(c => c.UsuarioEntidadId == usuarioEntidad.Id).FirstOrDefault();
            if (usuarioEntidadPerfil == null)
                return Ok(usuarioDetalleOutputModel);
            usuarioDetalleOutputModel.Perfil = usuarioEntidadPerfil.PerfilId;
            return Ok(usuarioDetalleOutputModel);
        }

        /// <summary>
        /// Solo SuperAdmin y Admin
        /// </summary>
        /// <param name="usuarioInputModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(UsuarioDetalleInputModel usuarioInputModel)
        {
            if (usuarioInputModel.EsMedico == null)
                usuarioInputModel.EsMedico = false;
            if (usuarioInputModel.Correo == null)
                return Conflict("El campo correo es requerido");
            if (usuarioInputModel.Correo.Length == 0)
                return Conflict("El campo correo es requerido");
            bool existenciaCorreo = await _usuariosService.ValidarCorreo(usuarioInputModel.Correo);
            if (existenciaCorreo)
                return Conflict("El correo ingresado ya existe");
            if (usuarioInputModel.PerfilId == 1)
                return Unauthorized("No es posible crear usuarios superadministradores");
            bool EsSuperAdmin = Convert.ToBoolean(User.Claims.Where(c => c.Type == "EsSuperAdmin").FirstOrDefault().Value);
            bool Admin = (User.Claims.Where(c => c.Type == "AdminEntidades").FirstOrDefault().Value).ToString().Length > 0;
            if (!EsSuperAdmin && !Admin)
                return Unauthorized("Este servicio solo puede ser usado por un usuario superadmin o admin de una entidad");

            if (usuarioInputModel.Entidades == null)
                return Conflict("Se requiere diligenciar la entidad");
            if (usuarioInputModel.Entidades.Count() != 1)
                return Conflict("Debe ingresar una entidad");

            IReadOnlyList<Entidad> entidades = await _repoEntidad.ListAllAsync();
            var entidad = entidades.Where(c => c.Id == usuarioInputModel.Entidades.First().Id).FirstOrDefault();
            if (entidad == null)
                return NotFound("El id de entidad " + usuarioInputModel.Entidades.First().Id.ToString() + " no existe");

            IReadOnlyList<TblPerfiles> perfiles = await _repoPerfiles.ListAllAsync();
            TblPerfiles perfil = perfiles.Where(c => c.IIdperfil == usuarioInputModel.PerfilId).FirstOrDefault();
            if (perfil == null)
                return NotFound("El perfil con Id " + usuarioInputModel.PerfilId.ToString() + " no existe");
            if (EsSuperAdmin && perfil.IIdperfil != 2)
                return Forbid("superadmin solo puede crear usuarios con perfil administrador");
            GetUserId(out int usuarioId);
            TblUsuarios usuario = _mapper.Map<TblUsuarios>(usuarioInputModel);
            usuario.DtFechaCreacion = DateTime.Now;
            usuario.IIdusuarioCreador = usuarioId;
            // convert string to stream
            if (usuario.Firma != null)
            {
                if (usuario.Firma.Length > 0)
                {
                    byte[] byteArray = Encoding.ASCII.GetBytes(usuario.Firma);
                    MemoryStream stream = new MemoryStream(byteArray);
                    stream.Position = 0;
                    Guid idArchivo = await _blobService.UploadToBlobAsync(stream, "firmas");
                    usuario.Firma = idArchivo.ToString();
                }
            }
            usuario.Entidades.First().Id = 0;
            usuario.Entidades.First().usuarioEntidadPerfiles = new List<UsuarioEntidadPerfil>();
            usuario.Entidades.First().usuarioEntidadPerfiles.Add(new UsuarioEntidadPerfil { PerfilId = usuarioInputModel.PerfilId });
            usuario.BCambioPassword = true;

            var emailConfig = _configuration.GetSection("Email");
            var templates = emailConfig.GetSection("Templates");
            var template = templates.GetSection("RegisterTemplateUser");

            string templateId = template.GetValue<string>("Id");
            string activateUrl = template.GetValue<string>("activateUrl");
            string origin = _configuration.GetValue<string>("Origin");

            usuario.EPSs = new List<UsuarioEPS> { new UsuarioEPS { Activo = true, TblEpsId = 16 } };

            TblUsuarios response = await _usuariosService.CrearUsuario(usuario);

            //Enviar correo al usuario informando la creación 
            string token = _tokenGenerator.CreateJwtSecurityToken(response);
            Dictionary<string, string> dictionary = new Dictionary<string, string>
            {
                { "username", usuario.TPrimerNombre + " " + usuario.TPrimerApellido },
                { "link", origin + activateUrl + token},
                { "origin", origin }
            };
            await _emailService.SendEmailAsync(response.TEmail, templateId, dictionary);

            return CreatedAtAction(nameof(ObtenerUsuario), new { id = response.IIdusuario }, new UsuarioOutputModel
            {
                Id = usuario.IIdusuario,
                Activo = true,
                Nombre = usuarioInputModel.PrimerNombre,
                Identificacion = usuarioInputModel.NumeroIdentificacion
            });
        }

        /// <summary>
        /// Solo SuperAdmin
        /// </summary>
        /// <param name="UsuarioId"></param>
        /// <returns></returns>
        [HttpDelete("{usuarioId:int}")]
        public async Task<IActionResult> Eliminar(int UsuarioId)
        {
            bool EsSuperAdmin = Convert.ToBoolean(User.Claims.Where(c => c.Type == "EsSuperAdmin").FirstOrDefault().Value);
            if (!EsSuperAdmin)
                return Forbid("Este servicio solo puede ser usado por un usuario superadmin");

            var usuario = await _repo.GetByIdAsync(UsuarioId);

            if (usuario is null)
                return NotFound("No se encontró el usuario con Id:" + UsuarioId.ToString());

            usuario.BActivo = false;

            await _repo.UpdateAsync(usuario);
            return NoContent();
        }

        /// <summary>
        /// Propietario, admin y superadmin
        /// </summary>
        /// <param name="inputModel"></param>
        /// <param name="usuarioId"></param>
        /// <returns></returns>
        [HttpPut("{usuarioId:int}")]
        public async Task<IActionResult> ActualizarUsuario(UsuarioInputModel inputModel, int usuarioId)
        {
            bool EsSuperAdmin = Convert.ToBoolean(User.Claims.Where(c => c.Type == "EsSuperAdmin").FirstOrDefault().Value);
            bool Admin = (User.Claims.Where(c => c.Type == "AdminEntidades").FirstOrDefault().Value).ToString().Length > 0;
            GetUserId(out int userId);
            if (!(userId == usuarioId || EsSuperAdmin || Admin))
                return Forbid("Un usuario común no puede actualizar datos de otro usuario");

            TblUsuarios usuariorepo = await _repo.GetByIdAsync(usuarioId);
            if (inputModel.Correo != null) {
                if (inputModel.Correo.Length != 0) {
                    if (inputModel.Correo != usuariorepo.TEmail)
                    {
                        bool existenciaCorreo = await _usuariosService.ValidarCorreo(inputModel.Correo);
                        if (existenciaCorreo)
                            return Conflict("El correo ingresado ya existe");
                    }
                }
            }

            _mapper.Map(inputModel, usuariorepo, typeof(UsuarioInputModel), typeof(TblUsuarios));
            await _repo.UpdateAsync(usuariorepo);
            return NoContent();
        }

        /// <summary>
        /// Solo propietario
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <returns></returns>
        [HttpPatch("{usuarioId:int}")]
        public async Task<IActionResult> Update([FromBody] JsonPatchDocument<UsuarioDetalleInputModel> registryPatch, int usuarioId)
        {
            GetUserId(out int userId);
            if (userId != usuarioId)
                return Forbid("Solo el usuario propietario de los datos puede actualizar su información");

            TblUsuarios usuario = await _usuariosService.ObtenerUsuarioDetalle(usuarioId);
            var usuarioDetalleInputModel = new UsuarioDetalleInputModel();
            
            usuarioDetalleInputModel = _mapper.Map(usuario, usuarioDetalleInputModel);

            registryPatch.ApplyTo(usuarioDetalleInputModel);
            TblUsuarios usuarioActualizado = _mapper.Map(usuarioDetalleInputModel, usuario);

            await _repo.UpdateAsync(usuarioActualizado);

            return NoContent();
        }

        /// <summary>
        /// Solo Admin y Propietario
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <param name="entidadId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{usuarioId:int}/entidad/{entidadId:int}/Perfil")]
        public async Task<IActionResult> ObtenerPerfil(int usuarioId, int entidadId)
        {
            bool Admin = (User.Claims.Where(c => c.Type == "AdminEntidades").FirstOrDefault().Value).ToString().Length > 0;
            bool EsSuperAdmin = Convert.ToBoolean(User.Claims.Where(c => c.Type == "EsSuperAdmin").FirstOrDefault().Value);
            if (EsSuperAdmin)
                return Forbid("Este servicio solo está disponible para un usuario admin de entidad o un usuario común");
            IReadOnlyList<UsuarioEntidad> usuarioEntidades = await _repoUsuarioEntidad.ListAllAsync();
            var usuarioEntidad = usuarioEntidades.Where(c => c.UsuarioId == usuarioId && c.EntidadId == entidadId).FirstOrDefault();
            if (usuarioEntidad == null)
                return NotFound("El usuario con Id: " + usuarioId.ToString() + " no se encuentra asociado a la entidad con Id: " + entidadId.ToString());
            IReadOnlyList<UsuarioEntidadPerfil> usuarioEntidadPerfiles = await _repoUsuarioEntidadPerfil.ListAllAsync();
            var usuarioEntidadPerfil = usuarioEntidadPerfiles.Where(c => c.UsuarioEntidadId == usuarioEntidad.Id).FirstOrDefault();
            if (usuarioEntidadPerfil == null)
                return NotFound("No se encontró un perfil asociado al usuario con Id: " + usuarioId.ToString() + " con la entidad con Id: " + entidadId.ToString());
            return Ok(usuarioEntidadPerfil);
        }

        [HttpGet]
        [Route("Enumeraciones")]
        public IActionResult ObtenerEnumeraciones(string enumeracion)
        {
            enumeracion = enumeracion.ToLower();
            List<EnumValueModel> enums = new List<EnumValueModel>();
            switch (enumeracion)
            {
                case "identificacion":
                    enums = ((TipoIdentificacion[])Enum.GetValues(typeof(TipoIdentificacion)))
                .Select(c => new EnumValueModel() { Value = (int)c, Name = c.ToString().Replace("_", " ") }).ToList();
                    break;
                case "via":
                    enums = ((Via[])Enum.GetValues(typeof(Via)))
                .Select(c => new EnumValueModel() { Value = (int)c, Name = c.ToString().Replace("_", " ") }).ToList();
                    break;
                case "naturaleza":
                    enums = ((Naturaleza[])Enum.GetValues(typeof(Naturaleza)))
                .Select(c => new EnumValueModel() { Value = (int)c, Name = c.ToString().Replace("_", " ") }).ToList();
                    break;
                case "entidad":
                    enums = ((TipoEntidad[])Enum.GetValues(typeof(TipoEntidad)))
                .Select(c => new EnumValueModel() { Value = (int)c, Name = c.ToString().Replace("_", " ") }).ToList();
                    break;
                case "sociedad":
                    enums = ((Sociedad[])Enum.GetValues(typeof(Sociedad)))
                .Select(c => new EnumValueModel() { Value = (int)c, Name = c.ToString().Replace("_", " ") }).ToList();
                    break;
                case "regimen":
                    enums = ((Regimen[])Enum.GetValues(typeof(Regimen)))
                .Select(c => new EnumValueModel() { Value = (int)c, Name = c.ToString().Replace("_", " ") }).ToList();
                    break;
                case "cliente":
                    enums = ((TipoCliente[])Enum.GetValues(typeof(TipoCliente)))
                .Select(c => new EnumValueModel() { Value = (int)c, Name = c.ToString().Replace("_", " ") }).ToList();
                    break;
                case "sexo":
                    enums = ((Sexos[])Enum.GetValues(typeof(Sexos)))
                .Select(c => new EnumValueModel() { Value = (int)c, Name = c.ToString().Replace("_", " ") }).ToList();
                    break;
                case "redsocial":
                    enums = ((RedSocial[])Enum.GetValues(typeof(RedSocial)))
                .Select(c => new EnumValueModel() { Value = (int)c, Name = c.ToString().Replace("_", " ") }).ToList();
                    break;
                case "estadocomprobante":
                    enums = ((Kustodya.ApplicationCore.Entities.Contabilidades.DepuracionContable.EstadoDepuracion[])Enum.GetValues(typeof(Kustodya.ApplicationCore.Entities.Contabilidades.DepuracionContable.EstadoDepuracion)))
                .Select(c => new EnumValueModel() { Value = (int)c, Name = c.ToString().Replace("_"," ") }).ToList();
                    break;
                default:
                    break;
            }
            return Ok(enums);
        }
        
        [HttpGet]
        [Route("Ciudades")]
        public async Task<IActionResult> ObtenerCiudades()
        {
            IReadOnlyList<TblDivipola> divipolas = await _repoDivipola.ListAllAsync();
            IReadOnlyList<CiudadOutputModel> ciudades = _mapper.Map<IReadOnlyList<CiudadOutputModel>>(divipolas);
            return Ok(ciudades);
        }
        
        /// <summary>
        /// superadmin y admin
        /// </summary>
        /// <returns></returns>
        [HttpGet("Administradores")]
        public async Task<IActionResult> ObtenerAdministradores([FromQuery] string busqueda = "", [FromQuery] int pagina = 1,
            [FromQuery] int? entidadId = null)
        {
            bool EsSuperAdmin = Convert.ToBoolean(User.Claims.Where(c => c.Type == "EsSuperAdmin").FirstOrDefault().Value);
            bool Admin = (User.Claims.Where(c => c.Type == "AdminEntidades").FirstOrDefault().Value).ToString().Length > 0;
            if (!EsSuperAdmin && !Admin)
                return Forbid("Este servicio solo puede ser usado por un usuario superadmin o admin de una entidad");
            if(Admin && entidadId == null)
                return Forbid("Este servicio requiere del id de la entidad para ser consumido por un administrador de una entidad");
            int cantidad = 10;
            int total = 0;
            IReadOnlyList<TblUsuarios> administradores;
            if (entidadId == null)
            {
                total = await _usuariosService.TotalAdministradores(busqueda);
                administradores = await _usuariosService.Administradores(busqueda, (pagina - 1) * cantidad, cantidad);
            }
            else {
                total = await _usuariosService.TotalAdministradoresPorEntidad(busqueda, (int)entidadId);
                administradores = await _usuariosService.AdministradoresPorEntidad(busqueda, (int)entidadId, (pagina - 1) * cantidad, cantidad);
            }
            administradores = administradores.OrderByDescending(c => c.DtFechaCreacion).ToList();
            IReadOnlyList<UsuarioOutputModel> UsuarioOutputModel = _mapper.Map<IReadOnlyList<UsuarioOutputModel>>(administradores);
            UsuariosOutputModel usuariosOutputModel = new UsuariosOutputModel
            {
                usuariosOutputModel = UsuarioOutputModel,
                paginacion = new PaginacionModel(total, pagina, cantidad)
            };
            return Ok(usuariosOutputModel);
        }
        [HttpGet("Contadores")]
        public async Task<IActionResult> ObtenerContadores()
        {
            IReadOnlyList<TblUsuarios> usuarios = await _repo.ListAllAsync();
            IReadOnlyList<UsuarioOutputModel> UsuarioOutputModel = _mapper.Map<IReadOnlyList<UsuarioOutputModel>>(usuarios);
            return Ok(UsuarioOutputModel);

        }

        [HttpPost("{usuarioId:int}/Firma")]
        public async Task<IActionResult> Post([FromForm]ArchivoModel model, int usuarioId)
        {
            TblUsuarios usuario = await _repo.GetByIdAsync(usuarioId);
            if (usuario == null)
                return NotFound("Usuario no existe");
            
            var stream = new MemoryStream();
            await model.File.CopyToAsync(stream);
            stream.Position = 0;
            Guid guid = await _blobService.UploadToBlobAsync(stream, "firmas");
            usuario.Firma = guid.ToString();
            await _repo.UpdateAsync(usuario);
            return Ok();
        }
        [HttpGet("{usuarioId:int}/Firma")]
        public async Task<IActionResult> Get(int usuarioId)
        {
            TblUsuarios usuario = await _repo.GetByIdAsync(usuarioId);
            if (usuario == null)
                return NotFound("Usuario no existe");
            if(usuario.Firma == null)
                return NotFound("El usuario no tiene firma");
            var stream = await _blobService.GetBlobFileByGuidAsync(usuario.Firma, "firmas");
            if (stream == null) return NotFound("No se encontro la firma del usuario en el repositorio de firmas");
            stream.Position = 0;
            return File(stream, "image/png", "firma.png");
        }

        [HttpPost("Activacion")]
        public async Task<IActionResult> Activar(ResetPassword reset)
        {
            GetUserId(out int userId);
            await _usuariosService.ActualizarPassword(userId, reset.Password);
            return Ok();
        }

        [HttpGet]
        [Route("Correo")]
        public async Task<IActionResult> ObtenerUsuarioporCorreo(string correo)
        {
            TblUsuarios usuario = await _usuariosService.ObtenerUsuarioDetallePorCorreo(correo);
            if (usuario == null)
                return NotFound("Usuario no existe");

            if (usuario.Firma != null)
            {
                if (usuario.Firma.Length > 0)
                {
                    try
                    {
                        MemoryStream stream = await _blobService.GetBlobFileByGuidAsync(usuario.Firma, "firmas");
                        stream.Position = 0;
                        StreamReader reader = new StreamReader(stream);
                        usuario.Firma = reader.ReadToEnd();
                    }
                    catch (Exception) { }
                }
            }
            UsuarioDetalleOutputModel usuarioDetalleOutputModel = _mapper.Map<UsuarioDetalleOutputModel>(usuario);
            return Ok(usuarioDetalleOutputModel);
        }
    }
}