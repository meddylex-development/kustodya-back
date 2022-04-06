using Kustodya.ApplicationCore.Constants;
using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Entities.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Specifications
{
    class EmployeeSpec : BaseSpec<TblEmpleados>
    {
        public EmployeeSpec(string documentNumber, TipoIdentificacion identificationType)
                : base(e => e.TNumeroDocumento == documentNumber && e.IIdtipoDocumento == (int)identificationType)
        {
        }
    }
}
