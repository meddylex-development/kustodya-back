using Kustodya.ApplicationCore.Entities.Rethus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Specifications.Rethus
{
    public class RethusMainporTipoidyNumId : BaseSpec<tblRethusData_Main>
    {
        public RethusMainporTipoidyNumId(string tipoId, string numId ) :
           base(t => t.tTipoIdentificacion == tipoId && t.tNrodentificacion == numId)
        {
        }
    }
}
