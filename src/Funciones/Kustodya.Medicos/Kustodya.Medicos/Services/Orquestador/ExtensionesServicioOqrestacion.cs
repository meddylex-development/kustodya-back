using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.Medicos.Services
{
    public static class ExtensionesServicioOqrestacion
    {
        public static void AgregarOrquestador(this IServiceCollection services)
        {
            services.AddScoped<IServicioDeOrquestacion, ServicioDeOrquestacion>();
        }

        public static void AgregarProcesamientoPaginado(this IServiceCollection servicios)
        {
            servicios.AddScoped<IServicioProcesamientoPaginado, ServicioDeProcesamientoPaginado>();
        }
    }
}
