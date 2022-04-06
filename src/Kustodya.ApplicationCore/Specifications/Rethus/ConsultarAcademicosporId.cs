using Kustodya.ApplicationCore.Entities.Rethus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Specifications.Rethus
{
    public class ConsultarAcademicosporId : BaseSpec<tblRethusData_Academic>
    {
        public ConsultarAcademicosporId(int id) :
           base(t => t.iIDRethusQuery == id)
        {
        }
    }
}
