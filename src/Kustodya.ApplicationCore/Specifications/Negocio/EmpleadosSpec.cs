using Kustodya.ApplicationCore.Entities;
using System.Globalization;

namespace Kustodya.ApplicationCore.Specifications.Negocio
{
    public class EmpleadosSpec : BaseSpec<TblEmpleados>
    {
        private long cedula;
        private string name;

        public EmpleadosSpec(long cedula) : base(u => u.TNumeroDocumento == cedula.ToString(CultureInfo.InvariantCulture))
        {
        }

        public EmpleadosSpec(long idcargo, long cedula) :
            base(u => u.TNumeroDocumento == cedula.ToString(CultureInfo.InvariantCulture) &&
           u.IIdcargo == idcargo)
        { }

        public EmpleadosSpec(long idCargo, string name) : base(u => u.IIdcargo == idCargo && (u.TPrimerNombre.Contains(name) || u.TSegundoNombre.Contains(name)))
        {
        }
    }
}