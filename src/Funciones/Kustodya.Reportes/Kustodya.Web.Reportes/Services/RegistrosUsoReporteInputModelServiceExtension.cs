using Microsoft.Extensions.DependencyInjection;

namespace Kustodya.Web.Reportes.Services
{
    public static class RegistrosUsoReporteInputModelServiceExtension
    {
        public static void AgregarUsoReporteInputModelService(this IServiceCollection servicios)
        {
            servicios.AddScoped<IRegistrosUsoReporteInputModelService, RegistrosUsoReporteInputModelService>();
        }
    }
}