using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Models.Contabilidades
{
    public class PlantillaOutputModel
    {
        public Guid Id { get; set; }
        public string TipoPlantilla { get; set; }
        public string Texto { get; set; }
    }
}
