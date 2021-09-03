using Kustodya.WebApi.Models.Rehabilitaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Services.Interfaces
{
    public interface IDiagnosticoViewModelService
    {
        Task<IReadOnlyList<DiagnosticoChrbModel>> CreateViewModel(int iIDDiagnosticoIncapacidad);
    }
}
