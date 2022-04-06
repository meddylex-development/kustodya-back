using Kustodya.ApplicationCore.Entities.Contabilidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.DTOs.Contabilidades
{
    public class PlantillaInputModel
    {
        public int TipoPlantilla { get; set; }
        public string Texto { get; set; }
    }
}
