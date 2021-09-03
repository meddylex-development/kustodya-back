using System;

namespace Kustodya.ApplicationCore.Specifications.Contabilidad
{
    public class MovimientosPorDepuracionContableyBusqueda : MovimientosporCodigoDescripcionTerceroyReferenciaSpec
    {
        public MovimientosPorDepuracionContableyBusqueda(int entidadId, Guid depuracionContableId, string busqueda, int? pagina = null)
            : base(entidadId, busqueda, m => m.DepuracionContableId == depuracionContableId && m.Eliminado == false, pagina)
        {

        }

    }
}