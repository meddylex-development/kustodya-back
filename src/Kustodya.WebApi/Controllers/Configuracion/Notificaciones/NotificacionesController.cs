//using Kustodya.BusinessLogic.Interfaces.Configuracion.Notificaciones;
using Kustodya.ApplicationCore.Interfaces.Configuracion.Notificaciones;
using Kustodya.ApplicationCore.Dtos.Configuracion.Notificaciones;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Configuracion.Notificaciones
{
    [Route("api/configuracion/[controller]")]
    [ApiController]
    public class NotificacionesController : ControllerBase
    {
        private readonly INotificacionService _notificacionService;

        public NotificacionesController(INotificacionService notificacionService)
        {
            _notificacionService = notificacionService;
        }

        [HttpDelete("{idIps}/{idUsuarioNotificacion}")]
        [ProducesResponseType(typeof(void), 200)]
        public async Task<IActionResult> Delete(int idIps, int idUsuarioNotificacion)
        {
            try
            {
                await _notificacionService.RemoveUserFromEmailNotificationsByIdEmpresaUsuario(idIps, idUsuarioNotificacion);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Notificaciones/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ICollection<UsuariosNotificacionesModel>), 200)]
        public async Task<ICollection<UsuariosNotificacionesModel>> Get(int id)
        {
            ICollection<UsuariosNotificacionesModel> lUsuarios = await _notificacionService.GetEmailConfigurationByIdEmpresa(id);
            return lUsuarios;
        }

        // POST: api/Notificaciones
        [HttpPost("{value}")]
        [ProducesResponseType(typeof(void), 200)]
        public async Task<IActionResult> Post([FromBody] UsuariosNotificacionesModel value)
        {
            await _notificacionService.AddEmailConfigurationByIdEmpresa(value);
            return Ok();
        }

        // PUT: api/Notificaciones/5
        [HttpPut("{idIps}/{idUsuarioNotificacion}")]
        [ProducesResponseType(typeof(Task<IActionResult>), 200)]
        public async Task<IActionResult> Put([FromRoute]int idIps, [FromRoute]int idUsuarioNotificacion, [FromBody] UsuariosNotificacionesModel model)
        {
            bool b = await _notificacionService.UpdateUsuarioEmpresaNotificacion(model);
            return Ok();
        }
    }
}