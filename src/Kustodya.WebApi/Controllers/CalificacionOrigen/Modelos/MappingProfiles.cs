using AutoMapper;
using Kustodya.ApplicationCore.DTOs.Contabilidades;
using Kustodya.ApplicationCore.Entities.CalificacionOrigen;
using Kustodya.ApplicationCore.Entities.Contabilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.CalificacionOrigen.Modelos
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Correo, CorreoOutputModel>()
                .ForMember(dest => dest.FechaCorreo, source => source.MapFrom(src => src.Fecha.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds))
                .ForMember(dest => dest.FechaTranscripcion, source => source.Ignore())
                .ForMember(dest => dest.Remitente, source => source.MapFrom(src => src.De))
                .ForMember(dest => dest.Estado, source => source.MapFrom(src => src.Estado.ToString().Replace("_", " ")))
                .ForMember(dest => dest.Adjuntos, source => source.MapFrom(src => src.Adjuntos));

            CreateMap<Adjunto, AdjuntoOutputModel>()
                .ForMember(dest => dest.ArchivoId, source => source.MapFrom(src => src.Contenido));
        }
    }
}
