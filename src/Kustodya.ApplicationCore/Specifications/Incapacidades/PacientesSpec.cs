using Kustodya.ApplicationCore.Entities;

namespace Kustodya.ApplicationCore.Specifications.Incapacidades
{
    public sealed class PacientesSpec : BaseSpec<TblPacientes>
    {
        public PacientesSpec(int IIdpaciente)
                : base(u => u.IIdpaciente == IIdpaciente)
        {
            base.AddInclude(d => d.IIdtipoDocNavigation);
            base.AddInclude(d => d.IIdepsNavigation);
            base.AddInclude(d => d.IIdgeneroNavigation);
            base.AddInclude(d => d.IIdregimenAfiliacionNavigation);
            base.AddInclude(d => d.IIdtipoAfiliacionNavigation);
        }

        public PacientesSpec(int IIdTipoIdentificacion, string tNumDoc)
                : base(u => u.IIdtipoDoc == IIdTipoIdentificacion && u.TNumeroDocumento == tNumDoc)
        {
            base.AddInclude(d => d.IIdtipoDocNavigation);
            base.AddInclude(d => d.IIdepsNavigation);
            base.AddInclude(d => d.IIdgeneroNavigation);
            base.AddInclude(d => d.IIdregimenAfiliacionNavigation);
            base.AddInclude(d => d.IIdtipoAfiliacionNavigation);
            base.AddInclude(d => d.IIdestadoAfiliacionNavigation);
        }
    }
}