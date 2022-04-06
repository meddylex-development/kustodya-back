using Kustodya.ApplicationCore.Entities.Contabilidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Kustodya.ApplicationCore.Specifications.Contabilidades
{
    public class PlantillaporNombreyTipoSpec : BaseSpec<Plantilla>
    {
        public PlantillaporNombreyTipoSpec(Expression<Func<Plantilla, bool>> criteria, int? skip, int? take) : base(criteria)
        {
            if (skip.HasValue && take.HasValue)
                ApplyPaging(skip.Value, take.Value);
        }
        public PlantillaporNombreyTipoSpec(int entidadId, string busqueda, Plantilla.TiposPlantillaContable? tipoPlantilla, int? skip, int? take)
                : this(u => u.EntidadId == entidadId &&
                tipoPlantilla == null ? true : u.TipoPlantilla == tipoPlantilla &&
                (busqueda == null ? true : u.Texto.ToLower().Contains(busqueda.ToLower())), skip, take)
        {
        }
    }
}
