using Kustodya.ApplicationCore.Entities.Contabilidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Kustodya.ApplicationCore.Specifications.Contabilidades
{
    public class CentrosporCodigoDescripcionyContabilidadSpec : BaseSpec<CentroCosto>
    {
        public CentrosporCodigoDescripcionyContabilidadSpec(Expression<Func<CentroCosto, bool>> criteria, int? skip, int? take) : base(criteria)
        {
            if (skip.HasValue && take.HasValue)
                ApplyPaging(skip.Value, take.Value);
        }
        public CentrosporCodigoDescripcionyContabilidadSpec(string busqueda, int? skip, int? take)
                : this(u => (busqueda == null ? true : (u.Codigo.ToLower().Contains(busqueda.ToLower()) || u.Codigo.ToLower().Contains(busqueda.ToLower()))), skip, take)
        {
            AddInclude(c => c.Regional);
            AddInclude(c => c.Segmento);
            AddInclude(c => c.Contabilidad);
        }
    }
}
