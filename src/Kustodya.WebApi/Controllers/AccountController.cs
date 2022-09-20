using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.BusinessLogic.Services.Configuracion.Email;
using Kustodya.Infrastructure;
using Kustodya.ApplicationCore.Dtos;
using Kustodya.ApplicationCore.Dtos.General;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Services;
using WebApi.ViewModels;
using Kustodya.WebApi.Models;
using Kustodya.ApplicationCore.Entities.Administracion;

namespace Kustodya.WebApi.Controllers
{
    public class AccountController : BaseController
    {
        #region DI
        private readonly IConfiguration _configuration;
        private readonly IEmpresaService _empresaService;
        private readonly ILoggerService<AccountController> _logger;
        private readonly IMenuService _menuService;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IUsuarioService _usuarioService;
        private readonly IAsyncRepository<UsuarioEntidad> _repoUsuarioEntidad;
        private readonly IAsyncRepository<UsuarioEntidadPerfil> _repoUsuarioEntidadPerfil;
        private readonly dbProtektoV1Context _context;
        private readonly EmailService _emailService;

        public AccountController(dbProtektoV1Context context, IUsuarioService asyncRepository, 
            IEmpresaService empresaServiceRepository, IMenuService menuServiceRepository, 
            ITokenGenerator tokenGenerator, ILoggerService<AccountController> logger, IConfiguration configuration, 
            EmailService emailService, IAsyncRepository<UsuarioEntidad> repousuarioEntidad, 
            IAsyncRepository<UsuarioEntidadPerfil> repoUsuarioEntidadPerfil)
        {
            _usuarioService = asyncRepository;
            _empresaService = empresaServiceRepository;
            _menuService = menuServiceRepository;
            _logger = logger;
            _tokenGenerator = tokenGenerator;
            _configuration = configuration;
            _context = context;
            _emailService = emailService;
            _repoUsuarioEntidad = repousuarioEntidad;
            _repoUsuarioEntidadPerfil = repoUsuarioEntidadPerfil;
        }
        #endregion

        [HttpGet]
        [ProducesResponseType(typeof(List<EmpresaModel>), 200)]
        public async Task<IActionResult> GetEmpresasUsuario()
        {
            int IIdusuario = Convert.ToInt32(User.Claims.Where(c => c.Type == "UserId").FirstOrDefault().Value);
            var lEmpresas = await _empresaService.GetEmpresasUsuario(IIdusuario);
            return Ok(lEmpresas);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Menu>), 200)]
        public async Task<IActionResult> GetMenusPerfil(int idEntidad)
        {
            // Saca los id usariuo y perfil del token
            var idUsuario = Convert.ToInt32(User.Claims.Where(c => c.Type == "UserId")
                                                       .FirstOrDefault().Value);
            IReadOnlyList<UsuarioEntidad> usuarioEntidades = await _repoUsuarioEntidad.ListAllAsync();
            IReadOnlyList<UsuarioEntidadPerfil> usuarioEntidadPerfiles = await _repoUsuarioEntidadPerfil.ListAllAsync();
            var usuarioEntidad = usuarioEntidades.Where(c => c.UsuarioId == idUsuario && c.EntidadId == idEntidad).FirstOrDefault();
            if (usuarioEntidad == null)
                return NotFound("El usuario no tiene asociada la entidad con Id:" + idEntidad.ToString());

            var usuarioEntidadPerfil = usuarioEntidadPerfiles.Where(c => c.UsuarioEntidadId == usuarioEntidad.Id).FirstOrDefault();
            if (usuarioEntidadPerfil == null)
                return NotFound("El usuario no tiene un perfil asociado para la entidad con Id: " + idEntidad.ToString());
            var idPerfil = usuarioEntidadPerfil.PerfilId;
            //var idPerfil = Convert.ToInt32(User.Claims.Where(c => c.Type == "IdProfile").FirstOrDefault().Value);

            _logger.LogInformation("In GetMenu");

            int level = 0;

            var menus = await _menuService.GetMenusPerfil(idPerfil).ConfigureAwait(false);

            menus = menus.Where(c => c.BActivo == true).ToList();
            var childs = menus.Where(m => m.IIdpadre == null && m.BActivo == true);
            var menusVM = GetRecursiveMenu(menus, childs, idUsuario, idEntidad, idPerfil, ref level);

            return Ok(menusVM);
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(LoginResponse), 200)]
        public async Task<IActionResult> Login([Required] Login login)
        {
            var passHash = ToMD5(login.Password);
            TblUsuarios user = await _usuarioService.Login(login.User, passHash);

            if (user != null)
            {
                try
                {
                    var token = _tokenGenerator.CreateJwtSecurityToken(user);

                    return Ok(new LoginResponse
                    {
                        Token = token,
                        UserId = user.IIdusuario,
                        Name = user.TPrimerNombre + ' ' + user.TPrimerApellido,
                        SuperAdmin = user.EsSuperAdmin,
                        Usuario = new UsuarioModel
                        {
                            TNumeroDocumento = "193429933",
                            TipoDocumento = new TipoDocumentoModel() { IID = 1, TNombre = "Cedula de Ciudadania" },
                            Ocupacion = new OcupacionModel { NumeroRegistroProfesional = "A-1202020215", TNombre = "Medico General" },
                            Documento = new DocumentoUsuarioModel()
                        }
                    });
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    ModelState.AddModelError("Login", ex.Message);
                    return StatusCode(500, ModelState);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPasswordRequest([FromBody] string email)
        {
            // Find user and validate user
            var user = await _context.TblUsuarios.Where(u => u.TEmail == email).FirstOrDefaultAsync();

            if (user is null)
                return NotFound();

            // Build email
            //      Build token
            string token = _tokenGenerator.CreateJwtSecurityToken(user);
            
            //      Get email configuration
            string origin = _configuration["Email:Origin"];

            string callbackUrl = Url.Page(
                          "/Account/ResetPassword",
                          pageHandler: null,
                          values: new { token },
                          protocol: Request.Scheme);

            string name = user?.TPrimerNombre;

            // Send email
            await _emailService.SendEmailAsync(user.TEmail, name, null);

            // Update user object
            user.BCambioPassword = true;
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(string newPasswordHash)
        {
            GetUserId(out int userId);
            var user = await _context.TblUsuarios.FindAsync(userId);

            if (user is null)
                return NotFound();

            if (user.TClave == newPasswordHash)
                return BadRequest("New password must have not been used");

            user.TClave = newPasswordHash;
            await _context.SaveChangesAsync();

            return Ok();
        }

        private static string ToMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        private List<Menu> GetRecursiveMenu(IEnumerable<TblMenu> menuPerfiles, IEnumerable<TblMenu> children, int idUsuario, int idEntidad, int idPerfil, ref int level)
        {
            var _level = level;
            var urlBase = _configuration["KustodyaGeneral:BaseUrl"];
            var menusRecursivo = children.Select(mp => new Menu
            {
                Id = mp.IIdmenu,
                Title = mp.TDescripcion,
                Position = mp.IPosicion,
                Link = GetUrlMenu(idUsuario, idEntidad, idPerfil, mp, urlBase),
                EsReporte = mp.EsReporte,
                ReporteGroupId = mp.ReporteGroupId,
                ReporteId = mp.ReporteId,
                MenuLevel = ++_level,
                Icon = mp.Icon,
                Children = GetRecursiveMenu(menuPerfiles, menuPerfiles.Where(m => m.IIdpadre == mp.IIdmenu).OrderBy(d => d.IPosicion), idUsuario, idEntidad, idPerfil, ref _level)
            }).ToList();
            level = --_level;

            return menusRecursivo;
        }

        private static string GetUrlMenu(int idUsuario, int idEntidad, int idPerfil, TblMenu mp, string urlBase)
        {
            //return string.IsNullOrWhiteSpace(mp.Url) ? 
            //    string.Empty : 
            //        mp.Url.Replace("~", urlBase, false, CultureInfo.InvariantCulture) +
            //        (mp.Url.Contains('?', StringComparison.InvariantCulture) ? $"&" : $"?") + 
            //        $"UUX={idUsuario}&EUX={idEntidad}&PX1={idPerfil}";
            return string.IsNullOrWhiteSpace(mp.Url) ?
                string.Empty :
                    mp.Url.Replace("~", urlBase, false, CultureInfo.InvariantCulture);
        }

        [HttpPost]
        public IActionResult ValidacionToken()
        {
            return Ok();
        }
    }
}