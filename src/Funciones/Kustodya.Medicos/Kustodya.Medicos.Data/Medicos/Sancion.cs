using System;

namespace Kustodya.Medicos.Data
{
    public class Sancion : BaseEntity
    {
        public string InstanciaEmiteFallo { get; set; }
        public string CodigoTipoSancion { get; set; }
        public DateTime FechaEjecucion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FehaFin { get; set; }
    }
}
