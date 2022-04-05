using System;
using Kustodya.Infrastructure.Reportes.Services;
using Kustodya.Core.Reportes.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Kustodya.Web.Reportes.Extensions
{
    public static class SwitchearCapacidadServiceExtension
    {
        public static void AgregarServicioDeSwitcheo(this IServiceCollection servicios)
        {
            servicios.AgregarServicioAad(o =>
            {
                o.AuthorityUri = GetEnvironmentVariable("Aad", "AuthorityUri");
                o.ClientId = GetEnvironmentVariable("Aad", "ClientId");
                o.ClientSecret = GetEnvironmentVariable("Aad", "ClientSecret");
                o.TenantId = GetEnvironmentVariable("Aad", "TenantId");
                o.Scope = new string[]
                {
                    GetEnvironmentVariable("Aad", "Scope")
                };
            });

            servicios.AgregarServicioPowerBI(o =>
            {
                o.BaseAddress = GetEnvironmentVariable("PowerBiClient", "BaseAddress");
                o.DedicatedCapacityName = GetEnvironmentVariable("PowerBiClient", "DedicatedCapacityName");
                o.ResourceGroupName = GetEnvironmentVariable("PowerBiClient", "ResourceGroupName");
                o.SubscriptionId = GetEnvironmentVariable("PowerBiClient", "SubscriptionId");
            },
            o => {
                o.WorkspaceId = Guid.Parse(GetEnvironmentVariable("PowerBiService", "WorkspaceId"));
            });
            
            servicios.AddScoped<ISwitchearCapacidadService, SwitchearCapacidadService>();
        }

        private static string GetEnvironmentVariable(string configuracion, string variable)
        {
            return Environment.GetEnvironmentVariable($"{configuracion}:{variable}");
        }
    }
}

