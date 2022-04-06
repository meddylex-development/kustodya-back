using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Interfaces.Rehabilitacion;
using Kustodya.ApplicationCore.Dtos.Rehabilitacion;
using System.Threading.Tasks;

namespace Kustodya.BusinessLogic.Services.Rehabilitacion
{
    public class RehabilitacionService : IRehabilitacionService
    {
        //private readonly IRehabilitacionRepository _rehabilitacionRepository;
        //private readonly ILoggerService<RehabilitacionService> _logger;

        public ConceptoRehabilitacionModel GetConceptoRehabilitacion(long id)
        {
            return new ConceptoRehabilitacionModel();
        }
    }
}