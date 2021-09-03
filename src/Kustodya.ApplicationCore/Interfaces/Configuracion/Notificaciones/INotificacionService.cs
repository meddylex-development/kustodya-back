using Kustodya.ApplicationCore.Dtos.Configuracion.Notificaciones;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.Interfaces.Configuracion.Notificaciones
{
    public interface INotificacionService
    {
        Task AddEmailConfigurationByIdEmpresa(UsuariosNotificacionesModel value);

        Task<ICollection<UsuariosNotificacionesModel>> GetEmailConfigurationByIdEmpresa(int id);

        Task RemoveUserFromEmailNotificationsByIdEmpresaUsuario(int id, int idUsuarioNotificacion);

        Task<bool> UpdateUsuarioEmpresaNotificacion(UsuariosNotificacionesModel model);
    }
}