using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.Medicos.Services
{
    public static class ExtensionesServicioDePeticiones
    {
        public static void AgregarServicioDePeticiones(this IServiceCollection services)
        {
            services.AddScoped<IServicioDePeticiones, ServicioDePeticiones>();
        }
    }
}
