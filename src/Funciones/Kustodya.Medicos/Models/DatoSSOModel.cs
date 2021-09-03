namespace Kustodya.Medicos.Models
{
    public class DatoSSOModel
    {
        public int Id { get; set; }
        public int ConsultaId { get; set; }
        public string TipoPresentacion { get; set; }
        public string TipoLugarPresentacion { get; set; }
        public string LugarPresentacion { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public string ModealidadPresentacion { get; set; }
        public string ProgramaPresentacion { get; set; }
        public string EntidadReportadora { get; set; }
    }
}
