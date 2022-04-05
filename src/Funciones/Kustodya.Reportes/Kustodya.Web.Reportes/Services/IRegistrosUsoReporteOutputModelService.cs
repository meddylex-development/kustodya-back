using System.Threading.Tasks;
using Kustodya.Core.Reportes.DTOs;

namespace Kustodya.Web.Reportes.Services
{
    public interface IRegistrosUsoReporteInputModelService
    {
        SolicitudReporteModel GetRegistrosUsoReporteModelAsync(string body);
    }
}