using Kustodya.ApplicationCore.Entities.Rethus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Specifications.Rethus
{
    public class QueriesporEntidadyTipoCargue : BaseSpec<tblRethusQuerys>
    {
        public QueriesporEntidadyTipoCargue(int entidadId) :
           base(t => t.iIDEntidad == entidadId)
        {
        }
    }
}