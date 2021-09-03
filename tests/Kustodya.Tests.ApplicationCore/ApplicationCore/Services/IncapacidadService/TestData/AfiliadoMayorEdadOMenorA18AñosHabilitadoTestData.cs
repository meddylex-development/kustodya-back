using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.UnitTests.ApplicationCore.Services
{
    public static class AfiliadoMayorEdadOMenorA18AñosHabilitadoTestData
    {
        public static IEnumerable<object[]> TestData
        {
            get
            {
                yield return new object[] { DateTime.Now.Date, false, false };
                yield return new object[] { DateTime.Now.Date.AddYears(-10), false, false };
                yield return new object[] { DateTime.Now.Date.AddYears(-14), false, false };
                yield return new object[] { DateTime.Now.Date.AddYears(-16), true, true };
                yield return new object[] { DateTime.Now.Date.AddYears(-22), false, true };
                yield return new object[] { DateTime.Now.Date.AddYears(-20), false, true };
            }
        }
    }
}
