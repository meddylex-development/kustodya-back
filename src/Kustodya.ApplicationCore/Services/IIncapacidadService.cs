using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.Services
{
    public interface IIncapacidadService
    {
        Task<bool> AfiliadoAsistioAExamenesYValoraciones(string incapacidadId);
        Task<bool> AfiliadoAsistioATratamientosTerapias(string incapacidadId);
        Task<bool> AfiliadoConCHRBDesfavorable(string incapacidadId);
        Task<bool> AfiliadoCotizaMasDeDe4Semanas(string incapacidadId);
        Task<bool> AfiliadoEsActivo(string incapacidadId);
        Task<bool> AfiliadoEsCotizante(string incapacidadId);
        Task<bool> AfiliadoMayorEdadOMenorA18AñosHabilitado(string incapacidadId);
        Task<bool> AfiliadoPensionado(string incapacidadId);
        Task<bool> AfiliadoSinActividadImpideSuRecuperacion(string incapacidadId);
        Task<bool> AfiliadoSinCalificacionAtel(string incapacidadId);
        Task<bool> AfiliadoSinCobroConDatosFalsos(string incapacidadId);
        Task<bool> AfiliadoSinConductasContrariasAEstadoDeSalud(string incapacidadId);
        Task<bool> CalificacionPCLMayorA50(string incapacidadId);
        bool DiasAcumuladosMayoraMaximo(string incapacidadId);
        bool DiasAcumuladosMayorAMaximo(string incapacidadId);
        Task<bool> EdadAfiliadoIgualAEdadDiagnostico(string incapacidadId);
        Task<bool> EdadAfiliadoMayor85Años(string incapacidadId);
        bool EspecialidadMedicaConcuerdaDiagnostico(string incapacidadId);
        bool ExcesoPorDiagnostico(string incapacidadId);
        Task<bool> FechaInicioMenorOIgualFechaRadicacion(string incapacidadId);
        Task<bool> IncapacidadEntre181y540Dias(string incapacidadId);
        bool IncapacidadGenerandoDobleCobro(string incapacidadId);
        Task<bool> IncapacidadMayorA2DiasSinProrroga(string incapacidadId);
        bool IncapacidadProlongadaMayorOIgualA540Dias(string incapacidadId);
        bool IncapacidadProlongadaPorDiagnosticosNoRelacinados(string incapacidadId);
        Task<bool> IncapacidadSinDobleCobro(string incapacidadId);
        Task<bool> IpsIsAdscrita(string incapacidadId);
        Task<bool> SexoAfiliadoIgualSexoDiagnostico(string incapacidadId);
        Task<bool> SinFraudeAlOtorgarIncapacidad(string incapacidadId);
        Task<bool> SinPresuntaAlteracionOFraude(string incapacidadId);
        bool UbicacionCorrespondeConAfiliado(string incapacidadId);
    }
}