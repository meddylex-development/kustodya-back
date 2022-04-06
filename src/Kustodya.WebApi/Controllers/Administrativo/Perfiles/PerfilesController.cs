
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kustodya.WebApi.Models;
using Kustodya.WebApi.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.JsonPatch;
using Kustodya.ApplicationCore.Dtos;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Entities;
using AutoMapper;
using Kustodya.ApplicationCore.DTOs;
using System.Linq;
using Kustodya.ApplicationCore.Specifications;

namespace Kustodya.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PerfilesController : BaseController
    {
        private IAsyncRepository<TblPerfiles> _repoPerfiles;
        private IAsyncRepository<TblMenuPerfiles> _repoMenuPerfiles;
        private IPerfilesOutputModelService _service;
        private IMapper _mapper;

        public PerfilesController(
            IPerfilesOutputModelService service,
            IAsyncRepository<TblPerfiles> repoPerfiles,
            IAsyncRepository<TblMenuPerfiles> repoMenuPerfiles,
            IMapper mapper
            )
        {
            _repoPerfiles = repoPerfiles;
            _repoMenuPerfiles = repoMenuPerfiles;
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Solo admin y superadmin
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="pagina"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string nombre, [FromQuery] int pagina)
        {
            bool EsSuperAdmin = Convert.ToBoolean(User.Claims.Where(c => c.Type == "EsSuperAdmin").FirstOrDefault().Value);
            bool Admin = (User.Claims.Where(c => c.Type == "AdminEntidades").FirstOrDefault().Value).ToString().Length > 0;

            if (!EsSuperAdmin && !Admin)
                return Forbid();

            var perfiles = await _service.GetPerfilesOutputModelAsync(nombre, pagina);
            if (EsSuperAdmin)
            {
                perfiles.Perfiles = perfiles.Perfiles.Where(c => c.Id == 2).ToList();
            }
            else {
                perfiles.Perfiles = perfiles.Perfiles.Where(c => c.Id != 1).ToList();
            }
            if (perfiles.Perfiles.Count == 0)
                return NotFound();

            return Ok(perfiles);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var perfil = await _service.GetPerfilOutputModelAsync(id);

            if (perfil is null)
                return NotFound();

            return Ok(perfil);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PerfilInputModel inputModel)
        {
            // TO DO: cambiar modelo de salida por nuevo modelo con detalles (ids de menus asociados al perfil) 📝 202 CREATED AT
            var perfil = _mapper.Map<TblPerfiles>(inputModel);
            await _repoPerfiles.AddAsync(perfil);

            return CreatedAtAction(
                nameof(GetOne),
                new { id = perfil.IIdperfil },
                _mapper.Map<PerfilOutputModel>(perfil));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(PerfilInputModel inputModel, int id)
        {
            var entity = _mapper.Map<TblPerfiles>(inputModel);
            var spec = new MenuPerfilesActivosDeUnPerfilSpec(id);

            entity.IIdperfil = id;
            entity.TblMenuPerfiles.ToList().ForEach(mp => mp.IIdperfil = id);

            var menuPerfilesActuales = await _repoMenuPerfiles.ListAsync(spec);

            await _repoMenuPerfiles.DeleteRangeAsync(menuPerfilesActuales);
            await _repoMenuPerfiles.AddRangeAsync(entity.TblMenuPerfiles);

            await _repoPerfiles.UpdateAsync(entity);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOne(int id)
        {
            var perfil = await _repoPerfiles.GetByIdAsync(id);
            if (perfil is null)
                return NotFound();

            perfil.BActivo = false;
            await _repoPerfiles.UpdateAsync(perfil);

            return NoContent();
        }
    }
}