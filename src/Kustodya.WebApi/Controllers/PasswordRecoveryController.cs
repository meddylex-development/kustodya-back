using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using WebApi.Controllers;
using Microsoft.Extensions.Configuration;
using Kustodya.ApplicationCore.Specifications;

namespace Kustodya.WebApi.Controllers
{
    [AllowAnonymous]
    public class PasswordRecoveryController : BaseController
    {
        private readonly IServicioRecuperacion _servicioRecuperacion;
        private readonly IConfiguration _configuration;
        private readonly IAsyncRepository<TblUsuarios> _usuariosRepo;
        private readonly ITokenGenerator _tokenGenerator;
        public PasswordRecoveryController(IServicioRecuperacion servicioRecuperacion, IConfiguration configuration,
            IAsyncRepository<TblUsuarios> usuariosRepo, ITokenGenerator tokenGenerator)
        {
            _servicioRecuperacion = servicioRecuperacion;
            _configuration = configuration;
            _usuariosRepo = usuariosRepo;
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] string email)
        {
            try
            {
                var spec = new ActiveUserSpec(email);
                TblUsuarios u = await _usuariosRepo.GetOneAsync(spec);
                if (u == null)
                    throw new Exception("Usuario no encontrado");
                var emailConfig = _configuration.GetSection("Email");
                var origin = _configuration.GetValue<string>("Origin");
                var templates = emailConfig.GetSection("Templates");
                string template = templates.GetValue<string>("RecoveryPassword");
                string requestPasswordUrl = templates.GetValue<string>("RequestPasswordUrl");
                string token = _tokenGenerator.CreateJwtSecurityToken(u);
                
                requestPasswordUrl = requestPasswordUrl + token;

                await _servicioRecuperacion.Recuperar(origin, template, requestPasswordUrl, u);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok();
        }
    }
}