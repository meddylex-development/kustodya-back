using System;
using Kustodya.ApplicationCore.DTOs.MallaValidadora.ModelosDeEntrada;
using System.Collections.Generic;
using Xunit.Sdk;
using System.Reflection;
using System.IO;
using Kustodya.ApplicationCore.Entities.MallaValidadora;

namespace Kustodya.UnitTests.Homologacion.Famisanar
{
    public class DatosDePruebaDeHomologacion : DataAttribute
    {
        private const string Pagina = "ServicioDeHomologacion/Pagina.json";

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[]
            {
                // TODO: [PK-630] Modificar valores de tipo de afiliación segun los datos que se exportan desde famisanar
                File.ReadAllText(Pagina),
                new IncapacidadInputModel()
                {
                    FechaInicio = new DateTime(2000, 5, 27, 14, 0, 21),
                    FechaAfiliacion = new DateTime(2000, 5, 27, 14, 0, 21),
                    FechaRadicacion = new DateTime(2000, 5, 27, 14, 0, 21),
                    IpsNit = "830.003.564-7",
                    Afiliado =  new AfiliadoInputModel()
                    {
                        FechaNacimiento = new DateTime(2000, 5, 27, 14, 0, 21),
                        TipoAfiliacion = Afiliado.TiposAfiliacion.Beneficiario
                    }
                }
            };
        }
    }
}