using Kustodya.ApplicationCore.Entities;
using System;

namespace Kustodya.ApplicationCore.Specifications.Incapacidades
{
    public sealed class Cie10DiagnosticoIncapacidadSpec : BaseSpec<TblCie10DiagnosticoIncapacidad>
    {
        public Cie10DiagnosticoIncapacidadSpec(int IIdpaciente, int IIdtipoCie, DateTime fechaInicial)
                : base(u => u.IIdcie10Navigation.IIdtipoCie == IIdtipoCie && u.IIddiagnosticoIncapacidadNavigation.IIdpaciente == IIdpaciente
                && u.IIddiagnosticoIncapacidadNavigation.DtFechaCreacion >= fechaInicial)
        {
            base.AddInclude(d => d.IIdcie10Navigation);
            base.AddInclude(d => d.IIddiagnosticoIncapacidadNavigation);
        }
    }
}