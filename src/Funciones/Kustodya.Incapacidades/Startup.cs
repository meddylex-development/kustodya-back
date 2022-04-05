using AutoMapper;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.Incapacidades.Data;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

[assembly: FunctionsStartup(typeof(Kustodya.Incapacidades.Startup))]
namespace Kustodya.Incapacidades
{
    public class Startup : FunctionsStartup
    {

        public override void Configure(IFunctionsHostBuilder builder)
        {
            var servicios = builder.Services;
            servicios.AddScoped(typeof(IncapacidadService));
            servicios.AddScoped(typeof(IAsyncCosmosRepository<>), typeof(CosmosRepository<>));
            servicios.AddScoped(typeof(IAsyncRepository<>), typeof(SqlRepository<>));
            AddMapper(servicios);

            servicios.AddCosmosDbContext(o =>
            {
                o.AccountEndpoint = Environment.GetEnvironmentVariable("CosmosDb:AccountEndpoint");
                o.Accountkey = Environment.GetEnvironmentVariable("CosmosDb:Accountkey");
                o.DatabaseName = Environment.GetEnvironmentVariable("CosmosDb:DatabaseName");
                o.DefaultContainer = Environment.GetEnvironmentVariable("CosmosDb:DefaultContainer");
            });

            servicios.AddSqlDbContext(o =>
            {
                o.ConectionString = Environment.GetEnvironmentVariable("SqlDb:ConnectionString");
            });
        }

        private void AddMapper(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfiles());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}

