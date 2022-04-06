using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Dtos.Negocio.RH;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.Interfaces.General
{
    public interface IEmpleadosService
    {
        Task<EmpleadosModel> AddEmpleado(TblEmpleados empleado);

        Task<EmpleadosModel> GetEmpleadoByIdCargoAndCedula(long idcargo, long cedula);

        Task<ICollection<EmpleadosModel>> GetEmpleadosByIdCargoAndName(long idcargo, string name);
    }
}