using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
using System.Collections.Generic;
using Kustodya.ApplicationCore.Entities.Contabilidades;
using Kustodya.ApplicationCore.Services;

namespace Kustodya.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    [ProducesResponseType(typeof(ModelStateDictionary), 400)]
    [ProducesResponseType(500)]
    //[Produces("application/json"), Consumes("application/json")]
    public class BaseController : ControllerBase
    {
        [NonAction]
        public bool GetUserId(out int userId)
        {
            var userIdClaim = HttpContext.User.Claims
                .Where(c => c.Type == "UserId").FirstOrDefault()?.Value;
            bool valid = int.TryParse(userIdClaim, out userId);

            return valid;
        }

        [NonAction]
        public bool GetEntidadId(out int entidadId)
        {
            var entidadIdClaim = HttpContext.User.Claims
                .Where(c => c.Type == "Entidad").FirstOrDefault()?.Value;
            bool valid = int.TryParse(entidadIdClaim.Split(",").First(), out entidadId);

            return valid;
        }
        protected void AsegurarNoNulo(IBaseEntity entidad)
        {
            if (entidad is null)
            {
                throw new EntidadNoExisteException(nameof(entidad));
            }
        }
    }
}