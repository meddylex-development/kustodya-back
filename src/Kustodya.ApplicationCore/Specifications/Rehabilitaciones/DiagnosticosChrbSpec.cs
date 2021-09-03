using Kustodya.ApplicationCore.Entities;
using System;

namespace Kustodya.ApplicationCore.Specifications.Rehabilitaciones
{
    public sealed class DiagnosticosChrbSpec:BaseSpec<TblCie10DiagnosticoIncapacidad>
    {
        public DiagnosticosChrbSpec(int iIDDiagnosticoIncapacidad)
                : base(u => u.IIddiagnosticoIncapacidad == iIDDiagnosticoIncapacidad)
        {
            base.AddInclude(d => d.IIddiagnosticoIncapacidadNavigation);
            base.AddInclude(d => d.IIdcie10Navigation);

            base.ApplyOrderByDescending(d => d.IIddiagnosticoIncapacidadNavigation.DtFechaCreacion);
        }
    }
}
