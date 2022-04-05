using System;

namespace Kustodya.WebApi.Controllers.Contabilidades
.Modelo
{
    public class TipoAjusteOutputModel
    {
        public Guid Id { get; set; }
        public string Descripcion { get; set; }
        public string Contabilidad { get; set; }
        public string CodigoContabilidad { get; set; }
        public bool EsTipoAjustePorDefecto { get; set; }
    }
}
