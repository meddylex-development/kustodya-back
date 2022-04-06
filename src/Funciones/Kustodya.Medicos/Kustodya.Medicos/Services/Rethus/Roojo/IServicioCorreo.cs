using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kustodya.Medicos.Models;
using Roojo.CalificacionOrigen;

namespace Kustodya.Medicos.Services
{
    public interface IServicioCorreo
    {
        Task GuardarCorreos(List<LectorCorreosModel> correosModel);
        void GuardarCorreosConsoleApp(List<LectorCorreosModel> correosModel);
        IQueryable<Adjunto> ObtenerArchivosPendientes();
        void ActualizarAdjunto(Adjunto adjunto);
    }
}
