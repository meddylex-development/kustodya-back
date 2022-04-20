using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Interfaces.Incapacidades;
using Kustodya.ApplicationCore.Specifications.Incapacidades;
using Kustodya.ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Kustodya.ApplicationCore.Constants;
using Kustodya.ApplicationCore.Interfaces.General;
using Kustodya.ApplicationCore.Entities.Concepto;
using Kustodya.ApplicationCore.Specifications.Concepto;

namespace Kustodya.Infrastructure.Services.Incapacidades
{
    public class PacienteService : IPacienteService
    {
        private readonly ILoggerService<PacienteService> _logger;
        private readonly IMultivaloresService _multivaloresService;
        private readonly IAsyncRepository<TblPacientes> _pacientesRepository;
        private readonly IAsyncRepository<PacientesPorEmitir> _pacientesPorEmitirRepository;


        public PacienteService(IAsyncRepository<TblPacientes> pacientesRepository,
            IMultivaloresService multivalores, ILoggerService<PacienteService> logger, IAsyncRepository<PacientesPorEmitir> pacientesPorEmitirRepository)
        {
            _multivaloresService = multivalores;
            _pacientesRepository = pacientesRepository;
            _logger = logger;
            _pacientesPorEmitirRepository = pacientesPorEmitirRepository;
        }

        public async Task<TblPacientes> GetPacienteById(int IIdpaciente)
        {
            var pacientesSpec = new PacientesSpec(IIdpaciente);
            var pacientes = await _pacientesRepository.GetOneAsync(pacientesSpec).ConfigureAwait(false);

            return pacientes;
        }

        public async Task<TblPacientes> GetPacienteByNumeroDocumento(int IIdTipoIdentificacion, string tNumeroDocumento)
        {
            var pacientesSpec = new PacientesSpec(IIdTipoIdentificacion, tNumeroDocumento);
            var pacientes = await _pacientesRepository.GetOneAsync(pacientesSpec).ConfigureAwait(false);

            return pacientes;
        }

        public async Task<TblPacientes> ValidarPacientePorNumeroDocumento(int iIdTipoDocumento, string tNumeroDocumento)
        {

            IReadOnlyList<TblMultivalores> lTipos = await _multivaloresService.GetDatosSubtabla(Subtabla.TipoIdentificacion).ConfigureAwait(false);
            var tipoIdentificacion = lTipos.First(a => a.IOrden == iIdTipoDocumento);
            var pacientesSpec = new PacientesSpec((int)tipoIdentificacion.IIdmultivalor, tNumeroDocumento);
            var pacientes = await _pacientesRepository.GetOneAsync(pacientesSpec).ConfigureAwait(false);
            return pacientes;
        }

        public async Task<IReadOnlyList<PacientesPorEmitir>> PacientesPorEmitir(PacientesPorEmitir.EstadoConcepto? estado, int usuario, string busqueda, int? skip = null, int? take = null) {//se filtra por usuario
            var spec = new PacientesPorEmitirSpec(usuario, busqueda, skip, take, estado);
            return await _pacientesPorEmitirRepository.ListAsync(spec);
        }


    }
}