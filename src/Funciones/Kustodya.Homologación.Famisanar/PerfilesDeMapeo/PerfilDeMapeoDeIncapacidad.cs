using AutoMapper;
using Kustodya.Homologacion.Famisanar.ModelosDeEntrada;
using Kustodya.ApplicationCore.DTOs.MallaValidadora.ModelosDeEntrada;
using Kustodya.ApplicationCore.Entities;
using System;
using Kustodya.ApplicationCore.Entities.MallaValidadora;
using Kustodya.ApplicationCore.Constants;

namespace Kustodya.Homologacion.Famisanar.PerfilesDeMapeo
{
    public class PerfilDeMapeoDeIncapacidad : Profile
    {
        public PerfilDeMapeoDeIncapacidad()
        {
            CreateMap<IncapacidadFamisanar, IncapacidadInputModel>()
                .ForMember(
                    kustodya => kustodya.FechaAfiliacion, o => o.MapFrom(
                    famisanar => famisanar.FechaAfiliación.ToDateTime()))
                .ForMember(
                    kustodya => kustodya.FechaRadicacion, o => o.MapFrom(
                    famisanar => famisanar.FechaRadicación.ToDateTime()))
                .ForMember(
                    kustodya => kustodya.Prorroga, o => o.MapFrom(
                    famisanar => famisanar.PRORROGA == "Si"))
                .ForMember(
                    kustodya => kustodya.FechaFin, o => o.MapFrom(
                    famisanar => famisanar.FechaInicio.ToDateTime().Value
                        .AddDays(int.Parse(famisanar.DIAS_APROBADOS))))
                .ForMember(
                    kustodya => kustodya.IpsNit, o => o.MapFrom(
                    famisanar => famisanar.COD_IPS_IGE))
                .ForMember(
                    kustodya => kustodya.Afiliado, o => o.MapFrom(src => src))
                .ForMember(
                    kustodya => kustodya.FechaInicio, o => o.MapFrom(
                    famisanar => famisanar.FechaInicio.ToDateTime()))
                .ForMember(
                    kustodya => kustodya.CodigoCie10, o => o.MapFrom(
                    famisanar => famisanar.DIAGNOSTICO))
                .ForMember(
                    kustodya => kustodya.Ips, o => o.MapFrom(
                        famisanar => famisanar));

            CreateMap<IncapacidadFamisanar, AfiliadoInputModel>()
                .ForMember(
                    kustodya => kustodya.Activo, o => o.MapFrom(
                    famisanar => famisanar.ESTADO_AFILIACION == "1"))
                .ForMember(
                    kustodya => kustodya.Sexo, o => o.ConvertUsing(new SexoValueConverter(), src => src.GENERO))
                .ForMember(
                    kustodya => kustodya.IpsNit, o => o.MapFrom(
                    famisanar => famisanar.NUMERO_ID_IPS_PRIMARIA))
                .ForMember(
                    kustodya => kustodya.TipoAfiliacion, o => o.ConvertUsing(new TiposDeAfiliacionValueConverter(), src => src.TipoAfiliación))
                .ForMember(
                    kustodya => kustodya.FechaNacimiento, o => o.MapFrom(
                    famisanar => famisanar.FechaNacimiento.ToDateTime()))
                .ForMember(
                    kustodya => kustodya.CodigoDaneMunicipio, o => o.MapFrom(
                    famisanar => famisanar.AFI_MUN_DEP_CODRES + famisanar.AFI_MUN_CODRES))
                .ForAllOtherMembers(kustodya => kustodya.Ignore());

            CreateMap<IncapacidadFamisanar, IpsInputModel>()
                .ForMember(
                    kustodya => kustodya.Estado, 
                    o => o.ConvertUsing(new EstadoIpsValueConverter(), src => src.IPS_NO_ADSCRITA));
        }

        public class TiposDeAfiliacionValueConverter : IValueConverter<string, Afiliado.TiposAfiliacion>
        {
            public Afiliado.TiposAfiliacion Convert(string sourceMember, ResolutionContext context)
            {
                switch (sourceMember)
                {
                    case "Cotizante":
                        return Afiliado.TiposAfiliacion.Cotizante;
                    case "Beneficiario":
                        return Afiliado.TiposAfiliacion.Beneficiario;
                    case "2do.Cotizante":
                        return Afiliado.TiposAfiliacion.SegundoCotizante;
                    default:
                        return 0;
                }
            }
        }

        public class EstadoIpsValueConverter : IValueConverter<string, Ips.Estados?>
        {
            public Ips.Estados? Convert(string sourceMember, ResolutionContext context)
            {
                switch (sourceMember)
                {
                    case "Si":
                        return Ips.Estados.NoAdscrita;
                    case "No":
                        return Ips.Estados.Adscrita;
                    default:
                        return 0;
                }
            }
        }

        public class SexoValueConverter : IValueConverter<string, Sexos>
        {
            public Sexos Convert(string sourceMember, ResolutionContext context)
            {
                switch (sourceMember)
                {
                    case "M":
                        return Sexos.Masculino;
                    case "F":
                        return Sexos.Femenino;
                    default:
                        return 0;
                }
            }
        }

    }
}
