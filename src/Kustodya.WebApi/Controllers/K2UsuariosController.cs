using AutoMapper;
using Kustodya.ApplicationCore.Entities;
using Kustodya.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kustodya.WebApi.Controllers.Administrativo.Usuarios.Modelos;
using Kustodya.ApplicationCore.Dtos;
using System.Collections;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Kustodya.BussinessLogic.Interfaces.General;
using System.Net;
using System.Text;

namespace Kustodya.WebApi.Controllers
{
    public class K2UsuariosController : BaseController
    {
        private readonly IUsuariosService _usuariosService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        private readonly IAsyncRepository<TblUsuarios> _repo;
        private readonly IBlobService _blobService;


        public K2UsuariosController
            (
            IMapper mapper,
            IUsuariosService usuariosService,
            IWebHostEnvironment env,
            IAsyncRepository<TblUsuarios> repo,
            IBlobService blobService
            )
        {
            _mapper = mapper;
            _usuariosService = usuariosService;
            _env = env;
            _repo = repo;
            _blobService = blobService;
        }

        // Consulta Usuarios por perfil
        [HttpGet("entidad/{entidadId:int}")]
        //[AllowAnonymous]
        public async Task<IActionResult> ConsultarUsuarios(int entidadId, int? perfil, [FromQuery] string busqueda = "", [FromQuery] int pagina = 1, [FromQuery] int cantidad = 10)
        {
            int total = await _usuariosService.TotalUsuariosPerfil(entidadId, perfil, busqueda);
            IReadOnlyList<TblUsuarios> listaUsuarios = await _usuariosService.ObtenerUsuariosporFiltroperfil(entidadId, perfil, busqueda, (pagina - 1) * cantidad, cantidad);
            IReadOnlyList<UsuarioOutputModel> UsuarioOutputModel = _mapper.Map<IReadOnlyList<UsuarioOutputModel>>(listaUsuarios);
            UsuariosOutputModel usuariosOutputModel = new UsuariosOutputModel
            {
                usuariosOutputModel = UsuarioOutputModel,
                paginacion = new PaginacionModel(total, pagina, cantidad)
            };
            return Ok(usuariosOutputModel);
        }

        [HttpPost]
        //[AllowAnonymous]
        public JsonResult SaveFile()
        {
            /*//FTP Server URL.
            string ftp = "win5135.site4now.net";

            //FTP Folder name. Leave blank if you want to upload to root folder.
            string ftpFolder = "db/archivoscalificacionorigen/";

            byte[] fileBytes = null;

            //Read the FileName and convert it to Byte array.
            var httpRequest = Request.Form;
            var postedFile = httpRequest.Files[0];
            string filename = postedFile.FileName;
            //using (StreamReader fileStream = new StreamReader(FileUpload1.PostedFile.InputStream))
            //{
            //    fileBytes = Encoding.UTF8.GetBytes(fileStream.ReadToEnd());
            //    fileStream.Close();
            //}

            try
            {
                //Create FTP Request.   win5135.site4now.net/db/archivoscalificacionorigen
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + ftpFolder + filename);
                request.Method = WebRequestMethods.Ftp.UploadFile;

                //Enter FTP Server credentials.
                request.Credentials = new NetworkCredential("calificacionorigen", "Meddylex123");
                request.ContentLength = fileBytes.Length;
                request.UsePassive = true;
                request.UseBinary = true;
                request.ServicePoint.ConnectionLimit = fileBytes.Length;
                request.EnableSsl = false;

                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(fileBytes, 0, fileBytes.Length);
                    requestStream.Close();
                }

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                response.Close();
                return new JsonResult(filename + " uploaded.<br />");
            }
            catch (WebException ex)
            {
                throw new Exception((ex.Response as FtpWebResponse).StatusDescription);
            }
        }*/
        try
        {
            var httpRequest = Request.Form;
            var postedFile = httpRequest.Files[0];
            string filename = postedFile.FileName;
            var physicalPath = _env.ContentRootPath + "/Files/" + filename;

            using (var stream = new FileStream(physicalPath, FileMode.Create))
            {
                postedFile.CopyTo(stream);
            }
            return new JsonResult(filename);
        }
        catch (Exception)
        {

            return new JsonResult("anonymous.png");
        }
    }

    /*[HttpGet("{usuarioId:int}/Firma")]
    [AllowAnonymous]
    public async Task<IActionResult> Get(int usuarioId)
    {
        TblUsuarios usuario = await _repo.GetByIdAsync(usuarioId);
        if (usuario == null)
            return NotFound("Usuario no existe");
        if (usuario.Firma == null)
            return NotFound("El usuario no tiene firma");
        var stream = await _blobService.GetBlobFileByGuidAsync(usuario.Firma, "firmas");
        if (stream == null) return NotFound("No se encontro la firma del usuario en el repositorio de firmas");
        stream.Position = 0;
        return File(stream, "image/png", "firma.png");
    }*/

    }
}
