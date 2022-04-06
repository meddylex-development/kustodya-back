using Kustodya.ApplicationCore.Entities.MallaValidadora;
using Kustodya.ApplicationCore.Constants;
using System;
using System.Collections.Generic;

namespace Kustodya.UnitTests.ApplicationCore.Services
{
    public class EdadAfiliadoIgualAEdadDiagnosticoTestData
    {
        public static IEnumerable<object[]> TestData
        {
            get
            {
                //                        |           Incapacidad                |                             Diagnostico                        |          Valido          |
                yield return new object[] { DateTime.Now.Date.AddMonths( -1 * 12), new Diagnostico() { EdadMinima = 10 * 12 },                                false          };
                yield return new object[] { DateTime.Now.Date.AddMonths(-11 * 12), new Diagnostico() { EdadMinima = 10 * 12 },                                true           };
                yield return new object[] { DateTime.Now.Date.AddMonths(-15 * 12), new Diagnostico() { EdadMinima = 10 * 12, EdadMaxima = 16 * 12 },          true           };
                yield return new object[] { DateTime.Now.Date.AddMonths(-16 * 12), new Diagnostico() { EdadMinima = 10 * 12, EdadMaxima = 16 * 12 },          true           };
                yield return new object[] { DateTime.Now.Date.AddMonths(-28 * 12), new Diagnostico() { EdadMinima = 10 * 12, EdadMaxima = 20 * 12 },          false          };
                yield return new object[] { DateTime.Now.Date.AddMonths(-75 * 12), new Diagnostico() { EdadMaxima = 70 * 12 },                                false          };
            }
        }
    }
}