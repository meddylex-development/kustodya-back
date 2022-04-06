using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.UnitTests.ApplicationCore.Services
{
    public static class IncapacidadMayorOIgualA2DiasTestData
    {
        public static IEnumerable<object[]> TestData
        {
            get
            {
                //                        |         Facha Inicio         |           FechaFin           |    Prorroga    |    Valido   |
                yield return new object[] { DateTime.Now.Date.AddDays(-1),  DateTime.Now.Date,                 false,          false   };
                yield return new object[] { DateTime.Now.Date.AddDays(-1),  DateTime.Now.Date,                 true,           true    };
                yield return new object[] { DateTime.Now.Date.AddDays(-2),  DateTime.Now.Date,                 false,          false   };
                yield return new object[] { DateTime.Now.Date.AddDays(-2),  DateTime.Now.Date,                 true,           true    };
                yield return new object[] { DateTime.Now.Date,              DateTime.Now.Date.AddDays(3),      false,          true    };
                yield return new object[] { DateTime.Now.Date,              DateTime.Now.Date.AddDays(3),      true,           true    };
                yield return new object[] { DateTime.Now.Date.AddDays(-10), DateTime.Now.Date.AddDays(-3),     false,          true    };
                yield return new object[] { DateTime.Now.Date.AddDays(-10), DateTime.Now.Date.AddDays(-3),     true,           true   };
            }                                                                                                  
        }
    }
}
