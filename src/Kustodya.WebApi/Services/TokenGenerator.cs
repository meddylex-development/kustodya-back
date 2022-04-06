using ComponentSpace.Saml2;
using Kustodya.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Entities;
using Kustodya.Infrastructure;
using Kustodya.ApplicationCore.Entities.Administracion;

namespace WebApi.Services
{
    public class TokenGenerator : ITokenGenerator
    {
        #region Dependency Injection

        private readonly IConfiguration _configuration;
        private readonly dbProtektoV1Context _context;
        private readonly IUsuariosService _usuariosService;

        public TokenGenerator(IConfiguration configuration, dbProtektoV1Context context, IUsuariosService usuariosService)
        {
            _configuration = configuration;
            _context = context;
            _usuariosService = usuariosService;
        }

        #endregion Dependency Injection

        public async Task<JwtSecurityToken> CreateJwtSecurityToken(ISpSsoResult ssoResult)
        {
            var user = await _context.TblUsuarios.Where(u => u.TEmail == ssoResult.UserID.ToString()).FirstOrDefaultAsync();
            var userId = user?.IIdusuario.ToString();
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, ssoResult.UserID),
                new Claim("UserId", userId ?? "0") // ssoResult.UserID)
		};

            if (ssoResult.Attributes != null)
            {
                var samlAttribute = ssoResult.Attributes.SingleOrDefault(a => a.Name == ClaimTypes.Email);

                if (samlAttribute != null)
                {
                    claims.Add(new Claim(JwtRegisteredClaimNames.Email, samlAttribute.ToString()));
                }

                samlAttribute = ssoResult.Attributes.SingleOrDefault(a => a.Name == ClaimTypes.GivenName);

                if (samlAttribute != null)
                {
                    claims.Add(new Claim(JwtRegisteredClaimNames.GivenName, samlAttribute.ToString()));
                }

                samlAttribute = ssoResult.Attributes.SingleOrDefault(a => a.Name == ClaimTypes.Surname);

                if (samlAttribute != null)
                {
                    claims.Add(new Claim(JwtRegisteredClaimNames.FamilyName, samlAttribute.ToString()));
                }
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            return new JwtSecurityToken(
                 _configuration["JWT:Issuer"],
                 _configuration["JWT:Issuer"],
                 claims,
                 expires: DateTime.Now.AddHours(1),
                 signingCredentials: credentials);
        }

        public string CreateJwtSecurityToken(TblUsuarios u)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub.ToString(), u.IIdusuario.ToString()),
                new Claim("UserId", u.IIdusuario.ToString())
            };
            string entidades = _usuariosService.ObtenerEntidadesAdministrador(u.IIdusuario).Result;
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, u.TEmail));
            claims.Add(new Claim(JwtRegisteredClaimNames.GivenName, u.TPrimerNombre));
            claims.Add(new Claim(JwtRegisteredClaimNames.FamilyName, u.TPrimerApellido));
            claims.Add(new Claim("IdProfile", (u.TblUsuariosPerfiles.Count != 0 ? u.TblUsuariosPerfiles.First().IIdperfil.ToString() : "1")));
            claims.Add(new Claim("EsSuperAdmin", u.EsSuperAdmin.ToString()));
            claims.Add(new Claim("AdminEntidades", entidades));
            claims.Add(new Claim("Entidad", "1"));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                     _configuration["JWT:Issuer"],
                     _configuration["JWT:Issuer"],
                     claims,
                     expires: DateTime.Now.AddHours(10),
                     signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public JwtSecurityToken UpdateJwtSecurityToken(IEnumerable<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            return new JwtSecurityToken(
                _configuration["JWT:Issuer"],
                _configuration["JWT:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials);
        }
    }
}