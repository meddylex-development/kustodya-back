using Kustodya.ApplicationCore.Constants;
using Kustodya.ApplicationCore.Entities.Medicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Specifications
{
    public class MedicoSpecification : BaseSpec<Medico>
    {
        public MedicoSpecification(string documentNumber, TipoIdentificacion identificationType)
                : base(e => e.NumeroIdentifiacion == documentNumber && e.TipoIdentificacion == identificationType)
        {
        }
    }
}
