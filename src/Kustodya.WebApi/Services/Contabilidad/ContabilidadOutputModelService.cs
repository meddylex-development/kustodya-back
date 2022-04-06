using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Specifications.Contabilidades;
using Kustodya.WebApi.Models.Contabilidades;
using System;
using Kustodya.ApplicationCore.Dtos;
using Kustodya.ApplicationCore.Entities.Administracion;
using System.Linq;
namespace Kustodya.WebApi.Services.Contabilidades
{
    public class ContabilidadOutputModelService : IContabilidadOutputModelService
    {
        private readonly IEntidadService _entidadService;
        #region Dependency Injection
        private readonly IMapper _mapper;
        private readonly IAsyncContabilidadRepository<ApplicationCore.Entities.Contabilidades.Contabilidad> _contabilidadRepo;
        private readonly IAsyncRepository<Entidad> _entidadRepo;

        public ContabilidadOutputModelService(
            IMapper mapper,
            IAsyncContabilidadRepository<ApplicationCore.Entities.Contabilidades.Contabilidad> contabilidadRepo,
            IEntidadService entidadService,
            IAsyncRepository<Entidad> entidadRepo
        )
        {
            _entidadService = entidadService;
            _mapper = mapper;
            _contabilidadRepo = contabilidadRepo;
            _entidadRepo = entidadRepo;
        }
        #endregion

        public async Task<ContabilidadesOutputModel> GetListaContabilidadOutputModel(string busqueda, int entidadId, int pagina)
        {
            var skip = Math.Max(0, pagina - 1) * 10;
            var spec = new ContabilidadPaginadaConTextoSpec(busqueda, entidadId, skip);
            var specTotal = new ContabilidadConTextoSpec(busqueda, entidadId);
            var contabilidades = await _contabilidadRepo.ListAsync(spec);
            
            var entidad = await _entidadRepo.GetByIdAsync(entidadId);
            var codigoDefecto = contabilidades.Where(c => c.Id == entidad.ContabilidadPorDefectoId).FirstOrDefault()?.Codigo;

            if (contabilidades is null)
                return null;
            var contabilidadOutputModels = _mapper.Map<List<ContabilidadOutputModel>>(contabilidades);
            var outputModel = new ContabilidadesOutputModel();
            outputModel.Contabilidades = contabilidadOutputModels;

            if (codigoDefecto != null)
                outputModel.Contabilidades.Where(c => c.Codigo == codigoDefecto).FirstOrDefault().EsContabilidadPorDefecto = true;

            outputModel.Paginacion = new PaginacionModel(await _contabilidadRepo.CountAsync(specTotal), pagina);
            return outputModel;
        }

        public async Task<DetalleContabilidadOutputModel> GetContabilidadOutputModel(string codigo, int entidadId)
        {
            var spec = new ContabilidadConCodigoSpec(codigo, entidadId);
            var contabilidad = await _contabilidadRepo.GetOneAsync(spec);
            var entidad = await _entidadRepo.GetByIdAsync(entidadId);
            if (contabilidad is null)
                return null;

            var outputModel = _mapper.Map<DetalleContabilidadOutputModel>(contabilidad);
            
            outputModel.EsContabilidadPorDefecto = entidad.ContabilidadPorDefectoId == contabilidad.Id;
            
            if(contabilidad.PucCreditoPorDefecto != null)
                outputModel.TipoContabilidad = contabilidad.PucCreditoPorDefecto.TipoContabilidad;
            return outputModel;
        }

        public async Task<ContabilidadOutputModel> GetContabilidadOutputModel(ApplicationCore.Entities.Contabilidades.Contabilidad contabilidad)
        {
            // var entidad = await _entidadService.ObtenerEntidadDetalle(contabilidad.EntidadId);
            var entidad = await _entidadRepo.GetByIdAsync(contabilidad.EntidadId);
            var outputModel = _mapper.Map<ContabilidadOutputModel>(contabilidad);
            outputModel.EsContabilidadPorDefecto = contabilidad.Id == entidad.ContabilidadPorDefectoId;
            return outputModel;
        }
    }
}

// ## Por entidad

// Controlador 👈
// OutputModel 👈
// Spec 
// OutputModelService 👈
// DetalleOutputModel GET /{id}
// InputModel 👈
// EntidadService 👈
// MappingProfile 👈