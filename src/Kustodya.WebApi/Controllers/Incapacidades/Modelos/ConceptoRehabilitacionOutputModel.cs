using Kustodya.ApplicationCore.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Controllers.Incapacidades.Modelos
{
    public class ConceptoRehabilitacionOutputModel
    {
        public int diasAcumulados {get;set;}
        public int conceptosEmitidos { get; set; }
        public int PCLCalificados { get; set; }
        public string apellidos { get; set; }
        public string nombres { get; set; }
        public string tipoDocumento { get; set; }
        public string numeroDocumento { get; set; }
        public double? fechaNacimiento { get; set; }
        public double? fechaEmision { get; set; }
        public int? edad { get; set; }
        public string ARL { get; set; }
        public string AFP { get; set; }
        public string EPS { get; set; }
        public string codigoCorto { get; set; }
        public List<DiagnosticosOutputModel> diagnosticos { get; set; }
        public List<SecuelasOutputModel> secuelas { get; set; }
        public string historiaClinica { get; set; }
        public int finalidadTratmamiento { get; set; }
        public bool Farmacologico { get; set; }
        public bool terapiaOcupacional { get; set; }
        public bool fonoAudiologia { get; set; }
        public bool quirurgico { get; set; }
        public bool terapiaFisica { get; set; }
        public bool otrosTramites { get; set; }
        public string otrosTratamientos { get; set; }
        public int cortoPlazo { get; set; }
        public int medianoPlazo { get; set; }
        public int concepto { get; set; }
        public string RemisionAdministradoraFondoPension { get; set; }
    }
}

