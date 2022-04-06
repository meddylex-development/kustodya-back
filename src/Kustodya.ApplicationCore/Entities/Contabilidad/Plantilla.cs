using Kustodya.ApplicationCore.Entities.Administracion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.Contabilidades
{
    public class Plantilla : BaseEntity
    {
        private Plantilla() { 
        }
        public Plantilla(int entidadId, TiposPlantillaContable tipoPlantilla, string texto)
        {
            EntidadId = entidadId;
            TipoPlantilla = tipoPlantilla;
            Texto = texto;
        }
        public int EntidadId { get; set; }
        public TiposPlantillaContable TipoPlantilla { get; set; }
        public string Texto { get; set; }

        public enum TiposPlantillaContable
        {
            Situación_encontrada = 1,
            Acciones_reales = 2,
            Disposiciones_legales = 3,
            Recomendaciones = 4,
            Anexos = 5
        }
    }
}
