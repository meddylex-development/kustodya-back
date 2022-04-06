using Kustodya.ApplicationCore.Entities.MallaValidadora;
using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace Kustodya.UnitTests.ApplicationCore.Entities
{
    public class IncapacidadInmediatamenteCorrelacionadaTestData : DataAttribute
    {
        readonly static DateTime Hace40Dias = DateTime.Now.Date.AddDays(-40);
        readonly static DateTime Hace20Dias = DateTime.Now.Date.AddDays(-20);

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] {
                new Incapacidad { Diagnostico = new Diagnostico("A900", "Dolor de cabeza") { GrupoDiagnosticos = GetGrupoDiagnosticosDePrueba() }, Inicio = Hace20Dias } };
        }

        private static ICollection<GrupoDiagnostico> GetGrupoDiagnosticosDePrueba()
        {
            DateTime Hace30Dias = DateTime.Now.Date.AddDays(-10);

            var Gripa = new Diagnostico("G100", "Gripa");
            var DolorDeCabeza = new Diagnostico("D500", "Dolor de Cabeza");
            var DolorDeGarganta = new Diagnostico("DG05", "Dolor de Garganta");
            var Malestar = new Diagnostico("M889", "Malestar general");

            var DolorDeEstomago = new Diagnostico("E345", "Dolor de Estomago");
            var Vomito = new Diagnostico("V211", "Vomito");
            var Nauseas = new Diagnostico("N600", "Nauseas");
            var Deshidratacion = new Diagnostico("D200", "Deshidratacion");

            Grupo A = new Grupo("A");
            Grupo B = new Grupo("B");

            var grupoDiagnosticosA = new List<GrupoDiagnostico> { new GrupoDiagnostico(Gripa, A),
                                                                 new GrupoDiagnostico(DolorDeCabeza, A),
                                                                 new GrupoDiagnostico(DolorDeGarganta, A),
                                                                 new GrupoDiagnostico(Malestar, A)};

            var grupoDiagnosticosB = new List<GrupoDiagnostico> { new GrupoDiagnostico(DolorDeEstomago, B),
                                                                 new GrupoDiagnostico(Vomito, B),
                                                                 new GrupoDiagnostico(Nauseas, B),
                                                                 new GrupoDiagnostico(Deshidratacion, B),
                                                                 new GrupoDiagnostico(Malestar, B)};

            var incapacidad1 = new Incapacidad() { Diagnostico = Gripa, Inicio = Hace40Dias };
            var incapacidad2 = new Incapacidad() { Diagnostico = Gripa, Inicio = Hace40Dias };
            var incapacidad3 = new Incapacidad() { Diagnostico = Gripa, Inicio = Hace40Dias };
            var incapacidad4 = new Incapacidad() { Diagnostico = Gripa, Inicio = Hace40Dias };

            return grupoDiagnosticosA;
        }

        public static List<Incapacidad> GetIncapacidadesDePrueba()
        {
            var Gripa = new Diagnostico("G100", "Gripa");
            Gripa.GrupoDiagnosticos = GetGrupoDiagnosticosDePrueba();
            DateTime Hace40Dias = DateTime.Now.Date.AddDays(-10);

            return new List<Incapacidad> {
                new Incapacidad { Diagnostico = Gripa, Inicio = Hace40Dias },
                new Incapacidad { Diagnostico = Gripa, Inicio = Hace40Dias },
                new Incapacidad { Diagnostico = Gripa, Inicio = Hace40Dias },
                new Incapacidad { Diagnostico = Gripa, Inicio = Hace40Dias } };
        }

        private static IEnumerable<Diagnostico> GetDiagnosticosDePrueba()
        {
            yield return new Diagnostico("G100", "Gripa");
            yield return new Diagnostico("D500", "Dolor de Cabeza");
            yield return new Diagnostico("DG05", "Dolor de Garganta");
            yield return new Diagnostico("M889", "Malestar general");
            yield return new Diagnostico("M889", "Dolor de Estomago");
            yield return new Diagnostico("M889", "Vomito");
            yield return new Diagnostico("M889", "Nauseas");
            yield return new Diagnostico("M889", "Deshidratacion");
        }
    }
}
