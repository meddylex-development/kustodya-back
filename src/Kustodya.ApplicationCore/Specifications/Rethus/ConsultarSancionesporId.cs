using Kustodya.ApplicationCore.Entities.Rethus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Specifications.Rethus
{
    public class ConsultarSancionesporId : BaseSpec<tblRethusData_Sanctions>
    {
        public ConsultarSancionesporId(int id) :
           base(t => t.iIDRethusQuery == id)
        {
        }
    }
}
