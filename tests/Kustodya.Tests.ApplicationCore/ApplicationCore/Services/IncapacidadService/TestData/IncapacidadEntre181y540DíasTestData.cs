using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.UnitTests.ApplicationCore.Services
{
    public static class IncapacidadEntre181y540DiasTestData
    {
        public static IEnumerable<object[]> TestData
        {
            get
            {
                yield return new object[] { DateTime.Now.Date.AddDays(-180), DateTime.Now.Date, false };
                yield return new object[] { DateTime.Now.Date.AddDays(-10), DateTime.Now.Date.AddDays(-2), false };
                yield return new object[] { DateTime.Now.Date.AddDays(-100), DateTime.Now.Date.AddDays(81), true };
                yield return new object[] { DateTime.Now.Date, DateTime.Now.Date.AddDays(200), true };
            }
        }
    }
}