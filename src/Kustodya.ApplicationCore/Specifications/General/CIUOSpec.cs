using Kustodya.ApplicationCore.Entities;

namespace Kustodya.ApplicationCore.Specifications.General
{
    public class CIUOSpec : BaseSpec<TblCiuo08>
    {
        public CIUOSpec(short id) : base(u => u.IId == id)
        {
        }
    }
}