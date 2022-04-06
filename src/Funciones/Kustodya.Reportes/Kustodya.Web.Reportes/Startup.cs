// using Kustodya.Infrastructure.Reportes.Services;
using Kustodya.Core.Reportes.Services;
using Kustodya.Infrastructure.Reportes.Data;
using Kustodya.Web.Reportes.Extensions;
using Kustodya.Web.Reportes.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using Kustodya.Infrastructure.Data;
using Kustodya.Core.Interfaces;
using Kustodya.Core.Reportes.Entities;
using Microsoft.Extensions.Logging;

[assembly: FunctionsStartup(typeof(Kustodya.Reportes.Startup))]
namespace Kustodya.Reportes
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            if (builder is null) throw new ArgumentNullException(nameof(builder));
            var servicios = builder.Services;

            servicios.AgregarServicioDeSwitcheo();
            servicios.AgregarUsoReporteInputModelService();
            // TODO: Agregar metodo de extensión para el servicio de solicitud de reporte
            servicios.AddScoped<IIniciarCapacidadService, IniciarCapacidadService>();
            // servicios.AgregarCosmosDb<ReportesContext>(o =>
            // {
            //     o.AccountEndpoint = Environment.GetEnvironmentVariable("CosmosDb:AccountEndpoint");
            //     o.Accountkey = Environment.GetEnvironmentVariable("CosmosDb:Accountkey");
            //     o.DatabaseName = Environment.GetEnvironmentVariable("CosmosDb:DatabaseName");
            //     o.DefaultContainer = Environment.GetEnvironmentVariable("CosmosDb:DefaultContainer");
            // });
            servicios.AgregarEfSqlRepository<Reporte, ReportesContext>(o =>
            {
                o.ConnectionString = Environment.GetEnvironmentVariable($"{EfSqlRepositoryOptions.Area}:{nameof(o.ConnectionString)}");
            });
            
            servicios.AddScoped(typeof(IAsyncRepository<Solicitud>), typeof(EfSqlRepository<Solicitud, ReportesContext>));
            // servicios.AddScoped(typeof(IAsyncRepository<Reporte>), typeof(ReportesCosmosRepository));

            // var scope = servicios.BuildServiceProvider();
            // try
            // {
            //     var reportesContext = scope.GetRequiredService<ReportesContext>();
            //     var logger = scope.GetRequiredService<ILogger<ReportesContextSeed>>();
            //     ReportesContextSeed.SeedAsync(reportesContext, logger).Wait();
            // }
            // catch (Exception ex)
            // {
            //     var logger = scope.GetRequiredService<ILogger<Startup>>();
            //     logger.LogError(ex, "An error occurred seeding the DB.");
            // }
            // servicios.AddScoped(typeof(IAsyncRepository<SolicitudDeUso>), typeof(SolicitudDeUsoRepository));
        }
    }
}

