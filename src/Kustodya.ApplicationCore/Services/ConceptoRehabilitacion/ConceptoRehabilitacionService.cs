using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Entities.Concepto;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Interfaces.Rehabilitacion;
using Kustodya.ApplicationCore.Specifications.Concepto;
using Kustodya.ApplicationCore.Specifications.Incapacidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.Services.ConceptoRehabilitacion
{
    public class ConceptoRehabilitacionService : IConceptoRehabilitacionService
    {
        private readonly IAsyncRepository<TblDiagnosticosIncapacidades> _repoDiagnosticoIncapacidades;
        private readonly IAsyncRepository<PacientesPorEmitir> _repoPacientesPorEmitir;
        private readonly IAsyncRepository<PronosticoConcepto> _repoPronosticoConcepto;
        private readonly IAsyncRepository<Entities.Concepto.ConceptoRehabilitacion> _repoConceptoRehabilitacion;

        public ConceptoRehabilitacionService(IAsyncRepository<TblDiagnosticosIncapacidades> repoDiagnosticoIncapacidades,
            IAsyncRepository<PacientesPorEmitir> repoPacientesPorEmitir,
            IAsyncRepository<Entities.Concepto.ConceptoRehabilitacion> repoConceptoRehabilitacion,
            IAsyncRepository<PronosticoConcepto> repoPronosticoConcepto) {
            _repoDiagnosticoIncapacidades = repoDiagnosticoIncapacidades;
            _repoPacientesPorEmitir = repoPacientesPorEmitir;
            _repoConceptoRehabilitacion = repoConceptoRehabilitacion;
            _repoPronosticoConcepto = repoPronosticoConcepto;
        }
        public async Task<int?> DiasAcumulados(int pacienteId) {
            var spec = new DiagnosticosIncapacidadesporPaciente(pacienteId);
            IReadOnlyList<TblDiagnosticosIncapacidades> diagnosticosIncapacidades = await _repoDiagnosticoIncapacidades.ListAsync(spec);
            return diagnosticosIncapacidades.Max(c => c.IDiasAcumuladosPorroga);
        }
        public async Task<PacientesPorEmitir> PacientePorEmitir(int pacienteporEmitirId)
        {
            var spec = new PacientesPorEmitirPorIdSpec(pacienteporEmitirId);
            return await _repoPacientesPorEmitir.GetOneAsync(spec);
        }
        public async Task<IReadOnlyList<Entities.Concepto.ConceptoRehabilitacion>> ConceptosEmitidos(int pacienteId, string busqueda, int? skip = null, int? take = null) {
            var spec = new ConceptosEmitidosporPacienteSpec(pacienteId, busqueda, skip, take);
            return await _repoConceptoRehabilitacion.ListAsync(spec);
        }
        public async Task<IReadOnlyList<TblDiagnosticosIncapacidades>> Incapacidades(int pacienteId, string busqueda, int? skip = null, int? take = null)
        {
            var spec = new DiagnosticosIncapacidadesporPacienteSpec(pacienteId, busqueda, skip, take);
            return await _repoDiagnosticoIncapacidades.ListAsync(spec);
        }
        public async Task<Entities.Concepto.ConceptoRehabilitacion> DatosConcepto(int pacientePorEmitirId) {
            var spec = new ConceptoEmitidosporIdSpec(pacientePorEmitirId);
            return await _repoConceptoRehabilitacion.GetOneAsync(spec);
        }
        public async Task<Entities.Concepto.ConceptoRehabilitacion> CrearConcepto(Entities.Concepto.ConceptoRehabilitacion concepto, int usuarioId)
        {
            concepto.UsuarioCreacionId = usuarioId;
            concepto.FechaEmision = DateTime.Now;

            var pacientePorEmitir = await _repoPacientesPorEmitir.GetByIdAsync(concepto.PacienteporEmitirId);
            pacientePorEmitir.Estado = PacientesPorEmitir.EstadoConcepto.Emitido;
            //pacientePorEmitir.FechaEmision = DateTime.Now; cambio base de datos

            await _repoPacientesPorEmitir.UpdateAsync(pacientePorEmitir);
            await _repoConceptoRehabilitacion.AddAsync(concepto);
            return concepto;
        }
        public async Task<Entities.Concepto.ConceptoRehabilitacion> ActualizarConcepto(Entities.Concepto.ConceptoRehabilitacion concepto) {
            await _repoConceptoRehabilitacion.UpdateAsync(concepto);
            return concepto;
        }

        public async Task<PacientesPorEmitir> ActualizarPacientePorEmitir(PacientesPorEmitir pacientesPorEmitir) {
            await _repoPacientesPorEmitir.UpdateAsync(pacientesPorEmitir);
            return pacientesPorEmitir;
        }
        public async Task<PacientesPorEmitir> CrearPendientePorEmitir(PacientesPorEmitir pacientesPorEmitir) {
            await _repoPacientesPorEmitir.AddAsync(pacientesPorEmitir);
            return pacientesPorEmitir;
        }
        public async Task<IReadOnlyCollection<PacientesPorEmitir>> Dashboard(string periodo)
        {
            DateTime anyoInicio = new DateTime(DateTime.Now.Year, 1, 1);
            DateTime anyoFin = new DateTime(DateTime.Now.Year, 12, 31).AddHours(23);
            DateTime mesInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime mesFin = new DateTime(DateTime.Now.Year, (DateTime.Now.Month + 1), 1).AddHours(23);
            int desdeellunes = (int)DateTime.Now.DayOfWeek;
            var spec = new ConceptosporPeriodoSpec(periodo, desdeellunes, anyoInicio, anyoFin, mesInicio, mesFin);
            var pacientes = await _repoPacientesPorEmitir.ListAsync(spec);
            return pacientes;
        }

        public async Task<IReadOnlyCollection<PronosticoConcepto>> Pronosticos(){
            return await _repoPronosticoConcepto.ListAllAsync();
        }
    }
}
