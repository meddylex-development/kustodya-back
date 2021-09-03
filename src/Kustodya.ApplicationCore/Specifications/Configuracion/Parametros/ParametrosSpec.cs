using Kustodya.ApplicationCore.Entities;

namespace Kustodya.ApplicationCore.Specifications.Configuracion.Parametros
{
    public class ParametrosSpec : BaseSpec<TblParametrosEmpresas>
    {
        public ParametrosSpec(string identificator) : base(u => u.TIdentificador == identificator)
        {
        }
    }
}