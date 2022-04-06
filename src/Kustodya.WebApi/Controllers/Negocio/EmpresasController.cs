using AutoMapper;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Dtos.General;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Controllers;

namespace Kustodya.WebApi.Controllers.Negocio
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : BaseController
    {
        private readonly IEmpresaService _empresasService;
        private readonly IMapper _mapper;

        public EmpresasController(
            IMapper mapper,
            IEmpresaService empresasService
            )
        {
            _mapper = mapper;
            _empresasService = empresasService;
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(long id)
        {
            var empresa = await _empresasService.GetEmpresaById(id);
            return Ok(empresa);
        }

        [HttpGet("/name/{name}", Name = "GetEmpresaByName")]
        public async Task<IActionResult> GetEmpresaByName(string name)
        {
            var model = await _empresasService.GetEmpresasByName(name);
            return Ok(model);
        }

        [HttpGet("/nit/{nit}", Name = "GetEmpresaByNIT")]
        public async Task<IActionResult> GetEmpresaByNIT(string nit)
        {
            EmpresaTercerosModel model = await _empresasService.GetEmpresasByNIT(nit);
            return Ok(model);
        }
    }
}