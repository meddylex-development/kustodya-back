using Kustodya.ApplicationCore.Entities;
using System;

namespace Kustodya.ApplicationCore.Specifications.Incapacidades
{
    public sealed class DiagnosticoIncapacidadSpec : BaseSpec<TblDiagnosticosIncapacidades>
    {
        public DiagnosticoIncapacidadSpec(int iIDPaciente)
                : base(u => u.IIdpaciente == iIDPaciente)
        {
            base.AddInclude(d => ((TblCie10DiagnosticoIncapacidad)d.TblCie10DiagnosticoIncapacidad).IIdcie10Navigation);
            base.AddInclude(d => d.IIdipsNavigation.IIdubicacionNavigation);
            base.AddInclude(d => d.IIdpresuntoOrigenIncapacidadNavigation);
            base.AddInclude(d => d.IIdorigenCalificadoIncapacidadNavigation);

            base.ApplyOrderByDescending(d => d.DtFechaCreacion);
        }

        public DiagnosticoIncapacidadSpec(int iIDPaciente, DateTime dtFechaInicial)
                : base(u => u.IIdpaciente == iIDPaciente && u.DtFechaFin >= dtFechaInicial)
        {
            base.AddInclude(d => ((TblCie10DiagnosticoIncapacidad)d.TblCie10DiagnosticoIncapacidad).IIdcie10Navigation.TblCodigosCorrelacion);
            base.ApplyOrderByDescending(d => d.DtFechaCreacion);
        }

        public DiagnosticoIncapacidadSpec(Guid UiCodigoDiagnostico)
                : base(u => u.UiCodigoDiagnostico == UiCodigoDiagnostico)
        {
            base.AddInclude(d => ((TblCie10DiagnosticoIncapacidad)d.TblCie10DiagnosticoIncapacidad).IIdcie10Navigation);
            base.AddInclude(d => d.IIdipsNavigation.IIdubicacionNavigation);
            base.AddInclude(d => d.IIdpresuntoOrigenIncapacidadNavigation);
            base.AddInclude(d => d.IIdorigenCalificadoIncapacidadNavigation);

            base.ApplyOrderByDescending(d => d.DtFechaCreacion);
        }
    }
}