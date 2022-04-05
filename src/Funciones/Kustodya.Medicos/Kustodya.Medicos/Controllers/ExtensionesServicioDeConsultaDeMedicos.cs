using Kustodya.Medicos.Controllers;
using Kustodya.Medicos.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Kustodya.Controllers
{
    public static class ExtensionesServicioDeConsultaDeMedicos
    {
        public static void AddMedicoDurableController(this IServiceCollection services, Action<OpcionesCargueMasivo> options)
        {
            services.Configure(options);
        }
    }
}