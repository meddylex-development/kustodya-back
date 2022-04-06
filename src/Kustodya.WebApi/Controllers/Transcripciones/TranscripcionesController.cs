using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Kustodya.ApplicationCore.Interfaces.Incapacidades;
using Kustodya.ApplicationCore.Dtos.Incapacidades;
using Kustodya.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Auth;
using Microsoft.Azure.Storage.Blob;
using WebApi.Controllers;

namespace Kustodya.WebApi.Controllers.Transcripciones
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class TranscripcionesController : BaseController
    {
        #region Dependency Injection
        public TranscripcionesController(
            IImageService imageService,
            ITranscripcionesService transcripcionService
            )
        {
            _imageService = imageService;
            _transcripcionService = transcripcionService;
        }

        private readonly IImageService _imageService;
        private readonly ITranscripcionesService _transcripcionService;

        #endregion

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TranscripcionModel transcripcionModel)
        {
            TranscripcionConfirmationModel model = await _transcripcionService.AddTranscription(transcripcionModel).ConfigureAwait(false);
            return Ok(model);
        }

       
    }
}
