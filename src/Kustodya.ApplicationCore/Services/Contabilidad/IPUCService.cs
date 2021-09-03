using Kustodya.ApplicationCore.DTOs.Contabilidades;
using Kustodya.ApplicationCore.Entities.Contabilidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.Services.Contabilidades
{
    public interface IPUCService
    {
        Task ActualizarPUC(IReadOnlyList<PUCInputModel> pucsInput, int entidadId);
    }
}
