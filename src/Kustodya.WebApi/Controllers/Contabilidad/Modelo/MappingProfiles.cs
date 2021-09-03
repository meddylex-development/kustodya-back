using AutoMapper;
using Kustodya.ApplicationCore.DTOs.Contabilidades;
using Kustodya.ApplicationCore.Entities.Contabilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Contabilidades
.Modelo
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CentroCosto, CentroCostoOutputModel>()
                .ForMember(dest => dest.Id, source => source.MapFrom(src => src.Id))
                .ForMember(dest => dest.Codigo, source => source.MapFrom(src => src.Codigo))
                // .ForMember(dest => dest.Regional, source => source.MapFrom(src => src.Regional))
                // .ForMember(dest => dest.Segmento, source => source.MapFrom(src => src.Segmento))
                ;

            CreateMap<Regional, RegionalOutputModel>()
                .ForMember(dest => dest.Codigo, source => source.MapFrom(src => src.Codigo))
                .ForMember(dest => dest.Descripcion, source => source.MapFrom(src => src.Descripcion));

            CreateMap<Segmento, SegmentoOutputModel>()
                .ForMember(dest => dest.Codigo, source => source.MapFrom(src => src.Codigo))
                .ForMember(dest => dest.Descripcion, source => source.MapFrom(src => src.Descripcion));

            CreateMap<EncabezadoInputModel, DepuracionContable>()
                .ForMember(dest => dest.FechaElaboracion, source => source.MapFrom(src => new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(src.FechaElaboracion)));

            CreateMap<DepuracionContable, EncabezadoOutputModel>()
                .ForMember(dest => dest.FechaElaboracion, source => source.MapFrom(src => src.FechaElaboracion.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds));

            CreateMap<DepuracionContable, EncabezadoDetalleOutputModel>()
                .ForMember(dest => dest.FechaElaboracion, source => source.MapFrom(src => src.FechaElaboracion.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds))
                .ForMember(dest => dest.Detalles, source => source.MapFrom(src => src.Movimientos))
                // .ForMember(dest => dest.Segmento, source => source.MapFrom(src => src.SegmentoId))
                ;

            CreateMap<Movimiento, DetalleOutputModel>()
            .ForMember(dest => dest.CentroBeneficio, source => source.MapFrom(src => src.CentroCostoId));

            CreateMap<DetalleInputModel, Movimiento>();

            CreateMap<ContabilidadInputModel, ApplicationCore.Entities.Contabilidades.Contabilidad>()
                .ForMember(dest => dest.CodigoPucDebitoMovimientoPorDefecto, source => source.Ignore())
                .ForMember(dest => dest.CodigoPucCreditoMovimientoPorDefecto, source => source.Ignore());
        }
    }
}
