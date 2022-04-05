using Kustodya.ApplicationCore.DTOs.Contabilidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.Services.Contabilidades
{
    public interface ICentroService
    {
        Task ActualizarCentros(IReadOnlyList<CentroInputModel> centrosInput, int entidadId);
    }
}
