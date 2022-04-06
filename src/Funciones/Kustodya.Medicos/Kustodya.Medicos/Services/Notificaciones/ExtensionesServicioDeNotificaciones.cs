using Microsoft.Extensions.DependencyInjection;
using System;

namespace Kustodya.Medicos.Services
{
    public static class ExtensionesServicioDeNotificaciones
    {
        public static void AgregarNotificaciones(this IServiceCollection services)
        {
            services.AddHttpClient("webApiClient", o =>
            {
                var url = Environment.GetEnvironmentVariable("NotificacionesService:Endpoint");
                o.BaseAddress = new Uri(url);
            });

            //services.AddScoped<INotificacionesService, NotificacionesService>();
        }
    }
}