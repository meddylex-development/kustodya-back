using Kustodya.Controllers;
using Kustodya.Medicos.Data;
using Kustodya.Medicos.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using Kustodya.ApplicationCore.Entities;

[assembly: FunctionsStartup(typeof(Kustodya.Medicos.Startup))]
namespace Kustodya.Medicos
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            if (builder is null) throw new ArgumentNullException(nameof(builder));
            var servicios = builder.Services;

            servicios.AgregarOrquestador();
            servicios.AgregarModeloEntrada();
            servicios.AddMedicoDurableController(o =>
            {
                int.TryParse(Environment.GetEnvironmentVariable("Rethus:TamanoPagina"), out int tamanoPagina);
                int.TryParse(Environment.GetEnvironmentVariable("Medico:Timeout"), out int getMedicoTimeout);

                o.tamanoPagina = tamanoPagina;
                o.getMedicoTimeout = getMedicoTimeout;
            });
            servicios.AgregarMapper();
            servicios.AddCosmosDbContext(o =>
            {
                o.AccountEndpoint = Environment.GetEnvironmentVariable("CosmosDb:AccountEndpoint");
                o.Accountkey = Environment.GetEnvironmentVariable("CosmosDb:Accountkey");
                o.DatabaseName = Environment.GetEnvironmentVariable("CosmosDb:DatabaseName");
                o.DefaultContainer = Environment.GetEnvironmentVariable("CosmosDb:DefaultContainer");
            });
            servicios.AgregarMedicos(o =>
            {
                int.TryParse(Environment.GetEnvironmentVariable("Rethus:DiasObsolencia"), out int diasObsolencia);
                bool.TryParse(Environment.GetEnvironmentVariable("Rethus:ServicioRethusHabilitado"), out bool servicioRethusHabilitado);

                o.ServicioRethusHabilitado = servicioRethusHabilitado;
                o.DiasObsolencia = diasObsolencia;
            });
            servicios.AddRethusService(o =>
            {
                int.TryParse(Environment.GetEnvironmentVariable("Rethus:Timeout"), out int timeout);

                o.Timeout = timeout;

                o.Endpoint = Environment.GetEnvironmentVariable("Rethus:Endpoint");
                o.Password = Environment.GetEnvironmentVariable("Rethus:Password");
                o.Timeout = timeout;
                o.Token = Environment.GetEnvironmentVariable("Rethus:Token");
            });
            servicios.AddEmailService();
            servicios.AgregarNotificaciones();
            /*servicios.AgregarSuborquestador();*/
            servicios.AgregarRepositorioAsincrono();
            servicios.AgregarSqlDbContext(o => 
                o.ConnectionString = Environment.GetEnvironmentVariable("SqlDb:ConnectionString"));
            /*servicios.AgregarServicioDePeticiones();*/
            /*servicios.AgregarServicioCargueMasivo();*/
        }
    }
}

