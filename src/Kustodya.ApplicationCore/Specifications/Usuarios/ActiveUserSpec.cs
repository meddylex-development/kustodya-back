using Kustodya.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Specifications
{
    public class ActiveUserSpec : BaseSpec<TblUsuarios>
    {
        public ActiveUserSpec(string email)
                : base(u => (u.TEmail == email && u.BActivo))
        {
            base.AddInclude(u => u.TblUsuariosPerfiles);
        }
        public ActiveUserSpec(int id)
                : base(u => (u.IIdusuario == id && u.BActivo))
        {
            base.AddInclude(u => u.TblUsuariosPerfiles);
        }
    }
}
