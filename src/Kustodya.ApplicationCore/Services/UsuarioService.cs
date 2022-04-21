using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Specifications;
using Kustodya.ApplicationCore.Specifications.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Kustodya.ApplicationCore.Entities.Administracion;

namespace Kustodya.ApplicationCore.Services
{
    public class UsuarioService : IUsuariosService
    {
        #region Dependency Injection
        private readonly IAsyncRepository<TblUsuarios> _usuariosRepo;
        private readonly IAsyncRepository<TblActas> _actasRepo;
        private readonly IAsyncRepository<UsuarioEntidadPerfil> _repoUsuarioEntidadPerfil;
        private readonly IAsyncRepository<UsuarioEntidad> _repoUsuarioEntidad;
        #endregion

        public UsuarioService(IAsyncRepository<TblUsuarios> usuariosRepo, 
            IAsyncRepository<UsuarioEntidadPerfil> repoUsuarioEntidadPerfil, IAsyncRepository<UsuarioEntidad> repoUsuarioEntidad)
        {
            _usuariosRepo = usuariosRepo;
            _repoUsuarioEntidadPerfil = repoUsuarioEntidadPerfil;
            _repoUsuarioEntidad = repoUsuarioEntidad;
        }
        public async Task<IReadOnlyList<TblUsuarios>> ObtenerUsuariosporFiltro(int entidadId, string busqueda, int? skip = null, int? take = null)
        {
            var spec = new UsuarioPorEntidadyNombreSpec(entidadId, busqueda, skip, take);
            var requests = await _usuariosRepo.ListAsync(spec);
            return  requests;
        }
        public async Task<IReadOnlyList<TblUsuarios>> ObtenerUsuariosporFiltroperfil(int entidadId, int perfil, string busqueda, int? skip = null, int? take = null)// Filtra entidad y perfil
        {
            var spec = new UsuarioPorEntidadyPerfilSpec(entidadId, perfil, busqueda, skip, take);
            var requests = await _usuariosRepo.ListAsync(spec);
            return requests;
        }
        public async Task<int> TotalUsuarios(int entidadId, string busqueda) {
            var spec = new UsuarioPorEntidadyNombreSpec(entidadId, busqueda, 0, int.MaxValue);
            return await _usuariosRepo.CountAsync(spec);
        }
        public async Task<int> TotalUsuariosPerfil(int entidadId, int perfil, string busqueda)// Filtra entidad y perfil
        {
            var spec = new UsuarioPorEntidadyPerfilSpec(entidadId, perfil, busqueda, 0, int.MaxValue);
            return await _usuariosRepo.CountAsync(spec);
        }
        public async Task<TblUsuarios> ObtenerUsuarioDetalle(int id) {
            var spec = new UsuarioDetalleSpec(id);
            return await _usuariosRepo.GetOneAsync(spec);
        }
        public async Task<TblUsuarios> ObtenerUsuarioDetallePorCorreo(string correo)
        {
            var spec = new UsuarioDetalleSpec(correo);
            return await _usuariosRepo.GetOneAsync(spec);
        }
        public async Task<TblUsuarios> CrearUsuario(TblUsuarios usuario) {
            usuario.DtFechaCreacion = DateTime.Now;
            usuario.IIdusuarioCreador = 1;
            usuario.TClave = "";
            usuario.TUsuario = usuario.TPrimerNombre.Substring(0, 1) + usuario.TPrimerApellido;
            usuario.DtFechaCambioPassword = DateTime.Now;
            await _usuariosRepo.AddAsync(usuario);
            return usuario;
        }
        public async Task EliminarUsuario(int id) {
            var spec = new UsuarioSpec(id);
            TblUsuarios usuario = await _usuariosRepo.GetOneAsync(spec);
            usuario.TblActas.Clear();
            await _usuariosRepo.DeleteAsync(usuario);
        }
        public async Task<string> ObtenerEntidadesAdministrador(int usuarioId) { 
            IReadOnlyList<UsuarioEntidadPerfil> usuarioEntidadPerfiles = await _repoUsuarioEntidadPerfil.ListAllAsync();
            usuarioEntidadPerfiles = usuarioEntidadPerfiles.Where(c => c.PerfilId == 2).ToList();
            IReadOnlyList<UsuarioEntidad> usuarioEntidades = await _repoUsuarioEntidad.ListAllAsync();
            usuarioEntidades = usuarioEntidades.Where(c => c.UsuarioId == usuarioId).ToList();
            usuarioEntidades = usuarioEntidades.Where(c => usuarioEntidadPerfiles.Select(d => d.UsuarioEntidadId).Contains(c.Id)).ToList();
            string entidades = "";
            foreach (UsuarioEntidad item in usuarioEntidades)
            {
                entidades += item.EntidadId.ToString() + ",";
            }
            return entidades.Length  > 0 ? entidades.Substring(0, entidades.Length - 1) : entidades;
        }
        public async Task<string> ObtenerEntidadesUsuario(int usuarioId)
        {
            IReadOnlyList<UsuarioEntidadPerfil> usuarioEntidadPerfiles = await _repoUsuarioEntidadPerfil.ListAllAsync();
            IReadOnlyList<UsuarioEntidad> usuarioEntidades = await _repoUsuarioEntidad.ListAllAsync();
            usuarioEntidades = usuarioEntidades.Where(c => c.UsuarioId == usuarioId).ToList();
            usuarioEntidades = usuarioEntidades.Where(c => usuarioEntidadPerfiles.Select(d => d.UsuarioEntidadId).Contains(c.Id)).ToList();
            string entidades = "";
            foreach (UsuarioEntidad item in usuarioEntidades)
            {
                entidades += item.EntidadId.ToString() + ",";
            }
            return entidades.Length > 0 ? entidades.Substring(0, entidades.Length - 1) : entidades;
        }
        public int[] ObtenerEntidades(string entidades)
        {
            string[] entidadesArray = entidades.Split(',');
            return System.Array.ConvertAll(entidadesArray, s => int.Parse(s));
        }

        public async Task<int> TotalAdministradores(string busqueda) {
            var spec = new BusquedaUsuariosAdministradoresSpec(busqueda, null, null);
            var requests = await _usuariosRepo.CountAsync(spec);
            return requests;
        }
        public async Task<int> TotalAdministradoresPorEntidad(string busqueda, int entidadId)
        {
            var spec = new BusquedaUsuariosAdministradoresporEntidadSpec(busqueda, entidadId, null, null);
            var requests = await _usuariosRepo.CountAsync(spec);
            return requests;
        }
        public async Task<IReadOnlyList<TblUsuarios>> Administradores(string busqueda, int? skip = null, int? take = null)
        {
            var spec = new BusquedaUsuariosAdministradoresSpec(busqueda, skip, take);
            var requests = await _usuariosRepo.ListAsync(spec);
            return requests;
        }
        public async Task<IReadOnlyList<TblUsuarios>> AdministradoresPorEntidad(string busqueda, int entidadId, int? skip = null, int? take = null)
        {
            var spec = new BusquedaUsuariosAdministradoresSpec(busqueda, skip, take);
            var requests = await _usuariosRepo.ListAsync(spec);
            return requests;
        }
        public async Task<bool> ValidarCorreo(string correo) {
            var spec = new UsuarioPorCorreoSpec(correo);
            var requests = await _usuariosRepo.ListAsync(spec);
            if (requests.Count() == 0)
            {
                return false;
            }
            else {
                return true;
            }
        }

        public async Task ActualizarPassword(int usuarioId, string password)
        {
            var usuario = await _usuariosRepo.GetByIdAsync(usuarioId);
            if (usuario == null)
            {
                throw new Exception("Usuario no encontrado");
            }
            usuario.TClave = CreateMD5(password);
            usuario.BCambioPassword = false;
            await _usuariosRepo.UpdateAsync(usuario);
        }
        private static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
