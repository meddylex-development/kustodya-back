using AutoMapper;
using Kustodya.BusinessLogic.Services.General;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Interfaces.Incapacidades;
using Kustodya.ApplicationCore.Dtos.General;
using Kustodya.ApplicationCore.Dtos.Incapacidades;
using Kustodya.ApplicationCore.Dtos.Multivalores;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Controllers;
using Kustodya.ApplicationCore.Interfaces.General;
using Kustodya.ApplicationCore.Constants;
using Kustodya.ApplicationCore.Entities;
using Kustodya.WebApi.Controllers.Incapacidades.Modelos;
using Kustodya.ApplicationCore.Dtos;
using Kustodya.ApplicationCore.Entities.Concepto;

namespace Kustodya.WebApi.Controllers.Incapacidades
{
    public class PacientesController : BaseController
    {
        private readonly ICie10Service _cie10Service;
        private readonly ICIUOService _CIUOService;
        private readonly IDANEService _daneService;
        private readonly IDiagnosticoIncapacidadService _diagnosticoIncapacidadService;
        private readonly IEmpresaService _empresaService;
        private readonly ILoggerService<PacientesController> _logger;
        private readonly IMapper _mapper;
        private readonly IMapper _mapper2;
        private readonly IMultivaloresService _multivaloresService;
        private readonly IPacienteService _pacienteService;
        private readonly MapperConfiguration _config = new MapperConfiguration(cfg => {
            cfg.AddProfile<MappingProfiles>();
            cfg.CreateMap<PacientesPorEmitir, PacienteOutputModel>();
        });

        public PacientesController(IPacienteService pacienteService, IMultivaloresService multivaloresService,
            IDiagnosticoIncapacidadService diagnosticoIncapacidadService, ICie10Service cie10Service,
            IEmpresaService empresaService, IDANEService daneService,
             ICIUOService ciuoService,
            IMapper mapper, ILoggerService<PacientesController> logger)
        {
            _pacienteService = pacienteService;
            _multivaloresService = multivaloresService;
            _diagnosticoIncapacidadService = diagnosticoIncapacidadService;
            _cie10Service = cie10Service;
            _mapper = mapper;
            _mapper2 = _config.CreateMapper();
            _empresaService = empresaService;
            _daneService = daneService;
            _CIUOService = ciuoService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<DiagnosticosPacienteModel>), 200)]
        public async Task<IActionResult> GetCantidadDiagnoticosIncapacidadByPaciente(int iIDPaciente)
        {
            IReadOnlyList<TblCie10DiagnosticoIncapacidad> diagnosticosIncapacidades = await _diagnosticoIncapacidadService.GetCie10DiagnosticosByPacienteUnAñoAtras(iIDPaciente).ConfigureAwait(false);

            List<DiagnosticosPacienteModel> result;

            result = diagnosticosIncapacidades.GroupBy(info => info.IIdcie10)
                    .Select(group => new DiagnosticosPacienteModel
                    {
                        TCie10 = group.First().IIdcie10Navigation.TCie10,
                        IDiasIncapacidad = group.Sum(c => c.IIddiagnosticoIncapacidadNavigation.IDiasIncapacidad),
                        IIncapacidadesEmitidas = group.Count()
                    })
                    .OrderBy(x => x.TCie10).ToList();

            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<DiagnosticoIncapacidadModel>), 200)]
        public async Task<IActionResult> GetDiagnosicosIncapacidadByPaciente(int iIDPaciente)
        {
            IReadOnlyList<DiagnosticoIncapacidadModel> diagnosticosIncapacidades = await _diagnosticoIncapacidadService.GetDiagnosticosIncapacidadByPaciente(iIDPaciente);

            if (!diagnosticosIncapacidades.Any())
            {
                return Ok();
            }

            return Ok(diagnosticosIncapacidades);
        }

        [HttpGet]
        [ProducesResponseType(typeof(int), 200)]
        public async Task<IActionResult> GetDiasIncapacidadesByPaciente(int iIDPaciente)
        {
            IReadOnlyList<TblDiagnosticosIncapacidades> diagnosticosIncapacidades = await _diagnosticoIncapacidadService.GetDiagnosticosIncapacidadByPacienteUnAñoAtras(iIDPaciente).ConfigureAwait(false);

            int diasIncapacidades = diagnosticosIncapacidades.Sum(d => d.IDiasIncapacidad);

            return Ok(diasIncapacidades);
        }

        [HttpGet]
        [ProducesResponseType(typeof(int), 200)]
        public async Task<IActionResult> GetNumeroIncapacidadesByPaciente(int iIDPaciente)
        {
            var diagnosticosIncapacidades = await _diagnosticoIncapacidadService.GetDiagnosticosIncapacidadByPacienteUnAñoAtras(iIDPaciente).ConfigureAwait(false);
            return Ok(diagnosticosIncapacidades.Count);
        }

        [HttpGet]
        [ProducesResponseType(typeof(PacienteModel), 200)]
        public async Task<IActionResult> GetPacienteByID(int IIdpaciente)
        {
            TblPacientes paciente = await _pacienteService.GetPacienteById(IIdpaciente).ConfigureAwait(false);

            if (paciente == null)
            {
                return Ok();
            }

            PacienteModel result = _mapper.Map<PacienteModel>(paciente);
            result.Empresa = await _empresaService.GetEmpresaById((long)paciente.IIdempresa).ConfigureAwait(false);
            UbicacionModel ubicacion = await _daneService.GetUbicacionById(paciente.IIddane).ConfigureAwait(false);
            result.Ubicacion = ubicacion;
            result.Ocupacion = await _CIUOService.GetOcupacionById(paciente.IIdciuo08).ConfigureAwait(false);

            return Ok(result);
        }


        [HttpGet]
        [ProducesResponseType(typeof(PacienteModel), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetPacienteByNumeroDocumento(int iIdTipoDocumento, string tNumeroDocumento)
        {
            TblPacientes paciente = await _pacienteService.GetPacienteByNumeroDocumento(iIdTipoDocumento, tNumeroDocumento).ConfigureAwait(false);

            if (paciente == null)
            {
                return Ok();
            }

            PacienteModel result = _mapper.Map<PacienteModel>(paciente);
            EmpresaTercerosModel empresa = await _empresaService.GetEmpresaById((long)paciente.IIdempresa).ConfigureAwait(false);
            result.Empresa = empresa;
            UbicacionModel ubicacion = await _daneService.GetUbicacionById(paciente.IIddane).ConfigureAwait(false);
            result.Ubicacion = ubicacion;

            result.Ocupacion = await _CIUOService.GetOcupacionById(paciente.IIdciuo08).ConfigureAwait(false);

            return Ok(result);
        }

        [HttpGet] 
        public async Task<IActionResult> PendientesConceptoRehabilitacion([FromQuery] PacientesPorEmitir.EstadoConcepto? estado, [FromQuery] string busqueda = "", [FromQuery] int pagina = 1)
        {
            int cantidad = 10;
            var listaPacientes = await _pacienteService.PacientesPorEmitir(estado, busqueda, (pagina - 1) * cantidad, cantidad);
            var total = await _pacienteService.PacientesPorEmitir(estado, busqueda, null, null);
            var listaSalida = _mapper2.Map<List<PacienteOutputModel>>(listaPacientes);

            PacientesOutputModel pacientesOutputModel = new PacientesOutputModel()
            {
                listaPacientes = listaSalida,
                paginacion = new PaginacionModel(total.Count(), pagina, cantidad)
            };
            return Ok(pacientesOutputModel);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<TipoIdentificacionModel>), 200)]
        public async Task<IActionResult> GetTiposIdentificacion()
        {
            IReadOnlyList<TblMultivalores> tipoIdentificacion = await _multivaloresService.GetDatosSubtabla(Subtabla.TipoIdentificacion).ConfigureAwait(false);

            if (!tipoIdentificacion.Any())
            {
                return Ok();
            }

            List<TipoIdentificacionModel> result = _mapper.Map<List<TipoIdentificacionModel>>(tipoIdentificacion);
            return Ok(result);
        }
    }
}