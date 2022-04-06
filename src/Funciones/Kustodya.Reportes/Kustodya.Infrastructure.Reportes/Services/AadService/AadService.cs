using System;
using System.Threading.Tasks;
using Kustodya.Core.Reportes.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;

namespace Kustodya.Infrastructure.Reportes.Services
{
    public class AadService : IAadService
    {
        private IOptions<ConfiguracionAad> _opciones;
        private ILogger<AadService> _logger;

        public AadService(IOptions<ConfiguracionAad> opciones, ILogger<AadService> logger)
        {
            _opciones = opciones;
            _logger = logger;
        }

        public async Task<string> GetTokenAadAsync()
        {
            try
            {
                AuthenticationResult authenticationResult = null;

                // For app only authentication, we need the specific tenant id in the authority url
                var tenantSpecificUrl = _opciones.Value.AuthorityUri.Replace("organizations", _opciones.Value.TenantId);

                // Create a confidetial client to authorize the app with the AAD app
                IConfidentialClientApplication clientApp =
                    ConfidentialClientApplicationBuilder
                        .Create(_opciones.Value.ClientId)
                        .WithClientSecret(_opciones.Value.ClientSecret)
                        .WithAuthority(tenantSpecificUrl)
                        .Build();
                        
                // Make a client call if Access token is not available in cache
                authenticationResult = await clientApp.AcquireTokenForClient(_opciones.Value.Scope).ExecuteAsync();
                return authenticationResult.AccessToken;
            }
            catch (MsalException)
            {
                _logger.LogError("Error de autenticación. Verifica la configuración del servicio AAD");
                throw;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error inesperado: {e.Message}\n\n{e.InnerException?.Message}");
                throw;
            }
        }
    }
}