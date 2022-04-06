using Kustodya.ApplicationCore.Entities;

namespace Kustodya.ApplicationCore.Specifications
{
    public sealed class MultivaloresSpec : BaseSpec<TblMultivalores>
    {
        public MultivaloresSpec(int IIdsubtabla)
                : base(u => u.IIdsubtabla == IIdsubtabla)
        {
        }

        public MultivaloresSpec(long IIdMultivalor)
                : base(u => u.IIdmultivalor == IIdMultivalor)
        {
        }
    }
}