using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Kustodya.ApplicationCore.Dtos;
using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Entities.Administracion;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.BussinessLogic.Interfaces.General;
using Kustodya.WebApi.Controllers.Administrativo.Entidades.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Kustodya.WebApi.Controllers.Administrativo.Entidades
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntidadesController : BaseController
    {
        #region Dependency Injection
        private readonly IUsuariosService _usuarioService;
        private readonly IBlobService _blobService;
        private readonly IEntidadService _entidadService;
        private readonly IAsyncRepository<Entidad> _repoEntidad;
        private readonly IAsyncRepository<TblUsuarios> _repoUsuario;
        private readonly IAsyncRepository<TblCiiu> _repoCIIU;
        
        private readonly MapperConfiguration _config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfiles>();
            cfg.CreateMap<EntidadInputModel, Entidad>();
            cfg.CreateMap<EntidadDetalleInputModel, Entidad>();
            cfg.CreateMap<Entidad, EntidadDetalleInputModel>();

            cfg.CreateMap<Entidad, EntidadOutputModel>();
            cfg.CreateMap<Entidad, EntidadDetalleOutputModel>();
        });
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<UsuarioEntidadPerfil> _repoUsuarioEntidadPerfil;
        private readonly IAsyncRepository<UsuarioEntidad> _repoUsuarioEntidad;
        private readonly IAsyncContabilidadRepository<ApplicationCore.Entities.Contabilidades.Contabilidad> _repoContabilidad;
        #endregion
        public EntidadesController(
            IAsyncRepository<Entidad> repoEntidad,
            IBlobService blobService,
            IEntidadService entidadService,
            IAsyncRepository<UsuarioEntidadPerfil> repoUsuarioEntidadPerfil,
            IAsyncRepository<UsuarioEntidad> repoUsuarioEntidad,
            IAsyncRepository<TblUsuarios> repoUsuario,
            IUsuariosService usuarioService,
            IAsyncRepository<TblCiiu> repoCIIU,
            IAsyncContabilidadRepository<ApplicationCore.Entities.Contabilidades.Contabilidad> repoContabilidad
            )
        {
            _repoEntidad = repoEntidad;
            _entidadService = entidadService;
            _mapper = _config.CreateMapper();
            _blobService = blobService;
            _repoUsuarioEntidadPerfil = repoUsuarioEntidadPerfil;
            _repoUsuarioEntidad = repoUsuarioEntidad;
            _repoEntidad = repoEntidad;
            _repoUsuario = repoUsuario;
            _usuarioService = usuarioService;
            _repoCIIU = repoCIIU;
            _repoContabilidad = repoContabilidad;
        }

        /// <summary>
        /// Solo usuario Superadmin
        /// </summary>
        /// <param name="entidadDetalleInputModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(EntidadDetalleInputModel entidadDetalleInputModel)
        {
            bool validarExistencia = await _entidadService.ValidarTipoIdNumIdyNombreCia(entidadDetalleInputModel.TipoId,
                entidadDetalleInputModel.NumeroId, entidadDetalleInputModel.NombreCompania);
            if (validarExistencia)
                return Conflict("Ya existe una entidad con el mismo tipo de identificación, numero de identificación y nombre de compañia");
            bool EsSuperAdmin = Convert.ToBoolean(User.Claims.Where(c => c.Type == "EsSuperAdmin").FirstOrDefault().Value);
            if (!EsSuperAdmin)
                return Forbid("Este servicio solo está permitido para ser usado por un usuario superadmin");
            GetUserId(out int usuarioId);
            Entidad entidad = _mapper.Map<Entidad>(entidadDetalleInputModel);

            List<int> TiposIdconDV = new List<int> { 10, 11 };

            if (entidad.DigitoVerificacion == null && TiposIdconDV.Contains((int)entidad.TipoId))
                return Conflict("El dígito de verificación es requerido para personas jurídicas");

            if (entidad.DigitoVerificacion != null)
                if (entidad.DigitoVerificacion != entidad.ValidarDigitoVerificacion())
                    return Conflict("El dígito de verificación no es valido");
            entidad.Activo = true;
            if (entidad.Logo != null)
            {
                if (entidad.Logo.Length > 0)
                {
                    byte[] byteArray = Encoding.ASCII.GetBytes(entidad.Logo);
                    MemoryStream stream = new MemoryStream(byteArray);
                    stream.Position = 0;
                    Guid idArchivo = await _blobService.UploadToBlobAsync(stream, "logos");
                    entidad.Logo = idArchivo.ToString();
                }
            }
            entidad.FechaCreacion = DateTime.Now;
            entidad.UsuarioCreacion = usuarioId;
            entidad.FechaActualizacion = DateTime.Now;
            entidad.UsuarioActualizacion = usuarioId;
            entidad.Usuarios = new List<UsuarioEntidad> { new UsuarioEntidad { UsuarioId = usuarioId } };
            entidad.Usuarios.First().usuarioEntidadPerfiles =
                new List<UsuarioEntidadPerfil> { new UsuarioEntidadPerfil { PerfilId = 1 } };
            Entidad response = await _repoEntidad.AddAsync(entidad);

            return CreatedAtAction(nameof(ObtenerEntidad), new { id = response.Id }, new EntidadOutputModel
            {
                Id = response.Id,
                Nombre = entidad.RazonSocial + entidad.PrimerNombre + " " + entidad.PrimerApellido
            });
        }

        /// <summary>
        /// Solo usuario Admin o Superadmin
        /// </summary>
        /// <param name="entidadDetalleInputModel"></param>
        /// <returns></returns>
        [HttpGet("{entidadId:int}")]
        public async Task<IActionResult> ObtenerEntidad(int entidadId)
        {
            GetEntidadId(out int entidadToken);
            bool EsSuperAdmin = Convert.ToBoolean(User.Claims.Where(c => c.Type == "EsSuperAdmin").FirstOrDefault().Value);
            bool Admin = (User.Claims.Where(c => c.Type == "AdminEntidades").FirstOrDefault().Value).ToString().Length > 0;
            if (!EsSuperAdmin && !Admin && entidadId != entidadToken)
                return Forbid("Este servicio solo esta permitido para un usuario admin o superadmin");

            Entidad entidad = await _entidadService.ObtenerEntidadDetalle(entidadId);
            if (entidad.Logo != null)
            {
                if (entidad.Logo.Length > 0)
                {
                    try
                    {
                        MemoryStream stream = await _blobService.GetBlobFileByGuidAsync(entidad.Logo, "logos");
                        stream.Position = 0;
                        StreamReader reader = new StreamReader(stream);
                        entidad.Logo = reader.ReadToEnd();
                    }
                    catch (Exception) { }
                }
            }
            EntidadDetalleOutputModel entidadDetalleOutputModel = _mapper.Map<EntidadDetalleOutputModel>(entidad);
            var contabilidad = await _repoContabilidad.GetByIdAsync(entidad.ContabilidadPorDefectoId);
            if (contabilidad != null)
                entidadDetalleOutputModel.ContabilidadDefecto = contabilidad.Codigo;

            return Ok(entidadDetalleOutputModel);
        }

        /// <summary>
        /// Solo usuario Superadmin
        /// </summary>
        /// <param name="entidadDetalleInputModel"></param>
        /// <returns></returns>
        [HttpGet()]
        public async Task<IActionResult> ObtenerEntidades([FromQuery] string busqueda = "", [FromQuery] int pagina = 1, [FromQuery] int cantidad = 10)
        {
            bool EsSuperAdmin = Convert.ToBoolean(User.Claims.Where(c => c.Type == "EsSuperAdmin").FirstOrDefault().Value);
            if (!EsSuperAdmin)
                return Forbid();
            int total = await _entidadService.TotalEntidades(busqueda);
            IReadOnlyList<Entidad> entidades = await _entidadService.ObtenerEntidadesporFiltro(busqueda, (pagina - 1) * cantidad, cantidad);
            IReadOnlyList<EntidadOutputModel> entidadOutputModel = _mapper.Map<IReadOnlyList<EntidadOutputModel>>(entidades);
            EntidadesOutputModel entidadesOutputModel = new EntidadesOutputModel
            {
                entidadesOutputModel = entidadOutputModel,
                paginacion = new PaginacionModel(total, pagina, cantidad)
            };
            return Ok(entidadesOutputModel);
        }

        /// <summary>
        /// Solo usuario Superadmin
        /// </summary>
        /// <param name="inputModel"></param>
        /// <param name="entidadId"></param>
        /// <returns></returns>
        [HttpPut("{entidadId:int}")]
        public async Task<IActionResult> ActualizarEntidad(EntidadInputModel inputModel, int entidadId)
        {
            bool EsSuperAdmin = Convert.ToBoolean(User.Claims.Where(c => c.Type == "EsSuperAdmin").FirstOrDefault().Value);
            if (!EsSuperAdmin)
                return Forbid();
            int usuarioId = Convert.ToInt32(User.Claims.Where(c => c.Type == "UserId").FirstOrDefault().Value);
            Entidad entidadrepo = await _repoEntidad.GetByIdAsync(entidadId);
            if (entidadrepo.TipoId != inputModel.TipoId || entidadrepo.NumeroId != inputModel.NumeroId || entidadrepo.NombreCompania != inputModel.NombreCompania)
            {
                bool validarExistencia = await _entidadService.ValidarTipoIdNumIdyNombreCia(inputModel.TipoId,
                inputModel.NumeroId, inputModel.NombreCompania);
                if (validarExistencia)
                    return BadRequest("Ya existe una entidad con el mismo tipo de identificación, numero de identificación y nombre de compañia");
            }
            _mapper.Map(inputModel, entidadrepo, typeof(EntidadInputModel), typeof(Entidad));
            if (entidadrepo.DigitoVerificacion != null)
                if (entidadrepo.DigitoVerificacion != entidadrepo.ValidarDigitoVerificacion())
                    return Conflict("El dígito de verificación no es valido");
            entidadrepo.FechaActualizacion = DateTime.Now;
            entidadrepo.UsuarioActualizacion = usuarioId;

            //Actualizar Usuarios por defecto
            await _repoEntidad.UpdateAsync(entidadrepo);
            return NoContent();
        }

        /// <summary>
        /// Solo usuario Superadmin
        /// </summary>
        /// <param name="entidadId"></param>
        /// <returns></returns>
        [HttpDelete("{entidadId:int}")]
        public async Task<IActionResult> Eliminar(int entidadId)
        {
            bool EsSuperAdmin = Convert.ToBoolean(User.Claims.Where(c => c.Type == "EsSuperAdmin").FirstOrDefault().Value);
            if (!EsSuperAdmin)
                return Forbid();
            var entidad = await _repoEntidad.GetByIdAsync(entidadId);

            if (entidad is null)
                return NotFound();

            entidad.Activo = false;

            await _repoEntidad.UpdateAsync(entidad);
            return NoContent();
        }

        /// <summary>
        /// Solo usuario Superadmin
        /// </summary>
        /// <param name="entidadDetalleInputModel"></param>
        /// <returns></returns>
        [HttpPatch("{entidadId:int}")]
        public async Task<IActionResult> Update([FromBody] JsonPatchDocument<EntidadDetalleInputModel> registryPatch, int entidadId)
        {
            bool EsSuperAdmin = Convert.ToBoolean(User.Claims.Where(c => c.Type == "EsSuperAdmin").FirstOrDefault().Value);
            if (!EsSuperAdmin)
                return Forbid();
            Entidad entidad = await _entidadService.ObtenerEntidadDetalle(entidadId);
            var entidadDetalleInputModel = new EntidadDetalleInputModel();
            entidadDetalleInputModel = _mapper.Map(entidad, entidadDetalleInputModel);
            registryPatch.ApplyTo(entidadDetalleInputModel);
            Entidad entidadActualizado = _mapper.Map(entidadDetalleInputModel, entidad);
            await _repoEntidad.UpdateAsync(entidadActualizado);
            return NoContent();
        }

        /// <summary>
        /// Usuario Comun y Admin
        /// </summary>
        /// <param name="entidadDetalleInputModel"></param>
        /// <returns></returns>
        [HttpGet("listado")]
        public async Task<IActionResult> listadoEntidades()
        {
            bool EsSuperAdmin = Convert.ToBoolean(User.Claims.Where(c => c.Type == "EsSuperAdmin").FirstOrDefault().Value);
            int usuarioId = Convert.ToInt32(User.Claims.Where(c => c.Type == "UserId").FirstOrDefault().Value);
            if (EsSuperAdmin)
                return Forbid();

            IReadOnlyList<Entidad> entidades = await _repoEntidad.ListAllAsync();
            string entidadesArray = await _usuarioService.ObtenerEntidadesUsuario(usuarioId);
            int[] ientidadesArray = _usuarioService.ObtenerEntidades(entidadesArray);
            entidades = entidades.Where(c => ientidadesArray.Contains(c.Id)).ToList();

            IReadOnlyList<EntidadOutputModel> entidadOutputModels = _mapper.Map<IReadOnlyList<EntidadOutputModel>>(entidades);
            return Ok(entidadOutputModels);
        }

        /// <summary>
        /// Solo Admin
        /// </summary>
        /// <param name="entidadDetalleInputModel"></param>
        /// <returns></returns>
        [HttpGet("listadoadministrador")]
        public async Task<IActionResult> listadoAdministrador()
        {
            bool EsSuperAdmin = Convert.ToBoolean(User.Claims.Where(c => c.Type == "EsSuperAdmin").FirstOrDefault().Value);
            bool Admin = (User.Claims.Where(c => c.Type == "AdminEntidades").FirstOrDefault().Value).ToString().Length > 0;
            int usuarioId = Convert.ToInt32(User.Claims.Where(c => c.Type == "UserId").FirstOrDefault().Value);
            if (EsSuperAdmin && !Admin)
                return Forbid();

            IReadOnlyList<Entidad> entidades = await _repoEntidad.ListAllAsync();
            string entidadesArray = await _usuarioService.ObtenerEntidadesAdministrador(usuarioId);
            int[] ientidadesArray = _usuarioService.ObtenerEntidades(entidadesArray);
            entidades = entidades.Where(c => ientidadesArray.Contains(c.Id)).ToList();

            IReadOnlyList<EntidadOutputModel> entidadOutputModels = _mapper.Map<IReadOnlyList<EntidadOutputModel>>(entidades);
            return Ok(entidadOutputModels);
        }

        [HttpPost("usuario")]
        public async Task<IActionResult> AsociarUsuario(UsuarioEntidadPerfilModel usuarioEntidadPerfilModel)
        {

            bool EsSuperAdmin = Convert.ToBoolean(User.Claims.Where(c => c.Type == "EsSuperAdmin").FirstOrDefault().Value);
            bool Admin = (User.Claims.Where(c => c.Type == "AdminEntidades").FirstOrDefault().Value).ToString().Length > 0;

            if (!EsSuperAdmin && !Admin)
            {
                return Forbid();
            }
            if ((EsSuperAdmin && usuarioEntidadPerfilModel.PerfilId != 2) || (!EsSuperAdmin && usuarioEntidadPerfilModel.PerfilId == 2))
            {
                return Forbid();
            }
            if (Admin)
            {
                int[] ientidadesArray = _usuarioService.ObtenerEntidades((User.Claims.Where(c => c.Type == "AdminEntidades").FirstOrDefault().Value).ToString());
                if (ientidadesArray.Contains(usuarioEntidadPerfilModel.EntidadId))
                    return Forbid();
            }
            IReadOnlyList<UsuarioEntidad> usuarioEntidades = await _repoUsuarioEntidad.ListAllAsync();
            UsuarioEntidad usuarioEntidad = usuarioEntidades
                .Where(c => c.EntidadId == usuarioEntidadPerfilModel.EntidadId && c.UsuarioId == usuarioEntidadPerfilModel.UsuarioId)
                .FirstOrDefault();
            if (usuarioEntidad == null)
            {
                usuarioEntidad = new UsuarioEntidad
                {
                    UsuarioId = usuarioEntidadPerfilModel.UsuarioId,
                    EntidadId = usuarioEntidadPerfilModel.EntidadId,
                };
                usuarioEntidad.usuarioEntidadPerfiles = new List<UsuarioEntidadPerfil> {
                    new UsuarioEntidadPerfil{ PerfilId = usuarioEntidadPerfilModel.PerfilId } };
                await _repoUsuarioEntidad.AddAsync(usuarioEntidad);
            }
            else
            {
                if (usuarioEntidad.usuarioEntidadPerfiles == null)
                {
                    usuarioEntidad.usuarioEntidadPerfiles = new List<UsuarioEntidadPerfil> {
                    new UsuarioEntidadPerfil{ PerfilId = usuarioEntidadPerfilModel.PerfilId } };
                    await _repoUsuarioEntidad.UpdateAsync(usuarioEntidad);
                }
                else
                {
                    usuarioEntidad.usuarioEntidadPerfiles.First().PerfilId = usuarioEntidadPerfilModel.PerfilId;
                    await _repoUsuarioEntidad.UpdateAsync(usuarioEntidad);
                }
            }
            return Ok();
        }

        [HttpPost("{entidadId:int}/Logo")]
        public async Task<IActionResult> Post([FromForm]Kustodya.WebApi.Models.ArchivoModel model, int entidadId)
        {
            Entidad entidad = await _repoEntidad.GetByIdAsync(entidadId);
            if (entidad == null)
                return NotFound("Entidad no existe");

            var stream = new MemoryStream();
            await model.File.CopyToAsync(stream);
            stream.Position = 0;
            Guid guid = await _blobService.UploadToBlobAsync(stream, "logos");
            entidad.Logo = guid.ToString();
            await _repoEntidad.UpdateAsync(entidad);
            return Ok();
        }
        [HttpGet("{entidadId:int}/Logo")]
        public async Task<IActionResult> Get(int entidadId)
        {
            Entidad entidad = await _repoEntidad.GetByIdAsync(entidadId);
            if (entidad == null)
                return NotFound("Entidad no existe");
            if (entidad.Logo == null)
                return NotFound("La entidad no tiene logo");
            var stream = await _blobService.GetBlobFileByGuidAsync(entidad.Logo, "logos");
            if (stream == null) return NotFound("No se encontro el logo de la entidad en el repositorio de logos");
            stream.Position = 0;
            return File(stream, "image/png", "logo.png");
        }

        [HttpGet("CIIU")]
        public async Task<IActionResult> Get()
        {
            IReadOnlyList<TblCiiu> ciius = await _repoCIIU.ListAllAsync();
            return Ok(ciius);
        }
        /// <summary>
        /// 
        /// </summary> Admin y superadmin
        /// <param name="entidadId"></param>
        /// <param name="usuarioId"></param>
        /// <returns></returns>
        [HttpDelete("{entidadId}/Usuarios/{usuarioId}")]
        public async Task<IActionResult> DesasociarUsuario(int entidadId, int usuarioId)
        {

            bool EsSuperAdmin = Convert.ToBoolean(User.Claims.Where(c => c.Type == "EsSuperAdmin").FirstOrDefault().Value);
            bool Admin = (User.Claims.Where(c => c.Type == "AdminEntidades").FirstOrDefault().Value).ToString().Length > 0;
            if (!Admin && !EsSuperAdmin)
                return Forbid("Este servicio solo está disponible para un usuario administrador");
            if (Admin)
            {
                int[] ientidadesArray = _usuarioService.ObtenerEntidades((User.Claims.Where(c => c.Type == "AdminEntidades").FirstOrDefault().Value).ToString());
                if (!ientidadesArray.Contains(entidadId))
                    return Forbid("El usuario no tiene permisos para consultar los usuario de la entidad con Id: " + entidadId.ToString());
            }
            IReadOnlyList<UsuarioEntidad> usuarioEntidades = await _repoUsuarioEntidad.ListAllAsync();
            var usuarioEntidad = usuarioEntidades.Where(c => c.EntidadId == entidadId && c.UsuarioId == usuarioId).FirstOrDefault();
            if (usuarioEntidad == null)
                return NotFound("El usuario con Id: " + usuarioId.ToString() + " no se encuentra asociado a la entidad con Id: " + entidadId.ToString());
            await _repoUsuarioEntidad.DeleteAsync(usuarioEntidad);
            return Ok();
        }

        /// <summary>
        /// Solo el admin y superadmin
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <param name="entidadId"></param>
        /// <param name="perfilId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{entidadId:int}/usuario/{usuarioId:int}/Perfil/{perfilId:int}")]
        public async Task<IActionResult> AsociarUsuario(int usuarioId, int entidadId, int perfilId)
        {
            bool EsSuperAdmin = Convert.ToBoolean(User.Claims.Where(c => c.Type == "EsSuperAdmin").FirstOrDefault().Value);
            bool Admin = (User.Claims.Where(c => c.Type == "AdminEntidades").FirstOrDefault().Value).ToString().Length > 0;
            if (!EsSuperAdmin && !Admin)
                return Forbid("Este servicio solo puede ser usado por un usuario superadmin o admin de una entidad");
            if (EsSuperAdmin && perfilId != 2)
                return Forbid("El usuario superadmin solo puede asociar el perfil administrador de entidad");
            if (Admin && (perfilId == 1 || perfilId == 2))
                return Forbid("El usuario admin no puede asociar el perfil administrador de entidad");

            IReadOnlyList<UsuarioEntidad> usuarioEntidades = await _repoUsuarioEntidad.ListAllAsync();
            var usuarioEntidad = usuarioEntidades.Where(c => c.EntidadId == entidadId && c.UsuarioId == usuarioId).FirstOrDefault();
            if (usuarioEntidad != null)
                return Conflict("El usuario ya tiene asociado un perfil a la entidad");
            usuarioEntidad = await _repoUsuarioEntidad.AddAsync(new UsuarioEntidad { UsuarioId = usuarioId, EntidadId = entidadId });
            UsuarioEntidadPerfil usuarioEntidadPerfil = new UsuarioEntidadPerfil
            {
                UsuarioEntidadId = usuarioEntidad.Id,
                PerfilId = perfilId
            };
            await _repoUsuarioEntidadPerfil.AddAsync(usuarioEntidadPerfil);
            return Ok();
        }

        /// <summary>
        /// Solo usuario Admin
        /// </summary>
        /// <param name="inputModel"></param>
        /// <param name="entidadId"></param>
        /// <returns></returns>
        [HttpPut("Firmas")]
        public async Task<IActionResult> ActualizarFirmas(FirmasInputModel inputModel)
        {
            bool Admin = (User.Claims.Where(c => c.Type == "AdminEntidades").FirstOrDefault().Value).ToString().Length > 0;
            GetUserId(out int usuarioId);
            GetEntidadId(out int entidadId);
            if (!Admin)
                return Forbid();

            Entidad entidadrepo = await _entidadService.ObtenerEntidadDetalle(entidadId);

            entidadrepo.EstablecerGerente(inputModel.Gerente, inputModel.CargoGerente);
            entidadrepo.EstablecerCoordinador(inputModel.Coordinador, inputModel.CargoCoordinador);
            entidadrepo.EstablecerInterventor(inputModel.Interventor, inputModel.CargoInterventor);
            entidadrepo.EstablecerAprobador(inputModel.Aprobador);

            await _repoEntidad.UpdateAsync(entidadrepo);
            return NoContent();
        }

        [HttpGet("Firmas")]
        public async Task<IActionResult> ObtenerFirmas()
        {
            bool Admin = (User.Claims.Where(c => c.Type == "AdminEntidades").FirstOrDefault().Value).ToString().Length > 0;
            GetUserId(out int usuarioId);
            GetEntidadId(out int entidadId);
            if (!Admin)
                return Forbid();

            Entidad entidadrepo = await _repoEntidad.GetByIdAsync(entidadId);
            IReadOnlyList<TblUsuarios> usuarios = await _repoUsuario.ListAllAsync();

            List<FirmasOutputModel> firmasOutputModel = new List<FirmasOutputModel>();
            firmasOutputModel.Add(new FirmasOutputModel { Rol = "Gerente", UsuarioId = null, Nombre = "", Cargo = entidadrepo.CargoGerente });
            firmasOutputModel.Add(new FirmasOutputModel { Rol = "Coordinador", UsuarioId = null, Nombre = "", Cargo = entidadrepo.CargoCoordinador });
            firmasOutputModel.Add(new FirmasOutputModel { Rol = "Interventor", UsuarioId = null, Nombre = "", Cargo = entidadrepo.CargoInterventor });
            firmasOutputModel.Add(new FirmasOutputModel { Rol = "Aprobador", UsuarioId = null, Nombre = "" });

            if (entidadrepo.GerentePorDefectoId != null) { 
                firmasOutputModel.Where(c => c.Rol == "Gerente").First().UsuarioId = entidadrepo.GerentePorDefectoId;
                firmasOutputModel.Where(c => c.Rol == "Gerente").First().Nombre = usuarios
                .Where(c => c.IIdusuario == entidadrepo.GerentePorDefectoId).First().ObtenerNombre();
            }
            if (entidadrepo.CoordinadorPorDefectoId!= null)
            {
                firmasOutputModel.Where(c => c.Rol == "Coordinador").First().UsuarioId = entidadrepo.CoordinadorPorDefectoId;
                firmasOutputModel.Where(c => c.Rol == "Coordinador").First().Nombre = usuarios
                .Where(c => c.IIdusuario == entidadrepo.CoordinadorPorDefectoId).First().ObtenerNombre();
            }
            if (entidadrepo.InterventorPorDefectoId != null)
            {
                firmasOutputModel.Where(c => c.Rol == "Interventor").First().UsuarioId = entidadrepo.InterventorPorDefectoId;
                firmasOutputModel.Where(c => c.Rol == "Interventor").First().Nombre = usuarios
                .Where(c => c.IIdusuario == entidadrepo.InterventorPorDefectoId).First().ObtenerNombre();
            }
            if (entidadrepo.AprobadorPorDefectoId!= null)
            {
                firmasOutputModel.Where(c => c.Rol == "Aprobador").First().UsuarioId = entidadrepo.AprobadorPorDefectoId;
                firmasOutputModel.Where(c => c.Rol == "Aprobador").First().Nombre = usuarios
                .Where(c => c.IIdusuario == entidadrepo.AprobadorPorDefectoId).First().ObtenerNombre();
            }

            return Ok(firmasOutputModel);
        }

    }
}