using Kustodya.ApplicationCore.Constants;
using Kustodya.Medicos.Data;
using Kustodya.Medicos.Data.Medicos;

namespace Kustodya.Medicos.Specifications
{
    public class MedicoSpecification : BaseSpec<Medico>
    {
        public MedicoSpecification(string documentNumber, TiposDeDocumentoDeIdentificacion identificationType)
                : base(e => e.NumeroIdentifiacion == documentNumber && e.TipoIdentificacion == identificationType)
        {
            
        }
    }
}
