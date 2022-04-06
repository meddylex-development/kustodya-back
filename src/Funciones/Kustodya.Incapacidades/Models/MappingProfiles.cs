using AutoMapper;
using Kustodya.ApplicationCore.DTOs.MallaValidadora.ModelosDeEntrada;
using Kustodya.ApplicationCore.Entities.MallaValidadora;
using Kustodya.MallaValidadora;

namespace Kustodya.Incapacidades
{
    internal class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<IncapacidadInputModel, Incapacidad>();
            CreateMap<AfiliadoInputModel, Afiliado>();
            CreateMap<IpsInputModel, Ips>();
        }
    }
}