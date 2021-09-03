using Kustodya.ApplicationCore.Constants;
using Kustodya.ApplicationCore.Entities.Administracion;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.Interfaces
{
    public interface IEntidadService
    {
        Task<int> TotalEntidades(string busqueda);
        Task<IReadOnlyList<Entidad>> ObtenerEntidadesporFiltro(string busqueda, int? skip = null, int? take = null);
        Task<Entidad> ObtenerEntidadDetalle(int entidadid);
        Task<bool> ValidarTipoIdNumIdyNombreCia(TipoIdentificacion tipoId, string numId, string nombreCompania);
        Task EstablecerContabilidadPorDefectoAsync(int entidadId, Guid contabilidadId);
    }
}
