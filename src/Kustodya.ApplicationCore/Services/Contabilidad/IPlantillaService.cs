using Kustodya.ApplicationCore.DTOs.Contabilidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.Services.Contabilidades
{
    public interface IPlantillaService
    {
        Task CrearPlantilla(PlantillaInputModel plantillaInput, int entidadId);
        Task ActualizarPlantilla(PlantillaInputModel plantillaInput, Guid plantillaId, int entidadId);
        Task EliminarPlantilla(Guid plantillaId, int entidadId);
    }
}
