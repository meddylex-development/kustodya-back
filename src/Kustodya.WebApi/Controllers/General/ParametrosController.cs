using Kustodya.ApplicationCore.Interfaces.Configuracion.Parametros;
using Kustodya.ApplicationCore.Dtos.General;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParametrosController : ControllerBase
    {
        private readonly IParametrosService _ParametrosService;

        public ParametrosController(IParametrosService parametrosService)
        {
            _ParametrosService = parametrosService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ICollection<ParametrosModel>), 200)]
        public async Task<IActionResult> Get()
        {
            ICollection<ParametrosModel> lParametros = await _ParametrosService.GetAllParameters();
            return Ok(lParametros);
        }
    }
}