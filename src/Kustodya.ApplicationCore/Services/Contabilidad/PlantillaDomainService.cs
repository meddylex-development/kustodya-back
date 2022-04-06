using AutoMapper;
using Kustodya.ApplicationCore.DTOs.Contabilidades;
using Kustodya.ApplicationCore.Entities.Contabilidades;
using Kustodya.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.Services.Contabilidades
{
    public class PlantillaDomainService : IPlantillaService
    {
        private IAsyncContabilidadRepository<Plantilla> _repoPlantilla;
        private readonly IMapper _mapper;
        public PlantillaDomainService(IAsyncContabilidadRepository<Plantilla> repoPlantilla, IMapper mapper)
        {
            _repoPlantilla = repoPlantilla;
            _mapper = mapper;
        }
        public async Task CrearPlantilla(PlantillaInputModel plantillaInput, int entidadId) {
            Plantilla plantilla = new Plantilla(entidadId, (Plantilla.TiposPlantillaContable)Enum.Parse(typeof(Plantilla.TiposPlantillaContable), plantillaInput.TipoPlantilla.ToString()), plantillaInput.Texto);
            await _repoPlantilla.AddAsync(plantilla);
        }
        public async Task ActualizarPlantilla(PlantillaInputModel plantillaInput, Guid plantillaId, int entidadId) {
            var plantillas = await _repoPlantilla.ListAllAsync();
            Plantilla plantilla = plantillas.Where(c => c.Id == plantillaId && c.EntidadId == entidadId).FirstOrDefault();
            if (plantilla == null)
                throw new Exception("La plantilla con Id: " + plantillaId.ToString() + " no existe");

            plantilla.TipoPlantilla = (Plantilla.TiposPlantillaContable)Enum.Parse(typeof(Plantilla.TiposPlantillaContable), plantillaInput.TipoPlantilla.ToString());
            plantilla.Texto = plantillaInput.Texto;
            await _repoPlantilla.UpdateAsync(plantilla);
        }

        public async Task EliminarPlantilla(Guid plantillaId, int entidadId) {
            var plantillas = await _repoPlantilla.ListAllAsync();
            Plantilla plantilla = plantillas.Where(c => c.Id == plantillaId && c.EntidadId == entidadId).FirstOrDefault();
            await _repoPlantilla.DeleteAsync(plantilla);
        }
    }
}
