using Kustodya.ApplicationCore.DTOs.Contabilidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.Services.Contabilidades
{
    public interface ITerceroService
    {
        Task ActualizarTerceros(IReadOnlyList<TerceroInputModel> tercerosInput, int entidadId);
        Task EliminarTerceros(int entidadId);
    }
}
