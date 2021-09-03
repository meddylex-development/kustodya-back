using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Specifications;
using Kustodya.ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kustodya.Infrastructure.Services
{
    public class MenuService : IMenuService
    {
        private readonly ILoggerService<UsuarioService> _logger;
        private readonly IAsyncRepository<TblMenu> _menuRepository;

        public MenuService(IAsyncRepository<TblMenu> menuRepository, ILoggerService<UsuarioService> logger)
        {
            _menuRepository = menuRepository;
            _logger = logger;
        }

        public async Task<IReadOnlyList<TblMenu>> GetMenusPerfil(int IIdperfil)
        {
            var menuSpec = new MenuSpec(IIdperfil);
            var menus = await _menuRepository.ListAsync(menuSpec);

            return menus;
        }
    }
}