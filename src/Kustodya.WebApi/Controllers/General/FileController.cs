using Kustodya.ApplicationCore.Dtos.General;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.Azure.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Azure.Storage.Blob;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System;
using Kustodya.WebApi.Services;
using System.Threading.Tasks;
using Kustodya.ApplicationCore.Constants;
using Kustodya.BussinessLogic.Interfaces.General;
using Kustodya.ApplicationCore.Entities;
using Kustodya.Infrastructure.Data;
using Kustodya.Infrastructure;
using Kustodya.WebApi.Models.General;

namespace Kustodya.WebApi.Controllers.General
{

    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        #region Dependency Injection
        public IConfiguration _configuration { get; set; }
        private IFileHelper _fileHelper { get; set; }
        private IBlobService _blobService { get; set; }
        private IImageService _imageService { get; set; }
        private dbProtektoV1Context _context { get; set; }

        public FileController(IConfiguration configuration, IFileHelper fileHelper, dbProtektoV1Context context, IBlobService blobService, IImageService imageService)
        {
            _blobService = blobService;
            _context = context;
            _fileHelper = fileHelper;
            _configuration = configuration;
            _imageService = imageService;
        }
        #endregion

        [HttpPost]
        public async Task<IActionResult> PostFile([FromForm]FileUpload file)
        {
            // Validations
            if (!int.TryParse(_configuration["KustodyaGeneral:MaxFileUploadSize"], out int maxFileSize))
                throw new Exception("Couldn't load MaxFileUploadSize setting from the appsettings file");
            if (file is null)
                return BadRequest("File can't be empty");
            if (file.File.Length > maxFileSize)
                return BadRequest($"File can't be bigger than {maxFileSize}");

            // Convert to tiff
            using (MemoryStream stream = new MemoryStream())
            {
                await file.File.CopyToAsync(stream);

                //MemoryStream streamPpm = await _imageService.ConvertToPpm(stream).ConfigureAwait(false);
                MemoryStream streamTiff = new MemoryStream(stream.ToArray());

                // Upload blob
                try
                {
                    Guid uuid = await _blobService.UploadToBlobAsync(streamTiff, "mycontainer").ConfigureAwait(false);
                    var blockName = uuid.ToString();

                    var blob = _context.TblBlobs.Add(new TblBlobs
                    {
                        Id = blockName,
                        Creator = file.DocumentoId,
                        MimeType = file.File.ContentType,
                        OriginalName = file.File.FileName,
                        FileType = 1
                    });

                    return Ok(new { id = blob.Entity.Id, status = true, message = "¡UploadFile Done!" });
                }
                catch(Exception)
                {
                    ModelState.AddModelError(GetCurrentMethod(), "An error ocurred connecting to the cloud storage service");
                    return StatusCode(500, ModelState);
                }
                //catch (BadBlobConnectionStringException)
                //{
                //    ModelState.AddModelError(GetCurrentMethod(), "An error ocurred connecting to the cloud storage service");
                //    return StatusCode(500, ModelState);
                //}
                //catch (ErrorUploadingStreamException)
                //{
                //    ModelState.AddModelError(GetCurrentMethod(), "An error ocurred saving the file in the cloud storage service");
                //    return StatusCode(500, ModelState);
                //}
            }
        }

        [HttpDelete("{guid}")]
        public async Task<IActionResult> DeleteFile(string guid)
        {
            if (await _blobService.DeleteBlobAsync(guid))
            {
                return Ok();
            }
            return StatusCode(500, "An error ocurred deleting the file in the cloud storage service");
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private string GetCurrentMethod()
        {
            var st = new StackTrace();
            var sf = st.GetFrame(1);

            return sf.GetMethod().Name;
        }
    }
}