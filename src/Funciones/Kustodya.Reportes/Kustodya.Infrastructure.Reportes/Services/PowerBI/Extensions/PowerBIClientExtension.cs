using System;
using Kustodya.Core.Reportes.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Kustodya.Infrastructure.Reportes.Services
{
    public static class PowerBIClientExtension
    {
        public static void AgregarClientePowerBI(this IServiceCollection servicios, Action<ConfiguracionPowerBiClient> opciones)
        {
            servicios.Configure(opciones);
            servicios.AgregarClienteHttp();
            servicios.AddScoped<IPowerBiClient, PowerBiClient>();
        }

        private static void AgregarClienteHttp(this IServiceCollection servicios)
        {
            var _opciones = servicios.BuildServiceProvider().GetRequiredService<IOptionsMonitor<ConfiguracionPowerBiClient>>().CurrentValue;

            servicios.AddHttpClient(nameof(PowerBiClient),
            o =>
            {
                o.BaseAddress = new Uri(
                    _opciones.BaseAddress
                    .Replace("{subscriptionId}", _opciones.SubscriptionId)
                    .Replace("{resourceGroupName}", _opciones.ResourceGroupName)
                    .Replace("{dedicatedCapacityName}", _opciones.DedicatedCapacityName)
                    );
            });
        }
    }
}