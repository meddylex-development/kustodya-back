using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Interfaces.Administrativo;
using Kustodya.WebApi.Controllers.Administrativo.Auditoria.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kustodya.WebApi.Controllers.Administrativo.Auditoria
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditoriaController : BaseController
    {
        #region Dependency Injection
        private readonly IAuditoriaService _repoAuditoriaService;
        #endregion

        public AuditoriaController(IAuditoriaService repoAuditoriaService)
        {
            _repoAuditoriaService = repoAuditoriaService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(AuditoriaInputModel auditoriaInputModel)
        {
            GetUserId(out int userId);
            GetEntidadId(out int entidadId);
            ApplicationCore.Entities.Administracion.Auditoria A = new ApplicationCore.Entities.Administracion.Auditoria
            {
                UsuarioId = userId,
                Fecha = DateTime.Now,
                Accion = auditoriaInputModel.Accion,
                Descripcion = auditoriaInputModel.Descripcion,
                EntidadId = entidadId
            };
            var auditoria = await _repoAuditoriaService.CrearAsync(A);
            //return CreatedAtAction(nameof(ObtenerDepuracion), new { id = auditoria.Id }, outputModel);
            return Ok(auditoria);
        }
    }
}