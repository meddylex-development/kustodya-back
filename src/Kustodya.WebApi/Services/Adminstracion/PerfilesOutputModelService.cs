using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Kustodya.ApplicationCore.Dtos;
using Kustodya.ApplicationCore.DTOs;
using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Specifications;
using Kustodya.WebApi.Models;
using Microsoft.Extensions.Logging;
using Kustodya.ApplicationCore.Constants;

namespace Kustodya.WebApi.Services
{
    public sealed class PerfilesOutputModelService : IPerfilesOutputModelService
    {
        private IAsyncRepository<TblPerfiles> _repo;
        private ILogger _logger;
        private readonly IMapper _mapper;

        public PerfilesOutputModelService(ILoggerFactory loggerFactory, IAsyncRepository<TblPerfiles> repo, IMapper mapper)
        {
            _repo = repo;
            _logger = loggerFactory.CreateLogger(nameof(PerfilesOutputModelService));
            _mapper = mapper;
        }

        public async Task<PerfilesOuputModel> GetPerfilesOutputModelAsync(string nombre, int pagina = 1)
        {
            var spec = new PerfilActivoConNombrePaginado(nombre, pagina);

            var perfiles = await _repo.ListAsync(spec);
            var perfilesOutputModel = _mapper
                .Map<IReadOnlyList<TblPerfiles>, IReadOnlyList<PerfilOutputModel>>(perfiles);

            var specCount = new PerfilActivoConNombre(nombre, pagina);
            var total = await _repo.CountAsync(specCount);

            return new PerfilesOuputModel
            {
                Perfiles = perfilesOutputModel,
                Paginacion = new PaginacionModel(total, pagina)
            };
        }

        public async Task<PerfilConDetalleOutputModel> GetPerfilOutputModelAsync(int id)
        {
            var spec = new PerfilActivoConDetalleSpec(id);
            var perfil = await _repo.GetOneAsync(spec);
            var outputModel = _mapper
                .Map<TblPerfiles, PerfilConDetalleOutputModel>(perfil);

            return outputModel;
        }
    }
}