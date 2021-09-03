using Microsoft.Azure.Functions.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Kustodya.Incapacidades.Startup))]
namespace Kustodya.Incapacidades
{
    public class OpcionesSqlDB
    {
        public string ConectionString { get; set; }
    }
}

