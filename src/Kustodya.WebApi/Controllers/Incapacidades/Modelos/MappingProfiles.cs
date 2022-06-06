using AutoMapper;
using Kustodya.ApplicationCore.Entities.Concepto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Incapacidades.Modelos
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<PacientesPorEmitir, PacienteOutputModel>()
            .ForMember(dest => dest.idPaciente, source => source.MapFrom(src => src.PacienteId))
            .ForMember(dest => dest.idpacienteporemitir, source => source.MapFrom(src => src.Id))
            .ForMember(dest => dest.numeroIdentificacion, source => source.MapFrom(src => src.Paciente.TNumeroDocumento))
            .ForMember(dest => dest.nombre, source => source.MapFrom(src => src.Paciente.ObtenerNombre()))
            .ForMember(dest => dest.fechaAsignacion, source => source.MapFrom(src => src.FechaCreacion.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds))
            .ForMember(dest => dest.estado, source => source.MapFrom(src => src.Estado.ToString().Replace("_", " ")))
            .ForMember(dest => dest.codigoCorto, source => source.MapFrom(src => src.concepto.CodigoCorto));

            CreateMap<ConceptoRehabilitacionDetalleInputModel, ConceptoRehabilitacion>()
                .ForMember(dest => dest.PacienteId, source => source.MapFrom(src => src.PacienteId))
                .ForMember(dest => dest.ResumenHistoriaClinica, source => source.MapFrom(src => src.ResumenHistoriaClinica))
                .ForMember(dest => dest.FinalidadTratamientos, source => source.MapFrom(src => src.FinalidadTratamientos))
                .ForMember(dest => dest.EsFarmacologico, source => source.MapFrom(src => src.EsFarmacologico))
                .ForMember(dest => dest.EsTerapiaOcupacional, source => source.MapFrom(src => src.EsTerapiaOcupacional))
                .ForMember(dest => dest.EsFonoaudiologia, source => source.MapFrom(src => src.EsFonoaudiologia))
                .ForMember(dest => dest.EsQuirurgico, source => source.MapFrom(src => src.EsQuirurgico))
                .ForMember(dest => dest.EsTerapiaFisica, source => source.MapFrom(src => src.EsTerapiaFisica))
                .ForMember(dest => dest.EsOtrosTratamientos, source => source.MapFrom(src => src.EsOtrosTratamientos))
                .ForMember(dest => dest.DescripcionOtrosTratamientos, source => source.MapFrom(src => src.DescripcionOtrosTratamientos))
                .ForMember(dest => dest.PlazoCorto, source => source.MapFrom(src => src.PlazoCorto))
                .ForMember(dest => dest.PlazoMediano, source => source.MapFrom(src => src.PlazoMediano))
                .ForMember(dest => dest.Concepto, source => source.MapFrom(src => src.Concepto))
                .ForMember(dest => dest.PacienteporEmitirId, source => source.MapFrom(src => src.PacienteporEmitirId))
                .ForMember(dest => dest.Diagnosticos, source => source.MapFrom(src => src.Diagnosticos))
                .ForMember(dest => dest.Secuelas, source => source.MapFrom(src => src.Secuelas));
            CreateMap<DiagnosticoInputModel, Diagnostico>()
                .ForMember(dest => dest.FechaIncapacidad, source => source.MapFrom(src => new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(src.FechaIncapacidad)));
            CreateMap<SecuelaInputModel, Secuela>()
                .ForMember(dest => dest.Tipo, source => source.MapFrom(src => src.TipoSecuela));

            CreateMap<Diagnostico, DiagnosticoInputModel>()
                .ForMember(dest => dest.FechaIncapacidad, source => source.MapFrom(src => src.FechaIncapacidad.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds));

            CreateMap<Secuela, SecuelaInputModel>()
                .ForMember(dest => dest.TipoSecuela, source => source.MapFrom(src => src.Tipo));

            CreateMap<ConceptoRehabilitacion, ConceptoRehabilitacionDetalleInputModel>();

            CreateMap<ConceptoRehabilitacion, HistorialConceptoOutputModel>()
                .ForMember(dest => dest.Id, source => source.MapFrom(src => src.PacienteporEmitirId))
                //.ForMember(dest => dest.FechaEmision, source => source.MapFrom(src => src.FechaEmision.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds))
                .ForMember(dest => dest.Diagnosticos, source => source.MapFrom(src => src.Diagnosticos))
                .ForMember(dest => dest.Medico, source => source.MapFrom(src => src.UsuarioCreacion.ObtenerNombre()));

            CreateMap<Diagnostico, DiagnosticosOutputModel>()
                .ForMember(dest => dest.FechaIncapacidad, source => source.MapFrom(src => src.FechaIncapacidad.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds))
                .ForMember(dest => dest.CIE10Id, source => source.MapFrom(src => src.Cie10Id))
                .ForMember(dest => dest.nombreEtiologia, source => source.MapFrom(src => src.Etiologia.ToString()));

            CreateMap<ApplicationCore.Entities.TblDiagnosticosIncapacidades, DiagnosticoIncapacidadOutputModel>()
                .ForMember(dest => dest.id, source => source.MapFrom(src => src.IIddiagnosticoIncapacidad))
                .ForMember(dest => dest.CodigoUnico, source => source.MapFrom(src => src.UiCodigoDiagnostico))
                .ForMember(dest => dest.CodigoCorto, source => source.MapFrom(src => src.TCodigoCorto))
                .ForMember(dest => dest.FechaInicio, source => source.MapFrom(src => Convert.ToDateTime(src.DtFechaEmisionIncapacidad).ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds))
                .ForMember(dest => dest.FechaFin, source => source.MapFrom(src => src.DtFechaFin.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds))
                .ForMember(dest => dest.DiasAcumulados, source => source.MapFrom(src => src.IDiasAcumuladosPorroga))
                .ForMember(dest => dest.DiasOtorgados, source => source.MapFrom(src => src.IDiasIncapacidad));
        }
    }
}
