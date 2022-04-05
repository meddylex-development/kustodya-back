using AutoMapper;
using Kustodya.Medicos.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Kustodya.Medicos.Services
{
    public static class ExtensionesMappper
    {
        public static void AgregarMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfiles());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}