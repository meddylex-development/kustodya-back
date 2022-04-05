using System;
using System.Collections.Generic;

namespace Kustodya.UnitTests.ApplicationCore.Services
{
    public class FechaInicioMenorOIgualFechaRadicacionTestData
    {
        public static IEnumerable<object[]> TestData
        {
            get
            {
                yield return new object[] { DateTime.Now.Date.AddDays(-1).Date, DateTime.Now.Date, true };
                yield return new object[] { DateTime.Now.Date, DateTime.Now.Date, true };
                yield return new object[] { DateTime.Now.Date.AddDays(-5), DateTime.Now.Date.AddDays(-5), true };
                yield return new object[] { DateTime.Now.Date, DateTime.Now.Date.AddDays(-2), false };
                yield return new object[] { DateTime.Now.Date.AddDays(-10), DateTime.Now.Date.AddDays(-13), false };
            }
        }
    }
}