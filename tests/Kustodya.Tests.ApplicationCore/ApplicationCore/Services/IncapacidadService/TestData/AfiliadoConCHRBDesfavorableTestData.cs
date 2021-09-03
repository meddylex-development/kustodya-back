using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.UnitTests.ApplicationCore.Services
{
    public class AfiliadoConCHRBDesfavorableTestData
    {
        public static IEnumerable<object[]> TestData
        {
            get
            {
                //                        |    CHRB Desfavorable   |    Valido  |
                yield return new object[] {         false,              true    };
                yield return new object[] {         true,               false   };
            }
        }
    }
}
