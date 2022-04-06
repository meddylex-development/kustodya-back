using Kustodya.ApplicationCore.Entities.Contabilidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Kustodya.ApplicationCore.Specifications.Contabilidades
{
    public class CentroCostoPorCodigoSpec : BaseSpec<CentroCosto>
    {
        public CentroCostoPorCodigoSpec(Expression<Func<CentroCosto, bool>> criteria, int? skip, int? take) : base(criteria)
        {
            if (skip.HasValue && take.HasValue)
                ApplyPaging(skip.Value, take.Value);
        }
        public CentroCostoPorCodigoSpec(string busqueda, int? skip, int? take)
                : this(u => u.Eliminado == false && busqueda == null ? true :  u.Codigo.Contains(busqueda) , skip, take)
        {
            // AddInclude(c => c.Segmento);
            // AddInclude(c => c.Regional);
        }
    }
}
