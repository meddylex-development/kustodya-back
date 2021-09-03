using Kustodya.ApplicationCore.Dtos.Rehabilitacion;
using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.Interfaces.Rehabilitacion
{
    public interface IRehabilitacionService
    {
        ConceptoRehabilitacionModel GetConceptoRehabilitacion(long id);
    }
}