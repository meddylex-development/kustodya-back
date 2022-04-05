namespace Kustodya.ApplicationCore.Dtos.General
{
    public class UbicacionModel
    {
        public int IIdDane { get; set; }
        public int IIdDepartamento { get; set; }
        public int IIdMunicipio { get; set; }
        public int IIdPais { get; set; }
        public string TCodigoDANE { get; set; }
        public string TNombreDepartamento { get; set; }
        public string TNombreMunicipio { get; set; }
        public string TNombrePais { get; set; }
        public string TNombrePoblacion { get; set; }

        public string GetLugarExpedicion()
        {
            return TNombrePoblacion + " - " + TNombreDepartamento;
        }
    }
}