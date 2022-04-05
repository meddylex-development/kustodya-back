using AutoMapper;
using Kustodya.ApplicationCore.Constants;
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
    public class TerceroOutputModelService : ITerceroOutputModelService
    {
        #region Dependency Injection
        private readonly IMapper _mapper;
        private readonly IAsyncContabilidadRepository<Tercero> _terceroRepo;

        public TerceroOutputModelService(IMapper mapper, IAsyncContabilidadRepository<Tercero> terceroRepo)
        {
            _mapper = mapper;
            _terceroRepo = terceroRepo;
        }
        #endregion
        public async Task<TercerosOutputModel> GetListaTercerosOutputModel(string busqueda, TiposPersona? tipoPersona, int pagina, int tamanoPagina) {
            var spec = new TerceroporNumIdNombreyTipoSpec(busqueda, tipoPersona, (pagina - 1) * tamanoPagina, tamanoPagina);
            var terceros = await _terceroRepo.ListAsync(spec);
            var specTotal = new TerceroporNumIdNombreyTipoSpec(busqueda, tipoPersona, null, null);
            var total = await _terceroRepo.CountAsync(specTotal);
            if (terceros is null)
                return null;

            var tercerosmodel = _mapper.Map<IReadOnlyList<TerceroOutputModel>>(terceros);
            TercerosOutputModel tercerosOutputModel = new TercerosOutputModel
            {
                terceroOutputModel = tercerosmodel,
                paginacion = new PaginacionModel(total, pagina, tamanoPagina)
            };
            return (tercerosOutputModel);
        }
        public async Task<IEnumerable<Tercero>> GetListaTerceros(string busqueda, TiposPersona? tipoPersona) {
            var spec = new TerceroporNumIdNombreyTipoSpec(busqueda, tipoPersona, null, null);
            var pucs = await _terceroRepo.ListAsync(spec);
            if (pucs is null)
                return null;
            return pucs;
        }
    }
}
