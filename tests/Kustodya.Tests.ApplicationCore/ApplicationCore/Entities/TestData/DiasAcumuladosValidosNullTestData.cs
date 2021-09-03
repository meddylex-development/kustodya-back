using Kustodya.ApplicationCore.Entities.MallaValidadora;
using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace Kustodya.UnitTests.ApplicationCore.Entities
{
    public class DiasAcumuladosValidosNullTestData : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            //  Id  |   Dias Acumulados     |       Maximo de dias acumulados por diagnostico       |   Valido  |
            yield return new object[] { new Incapacidad
                    { DiasAcumulados = null, Diagnostico = new Diagnostico { DiasMaxAcumulados = 15 } } };
            yield return new object[] { new Incapacidad
                    { DiasAcumulados = 15, Diagnostico = null } };
            yield return new object[] { new Incapacidad
                    { DiasAcumulados = 15, Diagnostico = new Diagnostico { DiasMaxAcumulados = null } } };
        }
    }
}
