using Kustodya.ApplicationCore.Entities.Rethus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Specifications.Rethus
{
    public class RethusMainbyQuery : BaseSpec<tblRethusData_Main>
    {
        public RethusMainbyQuery(int queryId) :
           base(t => t.iIDRethusQuery == queryId)
        {
            ApplyOrderByDescending(c => c.iIDMainData);
        }
    }
}
