using System;

namespace Kustodya.ApplicationCore.Dtos.Multivalores
{
    public class MultivaloresModel
    {
        public DateTime DTFechaCreacion { get; set; }
        public int IIdMultivalor { get; set; }
        public int IIdSubtabla { get; set; }
        public int IOrden { get; set; }
        public string tDescripcion { get; set; }
        public string TNombreSubtabla { get; set; }
        public string TValor { get; set; }
    }
}