using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.UnitTests.ApplicationCore.Services
{
    public static class AfiliadoMayorA85AñosTestData
    {
        public static IEnumerable<object[]> TestData
        {
            get
            {
                yield return new object[] { DateTime.Now, false };
                yield return new object[] { DateTime.Now.AddYears(-10), false };
                yield return new object[] { DateTime.Now.AddYears(-96), true };
                yield return new object[] { DateTime.Now.AddYears(-82), false };
                yield return new object[] { DateTime.Now.AddYears(-90), true };
            }
        }
    }
}
