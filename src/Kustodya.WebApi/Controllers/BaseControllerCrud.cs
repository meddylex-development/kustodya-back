using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc;
using Kustodya.ApplicationCore.DTOs;
using Kustodya.ApplicationCore.Services;

namespace Kustodya.WebApi.Controllers
{
    [Route("api/[controller]")]
    public abstract class BaseControllerCrud<TInputModel, TEntity> : BaseController
        where TInputModel : DTOBase
        where TEntity : ApplicationCore.Entities.Contabilidades.BaseEntity
    {
        private readonly IDomainService<TEntity, TInputModel> _domainService;

        public BaseControllerCrud(IDomainService<TEntity, TInputModel> domainService)
        {
            _domainService = domainService;
        }


        [HttpGet("/api/[Controller]/{id:guid}")]
        public abstract Task<IActionResult> GetOne(Guid id);

        [HttpGet]
        public abstract Task<IActionResult> GetList(string busqueda, int pagina = 1);

        [HttpGet("/api/[Controller]")]
        public abstract Task<IActionResult> GetList(Guid padreId, string busqueda, int pagina = 1);

        [HttpPost]
        public virtual async Task<IActionResult> Post(Guid padreId, TInputModel inputModel)
        {
            try
            {
                GetUserId(out int usuarioId);
                GetEntidadId(out int entidadId);
                var entidad = await _domainService.CrearAsync(usuarioId, entidadId, padreId, inputModel);
                // var outputModel = _depuracionOutputModelService.GetOutputModel(entidad);
                return CreatedAtAction(nameof(GetOne), new { id = entidad.Id });
            }
            catch (EntidadNoExisteException ex)
            {
                return NotFound(ex.Message);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPut("{id:guid}")]
        public virtual async Task<IActionResult> Put(Guid id, TInputModel inputModel)
        {
            GetEntidadId(out int entidadId);
            GetUserId(out int userId);
            try
            {
                var entidad = await _domainService.ActualizarAsync(entidadId, id, inputModel, userId);
                AsegurarNoNulo(entidad);
            }
            catch (EntidadNoExisteException ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }

        [HttpDelete("/api/[Controller]/{id:guid}")]
        public virtual async Task<IActionResult> Delete(Guid id, int entidadId)
        {
            try
            {
                await _domainService.EliminarAsync(id, entidadId);

                return NoContent();
            }
            catch (EntidadNoExisteException ex)
            {
                return NotFound(ex.Message);
            }
        }

        protected void AsegurarNoNulo(TEntity entidad)
        {
            if (entidad is null)
                throw new EntidadNoExisteException(nameof(entidad), entidad.Id.ToString());
        }
    }

}