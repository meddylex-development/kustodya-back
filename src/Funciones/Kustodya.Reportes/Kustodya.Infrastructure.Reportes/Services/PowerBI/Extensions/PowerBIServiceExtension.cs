using System;
using Kustodya.Core.Reportes.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Kustodya.Infrastructure.Reportes.Services
{
    public static class PowerBIServiceExtension
    {
        public static void AgregarServicioPowerBI(this IServiceCollection servicios, Action<ConfiguracionPowerBiClient> opcionesCliente, Action<ConfiguracionPowerBiService> configuracionService)
        {
            // TODO: Cambiar configuración de cliente (ConfiguracionPowerBiClient) por una configuración del servicio
            servicios.AgregarClientePowerBI(opcionesCliente);
            servicios.Configure(configuracionService);
            servicios.AddScoped<IPowerBiService, PowerBiService>();
        }
    }
}