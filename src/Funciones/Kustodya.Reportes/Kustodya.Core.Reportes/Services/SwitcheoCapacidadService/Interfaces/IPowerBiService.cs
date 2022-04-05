using System;
using System.Threading.Tasks;
using Kustodya.Core.Reportes.Entities;

namespace Kustodya.Core.Reportes.Services
{
    public interface IPowerBiService
    {
        Task DesasociarCapacidad(Guid capacidadId, Guid workspaceId, string token);
        Task PausarCapacidadAsync(string nombreCapacidad, string token, Guid reporteId);
        Task ReanudarCapacidadAsync(string nombreCapacidad, string token, Guid reporteId, Solicitud solicitud);
    }
}