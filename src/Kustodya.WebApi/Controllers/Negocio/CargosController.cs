using Kustodya.ApplicationCore.Interfaces.Negocio;
using Kustodya.ApplicationCore.Dtos.Negocio.RH;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Controllers;

namespace Kustodya.WebApi.Controllers.Negocio
{
    [Produces("application/json")]
    [Route("api/rh/[controller]")]
    [ApiController]
    public class CargosController : BaseController
    {
        private readonly ICargosService _cargosService;

        public CargosController(ICargosService cargosService)
        {
            _cargosService = cargosService;
        }

        // GET: api/Medicos
        [HttpGet("medicos/{cedula}")]
        public async Task<IActionResult> Get(long cedula)
        {
            var medico = await _cargosService.GetMedicoByCedula(cedula).ConfigureAwait(false);
            return Ok(medico);
        }

        // GET: api/Medicos/5
        [HttpGet("nombre/{id}")]
        public async Task<IActionResult> Get(string name)
        {
            var lMedicos = await _cargosService.GetMedicosByName(name).ConfigureAwait(false);
            return Ok(lMedicos);
        }

        /// <summary>
        /// </summary>
        /// <param name="medico">
        /// Objeto de tipo empleadoModel el cual contiene la informacion del medico.
        /// </param>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="500">
        /// Si existe algun error y no pudo ser creado el medico en la base de datos.
        /// </response>
        [HttpPost("medicos")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post(EmpleadosModel medico)
        {
            EmpleadosModel creado = medico;//await _cargosService.AddMedico(medico).ConfigureAwait(false);
            creado.IIdEmpleado = 2;
            return Ok(creado);
        }
    }
}