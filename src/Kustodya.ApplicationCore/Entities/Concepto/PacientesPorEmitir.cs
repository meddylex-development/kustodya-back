using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.Concepto
{
    public class PacientesPorEmitir
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public EstadoConcepto Estado { get; set; }
        public int UsuarioAsignadoId { get; set; }
        public DateTime? FechaEmision { get; set; }
        public string CausalAnulacion { get; set; }
        public DateTime? FechaAnulacion { get; set; }
        public DateTime FechaCreacion { get; set; } //se agrega nuevo
        public int Prioridad { get; set; } //se agrega nuevo
        public DateTime? FechaModificacion { get; set; } //se agrega nuevo
        public Decimal Progreso { get; set; } //se agrega nuevo
        public DateTime? FechaNotificacion { get; set; } //se agrega nuevo
        public int? DiasIncapacidad { get; set; } //se agrega nuevo
        public int? GrupoIncapacidad { get; set; } //se agrega nuevo



        public ConceptoRehabilitacion concepto { get; set; }
        public TblPacientes Paciente { get; set; }

        public string CalcularCodigoCorto() {
            return Paciente.IIdepsNavigation.TCodigoExterno + "-" + GenerateRndString(4) + "-" + Paciente.TNumeroDocumento;
        }
        public enum EstadoConcepto : int
        {
            Por_Emitir = 1,
            Emitido = 2,
            Anulado = 3
        }
        private string GenerateRndString(int size)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString().ToUpper();
        }
    }
}
