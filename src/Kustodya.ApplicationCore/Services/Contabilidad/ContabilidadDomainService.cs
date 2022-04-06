using System;
using System.Threading.Tasks;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.DTOs.Contabilidades;
using AutoMapper;
using Kustodya.ApplicationCore.Specifications.Contabilidades;
using Kustodya.ApplicationCore.Entities.Contabilidades;

namespace Kustodya.ApplicationCore.Services
{
    public class ContabilidadDomainService : IContabilidadService
    {
        private readonly IAsyncContabilidadRepository<Entities.Contabilidades.Contabilidad> _contabilidadRepo;
        private readonly IEntidadService _entidadService;
        private readonly IAsyncContabilidadRepository<Puc> _pucRepo;
        private readonly IAsyncContabilidadRepository<ClaseDocumento> _claseDocumentoRepo;
        private readonly IAsyncContabilidadRepository<TipoAjuste> _tipoAjusteRepo;
        private readonly IMapper _mapper;

        public ContabilidadDomainService(
            IAsyncContabilidadRepository<Entities.Contabilidades.Contabilidad> contabilidadRepo,
            IAsyncContabilidadRepository<ClaseDocumento> claseDocumentoRepo,
            IAsyncContabilidadRepository<Puc> pucRepo,
            IAsyncContabilidadRepository<TipoAjuste> tipoAjusteRepo,
            IEntidadService entidadService,
            IMapper mapper)
        {
            _contabilidadRepo = contabilidadRepo;
            _entidadService = entidadService;
            _pucRepo = pucRepo;
            _mapper = mapper;
            _claseDocumentoRepo = claseDocumentoRepo;
            _tipoAjusteRepo = tipoAjusteRepo;
        }

        public async Task<Entities.Contabilidades.Contabilidad> CrearOActualizarContabilidadAsync(ContabilidadInputModel inputModel, int entidadId)
        {
            var spec = new ContabilidadConCodigoSpec(inputModel.Codigo, entidadId);
            var contabilidad = await _contabilidadRepo.GetOneAsync(spec);

            var pucCreditoId = await GetPucIdAsync(inputModel.CodigoPucCreditoMovimientoPorDefecto, entidadId);

            var pucDebitoId = await GetPucIdAsync(inputModel.CodigoPucDebitoMovimientoPorDefecto, entidadId);

            var claseDocumentoId = await GetClaseDocIdAsync(inputModel.ClaseDocumentoPorDefecto, entidadId);
            
            var tipoAjusteId = await GetTipoAjusteIdAsync(inputModel.TipoAjustePorDefecto, entidadId);

            if (contabilidad is null)
            {
                contabilidad = new Entities.Contabilidades.Contabilidad(entidadId,
                inputModel.Codigo,
                inputModel.Descripcion,
                pucCreditoId,
                pucDebitoId,
                inputModel.ReferenciaMovimientoPorDefecto,
                inputModel.DescripcionMovimientoPorDefecto,
                claseDocumentoId,
                tipoAjusteId);
                await _contabilidadRepo.AddAsync(contabilidad);
            }
            else
            {
                contabilidad.CodigoPucCreditoMovimientoPorDefecto = pucCreditoId;
                contabilidad.CodigoPucDebitoMovimientoPorDefecto = pucDebitoId;
                contabilidad.Descripcion = inputModel.Descripcion;
                contabilidad.DescripcionMovimientoPorDefecto = inputModel.DescripcionMovimientoPorDefecto;
                contabilidad.ReferenciaMovimientoPorDefecto = inputModel.ReferenciaMovimientoPorDefecto;
                contabilidad.TipoAjustePorDefectoId = tipoAjusteId;
                contabilidad.ClaseDocumentoPorDefectoId = claseDocumentoId;
                await _contabilidadRepo.UpdateAsync(contabilidad);
            }

            if (inputModel.EsContabilidadPorDefecto)
            {
                await _entidadService.EstablecerContabilidadPorDefectoAsync(entidadId, contabilidad.Id);

            }

            return contabilidad;
        }
        public async Task<Entities.Contabilidades.Contabilidad> ObtenerContabilidadConPUCyCentrosporId(Guid Id)
        {
            var spec = new ObtenerContabilidadConPUCsyCentrosporId(Id);
            return await _contabilidadRepo.GetOneAsync(spec);
        }
        public async Task<Entities.Contabilidades.Contabilidad> ObtenerContabilidadPorCodigo(string codigo, int entidadId)
        {
            var spec = new ContabilidadConCodigoSpec(codigo, entidadId);
            return await _contabilidadRepo.GetOneAsync(spec);
        }

        private async Task<Guid?> GetPucIdAsync(string codigo, int entidadId)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                return null;
            var pucSpec = new PucConCodigoSpec(codigo, entidadId);
            var puc = await _pucRepo.GetOneAsync(pucSpec);

            if (puc is null)
                throw new PucNoExisteException(codigo);
            return puc.Id;
        }

        public async Task EliminarContabilidad(string code, int entidadId)
        {
            var spec = new ContabilidadConCodigoSpec(code, entidadId);
            var contabilidad = await _contabilidadRepo.GetOneAsync(spec);

            if (contabilidad is null)
                throw new EntidadNoExisteException(nameof(contabilidad), code);

            contabilidad.Eliminar();
            await _contabilidadRepo.UpdateAsync(contabilidad);
        }

        private async Task<Guid?> GetClaseDocIdAsync(string descripcion, int entidadId)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
                return null;
            var claseDocSpec = new ClaseDocumentoConDescSpec(descripcion, entidadId);
            var claseDoc = await _claseDocumentoRepo.GetOneAsync(claseDocSpec);

            if (claseDoc is null)
                throw new EntidadNoExisteException("Clase documento no existe");
            return claseDoc.Id;
        }
        private async Task<Guid?> GetTipoAjusteIdAsync(string descripcion, int entidadId)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
                return null;
            var tipoAjusteSpec = new TipoAjusteConDescSpec(descripcion, entidadId);
            var tipoAjuste = await _tipoAjusteRepo.GetOneAsync(tipoAjusteSpec);

            if (tipoAjuste is null)
                throw new EntidadNoExisteException("Tipo Ajuste no existe");
            return tipoAjuste.Id;
        }
    }
}