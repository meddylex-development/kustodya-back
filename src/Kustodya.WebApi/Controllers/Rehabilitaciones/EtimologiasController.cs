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
    public class EtimologiasController : ControllerBase
    {
        #region Dependency Injection
        public EtimologiasController(
            IEtimologiaViewModelService etimologiaService
            )
        {
            _etimologiaService = etimologiaService;
        }

        private readonly IEtimologiaViewModelService _etimologiaService;

        #endregion

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            List<EnumValueModel> result = _etimologiaService.CreateViewModel();
            return Ok(result);
        }
    }
}