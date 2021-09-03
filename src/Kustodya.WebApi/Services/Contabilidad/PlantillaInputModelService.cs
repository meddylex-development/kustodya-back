using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Services.Contabilidades
{
    public class PlantillaInputModelService : IPlantillaInputModelService
    {
        public void ValidarComodines(string texto)
        {
            string[] comodinesValidos = { "{{NIT}}", "{{Fecha_doc}}", "{{Valor_ter}}", "{{Nombre}}", "{{Fecha_hoy}}", "{{Valor}}", "{{NombreTercero}}", "{{FechaIncapacidad}}", "{{NroIncapacidad}}", "{{FechaRadicacion}}", "{{NivelEscolaridadEnfermero}}", "{{NombreMedico}}", "{{RegistroMedico}}" };
            var reg = new Regex("{{.*?}}");
            var matches = reg.Matches(texto);
            foreach (var item in matches)
            {
                if (!comodinesValidos.Contains(item.ToString()))
                    throw new Exception("El comodín " + item.ToString() + " no es un comodín válido. " +
                        "Comodines válidos: {{NIT}},{{Fecha_doc}},{{ Valor_ter}},{{Nombre}},{{Fecha_hoy}},{{Valor}},{{NombreTercero}},{{FechaIncapacidad}}," +
                        "{{NroIncapacidad}},{{FechaRadicacion}},{{NivelEscolaridadEnfermero}},{{NombreMedico}},{{RegistroMedico}}");
            }
            
        }
    }
}
