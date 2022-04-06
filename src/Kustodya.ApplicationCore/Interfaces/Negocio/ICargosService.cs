using Kustodya.ApplicationCore.Dtos.Negocio.RH;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.Interfaces.Negocio
{
    public interface ICargosService
    {
        Task<EmpleadosModel> AddMedico(EmpleadosModel medico);

        Task<EmpleadosModel> GetMedicoByCedula(long cedula);

        Task<ICollection<EmpleadosModel>> GetMedicosByName(string name);
    }
}