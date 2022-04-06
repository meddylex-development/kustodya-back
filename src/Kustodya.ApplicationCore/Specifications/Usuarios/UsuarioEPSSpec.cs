using Kustodya.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Specifications
{
    public sealed class UsuarioEPSSpec : BaseSpec<UsuarioEPS>
    {
        public UsuarioEPSSpec(int IdUser)
                : base(u => (u.TblUsuariosId == IdUser))
        {
            base.AddInclude(u => u.Eps);
        }
        public UsuarioEPSSpec(int IdUser, long eps)
                : base(u => (u.TblUsuariosId == IdUser && u.TblEpsId == eps))
        {
            
        }
    }
}