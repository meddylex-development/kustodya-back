using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kustodya.Core.Interfaces;
using Kustodya.Core.Reportes.Entities;
using Kustodya.Infrastructure.Data;
using Kustodya.Infrastructure.Reportes.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Kustodya.Reportes.Migrations
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IConfiguration _configuration { get; }
        public void ConfigureServices(IServiceCollection servicios)
        {
            servicios.AgregarEfSqlRepository<Reporte, ReportesContext>(o =>
            {
                o.ConnectionString = _configuration.GetConnectionString("KustodyaReportes");
            });
            
            servicios.AddScoped(typeof(IAsyncRepository<Solicitud>), typeof(EfSqlRepository<Solicitud, ReportesContext>));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
