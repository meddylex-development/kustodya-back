using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kustodya.WebApi.Controllers.Administrativo.Clientes
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        /*[HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post(ClienteDetalleInputModel entidadDetalleInputModel)
        {
            Entidad entidad = _mapper.Map<Entidad>(entidadDetalleInputModel);
            entidad.Activo = true;
            if (entidad.Logo != null)
            {
                if (entidad.Logo.Length > 0)
                {
                    byte[] byteArray = Encoding.ASCII.GetBytes(entidad.Logo);
                    MemoryStream stream = new MemoryStream(byteArray);
                    stream.Position = 0;
                    Guid idArchivo = await _blobService.UploadToBlobAsync(stream, "firmas");
                    entidad.Logo = idArchivo.ToString();
                }
            }
            Entidad response = await _repoEntidad.AddAsync(entidad);

            return CreatedAtAction(nameof(ObtenerEntidad), new { id = response.Id }, new EntidadOutputModel
            {
                Id = response.Id,
                Nombre = entidad.RazonSocial + entidad.PrimerNombre + " " + entidad.PrimerApellido
            });
        }*/
    }
}