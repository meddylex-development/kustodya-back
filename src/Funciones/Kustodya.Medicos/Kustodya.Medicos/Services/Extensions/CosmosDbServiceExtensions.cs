using Kustodya.Medicos.Data;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace Kustodya.Medicos.Services
{
    public static class CosmosDbServiceExtensions
    {
        private static string accountEndpoint;
        private static string accountKey;
        private static string databaseName;
        private static string defaultcontainer;

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

            services.AddDbContext<MedicosContext>(o =>
            {
                o.UseCosmos(accountEndpoint, accountKey, databaseName);
                o.EnableSensitiveDataLogging(true);
            });

            AsegurarContenedor();
        }

        private async static void AsegurarContenedor()
        {
            using CosmosClient cosmosClient = new CosmosClient(accountEndpoint, accountKey);
            await cosmosClient.GetDatabase(databaseName)
                .DefineContainer(defaultcontainer, "/_partitionKey")
                .WithUniqueKey()
                .Path("/NumeroIdentifiacion")
                //.Path("/TipoIdentificacion")
                //.Path("/Id")
                .Attach()
                .CreateIfNotExistsAsync();
        }
    }

    
}