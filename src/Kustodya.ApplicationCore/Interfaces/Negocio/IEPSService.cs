using Kustodya.ApplicationCore.Dtos.Negocio;
using Kustodya.ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.Interfaces.Negocio
{
    public interface IEPSService
    {
        Task<IReadOnlyList<EpsModel>> GetAllEPS();
        Task<EpsModel> GetEPSById(long idEps);
        Task<IReadOnlyList<UsuarioEPS>> GetAllEPSByUser(int IdUser);
        Task<string> CrearUsuarioEPS(UsuarioEPS usuarioEPS);
        Task<string> EliminarUsuarioEPS(UsuarioEPS usuarioEPS);
        
    }
}