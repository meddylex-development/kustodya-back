using Microsoft.Azure.Functions.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Kustodya.Incapacidades.Startup))]
namespace Kustodya.Incapacidades
{
    public class OpcionesCosmosDB
    {
        public string AccountEndpoint { get; set; }
        public string Accountkey { get; set; }
        public string DatabaseName { get; set; }
        public string DefaultContainer { get; internal set; }
    }
}

