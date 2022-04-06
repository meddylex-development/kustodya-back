using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kustodya.ApplicationCore.Entities.MallaValidadora;
using Kustodya.ApplicationCore.Helpers;

namespace Kustodya.ApplicationCore.Specifications.Incapacidades
{
    public class IncapacidadInmediatamenteCorrelacionada : BaseSpec<Incapacidad>
    {
        /// <summary>
        /// Retorna una especificacion para las incapacidades relacionadas e inmedieatamento correladionadas
        /// </summary>
        /// <param name="CodigoCie10">Codigo CIE10 del diagnostico de una incapacidad</param>
        /// <param name="inicio">Fecha de inicio de la incapacidad</param>
        public IncapacidadInmediatamenteCorrelacionada(string CodigoCie10, DateTime inicio)
                : base(incapacidadPasada =>
                    // Cuya fecha de inicio es mayor a la fecha de inicio de la incapacidad
                    incapacidadPasada.InicioMenorA30Dias(inicio)
                    // Y una de dos:
                    &&
                    // Su diagnostico tiene el CodigoCie10 (Relacionadas)
                    (incapacidadPasada.CodigoCie10 == CodigoCie10
                    // O su codigo CIE10 esta contenido dentro de alguno de los grupos a los que pertenece incapacidad actual
                    || incapacidadPasada.ContieneCorrelacionConCodigo(CodigoCie10))
                )
        {
            // Que se necesita consultar?
            base.AddIncludes(query => query.Include(i => i.Diagnostico)
                                           .ThenInclude(d => d.GrupoDiagnosticos));
            //.ThenInclude(gd => gd.Grupo)); <-- Incluyendo 3er nivel si se necesita
        }

        /// <summary>
        /// Retorna una especificacion para las incapacidades relacionadas e inmedieatamento correladionadas
        /// </summary>
        /// <param name="incapacidad">
        /// Incapacidad de la que se quiere encontrar las incapacidades inmediatamente correlacionadas
        /// </param>
        public IncapacidadInmediatamenteCorrelacionada(Incapacidad incapacidad)
                : base(
                    incapacidadPasada =>
                    // Cuya fecha de inicio es mayor a la fecha de inicio de la incapacidad
                    incapacidadPasada.InicioMenorA30Dias(incapacidad.Inicio.GetValueOrDefault())
                    // Y cumple una de las siguiente condiciones:
                    &&
                    (
                        // Su diagnostico tiene el mismo CodigoCie10 (Relacionadas)
                        incapacidadPasada.Diagnostico.CodigoCie10 == incapacidad.Diagnostico.CodigoCie10
                        ||
                        // O alguna de sus correlaciones tiene el mismo CodigoCie10 de la incapacidad (Correlacionadas)
                        // O su codigo CIE10 esta contenido dentro de alguno de los grupos de la incapacidad
                        incapacidadPasada.ContieneCorrelacionConCodigo(incapacidad.Diagnostico.CodigoCie10)
                    )
                )
        {
            // Que se necesita consultar?
            base.AddInclude(i => i.Diagnostico);
            base.AddInclude(i => i.Diagnostico.GrupoDiagnosticos);
        }


    }

    public static class ExtensionesIncapacidades
    {
        public static bool ContieneCorrelacionConCodigo(this Incapacidad incapacidadPasada, string CodigoCie10)
        {
            var codigosCorrelacionados = incapacidadPasada.Diagnostico.GrupoDiagnosticos.Select(c => c.CodigoDelDiagnostico);
            return codigosCorrelacionados.Contains(CodigoCie10);
        }

        public static bool ContieneCorrelacionConCodigo(this Incapacidad incapacidadPasada, Incapacidad incapacidad)
        {
            var codigosCorrelacionados = incapacidad.Diagnostico.GrupoDiagnosticos.Select(c => c.CodigoDelDiagnostico);
            return codigosCorrelacionados.Contains(incapacidadPasada.Diagnostico.CodigoCie10);
        }

        public static bool InicioMenorA30Dias(this Incapacidad incapacidadPasada, DateTime inicio)
        {
            return incapacidadPasada.Inicio >= FechaHace30Dias(inicio);
        }
        private static DateTime FechaHace30Dias(DateTime? dateTime)
        {
            return dateTime.GetValueOrDefault().Date.AddDays(-30);
        }
    }
}
