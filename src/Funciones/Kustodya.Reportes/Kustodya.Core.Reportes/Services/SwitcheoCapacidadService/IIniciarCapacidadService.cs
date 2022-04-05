using System;
using System.Threading.Tasks;

namespace Kustodya.Core.Reportes.Services
{
    public interface IIniciarCapacidadService
    {
        Task<bool> SolicitarAsync(int usuarioId, int entidadId, Guid id, Guid workspaceId);
    }
}