using System.Collections.Generic;
using Kustodya.Medicos.Data;

namespace Kustodya.Medicos.Services
{
    public class ConsultaPorCargueMasivoId
    {
        public string CargueMasivoId { get; internal set; }
        public List<Medico> Medicos { get; internal set; }
    }
    public class ConsultaPorNombres
    {
        public string PrimerNombre { get; internal set; }
        public string PrimerApellido { get; internal set; }
    }
}
