namespace Kustodya.WebApi.Controllers.Contabilidades
.Modelo
{
    public class ClaseDocumentoOutputModel
    {
        public string Descripcion { get; set; }
        public string Contabilidad { get; set; }
        public string CodigoContabilidad { get; set; }
        public bool EsClaseDocumentoPorDefecto { get; set; }
    }
}
