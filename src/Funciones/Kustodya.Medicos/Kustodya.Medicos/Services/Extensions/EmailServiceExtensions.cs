using AutoMapper.Configuration;
using Kustodya.ApplicationCore.Interfaces.Configuracion.Email;
using Kustodya.BussinessLogic.Interfaces.General;
using Kustodya.Medicos.Services.AI;
using Kustodya.Medicos.Services.AzureBlob;
//using Kustodya.BusinessLogic.Services.Configuracion.Email;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Kustodya.Medicos.Services
{
    public static class EmailServiceExtensions
    {
        public static void AddEmailService(this IServiceCollection services)
        {
            var sp = services.BuildServiceProvider();
            //IConfiguration configuration = sp.GetService<IConfiguration>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IServicioCorreo, ServicioCorreo>();
            services.AddScoped<IBlobService, BlobService>();
            services.AddScoped<IOCREngineService, OCREngineService>();
            //EmailServiceSettings cosmosDbClientSettings = configuration.Get<EmailServiceSettings>();
        }
    }
}