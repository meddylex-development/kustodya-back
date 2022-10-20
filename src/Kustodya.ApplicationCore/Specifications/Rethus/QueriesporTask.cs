using Kustodya.ApplicationCore.Entities.Rethus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Specifications.Rethus
{
    public class QueriesporTask : BaseSpec<tblRethusQuerys>
    {
        public QueriesporTask(int taskid) :
           base(t => t.iIDTask == taskid)
        {
        }
    }
}
