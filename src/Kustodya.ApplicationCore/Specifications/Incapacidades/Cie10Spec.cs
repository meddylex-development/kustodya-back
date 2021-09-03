using Kustodya.ApplicationCore.Entities;

namespace Kustodya.ApplicationCore.Specifications.Incapacidades
{
    public sealed class Cie10Spec : BaseSpec<TblCie10>
    {
        public Cie10Spec(int IIdcie10)
                : base(u => u.IIdcie10 == IIdcie10)
        {
            base.AddInclude(d => d.TblCodigosCorrelacion);
        }

        public Cie10Spec(int IIdtipoCie, bool bit)
                : base(u => u.IIdtipoCie == IIdtipoCie)
        {
        }

        public Cie10Spec(string tCie10)
                : base(u => u.TCie10 == tCie10)
        {
            base.AddInclude(d => d.TblCodigosCorrelacion);
        }
    }
}