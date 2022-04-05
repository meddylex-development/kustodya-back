using Kustodya.ApplicationCore.Entities.Contabilidades;
using Kustodya.WebApi.Models.Contabilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Services.Contabilidades
{
    public interface IPlantillaOutputModelService
    {
        Task<PlantillasOutputModel> GetListaPlantillasOutputModel(int entidadId,string busqueda, Plantilla.TiposPlantillaContable? tipoPlantilla, int pagina, int tamanoPagina);
    }
}
