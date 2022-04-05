using Kustodya.Medicos.Data;

namespace Roojo.Rethus
{
    public interface IConsultasFabric
    {
        Consulta NuevaDesdeMedicoPorTipoDeIdentificacion(Medico medico);
    }
}
