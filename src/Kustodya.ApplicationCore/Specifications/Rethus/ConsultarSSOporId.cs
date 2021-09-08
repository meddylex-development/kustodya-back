using Kustodya.ApplicationCore.Entities.Rethus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Specifications.Rethus
{
    public class ConsultarSSOporId : BaseSpec<tblRethusData_SSO>
    {
        public ConsultarSSOporId(int id) :
           base(t => t.iIDRethusQuery == id)
        {
        }
    }
}
