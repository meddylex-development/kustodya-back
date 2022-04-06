using Kustodya.Medicos.Models;
using Kustodya.Medicos.Services.Input;

namespace Kustodya.Medicos.Input
{
    public class ResultadoDeMapeo
    {
        public int IndiceDeFila { get; set; }
        public Registro Registro { get; set; }
        public bool EsValido { get; set; }
    }
}
