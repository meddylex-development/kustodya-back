namespace Kustodya.ApplicationCore.Dtos.Negocio
{
    public class AFPModel
    {
        public bool BActivo { get; set; }
        public int IIdAFP { get; set; }
        public string TCodigoExterno { get; set; }
        public string TDigitoVerificacion { get; set; }
        public string TNombreAFP { get; set; }
        public string TNumeroIdentificacion { get; set; }
    }
}