using AutoMapper;
using Kustodya.ApplicationCore.Dtos;
using Kustodya.ApplicationCore.Entities.Contabilidades;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Specifications.Contabilidades;
using Kustodya.WebApi.Models.Contabilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Services.Contabilidades
{
    public class PlantillaOutputModelService : IPlantillaOutputModelService
    {
        #region Dependency Injection
        private readonly IMapper _mapper;
        private readonly IAsyncContabilidadRepository<Plantilla> _plantillaRepo;

        public PlantillaOutputModelService(IMapper mapper, IAsyncContabilidadRepository<Plantilla> plantillaRepo)
        {
            _mapper = mapper;
            _plantillaRepo = plantillaRepo;
        }
        #endregion
        public async Task<PlantillasOutputModel> GetListaPlantillasOutputModel(int entidadId,string busqueda, Plantilla.TiposPlantillaContable? tipoPlantilla,  int pagina, int tamanoPagina)
        {
            var spec = new PlantillaporNombreyTipoSpec(entidadId, busqueda, tipoPlantilla, (pagina - 1) * tamanoPagina, tamanoPagina);
            var plantillas = await _plantillaRepo.ListAsync(spec);
            var specTotal = new PlantillaporNombreyTipoSpec(entidadId, busqueda, tipoPlantilla, null, null);
            var total = await _plantillaRepo.CountAsync(specTotal);
            if (plantillas is null)
                return null;

            var plantillasmodel = _mapper.Map<IReadOnlyList<PlantillaOutputModel>>(plantillas);
            PlantillasOutputModel plantillasOutputModel = new PlantillasOutputModel
            {
                plantillaOutputModel = plantillasmodel,
                paginacion = new PaginacionModel(total, pagina, tamanoPagina)
            };
            return (plantillasOutputModel);
        }
    }
}
