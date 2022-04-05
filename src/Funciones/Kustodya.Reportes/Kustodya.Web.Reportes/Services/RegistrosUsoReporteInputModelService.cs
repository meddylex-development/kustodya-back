using System.IO;
using System.Threading.Tasks;
using Kustodya.Core.Reportes.DTOs;
using Newtonsoft.Json;

namespace Kustodya.Web.Reportes.Services
{
    public class RegistrosUsoReporteInputModelService : IRegistrosUsoReporteInputModelService
    {
        public SolicitudReporteModel GetRegistrosUsoReporteModelAsync(string body)
        {
            var data = JsonConvert.DeserializeObject<SolicitudReporteModel>(body);
            // Todo: Agregar validacion de nulos, el chequeo de nulo debería estar encapsulada en una clausula Guard de Ardalis.GuardClauses
            return data;
        }
    }
}