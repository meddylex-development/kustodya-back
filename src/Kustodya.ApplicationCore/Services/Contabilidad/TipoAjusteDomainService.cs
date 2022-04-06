using System.Threading.Tasks;
using Kustodya.ApplicationCore.Interfaces;
using AutoMapper;
using Kustodya.ApplicationCore.Specifications.Contabilidades;
using Kustodya.ApplicationCore.Entities.Contabilidades;
using Kustodya.ApplicationCore.DTOs.Contabilidades;
using System;

namespace Kustodya.ApplicationCore.Services
{
    public class TipoAjusteDomainService : ITipoAjusteDomainService
    {
        private readonly IAsyncContabilidadRepository<TipoAjuste> _tipoAjusteRepo;
        private readonly IAsyncContabilidadRepository<Entities.Contabilidades.Contabilidad> _contabilidadRepo;
        private readonly IMapper _mapper;

        public TipoAjusteDomainService(
            IAsyncContabilidadRepository<TipoAjuste> tipoAjusteRepo, 
            IAsyncContabilidadRepository<Entities.Contabilidades.Contabilidad> contabilidadRepo,
            IMapper mapper)
        {
            _tipoAjusteRepo = tipoAjusteRepo;
            _mapper = mapper;
            _contabilidadRepo = contabilidadRepo;
        }

        public async Task<TipoAjuste> CrearAsync(TipoAjusteInputModel inputModel, string codigoContabilidad, int entidadId)
        {
            var contabilidad = await ConsultarContabilidad(codigoContabilidad, entidadId);
            AsegurarNoNulo(contabilidad);
            var tipoAjuste = await ConsultarTipoAjuste(inputModel.Descripcion, contabilidad.Id);

            if (tipoAjuste is null)
            {
                tipoAjuste = new TipoAjuste(inputModel.Descripcion, contabilidad.Id);
                await _tipoAjusteRepo.AddAsync(tipoAjuste);
            }
            else
                throw new EntidadYaExisteException(nameof(TipoAjuste), inputModel.Descripcion);

            await ActualizarContabilidadPorDefecto(inputModel, contabilidad, tipoAjuste);

            return tipoAjuste;
        }

        public async Task<TipoAjuste> ActualizarAsync(string decripcion, TipoAjusteInputModel inputModel, string codigoContabilidad, int entidadId)
        {
            var contabilidad = await ConsultarContabilidad(codigoContabilidad, entidadId);
            AsegurarNoNulo(contabilidad);

            var tipoAjuste = await ConsultarTipoAjuste(decripcion, contabilidad.Id);

            AsegurarNoNulo(tipoAjuste);

            tipoAjuste.ActualizarDescripcion(inputModel.Descripcion);
            await _tipoAjusteRepo.UpdateAsync(tipoAjuste);

            await ActualizarContabilidadPorDefecto(inputModel, contabilidad, tipoAjuste);

            return tipoAjuste;
        }

        public async Task EliminarAsync(string descripcion, string codigoContabilidad, int entidadId)
        {
            var contabilidad = await ConsultarContabilidad(codigoContabilidad, entidadId);
            TipoAjuste tipoAjuste = await ConsultarTipoAjuste(descripcion, contabilidad.Id);

            AsegurarNoNulo(tipoAjuste);

            tipoAjuste.Eliminar();
            await _tipoAjusteRepo.UpdateAsync(tipoAjuste);
        }

        private async Task<Entities.Contabilidades.Contabilidad> ConsultarContabilidad(string codigoContabilidad, int entidadId)
        {
            var spec = new ContabilidadConCodigoSpec(codigoContabilidad, entidadId);
            var contabilidad = await _contabilidadRepo.GetOneAsync(spec);
            return contabilidad;
        }

        private async Task ActualizarContabilidadPorDefecto(TipoAjusteInputModel inputModel, Entities.Contabilidades.Contabilidad contabilidad, TipoAjuste tipoAjuste)
        {
            if (inputModel.EsTipoAjustePorDefecto)
            {
                contabilidad.EstablecerTipoAjustePorDefecto(tipoAjuste.Id);
                await _contabilidadRepo.UpdateAsync(contabilidad);
            }
            else {
                contabilidad.EstablecerTipoAjustePorDefecto(null);
                await _contabilidadRepo.UpdateAsync(contabilidad);
            }
        }
        private async Task<TipoAjuste> ConsultarTipoAjuste(string descripcion, Guid contabilidadId)
        {
            var spec = new TipoAjusteConDescripcionSpec(descripcion, contabilidadId);
            var tipoAjuste = await _tipoAjusteRepo.GetOneAsync(spec);
            return tipoAjuste;
        }

        private void AsegurarNoNulo(object entidad)
        {
            if (entidad is null)
            {
                throw new EntidadNoExisteException(nameof(entidad));
            }
        }
    }

}