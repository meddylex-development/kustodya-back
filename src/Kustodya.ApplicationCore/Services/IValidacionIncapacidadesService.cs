using Kustodya.ApplicationCore.Entities;
using System;
using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.Interfaces
{
    public interface IValidacionIncapacidadesService
    {
        Task<Guid> SolicitarAsync(TblDiagnosticosIncapacidades incapacidad);
    }
}