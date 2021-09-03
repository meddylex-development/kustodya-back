using Kustodya.ApplicationCore.Specifications;
using Kustodya.ApplicationCore.Entities;

namespace Kustodya.Entities.Specifications.General
{
    public sealed class DaneSpec : BaseSpec<TblDivipola>
    {
        public DaneSpec(int idDane) : base(u => u.Iddivipola == idDane)
        {
        }
    }
}