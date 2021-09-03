using Kustodya.ApplicationCore.Entities;

namespace Kustodya.ApplicationCore.Specifications.Configuracion.Notificaciones
{
    public sealed class UsuariosNotificacionesSpec : BaseSpec<TblUsuariosNotificaciones>
    {
        public UsuariosNotificacionesSpec(int id, int idUsuarioNotificacion) : base(u => u.IId == idUsuarioNotificacion && u.IIdips == id)
        {
        }
    }
}