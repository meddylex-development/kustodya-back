using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Interfaces.Incapacidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kustodya.WebApi.Controllers.Incapacidades
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalServicesController : ControllerBase
    {

        private readonly IPacienteService _pacienteService;


        public ExternalServicesController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        [HttpGet("pacientes/{tNumeroDocumento}/tipodocumento/{iIdTipoDocumento}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> ValidarPaciente(int iIdTipoDocumento, string tNumeroDocumento)
        {
            
            TblPacientes paciente = await _pacienteService.ValidarPacientePorNumeroDocumento(iIdTipoDocumento, tNumeroDocumento).ConfigureAwait(false);
            if (paciente == null)
            {
                return NoContent();
            }
            return Ok();
        }
    }
}
