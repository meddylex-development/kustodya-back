using System.Threading.Tasks;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.DTOs.Contabilidades;
using AutoMapper;
using Kustodya.ApplicationCore.Specifications.Contabilidades;
using Kustodya.ApplicationCore.Entities.Contabilidades;
using System;

namespace Kustodya.ApplicationCore.Services
{
    public class ClaseDocumentoDomainService : IClaseDocumentoDomainService
    {
        #region DI
        private readonly IAsyncContabilidadRepository<ClaseDocumento> _claseDocumentoRepo;
        private readonly IMapper _mapper;
        private readonly IEntidadService _entidadService;
        private readonly IAsyncContabilidadRepository<Entities.Contabilidades.Contabilidad> _contabilidadRepo;

        public ClaseDocumentoDomainService(
            IAsyncContabilidadRepository<ClaseDocumento> claseDocumentoRepo,
            IAsyncContabilidadRepository<Entities.Contabilidades.Contabilidad> contabilidadRepo,
            IEntidadService entidadService,
            IMapper mapper)
        {
            _contabilidadRepo = contabilidadRepo;
            _claseDocumentoRepo = claseDocumentoRepo;
            _mapper = mapper;
            _entidadService = entidadService;
        }
        #endregion

        public async Task<ClaseDocumento> CrearAsync(ClaseDocumentoInputModel inputModel, string codigoContabilidad, int entidadId)
        {
            var contabilidad = await ConsultarContabilidad(codigoContabilidad, entidadId);
            AsegurarNoNulo(contabilidad);
            var claseDocumento = await ConsultarClaseDocumento(inputModel.Descripcion, contabilidad.Id);

            if (claseDocumento is null)
            {
                claseDocumento = new ClaseDocumento(contabilidad.Id, inputModel.Descripcion);
                await _claseDocumentoRepo.AddAsync(claseDocumento);
            }
            else
                throw new EntidadYaExisteException(nameof(ClaseDocumento), inputModel.Descripcion);

            await ActualizarContabilidadPorDefecto(inputModel, contabilidad, claseDocumento);

            return claseDocumento;
        }

        public async Task<ClaseDocumento> ActualizarAsync(string decripcion, ClaseDocumentoInputModel inputModel, string codigoContabilidad, int entidadId)
        {
            var contabilidad = await ConsultarContabilidad(codigoContabilidad, entidadId);
            AsegurarNoNulo(contabilidad);

            var claseDocumento = await ConsultarClaseDocumento(decripcion, contabilidad.Id);

            AsegurarNoNulo(claseDocumento);

            claseDocumento.ActualizarDescripcion(inputModel.Descripcion);
            await _claseDocumentoRepo.UpdateAsync(claseDocumento);

            await ActualizarContabilidadPorDefecto(inputModel, contabilidad, claseDocumento);

            return claseDocumento;
        }
        
        public async Task EliminarAsync(string descripcion, string codigoContabilidad, int entidadId)
        {
            var contabilidad = await ConsultarContabilidad(codigoContabilidad, entidadId);
            ClaseDocumento claseDocumento = await ConsultarClaseDocumento(descripcion, contabilidad.Id);

            AsegurarNoNulo(claseDocumento);

            claseDocumento.Eliminar();
            await _claseDocumentoRepo.UpdateAsync(claseDocumento);
        }

        private async Task<Entities.Contabilidades.Contabilidad> ConsultarContabilidad(string codigoContabilidad, int entidadId)
        {
            var spec = new ContabilidadConCodigoSpec(codigoContabilidad, entidadId);
            var contabilidad = await _contabilidadRepo.GetOneAsync(spec);
            AsegurarNoNulo(contabilidad);
            return contabilidad;
        }

        private async Task ActualizarContabilidadPorDefecto(ClaseDocumentoInputModel inputModel, Entities.Contabilidades.Contabilidad contabilidad, ClaseDocumento claseDocumento)
        {
            if (inputModel.EsClaseDocumentoPorDefecto)
            {
                contabilidad.EstablecerClaseDocumentoPorDefecto(claseDocumento.Id);
                await _contabilidadRepo.UpdateAsync(contabilidad);
            }
            else {
                contabilidad.EstablecerClaseDocumentoPorDefecto(null);
                await _contabilidadRepo.UpdateAsync(contabilidad);
            }
        }

        private async Task<ClaseDocumento> ConsultarClaseDocumento(string descripcion, Guid contabilidadId)
        {
            var spec = new ClaseDocumentoConDescripcionSpec(descripcion, contabilidadId);
            var claseDocumento = await _claseDocumentoRepo.GetOneAsync(spec);
            //AsegurarNoNulo(claseDocumento);
            return claseDocumento;
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