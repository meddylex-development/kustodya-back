using System;
using System.Threading.Tasks;
using Kustodya.ApplicationCore.Interfaces.Incapacidades;
using Kustodya.ApplicationCore.Dtos.Incapacidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace Kustodya.WebApi.Controllers.Transcripciones
{
    [Route("api/[controller]")]
    [ApiController]
    public class OcrController : ControllerBase
    {

        #region DI
        public OcrController (
        ITranscripcionesService transcripcionService
        )
        {
            _transcripcionService = transcripcionService;
        }
    
        private readonly ITranscripcionesService _transcripcionService;

        #endregion

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> PostOCR([FromBody] TranscripcionModel transcripcionModel)
        {
            TranscripcionConfirmationModel model = await _transcripcionService.AddTranscriptionOnlyOcr(transcripcionModel).ConfigureAwait(false);
            return Ok(model);
        }

    }
}
