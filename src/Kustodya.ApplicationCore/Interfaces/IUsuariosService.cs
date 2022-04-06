using Kustodya.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.Interfaces
{
    public interface IUsuariosService
    {
        Task<IReadOnlyList<TblUsuarios>> ObtenerUsuariosporFiltro(int entidadId, string busqueda, int? skip = null, int? take = null);
        Task<int> TotalUsuarios(int entidadId, string busqueda);
        Task<TblUsuarios> ObtenerUsuarioDetalle(int id);
        Task<TblUsuarios> ObtenerUsuarioDetallePorCorreo(string correo);
        Task EliminarUsuario(int id);
        Task<TblUsuarios> CrearUsuario(TblUsuarios usuario);
        Task<string> ObtenerEntidadesAdministrador(int usuarioId);
        Task<string> ObtenerEntidadesUsuario(int usuarioId);
        int[] ObtenerEntidades(string entidades);
        Task<int> TotalAdministradores(string busqueda);
        Task<IReadOnlyList<TblUsuarios>> Administradores(string busqueda, int? skip = null, int? take = null);
        Task<bool> ValidarCorreo(string correo);
        Task<int> TotalAdministradoresPorEntidad(string busqueda, int entidadId);
        Task<IReadOnlyList<TblUsuarios>> AdministradoresPorEntidad(string busqueda, int entidadId, int? skip = null, int? take = null);
        Task ActualizarPassword(int usuarioId, string password);
    }
}
