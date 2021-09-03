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
using static Kustodya.ApplicationCore.Entities.Contabilidades.Puc;

namespace Kustodya.WebApi.Services.Contabilidades
{
    public class PUCOutputModelService : IPUCOutputModelService
    {
        #region Dependency Injection
        private readonly IMapper _mapper;
        private readonly IAsyncContabilidadRepository<ApplicationCore.Entities.Contabilidades.Puc> _pucRepo;

        public PUCOutputModelService(IMapper mapper, IAsyncContabilidadRepository<ApplicationCore.Entities.Contabilidades.Puc> pucRepo)
        {
            _mapper = mapper;
            _pucRepo = pucRepo;
        }
        #endregion
        public async Task<PUCsOutputModel> GetListaPUCOutputModel
            (string busqueda, string contabilidadId, TiposContabilidad? tipoContabilidad, int pagina, int tamanoPagina) {

            var spec = new PucporCodigoDescripcionContabilidadyTipoSpec(busqueda, contabilidadId, tipoContabilidad, (pagina - 1) * tamanoPagina, tamanoPagina);
            var pucs = await _pucRepo.ListAsync(spec);
            var specTotal = new PucporCodigoDescripcionContabilidadyTipoSpec(busqueda, contabilidadId, tipoContabilidad, null, null);
            var total = await _pucRepo.CountAsync(specTotal);
            if (pucs is null)
                return null;

            var pucsmodel = _mapper.Map<IReadOnlyList<PUCOutputModel>>(pucs);
            PUCsOutputModel pucsOutputModel = new PUCsOutputModel
            {
                pucOutputModel = pucsmodel,
                paginacion = new PaginacionModel(total, pagina, tamanoPagina)
            };
            return (pucsOutputModel);
        }

        public async Task<IEnumerable<Puc>> GetListaPUC
            (string busqueda, string contabilidadId, TiposContabilidad? tipoContabilidad)
        {

            var spec = new PucporCodigoDescripcionContabilidadyTipoSpec(busqueda, contabilidadId, tipoContabilidad, null, null);
            var pucs = await _pucRepo.ListAsync(spec);
            if (pucs is null)
                return null;
            return pucs;
        }
    }
}
