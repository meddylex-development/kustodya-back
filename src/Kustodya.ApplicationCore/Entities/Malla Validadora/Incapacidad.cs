using Kustodya.ApplicationCore.Entities.MallaValidadora;
using Kustodya.ApplicationCore.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.MallaValidadora
{
    public class Incapacidad : BaseEntity
    {
        public Incapacidad()
        {
            Id = Guid.NewGuid();
        }

        #region Propiedades
        public Guid AfiliadoId { get; set; }
        public Afiliado Afiliado { get; set; }
        public string IpsNit { get; set; }
        public DateTime? FechaAfiliacion { get; set; }

        internal bool? AfiliadoEsActivo()
        {
            try
            {
                GuardAgainstNull(Afiliado);
                GuardAgainstNull(Afiliado.Activo);
            }
            catch(SinDatosParaValidarException)
            {
                return null;
            }

            return this.Afiliado.Activo.GetValueOrDefault();
        }

        public Diagnostico Diagnostico { get; set; }
        private int Dias { get; set; }
        public bool? AfiliadoIsActive() => Afiliado.Activo;
        public bool? Prorroga { get; set; }
        public string CodigoCie10 { get; set; }
        public bool IsValid()
        {
            return
                AfiliadoIsActive().GetValueOrDefault();
        }

        public DateTime? FechaFin
        {
            get => fechaFin;
            set
            {
                if (!(FechaInicio is null))
                {
                    Dias = DiasDiferencia(FechaInicio, value);
                    fechaFin = value;
                }
                else
                    fechaFin = value;
            }
        }
        private DateTime? fechaFin;
        public DateTime? FechaInicio
        {
            get => fechaInicio;
            set
            {
                if (!(FechaFin is null))
                {
                    Dias = DiasDiferencia(value, FechaFin);
                    fechaInicio = value;
                }
                else
                    fechaInicio = value;
            }
        }
        private DateTime? fechaInicio;

        public int? DiasAcumulados { get; set; }
        public int? EspecialidadMedicaId { get; set; }
        public EspecialidadMedica EspecialidadMedica { get; set; }
        public string? CodigoDaneMunicipio { get; set; }
        public Ips Ips { get; set; }
        public Validacion Validacion { get; set; }
        public Guid ValidacionId { get; set; }
        #endregion

        #region Comportamiento
        public Validacion Validar()
        {
            this.Validacion = new Validacion(this);
            return this.Validacion;
        }

        public bool? IncapacidadMayorA2DiasSinProrroga()
        {
            try
            {
                GuardAgainstNull(this.FechaInicio);
                GuardAgainstNull(this.FechaFin);
                GuardAgainstNull(this.Prorroga);

                int diasIncapacidad = DiasDiferencia(this.FechaInicio, this.FechaFin);

                return diasIncapacidad >= 2 && !this.Prorroga.GetValueOrDefault();
            }
            catch (System.Exception)
            {
                return null;
            }
        }
        public bool? EdadAfiliadoMayor85Años()
        {
            try
            {
                GuardAgainstNull(this.Afiliado);
                GuardAgainstNull(this.Afiliado.FechaNacimiento);
                return DateTime.Compare(this.Afiliado.FechaNacimiento.GetValueOrDefault().Date, DateTime.Now.AddYears(-85).Date) <= 0;
            }
            catch (SinDatosParaValidarException)
            {
                return null;
            }
        }
        public bool? AfiliadoMayorEdadOMenorA18AñosHabilitado()
        {
            try
            {
                GuardAgainstNull(Afiliado);
                GuardAgainstNull(Afiliado.FechaNacimiento);
                return DateTime.Compare(this.Afiliado.FechaNacimiento.GetValueOrDefault().Date, DateTime.Now.AddYears(-85).Date) <= 0;
            }
            catch (System.Exception)
            {
                return null;
            }
        }
        public bool? FechaInicioMenorOIgualFechaRadicacion()
        {
            try
            {
                GuardAgainstNull(this.FechaInicio);
                GuardAgainstNull(this.FechaRadicacion);
            }
            catch (SinDatosParaValidarException)
            {
                return null;
            }

            return IsLowerOrEqualThan(this.FechaInicio, this.FechaRadicacion);
        }
        public bool? EspecialidadMedicaEsValida()
        {
            try
            {
                GuardAgainstNull(EspecialidadMedicaId);
                GuardAgainstNull(Diagnostico);
                GuardAgainstNull(Diagnostico.EspecialidadMedicaId);
            }
            catch (SinDatosParaValidarException)
            {
                return null;
            }

            return EspecialidadMedicaId == Diagnostico.EspecialidadMedicaId;
        }
        public bool? DiasCorrespondenConDiagnostico()
        {
            try
            {
                GuardAgainstNull(Dias);
                GuardAgainstNull(Diagnostico);
                GuardAgainstNull(Diagnostico.DiasMaxConsulta);
            }
            catch(SinDatosParaValidarException)
            {
                return null;
            }

            return Dias <= Diagnostico.DiasMaxConsulta.Value;
        }
        public bool? UbicacionCorresponConAfiliado()
        {
            try
            {
                GuardAgainstNull(Ips);
                GuardAgainstNull(Ips.CodigoDaneMunicipio);
                GuardAgainstNull(Afiliado);
                GuardAgainstNull(Afiliado.CodigoDaneMunicipio);

                return Ips.CodigoDaneMunicipio == Afiliado.CodigoDaneMunicipio;
            }
            catch (SinDatosParaValidarException)
            {
                return null;
            }
        }
        public bool? DiasAcumuladosValidos()
        {
            try
            {
                GuardAgainstNull(DiasAcumulados);
                GuardAgainstNull(Diagnostico);
                GuardAgainstNull(Diagnostico.DiasMaxAcumulados);
            }
            catch (SinDatosParaValidarException)
            {
                return null;
            }

            return DiasAcumulados <= Diagnostico.DiasMaxAcumulados;
        }

        public bool? IpsIsAdscrita()
        {
            try
            {
                GuardAgainstNull(this.Ips);
                GuardAgainstNull(this.Ips.Estado);
            }
            catch(SinDatosParaValidarException)
            {
                return null;
            }

            return Ips.Estado == Ips.Estados.Adscrita;
        }

        public bool? EdadAfiliadoIgualAEdadDiagnostico()
        {
            try
            {
                GuardAgainstNull(Afiliado);
                GuardAgainstNull(Afiliado.FechaNacimiento);
                GuardAgainstNull(Diagnostico);
                GuardAgainstNull(Diagnostico.EdadMaxima);
                GuardAgainstNull(Diagnostico.EdadMinima);
            }
            catch(SinDatosParaValidarException)
            {
                return null;
            }

            var edadMaxima = this.Diagnostico.EdadMaxima;
            var edadMinima = this.Diagnostico.EdadMinima;

            var fechaMinimaNacimiento = DateTime.Now.Date.AddMonths(-edadMaxima.GetValueOrDefault());
            var fechaMaximaNacimiento = DateTime.Now.Date.AddMonths(-edadMinima.GetValueOrDefault());

            if (edadMinima is null && edadMaxima is null)
                return true;
            if (edadMaxima is null)
                return IsLowerThan(this.Afiliado.FechaNacimiento, fechaMaximaNacimiento);
            if (edadMinima is null)
                return IsGreaterThan(this.Afiliado.FechaNacimiento, fechaMinimaNacimiento);

            return IsBetweenIncluding(this.Afiliado.FechaNacimiento, fechaMinimaNacimiento, fechaMaximaNacimiento);
        }

        public DateTime? FechaRadicacion { get; set; }

        public bool? SexoAfiliadoIgualSexoDiagnostico()
        {
            try
            {
                GuardAgainstNull(Afiliado);
                GuardAgainstNull(Afiliado.Sexo);
                GuardAgainstNull(Diagnostico);
                GuardAgainstNull(Diagnostico.Sexo);
            }
            catch(SinDatosParaValidarException)
            {
                return null;
            }

            return this.Afiliado.Sexo == this.Diagnostico.Sexo;
        }

        public DateTime? Inicio { get; set; }
        public bool? AlteracionOFraude { get; set; }

        public bool? AfiliadoPensionado()
        {
            return null;
        }

        public bool? FraudeEnOtorgacion { get; set; }

        public bool? IncapacidadEntre181y540Dias()
        {
            return null;
        }

        public bool? IncapacidadProlongadaMayorOIgualA540Dias()
        {
            return null;
        }

        public bool? DobleCobro { get; set; }

        public bool? DiasAcumuladosMayorAMaximo()
        {
            return null;
        }

        public bool? IncapacidadProlongadaPorDiagnosticosNoRelacinados()
        {
            return null;
        }

        public bool? AfiliadoConCHRBDesfavorable()
        {
            return null;
        }

        public bool? ExcesoPorDiagnostico()
        {
            return null;
        }

        public bool? AfiliadoSinCalificacionAtel()
        {
            return null;
        }

        public bool? UbicacionCorrespondeConAfiliado()
        {
            return null;
        }

        public bool? EspecialidadMedicaConcuerdaDiagnostico()
        {
            return null;
        }

        public bool? AfiliadoAsistioAExamenesYValoraciones()
        {
            return null;
        }

        public bool? SinPresuntaAlteracionOFraude()
        {
            return null;
        }

        public bool? AfiliadoSinConductasContrariasAEstadoDeSalud()
        {
            return null;
        }

        public bool? SinFraudeAlOtorgarIncapacidad()
        {
            return null;
        }

        public bool? IncapacidadGenerandoDobleCobro()
        {
            return null;
        }

        public bool? IncapacidadSinDobleCobro()
        {
            return null;
        }

        public bool? AfiliadoSinCobroConDatosFalsos()
        {
            return null;
        }

        public bool? AfiliadoSinActividadImpideSuRecuperacion()
        {
            return null;
        }

        public bool? AfiliadoAsistioATratamientosTerapias()
        {
            return null;
        }

        public bool? CalificacionPCLMayorA50()
        {
            return null;
        }

        public bool? AfiliadoCotizaMasDeDe4Semanas()
        {
            try
            {
                GuardAgainstNull(this.FechaAfiliacion);
            }
            catch(SinDatosParaValidarException)
            {
                return null;
            }

            return DateTime.Compare(FechaAfiliacion.Value, DateTime.Now.AddDays(-30)) < 0;
        }

        public bool? AfiliadoEsCotizante()
        {
            try
            {
                GuardAgainstNull(this.Afiliado);
                GuardAgainstNull(this.Afiliado.TipoAfiliacion);
            }
            catch(SinDatosParaValidarException)
            {
                return null;
            }

            return Afiliado.TipoAfiliacion == Afiliado.TiposAfiliacion.Cotizante;
        }
        #endregion

        #region Helper Methods
        private int DiasDiferencia(DateTime? fechaInicio, DateTime? fechaFin)
        {
            return (fechaFin - fechaInicio).GetValueOrDefault().Days;
        }
        private void GuardAgainstNull(object obj)
        {
            if (obj is null) throw new SinDatosParaValidarException();
        }
        private bool IsGreaterThan(DateTime? date1, DateTime? date2)
        {
            var firstDate = date1.GetValueOrDefault();
            var secondDate = date2.GetValueOrDefault();
            return DateTime.Compare(firstDate, secondDate) > 0;
        }
        private bool IsLowerThan(DateTime? date1, DateTime? date2)
        {
            var firstDate = date1.GetValueOrDefault();
            var secondDate = date2.GetValueOrDefault();
            return DateTime.Compare(firstDate, secondDate) < 0;
        }
        private bool IsBetween(DateTime? dateToCheck, DateTime? dateMin, DateTime? dateMax)
            => IsLowerThan(dateToCheck, dateMax) && IsGreaterThan(dateToCheck, dateMin);
        private bool IsBetweenIncluding(DateTime? dateToCheck, DateTime? dateMin, DateTime? dateMax)
           => IsLowerOrEqualThan(dateToCheck, dateMax) && IsGreaterOrEqualThan(dateToCheck, dateMin);
        private bool IsLowerOrEqualThan(DateTime? date1, DateTime? date2)
        {
            var firstDate = date1.GetValueOrDefault();
            var secondDate = date2.GetValueOrDefault();
            return DateTime.Compare(firstDate, secondDate) <= 0;
        }
        private bool IsGreaterOrEqualThan(DateTime? date1, DateTime? date2)
        {
            var firstDate = date1.GetValueOrDefault();
            var secondDate = date2.GetValueOrDefault();
            return DateTime.Compare(firstDate, secondDate) >= 0;
        }
        #endregion
    }
}
