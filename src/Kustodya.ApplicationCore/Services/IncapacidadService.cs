using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Entities.MallaValidadora;
using Kustodya.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.Services
{
    public class IncapacidadService : IIncapacidadService
    {
        #region Dependency Injection
        private IAsyncRepository<Incapacidad> _incapacidadRepo;
        private IAsyncRepository<Afiliado> _afiliadoRepo;
        private IAsyncRepository<Ips> _ipsRepo;
        private readonly IValidacionIncapacidadesService _validacionService;

        public IncapacidadService(
            IAsyncRepository<Incapacidad> incapacidadRepo,
            IAsyncRepository<Afiliado> afiliadoRepo,
            IAsyncRepository<Ips> ipsRepo,
            IValidacionIncapacidadesService validacionService = null)
        {
            _incapacidadRepo = incapacidadRepo;
            _afiliadoRepo = afiliadoRepo;
            _ipsRepo = ipsRepo;
            _validacionService = validacionService;
        }
        #endregion

        public async Task<bool> AfiliadoEsActivo(string incapacidadId)
        {
            var incapacidad = await GetAndValidateIncapacidadAsync(incapacidadId);

            var afiliado = await GetAndValidateAfiliadoAsync(incapacidad.AfiliadoId);

            if (afiliado.Activo is null)
                throw new SinDatosParaValidarException();

            return afiliado.Activo.GetValueOrDefault();
        }

        public async Task<bool> AfiliadoEsCotizante(string incapacidadId)
        {
            var incapacidad = await GetAndValidateIncapacidadAsync(incapacidadId);

            Afiliado afiliado = await GetAndValidateAfiliadoAsync(incapacidad.AfiliadoId);

            if (afiliado.TipoAfiliacion is null) throw new SinDatosParaValidarException();

            return afiliado.TipoAfiliacion == Afiliado.TiposAfiliacion.Cotizante;
        }

        public async Task<bool> IpsIsAdscrita(string incapacidadId)
        {
            var incapacidad = await GetAndValidateIncapacidadAsync(incapacidadId);
            var ips = await GetAndValidateIpsAsync(incapacidad.IpsNit);

            if (ips.Estado is null) throw new SinDatosParaValidarException();

            return ips.Estado == Ips.Estados.Adscrita;
        }

        public async Task<bool> AfiliadoCotizaMasDeDe4Semanas(string incapacidadId)
        {
            var incapacidad = await GetAndValidateIncapacidadAsync(incapacidadId);

            if (incapacidad.FechaAfiliacion is null)
                throw new SinDatosParaValidarException();

            return DateTime.Compare(incapacidad.FechaAfiliacion.Value, DateTime.Now.AddDays(-30)) < 0;
        }

        public async Task<bool> EdadAfiliadoIgualAEdadDiagnostico(string incapacidadId)
        {
            var incapacidad = await GetAndValidateIncapacidadAsync(incapacidadId);
            var afiliado = await GetAndValidateAfiliadoAsync(incapacidad.AfiliadoId);

            if (afiliado.FechaNacimiento is null) throw new SinDatosParaValidarException();
            if (incapacidad.Diagnostico is null) throw new SinDatosParaValidarException();

            var edadMaxima = incapacidad.Diagnostico.EdadMaxima;
            var edadMinima = incapacidad.Diagnostico.EdadMinima;

            var fechaMinimaNacimiento = DateTime.Now.Date.AddMonths(-edadMaxima.GetValueOrDefault());
            var fechaMaximaNacimiento = DateTime.Now.Date.AddMonths(-edadMinima.GetValueOrDefault());

            if (edadMinima is null && edadMaxima is null)
                return true;
            if (edadMaxima is null)
                return IsLowerThan(afiliado.FechaNacimiento, fechaMaximaNacimiento);
            if (edadMinima is null)
                return IsGreaterThan(afiliado.FechaNacimiento, fechaMinimaNacimiento);

            return IsBetweenIncluding(afiliado.FechaNacimiento, fechaMinimaNacimiento, fechaMaximaNacimiento);
        }

        public async Task<bool> SexoAfiliadoIgualSexoDiagnostico(string incapacidadId)
        {
            var incapacidad = await GetAndValidateIncapacidadAsync(incapacidadId);
            var afiliado = await GetAndValidateAfiliadoAsync(incapacidad.AfiliadoId);

            if (afiliado.Sexo is null) throw new SinDatosParaValidarException();
            if (incapacidad.Diagnostico is null) throw new SinDatosParaValidarException();

            return afiliado.Sexo == incapacidad.Diagnostico.Sexo;
        }

        public async Task<bool> AfiliadoMayorEdadOMenorA18AñosHabilitado(string incapacidadId)
        {
            var incapacidad = await GetAndValidateIncapacidadAsync(incapacidadId);
            var afiliado = await GetAndValidateAfiliadoAsync(incapacidad.AfiliadoId);

            if (afiliado.FechaNacimiento is null)
                throw new SinDatosParaValidarException();

            var mayorEdad = DateTime.Compare(afiliado.FechaNacimiento.Value, DateTime.Now.AddYears(-18)) < 0;

            if (mayorEdad) return true;
            if (!mayorEdad && afiliado.PermisoTrabajo is null)
                throw new SinDatosParaValidarException();

            return !mayorEdad && afiliado.PermisoTrabajo.Value;
        }

        public async Task<bool> EdadAfiliadoMayor85Años(string incapacidadId)
        {
            var incapacidad = await GetAndValidateIncapacidadAsync(incapacidadId);
            var afiliado = await GetAndValidateAfiliadoAsync(incapacidad.AfiliadoId);

            if (afiliado.FechaNacimiento is null)
                throw new SinDatosParaValidarException();
            return DateTime.Compare(afiliado.FechaNacimiento.GetValueOrDefault().Date, DateTime.Now.AddYears(-85).Date) <= 0;
        }

        public async Task<bool> AfiliadoPensionado(string incapacidadId)
        {
            var incapacidad = await GetAndValidateIncapacidadAsync(incapacidadId);
            var afiliado = await GetAndValidateAfiliadoAsync(incapacidad.AfiliadoId);

            if (afiliado.Pensionado is null || afiliado.FechaNacimiento is null)
                throw new SinDatosParaValidarException();

            var mayorA65 = IsGreaterThan(afiliado.FechaNacimiento, DateTime.Now.Date);

            return !afiliado.Pensionado.Value;
        }

        public async Task<bool> IncapacidadMayorA2DiasSinProrroga(string incapacidadId)
        {
            var incapacidad = await GetAndValidateIncapacidadAsync(incapacidadId);

            GuardAgainstNull(incapacidad.FechaInicio);
            GuardAgainstNull(incapacidad.FechaFin);
            GuardAgainstNull(incapacidad.Prorroga);

            int diasIncapacidad = DiasDiferencia(incapacidad.FechaInicio, incapacidad.FechaFin);

            return diasIncapacidad > 2 || incapacidad.Prorroga.GetValueOrDefault();
        }

        public async Task<bool> IncapacidadEntre181y540Dias(string incapacidadId)
        {
            var incapacidad = await GetAndValidateIncapacidadAsync(incapacidadId);

            GuardAgainstNull(incapacidad.FechaInicio);
            GuardAgainstNull(incapacidad.FechaFin);

            int diasIncapacidad = DiasDiferencia(incapacidad.FechaInicio, incapacidad.FechaFin);

            return diasIncapacidad >= 181 && diasIncapacidad <= 540;
        }

        public bool IncapacidadProlongadaMayorOIgualA540Dias(string incapacidadId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> FechaInicioMenorOIgualFechaRadicacion(string incapacidadId)
        {
            var incapacidad = await GetAndValidateIncapacidadAsync(incapacidadId);

            GuardAgainstNull(incapacidad.FechaInicio);
            GuardAgainstNull(incapacidad.FechaRadicacion);

            return IsLowerOrEqualThan(incapacidad.FechaInicio, incapacidad.FechaRadicacion);
        }

        public bool DiasAcumuladosMayoraMaximo(string incapacidadId)
        {
            throw new NotImplementedException();
        }

        public bool DiasAcumuladosMayorAMaximo(string incapacidadId)
        {
            throw new NotImplementedException();
        }
        public bool IncapacidadProlongadaPorDiagnosticosNoRelacinados(string incapacidadId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CalificacionPCLMayorA50(string incapacidadId)
        {
            var incapacidad = await GetAndValidateIncapacidadAsync(incapacidadId);
            var afiliado = await GetAndValidateAfiliadoAsync(incapacidad.AfiliadoId);

            GuardAgainstNull(afiliado.CalificacionPcl);

            return afiliado.CalificacionPcl > 50;
        }

        public async Task<bool> AfiliadoConCHRBDesfavorable(string incapacidadId)
        {
            var incapacidad = await GetAndValidateIncapacidadAsync(incapacidadId);
            var afiliado = await GetAndValidateAfiliadoAsync(incapacidad.AfiliadoId);

            GuardAgainstNull(afiliado.ChrbDesfavorable);

            return !(bool)afiliado.ChrbDesfavorable;
        }

        public bool ExcesoPorDiagnostico(string incapacidadId)
        {
            throw new NotImplementedException();
        }

        public bool EspecialidadMedicaConcuerdaDiagnostico(string incapacidadId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AfiliadoSinCalificacionAtel(string incapacidadId)
        {
            var incapacidad = await GetAndValidateIncapacidadAsync(incapacidadId);
            var afiliado = await GetAndValidateAfiliadoAsync(incapacidad.AfiliadoId);

            GuardAgainstNull(afiliado.CalificacionAtel);

            return !(bool)afiliado.CalificacionAtel;
        }

        public bool UbicacionCorrespondeConAfiliado(string incapacidadId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AfiliadoAsistioATratamientosTerapias(string incapacidadId)
        {
            var incapacidad = await GetAndValidateIncapacidadAsync(incapacidadId);
            var afiliado = await GetAndValidateAfiliadoAsync(incapacidad.AfiliadoId);

            GuardAgainstNull(afiliado.AsisteATratamientos);

            return (bool)afiliado.AsisteATratamientos;
        }

        public async Task<bool> AfiliadoAsistioAExamenesYValoraciones(string incapacidadId)
        {
            var incapacidad = await GetAndValidateIncapacidadAsync(incapacidadId);
            var afiliado = await GetAndValidateAfiliadoAsync(incapacidad.AfiliadoId);

            GuardAgainstNull(afiliado.AsisteAExamenes);

            return (bool)afiliado.AsisteAExamenes;
        }

        public async Task<bool> SinPresuntaAlteracionOFraude(string incapacidadId)
        {
            var incapacidad = await GetAndValidateIncapacidadAsync(incapacidadId);

            GuardAgainstNull(incapacidad.AlteracionOFraude);

            return (bool)!incapacidad.AlteracionOFraude;
        }

        public async Task<bool> AfiliadoSinConductasContrariasAEstadoDeSalud(string incapacidadId)
        {
            var incapacidad = await GetAndValidateIncapacidadAsync(incapacidadId);
            var afiliado = await GetAndValidateAfiliadoAsync(incapacidad.AfiliadoId);

            GuardAgainstNull(afiliado.ConductasContrarias);

            return !(bool)afiliado.ConductasContrarias;
        }

        public async Task<bool> AfiliadoSinActividadImpideSuRecuperacion(string incapacidadId)
        {
            var incapacidad = await GetAndValidateIncapacidadAsync(incapacidadId);
            var afiliado = await GetAndValidateAfiliadoAsync(incapacidad.AfiliadoId);

            GuardAgainstNull(afiliado.ActividadimpideRecuperacion);

            return !(bool)afiliado.ActividadimpideRecuperacion;
        }

        public async Task<bool> SinFraudeAlOtorgarIncapacidad(string incapacidadId)
        {
            var incapacidad = await GetAndValidateIncapacidadAsync(incapacidadId);

            GuardAgainstNull(incapacidad.FraudeEnOtorgacion);

            return (bool)!incapacidad.FraudeEnOtorgacion;
        }

        public bool IncapacidadGenerandoDobleCobro(string incapacidadId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AfiliadoSinCobroConDatosFalsos(string incapacidadId)
        {
            var incapacidad = await GetAndValidateIncapacidadAsync(incapacidadId);
            var afiliado = await GetAndValidateAfiliadoAsync(incapacidad.AfiliadoId);

            GuardAgainstNull(afiliado.DatosFalsos);

            return !(bool)afiliado.DatosFalsos;
        }

        public async Task<bool> IncapacidadSinDobleCobro(string incapacidadId)
        {
            var incapacidad = await GetAndValidateIncapacidadAsync(incapacidadId);

            GuardAgainstNull(incapacidad.DobleCobro);

            return !(bool)incapacidad.DobleCobro;
        }

        #region HelperMethods
        private async Task<Ips> GetAndValidateIpsAsync(string IpsNit)
        {
            var ips = await _ipsRepo.GetByIdAsync(IpsNit);

            if (ips is null) throw new IpsNotFoundException($"Couldn't find Ips with Nit: {IpsNit}");

            return ips;
        }

        private async Task<Afiliado> GetAndValidateAfiliadoAsync(Guid afiliadoId)
        {
            var afiliado = await _afiliadoRepo.GetByIdAsync(afiliadoId);

            if (afiliado is null) throw new AfiliadoNotFoundException($"Couldn't find afiliado with id: {afiliadoId}");

            return afiliado;
        }

        private async Task<Incapacidad> GetAndValidateIncapacidadAsync(string incapacidadId)
        {
            var incapacidad = await _incapacidadRepo.GetByIdAsync(incapacidadId);

            if (incapacidad is null) throw new IncapacidadNotFoundException($"Couldn't find incapacidad with id: {incapacidadId}");

            return incapacidad;
        }

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