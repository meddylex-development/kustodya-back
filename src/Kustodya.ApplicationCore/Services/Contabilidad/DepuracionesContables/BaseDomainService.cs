using System.Threading.Tasks;
using Kustodya.ApplicationCore.DTOs;
using Kustodya.ApplicationCore.Entities.Contabilidades;
using Kustodya.ApplicationCore.Interfaces;
using System;
using Kustodya.ApplicationCore.Specifications;

namespace Kustodya.ApplicationCore.Services
{
    public abstract class BaseDomainService<TEntity, TInputModel, TAsyncRepository> : IDomainService<TEntity, TInputModel>
        where TEntity : BaseEntity
        where TInputModel : DTOBase
        where TAsyncRepository : IAsyncRepository<TEntity>
    {
        protected TAsyncRepository _repo;

        public BaseDomainService(TAsyncRepository repo)
        {
            _repo = repo;
        }

        public virtual async Task EliminarAsync(Guid id, int entidadId)
        {
            var entidad = await BuscarPorIdYEntidad(id, entidadId);
            entidad.Eliminar();
            await _repo.UpdateAsync(entidad);
        }

        public abstract Task<TEntity> CrearAsync(int usuarioId, int entidadId, Guid entidadPadreId, TInputModel inputModel);

        public abstract Task<TEntity> ActualizarAsync(int entidadId, Guid id, TInputModel inputModel, int userId);

        protected virtual async Task<TEntity> BuscarPorIdYEntidad(Guid id, int entidadId)
        {
            // Buscar por Id y Entidad
            var spec = new NoEliminadaPaginadaPorEntidadYIdSpec<TEntity>(id, entidadId);
            var entidad = await _repo.GetOneAsync(spec);
            if (entidad is null) throw new EntidadNoExisteException(nameof(TEntity), id.ToString());
            return entidad;
        }

        protected void AsegurarNoNulo(IBaseEntity entidad)
        {
            if (entidad is null)
                throw new EntidadNoExisteException(typeof(TEntity).Name, entidad?.Id.ToString());
        }

        protected async Task<IBaseEntity> ConsultarYAsegurarEntidad(Guid entidadPadre, int entidadId, IAsyncContabilidadRepository<IBaseEntity> repoEntidadHija)
        {
            var spec = new NoEliminadaPaginadaPorEntidadYIdSpec<IBaseEntity>(entidadPadre, entidadId);

            var entidad = await repoEntidadHija.GetOneAsync(spec);
            AsegurarNoNulo(entidad);

            return entidad;
        }
    }
}