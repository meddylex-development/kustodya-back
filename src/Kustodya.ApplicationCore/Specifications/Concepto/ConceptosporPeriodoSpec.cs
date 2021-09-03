using Kustodya.ApplicationCore.Entities.Concepto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Specifications.Concepto
{
    public class ConceptosporPeriodoSpec : BaseSpec<PacientesPorEmitir>
    {
        public ConceptosporPeriodoSpec(string periodo, int desdeellunes, DateTime anyoInicio, DateTime anyoFin, DateTime mesInicio, DateTime mesFin)
                : base(u => (periodo == "hoy" ? u.FechaAsignacion.Date == DateTime.Now.Date : true) &&
                (periodo == "semana" ? u.FechaAsignacion > DateTime.Now.Date.AddDays(-(desdeellunes - 1)) : true) &&
                (periodo == "mes" ? (u.FechaAsignacion > mesInicio && 
                u.FechaAsignacion < mesFin) : true) &&
                (periodo == "año" ? (u.FechaAsignacion > anyoInicio &&
                u.FechaAsignacion < anyoFin) : true))
        {
        
        }
        /*public ConceptosporPeriodoSpec(string periodo, int desdeellunes)
                : base(u => u.FechaAsignacion.Date > DateTime.Now.Date.AddDays(-(desdeellunes - 1)))
        {

        }*/
    }
}