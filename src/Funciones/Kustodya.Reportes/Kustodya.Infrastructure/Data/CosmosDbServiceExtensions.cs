using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;

namespace Kustodya.Infrastructure.Data
{
    public static class CosmosDbServiceExtensions
    {
        private static string accountEndpoint;
        private static string accountKey;
        private static string databaseName;
        private static string defaultcontainer;

        public static void AgregarCosmosDb<TContext>(this IServiceCollection services,
            Action<OpcionesCosmosDB> options)
            where TContext : DbContext
        {
            services.Configure(options);
            var sp = services.BuildServiceProvider();
            var config = sp.GetService<IOptionsMonitor<OpcionesCosmosDB>>().CurrentValue;
            var logger = sp.GetService<ILogger>();

            // logger.LogInformation($@"
            //     AccountEndpoint: {config.AccountEndpoint}
            //     DefaultContainer: {config.DefaultContainer}
            //     Accountkey: {config.Accountkey}
            //     DatabaseName: {config.DatabaseName}");

            accountEndpoint = config.AccountEndpoint;
            defaultcontainer = config.DefaultContainer;
            accountKey = config.Accountkey;
            databaseName = config.DatabaseName;

            services.AddDbContext<TContext>(o =>
            {
                o.UseCosmos(accountEndpoint, accountKey, databaseName);
                o.EnableSensitiveDataLogging(true);
            }, ServiceLifetime.Singleton);

            AsegurarContenedor();
        }

        private async static void AsegurarContenedor()
        {
            using CosmosClient cosmosClient = new CosmosClient(accountEndpoint, accountKey);
            await cosmosClient.CreateDatabaseIfNotExistsAsync(databaseName);
            await cosmosClient.GetDatabase(databaseName)
                .DefineContainer(defaultcontainer, "/_partitionKey")
                .CreateIfNotExistsAsync();
        }
    }
}