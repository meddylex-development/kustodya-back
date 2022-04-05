using AutoMapper;
using Kustodya.ApplicationCore.Entities.MallaValidadora;
using System;
using System.Collections.Generic;
using System.Text;
using Kustodya.Homologacion.Famisanar.ModelosDeEntrada;

namespace Kustodya.Homologacion.Famisanar
{
    public class IncapacidadMappingProfile : Profile
    {
        public IncapacidadMappingProfile()
        {
            CreateMap<IncapacidadFamisanar, Incapacidad>()
                .ForMember(
                kustodya => kustodya.FechaAfiliacion,
                o => o.MapFrom(
                    famisanar => famisanar.FechaAfiliacion.ToDateTime()));

            CreateMap<IncapacidadFamisanar, Incapacidad>()
                .ForMember(
                kustodya => kustodya.IpsNit,
                o => o.MapFrom(
                    famisanar => famisanar.NUMERO_ID_IPS_PRIMARIA));


            CreateMap<IncapacidadFamisanar, Incapacidad>()
                .ForMember(
                kustodya => kustodya.Ips,
                o => o.MapFrom(
                    famisanar => famisanar.NUMERO_ID_IPS_PRIMARIA));
        }
    }
}