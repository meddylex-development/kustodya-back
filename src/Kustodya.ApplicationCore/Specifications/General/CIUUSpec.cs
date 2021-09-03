using Kustodya.ApplicationCore.Entities;

namespace Kustodya.ApplicationCore.Specifications.General
{
    public class CIUUSpec : BaseSpec<TblCiiu>
    {
        public CIUUSpec(short id) : base(u => u.IId == id)
        {
        }
    }
}