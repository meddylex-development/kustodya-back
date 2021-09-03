using Kustodya.ApplicationCore.Interfaces;
using Kustodya.Medicos.Data;
using Roojo.Rethus;
using Microsoft.Extensions.DependencyInjection;

namespace Kustodya.Medicos.Data
{
    public static class ExtensionesRepositorioAsincrono
    {
        public static void AgregarRepositorioAsincrono(this IServiceCollection servicios)
        {
            servicios.AddScoped(typeof(ICosmosDbAsyncRepository<,>), typeof(AsyncCosmosDbRepository<,>));
            servicios.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
        }
    }
}
