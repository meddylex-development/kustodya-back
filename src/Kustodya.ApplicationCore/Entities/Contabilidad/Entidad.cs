using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.Contabilidades
{
    public class Entidad
    {
        public int Id { get; private set; }
        public int? GerentePorDefectoId { get; private set; }
        public int? CoordinadorPorDefectoId { get; private set; }
        public int? InterventorPorDefectoId { get; private set; }
        public int? AprobadorPorDefectoId { get; private set; }
        public string TarjetaProfessionalContador1 { get; set; }
        public string TarjetaProfessionalContador2 { get; set; }
        public int? AprobadorContabilidad_1 { get; set; }
        public int? AprobadorContabilidad_2 { get; set; }
        public int? AprobadorOperativo_1 { get; set; }
        public int? AprobadorOperativo_2 { get; set; }
        public string Logo { get; private set; }
        public ICollection<Contabilidad> Contabilidades { get; private set; }

        public bool TieneAprobadoresPorDefecto()
        {
            return GerentePorDefectoId != null && CoordinadorPorDefectoId != null && InterventorPorDefectoId != null;
        }
    }
}
