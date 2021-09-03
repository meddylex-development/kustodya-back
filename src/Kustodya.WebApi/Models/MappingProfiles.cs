using AutoMapper;
using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Dtos;
using Kustodya.ApplicationCore.Dtos.Configuracion.Notificaciones;
using Kustodya.ApplicationCore.Dtos.General;
using Kustodya.ApplicationCore.Dtos.Incapacidades;
using Kustodya.ApplicationCore.Dtos.Multivalores;
using Kustodya.ApplicationCore.Dtos.Negocio;
using Kustodya.ApplicationCore.Dtos.Negocio.RH;
using Kustodya.WebApi.Models.Rehabilitaciones;
using System;
using Kustodya.ApplicationCore.Entities.Medicos;
using Kustodya.WebApi.Controllers;
using Kustodya.WebApi.Controllers.Administrativo.Usuarios.Modelos;
using WebApi.Services;
using Kustodya.ApplicationCore.Entities.Administracion;

namespace Kustodya.WebApi.Models
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<TblPacientes, PacienteModel>()
                .ForMember(dest => dest.Eps, source => source.MapFrom(src => src.IIdepsNavigation))
                .ForMember(dest => dest.TipoDocumento, source => source.MapFrom(src => src.IIdtipoDocNavigation))
                .ForMember(dest => dest.Genero, source => source.MapFrom(src => src.IIdgeneroNavigation))
                .ForMember(dest => dest.RegimenAfiliacion, source => source.MapFrom(src => src.IIdregimenAfiliacionNavigation))
                .ForMember(dest => dest.TipoAfiliacion, source => source.MapFrom(src => src.IIdtipoAfiliacionNavigation))
                .ForMember(dest => dest.Empresa, source => source.MapFrom(src => src.IIdempresaNavigation))
                .ForMember(dest => dest.EstadoAfiliacion, source => source.MapFrom(src => src.IIdestadoAfiliacionNavigation));

            CreateMap<TblEmpresas, EmpresaTercerosModel>()
                .ForMember(dest => dest.IId, source => source.MapFrom(src => src.IIdempresa))
                .ForMember(dest => dest.TDireccion, source => source.MapFrom(src => src.TDireccion))
                .ForMember(dest => dest.TipoDocumento, source => source.MapFrom(src => src.IIdtipoIdentificacionNavigation))
                .ForMember(dest => dest.NIT, source => source.MapFrom(src => src.TNumeroIdentificacion))
                .ForMember(dest => dest.TDigitoVerificacion, source => source.MapFrom(src => src.TDigitoVerificacion));

            CreateMap<TblRegimenAfiliacion, RegimenAfiliacionModel>()
                .ForMember(dest => dest.IId, source => source.MapFrom(src => src.IId))
                .ForMember(dest => dest.TNombre, source => source.MapFrom(src => src.TNombre));

            CreateMap<TblTipoAfiliacion, TipoAfiliacionModel>()
                .ForMember(dest => dest.IID, source => source.MapFrom(src => src.IId))
                .ForMember(dest => dest.TNombre, source => source.MapFrom(src => src.TNombre));

            CreateMap<TblDivipola, UbicacionModel>()
                .ForMember(dest => dest.IIdDane, source => source.MapFrom(src => src.Iddivipola))
                .ForMember(dest => dest.IIdPais, source => source.MapFrom(src => src.Idpais))
                .ForMember(dest => dest.TNombrePais, source => source.MapFrom(src => src.Nombrepais))
                .ForMember(dest => dest.IIdDepartamento, source => source.MapFrom(src => src.Iddepto))
                .ForMember(dest => dest.TNombreDepartamento, source => source.MapFrom(src => src.Nombredepto))
                .ForMember(dest => dest.IIdMunicipio, source => source.MapFrom(src => src.Idmunicipio))
                .ForMember(dest => dest.TNombreMunicipio, source => source.MapFrom(src => src.Nombremunicipio))
                .ForMember(dest => dest.TNombrePoblacion, source => source.MapFrom(src => src.Nombrepoblacion))
                .ForMember(dest => dest.TCodigoDANE, source => source.MapFrom(src => src.Codigodivipola));

            CreateMap<TblCiiu, ActividadEconomicaModel>()
           .ForMember(dest => dest.IId, source => source.MapFrom(src => src.IId))
           .ForMember(dest => dest.CIIU, source => source.MapFrom(src => src.Seccion + src.Clase))
           .ForMember(dest => dest.TNombreActividad, source => source.MapFrom(src => src.Descripcion));

            CreateMap<TblCiuo08, OcupacionModel>()
           .ForMember(dest => dest.IId, source => source.MapFrom(src => src.IId))
           .ForMember(dest => dest.ICategoria, source => source.MapFrom(src => src.ICategoria))
           .ForMember(dest => dest.TNombre, source => source.MapFrom(src => src.TDescripcion));

            CreateMap<TblMultivalores, MultivaloresModel>()
             .ForMember(dest => dest.IIdMultivalor, source => source.MapFrom(src => src.IIdmultivalor))
             .ForMember(dest => dest.IIdSubtabla, source => source.MapFrom(src => src.IIdsubtabla))
             .ForMember(dest => dest.tDescripcion, source => source.MapFrom(src => src.TDescripcion))
             .ForMember(dest => dest.TNombreSubtabla, source => source.MapFrom(src => src.TSubtabla))
             .ForMember(dest => dest.IOrden, source => source.MapFrom(src => src.IOrden))
             .ForMember(dest => dest.TValor, source => source.MapFrom(src => src.TValor));

            CreateMap<MultivaloresModel, TipoAtencionModel>()
                .ForMember(dest => dest.TTipoAtencion, source => source.MapFrom(src => src.TValor))
                .ForMember(dest => dest.TDescripcion, source => source.MapFrom(src => src.tDescripcion)
                );

            CreateMap<TblEps, EpsModel>()
                .ForMember(dest => dest.TNumeroIdentificacion, source => source.MapFrom(src => src.TNumeroIdentificacion));

            CreateMap<EpsModel, TblEps>()
                .ForMember(dest => dest.TNumeroIdentificacion, source => source.MapFrom(src => src.TNumeroIdentificacion));


            CreateMap<TblIps, IPSModel>()
                .ForMember(dest => dest.TNumeroIdentificacion, source => source.MapFrom(src => src.TNumeroIdentificacion))
                .ForMember(dest => dest.tDigitoVerificacion, source => source.MapFrom(src => src.TDigitoVerificacion))
                .ForPath(dest => dest.Ubicacion.IIdDane, source => source.MapFrom(src => src.IIdubicacion));

            CreateMap<IPSModel, TblIps>()
                .ForMember(dest => dest.TNumeroIdentificacion, source => source.MapFrom(src => src.TNumeroIdentificacion))
                .ForMember(dest => dest.TDigitoVerificacion, source => source.MapFrom(src => src.tDigitoVerificacion))
                .ForPath(dest => dest.IIdubicacion, source => source.MapFrom(src => src.Ubicacion.IIdDane));


            CreateMap<TblMultivalores, OrigenIncapacidadModel>()
                .ForMember(d => d.IIdOrigenIncapacidad, s => s.MapFrom(src => src.IIdmultivalor))
                .ForMember(d => d.TOrigenIncapacidad, s => s.MapFrom(src => src.TDescripcion));

            CreateMap<TblMultivalores, TipoIdentificacionModel>()
                .ForMember(d => d.IIdTipoIdentificacion, s => s.MapFrom(src => src.IIdmultivalor))
                .ForMember(d => d.TTipoIdentificacion, s => s.MapFrom(src => src.TDescripcion));

            CreateMap<TblMultivalores, GeneroModel>()
                .ForMember(d => d.IIdGenero, s => s.MapFrom(src => src.IIdmultivalor))
                .ForMember(d => d.TGenero, s => s.MapFrom(src => src.TDescripcion));

            CreateMap<TblMultivalores, TipoAtencionModel>()
                .ForMember(d => d.IIdTipoAtencion, s => s.MapFrom(src => src.IIdmultivalor))
                .ForMember(d => d.TTipoAtencion, s => s.MapFrom(src => src.TDescripcion));

            CreateMap<TblCie10, CIE10Model>()
                .ForMember(dest => dest.TFullDescripcion, source => source.MapFrom(src => src.TCie10 + " - " + src.TDescripcion));

            CreateMap<TblDiagnosticosIncapacidades, DiagnosticoIncapacidadModel>()
                .ForMember(dest => dest.Cie10, source => source.MapFrom(src => src.TblCie10DiagnosticoIncapacidad))
                .ForMember(dest => dest.PresuntoOrigenIncapacidad, source => source.MapFrom(src => src.IIdpresuntoOrigenIncapacidadNavigation))
                .ForMember(dest => dest.OrigenCalificadoIncapacidad, source => source.MapFrom(src => src.IIdorigenCalificadoIncapacidadNavigation))
                //.ForMember(dest => dest.TipoAtencion, source => source.MapFrom(src => src.IIdtipoAtencionNavigation))
                .ForMember(dest => dest.DtFechaCreacion, source => source.MapFrom(src => src.DtFechaCreacion))
                .ForMember(dest => dest.EsTranscripcion, source => source.MapFrom(src => src.BEsTranscripcion))
                .ForMember(dest => dest.FechaEmisionIncapacidad, source => source.MapFrom(src => src.DtFechaEmisionIncapacidad))
                .ForMember(dest => dest.DtFechaFin, source => source.MapFrom(src => src.DtFechaFin))
                .ForMember(dest => dest.TCodigoCorto, source => source.MapFrom(src => src.TCodigoCorto))
                .ForMember(dest => dest.IIdips, source => source.MapFrom(src => src.IIdips))
                .ForMember(dest => dest.IIdEps, source => source.MapFrom(src => src.IIdeps))
                .ForMember(dest => dest.IIdpaciente, source => source.MapFrom(src => src.IIdpaciente))
                .ForMember(dest => dest.TipoAtencion, source => source.MapFrom(src => src.IIdtipoAtencionNavigation));
            //.ForMember(dest => dest.TLugarExpedicion, source => source.MapFrom(src => src.IIdipsNavigation.IIdubicacionNavigation.Nombremunicipio + " - " + src.IIdipsNavigation.IIdubicacionNavigation.Nombredepto));

            CreateMap<DiagnosticoIncapacidadModel, TblDiagnosticosIncapacidades>()
                .ForMember(dest => dest.UiCodigoDiagnostico, source => source.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.TblCie10DiagnosticoIncapacidad, source => source.MapFrom(src => src.Cie10))
                .ForMember(dest => dest.DtFechaCreacion, source => source.MapFrom(src => TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time"))))
                //.ForMember(dest => dest.DtFechaFin, source => source.MapFrom(src => TimeZoneInfo.ConvertTime(DateTime.Now.AddDays(src.IDiasIncapacidad - 1), TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time"))))
                .ForMember(dest => dest.DtFechaFin, source => source.MapFrom(src => src.DtFechaFin))
                .ForMember(dest => dest.IIdpresuntoOrigenIncapacidad, source => source.MapFrom(src => src.PresuntoOrigenIncapacidad.IIdOrigenIncapacidad))
                .ForMember(dest => dest.IIdorigenCalificadoIncapacidad, source => source.MapFrom(src => src.OrigenCalificadoIncapacidad.IIdOrigenIncapacidad))
                .ForMember(dest => dest.BEsTranscripcion, source => source.MapFrom(src => src.EsTranscripcion))
                .ForMember(dest => dest.DtFechaEmisionIncapacidad, source => source.MapFrom(src => src.FechaEmisionIncapacidad))
                .ForMember(dest => dest.TCodigoCorto, source => source.MapFrom(src => src.TCodigoCorto))
                .ForMember(dest => dest.IIdips, source => source.MapFrom(src => src.IIdips))
                .ForMember(dest => dest.IIdeps, source => source.MapFrom(src => src.IIdEps))
                .ForMember(dest => dest.IIdpaciente, source => source.MapFrom(src => src.IIdpaciente))
                .ForMember(dest => dest.IIdtipoAtencion, source => source.MapFrom(src => src.TipoAtencion.IIdTipoAtencion));

            CreateMap<TblCie10DiagnosticoIncapacidad, CIE10Model>()
                .ForMember(dest => dest.IIdcie10, source => source.MapFrom(src => src.IIdcie10Navigation.IIdcie10))
                .ForMember(dest => dest.TCie10, source => source.MapFrom(src => src.IIdcie10Navigation.TCie10))
                .ForMember(dest => dest.TDescripcion, source => source.MapFrom(src => src.IIdcie10Navigation.TDescripcion))
                .ForMember(dest => dest.IDiasMaxConsulta, source => source.MapFrom(src => src.IIdcie10Navigation.IDiasMaxConsulta))
                .ForMember(dest => dest.TFullDescripcion, source => source.MapFrom(src => src.IIdcie10Navigation.TCie10 + " - " + src.IIdcie10Navigation.TDescripcion))
                .ForMember(dest => dest.IIdtipoCie, source => source.MapFrom(src => src.IIdcie10Navigation.IIdtipoCie));

            CreateMap<CIE10Model, TblCie10DiagnosticoIncapacidad>()
                .ForMember(dest => dest.IIdcie10DiagnosticoIncapacidad, source => source.MapFrom(src => 0))
                .ForMember(dest => dest.IIdcie10, source => source.MapFrom(src => src.IIdcie10))
                .ForMember(dest => dest.IIddiagnosticoIncapacidad, source => source.MapFrom(src => 0));

            CreateMap<TblDiagnosticosIncapacidades, DiagnosticoCorrelacionModel>()
                .ForMember(dest => dest.IIddiagnosticoCorrelacion, source => source.MapFrom(src => src != null ? src.IIddiagnosticoIncapacidad : 0))
                .ForMember(dest => dest.BProrroga, source => source.MapFrom(src => src != null ? true : false))
                .ForMember(dest => dest.IDiasAcumuladosPorroga, source => source.MapFrom(src => src != null ? src.IDiasIncapacidad + (src.IDiasAcumuladosPorroga ?? 0) : 0));

            CreateMap<TblUsuariosNotificaciones, UsuariosNotificacionesModel>()
            .ForMember(dest => dest.IId, source => source.MapFrom(src => src.IId))
             .ForMember(dest => dest.IIDIPS, source => source.MapFrom(src => src.IIdips))
            .ForMember(dest => dest.TCargo, source => source.MapFrom(src => src.TCargo))
            .ForMember(dest => dest.TEmail, source => source.MapFrom(src => src.TEmail))
            .ForMember(dest => dest.TNombreEmpresa, source => source.MapFrom(src => src.TNombreEmpresa))
            .ForMember(dest => dest.TPrimerNombre, source => source.MapFrom(src => src.TPrimerNombre))
            .ForMember(dest => dest.TSegundoNombre, source => source.MapFrom(src => src.TSegundoNombre))
            .ForMember(dest => dest.TPrimerApellido, source => source.MapFrom(src => src.TPrimerApellido))
            .ForMember(dest => dest.TSegundoApellido, source => source.MapFrom(src => src.TSegundoApellido))
            .ForMember(dest => dest.BActivo, source => source.MapFrom(src => src.BActivo));

            CreateMap<UsuariosNotificacionesModel, TblUsuariosNotificaciones>()
           .ForMember(dest => dest.IId, source => source.MapFrom(src => src.IId))
           .ForMember(dest => dest.IIdips, source => source.MapFrom(src => src.IIDIPS))
           .ForMember(dest => dest.TCargo, source => source.MapFrom(src => src.TCargo.ToUpperInvariant()))
           .ForMember(dest => dest.TEmail, source => source.MapFrom(src => src.TEmail.ToUpperInvariant()))
           .ForMember(dest => dest.TNombreEmpresa, source => source.MapFrom(src => src.TNombreEmpresa.ToUpperInvariant()))
           .ForMember(dest => dest.TPrimerNombre, source => source.MapFrom(src => src.TPrimerNombre.ToUpperInvariant()))
           .ForMember(dest => dest.TSegundoNombre, source => source.MapFrom(src => src.TSegundoNombre.ToUpperInvariant()))
           .ForMember(dest => dest.TPrimerApellido, source => source.MapFrom(src => src.TPrimerApellido.ToUpperInvariant()))
           .ForMember(dest => dest.TSegundoApellido, source => source.MapFrom(src => src.TSegundoApellido.ToUpperInvariant()))
           .ForMember(dest => dest.BActivo, source => source.MapFrom(src => src.BActivo));

            CreateMap<TblParametrosEmpresas, ParametrosModel>()
           .ForMember(dest => dest.IIDParametro, source => source.MapFrom(src => src.IIdparametro))
           .ForMember(dest => dest.IIDEmpresa, source => source.MapFrom(src => src.IIdempresa))
           .ForMember(dest => dest.TDescripcion, source => source.MapFrom(src => src.TDescripcion))
           .ForMember(dest => dest.TIdentificador, source => source.MapFrom(src => src.TIdentificador))
           .ForMember(dest => dest.TValor, source => source.MapFrom(src => src.TValor));

            //TODO Replace Login on UI & model to empresasterceros
            CreateMap<TblEmpresas, EmpresaModel>()
            .ForMember(dest => dest.Id, source => source.MapFrom(src => src.IIdempresa))
            .ForMember(dest => dest.tNombreComercial, source => source.MapFrom(src => src.TNombreComercial))
            .ForMember(dest => dest.tRazonSocial, source => source.MapFrom(src => src.TRazonSocial));

            CreateMap<TblEmpleados, EmpleadosModel>()
           .ForMember(dest => dest.TNumeroDocumento, source => source.MapFrom(src => src.TNumeroDocumento))
           .ForMember(dest => dest.TPrimerNombre, source => source.MapFrom(src => src.TPrimerNombre))
           .ForMember(dest => dest.TSegundoNombre, source => source.MapFrom(src => src.TSegundoNombre))
           .ForMember(dest => dest.TPrimerApellido, source => source.MapFrom(src => src.TPrimerApellido))
           .ForMember(dest => dest.TSegundoApellido, source => source.MapFrom(src => src.TSegundoApellido))
           .ForMember(dest => dest.TTarjetaProfesional, source => source.MapFrom(src => src.TNumeroDocumento));

            CreateMap<EmpleadosModel, TblEmpleados>()
          .ForMember(dest => dest.TNumeroDocumento, source => source.MapFrom(src => src.TNumeroDocumento))
          .ForMember(dest => dest.TPrimerNombre, source => source.MapFrom(src => src.TPrimerNombre))
          .ForMember(dest => dest.TSegundoNombre, source => source.MapFrom(src => src.TSegundoNombre))
          .ForMember(dest => dest.TPrimerApellido, source => source.MapFrom(src => src.TPrimerApellido))
          .ForMember(dest => dest.TSegundoApellido, source => source.MapFrom(src => src.TSegundoApellido))
          .ForMember(dest => dest.TNumeroDocumento, source => source.MapFrom(src => src.TTarjetaProfesional));

            CreateMap<TblEstadoAfiliacion, MembershipModel>()
                .ForMember(dest => dest.Id, source => source.MapFrom(src => src.IId))
                .ForMember(dest => dest.Name, source => source.MapFrom(src => src.TNombre));


            CreateMap<TblCie10DiagnosticoIncapacidad, DiagnosticoChrbModel>()
            .ForMember(dest => dest.Diagnostico, source => source.MapFrom(src => src.IIdcie10Navigation))
            .ForMember(dest => dest.FechaCreacion, source => source.MapFrom(src => src.IIddiagnosticoIncapacidadNavigation.DtFechaCreacion));

            CreateMap<Medico, MedicoOutputModel>();

            CreateMap<Detalle, MedicoOutputModel.Detalle>();

            CreateMap<TblUsuarios, UsuarioModel>()
                .ForMember(dest => dest.Documento, conf => conf.MapFrom(src => src.TIdnumDoc));

            // .ForMember(e => e., conf => conf.MapFrom(src => src.))
            // .ForMember(e => e., conf => conf.MapFrom(src => src.))
            // .ForMember(e => e., conf => conf.MapFrom(src => src.))
            // .ForMember(e => e., conf => conf.MapFrom(src => src.))
            // .ForMember(e => e., conf => conf.MapFrom(src => src.));

            CreateMap<TblUsuarios, UsuarioOutputModel>()
                .ForMember(dest => dest.Id, source => source.MapFrom(src => src.IIdusuario))
                .ForMember(dest => dest.Identificacion, source => source.MapFrom(src => src.TIdnumDoc))
                .ForMember(dest => dest.Activo, source => source.MapFrom(src => src.BActivo))
                .ForMember(dest => dest.Nombre,
                source => source.MapFrom(src => (src.TPrimerNombre + Utilidades.TextoNormalizado(src.TSegundoNombre) +
                    src.TPrimerApellido + Utilidades.TextoNormalizado(src.TSegundoApellido)).TrimEnd()));

            CreateMap<TblUsuarios, UsuarioDetalleOutputModel>()
                .ForMember(dest => dest.Id, source => source.MapFrom(src => src.IIdusuario))
                .ForMember(dest => dest.TipoIdentificacion, source => source.MapFrom(src => src.IIdtipoDoc))
                .ForMember(dest => dest.NumeroIdentificacion, source => source.MapFrom(src => src.TIdnumDoc))
                .ForMember(dest => dest.PrimerNombre, source => source.MapFrom(src => src.TPrimerNombre))
                .ForMember(dest => dest.SegundoNombre, source => source.MapFrom(src => src.TSegundoNombre))
                .ForMember(dest => dest.PrimerApellido, source => source.MapFrom(src => src.TPrimerApellido))
                .ForMember(dest => dest.SegundoApellido, source => source.MapFrom(src => src.TSegundoApellido))
                .ForMember(dest => dest.Sexo, source => source.MapFrom(src => src.IIdgenero))
                .ForMember(dest => dest.Correo, source => source.MapFrom(src => src.TEmail))
                .ForMember(dest => dest.FechaNacimiento, source => source.MapFrom(src => src.FechaNacimiento.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds))
                .ForMember(dest => dest.EsMedico, source => source.MapFrom(src => src.EsMedico))
                .ForMember(dest => dest.RegistroMedico, source => source.MapFrom(src => src.RegistroMedico))
                .ForMember(dest => dest.Activo, source => source.MapFrom(src => src.BActivo))
                .ForMember(dest => dest.Correos, source => source.MapFrom(src => src.Correos))
                .ForMember(dest => dest.Direcciones, source => source.MapFrom(src => src.Direcciones))
                .ForMember(dest => dest.Telefonos, source => source.MapFrom(src => src.Telefonos))
                .ForMember(dest => dest.EPSs, source => source.MapFrom(src => src.EPSs))
                .ForMember(dest => dest.RedesSociales, source => source.MapFrom(src => src.RedesSociales))
                .ForMember(dest => dest.Entidades, source => source.MapFrom(src => src.Entidades));

            CreateMap<UsuarioEntidad, EntidadOutputModel>()
               .ForMember(dest => dest.Id, source => source.MapFrom(src => src.EntidadId));

            CreateMap<UsuarioTelefono, TelefonoOutputModel>()
                .ForMember(dest => dest.Id, source => source.MapFrom(src => src.Id))
                .ForMember(dest => dest.Numero, source => source.MapFrom(src => src.Numero))
                .ForMember(dest => dest.Extension, source => source.MapFrom(src => src.Extension))
                .ForMember(dest => dest.Descripcion, source => source.MapFrom(src => src.Descripcion));

            CreateMap<UsuarioDireccion, DireccionOutputModel>()
                .ForMember(dest => dest.Id, source => source.MapFrom(src => src.Id))
                .ForMember(dest => dest.TipoViaPrincipal, source => source.MapFrom(src => src.TipoViaPrincipal))
                .ForMember(dest => dest.NumeroViaPrincipal, source => source.MapFrom(src => src.NumeroViaPrincipal))
                .ForMember(dest => dest.LetraViaPrincipal, source => source.MapFrom(src => src.LetraViaPrincipal))
                .ForMember(dest => dest.NumeroViaSecundaria, source => source.MapFrom(src => src.NumeroViaSecundaria))
                .ForMember(dest => dest.LetraViaSecundaria, source => source.MapFrom(src => src.LetraViaSecundaria))
                .ForMember(dest => dest.DistanciaInterseccion, source => source.MapFrom(src => src.DistanciaInterseccion))
                .ForMember(dest => dest.Indicaciones, source => source.MapFrom(src => src.Indicaciones));

            CreateMap<UsuarioCorreo, CorreoOutputModel>()
                .ForMember(dest => dest.Id, source => source.MapFrom(src => src.Id))
                .ForMember(dest => dest.CorreoElectronico, source => source.MapFrom(src => src.Correo))
                .ForMember(dest => dest.Descripcion, source => source.MapFrom(src => src.Descripcion));

            CreateMap<UsuarioRedSocial, RedSocialOutputModel>()
                .ForMember(dest => dest.Id, source => source.MapFrom(src => src.Id))
                .ForMember(dest => dest.TipoRedSocial, source => source.MapFrom(src => src.TipoRedSocial))
                .ForMember(dest => dest.NombreUsuarioOLink, source => source.MapFrom(src => src.UsuariooLink));

            CreateMap<UsuarioEPS, EPSOutputModel>()
                .ForMember(dest => dest.Id, source => source.MapFrom(src => src.Id))
                .ForMember(dest => dest.EpsId, source => source.MapFrom(src => src.TblEpsId))
                .ForMember(dest => dest.Activo, opt => opt.MapFrom(src => src.Activo));


            CreateMap<UsuarioDetalleInputModel, TblUsuarios>()
                .ForMember(dest => dest.IIdtipoDoc, source => source.MapFrom(src => src.TipoIdentificacion))
                .ForMember(dest => dest.TIdnumDoc, source => source.MapFrom(src => src.NumeroIdentificacion))
                .ForMember(dest => dest.TPrimerNombre, source => source.MapFrom(src => src.PrimerNombre))
                .ForMember(dest => dest.TSegundoNombre, source => source.MapFrom(src => src.SegundoNombre))
                .ForMember(dest => dest.TPrimerApellido, source => source.MapFrom(src => src.PrimerApellido))
                .ForMember(dest => dest.TSegundoApellido, source => source.MapFrom(src => src.SegundoApellido))
                .ForMember(dest => dest.IIdgenero, source => source.MapFrom(src => src.Sexo))
                .ForMember(dest => dest.TEmail, source => source.MapFrom(src => src.Correo))
                .ForMember(dest => dest.FechaNacimiento, source => source.MapFrom(src => new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(src.FechaNacimiento)))
                .ForMember(dest => dest.EsMedico, source => source.MapFrom(src => src.EsMedico))
                .ForMember(dest => dest.RegistroMedico, source => source.MapFrom(src => src.RegistroMedico))
                .ForMember(dest => dest.BActivo, source => source.MapFrom(src => src.Activo))
                .ForMember(dest => dest.BCambioPassword, source => source.UseDestinationValue())
                .ForMember(dest => dest.IPerfilDocumentos, source => source.UseDestinationValue())
                .ForMember(dest => dest.OtrosTratamientos, source => source.UseDestinationValue())
                .ForMember(dest => dest.EsSuperAdmin, source => source.UseDestinationValue())
                .ForMember(dest => dest.Correos, source => source.MapFrom(src => src.Correos))
                .ForMember(dest => dest.Direcciones, source => source.MapFrom(src => src.Direcciones))
                .ForMember(dest => dest.Telefonos, source => source.MapFrom(src => src.Telefonos))
                .ForMember(dest => dest.Entidades, source => source.MapFrom(src => src.Entidades))
                .ForMember(dest => dest.RedesSociales, source => source.MapFrom(src => src.RedesSociales));

            CreateMap<TelefonoInputModel, UsuarioTelefono>()
                .ForMember(dest => dest.Id, source => source.MapFrom(src => src.Id))
                .ForMember(dest => dest.UsuarioId, source => source.MapFrom(src => src.UsuarioId))
                .ForMember(dest => dest.Numero, source => source.MapFrom(src => src.Numero))
                .ForMember(dest => dest.Extension, source => source.MapFrom(src => src.Extension))
                .ForMember(dest => dest.Descripcion, source => source.MapFrom(src => src.Descripcion))
                .ForMember(dest => dest.Usuario, source => source.Ignore());

            CreateMap<EntidadInputModel, UsuarioEntidad>()
                .ForMember(dest => dest.EntidadId, source => source.MapFrom(src => src.Id))
                .ForMember(dest => dest.Entidad, source => source.Ignore())
                .ForMember(dest => dest.Usuario, source => source.Ignore());

            CreateMap<DireccionInputModel, UsuarioDireccion>()
                .ForMember(dest => dest.Id, source => source.MapFrom(src => src.Id))
                .ForMember(dest => dest.UsuarioId, source => source.MapFrom(src => src.UsuarioId))
                .ForMember(dest => dest.DivipolaId, source => source.MapFrom(src => src.DivipolaId))
                .ForMember(dest => dest.TipoViaPrincipal, source => source.MapFrom(src => src.TipoViaPrincipal))
                .ForMember(dest => dest.NumeroViaPrincipal, source => source.MapFrom(src => src.NumeroViaPrincipal))
                .ForMember(dest => dest.LetraViaPrincipal, source => source.MapFrom(src => src.LetraViaPrincipal))
                .ForMember(dest => dest.NumeroViaSecundaria, source => source.MapFrom(src => src.NumeroViaSecundaria))
                .ForMember(dest => dest.LetraViaSecundaria, source => source.MapFrom(src => src.LetraViaSecundaria))
                .ForMember(dest => dest.DistanciaInterseccion, source => source.MapFrom(src => src.DistanciaInterseccion))
                .ForMember(dest => dest.Indicaciones, source => source.MapFrom(src => src.Indicaciones))
                .ForMember(dest => dest.Usuario, source => source.Ignore())
                .ForMember(dest => dest.Divipola, source => source.Ignore());

            CreateMap<CorreoInputModel, UsuarioCorreo>()
                .ForMember(dest => dest.Id, source => source.MapFrom(src => src.Id))
                .ForMember(dest => dest.UsuarioId, source => source.MapFrom(src => src.UsuarioId))
                .ForMember(dest => dest.Correo, source => source.MapFrom(src => src.CorreoElectronico))
                .ForMember(dest => dest.Descripcion, source => source.MapFrom(src => src.Descripcion))
                .ForMember(dest => dest.Usuario, source => source.Ignore());

            CreateMap<RedSocialInputModel, UsuarioRedSocial>()
                .ForMember(dest => dest.Id, source => source.MapFrom(src => src.Id))
                .ForMember(dest => dest.UsuarioId, source => source.MapFrom(src => src.UsuarioId))
                .ForMember(dest => dest.TipoRedSocial, source => source.MapFrom(src => src.RedSocial))
                .ForMember(dest => dest.UsuariooLink, source => source.MapFrom(src => src.NombreUsuarioOLink))
                .ForMember(dest => dest.Usuario, source => source.Ignore());

            CreateMap<EPSInputModel, UsuarioEPS>()
                .ForMember(dest => dest.Id, source => source.MapFrom(src => src.Id))
                .ForMember(dest => dest.TblUsuariosId, source => source.MapFrom(src => src.UsuarioId))
                .ForMember(dest => dest.TblEpsId, source => source.MapFrom(src => src.EPSId))
                .ForMember(dest => dest.Usuario, source => source.Ignore())
                .ForMember(dest => dest.Eps, source => source.Ignore());

            CreateMap<UsuarioInputModel, TblUsuarios>()
                .ForMember(dest => dest.IIdtipoDoc, source => source.MapFrom(src => src.TipoIdentificacion))
                .ForMember(dest => dest.TIdnumDoc, source => source.MapFrom(src => src.NumeroIdentificacion))
                .ForMember(dest => dest.TPrimerNombre, source => source.MapFrom(src => src.PrimerNombre))
                .ForMember(dest => dest.TSegundoNombre, source => source.MapFrom(src => src.SegundoNombre))
                .ForMember(dest => dest.TPrimerApellido, source => source.MapFrom(src => src.PrimerApellido))
                .ForMember(dest => dest.TSegundoApellido, source => source.MapFrom(src => src.SegundoApellido))
                .ForMember(dest => dest.TEmail, source => source.MapFrom(src => src.Correo))
                .ForMember(dest => dest.IIdgenero, source => source.MapFrom(src => src.Sexo))
                .ForMember(dest => dest.FechaNacimiento, source => source.MapFrom(src => new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(src.FechaNacimiento)))
                .ForMember(dest => dest.EsMedico, source => source.MapFrom(src => src.EsMedico))
                .ForMember(dest => dest.RegistroMedico, source => source.MapFrom(src => src.RegistroMedico))
                .ForMember(dest => dest.BActivo, source => source.MapFrom(src => src.Activo));

            CreateMap<TblUsuarios, UsuarioDetalleInputModel>()
                .ForMember(dest => dest.TipoIdentificacion, source => source.MapFrom(src => src.IIdtipoDoc))
                .ForMember(dest => dest.NumeroIdentificacion, source => source.MapFrom(src => src.TIdnumDoc))
                .ForMember(dest => dest.PrimerNombre, source => source.MapFrom(src => src.TPrimerNombre))
                .ForMember(dest => dest.SegundoNombre, source => source.MapFrom(src => src.TSegundoNombre))
                .ForMember(dest => dest.PrimerApellido, source => source.MapFrom(src => src.TPrimerApellido))
                .ForMember(dest => dest.SegundoApellido, source => source.MapFrom(src => src.TSegundoApellido))
                .ForMember(dest => dest.Correo, source => source.MapFrom(src => src.TEmail))
                .ForMember(dest => dest.Sexo, source => source.MapFrom(src => src.IIdgenero))
                .ForMember(dest => dest.FechaNacimiento, source => source.MapFrom(src => src.FechaNacimiento.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds))
                .ForMember(dest => dest.EsMedico, source => source.MapFrom(src => src.EsMedico))
                .ForMember(dest => dest.RegistroMedico, source => source.MapFrom(src => src.RegistroMedico))
                .ForMember(dest => dest.Activo, source => source.MapFrom(src => src.BActivo))
                .ForMember(dest => dest.Correos, source => source.MapFrom(src => src.Correos))
                .ForMember(dest => dest.Direcciones, source => source.MapFrom(src => src.Direcciones))
                .ForMember(dest => dest.Telefonos, source => source.MapFrom(src => src.Telefonos))
                .ForMember(dest => dest.Entidades, source => source.MapFrom(src => src.Entidades))
                .ForMember(dest => dest.RedesSociales, source => source.MapFrom(src => src.RedesSociales));

            CreateMap<UsuarioTelefono, TelefonoInputModel>()
                .ForMember(dest => dest.Id, source => source.MapFrom(src => src.Id))
                .ForMember(dest => dest.Numero, source => source.MapFrom(src => src.Numero))
                .ForMember(dest => dest.Extension, source => source.MapFrom(src => src.Extension))
                .ForMember(dest => dest.Descripcion, source => source.MapFrom(src => src.Descripcion));
            
            CreateMap<UsuarioRedSocial, RedSocialInputModel>()
                .ForMember(dest => dest.Id, source => source.MapFrom(src => src.Id))
                .ForMember(dest => dest.RedSocial, source => source.MapFrom(src => src.TipoRedSocial))
                .ForMember(dest => dest.NombreUsuarioOLink, source => source.MapFrom(src => src.UsuariooLink));

            CreateMap<UsuarioDireccion, DireccionInputModel>()
                .ForMember(dest => dest.Id, source => source.MapFrom(src => src.Id))
                .ForMember(dest => dest.TipoViaPrincipal, source => source.MapFrom(src => src.TipoViaPrincipal))
                .ForMember(dest => dest.Indicaciones, source => source.MapFrom(src => src.Indicaciones));

            CreateMap<UsuarioCorreo, CorreoInputModel>()
                .ForMember(dest => dest.Id, source => source.MapFrom(src => src.Id))
                .ForMember(dest => dest.CorreoElectronico, source => source.MapFrom(src => src.Correo))
                .ForMember(dest => dest.Descripcion, source => source.MapFrom(src => src.Descripcion));

            CreateMap<UsuarioEntidad, EntidadInputModel> ()
                .ForMember(dest => dest.Id, source => source.MapFrom(src => src.EntidadId));
            
            CreateMap<TblDivipola, CiudadOutputModel>()
                .ForMember(dest => dest.Id, source => source.MapFrom(src => src.Iddivipola))
                .ForMember(dest => dest.PaisId, source => source.MapFrom(src => src.Idpais))
                .ForMember(dest => dest.DeptoId, source => source.MapFrom(src => src.Iddepto))
                .ForMember(dest => dest.MunicipioId, source => source.MapFrom(src => src.Idmunicipio))
                .ForMember(dest => dest.Ciudad, source => source.MapFrom(src => src.Nombrepoblacion));

        }
    }

    public static class DatetimeExtensions
    {
        public static DateTime FromUnixTime(this long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime);
        }

        public static long ToUnixTime(this DateTime date)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return Convert.ToInt64((date - epoch).TotalSeconds);
        }
    }
}