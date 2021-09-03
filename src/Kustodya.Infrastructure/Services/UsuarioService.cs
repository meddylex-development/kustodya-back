using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Specifications;
using Kustodya.ApplicationCore.Entities;
using System.Threading.Tasks;

namespace Kustodya.Infrastructure.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ILoggerService<UsuarioService> _logger;
        private readonly IAsyncRepository<TblUsuarios> _usuariosRepository;

        public UsuarioService(IAsyncRepository<TblUsuarios> usuariosRepository, ILoggerService<UsuarioService> logger)
        {
            _usuariosRepository = usuariosRepository;
            _logger = logger;
        }

        public async Task<TblUsuarios> Login(string user, string password)
        {
            var usuarioSpec = new UsuarioSpec(user, password);
            var usuario = await _usuariosRepository.GetOneAsync(usuarioSpec);

            return usuario;
        }
        //public async Task<UsuarioModel> GetUserInfoById(int IdUsuario) {
        //    return new UsuarioModel();
        //}
    }
}