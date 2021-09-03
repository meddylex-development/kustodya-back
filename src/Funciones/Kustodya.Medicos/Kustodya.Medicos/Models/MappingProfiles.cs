using AutoMapper;
using Kustodya.Medicos.Input;
using Kustodya.Medicos.Services.Input;
using System;
using System.Collections.Generic;
using Kustodya.ApplicationCore.Constants;
using TinyCsvParser.Mapping;
using Kustodya.Medicos.Services;
using Roojo.Rethus;
using TipoIdentificacion = Kustodya.Medicos.Data.Medicos.TiposDeDocumentoDeIdentificacion;
using Kustodya.Medicos.Data;
using System.Linq;

namespace Kustodya.Medicos.Models
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Medico, MedicoOutputModel>()
                .ForMember(dest =>
                    dest.NumeroIdentificacion,
                    opt => opt.MapFrom(src => src.NumeroIdentifiacion ?? src.NumeroIdentifiacion));

            CreateMap<Detalle, DetalleOutputModel>();

            CreateMap<RethusResponseModel, Medico>()
               .ForMember(dest =>
                            dest.TipoIdentificacion,
                          opt =>
                            opt.MapFrom(opt =>
                                opt.TIdValorTipoIdentificacion))
               .ForMember(dest => dest.NumeroIdentifiacion, opt => opt.MapFrom(src => src.TNumeroIdentificacion))
               .ForMember(dest => dest.UltimaActualizacion, opt => opt.MapFrom(src => DateTime.Now))
               .ForMember(dest => dest.Detalles, opt => opt.MapFrom(src => src.Detalles))
               .ForMember(dest => dest.RegistradoEnRethus, opt => opt.MapFrom(new RegistradoEnRethusResolver()));

            CreateMap<Detalle, Data.Detalle>()
                .ForMember(dest => dest.TipoProgramaOrigen, opt => opt.MapFrom(src => src.TTipoProgramaOrigen))
                .ForMember(dest => dest.TituloObtenido, opt => opt.MapFrom(src => src.TTituloObtenido))
                .ForMember(dest => dest.Ocupacion, opt => opt.MapFrom(src => src.TProfesionOcupacion))
                .ForMember(dest => dest.AutorizadoParaEjercerHasta, opt => opt.MapFrom(src => src.DtFechaAutorizacionEjercer))
                .ForMember(dest => dest.ActoAdministrativo, opt => opt.MapFrom(src => src.TActoAdministrativo))
                .ForMember(dest => dest.EntidadQueReporta, opt => opt.MapFrom(src => src.TEntidadReportante));

            CreateMap<CsvMappingResult<Registro>, ResultadoDeMapeo>()
                .ForMember(dest => dest.EsValido, opt => opt.MapFrom(src => src.IsValid))
                .ForMember(dest => dest.Registro, opt => opt.MapFrom(src => src.Result))
                .ForMember(dest => dest.IndiceDeFila, opt => opt.MapFrom(src => src.RowIndex));
            //.ForMember(dest => dest. , opt => opt.MapFrom(src => src.))

            CreateMap<Registro, Consulta>()
                .ForMember(
                    dest => dest.TipoIdentificacion,
                    opt => opt.Ignore()
                );

            CreateMap<Consulta, Medico>()
                .ForCtorParam("peticionId", o => o.MapFrom(src => Guid.NewGuid()))
                .ForMember(
                    dest => dest.TipoIdentificacion,
                    o => o.MapFrom(src => src.TipoIdentificacion))
                .ForMember(
                    dest => dest.RegistradoEnRethus,
                    o => o.MapFrom(src => src.EstaEnRethus))
                .ForMember(
                    dest => dest.PrimerNombre,
                    o => o.MapFrom(src => src.Datos.FirstOrDefault().PrimerNombre))
                .ForMember(
                    dest => dest.SegundoNombre,
                    o => o.MapFrom(src => src.Datos.FirstOrDefault().SegundoNombre))
                .ForMember(
                    dest => dest.PrimerApellido,
                    o => o.MapFrom(src => src.Datos.FirstOrDefault().PrimerApellido))
                .ForMember(
                    dest => dest.SegundoApellido,
                    o => o.MapFrom(src => src.Datos.FirstOrDefault().SegundoApellido))
                .ForMember(
                    dest => dest.SegundoApellido,
                    o => o.MapFrom(src => src.Datos.FirstOrDefault().SegundoApellido))
                .ForMember(
                    dest => dest.SegundoApellido,
                    o => o.MapFrom(src => src.Datos.FirstOrDefault().SegundoApellido))
                .ForMember(
                    dest => dest.Detalles,
                    o => o.MapFrom(src => src.DatosAcademicos.ToList())
                )
                .ForMember(
                    dest => dest.DatosSso,
                    o => o.MapFrom(src => src.DatosSso.ToList())
                );

            CreateMap<TipoIdentificacionRethus, Kustodya.Medicos.Data.Medicos.TiposDeDocumentoDeIdentificacion?>()
                .ConvertUsing<TipoIdentificacionConverterRethusKustodya>();

                CreateMap<Kustodya.Medicos.Data.Medicos.TiposDeDocumentoDeIdentificacion?, TipoIdentificacionRethus?>()
                .ConvertUsing<TipoIdentificacionConverterKustodyaRethus>();

            CreateMap<string, Kustodya.Medicos.Data.Medicos.TiposDeDocumentoDeIdentificacion?>()
                .ConvertUsing<TipoIdentificacionDatoBasicoConverter>();

            CreateMap<DatoAcademico, Data.Detalle>()
                .ForMember(
                    dest => dest.AutorizadoParaEjercerHasta,
                    o => o.MapFrom(src => DateTime.Parse(src.FechaInicioEjercerActoAdmin)))
                .ForMember(
                    dest => dest.EntidadQueReporta,
                    o => o.MapFrom(src => src.EntidadReportadora))
                .ForMember(
                    dest => dest.Ocupacion,
                    o => o.MapFrom(src => src.ProfesionOcupacion))
                .ForMember(
                    dest => dest.TipoProgramaOrigen,
                    o => o.MapFrom(src => src.TipoPrograma))
                .ForMember(
                    dest => dest.TituloObtenido,
                    o => o.MapFrom(src => src.OrigenObtencionTitulo))
                .ForMember(
                    dest => dest.ActoAdministrativo,
                    o => o.MapFrom(src => src.ActoAdministrativo));

            CreateMap<Dato, Medico>()
                .ForCtorParam("peticionId", o => o.MapFrom(src => Guid.NewGuid()))
                .ForMember(
                    dest => dest.TipoIdentificacion,
                    o => o.MapFrom(src => src.TipoIdentificacion)
                    )
                .ForMember(
                    dest => dest.RegistradoEnRethus,
                    o => o.MapFrom(src => true))
                .ForMember(
                    dest => dest.PrimerNombre,
                    o => o.MapFrom(src => src.PrimerNombre))
                .ForMember(
                    dest => dest.SegundoNombre,
                    o => o.MapFrom(src => src.SegundoNombre))
                .ForMember(
                    dest => dest.PrimerApellido,
                    o => o.MapFrom(src => src.PrimerApellido))
                .ForMember(
                    dest => dest.SegundoApellido,
                    o => o.MapFrom(src => src.SegundoApellido))
                .ForMember(
                    dest => dest.EstadoIdentificacion,
                    o => o.MapFrom(src => src.EstadoIdentificacion));

            CreateMap<Roojo.Rethus.Sancion, Kustodya.Medicos.Data.Sancion>()
                .ForMember(
                    dest => dest.FechaEjecucion,
                    o => o.MapFrom(src => src.FechaEjecucion.ToDateTime())
                )
                .ForMember(
                    dest => dest.FechaInicio,
                    o => o.MapFrom(src => src.FechaInicio.ToDateTime())
                )
                .ForMember(
                    dest => dest.FehaFin,
                    o => o.MapFrom(src => src.FehaFin.ToDateTime())
                );

            CreateMap<Roojo.Rethus.DatoSso, Kustodya.Medicos.Data.Medicos.DatoSso>();
        }

        public class RegistradoEnRethusResolver : IValueResolver<RethusResponseModel, Medico, bool?>
        {
            public bool? Resolve(RethusResponseModel src, Medico destination, bool? destMember, ResolutionContext context)
            {
                if (src.Mensaje == "Información Correcta") return true;
                if (src.Mensaje == "") return false;
                return null;
            }
        }

        public class TipoIdentificacionDatoBasicoConverter : ITypeConverter<string, Kustodya.Medicos.Data.Medicos.TiposDeDocumentoDeIdentificacion?>
        {
            public Kustodya.Medicos.Data.Medicos.TiposDeDocumentoDeIdentificacion? Convert(string tipoIdentificacionDatoBasico, Kustodya.Medicos.Data.Medicos.TiposDeDocumentoDeIdentificacion? tipoIdentificacionMedicos, ResolutionContext context)
            {
                switch (tipoIdentificacionDatoBasico)
                {
                    case "CC":
                        return Kustodya.Medicos.Data.Medicos.TiposDeDocumentoDeIdentificacion.Cédula_de_Ciudadanía;
                    case "CE":
                        return Kustodya.Medicos.Data.Medicos.TiposDeDocumentoDeIdentificacion.Cédula_de_Extranjería;
                    default:
                        return null;
                }
            }
        }

        public class TipoIdentificacionConverterRethusKustodya : ITypeConverter<TipoIdentificacionRethus, Kustodya.Medicos.Data.Medicos.TiposDeDocumentoDeIdentificacion?>
        {
            public Kustodya.Medicos.Data.Medicos.TiposDeDocumentoDeIdentificacion? Convert(TipoIdentificacionRethus source, Kustodya.Medicos.Data.Medicos.TiposDeDocumentoDeIdentificacion? destination, ResolutionContext context)
            {
                try
                {
                    switch (source)
                    {
                        case TipoIdentificacionRethus.Cédule_de_Ciudadanía:
                            return TipoIdentificacion.Cédula_de_Ciudadanía;
                        case TipoIdentificacionRethus.Cédula_de_Extranjería:
                            return TipoIdentificacion.Cédula_de_Extranjería;
                        case TipoIdentificacionRethus.CN_Certificado_de_Nacido_Vivo:
                            return TipoIdentificacion.CN_Certificado_de_Nacido_Vivo;
                        case TipoIdentificacionRethus.Nit:
                            return TipoIdentificacion.Nit;
                        case TipoIdentificacionRethus.Pasaporte:
                            return TipoIdentificacion.Pasaporte;
                        case TipoIdentificacionRethus.PE_Permiso_Especial_de_Permanencia:
                            return TipoIdentificacion.PE_Permiso_Especial_de_Permanencia;
                        case TipoIdentificacionRethus.Resgistro_Civil:
                            return TipoIdentificacion.Resgistro_Civil;
                        case TipoIdentificacionRethus.Tarjeta_de_Identidad:
                            return TipoIdentificacion.Tarjeta_de_Identidad;
                        default:
                            throw new ArgumentException($"El tipo de identificacion: {source} no se reconoce.");
                    }
                }
                catch (ArgumentException)
                {
                    return null;
                }
            }
        }
        public class TipoIdentificacionConverterKustodyaRethus : ITypeConverter<Kustodya.Medicos.Data.Medicos.TiposDeDocumentoDeIdentificacion?, Roojo.Rethus.TipoIdentificacionRethus?>
        {
            public TipoIdentificacionRethus? Convert(Kustodya.Medicos.Data.Medicos.TiposDeDocumentoDeIdentificacion? source, TipoIdentificacionRethus? destination, ResolutionContext context)
            {
                try
                {
                    switch (source)
                    {
                        case TipoIdentificacion.Cédula_de_Ciudadanía:
                            return TipoIdentificacionRethus.Cédule_de_Ciudadanía;
                        case TipoIdentificacion.Cédula_de_Extranjería:
                            return TipoIdentificacionRethus.Cédula_de_Extranjería;
                        case TipoIdentificacion.CN_Certificado_de_Nacido_Vivo:
                            return TipoIdentificacionRethus.CN_Certificado_de_Nacido_Vivo;
                        case TipoIdentificacion.Nit:
                            return TipoIdentificacionRethus.Nit;
                        case TipoIdentificacion.Pasaporte:
                            return TipoIdentificacionRethus.Pasaporte;
                        case TipoIdentificacion.PE_Permiso_Especial_de_Permanencia:
                            return TipoIdentificacionRethus.PE_Permiso_Especial_de_Permanencia;
                        case TipoIdentificacion.Resgistro_Civil:
                            return TipoIdentificacionRethus.Resgistro_Civil;
                        case TipoIdentificacion.Tarjeta_de_Identidad:
                            return TipoIdentificacionRethus.Tarjeta_de_Identidad;
                        default:
                            throw new ArgumentException($"El tipo de identificacion: {source} no se reconoce.");
                    }
                }
                catch (ArgumentException)
                {
                    return null;
                }
            }
        }
    }

    public static class ServicioMedicosRoojoExtensions
    {
        public static DateTime? ToDateTime(this string javaTimeStamp)
        {
            if (!long.TryParse(javaTimeStamp, out long timestamp))
                return null;
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddMilliseconds(timestamp).ToLocalTime();
            return dtDateTime;
        }
    }
}
