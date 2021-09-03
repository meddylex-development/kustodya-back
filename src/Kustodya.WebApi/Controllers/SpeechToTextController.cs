using Google.Apis.Auth.OAuth2;
using Google.Cloud.Speech.V1;
using Grpc.Auth;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.WebApi.Models.SpeechToText;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WebApi.Services;

namespace Kustodya.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeechToTextController : ControllerBase
    {
        private readonly ILoggerService<SpeechToTextController> _logger;
        private readonly ITokenGenerator _tokenGenerator;

        public SpeechToTextController(ITokenGenerator tokenGenerator, ILoggerService<SpeechToTextController> logger)
        {
            _logger = logger;
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromForm]UploadFileModel objRequestFile)
        {
            IFormFile objfile = objRequestFile.file;
            // Full path to file in temp location
            //var filePath = "../Areas/test.png"; // Path.GetTempFileName();
            string ext = Path.GetExtension(objfile.FileName);
            string fileName = objRequestFile.tFileName + ".wav";
            var filePath = Path.Combine(
                  Directory.GetCurrentDirectory(), "Audios",
                 fileName);

            string publicUrl = "";

            try
            {
                if (objfile.Length > 0)
                    using (var stream = new FileStream(filePath, FileMode.Create))
                        await objfile.CopyToAsync(stream);
                // Process uploaded files
                publicUrl = "https://Kustodyawebapi.azurewebsites.net/Audios/" + fileName;
                string text = await GetTextOfAudio(filePath);

                return Ok(new { url = publicUrl, texto = text });
            }
            catch (Exception ex)
            {
                return BadRequest(new { url = publicUrl, message = ex.Message });
            }
        }

        private async Task<string> GetTextOfAudio(string path)
        {
            string keyPath = "key.json";

            GoogleCredential googleCredential;
            using (Stream m = new FileStream(keyPath, FileMode.Open))
                googleCredential = GoogleCredential.FromStream(m);
            var channel = new Grpc.Core.Channel(SpeechClient.DefaultEndpoint.Host,
                googleCredential.ToChannelCredentials());
            var speech = SpeechClient.Create(channel);

            var config = new RecognitionConfig
            {
                //Encoding = RecognitionConfig.Types.AudioEncoding.,
                SampleRateHertz = 48000,
                AudioChannelCount = 2,
                //LanguageCode = LanguageCodes.English.UnitedStates
                LanguageCode = LanguageCodes.Spanish.Colombia
            };
            var audio = RecognitionAudio.FromFile(path);

            var response = await speech.RecognizeAsync(config, audio);

            StringBuilder sb = new StringBuilder();

            foreach (var result in response.Results)
            {
                foreach (var alternative in result.Alternatives)
                {
                    sb.AppendLine(alternative.Transcript);
                }
            }

            return sb.ToString();
        }
    }
}