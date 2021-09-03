using Kustodya.ApplicationCore.Interfaces.Rehabilitacion;
using Kustodya.ApplicationCore.Dtos.Rehabilitacion;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Controllers;

namespace Kustodya.WebApi.Controllers.Incapacidades
{
    [Route("api/[controller]")]
    [ApiController]
    public class RehabilitacionController : BaseController
    {
        public IRehabilitacionService _rehabilitacionService;

        public RehabilitacionController(IRehabilitacionService rehabilitacionService)
        {
            _rehabilitacionService = rehabilitacionService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ConceptoRehabilitacionModel), 200)]
        public IActionResult Get(long id)
        {
            ConceptoRehabilitacionModel model = _rehabilitacionService.GetConceptoRehabilitacion(id);
            return Ok(model);
        }
    }
}