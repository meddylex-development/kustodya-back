using System;
using System.Collections.Generic;

namespace Roojo.Rethus
{
    public partial class Sancion
    {
        public int Id { get; set; }
        public int? ConsultaId { get; set; }
        public string InstanciaEmiteFallo { get; set; }
        public string CodigoTipoSancion { get; set; }
        public string FechaEjecucion { get; set; }
        public string FechaInicio { get; set; }
        public string FehaFin { get; set; }

        public static class Nueva
        {
            public static Sancion DePrueba(int idDeLaConsulta)
            {
                return new Sancion
                {
                    Id = 10,
                    CodigoTipoSancion = "1",
                    InstanciaEmiteFallo = "TRIBUNAL SECCIONAL DE ETICA MEDICA DE CUNDINAMARCA",
                    ConsultaId = idDeLaConsulta,
                    FechaEjecucion = "2018-08-28",
                    FechaInicio = "2018-12-04",
                    FehaFin = "2018-12-08"
                };
            }
        }
    }
}
