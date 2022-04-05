using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Entities.Concepto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.Interfaces.Rehabilitacion
{
    public interface IConceptoRehabilitacionService
    {
        Task<int?> DiasAcumulados(int pacienteId);
        Task<PacientesPorEmitir> PacientePorEmitir(int pacienteporEmitirId);
        Task<IReadOnlyList<ConceptoRehabilitacion>> ConceptosEmitidos(int pacienteId, string busqueda, int? skip = null, int? take = null);
        Task<IReadOnlyList<TblDiagnosticosIncapacidades>> Incapacidades(int pacienteId, string busqueda, int? skip = null, int? take = null);
        Task<ConceptoRehabilitacion> DatosConcepto(int pacientePorEmitirId);
        Task<ConceptoRehabilitacion> CrearConcepto(ConceptoRehabilitacion concepto, int usuarioId);
        Task<ConceptoRehabilitacion> ActualizarConcepto(ConceptoRehabilitacion concepto);
        Task<PacientesPorEmitir> ActualizarPacientePorEmitir(PacientesPorEmitir pacientesPorEmitir);
        Task<PacientesPorEmitir> CrearPendientePorEmitir(PacientesPorEmitir pacientesPorEmitir);
        Task<IReadOnlyCollection<PacientesPorEmitir>> Dashboard(string periodo);
        Task<IReadOnlyCollection<PronosticoConcepto>> Pronosticos();


    }
}
