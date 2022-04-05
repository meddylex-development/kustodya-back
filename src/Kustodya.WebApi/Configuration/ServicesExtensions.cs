using Infrastructure.Services;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Services;
using Kustodya.Infrastructure.Configuration;
using Kustodya.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http.Headers;
using WebApi.Configuration;

namespace WebApi
{
    public static class ServicesExtensions
    {
        public static void AddCosmosDbContext(this IServiceCollection services,
            Action<CosmosDbOptions> options)
        {
            services.Configure(options);
            var sp = services.BuildServiceProvider();
            var config = sp.GetService<IOptionsMonitor<CosmosDbOptions>>().CurrentValue;

            services.AddDbContext<MedicosContext>(o =>
            {
                string accountEndpoint = config.AccountEndpoint;
                string accountKey = config.Accountkey;
                string databaseName = config.DatabaseName;

                o.UseCosmos(accountEndpoint, accountKey, databaseName);
            },
            ServiceLifetime.Transient);
        }

        public static void AddRethusService(this IServiceCollection services, Action<RethusServiceOptions> options)
        {
            services.Configure(options);
            services.AddHttpClient("Rethus", client =>
            {
                var sp = services.BuildServiceProvider();
                var localOptions = sp.GetService<IOptionsMonitor<RethusServiceOptions>>().CurrentValue;

                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(localOptions.Endpoint);
                client.DefaultRequestHeaders.Add("Token", localOptions.Token);
                client.DefaultRequestHeaders.Add("Password", localOptions.Password);
                client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.Timeout = new TimeSpan(0, 0, localOptions.Timeout);
            });

            services.AddScoped<IRethusService, SmartLawRethusService>();
        }
    
        public static void AddMedicoService<MedicoServiceImplementation>(this IServiceCollection services, Action<MedicoServiceOptions> options)
        {
            services.Configure(options);
            services.AddTransient(typeof(IMedicoService), typeof(MedicoServiceImplementation));
        }
    }
}