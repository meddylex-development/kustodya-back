using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Kustodya.ApplicationCore.Entities.Contabilidades;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Services;
using Kustodya.ApplicationCore.Specifications.Contabilidades;
using Kustodya.ApplicationCore.Specifications.Contabilidades;
using Kustodya.WebApi.Controllers.Contabilidades.Modelo;
using Kustodya.WebApi.Models.Contabilidades;

namespace Kustodya.WebApi.Controllers.Contabilidades
{

    public class TipoAjusteOutputModelService : ITipoAjusteOutputModelService
    {
        private readonly IAsyncContabilidadRepository<TipoAjuste> _tipoAjusteRepo;
        private readonly IAsyncContabilidadRepository<ApplicationCore.Entities.Contabilidades.Contabilidad> _contabilidadRepo;
        private readonly IMapper _mapper;

        public TipoAjusteOutputModelService(
            IAsyncContabilidadRepository<TipoAjuste> tipoAjusteRepo,
            IAsyncContabilidadRepository<ApplicationCore.Entities.Contabilidades.Contabilidad> contabilidadRepo,
            IMapper mapper)
        {
            _tipoAjusteRepo = tipoAjusteRepo;
            _mapper = mapper;
            _contabilidadRepo = contabilidadRepo;
        }

        public async Task<OutputModel<TipoAjusteOutputModel>> GetOutputModelsAsync(string codigoContabilidad, int entidadId, string busqueda, int pagina = 1)
        {
            var contabilidad = await ConsultarContabilidad(codigoContabilidad, entidadId);

            AsegurarNoNulo(contabilidad);

            var spec = new TipoAjusteConContabilidadSpec(contabilidad.Id, busqueda, pagina);
            var clasesDocumento = await _tipoAjusteRepo.ListAsync(spec);

            var specTotal = new TipoAjusteConContabilidadSpec(contabilidad.Id, busqueda);
            var total = await _tipoAjusteRepo.CountAsync(specTotal);

            if (clasesDocumento is null) return null;

            var outputModels = _mapper.Map<List<TipoAjusteOutputModel>>(clasesDocumento);

            var outputModel = new OutputModel<TipoAjusteOutputModel>(outputModels, pagina, total);

            return outputModel;
        }

        public async Task<OutputModel<TipoAjusteOutputModel>> GetOutputModelsAsync(int entidadId, string busqueda, int pagina = 1)
        {
            var spec = new TipoAjusteConEntidadSpec(entidadId, busqueda, pagina);
            var tiposAjuste = await _tipoAjusteRepo.ListAsync(spec);

            var specTotal = new TipoAjusteConEntidadSpec(entidadId, busqueda);
            var total = await _tipoAjusteRepo.CountAsync(specTotal);

            if (tiposAjuste is null) return null;

            var outputModels = _mapper.Map<List<TipoAjusteOutputModel>>(tiposAjuste);

            var outputModel = new OutputModel<TipoAjusteOutputModel>(outputModels, pagina, total);

            return outputModel;
        }

        public async Task<TipoAjusteOutputModel> GetOutputModelAsync(string codigoContabilidad, int entidadId, string descripcion)
        {
            var contabilidad = await ConsultarContabilidad(codigoContabilidad, entidadId);

            AsegurarNoNulo(contabilidad);

            var spec = new TipoAjusteConDescripcionSpec(descripcion, contabilidad.Id);
            var claseDocumento = await _tipoAjusteRepo.GetOneAsync(spec);

            AsegurarNoNulo(claseDocumento);

            var outputModel = _mapper.Map<TipoAjusteOutputModel>(claseDocumento);

            return outputModel;
        }

        private void AsegurarNoNulo(object entidad)
        {
            if (entidad is null)
            {
                throw new EntidadNoExisteException(nameof(entidad));
            }
        }

        private async Task<ApplicationCore.Entities.Contabilidades.Contabilidad> ConsultarContabilidad(string codigoContabilidad, int entidadId)
        {
            var spec = new ContabilidadConCodigoSpec(codigoContabilidad, entidadId);
            var contabilidad = await _contabilidadRepo.GetOneAsync(spec);
            return contabilidad;
        }

    }

}