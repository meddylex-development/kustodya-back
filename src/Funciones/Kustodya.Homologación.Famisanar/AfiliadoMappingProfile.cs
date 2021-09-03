using AutoMapper;
using Kustodya.ApplicationCore.DTOs.MallaValidadora.ModelosDeEntrada;
using Kustodya.ApplicationCore.Entities.MallaValidadora;
using System.Collections.Generic;
using System.Text;
using Kustodya.Homologacion.Famisanar.PerfilesDeMapeo;
using Kustodya.Homologacion.Famisanar.ModelosDeEntrada;

namespace Kustodya.Homologacion.Famisanar
{
    public class AfiliadoMappingProfile : Profile
    {
        public AfiliadoMappingProfile()
        {
            CreateMap<IncapacidadFamisanar, Incapacidad>()
                .ForMember(
                kustodya => kustodya.FechaAfiliacion,
                o => o.MapFrom(
                    famisanar => famisanar.FechaAfiliacion.ToDateTime()));
        }
    }
}
