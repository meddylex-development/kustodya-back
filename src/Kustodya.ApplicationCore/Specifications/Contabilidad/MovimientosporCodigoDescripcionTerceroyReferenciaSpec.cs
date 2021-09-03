using Kustodya.ApplicationCore.Entities.Contabilidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Kustodya.ApplicationCore.Helpers;

namespace Kustodya.ApplicationCore.Specifications.Contabilidad
{
    public class MovimientosporCodigoDescripcionTerceroyReferenciaSpec : NoEliminadaPaginadaPorEntidadYIdSpec<Movimiento>
    {
        protected MovimientosporCodigoDescripcionTerceroyReferenciaSpec(int entidadId, string busqueda, Expression<Func<Movimiento, bool>> criteria = null, int? pagina = 1)
                : base(
                    entidadId,
                    pagina,
                    d => string.IsNullOrWhiteSpace(busqueda) ||
                        busqueda.ToLower() == d.CodigoContable.ToString() 
                        || busqueda.ToLower() == d.DescripcionMovimiento.ToString() 
                        || busqueda.ToLower() == d.NitTercero.ToLower() 
                        || busqueda.ToLower() == d.Referencia.ToLower())
        {
            AddIncludes(c => c.Include(c => c.DepuracionContable)
            .ThenInclude(c => c.Contabilidad).ThenInclude(c => c.Entidad));
        }

        public MovimientosporCodigoDescripcionTerceroyReferenciaSpec(int entidadId, string busqueda, int? pagina = 1)
                : this(
                    entidadId, busqueda, null, pagina)
        {
            AddIncludes(c => c.Include(c => c.DepuracionContable)
            .ThenInclude(c => c.Contabilidad).ThenInclude(c => c.Entidad));
        }
    }
}