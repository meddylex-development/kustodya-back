using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.Medicos.Services
{
    public static class ExtensionesServicioCargueMasivo
    {
        public static void AgregarCargueMasivo(this IServiceCollection servicios)
        {
            servicios.AddScoped<IServicioCargueMasivo, ServicioCargueMasivo>();
        }
    }
}
