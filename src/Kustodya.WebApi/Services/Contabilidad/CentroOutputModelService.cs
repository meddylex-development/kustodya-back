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
using Kustodya.WebApi.Services.Contabilidades;

namespace Kustodya.WebApi.Services.Contabilidades
{
    public class CentroOutputModelService : ICentroOutputModelService
    {
        #region Dependency Injection
        private readonly IMapper _mapper;
        private readonly IAsyncContabilidadRepository<CentroCosto> _centroRepo;

        public CentroOutputModelService(IMapper mapper, IAsyncContabilidadRepository<CentroCosto> centroRepo)
        {
            _mapper = mapper;
            _centroRepo = centroRepo;
        }
        #endregion
        public async Task<CentrosOutputModel> GetListaCentrosOutputModel(string busqueda, int pagina, int tamanoPagina) {
            var spec = new CentrosporCodigoDescripcionyContabilidadSpec(busqueda, (pagina - 1) * tamanoPagina, tamanoPagina);
            var centros = await _centroRepo.ListAsync(spec);
            var specTotal = new CentrosporCodigoDescripcionyContabilidadSpec(busqueda, null, null);
            var total = await _centroRepo.CountAsync(specTotal);
            if (centros is null)
                return null;

            var centrosmodel = _mapper.Map<IReadOnlyList<CentroOutputModel>>(centros);
            CentrosOutputModel centrosOutputModel = new CentrosOutputModel
            {
                centroOutputModel = centrosmodel,
                paginacion = new PaginacionModel(total, pagina, tamanoPagina)
            };
            return (centrosOutputModel);
        }
        public async Task<IEnumerable<CentroCosto>> GetListaCentros(string busqueda) {
            var spec = new CentrosporCodigoDescripcionyContabilidadSpec(busqueda, null, null);
            var centros = await _centroRepo.ListAsync(spec);
            if (centros is null)
                return null;
            return centros;
        }
    }
}
