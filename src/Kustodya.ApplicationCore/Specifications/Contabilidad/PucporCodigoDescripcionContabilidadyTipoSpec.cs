using Kustodya.ApplicationCore.Entities.Contabilidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using static Kustodya.ApplicationCore.Entities.Contabilidades.Puc;

namespace Kustodya.ApplicationCore.Specifications.Contabilidades
{
    public class PucporCodigoDescripcionContabilidadyTipoSpec : BaseSpec<Puc>
    {
        public PucporCodigoDescripcionContabilidadyTipoSpec(Expression<Func<Puc, bool>> criteria, int? skip, int? take) : base(criteria)
        {
            if (skip.HasValue && take.HasValue)
                ApplyPaging(skip.Value, take.Value);
        }
        public PucporCodigoDescripcionContabilidadyTipoSpec(string busqueda, string contabilidad, TiposContabilidad? tipoContabilidad, int? skip, int? take)
                : this(u => (busqueda == null ? true : (u.Codigo.ToLower().Contains(busqueda.ToLower()) || u.Descripcion.ToLower().Contains(busqueda.ToLower()))) &&
                (contabilidad != null ? (u.Contabilidad.Codigo == contabilidad || u.Contabilidad.Descripcion == contabilidad) : true) &&
                (tipoContabilidad != null ? (u.TipoContabilidad == tipoContabilidad) : true), skip, take)
        {
            AddInclude(c => c.Contabilidad);
        }
    }
}
