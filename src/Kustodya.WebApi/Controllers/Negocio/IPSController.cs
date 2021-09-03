using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Interfaces.Negocio;
using Kustodya.ApplicationCore.Dtos.Negocio;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Controllers;

namespace Kustodya.WebApi.Controllers.Negocio
{
    [Route("api/[controller]")]
    [ApiController]
    public class IPSController : BaseController
    {
        private readonly IIPSService _ipsService;
        private readonly ILoggerService<IPSController> _logger;

        public IPSController(IIPSService ipsService, ILoggerService<IPSController> logger)
        {
            _ipsService = ipsService;
            _logger = logger;
        }

        [HttpGet("{IdIps}", Name = "GetIPSById")]
        [ProducesResponseType(typeof(IPSModel), 200)]
        public async Task<IActionResult> GetIPSById(int IdIps)
        {
            IPSModel ips = await _ipsService.GetIPSById(IdIps).ConfigureAwait(false);

            return Ok(ips);
        }
    }
}