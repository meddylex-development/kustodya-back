using Roojo.Rethus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http.Headers;
using Kustodya.ApplicationCore.Entities;
using static Roojo.Rethus.Consulta;

namespace Kustodya.Medicos.Services
{
    public static class ExtensionesServicioReTHUS
    {
        private static string connectionString;

        public static void AddRethusService(this IServiceCollection services, Action<OpcionesServicioReTHUS> options)
        {
            services.Configure(options);
            
            services.AddScoped<IServicioRethusRoojo, ServicioRethusRoojo>();
        }

        public static void AgregarSqlDbContext(this IServiceCollection services,
            Action<OpcionesSqlDB> options)
        {
            services.Configure(options);
            var sp = services.BuildServiceProvider();
            var config = sp.GetService<IOptionsMonitor<OpcionesSqlDB>>().CurrentValue;

            connectionString = config.ConnectionString;

            services.AddDbContext<RethusContext>(o =>
            {
                o.UseSqlServer(connectionString);
            });

            services.AddScoped<TareaFabric>();
            services.AddScoped<IConsultasFabric, ConsultasFabric>();
        }
    }
}