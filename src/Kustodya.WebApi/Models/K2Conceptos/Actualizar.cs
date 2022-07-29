using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Models.K2Conceptos
{
    public class Actualizar
    {
        public int Id { get; set; }
        public string ResumenHistoriaClinica { get; set; }
        public int FinalidadTratamientos { get; set; }
        public bool EsFarmacologico { get; set; }
        public bool EsTerapiaOcupacional { get; set; }
        public bool EsFonoaudiologia { get; set; }
        public bool EsQuirurgico { get; set; }
        public bool EsTerapiaFisica { get; set; }
        public bool EsOtrosTratamientos { get; set; }
        public string DescripcionOtrosTratamientos { get; set; }
        public int PlazoCorto { get; set; }
        public int PlazoMediano { get; set; }
        public int Concepto { get; set; }
        public string RemisionAdministradoraFondoPension { get; set; }
        public int Progreso { get; set; }
        public int IdAfp { get; set; }
        public string tAsunto { get; set; }
        public string tDireccionPaciente { get; set; }
        public string tTelefonoPaciente { get; set; }
        public int iIDCiudad { get; set; }
        public string tEmailPaciente { get; set; }
    }
}
