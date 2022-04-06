using Kustodya.ApplicationCore.Entities.Concepto;
using System;
using System.Collections.Generic;
using System.Text;
using Kustodya.ApplicationCore.Helpers;

namespace Kustodya.ApplicationCore.Specifications.Incapacidades
{
    public class PacientesPorEmitirPorIdSpec : BaseSpec<PacientesPorEmitir>
    {
        public PacientesPorEmitirPorIdSpec(int pacientePorEmitirId)
                : base(u => u.Id == pacientePorEmitirId)
        {
            //AddInclude(c => c.Paciente)
            AddIncludes(i => i.Include(c => c.Paciente)
                .ThenInclude(c => c.IIdtipoDocNavigation));
            AddIncludes(i => i.Include(c => c.Paciente)
                .ThenInclude(c => c.IIdarlNavigation));
            AddIncludes(i => i.Include(c => c.Paciente)
                .ThenInclude(c => c.IIdarlNavigation));
            AddIncludes(i => i.Include(c => c.Paciente)
                .ThenInclude(c => c.IIdafpNavigation));
            AddIncludes(i => i.Include(c => c.Paciente)
                .ThenInclude(c => c.IIdepsNavigation));

        }
    }
}