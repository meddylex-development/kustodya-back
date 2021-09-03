using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.Homologacion.Famisanar.ModelosDeEntrada
{
    public class IncapacidadFamisanar
    {
        public string FechaNacimiento { get; set; }
        public string FechaRadicación { get; set; }
        public string TipoAfiliación { get; set; }
        public string FechaInicio { get; set; }
        public string NUMERO_ID_IPS_PRIMARIA { get; set; }
        public string FechaAfiliación { get; set; }
        public string COD_IPS_IGE { get; set; }
        public string DIAS_APROBADOS { get; set; }
        public string PRORROGA { get; set; }
        public string ESTADO_AFILIACION { get; set; }
        public string GENERO { get; set; }
        public string AFI_MUN_DEP_CODRES { get; set; }
        public string AFI_MUN_CODRES { get; set; }
        public string DIAGNOSTICO { get; set; }
        public string IPS_NO_ADSCRITA { get; set; }
        public string FechaAfiliacion { get; internal set; }
    }
}