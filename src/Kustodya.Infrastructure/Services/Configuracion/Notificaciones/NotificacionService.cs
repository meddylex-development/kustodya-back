using AutoMapper;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Specifications.Configuracion.Notificaciones;
using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Dtos.Configuracion.Notificaciones;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kustodya.ApplicationCore.Interfaces.Configuracion.Notificaciones;

namespace Kustodya.BusinessLogic.Services.Configuracion.Notificaciones
{
    public class NotificacionService : INotificacionService
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<TblUsuariosNotificaciones> _repositoryUsuariosNotificacion;

        public NotificacionService(IAsyncRepository<TblUsuariosNotificaciones> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryUsuariosNotificacion = repository;
        }

        public async Task AddEmailConfigurationByIdEmpresa(UsuariosNotificacionesModel value)
        {
            TblUsuariosNotificaciones usuario = _mapper.Map<TblUsuariosNotificaciones>(value);
            await _repositoryUsuariosNotificacion.AddAsync(usuario).ConfigureAwait(false);
        }

        public async Task<ICollection<UsuariosNotificacionesModel>> GetEmailConfigurationByIdEmpresa(int id)
        {
            IReadOnlyList<TblUsuariosNotificaciones> lUsuarios = await _repositoryUsuariosNotificacion.ListAllAsync().ConfigureAwait(false);
            ICollection<UsuariosNotificacionesModel> lCollectionUsuarios = new List<UsuariosNotificacionesModel>();
            UsuariosNotificacionesModel model = new UsuariosNotificacionesModel();
            foreach (TblUsuariosNotificaciones un in lUsuarios)
            {
                model = _mapper.Map<UsuariosNotificacionesModel>(un);
                lCollectionUsuarios.Add(model);
            }
            return lCollectionUsuarios;
        }

        public async Task RemoveUserFromEmailNotificationsByIdEmpresaUsuario(int id, int idUsuarioNotificacion)
        {
            var spec = new UsuariosNotificacionesSpec(id, idUsuarioNotificacion);
            var usuario = await _repositoryUsuariosNotificacion.GetOneAsync(spec).ConfigureAwait(false);
            await _repositoryUsuariosNotificacion.DeleteAsync(usuario).ConfigureAwait(false);
        }

        public async Task<bool> UpdateUsuarioEmpresaNotificacion(UsuariosNotificacionesModel model)
        {
            var spec = new UsuariosNotificacionesSpec(model.IIDIPS, model.IId);
            var usuario = await _repositoryUsuariosNotificacion.GetOneAsync(spec).ConfigureAwait(false);

            if (usuario == null)
            {
                const string Message = "Usuario no encontrado.";
                throw new Exception(Message);
            }

            usuario.TPrimerNombre = model.TPrimerNombre;
            usuario.TPrimerApellido = model.TPrimerApellido;
            usuario.TSegundoNombre = model.TSegundoNombre;
            usuario.TSegundoApellido = model.TSegundoApellido;
            usuario.TCargo = model.TCargo;
            usuario.TEmail = model.TEmail;
            usuario.TNombreEmpresa = model.TNombreEmpresa;
            await _repositoryUsuariosNotificacion.UpdateAsync(usuario).ConfigureAwait(false);
            return true;
        }
    }
}