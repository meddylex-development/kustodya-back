using Kustodya.ApplicationCore.Dtos;
using Kustodya.ApplicationCore.Dtos.General;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.Interfaces
{
    public interface IEmpresaService
    {
        Task<EmpresaTercerosModel> GetEmpresaById(long id);

        Task<IList<EmpresaTercerosModel>> GetEmpresasByName(string name);

        Task<EmpresaTercerosModel> GetEmpresasByNIT(string nit);

        Task<IList<EmpresaModel>> GetEmpresasUsuario(int IIdusuario);
    }
}