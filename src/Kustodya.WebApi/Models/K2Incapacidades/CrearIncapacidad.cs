using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Models.K2Incapacidades
{
    public class CrearIncapacidad
    {
        public int iIDIPS { get; set; }
        public int iIDPaciente { get; set; }
        public DateTime? dtFechaInicioAfeccion { get; set; }
        public int? iIDTipoAtencion { get; set; }
        public int iIDTipoAfeccion { get; set; }
        public bool bSOAT { get; set; }
        public string tJustificacionDiasAdicionales { get; set; }
        public int iIDPresuntoOrigenIncapacidad { get; set; }
        public string? tPalabrasClave { get; set; }
        public string? tDescripcion { get; set; }
        public int iIDCiudad { get; set; }
        public string? tDireccion { get; set; }
        public string? tBarrio { get; set; }
        public int iIDCIE10 { get; set; }
        public int? iIDLateralidad { get; set; }
        public string? tDescripcionSintomatologica { get; set; }
        public bool bProrroga { get; set; }
        public int iDiasIncapacidad { get; set; }
        public string? tJustificacion { get; set; }
        public int iIDUsuarioCreador { get; set; }
        public int iIDDiagnosticoCorrelacion { get; set; }
        public bool bEsTranscripcion { get; set; }
        public bool bQuestion1 { get; set; }
        public bool bQuestion2 { get; set; }
        public bool bQuestion3 { get; set; }
        public bool bQuestion4 { get; set; }
        public bool bQuestion5 { get; set; }
    }
}
