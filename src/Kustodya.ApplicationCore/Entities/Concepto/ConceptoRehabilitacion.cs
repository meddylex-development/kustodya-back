using Kustodya.ApplicationCore.Entities.General;
using Kustodya.ApplicationCore.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.Concepto
{
    public class ConceptoRehabilitacion
    {
        public long Id { get; set; }
        public int PacienteId { get; set; }
        public TblPacientes Paciente { get; set; }
        public string CodigoCorto { get; set; }
        public string ResumenHistoriaClinica { get; set; }
        public TipoFinalidad FinalidadTratamientos { get; set; }
        public bool EsFarmacologico { get; set; }
        public bool EsTerapiaOcupacional { get; set; }
        public bool EsFonoaudiologia { get; set; }
        public bool EsQuirurgico { get; set; }
        public bool EsTerapiaFisica { get; set; }
        public bool EsOtrosTratamientos { get; set; }
        public string DescripcionOtrosTratamientos { get; set; }
        public TipoPlazo PlazoCorto { get; set; }
        public TipoPlazo PlazoMediano { get; set; }
        public int Concepto { get; set; }
        public string RemisionAdministradoraFondoPension { get; set; }
        public int PacienteporEmitirId { get; set; }
        public PacientesPorEmitir PacienteporEmitir { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int UsuarioCreacionId { get; set; }
        public TblUsuarios UsuarioCreacion { get; set; }
        public ICollection<Diagnostico> Diagnosticos { get; set; }
        public ICollection<Secuela> Secuelas { get; set; }

        public enum TipoFinalidad : int {
            Curativo = 1,
            Paliativo = 2
        }
        public enum TipoPlazo : int { 
            Bueno = 1,
            Regular = 2,
            Malo = 3
        }
        public enum TipoConcepto : int
        {
            Favorable = 1,
            Desfavorable = 2
        }
    }
}
