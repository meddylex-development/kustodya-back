using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.Medicos.Services
{
    public static class ExtensionesServicioModeloEntrada
    {
        public static void AgregarModeloEntrada(this IServiceCollection servicios)
        {
            servicios.AddScoped<IServicioModeloDeEntrada, ServicioModeloDeEntrada>();
        }
    }
}
