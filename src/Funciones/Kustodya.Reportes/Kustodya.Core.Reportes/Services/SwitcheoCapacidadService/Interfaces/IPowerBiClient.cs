using System;
using System.Threading.Tasks;

namespace Kustodya.Core.Reportes.Services
{
    public interface IPowerBiClient
    {
        Task<EstadoIncapacidad> ConsultarEstadoCapacidadAsync(string nombreCapacidad, string token);
        Task PausarCapacidadAsync(string nombreCapacidad, string token);
        Task ReanudarCapacidadAsync(string nombreCapacidad, string token);

        enum EstadoIncapacidad
        {
            Pausado,
            Reanudado
        }
    }
}