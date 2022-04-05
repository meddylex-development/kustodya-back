using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.MallaValidadora
{
    public class Validacion : BaseEntity
    {
        public Validacion()
        {

        }
        public Validacion(Incapacidad incapacidad)
        {
            Fecha = DateTime.Now;
            IncapacidadId = incapacidad.Id;

            AfiliadoCotizaMasDeDe4Semanas = incapacidad.AfiliadoCotizaMasDeDe4Semanas();
            AfiliadoEsCotizante = incapacidad.AfiliadoEsCotizante();
            AfiliadoEsActivo = incapacidad.AfiliadoEsActivo();
            IpsIsAdscrita = incapacidad.IpsIsAdscrita();
            EdadAfiliadoIgualAEdadDiagnostico = incapacidad.EdadAfiliadoIgualAEdadDiagnostico();
            EdadAfiliadoIgualAEdadDiagnostico = incapacidad.EdadAfiliadoIgualAEdadDiagnostico();
            SexoAfiliadoIgualSexoDiagnostico = incapacidad.SexoAfiliadoIgualSexoDiagnostico();
            AfiliadoMayorEdadOMenorA18AñosHabilitado = incapacidad.AfiliadoMayorEdadOMenorA18AñosHabilitado();
            EdadAfiliadoMayor85Años = incapacidad.EdadAfiliadoMayor85Años();
            AfiliadoPensionado = incapacidad.AfiliadoPensionado();
            IncapacidadMayorA2DiasSinProrroga = incapacidad.IncapacidadMayorA2DiasSinProrroga();
            IncapacidadEntre181y540Dias = incapacidad.IncapacidadEntre181y540Dias();
            IncapacidadProlongadaMayorOIgualA540Dias = incapacidad.IncapacidadProlongadaMayorOIgualA540Dias();
            FechaInicioMenorOIgualFechaRadicacion = incapacidad.FechaInicioMenorOIgualFechaRadicacion();
            DiasAcumuladosMayorAMaximo = incapacidad.DiasAcumuladosMayorAMaximo();
            IncapacidadProlongadaPorDiagnosticosNoRelacinados = incapacidad.IncapacidadProlongadaPorDiagnosticosNoRelacinados();
            CalificacionPCLMayorA50 = incapacidad.CalificacionPCLMayorA50();
            AfiliadoConCHRBDesfavorable = incapacidad.AfiliadoConCHRBDesfavorable();
            ExcesoPorDiagnostico = incapacidad.ExcesoPorDiagnostico();
            EspecialidadMedicaConcuerdaDiagnostico = incapacidad.EspecialidadMedicaConcuerdaDiagnostico();
            AfiliadoSinCalificacionAtel = incapacidad.AfiliadoSinCalificacionAtel();
            UbicacionCorrespondeConAfiliado = incapacidad.UbicacionCorrespondeConAfiliado();
            UbicacionCorresponConAfiliado = incapacidad.UbicacionCorresponConAfiliado();
            AfiliadoAsistioATratamientosTerapias = incapacidad.AfiliadoAsistioATratamientosTerapias();
            AfiliadoAsistioAExamenesYValoraciones = incapacidad.AfiliadoAsistioAExamenesYValoraciones();
            SinPresuntaAlteracionOFraude = incapacidad.SinPresuntaAlteracionOFraude();
            AfiliadoSinConductasContrariasAEstadoDeSalud = incapacidad.AfiliadoSinConductasContrariasAEstadoDeSalud();
            AfiliadoSinActividadImpideSuRecuperacion = incapacidad.AfiliadoSinActividadImpideSuRecuperacion();
            SinFraudeAlOtorgarIncapacidad = incapacidad.SinFraudeAlOtorgarIncapacidad();
            IncapacidadGenerandoDobleCobro = incapacidad.IncapacidadGenerandoDobleCobro();
            AfiliadoSinCobroConDatosFalsos = incapacidad.AfiliadoSinCobroConDatosFalsos();
            IncapacidadSinDobleCobro = incapacidad.IncapacidadSinDobleCobro();
        }

        // public Guid Id { get; set; }
        public bool? EspecialidadMedicaEsValida { get; private set; }
        public bool? DiasCorrespondenConDiagnostico { get; private set; }
        public bool? UbicacionCorresponConAfiliado { get; private set; }
        public bool? DiasAcumuladosValidos { get; private set; }
        public bool? AfiliadoEsActivo { get; set; }
        public bool? AfiliadoEsCotizante { get; set; }
        public bool? IpsIsAdscrita { get; set; }
        public bool? AfiliadoCotizaMasDeDe4Semanas { get; set; }
        public bool? EdadAfiliadoIgualAEdadDiagnostico { get; set; }
        public bool? SexoAfiliadoIgualSexoDiagnostico { get; set; }
        public bool? AfiliadoMayorEdadOMenorA18AñosHabilitado { get; set; }
        public bool? EdadAfiliadoMayor85Años { get; set; }
        public bool? AfiliadoPensionado { get; set; }
        public bool? IncapacidadMayorA2DiasSinProrroga { get; set; }
        public bool? IncapacidadEntre181y540Dias { get; set; }
        public bool? IncapacidadProlongadaMayorOIgualA540Dias { get; set; }
        public bool? FechaInicioMenorOIgualFechaRadicacion { get; set; }
        public bool? DiasAcumuladosMayorAMaximo { get; set; }
        public bool? IncapacidadProlongadaPorDiagnosticosNoRelacinados { get; set; }
        public bool? CalificacionPCLMayorA50 { get; set; }
        public bool? AfiliadoConCHRBDesfavorable { get; set; }
        public bool? ExcesoPorDiagnostico { get; set; }
        public bool? EspecialidadMedicaConcuerdaDiagnostico { get; set; }
        public bool? AfiliadoSinCalificacionAtel { get; set; }
        public bool? UbicacionCorrespondeConAfiliado { get; set; }
        public bool? AfiliadoAsistioATratamientosTerapias { get; set; }
        public bool? AfiliadoAsistioAExamenesYValoraciones { get; set; }
        public bool? SinPresuntaAlteracionOFraude { get; set; }
        public bool? AfiliadoSinConductasContrariasAEstadoDeSalud { get; set; }
        public bool? AfiliadoSinActividadImpideSuRecuperacion { get; set; }
        public bool? SinFraudeAlOtorgarIncapacidad { get; set; }
        public bool? IncapacidadGenerandoDobleCobro { get; set; }
        public bool? AfiliadoSinCobroConDatosFalsos { get; set; }
        public bool? IncapacidadSinDobleCobro { get; set; }

        public DateTime Fecha { get; private set; }

        public Guid IncapacidadId { get; set; }
    }
}
