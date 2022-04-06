using Infrastructure.Identity;
using Kustodya.Infrastructure;
using Kustodya.Infrastructure.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Prozess.Infrastructure.Identity;
using System;
using System.Threading.Tasks;
using Kustodya.Infrastructure.Data.Contabilidades;

namespace WebApi
{
    public class Program
    {
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
             WebHost.CreateDefaultBuilder(args)
                  .UseStartup<Startup>();

        public async static Task Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    // var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    //AppIdentityDbContextSeed.SeedAsync(userManager).Wait();
                    var contabilidadContext = services.GetRequiredService<ContabilidadContext>();
                    await ContabilidadContextSeed.SeedAsync(contabilidadContext, loggerFactory);
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }

            host.Run();
        }
    }
}