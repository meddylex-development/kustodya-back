using System;
using Kustodya.Core.Reportes.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Kustodya.Infrastructure.Reportes.Services
{
    public static class AadServiceExtension
    {
        public static void AgregarServicioAad(this IServiceCollection servicios, Action<ConfiguracionAad> opciones)
        {
            servicios.Configure(opciones);
            servicios.AddScoped<IAadService, AadService>();
        }
    }
}