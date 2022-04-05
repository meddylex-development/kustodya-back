namespace Kustodya.ApplicationCore.Dtos.Incapacidades
{
    public class CIE10Model
    {
        public int IDiasMaxAcumulados { get; set; }
        public int IDiasMaxConsulta { get; set; }
        public int IIdcie10 { get; set; }
        public int? IIdtipoCie { get; set; }
        public string TCie10 { get; set; }
        public string TDescripcion { get; set; }
        public string TFullDescripcion { get; set; }
        public bool? AplicaLateralidad { get; set; }
    }
}