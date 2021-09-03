using AutoMapper;
using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Interfaces.Incapacidades;
using Kustodya.ApplicationCore.Interfaces.Negocio;
using Kustodya.ApplicationCore.Constants;
using Kustodya.ApplicationCore.Dtos.Incapacidades;
using Kustodya.ApplicationCore.Dtos.Multivalores;
using Kustodya.ApplicationCore.Dtos.Negocio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Controllers;
using Kustodya.ApplicationCore.Interfaces.General;

namespace Kustodya.WebApi.Controllers.Incapacidades
{
    public class DiagnosticoIncapacidadController : BaseController
    {
        #region Dependency Injection
        private readonly ICie10Service _cie10Service;
        private readonly IDANEService _daneService;
        private readonly IDiagnosticoIncapacidadService _diagnosticoIncapacidadService;
        private readonly IIPSService _ipsService;
        private readonly IEPSService _epsService;
        private readonly ILoggerService<DiagnosticoIncapacidadController> _logger;
        private readonly IMapper _mapper;
        private readonly IMultivaloresService _multivaloresService;
        private readonly IPacienteService _pacienteService;

        public DiagnosticoIncapacidadController(IMultivaloresService multivaloresService, ICie10Service cie10Service,
            IPacienteService pacienteService, IDiagnosticoIncapacidadService diagnosticoIncapacidadService,
        ILoggerService<DiagnosticoIncapacidadController> logger, IMapper mapper, IDANEService daneService, 
        IIPSService ipsService, IEPSService epsService)
        {
            _multivaloresService = multivaloresService;
            _cie10Service = cie10Service;
            _pacienteService = pacienteService;
            _diagnosticoIncapacidadService = diagnosticoIncapacidadService;
            _logger = logger;
            _mapper = mapper;
            _daneService = daneService;
            _ipsService = ipsService;
            _epsService = epsService;
        }
        #endregion

        /// <summary>
        /// 1. Diagnostico, 2. Sintoma, 3. Signo
        /// </summary>
        /// <param name="IIdtipoCie"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<CIE10Model>), 200)]
        public async Task<IActionResult> GetCie10(int IIdtipoCie)
        {
            IReadOnlyList<TblCie10> cie10 = await _cie10Service.GetCie10(IIdtipoCie).ConfigureAwait(false);

            if (!cie10.Any())
            {
                return Ok();
            }

            List<CIE10Model> result = _mapper.Map<List<CIE10Model>>(cie10);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(DiagnosticoIncapacidadModel), 200)]
        public async Task<IActionResult> GetDiagnosicosIncapacidadByCodigoDiagnostico(string CodigoDiagnostico)
        {
            bool validateGuid = Guid.TryParse(CodigoDiagnostico, out Guid guidCodigoDiagnostico);

            if (!validateGuid)
            {
                return BadRequest("Codigo de diagnostico no valido");
            }

            TblDiagnosticosIncapacidades objDiagnosticosIncapacidad = await _diagnosticoIncapacidadService.GetDiagnosticosIncapacidadByCodigoDiagnostico(guidCodigoDiagnostico).ConfigureAwait(false);

            var idTipoAtencion = objDiagnosticosIncapacidad.IIdtipoAtencion;
            DiagnosticoIncapacidadModel result = _mapper.Map<DiagnosticoIncapacidadModel>(objDiagnosticosIncapacidad);
            MultivaloresModel tipo = await _multivaloresService.GetMultivalorById(idTipoAtencion).ConfigureAwait(false);
            TipoAtencionModel tipoAtencion = _mapper.Map<MultivaloresModel, TipoAtencionModel>(tipo);
            IPSModel ips = await _ipsService.GetIPSById(result.IIdips).ConfigureAwait(false);

            result.Eps = await _epsService.GetEPSById(result.IIdEps).ConfigureAwait(false);
            result.LugarExpedicion = ips.Ubicacion;
            result.TLugarExpedicion = ips.Ubicacion.GetLugarExpedicion();
            result.DtFechaFin = result.FechaEmisionIncapacidad.AddDays(result.IDiasIncapacidad);
            result.Ips = ips;
            result.TipoAtencion = tipoAtencion;
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(DiagnosticoCorrelacionModel), 200)]
        public async Task<IActionResult> GetDiagnosticoCorrelacion(int IIdcie10, int IIdpaciente)
        {
            TblDiagnosticosIncapacidades objDiagnosticosIncapacidad = await _diagnosticoIncapacidadService.GetDiagnosticoCorrelacion(IIdcie10, IIdpaciente).ConfigureAwait(false);

            DiagnosticoCorrelacionModel result = new DiagnosticoCorrelacionModel()
            {
                IIddiagnosticoCorrelacion = 0,
                BProrroga = false,
                IDiasAcumuladosPorroga = 0
            };

            if (objDiagnosticosIncapacidad != null)
            {
                result = new DiagnosticoCorrelacionModel()
                {
                    IIddiagnosticoCorrelacion = objDiagnosticosIncapacidad.IIddiagnosticoIncapacidad,
                    BProrroga = true,
                    IDiasAcumuladosPorroga = objDiagnosticosIncapacidad.IDiasIncapacidad + (objDiagnosticosIncapacidad.IDiasAcumuladosPorroga ?? 0)
                };
            }

            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<OrigenIncapacidadModel>), 200)]
        public async Task<IActionResult> GetOrigenesIncapacidad()
        {
            IReadOnlyList<TblMultivalores> origenesIncapacidad = await _multivaloresService.GetDatosSubtabla(Subtabla.OrigenIncapacidad).ConfigureAwait(false);

            if (!origenesIncapacidad.Any())
            {
                return Ok();
            }

            List<OrigenIncapacidadModel> result = _mapper.Map<List<OrigenIncapacidadModel>>(origenesIncapacidad);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<TipoAtencionModel>), 200)]
        public async Task<IActionResult> GetTiposAtencion()
        {
            IReadOnlyList<TblMultivalores> tipoAtencion = await _multivaloresService.GetDatosSubtabla(Subtabla.TipoAtencion);

            if (!tipoAtencion.Any())
            {
                return Ok();
            }

            List<TipoAtencionModel> result = _mapper.Map<List<TipoAtencionModel>>(tipoAtencion);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(DiagnosticoIncapacidadModel), 200)]
        public async Task<IActionResult> PostDiagnosticosIncapacidad([FromBody]DiagnosticoIncapacidadModel diagnosticoIncapacidad)
        {
            if (diagnosticoIncapacidad is null)
                return BadRequest("The model can't be null");
            
            if (await PacientStateIsValid(diagnosticoIncapacidad))
                return Conflict("The pacient is not in a active state");

            try
            {
                //DiagnosticoIncapacidadModel model = await _diagnosticoIncapacidadService.GuardarIncapacidad(idDiagnosticoIncapacidad);

                int? IIdusuario = Convert.ToInt32(User.Claims.Where(c => c.Type == "UserId").FirstOrDefault().Value);
                if (IIdusuario is null || IIdusuario == 0)
                {
                    return Forbid(); // 403
                }

                TblPacientes paciente = await _pacienteService.GetPacienteById(diagnosticoIncapacidad.IIdpaciente);

                //TODO Consume micro-service
                string codigoIncapacidad = GetCodigoIncapacidad(paciente);
                diagnosticoIncapacidad.TCodigoCorto = codigoIncapacidad;

                TblDiagnosticosIncapacidades objDiagnosticosIncapacidad = _mapper.Map<TblDiagnosticosIncapacidades>(diagnosticoIncapacidad);

                objDiagnosticosIncapacidad = await _diagnosticoIncapacidadService.CrearDiagnosticosIncapacidad(objDiagnosticosIncapacidad, paciente, IIdusuario.Value);

                DiagnosticoIncapacidadModel result = _mapper.Map<DiagnosticoIncapacidadModel>(objDiagnosticosIncapacidad);

                IPSModel ips = await _ipsService.GetIPSById(diagnosticoIncapacidad.IIdips);
                result.LugarExpedicion = ips.Ubicacion;
                result.TLugarExpedicion = ips.Ubicacion.GetLugarExpedicion();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        
        private async Task<bool> PacientStateIsValid(DiagnosticoIncapacidadModel incapacidadModel)
        {
            var pacientId = incapacidadModel.IIdpaciente;
            var pacient = await _pacienteService.GetPacienteById(pacientId);
            return pacient?.IIdestadoAfiliacion != (byte)MembershipModel.Status.Active;
        }

        #region Helper Methods
        private string GenerateRndString(int size)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString().ToUpper();
        }

        private string GetCodigoIncapacidad(TblPacientes paciente)
        {
            //TODO Consumes micro-service
            string shortCode = GenerateRndString(4);
            StringBuilder builder = new StringBuilder();
            builder.Append(paciente.IIdepsNavigation.TCodigoExterno)
                .Append("-").Append(shortCode)
                .Append("-").Append(paciente.TNumeroDocumento)
                ;

            return builder.ToString();
        }
        #endregion
    }
}