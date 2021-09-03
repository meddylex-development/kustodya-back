using Kustodya.Incapacidades.Data;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using Microsoft.EntityFrameworkCore.SqlServer;

[assembly: FunctionsStartup(typeof(Kustodya.Incapacidades.Startup))]
namespace Kustodya.Incapacidades
{
    public static class ServicesExtensions
    {
        private static string conectionString;
        private static string accountEndpoint;
        private static string defaultcontainer;
        private static string accountKey;
        private static string databaseName;

        public static void AddCosmosDbContext(this IServiceCollection services,
            Action<OpcionesCosmosDB> options)
        {
            services.Configure(options);
            var sp = services.BuildServiceProvider();
            var config = sp.GetService<IOptionsMonitor<OpcionesCosmosDB>>().CurrentValue;

            accountEndpoint = config.AccountEndpoint;
            defaultcontainer = config.DefaultContainer;
            accountKey = config.Accountkey;
            databaseName = config.DatabaseName;

            services.AddDbContext<IncapacidadContext>(o =>
            {
                o.UseCosmos(accountEndpoint, accountKey, databaseName);
                o.EnableSensitiveDataLogging(true);
            }, ServiceLifetime.Transient);

            AsegurarContenedor();
        }

        public static void AddSqlDbContext(this IServiceCollection services,
            Action<OpcionesSqlDB> options)
        {
            services.Configure(options);
            var sp = services.BuildServiceProvider();
            var config = sp.GetService<IOptionsMonitor<OpcionesSqlDB>>().CurrentValue;

            conectionString = config.ConectionString;

            services.AddDbContext<DiagnosticoContext>(o =>
            {
                o.UseSqlServer(conectionString);
                o.EnableSensitiveDataLogging(true);
            }, ServiceLifetime.Transient);
        }

        private async static void AsegurarContenedor()
        {
            using CosmosClient cosmosClient = new CosmosClient(accountEndpoint, accountKey);
            await cosmosClient.GetDatabase(databaseName)
                .DefineContainer(defaultcontainer, "/IpsId")
                .CreateIfNotExistsAsync();
        }
    }
}

