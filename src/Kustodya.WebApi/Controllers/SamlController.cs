using ComponentSpace.Saml2;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Entities;
using System.Linq;
using System.Security.Claims;
using System;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SamlController : ControllerBase
    {
        #region Dependency Injection

        private readonly IConfiguration _configuration;
        private readonly ISamlServiceProvider _samlServiceProvider;
        private readonly ITokenGenerator _tokenGenerator;

        public SamlController(
             ISamlServiceProvider samlServiceProvider,
             IConfiguration configuration, ITokenGenerator tokenGenerator)
        {
            _samlServiceProvider = samlServiceProvider;
            _configuration = configuration;
            _tokenGenerator = tokenGenerator;
        }

        #endregion Dependency Injection

        [HttpPost]
        public async Task<IActionResult> AssertionConsumerService()
        {
            // Receive and process the SAML assertion contained in the SAML response. The SAML
            // response is received either as part of IdP-initiated or SP-initiated SSO.
            var ssoResult = await _samlServiceProvider.ReceiveSsoAsync();
            TblUsuarios u = new TblUsuarios();

            var samlAttribute = ssoResult.Attributes.SingleOrDefault(a => a.Name == ClaimTypes.Sid);
            if (samlAttribute != null)
            {
                u.IIdusuario = Convert.ToInt32(samlAttribute.ToString());
            }

            samlAttribute = ssoResult.Attributes.SingleOrDefault(a => a.Name == ClaimTypes.Email);
            if (samlAttribute != null)
            {
                u.TEmail = samlAttribute.ToString();
            }
            
            samlAttribute = ssoResult.Attributes.SingleOrDefault(a => a.Name == ClaimTypes.Name);
            if (samlAttribute != null)
            {
                u.TPrimerNombre = samlAttribute.ToString();
            }

            samlAttribute = ssoResult.Attributes.SingleOrDefault(a => a.Name == ClaimTypes.GivenName);
            if (samlAttribute != null)
            {
                u.TPrimerApellido = samlAttribute.ToString();
            }
            // Generate a JWT from the SAML assertion.
            var token = _tokenGenerator.CreateJwtSecurityToken(u);

            // Return the JWT.
            //return Redirect(QueryHelpers.AddQueryString(ssoResult.RelayState, "token", new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)));
            var baseURL = _configuration["RelayState"];  // "http://localhost:4200/#/auth/login";
                                                         //var redirect = baseURL + "?token=" + new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            var redirect = baseURL + token;
            return Redirect(redirect);
        }

        [Authorize, HttpGet]
        public async Task<IActionResult> InitiateSingleLogout(string returnUrl)
        {
            var ssoState = await _samlServiceProvider.GetStatusAsync();

            if (await ssoState.CanSloAsync())
            {
                // Request logout at the identity provider.
                await _samlServiceProvider.InitiateSloAsync(relayState: returnUrl);

                return new EmptyResult();
            }

            return Redirect(returnUrl);
        }

        [HttpGet]
        public async Task<IActionResult> InitiateSingleSignOn(string returnUrl)
        {
            // To login automatically at the service provider, initiate single sign-on to the
            // identity provider (SP-initiated SSO).
            var partnerName = _configuration["PartnerName"];

            await _samlServiceProvider.InitiateSsoAsync(partnerName, returnUrl);

            return new EmptyResult();
        }

        [HttpGet]
        public async Task<IActionResult> SingleLogoutService()
        {
            // Receive the single logout request or response. If a request is received then single
            // logout is being initiated by the identity provider. If a response is received then
            // this is in response to single logout having been initiated by the service provider.
            var sloResult = await _samlServiceProvider.ReceiveSloAsync();

            if (sloResult.IsResponse)
            {
                // SP-initiated SLO has completed.
                return Redirect(sloResult.RelayState);
            }
            else
            {
                // Respond to the IdP-initiated SLO request indicating successful logout.
                await _samlServiceProvider.SendSloAsync();
            }

            return new EmptyResult();
        }
    }
}