namespace Kustodya.ApplicationCore.Entities
{
    public partial class ParametrosEmpresas
    {
        public long? IIdempresa { get; set; }
        public short IIdparametro { get; set; }
        public string TDescripcion { get; set; }
        public string TIdentificador { get; set; }
        public string TValor { get; set; }
    }
}