using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.UnitTests.ApplicationCore.Services
{
    public static class AfiliadoPensionadoTestData
    {
        public static IEnumerable<object[]> TestData
        {
            get
            {
                //                          |       Fecha Nacimiento        |   Pensionado  |   Valido  |
                yield return new object[] { DateTime.Now.Date.AddYears(-10),    false,          true    };
                yield return new object[] { DateTime.Now.Date.AddYears(-14),    true,           false   };
                yield return new object[] { DateTime.Now.Date.AddYears(-76),    true,           false   };
                yield return new object[] { DateTime.Now.Date.AddYears(-72),    false,          true    };
            }
        }
    }
}
