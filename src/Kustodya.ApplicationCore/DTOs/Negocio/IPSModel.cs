using Kustodya.ApplicationCore.Dtos.General;

namespace Kustodya.ApplicationCore.Dtos.Negocio
{
    public class IPSModel
    {
        private IPSModel()
        {
            Ubicacion = new UbicacionModel();
        }

        public long IIdips { get; set; }
        public string TCodigoExterno { get; set; }
        public int tDigitoVerificacion { get; set; }
        public string tDireccion { get; set; }
        public string tEmail { get; set; }
        public string TNombre { get; set; }
        public string TNumeroIdentificacion { get; set; }
        public string TPathLogo { get; set; }
        public string tTelefono { get; set; }
        public UbicacionModel Ubicacion { get; set; }
    }
}