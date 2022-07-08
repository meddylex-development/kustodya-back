using AutoMapper;
using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Interfaces.Negocio;
using Kustodya.ApplicationCore.Dtos.Negocio;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kustodya.ApplicationCore.DTOs.Negocio;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;

namespace Kustodya.WebApi.Controllers.Negocio
{
    [Route("api/[controller]")]
    [ApiController]
    public class EPSController : BaseController
    {
        private readonly IEPSService _epsService;
        private readonly IIPSService _ipsService;
        private readonly ILoggerService<EPSController> _logger;
        private readonly IMapper _mapper;


        public EPSController(IEPSService epsService, IIPSService ipsService, IMapper mapper, ILoggerService<EPSController> logger)
        {
            _epsService = epsService;
            _mapper = mapper;
            _logger = logger;
            _ipsService = ipsService;

        }
 
        [HttpGet]
        [ProducesResponseType(typeof(List<EpsModel>), 200)]
        public async Task<IActionResult> GetAllEPS()
        {
            IReadOnlyList<EpsModel> listEps = await _epsService.GetAllEPS();

            if (!listEps.Any())
            {
                return Ok();
            }
            return Ok(listEps);
        }

        [HttpGet("{IIdeps}/ips", Name = "GetAllIPSByEps")]
        [ProducesResponseType(typeof(List<IPSModel>), 200)]
        public async Task<IActionResult> GetAllIPSByEps(int IIdeps)
        {
            IReadOnlyList<IPSModel> listIPS = await _ipsService.GetAllIPSByEps(IIdeps);

            if (!listIPS.Any())
            {
                return Ok();
            }

            return Ok(listIPS);
        }

        [HttpGet("{IdUser}")]
        public async Task<IActionResult> GetAllEPSByUser(int IdUser)
        {
            IReadOnlyList<UsuarioEPS> listUsuarioEPS = await _epsService.GetAllEPSByUser(IdUser);

            if (!listUsuarioEPS.Any())
            {
                return Ok();
            }
            List<UsuarioEPSModel> listaUsuEps = new List<UsuarioEPSModel>();
            foreach (UsuarioEPS item in listUsuarioEPS)
            {
                UsuarioEPSModel usueps = new UsuarioEPSModel
                {
                    UsuarioId = item.TblUsuariosId,
                    EpsId = item.TblEpsId,
                    IpsId = item.TblIpsId
                };
                listaUsuEps.Add(usueps);
            }
            return Ok(listaUsuEps);
        }

        [HttpPost]
        [Route("CrearUsuarioEPS")]
        public async Task<IActionResult> CrearUsuarioEPS(UsuarioEPSModel usuarioepsmodel)
        {
            try
            {
                UsuarioEPS usuarioeps = new UsuarioEPS
                {
                    TblEpsId = usuarioepsmodel.EpsId,
                    TblUsuariosId = usuarioepsmodel.UsuarioId
                };
                var resultado = await _epsService.CrearUsuarioEPS(usuarioeps);
                if (resultado != null)
                    return NotFound(resultado);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
            return Ok();
        }

        [HttpDelete]
        [Route("EliminarUsuarioEPS")]
        public async Task<IActionResult> EliminarUsuarioEPS(UsuarioEPSModel usuarioepsmodel)
        {
            try
            {
                UsuarioEPS usuarioeps = new UsuarioEPS
                {
                    TblEpsId = usuarioepsmodel.EpsId,
                    TblUsuariosId = usuarioepsmodel.UsuarioId
                };
                var resultado = await _epsService.EliminarUsuarioEPS(usuarioeps);
                if (resultado != null)
                    return NotFound(resultado);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
            return Ok();
        }

    }
}