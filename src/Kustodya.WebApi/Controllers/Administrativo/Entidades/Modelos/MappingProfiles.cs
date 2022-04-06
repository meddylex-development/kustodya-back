using AutoMapper;
using Kustodya.ApplicationCore.Entities.Administracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Kustodya.WebApi.Controllers.Administrativo.Entidades.Modelos
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Entidad, EntidadDetalleOutputModel>()
            .ForMember(dest => dest.Id, source => source.MapFrom(src => src.Id))
            .ForMember(dest => dest.TipoId, source => source.MapFrom(src => src.TipoId))
            .ForMember(dest => dest.NumeroId, source => source.MapFrom(src => src.NumeroId))
            //.ForMember(dest => dest.TipoEntidad, source => source.MapFrom(src => src.TipoEntidad))
            .ForMember(dest => dest.TipoRelacion, source => source.MapFrom(src => src.TipoRelacion))
            .ForMember(dest => dest.EntidadRelacionId, source => source.MapFrom(src => src.EntidadRelacionId))
            .ForMember(dest => dest.RazonSocial, source => source.MapFrom(src => src.RazonSocial))
            .ForMember(dest => dest.PrimerNombre, source => source.MapFrom(src => src.PrimerNombre))
            .ForMember(dest => dest.SegundoNombre, source => source.MapFrom(src => src.SegundoNombre))
            .ForMember(dest => dest.PrimerApellido, source => source.MapFrom(src => src.PrimerApellido))
            .ForMember(dest => dest.SegundoApellido, source => source.MapFrom(src => src.SegundoApellido))
            .ForMember(dest => dest.CorreoPrincipal, source => source.MapFrom(src => src.CorreoPrincipal))
            .ForMember(dest => dest.DigitoVerificacion, source => source.MapFrom(src => src.DigitoVerificacion))
            .ForMember(dest => dest.Regimen, source => source.MapFrom(src => src.Regimen))
            .ForMember(dest => dest.Naturaleza, source => source.MapFrom(src => src.Naturaleza))
            .ForMember(dest => dest.DiasContrasena, source => source.MapFrom(src => src.DiasContrasena))
            .ForMember(dest => dest.NombreCompania, source => source.MapFrom(src => src.NombreCompania))
            .ForMember(dest => dest.CodigoExterno, source => source.MapFrom(src => src.CodigoExterno))
            .ForMember(dest => dest.CodigoHabilitacion, source => source.MapFrom(src => src.CodigoHabilitacion))
            .ForMember(dest => dest.CodigoCIIU, source => source.MapFrom(src => src.CodigoCIIU))
            .ForMember(dest => dest.TipoSociedad, source => source.MapFrom(src => src.TipoSociedad))
            //.ForMember(dest => dest.Logo, source => source.MapFrom(src => src.Logo))
            .ForMember(dest => dest.Telefonos, source => source.MapFrom(src => src.Telefonos))
            .ForMember(dest => dest.Direcciones, source => source.MapFrom(src => src.Direcciones))
            .ForMember(dest => dest.Correos, source => source.MapFrom(src => src.Correos))
            .ForMember(dest => dest.RedesSociales, source => source.MapFrom(src => src.RedesSociales))
            .ForMember(dest => dest.Otros, source => source.MapFrom(src => src.Otros))
            //.ForMember(dest => dest.ContabilidadDefecto, source => source.MapFrom(src => src.cp))
            .ForMember(dest => dest.Clientes, source => source.MapFrom(src => src.Clientes));

            CreateMap<EntidadCorreo, CorreoOutputModel>()
                .ForMember(dest => dest.Id, source => source.MapFrom(src => src.Id))
                .ForMember(dest => dest.CorreoElectronico , source => source.MapFrom(src => src.Correo))
                .ForMember(dest => dest.Descripcion, source => source.MapFrom(src => src.Descripcion));
            
            CreateMap<EntidadTelefono, TelefonoOutputModel>()
                .ForMember(dest => dest.Id, source => source.MapFrom(src => src.Id))
                .ForMember(dest => dest.Numero, source => source.MapFrom(src => src.Numero))
                .ForMember(dest => dest.Extension, source => source.MapFrom(src => src.Extension))
                .ForMember(dest => dest.Descripcion, source => source.MapFrom(src => src.Descripcion));

            CreateMap<EntidadDireccion, DireccionOutputModel>()
                .ForMember(dest => dest.Id, source => source.MapFrom(src => src.Id))
                .ForMember(dest => dest.NumeroViaPrincipal, source => source.MapFrom(src => src.NumeroViaPrincipal))
                .ForMember(dest => dest.LetraViaPrincipal, source => source.MapFrom(src => src.LetraViaPrincipal))
                .ForMember(dest => dest.NumeroViaSecundaria, source => source.MapFrom(src => src.NumeroViaSecundaria))
                .ForMember(dest => dest.LetraViaSecundaria, source => source.MapFrom(src => src.LetraViaSecundaria))
                .ForMember(dest => dest.Indicaciones, source => source.MapFrom(src => src.Indicaciones));

            CreateMap<EntidadRedSocial, RedSocialOutputModel>()
                .ForMember(dest => dest.Id, source => source.MapFrom(src => src.Id))
                .ForMember(dest => dest.TipoRedSocial, source => source.MapFrom(src => src.TipoRedSocial))
                .ForMember(dest => dest.NombreUsuarioOLink, source => source.MapFrom(src => src.usuarioOLink));
            
            CreateMap<EntidadOtro, OtroOutputModel>()
                .ForMember(dest => dest.Id, source => source.MapFrom(src => src.Id))
                .ForMember(dest => dest.Categoria, source => source.MapFrom(src => src.Categoria))
                .ForMember(dest => dest.Nombre, source => source.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.Valor, source => source.MapFrom(src => src.Valor))
                .ForMember(dest => dest.Descripcion, source => source.MapFrom(src => src.Descripcion));

            CreateMap<Cliente, ClienteOutputModel>()
                .ForMember(dest => dest.Id, source => source.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nombre, source =>
                source.MapFrom(src => (src.PrimerNombre != null ? (src.PrimerNombre + " " + src.PrimerApellido) : src.RazonSocial)));

            CreateMap<Entidad, EntidadOutputModel>()
                .ForMember(dest => dest.Id, source => source.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nombre, source =>
                source.MapFrom(src => (src.PrimerNombre != null ? (src.PrimerNombre + " " + src.PrimerApellido) : src.RazonSocial)));

            CreateMap<EntidadInputModel, Entidad>()
                .ForMember(dest => dest.Id, source => source.UseDestinationValue())
                .ForMember(dest => dest.TipoId, source => source.MapFrom(src => src.TipoId))
                .ForMember(dest => dest.NumeroId, source => source.MapFrom(src => src.NumeroId))
                .ForMember(dest => dest.Sucursal, source => source.MapFrom(src => src.Sucursal))
                //.ForMember(dest => dest.TipoEntidad, source => source.MapFrom(src => src.TipoEntidad))
                .ForMember(dest => dest.TipoRelacion, source => source.MapFrom(src => src.TipoRelacion))
                .ForMember(dest => dest.EntidadRelacionId, source => source.MapFrom(src => src.EntidadRelacionId))
                .ForMember(dest => dest.RazonSocial, source => source.MapFrom(src => src.RazonSocial))
                .ForMember(dest => dest.PrimerNombre, source => source.MapFrom(src => src.PrimerNombre))
                .ForMember(dest => dest.SegundoNombre, source => source.MapFrom(src => src.SegundoNombre))
                .ForMember(dest => dest.PrimerApellido, source => source.MapFrom(src => src.PrimerApellido))
                .ForMember(dest => dest.SegundoApellido, source => source.MapFrom(src => src.SegundoApellido))
                .ForMember(dest => dest.CorreoPrincipal, source => source.MapFrom(src => src.CorreoPrincipal))
                .ForMember(dest => dest.DigitoVerificacion, source => source.MapFrom(src => src.DigitoVerificacion))
                .ForMember(dest => dest.Regimen, source => source.MapFrom(src => src.Regimen))
                .ForMember(dest => dest.Naturaleza, source => source.MapFrom(src => src.Naturaleza))
                .ForMember(dest => dest.DiasContrasena, source => source.MapFrom(src => src.DiasContrasena))
                .ForMember(dest => dest.NombreCompania, source => source.MapFrom(src => src.NombreCompania))
                .ForMember(dest => dest.CodigoExterno, source => source.MapFrom(src => src.CodigoExterno))
                .ForMember(dest => dest.CodigoHabilitacion, source => source.MapFrom(src => src.CodigoHabilitacion))
                .ForMember(dest => dest.CodigoCIIU, source => source.MapFrom(src => src.CodigoCIIU))
                .ForMember(dest => dest.TipoSociedad, source => source.MapFrom(src => src.TipoSociedad));

            CreateMap<EntidadDetalleInputModel, Entidad>()
                .ForMember(dest => dest.Id, source => source.UseDestinationValue())
                .ForMember(dest => dest.TipoId, source => source.MapFrom(src => src.TipoId))
                .ForMember(dest => dest.NumeroId, source => source.MapFrom(src => src.NumeroId))
                .ForMember(dest => dest.TipoEntidad, source => source.MapFrom(src => src.TipoEntidad))
                .ForMember(dest => dest.TipoRelacion, source => source.MapFrom(src => src.TipoRelacion))
                .ForMember(dest => dest.EntidadRelacionId, source => source.MapFrom(src => src.EntidadRelacionId))
                .ForMember(dest => dest.RazonSocial, source => source.MapFrom(src => src.RazonSocial))
                .ForMember(dest => dest.PrimerNombre, source => source.MapFrom(src => src.PrimerNombre))
                .ForMember(dest => dest.SegundoNombre, source => source.MapFrom(src => src.SegundoNombre))
                .ForMember(dest => dest.PrimerApellido, source => source.MapFrom(src => src.PrimerApellido))
                .ForMember(dest => dest.SegundoApellido, source => source.MapFrom(src => src.SegundoApellido))
                .ForMember(dest => dest.CorreoPrincipal, source => source.MapFrom(src => src.CorreoPrincipal))
                .ForMember(dest => dest.Sucursal, source => source.MapFrom(src => src.Sucursal))
                .ForMember(dest => dest.DigitoVerificacion, source => source.MapFrom(src => src.DigitoVerificacion))
                .ForMember(dest => dest.Regimen, source => source.MapFrom(src => src.Regimen))
                .ForMember(dest => dest.Naturaleza, source => source.MapFrom(src => src.Naturaleza))
                .ForMember(dest => dest.DiasContrasena, source => source.MapFrom(src => src.DiasContrasena))
                .ForMember(dest => dest.NombreCompania, source => source.MapFrom(src => src.NombreCompania))
                .ForMember(dest => dest.CodigoExterno, source => source.MapFrom(src => src.CodigoExterno))
                .ForMember(dest => dest.CodigoHabilitacion, source => source.MapFrom(src => src.CodigoHabilitacion))
                .ForMember(dest => dest.CodigoCIIU, source => source.MapFrom(src => src.CodigoCIIU))
                .ForMember(dest => dest.TipoSociedad, source => source.MapFrom(src => src.TipoSociedad))
                .ForMember(dest => dest.Telefonos, source => source.MapFrom(src => src.Telefonos))
                .ForMember(dest => dest.Direcciones, source => source.MapFrom(src => src.Direcciones))
                .ForMember(dest => dest.RedesSociales, source => source.MapFrom(src => src.RedesSociales))
                .ForMember(dest => dest.Otros, source => source.MapFrom(src => src.Otros))
                .ForMember(dest => dest.Correos, source => source.MapFrom(src => src.Correos));

            CreateMap<TelefonoInputModel, EntidadTelefono>()
                .ForMember(dest => dest.Id, source => source.MapFrom(src => src.Id))
                .ForMember(dest => dest.EntidadId, source => source.MapFrom(src => src.EntidadId))
                .ForMember(dest => dest.Numero, source => source.MapFrom(src => src.Numero))
                .ForMember(dest => dest.Extension, source => source.MapFrom(src => src.Extension))
                .ForMember(dest => dest.Descripcion, source => source.MapFrom(src => src.Descripcion))
                .ForMember(dest => dest.Entidad, source => source.Ignore());

            CreateMap<DireccionInputModel, EntidadDireccion>()
                .ForMember(dest => dest.Id, source => source.MapFrom(src => src.Id))
                .ForMember(dest => dest.EntidadId, source => source.MapFrom(src => src.EntidadId))
                .ForMember(dest => dest.DivipolaId, source => source.MapFrom(src => src.DivipolaId))
                .ForMember(dest => dest.TipoViaPrincipal, source => source.MapFrom(src => src.TipoViaPrincipal))
                .ForMember(dest => dest.NumeroViaPrincipal, source => source.MapFrom(src => src.NumeroViaPrincipal))
                .ForMember(dest => dest.LetraViaPrincipal, source => source.MapFrom(src => src.LetraViaPrincipal))
                .ForMember(dest => dest.NumeroViaSecundaria, source => source.MapFrom(src => src.NumeroViaSecundaria))
                .ForMember(dest => dest.LetraViaSecundaria, source => source.MapFrom(src => src.LetraViaSecundaria))
                .ForMember(dest => dest.DistanciaInterseccion, source => source.MapFrom(src => src.DistanciaInterseccion))
                .ForMember(dest => dest.Indicaciones, source => source.MapFrom(src => src.Indicaciones))
                .ForMember(dest => dest.Entidad, source => source.Ignore())
                .ForMember(dest => dest.Divipola, source => source.Ignore());

            CreateMap<CorreoInputModel, EntidadCorreo>()
                .ForMember(dest => dest.Id, source => source.MapFrom(src => src.Id))
                .ForMember(dest => dest.EntidadId, source => source.MapFrom(src => src.EntidadId))
                .ForMember(dest => dest.Correo, source => source.MapFrom(src => src.CorreoElectronico))
                .ForMember(dest => dest.Descripcion, source => source.MapFrom(src => src.Descripcion))
                .ForMember(dest => dest.Entidad, source => source.Ignore());

            CreateMap<RedSocialInputModel, EntidadRedSocial>()
                .ForMember(dest => dest.Id, source => source.MapFrom(src => src.Id))
                .ForMember(dest => dest.EntidadId, source => source.MapFrom(src => src.EntidadId))
                .ForMember(dest => dest.TipoRedSocial, source => source.MapFrom(src => src.RedSocial))
                .ForMember(dest => dest.usuarioOLink, source => source.MapFrom(src => src.NombreUsuarioOLink))
                .ForMember(dest => dest.Entidad, source => source.Ignore());

            CreateMap<OtroInputModel, EntidadOtro>()
                .ForMember(dest => dest.Id, source => source.MapFrom(src => src.Id))
                .ForMember(dest => dest.Categoria, source => source.MapFrom(src => src.Categoria))
                .ForMember(dest => dest.Nombre, source => source.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.Valor, source => source.MapFrom(src => src.Valor))
                .ForMember(dest => dest.Descripcion, source => source.MapFrom(src => src.Descripcion))
                .ForMember(dest => dest.Entidad, source => source.Ignore());

            CreateMap<Entidad, EntidadDetalleInputModel>()
            .ForMember(dest => dest.TipoId, source => source.MapFrom(src => src.TipoId))
            .ForMember(dest => dest.NumeroId, source => source.MapFrom(src => src.NumeroId))
            .ForMember(dest => dest.TipoEntidad, source => source.MapFrom(src => src.TipoEntidad))
            .ForMember(dest => dest.TipoRelacion, source => source.MapFrom(src => src.TipoRelacion))
            .ForMember(dest => dest.EntidadRelacionId, source => source.MapFrom(src => src.EntidadRelacionId))
            .ForMember(dest => dest.RazonSocial, source => source.MapFrom(src => src.RazonSocial))
            .ForMember(dest => dest.PrimerNombre, source => source.MapFrom(src => src.PrimerNombre))
            .ForMember(dest => dest.SegundoNombre, source => source.MapFrom(src => src.SegundoNombre))
            .ForMember(dest => dest.PrimerApellido, source => source.MapFrom(src => src.PrimerApellido))
            .ForMember(dest => dest.SegundoApellido, source => source.MapFrom(src => src.SegundoApellido))
            .ForMember(dest => dest.CorreoPrincipal, source => source.MapFrom(src => src.CorreoPrincipal))
            .ForMember(dest => dest.DigitoVerificacion, source => source.MapFrom(src => src.DigitoVerificacion))
            .ForMember(dest => dest.Regimen, source => source.MapFrom(src => src.Regimen))
            .ForMember(dest => dest.Naturaleza, source => source.MapFrom(src => src.Naturaleza))
            .ForMember(dest => dest.DiasContrasena, source => source.MapFrom(src => src.DiasContrasena))
            .ForMember(dest => dest.NombreCompania, source => source.MapFrom(src => src.NombreCompania))
            .ForMember(dest => dest.CodigoExterno, source => source.MapFrom(src => src.CodigoExterno))
            .ForMember(dest => dest.CodigoHabilitacion, source => source.MapFrom(src => src.CodigoHabilitacion))
            .ForMember(dest => dest.CodigoCIIU, source => source.MapFrom(src => src.CodigoCIIU))
            .ForMember(dest => dest.TipoSociedad, source => source.MapFrom(src => src.TipoSociedad))
            .ForMember(dest => dest.Telefonos, source => source.MapFrom(src => src.Telefonos))
            .ForMember(dest => dest.Direcciones, source => source.MapFrom(src => src.Direcciones))
            .ForMember(dest => dest.Correos, source => source.MapFrom(src => src.Correos))
            .ForMember(dest => dest.RedesSociales, source => source.MapFrom(src => src.RedesSociales));

            CreateMap<EntidadCorreo, CorreoInputModel>()
                .ForMember(dest => dest.CorreoElectronico, source => source.MapFrom(src => src.Correo))
                .ForMember(dest => dest.Descripcion, source => source.MapFrom(src => src.Descripcion));

            CreateMap<EntidadTelefono, TelefonoInputModel>();

            CreateMap<EntidadDireccion, DireccionInputModel>();

            CreateMap<EntidadRedSocial, RedSocialInputModel>()
                .ForMember(dest => dest.NombreUsuarioOLink, source => source.MapFrom(src => src.usuarioOLink));

            CreateMap<EntidadOtro, OtroInputModel>();
        }
    }
}
