using Kustodya.ApplicationCore.Dtos.Multivalores;

namespace Kustodya.ApplicationCore.Dtos.General
{
    public class EmpresaTercerosModel
    {
        public EmpresaTercerosModel()
        {
            ActividadEconomica = new ActividadEconomicaModel();
            TipoSociedad = new TipoSociedadModel();
        }

        public ActividadEconomicaModel ActividadEconomica { get; set; }
        public long IId { get; set; }
        public TipoIdentificacionModel TipoDocumento { get; set; }
        public long NIT { get; set; }
        public int TDigitoVerificacion { get; set; }
        public string TDireccion { get; set; }
        public TipoSociedadModel TipoSociedad { get; set; }
        public string TObjetoSocial { get; set; }
        public string TRazonSocial { get; set; }
    }
}