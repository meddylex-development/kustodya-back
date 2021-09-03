using Kustodya.ApplicationCore.Entities.Contabilidades;
using System;
using Kustodya.ApplicationCore.Helpers;

namespace Kustodya.ApplicationCore.Specifications.Contabilidades
{
    public class MovimientoNoEliminadoConEntidadYContabilidad : NoEliminadaPaginadaPorEntidadYIdSpec<Movimiento>
    {
        public MovimientoNoEliminadoConEntidadYContabilidad(int entidadId, Guid contabilidadId, Guid id, int? pagina = null)
        : base(
            id,
            entidadId,
            pagina,
            m => 
            m.DepuracionContable.ContabilidadId == contabilidadId 
            && m.DepuracionContable.Contabilidad.EntidadId == entidadId)
        {                
            AddIncludes(m => m.Include(m => m.DepuracionContable)
                .ThenInclude(d => d.Contabilidad));
        }
    }
}