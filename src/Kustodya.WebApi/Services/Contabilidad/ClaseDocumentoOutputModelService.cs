using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Kustodya.ApplicationCore.Entities.Contabilidades;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Services;
using Kustodya.ApplicationCore.Specifications.Contabilidades;
using Kustodya.WebApi.Controllers.Contabilidades.Modelo;
using Kustodya.WebApi.Models.Contabilidades;
using Microsoft.AspNetCore.Mvc;

namespace Kustodya.WebApi.Controllers.Contabilidades
{
    public class ClasesDocumentoOutputModelService : IClasesDocumentoOutputModelService
    {
        #region DI
        private readonly IAsyncContabilidadRepository<ClaseDocumento> _claseDocumentoRepo;
        private readonly IAsyncContabilidadRepository<ApplicationCore.Entities.Contabilidades.Contabilidad> _contabilidadRepo;
        private readonly IMapper _mapper;

        public ClasesDocumentoOutputModelService(
            IAsyncContabilidadRepository<ClaseDocumento> claseDocumentoRepo,
            IAsyncContabilidadRepository<ApplicationCore.Entities.Contabilidades.Contabilidad> contabilidadRepo,
            IMapper mapper)
        {
            _claseDocumentoRepo = claseDocumentoRepo;
            _contabilidadRepo = contabilidadRepo;
            _mapper = mapper;
        }
        #endregion
        
        public async Task<OutputModel<ClaseDocumentoOutputModel>> GetOutputModelsAsync(string codigoContabilidad, int entidadId, string busqueda, int pagina = 1)
        {
            var contabilidad = await ConsultarContabilidad(codigoContabilidad, entidadId);

            AsegurarNoNulo(contabilidad);

            var spec = new ClaseDocumentoConContabilidadSpec(contabilidad.Id, busqueda, pagina);
            var clasesDocumento = await _claseDocumentoRepo.ListAsync(spec);

            var specTotal = new ClaseDocumentoConContabilidadSpec(contabilidad.Id, busqueda);
            var total = await _claseDocumentoRepo.CountAsync(specTotal);

            if (clasesDocumento is null) return null;

            var outputModels = _mapper.Map<List<ClaseDocumentoOutputModel>>(clasesDocumento);

            var outputModel = new OutputModel<ClaseDocumentoOutputModel>(outputModels, pagina, total);

            return outputModel;
        }

        public async Task<OutputModel<ClaseDocumentoOutputModel>> GetOutputModelsAsync(int entidadId, string busqueda, int pagina = 1)
        {
            var spec = new ClaseDocumentoConEntidadSpec(entidadId, busqueda, pagina);
            var clasesDocumento = await _claseDocumentoRepo.ListAsync(spec);

            var specTotal = new ClaseDocumentoConEntidadSpec(entidadId, busqueda);
            var total = await _claseDocumentoRepo.CountAsync(specTotal);

            if (clasesDocumento is null) return null;

            var outputModels = _mapper.Map<List<ClaseDocumentoOutputModel>>(clasesDocumento);

            var outputModel = new OutputModel<ClaseDocumentoOutputModel>(outputModels, pagina, total);

            return outputModel;
        }

        public async Task<ClaseDocumentoOutputModel> GetOutputModelAsync(string codigoContabilidad, int entidadId, string descripcion)
        {
            var contabilidad = await ConsultarContabilidad(codigoContabilidad, entidadId);

            AsegurarNoNulo(contabilidad);

            var spec = new ClaseDocumentoConDescripcionSpec(descripcion, contabilidad.Id);
            var claseDocumento = await _claseDocumentoRepo.GetOneAsync(spec);

            AsegurarNoNulo(claseDocumento);

            var outputModel = _mapper.Map<ClaseDocumentoOutputModel>(claseDocumento);

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