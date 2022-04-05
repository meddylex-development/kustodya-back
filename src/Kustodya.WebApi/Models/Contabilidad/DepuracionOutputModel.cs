using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Models.Contabilidades
{
    public class DepuracionOutputModel
    {
        public Guid Id { get; set; }
        public string NoFichaTecnica { get;  set; }
        public long FechaElaboracion { get; set; }
        public string CodyNombreCuenta { get; set; }
        public string DescripcionFicha { get; set; }
        public string Estado { get; set; }
        public string Accion { get; set; }
        public bool Editable { get; set; }
    }
}
