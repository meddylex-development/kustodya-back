using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kustodya.WebApi.Models;
using Kustodya.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kustodya.WebApi.Controllers.Rehabilitaciones
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoSecuelasController : ControllerBase
    {
        #region Dependency Injection
        public TipoSecuelasController(
            ITipoSecuelaViewModelService service
            )
        {
            _service = service;
        }

        private readonly ITipoSecuelaViewModelService _service;

        #endregion

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<EnumValueModel> result = _service.CreateViewModel();
            return Ok(result);
        }
    }
}