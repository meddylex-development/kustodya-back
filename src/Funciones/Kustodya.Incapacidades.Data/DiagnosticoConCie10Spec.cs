using Kustodya.ApplicationCore.Entities.MallaValidadora;
using Kustodya.ApplicationCore.Specifications;

namespace Kustodya.Incapacidades.Data
{
    public class DiagnosticoSpec : BaseSpec<Diagnostico>
    {
        public DiagnosticoSpec(string codigoCie10)
                : base(d => d.CodigoCie10 == codigoCie10)
        {
        }
    }
}