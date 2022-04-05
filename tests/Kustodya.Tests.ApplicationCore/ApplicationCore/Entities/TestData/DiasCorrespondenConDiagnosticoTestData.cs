using System;
using System.Collections.Generic;
using System.Text;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Services;
using Moq;
using System.Threading.Tasks;
using Xunit;
using Kustodya.ApplicationCore.Entities.MallaValidadora;

namespace Kustodya.UnitTests.ApplicationCore.Entities
{
    public static class DiasCorrespondenConDiagnosticoTestData
    {
        public static IEnumerable<object[]> TestData
        {
            get
            {

                //                        |
                yield return new object[] { new Incapacidad { CodigoCie10 = "15", FechaInicio = DateTime.Now.Date.AddDays(-20), FechaFin = DateTime.Now.Date, Diagnostico = new Diagnostico() { CodigoCie10 = "15", DiasMaxConsulta = 19 } }, false };
                yield return new object[] { new Incapacidad { CodigoCie10 = "15", FechaInicio = DateTime.Now.Date.AddDays(-20), FechaFin = DateTime.Now.Date, Diagnostico = new Diagnostico() { CodigoCie10 = "15", DiasMaxConsulta = 20 } }, true };
                yield return new object[] { new Incapacidad { CodigoCie10 = "15", FechaInicio = DateTime.Now.Date.AddDays(-20), FechaFin = DateTime.Now.Date, Diagnostico = new Diagnostico() { CodigoCie10 = "15", DiasMaxConsulta = 21 } }, true };
                yield return new object[] { new Incapacidad { CodigoCie10 = "15", FechaInicio = DateTime.Now.Date.AddDays(-20), FechaFin = DateTime.Now.Date, Diagnostico = new Diagnostico() { CodigoCie10 = "15", DiasMaxConsulta = 10 } }, false };
            }
        }

        public static IEnumerable<object[]> NullDataTestData
        {
            get
            {
                //                        |
                yield return new object[] { new Incapacidad { FechaInicio = null, FechaFin = DateTime.Now, CodigoCie10 = null } };
                yield return new object[] { new Incapacidad { FechaInicio = DateTime.Now, CodigoCie10 = null } };
                yield return new object[] { new Incapacidad { FechaInicio = DateTime.Now, FechaFin = DateTime.Now, CodigoCie10 = null } };
                yield return new object[] { new Incapacidad { CodigoCie10 = "15", Diagnostico = null } };
            }
        }
    }
}
