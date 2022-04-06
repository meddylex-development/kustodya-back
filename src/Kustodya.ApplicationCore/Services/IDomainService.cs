using System;
using System.Threading.Tasks;
using Kustodya.ApplicationCore.DTOs;
using Kustodya.ApplicationCore.Entities.Contabilidades;
using System;

namespace Kustodya.ApplicationCore.Services
{
    public interface IDomainService<TEntity, TInputModel> 
        where TEntity : BaseEntity 
        where TInputModel : DTOBase
    {
        Task<TEntity> CrearAsync(int usuarioId, int entidadId, Guid entidadPadreId, TInputModel inputModel);
        Task<TEntity> ActualizarAsync(int entidadId, Guid id, TInputModel inputModel, int userId);
        Task EliminarAsync(Guid id, int entidadId);
    }
}