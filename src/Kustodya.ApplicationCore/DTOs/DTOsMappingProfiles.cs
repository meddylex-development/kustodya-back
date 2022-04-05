using AutoMapper;
using Kustodya.ApplicationCore.Constants;
using Kustodya.ApplicationCore.Dtos;
using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Entities.General;
using Kustodya.ApplicationCore.Entities.MallaValidadora;
using Kustodya.ApplicationCore.Entities.Medicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.DTOs
{
    public class DTOsMappingProfiles : Profile
    {
        public DTOsMappingProfiles()
        {
            CreateMap<RethusResponse, TblEmpleados>()
                .ForMember(dest => dest.TPrimerNombre, opt => opt.MapFrom(src => src.PrimerNombre))
                .ForMember(dest => dest.TSegundoNombre, opt => opt.MapFrom(src => src.SegundoNombre))
                .ForMember(dest => dest.TPrimerApellido, opt => opt.MapFrom(src => src.PrimerApellido))
                .ForMember(dest => dest.TSegundoNombre, opt => opt.MapFrom(src => src.SegundoApellido));

            CreateMap<RethusResponse, Medico>()
               .ForMember(dest => dest.TipoIdentificacion,
                          opt => opt.MapFrom(opt => Enum.GetName(typeof(TipoIdentificacion), opt.TIdValorTipoIdentificacion)))
               .ForMember(dest => dest.NumeroIdentifiacion, opt => opt.MapFrom(src => src.TNumeroIdentificacion))
               .ForMember(dest => dest.UltimaActualizacion, opt => opt.MapFrom(src => DateTime.Now))
               .ForMember(dest => dest.Detalles, opt => opt.MapFrom(src => src.Detalles))
               .ForMember(dest => dest.RegistradoEnRethus, opt => opt.MapFrom(src => src.Mensaje != "Informacion No Disponible en la Fuente"));

            CreateMap<Detalle, Entities.Medicos.Detalle>()
                .ForMember(dest => dest.TipoProgramaOrigen, opt => opt.MapFrom(src => src.TTipoProgramaOrigen))
                .ForMember(dest => dest.TituloObtenido, opt => opt.MapFrom(src => src.TTituloObtenido))
                .ForMember(dest => dest.Ocupacion, opt => opt.MapFrom(src => src.TProfesionOcupacion))
                .ForMember(dest => dest.AutorizadoParaEjercerHasta, opt => opt.MapFrom(src => src.DtFechaAutorizacionEjercer))
                .ForMember(dest => dest.EntidadQueReporta, opt => opt.MapFrom(src => src.TEntidadReportante));

            CreateMap<TblDiagnosticosIncapacidades, Incapacidad>()
                .ForMember(dest => dest.Afiliado, opt => opt.MapFrom(src => src.IIdpacienteNavigation))
                .ForMember(dest => dest.DiasAcumulados, opt => opt.MapFrom(src => src.IDiasAcumuladosPorroga))
                .ForMember(dest => dest.FechaInicio, opt => opt.MapFrom(src => src.DtFechaEmisionIncapacidad));

            CreateMap<TblPerfiles, PerfilOutputModel>()
                .ForMember(dest => dest.Nombre, conf => conf.MapFrom(src => src.TDescripcion))
                .ForMember(dest => dest.Id, conf => conf.MapFrom(src => src.IIdperfil))
                .ForMember(dest => dest.Activo, conf => conf.MapFrom(src => src.BActivo));
            // .ForMember(dest => dest.Creado, conf => conf.MapFrom(src => src));

            #region Perfiles Output
            CreateMap<TblPerfiles, PerfilConDetalleOutputModel>()
                .ForMember(dest => dest.Nombre, conf => conf.MapFrom(src => src.TDescripcion))
                .ForMember(dest => dest.Id, conf => conf.MapFrom(src => src.IIdperfil))
                .ForMember(dest => dest.Activo, conf => conf.MapFrom(src => src.BActivo))
                .ForMember(dest => dest.Menus, conf => conf.MapFrom(src => src.TblMenuPerfiles));
            // .ForMember(dest => dest.Creado, conf => conf.MapFrom(src => src));
            CreateMap<TblMenuPerfiles, MenuOutputModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IIdmenu));
            #endregion

            #region Perfiles Input
            CreateMap<PerfilInputModel, TblPerfiles>()
                .ForMember(e => e.BActivo, conf => conf.MapFrom(src => src.Activo))
                .ForMember(e => e.TDescripcion, conf => conf.MapFrom(src => src.Nombre))
                .ForMember(_ => _.TblMenuPerfiles, conf => conf.MapFrom(src => src.Menus));
            CreateMap<PerfilInputModel, TblMenuPerfiles>()
                .ForMember(dest => dest.IIdperfil, opt => opt.MapFrom(src => src.Id));
            CreateMap<MenuInputModel, TblMenuPerfiles>()
                .ForMember(dest => dest.IIdmenu, opt => opt.MapFrom(src => src.MenuId));
            #endregion
        }

        public class EnumToIntConverter : ITypeConverter<int, TipoIdentificacion?>
        {
            public TipoIdentificacion? Convert(int source, TipoIdentificacion? destination, ResolutionContext context)
            {
                try
                {
                    TipoIdentificacion tipoIdentificacionValue = (TipoIdentificacion)Enum.Parse(typeof(TipoIdentificacion), source.ToString());
                    if (Enum.IsDefined(typeof(TipoIdentificacion), tipoIdentificacionValue) | tipoIdentificacionValue.ToString().Contains(","))
                        return tipoIdentificacionValue;
                    else
                        throw new ArgumentException();
                }
                catch (ArgumentException)
                {
                    return null;
                }
                return (TipoIdentificacion)source;
            }
        }
    }
}
