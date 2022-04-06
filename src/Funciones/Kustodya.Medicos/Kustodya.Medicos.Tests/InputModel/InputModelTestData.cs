using Kustodya.Medicos.Input;
using Kustodya.Medicos.Services.Input;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit.Sdk;
using Kustodya.ApplicationCore.Constants;

namespace Kustodya.Medicos.Tests
{
    public class InputModelTestData : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { new List<Input.ResultadoDeMapeo>
            {
                new Input.ResultadoDeMapeo() { EsValido = false, Registro = new Registro("1A1111", TipoIdentificacion.Cédula_de_ciudadanía), IndiceDeFila = 0  },
                new Input.ResultadoDeMapeo() { EsValido = false, Registro = new Registro("1A1111", TipoIdentificacion.Cédula_de_ciudadanía), IndiceDeFila = 1  },
                new Input.ResultadoDeMapeo() { EsValido = false, Registro = new Registro("1A1111", TipoIdentificacion.Cédula_de_ciudadanía), IndiceDeFila = 2  },
                new Input.ResultadoDeMapeo() { EsValido = true,  Registro = new Registro("222222", TipoIdentificacion.Cédula_de_ciudadanía), IndiceDeFila = 3  },
                new Input.ResultadoDeMapeo() { EsValido = true,  Registro = new Registro("222222", TipoIdentificacion.Cédula_de_ciudadanía), IndiceDeFila = 4  },
                new Input.ResultadoDeMapeo() { EsValido = false, Registro = new Registro("1A1111", TipoIdentificacion.Cédula_de_ciudadanía), IndiceDeFila = 5  },
                new Input.ResultadoDeMapeo() { EsValido = true,  Registro = new Registro("333333", TipoIdentificacion.Cédula_de_ciudadanía), IndiceDeFila = 6  },
                new Input.ResultadoDeMapeo() { EsValido = true,  Registro = new Registro("444444", TipoIdentificacion.Cédula_de_ciudadanía), IndiceDeFila = 7  },
                new Input.ResultadoDeMapeo() { EsValido = true,  Registro = new Registro("444444", TipoIdentificacion.Cédula_de_ciudadanía), IndiceDeFila = 8  },
                new Input.ResultadoDeMapeo() { EsValido = false, Registro = new Registro("0",      TipoIdentificacion.Cédula_de_ciudadanía), IndiceDeFila = 9  },
                new Input.ResultadoDeMapeo() { EsValido = false, Registro = new Registro("0",      TipoIdentificacion.Cédula_de_ciudadanía), IndiceDeFila = 10 } 
            } };
        }
    }
}
