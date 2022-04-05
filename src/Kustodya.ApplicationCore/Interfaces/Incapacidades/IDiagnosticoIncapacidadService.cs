using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Dtos.Incapacidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kustodya.ApplicationCore.Entities.Incapacidad;

namespace Kustodya.ApplicationCore.Interfaces.Incapacidades
{
    public interface IDiagnosticoIncapacidadService
    {
        Task<IReadOnlyList<TblCie10DiagnosticoIncapacidad>> GetCie10DiagnosticosByPacienteUnAñoAtras(int iIDPaciente);

        Task<TblDiagnosticosIncapacidades> GetDiagnosticosIncapacidadByCodigoDiagnostico(Guid UiCodigoDiagnostico);

        Task<IReadOnlyList<DiagnosticoIncapacidadModel>> GetDiagnosticosIncapacidadByPaciente(int iIDPaciente);

        Task<IReadOnlyList<TblDiagnosticosIncapacidades>> GetDiagnosticosIncapacidadByPacienteUnAñoAtras(int iIDPaciente);

        Task<TblDiagnosticosIncapacidades> GetDiagnosticoCorrelacion(int IIdcie10, int IIdpaciente);

        Task<DiagnosticoIncapacidadModel> GuardarIncapacidad(DiagnosticoIncapacidadModel idDiagnosticoIncapacidad);

        Task<TblDiagnosticosIncapacidades> CrearDiagnosticosIncapacidad(TblDiagnosticosIncapacidades DiagnosticosIncapacidad, TblPacientes paciente, long IIdusuarioCreador, TranscripcionAIModel transcripcionAIModel = null, TblTranscripciones transcripcion = null);
        Task<IReadOnlyList<tblLateralidad>> GetLateralidades();
    }
}