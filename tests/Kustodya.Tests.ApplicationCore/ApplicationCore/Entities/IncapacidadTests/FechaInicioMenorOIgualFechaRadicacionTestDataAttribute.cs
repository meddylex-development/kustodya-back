using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;
using Kustodya.ApplicationCore.Entities.MallaValidadora;

namespace Kustodya.UnitTests.ApplicationCore.Entities
{
internal class FechaInicioMenorOIgualFechaRadicacionTestData : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[] {
            new Incapacidad {
                FechaInicio = DateTime.Now.Date.AddDays(-1).Date,
                FechaRadicacion = DateTime.Now.Date
                },
            true
            };
        yield return new object[] {
            new Incapacidad {
                FechaInicio = DateTime.Now.Date,
                FechaRadicacion = DateTime.Now.Date
                },
            true
            };
        yield return new object[] {
            new Incapacidad {
                FechaInicio = DateTime.Now.Date.AddDays(-5),
                FechaRadicacion = DateTime.Now.Date.AddDays(-5)
            },
            true
            };
        yield return new object[] {
            new Incapacidad {
                FechaInicio = DateTime.Now.Date,
                FechaRadicacion = DateTime.Now.Date.AddDays(-2)
                },
            false
            };
        yield return new object[] {
            new Incapacidad {
                FechaInicio = DateTime.Now.Date.AddDays(-10),
                FechaRadicacion = DateTime.Now.Date.AddDays(-13)
            }, 
            false 
        };
    }
}
}