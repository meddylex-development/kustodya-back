using Kustodya.ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.Interfaces
{
    public interface IMenuService
    {
        Task<IReadOnlyList<TblMenu>> GetMenusPerfil(int IIdperfil);
    }
}