using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.Contabilidades
{
    public class CentroCosto : BaseEntity
    {
        private CentroCosto() { 
        
        }
        public CentroCosto(
            Guid contabilidadId,
            string codigo,
            string descripcion,
            Guid regionalId,
            Guid segmentoId)
        {
            Codigo = codigo;
            Descripcion = descripcion;
            ContabilidadId = contabilidadId;
            RegionalId = regionalId;
            SegmentoId = segmentoId;
        }
        public Guid ContabilidadId { get; set; }
        public Guid? SegmentoId { get; set; }
        public Guid? RegionalId { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }

        public Segmento Segmento { get; set; }
        public Regional Regional { get; set; }
        public Contabilidad Contabilidad { get; set; }
    }
}
