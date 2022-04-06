using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kustodya.WebApi.Models.Rehabilitaciones;
using Kustodya.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kustodya.WebApi.Controllers.Rehabilitaciones
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class RehabilitacionesController : ControllerBase
    {
        #region Dependency Injection
        public RehabilitacionesController(
            IDiagnosticoViewModelService diagnosticoService
            )
        {
            _diagnosticoService = diagnosticoService;
        }

        private readonly IDiagnosticoViewModelService _diagnosticoService;

        #endregion

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get(int iIDDiagnosticoIncapacidad)
        {
            IReadOnlyList<DiagnosticoChrbModel> result = await _diagnosticoService.CreateViewModel(iIDDiagnosticoIncapacidad).ConfigureAwait(false);
            return Ok(result);
        }
    }
}