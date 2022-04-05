using Microsoft.Extensions.DependencyInjection;
using System;

namespace Kustodya.Medicos.Services
{
    public static class ExtensionesServicioDeConsultaDeMedicos
    {
        public static void AgregarMedicos(this IServiceCollection services, Action<OpcionesServicioDeConsultaDeMedicos> options)
        {
            services.Configure(options);
            services.AddScoped<IServicioDeConsultaDeMedicos, ServiciodeConsultaDeMedicos>();
        }
    }
}