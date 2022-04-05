using System;
using AutoMapper;
using Kustodya.Homologacion;
using Kustodya.Homologacion.Famisanar;
using Kustodya.Homologacion.Famisanar.Servicios;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs.Extensions;
[assembly: FunctionsStartup(typeof(Kustodya.Homologacion.Famisanar.Startup))]

namespace Kustodya.Homologacion.Famisanar
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var servicios = builder.Services;
            servicios.AddScoped<ServicioDeHomologacion>();
            // builder.Services.AddServiceBus();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new PerfilesDeMapeo.PerfilDeMapeoDeIncapacidad());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            servicios.AddSingleton(mapper);
            servicios.AgregarServicioDeValidacion();
        }
    }

    public static class ExtensionesDelServicioDeValidacion
    {
        public static void AgregarServicioDeValidacion(this IServiceCollection servicios)
        {
            servicios.AddHttpClient("Kustodya.Incapacidades",
             options =>{
                 options.BaseAddress = new Uri(Environment.GetEnvironmentVariable("Kustodya:Incapacidades:BaseUrl"));
             });

             servicios.AddScoped<ServicioDeValidacion>();
        }
    }
}

