using System;
using Kustodya.ApplicationCore.Entities.Contabilidades;

namespace Kustodya.ApplicationCore.Specifications.Contabilidades
{
    public class ContabilidadConEntidadSpec : BaseSpec<Entities.Contabilidades.Contabilidad>
    {
        public ContabilidadConEntidadSpec(Guid id, int entidadId, int? skip = 0, int? take = 10)
            : base(c => c.Eliminado == false && c.Id == id && c.EntidadId == entidadId)
        {
            if (skip.HasValue || take.HasValue)
                ApplyPaging(skip.Value, take.Value);
            AddInclude(c => c.Entidad);
        }
    }
}