using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.UnitTests.ApplicationCore.Services
{
    public static class AfiliadoCotizaMasDe4SemanasTestData
    {
        public static IEnumerable<object[]> TestData
        {
            get
            {
                yield return new object[] { DateTime.Now.Date, false };
                yield return new object[] { DateTime.Now.Date.AddDays(-10), false };
                yield return new object[] { DateTime.Now.Date.AddDays(-10), false };
                yield return new object[] { DateTime.Now.Date.AddDays(-20), false };
                yield return new object[] { DateTime.Now.Date.AddDays(-30), true };
                yield return new object[] { DateTime.Now.Date.AddDays(-50), true };
                yield return new object[] { DateTime.Now.Date.AddDays(-500), true };
                yield return new object[] { DateTime.Now.Date.AddDays(50), false };
            }
        }
    }
}
