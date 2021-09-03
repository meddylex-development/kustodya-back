using AutoMapper;
using Kustodya.ApplicationCore.DTOs.Contabilidades;
using Kustodya.ApplicationCore.Entities.Contabilidades;
using Kustodya.WebApi.Controllers.Contabilidades.Modelo;
using Kustodya.WebApi.Models.Contabilidades;
using System;
using WebApi.Services;

namespace Kustodya.WebApi.Models.Contabilidades
{
    public class ContabilidadMappingProfile : Profile
    {
        public ContabilidadMappingProfile()
        {

            CreateMap<ApplicationCore.Entities.Contabilidades.Contabilidad, ContabilidadOutputModel>()
            .ForMember(dest => dest.ClaseDocumentoPorDefecto, source => source.MapFrom(src => src.ClaseDocumentoPorDefecto.Descripcion))
            .ForMember(dest => dest.TipoAjustePorDefecto, source => source.MapFrom(src => src.TipoAjustePorDefecto.Descripcion))
            .ForMember(dest => dest.Credito, source => source.MapFrom(src => src.PucCreditoPorDefecto.Codigo))
            .ForMember(dest => dest.Debito, source => source.MapFrom(src => src.PucDebitoPorDefecto.Codigo))
            .ForMember(dest => dest.TipoContabilidad, source => source.MapFrom(src => src.PucDebitoPorDefecto == null ? "Kustodya" : src.PucDebitoPorDefecto.TipoContabilidad.ToString()));

            CreateMap<ApplicationCore.Entities.Contabilidades.Contabilidad, DetalleContabilidadOutputModel>()
                .ReverseMap();

            CreateMap<ContabilidadInputModel, ApplicationCore.Entities.Contabilidades.Contabilidad>();

            CreateMap<Puc, PUCOutputModel>();

            CreateMap<ClaseDocumento, ClaseDocumentoOutputModel>()
                .ForMember(o => o.Contabilidad, opt => opt.MapFrom(src => src.Contabilidad.Descripcion))
                .ForMember(o => o.CodigoContabilidad, opt => opt.MapFrom(src => src.Contabilidad.Codigo))
                .ForMember(o => o.EsClaseDocumentoPorDefecto, 
                    opt => opt.MapFrom(src => src.Contabilidad.ClaseDocumentoPorDefectoId == src.Id))
                ;
                
            CreateMap<TipoAjuste, TipoAjusteOutputModel>()
                .ForMember(o => o.Contabilidad, opt => opt.MapFrom(src => src.Contabilidad.Descripcion))
                .ForMember(o => o.CodigoContabilidad, opt => opt.MapFrom(src => src.Contabilidad.Codigo))
                .ForMember(dest => dest.EsTipoAjustePorDefecto, source => source.MapFrom(src => src.Contabilidad.TipoAjustePorDefectoId == src.Id));

            CreateMap<Tercero, TerceroOutputModel>()
                .ForMember(dest => dest.Nombre,
                source => source.MapFrom(src => src.RazonSocial + (src.PrimerNombre + Utilidades.TextoNormalizado(src.SegundoNombre) +
                    src.PrimerApellido + Utilidades.TextoNormalizado(src.SegundoApellido)).TrimEnd()));

            CreateMap<CentroCosto, CentroOutputModel>();
            
            CreateMap<Plantilla, PlantillaOutputModel>()
                .ForMember(dest => dest.TipoPlantilla, source => source.MapFrom(src=>src.TipoPlantilla.ToString().Replace("_", " ")));

            CreateMap<DepuracionContable, DepuracionOutputModel>()
            .ForMember(dest => dest.FechaElaboracion, source => source.MapFrom(src => src.FechaElaboracion.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds))
            .ForMember(dest => dest.NoFichaTecnica, source => source.MapFrom(src => src.FichaTecnica))
            .ForMember(dest => dest.Editable, source => source.MapFrom(src => false))
            .ForMember(dest => dest.Estado, source => source.MapFrom(src => src.Estado.ToString().Replace("_", " ")));

            CreateMap<DepuracionContable, DetalleDepuracionOutputModel>()
            .ForMember(dest => dest.FechaElaboracion, source => source.MapFrom(src => src.FechaElaboracion.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds))
            .ForMember(dest => dest.CodigoContabilidad, source => source.MapFrom(src => src.Contabilidad.Codigo))
            .ForMember(dest => dest.ClaseDocumento, source => source.MapFrom(src => src.ClaseDocumento.Descripcion))
            .ForMember(dest => dest.Segmento, source => source.MapFrom(src => src.Segmento.Descripcion))
            .ForMember(dest => dest.MovimientoOutputModel, source => source.MapFrom(src => src.Movimientos));

            CreateMap<Movimiento, MovimientoOutputModel>();

            CreateMap<Movimiento, DetalleMovimientoOutputModel>();

            


            /*CreateMap<ContabilidadInputModel, Contabilidad>()
            CreateMap<ContabilidadInputModel, ApplicationCore.Entities.Contabilidad.Contabilidad>();
            CreateMap<ApplicationCore.Entities.Contabilidad.Puc, PUCOutputModel>()
                .ReverseMap();*/

            /*CreateMap<ContabilidadInputModel, ApplicationCore.Entities.Contabilidad.Contabilidad>()
                .ForCtorParam("entidadId", opt => opt.MapFrom(src => src.EntidadId))
                .ForCtorParam("codigo", opt => opt.MapFrom(src => src.Codigo))
                .ForCtorParam("descripcion", opt => opt.MapFrom(src => src.Descripcion))
                .ForCtorParam("codigoPucCreditoMovimientoPorDefecto", opt => opt.MapFrom(src => src.CodigoPucCreditoMovimientoPorDefecto))
                .ForCtorParam("codigoPucDebitoMovimientoPorDefecto", opt => opt.MapFrom(src => src.CodigoPucDebitoMovimientoPorDefecto))
                .ForCtorParam("referenciaMovimientoPorDefecto", opt => opt.MapFrom(src => src.ReferenciaMovimientoPorDefecto))
                .ForCtorParam("descripcionMovimientoPorDefecto", opt => opt.MapFrom(src => src.DescripcionMovimientoPorDefecto))
                .IgnoreAllPropertiesWithAnInaccessibleSetter();*/
        }
    }
}