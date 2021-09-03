using Kustodya.ApplicationCore.Constants;
using Kustodya.ApplicationCore.Entities.Administracion;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Specifications.Administracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.Services
{
    public class EntidadService : IEntidadService
    {
        #region Dependency Injection
        private readonly IAsyncRepository<Entidad> _entidadRepo;
        #endregion
        public EntidadService(IAsyncRepository<Entidad> entidadRepo)
        {
            _entidadRepo = entidadRepo;
        }
        public async Task<int> TotalEntidades(string busqueda)
        {
            var spec = new EntidadPorNombreSpec(busqueda, 0, int.MaxValue);
            return await _entidadRepo.CountAsync(spec);
        }
        public async Task<IReadOnlyList<Entidad>> ObtenerEntidadesporFiltro(string busqueda, int? skip = null, int? take = null)
        {
            var spec = new EntidadPorNombreSpec(busqueda, skip, take);
            var requests = await _entidadRepo.ListAsync(spec);
            return requests;
        }
        public async Task<Entidad> ObtenerEntidadDetalle(int id)
        {
            var spec = new EntidadDetalleSpec(id);
            return await _entidadRepo.GetOneAsync(spec);
        }
        public async Task<bool> ValidarTipoIdNumIdyNombreCia(TipoIdentificacion tipoId, string numId, string nombreCompania)
        {
            var spec = new EntidadPorTipoidyNumIdyNombreCompaniaSpec(tipoId, numId, nombreCompania);
            var requests = await _entidadRepo.ListAsync(spec);
            if (requests.Count() == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task EstablecerContabilidadPorDefectoAsync(int entidadId, Guid contabilidadId)
        {
            var entidad = await _entidadRepo.GetByIdAsync(entidadId);
            entidad.EstablecerContabilidadPorDefecto(contabilidadId);
            await _entidadRepo.UpdateAsync(entidad);
        }

        // public async Task EstablecerClaseDocumentoPorDefectoAsync(int entidadId, Guid claseDocumentoId)
        // {
        //     var entidad = await _entidadRepo.GetByIdAsync(entidadId);
        //     entidad.EstablecerClaseDocumentoPorDefecto(claseDocumentoId);
        //     await _entidadRepo.UpdateAsync(entidad);
        // }
    }
}
