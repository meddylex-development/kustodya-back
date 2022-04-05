using System;
using System.Collections.Generic;
using System.Text;
using Kustodya.ApplicationCore.Entities.Concepto;
using Kustodya.ApplicationCore.Helpers;

namespace Kustodya.ApplicationCore.Specifications.Concepto
{
    class ConceptoEmitidosporIdSpec : BaseSpec<ConceptoRehabilitacion>
    {
        public ConceptoEmitidosporIdSpec(int id)
                : base(u => u.PacienteporEmitirId == id)
        {
            AddInclude(c => c.Diagnosticos);
            AddInclude(c => c.Secuelas);
        }
    }
}